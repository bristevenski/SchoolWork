       IDENTIFICATION DIVISION.  
       PROGRAM-ID. Fianl.
       AUTHOR. Brianna Muleski 
       DATE-WRITTEN. 5/12/14
      ******************************************************************
      * Purpose:	  
      *     This program determines the discount percentage and
      *        computes the net sales amount for each transaction, and
      *        the total sales amount for each store, then sorts the 
      *        output file.
      *          
      * Input:
      *     FINAL.DAT
      * Output:
      *     UNSORTED.DAT
      ******************************************************************	   
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
           SELECT IN-FILE ASSIGN TO "FINAL.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT OUT-FILE ASSIGN TO "UNSORTED.DAT".
           
       DATA DIVISION.
       FILE SECTION.
       FD  IN-FILE.
       01  IN-REC.
           05  IN-CUST-NO      PIC X(4).
           05  IN-STORE-NO     PIC 9.
               88  PLATTEVILLE             VALUE 1.
               88  DUBUQUE                 VALUE 2.
               88  MADISON                 VALUE 3.
               88  MILWAUKEE               VALUE 4.
           05  IN-SALES-AMT    PIC 999V99.
           
       FD  OUT-FILE.
       01  OUT-REC.
           05  OUT-CUST-NO     PIC X(4).
           05  FILLER          PIC X.
           05  OUT-STORE-NO    PIC 9.
           05  FILLER          PIC X.
           05  OUT-SALES-AMT   PIC 999V99.
           05  FILLER          PIC X.
           05  DISCOUNT        PIC V999.
           05  FILLER          PIC X.
           05  NET-SALES       PIC 9(4)V99.
               
                   
       WORKING-STORAGE SECTION.
       01  DISCOUNT-TABLE VALUE '1020203030154010'.
           05  DISCOUNT-REC OCCURS 4 TIMES.
               10  STORE-NO    PIC 9.
               10  TBL-DISC    PIC V999.
               
       01  WORKING-ITEMS.
           05  P-TOT-SALES     PIC 9(4)V99.
           05  D-TOT-SALES     PIC 9(4)V99.
           05  MAD-TOT-SALES   PIC 9(4)V99.
           05  MIL-TOT-SALES   PIC 9(4)V99.
           05  ED-TOTAL-SALES  PIC Z,ZZ9.99.
           05  EOF-SWITCH      PIC X           VALUE 'N'.
           05  DISC-AMT        PIC V999.
                
       PROCEDURE DIVISION.
       000-MAIN.
           PERFORM 100-OPEN-FILES          
           PERFORM 200-READ-INPUT UNTIL EOF-SWITCH = 'Y'
           PERFORM 350-DISPLAY-TOTALS
           PERFORM 600-CLOSE-FILES
           
           DISPLAY SPACE
           DISPLAY 'DONE!!'
           
           STOP RUN.
       
       100-OPEN-FILES.
           OPEN INPUT IN-FILE
           OPEN OUTPUT OUT-FILE.
       
       200-READ-INPUT.
           READ IN-FILE
               AT END
                   MOVE 'Y' TO EOF-SWITCH
               NOT AT END
                   PERFORM 250-COMPUTATIONS
                   PERFORM 400-WRITE-OUTPUT
           END-READ.
           
       250-COMPUTATIONS.
           MOVE IN-CUST-NO TO OUT-CUST-NO
           MOVE IN-STORE-NO TO OUT-STORE-NO
           MOVE IN-SALES-AMT TO OUT-SALES-AMT
           
           PERFORM 275-FIND-DISCOUNT
           MULTIPLY IN-SALES-AMT BY DISC-AMT GIVING NET-SALES
           SUBTRACT IN-SALES-AMT FROM NET-SALES
           PERFORM 300-ADD-TOTALS.
           
       275-FIND-DISCOUNT.
           EVALUATE TRUE
               WHEN PLATTEVILLE
                   MOVE TBL-DISC(1) TO DISC-AMT
               WHEN DUBUQUE
                   MOVE TBL-DISC(2) TO DISC-AMT
               WHEN MADISON
                   MOVE TBL-DISC(3) TO DISC-AMT
               WHEN MILWAUKEE
                   MOVE TBL-DISC(4) TO DISC-AMT
               WHEN OTHER
                   MOVE ZEROS TO DISC-AMT
           END-EVALUATE
           
           MOVE DISC-AMT TO DISCOUNT.
       
       300-ADD-TOTALS.
           EVALUATE TRUE
               WHEN PLATTEVILLE
                   ADD NET-SALES TO P-TOT-SALES
               WHEN DUBUQUE
                   ADD NET-SALES TO D-TOT-SALES
               WHEN MADISON
                   ADD NET-SALES TO MAD-TOT-SALES
               WHEN MILWAUKEE
                   ADD NET-SALES TO MIL-TOT-SALES
           END-EVALUATE.
               
       350-DISPLAY-TOTALS.
           MOVE P-TOT-SALES TO ED-TOTAL-SALES
           DISPLAY 'PLATTEVILLE TOTAL  ' ED-TOTAL-SALES  
           MOVE D-TOT-SALES TO ED-TOTAL-SALES
           DISPLAY 'DUBUQUE TOTAL      ' ED-TOTAL-SALES 
           MOVE MAD-TOT-SALES TO ED-TOTAL-SALES
           DISPLAY 'MADISON TOTAL      ' ED-TOTAL-SALES 
           MOVE MIL-TOT-SALES TO ED-TOTAL-SALES
           DISPLAY 'MILWAUKEE TOTAL    ' ED-TOTAL-SALES.  
                   
       400-WRITE-OUTPUT.
           WRITE OUT-REC 
               BEFORE ADVANCING 1 LINE.
           
       600-CLOSE-FILES.
           CLOSE IN-FILE OUT-FILE.
           
           
                   
