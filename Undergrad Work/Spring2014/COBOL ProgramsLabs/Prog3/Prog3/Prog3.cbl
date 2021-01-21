       IDENTIFICATION DIVISION.
       PROGRAM-ID. Prog3
       AUTHOR. Brianna Muleski
       DATE-WRITTEN. 4/4/14
      ******************************************************************
      * Purpose:
      *    Generates a summary report based on the store locations of 
      *    the International Chocolates Company. The report will be
      *    sorted based of the store number and customer number. The
      *    report will inclode the transaction records of each store,
      *    the total sales amount of each store, and the total sales
      *    amount of all the stores.
      *
      * Input:
      *    program3.dat
      *    The transaction records of the company that is line
      *    sequential.
      *    
      * Output:
      *    program3.rpt
      *    Report summary that includes the transaction information and
      *    sales totals in a formatted layout.
      *
      ******************************************************************
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
           SELECT SORT-FILE ASSIGN TO "SORT.DAT".
           SELECT IN-FILE ASSIGN TO "PROGRAM3.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT OUT-FILE ASSIGN TO "PROGRAM3.RPT"
               ORGANIZATION IS LINE SEQUENTIAL.
      *
       DATA DIVISION.
       SD SORT-FILE.
       01  SORT-REC.
           05  SRT-CUST-NO     PIC 9(4).
           05  FILLER          PIC X(10).
           05  SRT-STORE-NO    PIC 9.
           05  FILLER          PIC 9(16).
           
       FD IN-FILE.
       01  IN-REC.
           05  CUST-NO         PIC 9(4).
           05  CUST-NAME       PIC X(10).
           05  STORE-NO        PIC 9.
               88  NY                          VALUE 1.
               88  LA                          VALUE 2.
               88  MI                          VALUE 3.
               88  CHI                         VALUE 4.
           05  SALEPER-NO      PIC 999.
           05  SALES-AMT       PIC 999V99.
           05  TRANS-DATE.
               10  TRANS-MM    PIC 99.
               10  TRANS-DD    PIC 99.
               10  TRANS-YEAR  PIC 9(4).
       
       FD OUT-FILE.
       01  OUT-REC             PIC X(80).
      *
       WORKING-STORAGE SECTION.
       01  HD-TITLE.
           05  FILLER          PIC X(6)        VALUE "DATE: ".
           05  HD-MM           PIC 99.
           05  FILLER          PIC X           VALUE "/".
           05  HD-DD           PIC 99.
           05  FILLER          PIC X           VALUE "/".
           05  HD-YEAR         PIC 9(4).
           05  FILLER          PIC X(7)        VALUE SPACES.
           05  FILLER          PIC X(32)       VALUE
                                    "INTERNATIONAL CHOCOLATES COMPANY".
           05  FILLER          PIC X(8)        VALUE SPACES.
           05  FILLER          PIC X(5)        VALUE "PAGE ".
           05  PAGE-NO         PIC Z9.
           05  FILLER          PIC X(10)       VALUE SPACES.
       
       01  HD-SUBTITLE.
           05  FILLER          PIC X(6)        VALUE "TIME: ".
           05  HD-HOUR         PIC 99.
           05  FILLER          PIC X           VALUE ":".
           05  HD-MIN          PIC 99.
           05  FILLER          PIC X(14)       VALUE SPACES.
           05  FILLER          PIC X(26)       VALUE 
                                           "STORE TRANSACTIONS SUMMARY".
           05  FILLER          PIC X(4)        VALUE SPACES.
           05  FILLER          PIC X(15)       VALUE "BRIANNA MULESKI".
           05  FILLER          PIC X(10)       VALUE SPACES.
       
       01  HD-STORE-NAME.
           05  FILLER          PIC X(7)        VALUE "STORE: ".
           05  HD-STORE        PIC X(11).
           05  FILLER          PIC X(62)       VALUE SPACES.
           
       01  HD-COLUMNS1.
           05  FILLER          PIC X(8)        VALUE "CUSTOMER".
           05  FILLER          PIC X           VALUE SPACE.
           05  FILLER          PIC X(8)        VALUE "CUSTOMER".
           05  FILLER          PIC X(4)        VALUE SPACES.
           05  FILLER          PIC X(6)        VALUE "SALES-".
           05  FILLER          PIC XX          VALUE SPACES.
           05  FILLER          PIC X(5)        VALUE "SALES".
           05  FILLER          PIC X(5)        VALUE SPACES.
           05  FILLER          PIC X(11)       VALUE "TRANSACTION".
           05  FILLER          PIC X(30)       VALUE SPACES.
           
       01  HD-COLUMNS2.
           05  FILLER          PIC X(5)        VALUE "  NUM".
           05  FILLER          PIC X(4)        VALUE SPACES.
           05  FILLER          PIC X(4)        VALUE "NAME".
           05  FILLER          PIC X(8)        VALUE SPACES.
           05  FILLER          PIC X(8)        VALUE "PERSON  ".
           05  FILLER          PIC X(6)        VALUE "AMOUNT".
           05  FILLER          PIC X(8)        VALUE SPACES.
           05  FILLER          PIC X(4)        VALUE "DATE".
           05  FILLER          PIC X(33)       VALUE SPACES.
           
       01  CUSTOMER-REC.
           05  FILLER          PIC XX          VALUE SPACES.
           05  D-CUST-NO       PIC 9(4).
           05  FILLER          PIC XXX         VALUE SPACES.
           05  D-CUST-NAME     PIC X(10).
           05  FILLER          PIC XXX         VALUE SPACES.
           05  D-SALEPER-NO    PIC 999.
           05  FILLER          PIC X(4)        VALUE SPACES.
           05  D-SALES-AMT     PIC 999.99.
           05  FILLER          PIC X(5)        VALUE SPACES.
           05  D-TRANS-MM      PIC 99.
           05  FILLER          PIC X           VALUE "/".
           05  D-TRANS-DD      PIC 99.
           05  FILLER          PIC X           VALUE "/".
           05  D-TRANS-YEAR    PIC 9(4).
           05  FILLER          PIC X(30)       VALUE SPACES.
       
       01  FD-STORE-TOTAL.
           05  FILLER          PIC X(9)        VALUE SPACES.
           05  FILLER          PIC X(11)       VALUE "STORE TOTAL".
           05  FILLER          PIC X(5)        VALUE SPACES.
           05  D-STORE-TOT     PIC $$$,$$9.99.
           05  FILLER          PIC X(45)       VALUE SPACES.
           
       01  FD-GRAND-TOTAL.
           05  FILLER          PIC X(9)        VALUE SPACES.
           05  FILLER          PIC X(11)       VALUE "GRAND TOTAL".
           05  FILLER          PIC XXX         VALUE SPACES.
           05  D-GRAND-TOT     PIC $,$$$,$$9.99.
           05  FILLER          PIC X(45)       VALUE SPACES.
           
       01  WORKING-ITEMS.
           05  STORE-TOT       PIC 9(6)V99.
           05  GRAND-TOT       PIC 9(7)V99.
           05  WS-DATE.
               10  WS-YEAR     PIC 9(4).
               10  WS-MM       PIC 99.
               10  WS-DD       PIC 99.
               10  WS-HR       PIC 99.
               10  WS-MIN      PIC 99.
           05  EOF-SWITCH      PIC X           VALUE 'N'.
           05  PG-COUNT        PIC 99          VALUE 01.
           05  FIRST-REC       PIC X           VALUE 'Y'.
           05  HOLD-STORE-NO   PIC 9.
      *
       PROCEDURE DIVISION.
       000-MAIN.
           PERFORM 100-SORT
           PERFORM 200-OPEN-FILES
           PERFORM 250-PRINT-FIRST-HEADER
           PERFORM 300-READ UNTIL EOF-SWITCH = 'Y'
           PERFORM 900-CLOSE-FILES
           
           DISPLAY "REPORT GENERATED!"
           
           STOP RUN.
           
      * Sorts the input file and overwrites the file with a sorted 
      * version of the input file. 
       100-SORT.
           SORT SORT-FILE
               ON ASCENDING KEY SRT-STORE-NO
                                SRT-CUST-NO
                   USING IN-FILE
                   GIVING IN-FILE.
                   
      * Opens the input and output files. 
       200-OPEN-FILES.
           OPEN INPUT IN-FILE
           OPEN OUTPUT OUT-FILE.
           
      * Prints the headers for the first page.
       250-PRINT-FIRST-HEADER.
           PERFORM 450-MOVE-HEADER-INFO
           MOVE 'NEW YORK' TO HD-STORE
           
           WRITE OUT-REC FROM HD-TITLE
           WRITE OUT-REC FROM HD-SUBTITLE
           WRITE OUT-REC FROM HD-STORE-NAME
               AFTER ADVANCING 1 LINE
           WRITE OUT-REC FROM HD-COLUMNS1
               AFTER ADVANCING 2 LINES
           WRITE OUT-REC FROM HD-COLUMNS2
               AFTER ADVANCING 1 LINE.  
               
      * Reads the input file until the end of the file is reached. When
      * the end-of-file is reached, the eof-switch is changed to 'y', 
      * the store total is printed for the last store, and the grand
      * total is printed. When the file is not at the end, the store
      * number is compared to the hold number to determine if it belongs
      * on the same page or if there needs to be a page break for a new
      * store.
       300-READ.
           READ IN-FILE
               AT END
                   MOVE 'Y' TO EOF-SWITCH
                   PERFORM 700-PRINT-STORE-TOTAL
                   PERFORM 800-PRINT-TOTAL
               NOT AT END
                   IF FIRST-REC = 'Y'
                       MOVE STORE-NO TO HOLD-STORE-NO
                       MOVE 'N' TO FIRST-REC 
                       
                    END-IF  
                    IF STORE-NO = HOLD-STORE-NO
                       PERFORM 600-PRINT-CUST-REC
                   ELSE
                       PERFORM 700-PRINT-STORE-TOTAL
                       PERFORM 400-PRINT-HEADERS
                       PERFORM 600-PRINT-CUST-REC
                   END-IF
           END-READ.
      
      * Prints the headers for the pages after the first page.  
       400-PRINT-HEADERS.
           PERFORM 450-MOVE-HEADER-INFO
           PERFORM 500-EVALUATE-STORE
           
           WRITE OUT-REC FROM HD-TITLE
               AFTER ADVANCING PAGE
           WRITE OUT-REC FROM HD-SUBTITLE
           WRITE OUT-REC FROM HD-STORE-NAME
               AFTER ADVANCING 1 LINE
           WRITE OUT-REC FROM HD-COLUMNS1
               AFTER ADVANCING 2 LINES
           WRITE OUT-REC FROM HD-COLUMNS2
               AFTER ADVANCING 1 LINE.
     
      * Moves the information needed for printing the headers from
      * working storage to edited items.          
       450-MOVE-HEADER-INFO.
           MOVE FUNCTION CURRENT-DATE TO WS-DATE
           MOVE WS-MM TO HD-MM
           MOVE WS-DD TO HD-DD
           MOVE WS-YEAR TO HD-YEAR
           MOVE WS-HR TO HD-HOUR
           MOVE WS-MIN TO HD-MIN
           
           MOVE PG-COUNT TO PAGE-NO. 
      
      * Determines what store name should be printed at the top of the 
      * page.     
       500-EVALUATE-STORE.
           EVALUATE TRUE
               WHEN NY
                   MOVE "NEW YORK" TO HD-STORE
               WHEN LA
                   MOVE "LOS ANGELES" TO HD-STORE
               WHEN MI
                   MOVE "MIAMI" TO HD-STORE
               WHEN CHI
                   MOVE "CHICAGO" TO HD-STORE
           END-EVALUATE.
      
      * Prints a single customer record.     
       600-PRINT-CUST-REC.
           MOVE CUST-NO    TO D-CUST-NO
           MOVE CUST-NAME  TO D-CUST-NAME
           MOVE SALEPER-NO TO D-SALEPER-NO
           MOVE SALES-AMT  TO D-SALES-AMT
           MOVE TRANS-MM   TO D-TRANS-MM
           MOVE TRANS-DD   TO D-TRANS-DD
           MOVE TRANS-YEAR TO D-TRANS-YEAR
           
           ADD SALES-AMT TO STORE-TOT
           
           WRITE OUT-REC FROM CUSTOMER-REC 
               AFTER ADVANCING 2 LINES.
      
      * Prints the store total at the end of the page, resets the store
      * total after the amount is added to the grand total, increments 
      * the page count, and changes the first record switch to 'y'. 
       700-PRINT-STORE-TOTAL.
           MOVE STORE-TOT TO D-STORE-TOT
           ADD STORE-TOT TO GRAND-TOT
           MOVE ZEROS TO STORE-TOT
           
           WRITE OUT-REC FROM FD-STORE-TOTAL
               AFTER ADVANCING 2 LINES
           ADD 1 TO PG-COUNT
           MOVE 'Y' TO FIRST-REC.
      
      * Prints the grand total for the company.     
       800-PRINT-TOTAL.
           MOVE GRAND-TOT TO D-GRAND-TOT
           
           WRITE OUT-REC FROM FD-GRAND-TOTAL
               AFTER ADVANCING 2 LINES.
      
      * Closes the input and output files.         
       900-CLOSE-FILES.
           CLOSE IN-FILE
           CLOSE OUT-FILE.