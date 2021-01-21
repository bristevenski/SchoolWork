       IDENTIFICATION DIVISION.
       PROGRAM-ID. Prog4
       AUTHOR. Brianna Muleski
       DATE-WRITTEN. 4/23/14
      ******************************************************************
      * Purpose:
      *    Processing the payroll of the International Chocolates
      *    Company and creating a detail report for all employees.
      * Input:
      *    PROGRAM4.DAT
      *        A line sequential file of the hours and standard pay 
      *        rates for all employees
      *    TAX.DAT
      *        A line sequential file of the tax rates
      * Output:
      *    PROGRAM4.RPT
      *        A detail report that includes employee id, hours, pay
      *        rate, gross pay, tax rate, income tax withheld, and net
      *        pay of each employee
      *    EXCEPTIONS.RPT
      *        An exception report for each abnormal record
      ******************************************************************
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
           SELECT IN-FILE ASSIGN TO "PROGRAM4.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT TAX-FILE ASSIGN TO "TAX.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT OUT-FILE ASSIGN TO "PROGRAM4.RPT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT EX-FILE ASSIGN TO "EXCEPTIONS.RPT"
               ORGANIZATION IS LINE SEQUENTIAL.
      *
       DATA DIVISION.
       FD  IN-FILE.
       01  IN-REC.
           05  IN-EMP-ID       PIC X(4).
           05  IN-HR           PIC 99.
           05  IN-PAY-RT       PIC 999V9.
           
       FD  TAX-FILE.
       01  TAX-REC.
           05  WG-LVL          PIC 9(4).
           05  TX-RT           PIC V999.
           
       FD  OUT-FILE.
       01  OUT-REC             PIC X(80).
       
       FD  EX-FILE.
       01  EX-REC              PIC X(80).
      *
       WORKING-STORAGE SECTION.
       01  WORKING-ITEMS.
           05  WS-GRS-PAY      PIC 9(4)V99.
           05  WS-NET-PAY      PIC 9(4)V99.
           05  WS-TAX          PIC 9(4)V99.
           05  WS-GRS-TOT      PIC 9(6)V99.
           05  WS-TAX-TOT      PIC 9(5)V99.
           05  WS-NET-TOT      PIC 9(6)V99.
           05  WS-DATE.
               10  WS-YEAR     PIC 9(4).
               10  WS-MM       PIC 99.
               10  WS-DD       PIC 99.
               10  WS-HR       PIC 99.
               10  WS-MIN      PIC 99.
           05  ERRORS          PIC 99      VALUE 0.
           05  OT-HR-ERR       PIC X       VALUE 'N'.
           05  NO-HR-ERR       PIC X       VALUE 'N'.
           05  EOF-SWITCH      PIC X       VALUE 'N'.
           05  WS-TAX-RT       PIC V999.

       01  CONSTANTS.
           05  MAX-HRS         PIC 99      VALUE 60.       
           05  PERCENT         PIC 999     VALUE 100.
           05  NO-TAX-RT       PIC 9       VALUE 7.
           05  NO-OT           PIC 99      VALUE 40.
           05  OT-RT           PIC 9V9     VALUE 1.5.    
           05  MAX-TX          PIC V999    VALUE .150.
           
       01  TAX-TABLE.
           05  TAX-TABLE-REC OCCURS 7 TIMES INDEXED BY INDX.
               10  TB-WG-LVL   PIC 9(4).
               10  TB-TX-RT    PIC V999.
               
       01  HD-TITLE.
           05  FILLER          PIC X(6)    VALUE "DATE: ".
           05  HD-MM           PIC 99.
           05  FILLER          PIC X       VALUE "/".
           05  HD-DD           PIC 99.
           05  FILLER          PIC X       VALUE "/".
           05  HD-YEAR         PIC 9(4).
           05  FILLER          PIC X(8)    VALUE SPACES.
           05  FILLER          PIC X(32)   VALUE
                                   "INTERNATIONAL CHOCOLATES COMPANY".
           05  FILLER          PIC X(9)    VALUE SPACES.
           05  FILLER          PIC X(15)   VALUE "BRIANNA MULESKI".
           
       01  HD-SUBTITLE.
           05  FILLER          PIC X(6)    VALUE "TIME: ".
           05  HD-HR           PIC 99.
           05  FILLER          PIC X       VALUE ":".
           05  HD-MIN          PIC 99.
           05  FILLER          PIC X(21)   VALUE SPACES.
           05  FILLER          PIC X(16)   VALUE "EMPLOYEE PAYROLL".
       
       01  HD-COLUMNS.
           05  FILLER          PIC X(10)   VALUE "EMP ID    ".
           05  FILLER          PIC X(9)    VALUE "HOURS    ".
           05  FILLER          PIC X(8)    VALUE "PAY RATE".
           05  FILLER          PIC X(5)    VALUE SPACES.
           05  FILLER          PIC X(9)    VALUE "GROSS PAY".
           05  FILLER          PIC X(5)    VALUE SPACES.
           05  FILLER          PIC X(8)    VALUE "TAX RATE".
           05  FILLER          PIC X(5)    VALUE SPACES.
           05  FILLER          PIC X(12)   VALUE "TAX WITHHELD".
           05  FILLER          PIC X(9)    VALUE "  NET PAY".
       
       01  HD-DASHES.
           05  FILLER  OCCURS 80 TIMES     VALUE "=".
           
       01  D-EMP-REC.
           05  D-EMP-ID        PIC X(4).
           05  FILLER          PIC X(7)    VALUE SPACES.
           05  D-HRS           PIC Z9.
           05  FILLER          PIC X(7)    VALUE SPACES.
           05  D-PAY-RT        PIC ZZ9.9.
           05  FILLER          PIC X(8)    VALUE SPACES.
           05  D-GRS-PAY       PIC Z,ZZ9.99.
           05  FILLER          PIC X(6)    VALUE SPACES.
           05  D-TX-RT         PIC Z9.99.
           05  FILLER          PIC X       VALUE "%".
           05  FILLER          PIC X(8)    VALUE SPACES.
           05  D-TAX           PIC Z,ZZ9.99.
           05  FILLER          PIC X(3)    VALUE SPACES.
           05  D-NET-PAY       PIC Z,ZZ9.99.
           
       01  F-TOTALS.
           05  FILLER          PIC X(20)   VALUE SPACES.
           05  FILLER          PIC X(7)    VALUE "TOTALS:".
           05  FILLER          PIC X(4)    VALUE SPACES.
           05  F-GRS-TOT       PIC $$$,$$9.99.
           05  FILLER          PIC X(19)   VALUE SPACES.
           05  F-TAX-TOT       PIC $$,$$9.99.
           05  FILLER          PIC X       VALUE SPACE.
           05  F-NET-TOT       PIC $$$,$$9.99.
           
       01  HD-ERR-COLUMNS.
           05  FILLER          PIC X(6)    VALUE "EMP ID".
           05  FILLER          PIC X(4)    VALUE SPACES.
           05  FILLER          PIC X(5)    VALUE "HOURS".
           05  FILLER          PIC X(4)    VALUE SPACES.
           05  FILLER          PIC X(8)    VALUE "PAY RATE".
           05  FILLER          PIC X(4)    VALUE SPACES.
           05  FILLER          PIC X(13)   VALUE "ERROR MESSAGE".
       
       01  D-ERR-REC.
           05  DE-EMP-ID       PIC X(4).
           05  FILLER          PIC X(7)    VALUE SPACES.
           05  DE-HRS          PIC Z9.
           05  FILLER          PIC X(7)    VALUE SPACES.
           05  DE-PAY-RT       PIC ZZ9.9.
           05  FILLER          PIC X(6)    VALUE SPACES.
           05  DE-ERR-MSG      PIC X(31).
       
       01  F-TOTAL-ERRORS.
           05  F-ERR-TOT       PIC Z9.
           05  FILLER          PIC X(14)   VALUE " ERROR RECORDS".
      *
       PROCEDURE DIVISION.
       000-MAIN.
           PERFORM 100-OPEN-FILES
           PERFORM 200-LOAD-TAX-TABLE
           PERFORM 250-WRITE-HEADERS
           PERFORM 300-READ-INPUT-FILE UNTIL EOF-SWITCH = 'Y'
           PERFORM 900-PRINT-TOTALS
           PERFORM 950-CLOSE-FILES
           
           DISPLAY "REPORTS GENERATED!".
           
      * Opens the input and output files.
       100-OPEN-FILES.
           OPEN INPUT  IN-FILE
           OPEN INPUT  TAX-FILE 
           OPEN OUTPUT OUT-FILE
           OPEN OUTPUT EX-FILE.
           
      * Loads the tax table by reading in the tax-file and adding the
      * the info into the run-time table defined the in the working
      * storage. Closes the tax-file when the end is reached.
       200-LOAD-TAX-TABLE.
           PERFORM VARYING INDX FROM 1 BY 1 UNTIL INDX > NO-TAX-RT
               READ TAX-FILE
                   AT END
                       CLOSE TAX-FILE
                   NOT AT END
                       MOVE WG-LVL TO TB-WG-LVL(INDX)
                       MOVE TX-RT TO TB-TX-RT(INDX)
           END-PERFORM.
           
      * Writes the headers on both the output file and the exception
      * file.
       250-WRITE-HEADERS.
           MOVE FUNCTION CURRENT-DATE TO WS-DATE
           MOVE WS-YEAR TO HD-YEAR
           MOVE WS-MM   TO HD-MM
           MOVE WS-DD   TO HD-DD
           MOVE WS-HR   TO HD-HR
           MOVE WS-MIN  TO HD-MIN
           
           WRITE OUT-REC FROM HD-TITLE
           WRITE OUT-REC FROM HD-SUBTITLE
           WRITE OUT-REC FROM HD-COLUMNS
               AFTER ADVANCING 1 LINE
           WRITE OUT-REC FROM HD-DASHES
           
           WRITE EX-REC FROM HD-TITLE
           WRITE EX-REC FROM HD-SUBTITLE
           WRITE EX-REC FROM HD-ERR-COLUMNS
               AFTER ADVANCING 1 LINE
           WRITE EX-REC FROM HD-DASHES.
       
      * Reads the input file. After each record is read calulations are
      * made and the record is printed. At the end of the file, the 
      * eof-switch is switched from 'N' to 'Y'.
       300-READ-INPUT-FILE.
           READ IN-FILE
               AT END
                   MOVE 'Y' TO EOF-SWITCH
               NOT AT END
                   PERFORM 400-CALCULATIONS
                   PERFORM 600-PRINT-RECORD
           END-READ.
           
      * Calculates the gross pay of a single employee. If an error is 
      * found then the error is flagged and the error is added to the 
      * amount of errors found. If there is not error than the tax and
      * net pay are found and then added to the totals.
       400-CALCULATIONS.
           MOVE 'N' TO NO-HR-ERR
           MOVE 'N' TO OT-HR-ERR
           IF IN-HR = ZERO
               ADD 1 TO ERRORS
               MOVE 'Y' TO NO-HR-ERR
           ELSE IF IN-HR <= NO-OT
               COMPUTE WS-GRS-PAY = IN-HR * IN-PAY-RT
           ELSE IF IN-HR > NO-OT AND <= MAX-HRS
               COMPUTE WS-GRS-PAY = NO-OT * IN-PAY-RT + 
                                   ((IN-HR - NO-OT) * IN-PAY-RT * OT-RT)
           ELSE 
               ADD 1 TO ERRORS
               MOVE 'Y' TO OT-HR-ERR
           END-IF.
           
           IF NO-HR-ERR = 'N' AND OT-HR-ERR = 'N'
               PERFORM 500-COMPUTE-TAX
               COMPUTE WS-NET-PAY = WS-GRS-PAY - WS-TAX 
               ADD WS-GRS-PAY TO WS-GRS-TOT
               ADD WS-TAX TO WS-TAX-TOT
               ADD WS-NET-PAY TO WS-NET-TOT
           END-IF.
           
      * Computes the tax of a single record. Searches the tax table to
      * determine how much tax is being withheld.
       500-COMPUTE-TAX.
           SET INDX TO 1
           SEARCH  TAX-TABLE-REC
               AT END
                   MOVE MAX-TX TO WS-TAX-RT
               WHEN WS-GRS-PAY < TB-WG-LVL(INDX)
                   MOVE TB-TX-RT(INDX) TO WS-TAX-RT
           END-SEARCH
           
           COMPUTE WS-TAX = WS-GRS-PAY * WS-TAX-RT.
           
      * Prints a record of one employee. If an error was found, then
      * the error record is printed.
       600-PRINT-RECORD.
           IF OT-HR-ERR = 'Y' OR NO-HR-ERR = 'Y'
               PERFORM 800-PRINT-ERROR-RECORD
           ELSE 
               PERFORM 700-MOVE-EMP-INFO
               WRITE OUT-REC FROM D-EMP-REC 
                   BEFORE ADVANCING 1 LINE
           END-IF.
           
      * Moves the necessary information to edited versions in order to 
      * print.
       700-MOVE-EMP-INFO.
           MOVE IN-EMP-ID  TO D-EMP-ID
           MOVE IN-HR      TO D-HRS
           MOVE IN-PAY-RT  TO D-PAY-RT
           MOVE WS-GRS-PAY TO D-GRS-PAY
           MOVE WS-TAX     TO D-TAX
           MOVE WS-NET-PAY TO D-NET-PAY
           
           COMPUTE D-TX-RT = WS-TAX-RT * PERCENT.
           
      * Prints a single error record.
       800-PRINT-ERROR-RECORD.
           IF NO-HR-ERR = 'Y'
               MOVE "Number of hours is ZERO!!" TO DE-ERR-MSG
           ELSE IF OT-HR-ERR = 'Y'
               MOVE "Exceeds maximum overtime hours!" TO DE-ERR-MSG
           END-IF.

           MOVE IN-EMP-ID TO DE-EMP-ID
           MOVE IN-HR     TO DE-HRS
           MOVE IN-PAY-RT TO DE-PAY-RT
           
           WRITE EX-REC FROM D-ERR-REC
               BEFORE ADVANCING 1 LINE.
               
      * Prints the gross pay, tax withheld, net pay, and error totals.
       900-PRINT-TOTALS.
           MOVE ERRORS TO F-ERR-TOT
           
           WRITE EX-REC FROM HD-DASHES
           WRITE EX-REC FROM F-TOTAL-ERRORS
               
           MOVE WS-GRS-TOT TO F-GRS-TOT
           MOVE WS-TAX-TOT TO F-TAX-TOT
           MOVE WS-NET-TOT TO F-NET-TOT
           
           WRITE OUT-REC FROM HD-DASHES
           WRITE OUT-REC FROM F-TOTALS.
           
      * Closes the input and output files.
       950-CLOSE-FILES.
           CLOSE IN-FILE
           CLOSE OUT-FILE
           CLOSE EX-FILE.