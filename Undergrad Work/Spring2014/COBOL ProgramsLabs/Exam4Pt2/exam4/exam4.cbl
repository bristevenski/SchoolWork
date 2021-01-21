       IDENTIFICATION DIVISION.
       PROGRAM-ID. Exam4.
      ******************************************************************
      * Type your full name below. -1 point if it is not done.
      ******************************************************************  
       AUTHOR. Brianna Muleski
       DATE-WRITTEN. 5/5/14
      ******************************************************************
      * Purpose:	  
      *    This exam tests your knowledge on updating a sequential file. 
      *     
      * Input:  1. a sorted old master file
      *         2. an unsorted transaction file
      *      
      * Output: 
      *         1. a new master file 
      *         2. a error log file recording the transactions that
      *            couldn't find a match in the old master file.	  
      ******************************************************************	   
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
      ******************************************************************
      * Question 1: SELECT STATEMENTS for all files.
      * (2 points)
      ******************************************************************
       SELECT OLD-MSTR ASSIGN TO "SALESOLD.DAT"
           ORGANIZATION IS LINE SEQUENTIAL.
       SELECT TRANS-FILE ASSIGN TO "SALESTRN.DAT"
           ORGANIZATION IS LINE SEQUENTIAL.
       SELECT NEW-MSTR ASSIGN TO "NEWMASTER.DAT"
           ORGANIZATION IS LINE SEQUENTIAL.
       SELECT ERROR-LOG ASSIGN TO "ERRORLOG.DAT"
           ORGANIZATION IS LINE SEQUENTIAL.

	  
       DATA DIVISION.
       FILE SECTION.
      ******************************************************************
      * Question 2: SD/FD entries.
      * (3 points)
      ******************************************************************
       FD  OLD-MSTR.
       01  OLD-REC.
           05  O-SALE-NO   PIC X(5).
           05  O-SALE-AMT  PIC 9(4)V99.
           05  O-COMM      PIC 9(4)V99.
           
       FD  TRANS-FILE.
       01  TRANS-REC.
           05  T-SALE-NO   PIC X(5).
           05  T-SALE-AMT  PIC 9(4)V99.
           05  T-COMM      PIC 9(4)V99.

       FD  NEW-MSTR.
       01  NEW-REC.
           05  N-SALE-NO   PIC X(5).
           05  N-SALE-AMT  PIC 9(4)V99.
           05  N-COMM      PIC 9(4)V99.
           
       FD  ERROR-LOG.
       01  ERROR-REC.
           05  E-SALE-NO   PIC X(5).
           05  E-SALE-AMT  PIC 9(4)V99.
           05  E-COMM      PIC 9(4)V99.
	  
       WORKING-STORAGE SECTION.     
       PROCEDURE DIVISION.
      ******************************************************************
      * Question 3: Complete the main paragraph.
      * (3 points)
      ******************************************************************	 
       000-MAIN.
           OPEN INPUT OLD-MSTR TRANS-FILE                               
           OPEN OUTPUT NEW-MSTR ERROR-LOG
           PERFORM 700-READ-OMASTER
           PERFORM 800-READ-TRANS
           PERFORM 100-UPDATE-MASTER UNTIL 
               O-SALE-NO = HIGH-VALUES AND
               T-SALE-NO = HIGH-VALUES     
           CLOSE OLD-MSTR TRANS-FILE NEW-MSTR ERROR-LOG
           DISPLAY 'MASTER FILE UPDATED!!'
           STOP RUN. 
      ******************************************************************
      * Question 4: Complete the main paragraph for the updating process
      * (2 points)
      ******************************************************************			   
       100-UPDATE-MASTER.
           EVALUATE TRUE
               WHEN T-SALE-NO = O-SALE-NO  PERFORM 150-APPLY-UPDATE
               WHEN T-SALE-NO < O-SALE-NO  PERFORM 170-ERROR-LOG
               WHEN OTHER                  PERFORM 190-WRITE-OMASTER
           END-EVALUATE.            
		   
      ******************************************************************
      * Question 5: Incorporate the amounts from the old master and the
      *             transaction file.
      * (3 points)
      ******************************************************************	   
       150-APPLY-UPDATE.
           COMPUTE N-SALE-AMT = O-SALE-AMT + T-SALE-AMT
           COMPUTE N-COMM     = O-COMM     + T-COMM
           
           WRITE NEW-REC
           PERFORM 700-READ-OMASTER
           PERFORM 800-READ-TRANS.
           		  
       170-ERROR-LOG.
           MOVE TRANS-REC TO ERROR-REC           
           WRITE ERROR-REC
           PERFORM 800-READ-TRANS.
       190-WRITE-OMASTER.
           MOVE OLD-REC TO NEW-REC           
           WRITE NEW-REC
           PERFORM 700-READ-OMASTER.
      ******************************************************************
      * Question 6: Complete the READ command.
      * (2 points)
      ******************************************************************			   
       700-READ-OMASTER.
           READ OLD-MSTR
               AT END
                   MOVE HIGH-VALUES TO O-SALE-NO.	   
       800-READ-TRANS.
           READ TRANS-FILE
               AT END
                   MOVE HIGH-VALUES TO T-SALE-NO.
           
       