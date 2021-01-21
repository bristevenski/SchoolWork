       IDENTIFICATION DIVISION.
       PROGRAM-ID. PhaseII
       AUTHOR. Brianna Muleski
               Andrew Iverson
       DATE-WRITTEN. 3/26/14
      ******************************************************************
      * Purpose: 
      *    This program will sort the transaction records by 
      *    customer number and item number, and create a report
      *    with the running total of the sales amount, sales tax
      *    and transaction amount of all transactions.
      *
      * Input: 
      *    PhaseII.dat
      *
      * Output:
      *    TransactionReport.rpt
      ******************************************************************
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
           SELECT SORT-FILE ASSIGN TO "SORT.DAT".
           SELECT INPUT-FILE ASSIGN TO "PHASEII.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT OUTPUT-FILE ASSIGN TO "TRANSACTIONREPORT.RPT"
               ORGANIZATION IS LINE SEQUENTIAL.
      *
       DATA DIVISION.
      *
       SD  SORT-FILE.
       01  SORT-REC.
           05  SRT-CUST-NO     PIC 9(5).
           05  FILLER          PIC X(20).
           05  SRT-ITEM-NO     PIC X(4).
           05  FILLER          PIC X(24).      
       
       FD  INPUT-FILE.
       01 INPUT-REC.
           05  CUST-NO         PIC 9(5).
           05  CUST-NAME       PIC X(20).
           05  ITEM-NO.
               10  DEPT-CODE   PIC X.
                   88  HOME                    VALUE '1'.
                   88  ELECTRONIC              VALUE '2'.
                   88  GROCERY                 VALUE '3'.
                   88  AUTOMOBILE              VALUE '4'.
               10  ITEM-CODE   PIC X(3).
           05  ITEM-DESC       PIC X(15).
           05  UNIT-PRICE      PIC 9(6).
           05  QUANTITY        PIC 9(3).
       
       FD  OUTPUT-FILE.
       01  OUTPUT-REC          PIC X(80).
      * 
       WORKING-STORAGE SECTION.
      *
       01  WORKING-ITEMS.
           05  SALES-AMT       PIC 9(7)V99.
           05  SALES-TAX       PIC 9(6)V99.
           05  TRANS-AMT       PIC 9(8)V99.
           05  SALES-TOT       PIC 9(8)V99.
           05  TAX-TOT         PIC 9(7)V99.
           05  TRANS-TOT       PIC 9(9)V99.
           05  EOF-SWITCH      PIC X.
           05  WS-DATE.
               10  WS-YEAR     PIC 9(4).
               10  WS-MM       PIC 99.
               10  WS-DAY      PIC 99.
               10  WS-HR       PIC 99.
               10  WS-MIN      PIC 99.
           05  PG-COUNT        PIC 9       VALUE 1.
           05  LN-COUNT        PIC 99      VALUE 01.
       01  CONSTANTS.
           05  TAX-AMT         PIC V999    VALUE .055.
           05  MAX-LINE        PIC 99      VALUE 55.
           05  THREE-LN-CT     PIC 9       VALUE 3.
           05  FIVE-LN-CT      PIC 9       VALUE 5.
       01  HD-TITLE.
           05  FILLER          PIC X(6)    VALUE "DATE: ".
           05  HD-MM           PIC 99.
           05  FILLER          PIC X       VALUE "/".
           05  HD-DD           PIC 99.
           05  FILLER          PIC X       VALUE "/".
           05  HD-YEAR         PIC 9(4).
           05  FILLER          PIC X(20)   VALUE SPACES.
           05  FILLER          PIC X(8)    VALUE "FastMart".
           05  FILLER          PIC X(29)   VALUE SPACES.
           05  FILLER          PIC X(5)    VALUE "PAGE:".
           05  PAGE-NO         PIC 99.
       01  HD-SUBTITLE.
           05  FILLER          PIC X(6)    VALUE "TIME: ".
           05  HD-HOUR         PIC 99.
           05  FILLER          PIC X       VALUE ":".
           05  HD-MIN          PIC 99.
           05  FILLER          PIC X(20)   VALUE SPACES.
           05  FILLER          PIC X(18)   VALUE "TRANSACTION REPORT".
           05  FILLER          PIC X(31)   VALUE SPACES.
       01  HD-COLUMN1.
           05  FILLER          PIC X(8)    VALUE "CUSTOMER".
           05  FILLER          PIC X(7)    VALUE SPACES.
           05  FILLER          PIC X(8)    VALUE "CUSTOMER".
           05  FILLER          PIC X(7)    VALUE SPACES.
           05  FILLER          PIC X(10)   VALUE "DEPARTMENT".
           05  FILLER          PIC X(11)   VALUE " ITEM      ".
           05  FILLER          PIC X(4)    VALUE "ITEM".
           05  FILLER          PIC X(10)   VALUE SPACES.
           05  FILLER          PIC X(4)    VALUE "UNIT".
           05  FILLER          PIC X(11)   VALUE SPACES.
       01  HD-COLUMN2.
           05  FILLER          PIC X(7)    VALUE " NUMBER".
           05  FILLER          PIC X(10)   VALUE SPACES.
           05  FILLER          PIC X(4)    VALUE "NAME".
           05  FILLER          PIC X(12)   VALUE SPACES.
           05  FILLER          PIC X(12)   VALUE "CODE    CODE".
           05  FILLER          PIC X(14)   VALUE "   DESCRIPTION".
           05  FILLER          PIC X(11)   VALUE "      PRICE".
           05  FILLER          PIC X(10)   VALUE "  QUANTITY".
       01  SALES-SUMMARY.
           05  FILLER          PIC X(10)   VALUE SPACES.
           05  FILLER          PIC X(10)   VALUE "SALES AMT:".
           05  D-SALES-AMT     PIC $$,$$$,$$9.99.
           05  FILLER          PIC X(11)   VALUE " SALES TAX:".
           05  D-SALES-TAX     PIC $$$$,$$9.99.
           05  FILLER          PIC X(11)   VALUE " TRANS AMT:".
           05  D-TRANS-AMT     PIC $$$,$$$,$$9.99.
       01  CUST-REC.
           05  FILLER          PIC XX      VALUE SPACES.
           05  D-CUST-NO       PIC X(5).
           05  FILLER          PIC XX      VALUE SPACES.
           05  D-CUST-NM       PIC X(20).
           05  FILLER          PIC X       VALUE SPACE.
           05  D-DEPT-CO       PIC X(10).
           05  FILLER          PIC X       VALUE SPACE.
           05  D-ITEM-CO       PIC XXX.
           05  FILLER          PIC XX      VALUE SPACES.
           05  D-DESC          PIC X(15).
           05  FILLER          PIC XX      VALUE SPACES.
           05  D-PRICE         PIC $Z,ZZ9.99.
           05  FILLER          PIC XXX     VALUE SPACES.
           05  D-QUANTITY      PIC ZZ9.
           05  FILLER          PIC XX      VALUE SPACES.
       01  TOTALS.
           05  FILLER          PIC X(10)   VALUES SPACES.
           05  FILLER          PIC X(7)    VALUE "TOTALS:".
           05  FILLER          PIC X(2)    VALUE SPACES.           
           05  D-SALES-TOT     PIC $$$,$$$,$$9.99.
           05  FILLER          PIC X(9)    VALUE SPACES.
           05  D-TAX-TOT       PIC $$,$$$,$$9.99.
           05  FILLER          PIC X(10)   VALUE SPACES.
           05  D-TRANS-TOT     PIC $$$$,$$$,$$9.99.

      *
       PROCEDURE DIVISION.
       000-MAIN.
           PERFORM 100-SORT
           PERFORM 150-OPEN-FILES
           PERFORM 600-WRITE-HEADINGS         
           PERFORM 200-READ UNTIL EOF-SWITCH = 'Y'
           PERFORM 500-TOTALS
           PERFORM 700-CLOSE-FILES
           
           DISPLAY "REPORT GENERATED!"
           
           STOP RUN.
       
      * SORTS THE INPUT FILE AND OVERWRITES THE INPUT FILE WITH THE
      * SORTED FILE.   
       100-SORT.
           SORT SORT-FILE
               ON ASCENDING KEY SRT-CUST-NO
                                SRT-ITEM-NO
                   USING INPUT-FILE
                   GIVING INPUT-FILE.
                   
      * OPENS THE OUTPUT AND INPUT FILES.              
       150-OPEN-FILES.
           OPEN INPUT INPUT-FILE
           OPEN OUTPUT OUTPUT-FILE.
     
      * READS THE INPUT FILE UNTIL THE END OF FILE, AFTER EACH RECORD
      * IS READ, THE CALCULATIONS ARE DONE AND THE CUSTOMER RECORD IS
      * PRINTED.      
       200-READ.
           READ INPUT-FILE
               AT END
                   MOVE 'Y' TO EOF-SWITCH
               NOT AT END
                   PERFORM 300-CALCULATIONS
                   PERFORM 400-WRITE-CUSTOMER-REC
           END-READ.
      
      * CALCULATES THE SALES AMOUNT, SALES TAX, AND TRANSACTION AMOUNT
      * OF A SINGLE CUSTOMER RECORD. ADDS THE SALES AMOUNT, SALES TAX
      * AND TRANSACTION AMOUNT TO THE RUNNING TOTALS.    
       300-CALCULATIONS.
           COMPUTE SALES-AMT ROUNDED = UNIT-PRICE * QUANTITY
           COMPUTE SALES-TAX ROUNDED = SALES-AMT * TAX-AMT
           COMPUTE TRANS-AMT = SALES-AMT + SALES-TAX
           
           ADD SALES-AMT TO SALES-TOT
           ADD SALES-TAX TO TAX-TOT
           ADD TRANS-AMT TO TRANS-TOT.
      
      * PRINTS A SINGLE CUSTOMER RECORD, IF THE LINE COUNT REACHES THE
      * MAX (55 LINES) A PAGE BREAK IS INSERTED AND THE HEADINGS ARE
      * PRINTED BEFORE PRINTING THE CUSTOMER RECORD.     
       400-WRITE-CUSTOMER-REC.
           PERFORM 450-MOVE-CUST-INFO
           PERFORM 475-DEPARTMENT-NAME
           
           ADD THREE-LN-CT TO LN-COUNT
           IF LN-COUNT > MAX-LINE
               MOVE 1 TO LN-COUNT
               ADD 1 TO PG-COUNT
               PERFORM 600-WRITE-HEADINGS
           END-IF			   
           WRITE OUTPUT-REC FROM CUST-REC
               AFTER ADVANCING 1 LINE
           WRITE OUTPUT-REC FROM SALES-SUMMARY.
      
      * MOVES THE CUSTOMER INFORMATION FROM THE INPUT VARIABLES TO THE
      * EDITED REPORT VARIABLES TO BE PRINTED IN A FORMAT  
       450-MOVE-CUST-INFO.
           MOVE CUST-NO    TO D-CUST-NO
		   MOVE CUST-NAME  TO D-CUST-NM
		   MOVE ITEM-CODE  TO D-ITEM-CO
		   MOVE ITEM-DESC  TO D-DESC
		   MOVE UNIT-PRICE TO D-PRICE
		   MOVE QUANTITY   TO D-QUANTITY
           MOVE SALES-AMT  TO D-SALES-AMT
           MOVE SALES-TAX  TO D-SALES-TAX
           MOVE TRANS-AMT  TO D-TRANS-AMT.
     
      * DETERMINES WHICH DEPARTMENT NAME SHOULD BE PRINTED ON THE REPORT
      * BASED ON THE DEPARTMENT NUMBER FROM THE INPUT FILE.                
       475-DEPARTMENT-NAME.
           EVALUATE TRUE
               WHEN HOME
                   MOVE "HOME" TO D-DEPT-CO
               WHEN ELECTRONIC
                   MOVE "ELECTRONIC" TO D-DEPT-CO
               WHEN GROCERY
                   MOVE "GROCERY" TO D-DEPT-CO
               WHEN AUTOMOBILE
                   MOVE "AUTO" TO D-DEPT-CO
           END-EVALUATE.  
      
      * MOVES THE TOTAL VARIABLES TO EDITED VARIABLES TO BE PRINTED,
      * THEN PRINTS THE TOTALS OF A SINGLE CUSTOMER RECORD. IF THE MAX
      * LINE COUNT (55 LINES) IS REACHED, A PAGE BREAK IS INSERTED AND
      * THE HEADINGS ARE PRINTED BEFORE THE TOTALS ARE PRINTED.
       500-TOTALS.
           MOVE SALES-TOT TO D-SALES-TOT
           MOVE TAX-TOT TO D-TAX-TOT
           MOVE TRANS-TOT TO D-TRANS-TOT
           ADD THREE-LN-CT TO LN-COUNT
           IF LN-COUNT > MAX-LINE
               MOVE 1 TO LN-COUNT
               ADD 1 TO PG-COUNT
               PERFORM 600-WRITE-HEADINGS
           END-IF
           
           WRITE OUTPUT-REC FROM TOTALS
               AFTER ADVANCING 1 LINE.
	
      * WRITES THE HEADINGS ON THE TOP OF THE PAGE.	   
       600-WRITE-HEADINGS.
           MOVE FUNCTION CURRENT-DATE TO WS-DATE
           MOVE WS-YEAR  TO HD-YEAR
           MOVE WS-MM    TO HD-MM
           MOVE WS-DAY   TO HD-DD
           MOVE WS-HR    TO HD-HOUR
           MOVE WS-MIN   TO HD-MIN
           MOVE PG-COUNT TO PAGE-NO.

           IF PAGE-NO > 1
               WRITE OUTPUT-REC FROM HD-TITLE AFTER ADVANCING PAGE
           ELSE
               WRITE OUTPUT-REC FROM HD-TITLE
           END-IF
           WRITE OUTPUT-REC FROM HD-SUBTITLE
           WRITE OUTPUT-REC FROM HD-COLUMN1
               AFTER ADVANCING 1 LINE
           WRITE OUTPUT-REC FROM HD-COLUMN2
		   ADD FIVE-LN-CT TO LN-COUNT.
      
      * CLOSES THE OUTPUT AND INPUT FILES. 
       700-CLOSE-FILES.
           CLOSE INPUT-FILE
           CLOSE OUTPUT-FILE.
           

           