       IDENTIFICATION DIVISION.
      * DO_1: Complete the following information.  
       PROGRAM-ID. LAB08.
       AUTHOR. Brianna Muleski 
       DATE-WRITTEN. 4/23/14
      ******************************************************************
      * Purpose:	  
      *     This program updates the old master file and create a new 
      *     master file
      *          
      * Input:
      *     OLDMASTER.dat -- old master payroll
      *     TRANS.dat     -- weekly payroll
      * Output:
      *     NEWMASTER.dat -- new master payroll
      *     ERRLOG.dat    -- records of weekly payroll that could not 
      *                      find a match in the old master payroll
      ******************************************************************	   
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
           SELECT OLDMASTER-FILE ASSIGN TO "OLDMASTER.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT TRANS-FILE ASSIGN TO "TRANS.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT NEWMASTER-FILE ASSIGN TO "NEWMASTER.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT ERRLOG-FILE ASSIGN TO "ERRLOG.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
       DATA DIVISION.
      ******************************************************************	   
      * DO_2: Complete the following file descriptions.
      ****************************************************************** 
       FILE SECTION.
       FD  OLDMASTER-FILE.
       01  OLD-REC.
           05  O-EMP-ID    PIC X(4).
           05  O-GRS-PAY   PIC 9(6)V99.
           05  O-INC-TAX   PIC 9(6)V99.
           05  O-NET-PAY   PIC 9(6)V99. 
            
       FD  TRANS-FILE.
       01  WEEKLY-REC.
           05  W-EMP-ID    PIC X(4).
           05  W-GRS-PAY   PIC 9(5)V99.
           05  W-INC-TAX   PIC 9(5)V99.
           05  W-NET-PAY   PIC 9(5)V99. 
            
       FD  NEWMASTER-FILE.
       01  NEW-REC.
           05  N-EMP-ID    PIC X(4).
           05  N-GRS-PAY   PIC 9(6)V99.
           05  N-INC-TAX   PIC 9(6)V99.
           05  N-NET-PAY   PIC 9(6)V99.         
            
       FD  ERRLOG-FILE.
       01  ERROR-REC.
           05  E-EMP-ID    PIC X(4).
           05  E-GRS-PAY   PIC 9(6)V99.
           05  E-INC-TAX   PIC 9(6)V99.
           05  E-NET-PAY   PIC 9(6)V99.
                   
       WORKING-STORAGE SECTION.     
       PROCEDURE DIVISION.
       000-MAIN.
           PERFORM 500-OPEN-FILES
           PERFORM 700-READ-OMASTER
           PERFORM 800-READ-TRANS
           PERFORM 100-UPDATE-MASTER UNTIL
               O-EMP-ID = HIGH-VALUES AND
               W-EMP-ID = HIGH-VALUES
           PERFORM 600-CLOSE-FILES
           DISPLAY 'MASTER FILE UPDATED!!'
           STOP RUN.
      ******************************************************************	   
      * DO_3: Complete the PERFORM statements
      ******************************************************************	   
       100-UPDATE-MASTER.
           EVALUATE TRUE
               WHEN W-EMP-ID = O-EMP-ID  PERFORM 150-APPLY-UPDATE
               WHEN W-EMP-ID < O-EMP-ID  PERFORM 170-ERROR-LOG
               WHEN OTHER                PERFORM 190-WRITE-OMASTER
           END-EVALUATE.
      ******************************************************************	   
      * DO_4: (1) ADD associated amounts in the transaction file to the 
      *       amounts in the old master file, and write a new record to
      *       the new master file. 
      *       (2) READ the next record in the transaction file and  the
      *           old master file
      ****************************************************************** 	   
       150-APPLY-UPDATE.
           MOVE O-EMP-ID TO N-EMP-ID
           COMPUTE N-GRS-PAY = O-GRS-PAY + W-GRS-PAY
           COMPUTE N-INC-TAX = O-INC-TAX + W-INC-TAX
           COMPUTE N-NET-PAY = O-NET-PAY + W-NET-PAY
           WRITE NEW-REC 
           PERFORM 800-READ-TRANS
           PERFORM 700-READ-OMASTER.
      ******************************************************************	   
      * DO_5: Write the transaction record to the error log file, and
      *       READ the next record from the transaction file
      ******************************************************************	   
       170-ERROR-LOG.
           MOVE WEEKLY-REC TO ERROR-REC          
           WRITE ERROR-REC 
           PERFORM 800-READ-TRANS.
      ******************************************************************	   
      * DO_6: Write the record as it is from old master file to the 
      *       new master file, and READ the next record from the old 
      *       master file
      ******************************************************************	   
       190-WRITE-OMASTER.
           MOVE OLD-REC TO NEW-REC           
           WRITE NEW-REC 
           PERFORM 700-READ-OMASTER.
       500-OPEN-FILES.
           OPEN INPUT OLDMASTER-FILE TRANS-FILE
           OPEN OUTPUT NEWMASTER-FILE ERRLOG-FILE.
       600-CLOSE-FILES.
           CLOSE OLDMASTER-FILE TRANS-FILE
                 NEWMASTER-FILE ERRLOG-FILE.
       700-READ-OMASTER.
           READ OLDMASTER-FILE AT END
               MOVE HIGH-VALUES TO O-EMP-ID.
       800-READ-TRANS.
           READ TRANS-FILE AT END
               MOVE HIGH-VALUES TO W-EMP-ID.
