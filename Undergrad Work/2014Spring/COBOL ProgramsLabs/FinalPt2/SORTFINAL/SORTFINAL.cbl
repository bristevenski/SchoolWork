       IDENTIFICATION DIVISION.  
       PROGRAM-ID. Fianl.
       AUTHOR. Brianna Muleski 
       DATE-WRITTEN. 5/12/14
      ******************************************************************
      * Purpose:	  
      *    sorts the output file.
      *          
      * Input:
      *     UNSORTED.DAT
      * Output:
      *     SORTEDFINAL.DAT
      ******************************************************************	   
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
           SELECT IN-FILE ASSIGN TO "UNSORTED.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT OUT-FILE ASSIGN TO "SORTEDFINAL.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT SORT-FILE ASSIGN TO "SORT.DAT".
           
       DATA DIVISION.
       FILE SECTION.
       FD  IN-FILE.
       01  IN-REC.
           05  IN-CUST-NO     PIC X(4).
           05  FILLER          PIC X.
           05  IN-STORE-NO    PIC 9.
           05  FILLER          PIC X(17).
           
       FD  OUT-FILE.
       01  OUT-REC.
           05  OUT-CUST-NO     PIC X(4).
           05  FILLER          PIC X.
           05  OUT-STORE-NO    PIC 9.
           05  FILLER          PIC X(17).
           
       SD  SORT-FILE.
       01  SORT-REC.
           05  SRT-CUST-NO     PIC X(4).
           05  FILLER          PIC X.
           05  SRT-STORE-NO    PIC 9.
           05  FILLER          PIC X(17).
               
                   
       WORKING-STORAGE SECTION.
                
       PROCEDURE DIVISION.
       000-MAIN.
           OPEN INPUT IN-FILE
           OPEN OUTPUT OUT-FILE
           PERFORM 100-SORT
           DISPLAY 'FILE SORTED!'
           CLOSE IN-FILE OUT-FILE.
           STOP RUN.
           
       100-SORT.
           SORT SORT-FILE
               ON ASCENDING KEY SRT-STORE-NO
                                SRT-CUST-NO
                   USING IN-FILE
                   GIVING OUT-FILE
           DISPLAY SPACE
           DISPLAY 'FILE SORTED!'.

           