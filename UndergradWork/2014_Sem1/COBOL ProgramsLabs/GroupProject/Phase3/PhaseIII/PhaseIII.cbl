       IDENTIFICATION DIVISION.
       PROGRAM-ID. PhaseIII
       AUTHOR. Brianna Muleski
               Andrew Iverson
       DATE-WRITTEN. 5/7/14
      ******************************************************************
      * Purpose:
      *    Updating a master file that stores the total amount of
      *    account receivable for each customer
      *
      * Input:
      *    MASTER.DAT
      *        Old master file
      *    PHASE2.DAT
      *        Transaction file
      *
      * Output:
      *    NEWMASTER.DAT
      *        New master file
      *    ERRORLOG.DAT
      *        Error log file
      *
      ******************************************************************
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
           SELECT OLDMSTR-FILE ASSIGN TO "MASTER.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT TRANS-FILE ASSIGN TO "PHASE2.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT NEWMSTR-FILE ASSIGN TO "NEWMASTER.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT ERROR-FILE ASSIGN TO "ERRORLOG.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT SORT-TRANS-FILE ASSIGN TO "SORTEDTRANS.DAT".
      *
       DATA DIVISION.
       SD  SORT-TRANS-FILE.
       01  SORTED-REC.
           05  SORT-T-CUST-NO       PIC X(5).
           05  SORT-T-CUST-NM       PIC X(20).
           05  SORT-T-ITEM-NO       PIC X(4).
           05  SORT-T-ITEM-DES      PIC X(15).
           05  SORT-T-UNIT-PR       PIC 9(4)V99.
           05  SORT-T-QNT           PIC 999.
       FD  OLDMSTR-FILE.
       01  OLD-REC.
           05  O-CUST-NO       PIC X(5).
           05  O-CUST-NM       PIC X(20).
           05  O-AMT           PIC 9(7)V99.
       
       FD  TRANS-FILE.
       01  TRANS-REC.
           05  T-CUST-NO       PIC X(5).
           05  T-CUST-NM       PIC X(20).
           05  T-ITEM-NO       PIC X(4).
           05  T-ITEM-DES      PIC X(15).
           05  T-UNIT-PR       PIC 9(4)V99.
           05  T-QNT           PIC 999.
       
       FD  NEWMSTR-FILE.
       01  NEW-REC.
           05  N-CUST-NO       PIC X(5).
           05  N-CUST-NM       PIC X(20).
           05  N-AMT           PIC 9(7)V99. 
           
       FD  ERROR-FILE.
       01  ERR-REC.
           05  E-CUST-NO       PIC X(5).
           05  E-CUST-NM       PIC X(20).
           05  E-ITEM-NO       PIC X(4).
           05  E-ITEM-DES      PIC X(15).
           05  E-UNIT-PR       PIC 9(4)V99.
           05  E-QNT           PIC 999.              
      *
       WORKING-STORAGE SECTION.
       01  WORKING-ITEMS.
           05  SALES-AMT       PIC 9(7)V99.
           05  SALES-TAX       PIC 9(6)V99.
           05  TRANS-AMT       PIC 9(8)V99.
           05  TRANS-TOT       PIC 9(9)V99.
           05  TAX             PIC V999        VALUE .055.
      *
       PROCEDURE DIVISION.
      * Runs the program and outputs a file generated message.
       000-MAIN.
           PERFORM 50-SORT
           PERFORM 100-OPEN-FILES           
           PERFORM 700-READ-OLD-MASTER
           PERFORM 800-READ-TRANS
           PERFORM 200-UPDATE-MASTER
               UNTIL O-CUST-NO = HIGH-VALUES AND
                     T-CUST-NO = HIGH-VALUES
           PERFORM 600-CLOSE-FILES
           DISPLAY "MASTER FILE UPDATED!!"           
           STOP RUN.
           
      * Sorts the transaction file based on the customer number.
       50-SORT.
           SORT SORT-TRANS-FILE
               ON ASCENDING KEY SORT-T-CUST-NO
               USING TRANS-FILE
               GIVING TRANS-FILE.
               
      * Opens the input and output files
       100-OPEN-FILES.
           OPEN INPUT  OLDMSTR-FILE
                       TRANS-FILE
           OPEN OUTPUT NEWMSTR-FILE
                       ERROR-FILE.
                       
      * Evauluates what is done with the transaction record. If the 
      * transaction record equals the corresponding old master record
      * then the update it applied. If the transaction record is a
      * customer that is lower than the corresponding old master record
      * then an error log is created. If the transaction record is a
      * customer that is greater than the corresponding old master
      * record then the old master is copied.
       200-UPDATE-MASTER.
           EVALUATE TRUE
               WHEN T-CUST-NO = O-CUST-NO
                   ADD O-AMT TO N-AMT
                   PERFORM 300-APPLY-UPDATE                   
               WHEN T-CUST-NO < O-CUST-NO
                   PERFORM 400-ERROR-LOG
               WHEN OTHER
                   PERFORM 500-COPY-OLD-MASTER
           END-EVALUATE.
           
      * Applies the update to the new master file.
       300-APPLY-UPDATE.
           MOVE O-CUST-NO TO N-CUST-NO
           MOVE O-CUST-NM TO N-CUST-NM
           PERFORM 350-COMPUTATIONS
           PERFORM 325-CHECK-REC.    
           
      * Checks the transaction file for another transaction record of
      * the same customer. If it is detected, then another update is
      * applied, if not then the new master record is written and the
      * old master file is read.
       325-CHECK-REC.       
           PERFORM 800-READ-TRANS
           IF O-CUST-NO IS EQUAL T-CUST-NO
               IF O-CUST-NM IS EQUAL T-CUST-NM
                   PERFORM 300-APPLY-UPDATE
               ELSE
                   MOVE TRANS-REC TO ERR-REC
                   WRITE ERR-REC
                       BEFORE ADVANCING 1 LINE
               END-IF
           ELSE               
               WRITE NEW-REC
                   BEFORE ADVANCING 1 LINE
               PERFORM 700-READ-OLD-MASTER
           END-IF. 
           
      * Computes the new amount for the new master file and updates the
      * new amount.
       350-COMPUTATIONS.
           COMPUTE SALES-AMT ROUNDED = T-UNIT-PR * T-QNT
           COMPUTE SALES-TAX ROUNDED = SALES-AMT * TAX 
           COMPUTE TRANS-AMT = SALES-AMT + SALES-TAX
           ADD TRANS-AMT TO N-AMT.
           
      * Writes the transaction record to the error log, then reads the 
      * next transaction record.
       400-ERROR-LOG.
           MOVE TRANS-REC TO ERR-REC
           WRITE ERR-REC
               BEFORE ADVANCING 1 LINE
           PERFORM 800-READ-TRANS.
           
      * Copies the old master record to the new master file.
       500-COPY-OLD-MASTER.
           MOVE OLD-REC TO NEW-REC
           WRITE NEW-REC
               BEFORE ADVANCING 1 LINE
           PERFORM 700-READ-OLD-MASTER.
           
      * Closes the input and output files.
       600-CLOSE-FILES.
           CLOSE OLDMSTR-FILE
                 TRANS-FILE
                 NEWMSTR-FILE
                 ERROR-FILE. 
                 
      * Reads the next record from the old master file. When at the end
      * high-values is moved to the customer number to signal the end 
      * of the file.
       700-READ-OLD-MASTER.
           MOVE ZEROS TO N-AMT
           READ OLDMSTR-FILE
               AT END
                   MOVE HIGH-VALUES TO O-CUST-NO.
                   
      * Reads the next record from the transaction file. When at the
      * end high-values is moved to the customer number to signal the 
      * end of the file.
       800-READ-TRANS.
           READ TRANS-FILE
               AT END
                   MOVE HIGH-VALUES TO T-CUST-NO.