       IDENTIFICATION DIVISION.
       PROGRAM-ID. EXAM2.
      ******************************************************************
      * Type your full name below. -1 point if it is not done.
      ****************************************************************** 
       AUTHOR. Brianna Muleski
       DATE-WRITTEN. 3/28/14  
      ******************************************************************
      * Purpose:	  
      *     This program generates a report file.
      *     
      * Input:  exam2_part2.dat
      *      
      * Output: exam2_part2.rpt     
      ****************************************************************** 
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.	  	  
       FILE-CONTROL.
           SELECT INPUT-FILE ASSIGN TO "EXAM2_PART2.DAT"
                  ORGANIZATION IS LINE SEQUENTIAL.
           SELECT OUTPUT-FILE ASSIGN TO "EXAM2_PART2.RPT"
                  ORGANIZATION IS LINE SEQUENTIAL. 
       DATA DIVISION.
      ******************************************************************
      * Question 1: Define the record layout for input/output files.
      * (3 points)
      ******************************************************************	 
       FILE SECTION.
       FD  INPUT-FILE.
       01  INPUT-REC.
           05  INIT1       PIC X.
           05  INIT2       PIC X.
           05  LAST-NAME   PIC X(10).
           05  TRANS-MM    PIC XX.
           05  TRANS-YR    PIC X(4).
           05  TRANS-AMT   PIC 9(6).
           
       FD  OUTPUT-FILE.
       01  OUTPUT-REC      PIC X(80).
         
       WORKING-STORAGE SECTION.
       77  EOF               PIC X VALUE 'N'.
       01  WS-DATE.
           05  WS-YEAR       PIC 9(4).
           05  WS-MM         PIC 99.
           05  WS-DD         PIC 99.
      ******************************************************************
      * Question 2: Define the headers and record layout for the report.  
      * (7 points)
      ****************************************************************** 
       01  HD-TITLE.
           05  FILLER      PIC X(30)   VALUE SPACES.
           05  FILLER      PIC X(18)   VALUE "TRANSACTION REPORT".
           05  FILLER      PIC X(32)   VALUE SPACES.
       01  HD-DATE.
           05  FILLER      PIC X(31)   VALUE SPACES.
           05  FILLER      PIC X(6)    VALUE "DATE: ".
           05  HD-MM       PIC 99.
           05  FILLER      PIC X       VALUE "/".
           05  HD-DD       PIC 99.
           05  FILLER      PIC X       VALUE "/".
           05  HD-YEAR     PIC 9(4).
           05  FILLER      PIC X(33)   VALUE SPACES.
       01  HD-NAME.
           05  FILLER      PIC X(30)   VALUE SPACES.
           05  FILLER      PIC X(19)   VALUE "BY: BRIANNA MULESKI".
           05  FILLER      PIC X(31)   VALUE SPACES.
       01  HD-COLUMNS.
           05  FILLER      PIC X(6)    VALUE SPACES.
           05  FILLER      PIC X(4)    VALUE "NAME".
           05  FILLER      PIC X(8)    VALUE SPACES.
           05  FILLER      PIC X(19)   VALUE "DATE OF TRANSACTION".
           05  FILLER      PIC X(5)    VALUE SPACES.
           05  FILLER      PIC X(21)   VALUE "AMOUNT OF TRANSACTION".
           05  FILLER      PIC X(17)   VALUE SPACES.
       01  TRANS-REC.
           05  FILLER      PIC X       VALUE SPACE.
           05  D-INIT1     PIC X.
           05  FILLER      PIC X       VALUE ".".
           05  D-INIT2     PIC X.
           05  FILLER      PIC X       VALUE ".".
           05  D-NAME      PIC X(10).
           05  FILLER      PIC X(9)    VALUE SPACES.
           05  D-TRANS-M   PIC XX.
           05  FILLER      PIC X       VALUE "/".
           05  D-TRANS-Y   PIC X(4).
           05  FILLER      PIC X(19)   VALUE SPACES.
           05  D-TRANS-AMT PIC ZZZ,ZZ9.
                
       PROCEDURE DIVISION.
       000-MAIN.
           OPEN INPUT INPUT-FILE
           OPEN OUTPUT OUTPUT-FILE
           PERFORM 050-PRINT-HEADER   
           PERFORM 100-PROCESS-INFILE UNTIL EOF = 'Y'
           CLOSE INPUT-FILE OUTPUT-FILE
           DISPLAY "DONE"
           STOP RUN.    
      ******************************************************************
      * Question 3: Write COBOL codes to print out the headers.  
      * (3 points)
      ******************************************************************  		   
       050-PRINT-HEADER.
           MOVE FUNCTION CURRENT-DATE TO WS-DATE
           MOVE WS-YEAR               TO HD-YEAR
           MOVE WS-MM                 TO HD-MM
           MOVE WS-DD                 TO HD-DD
           
           WRITE OUTPUT-REC FROM HD-TITLE
           WRITE OUTPUT-REC FROM HD-DATE
           WRITE OUTPUT-REC FROM HD-NAME
           WRITE OUTPUT-REC FROM HD-COLUMNS
               AFTER ADVANCING 2 LINES.
	  
       100-PROCESS-INFILE.
           READ INPUT-FILE
               AT END
                  MOVE 'Y' TO EOF
               NOT AT END
                  PERFORM 200-WRITE-REPORT
           END-READ.
      ******************************************************************
      * Question 4: Write COBOL codes to print out a record on the 
      *             report.  
      * (2 points)
      ******************************************************************  		   
       200-WRITE-REPORT.
           MOVE INIT1     TO D-INIT1
           MOVE INIT2     TO D-INIT2
           MOVE LAST-NAME TO D-NAME
           MOVE TRANS-MM  TO D-TRANS-M
           MOVE TRANS-YR  TO D-TRANS-Y
           MOVE TRANS-AMT TO D-TRANS-AMT 
           
           WRITE OUTPUT-REC FROM TRANS-REC
               AFTER ADVANCING 2 LINES.       
