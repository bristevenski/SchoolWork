       IDENTIFICATION DIVISION.
       PROGRAM-ID. EXAM3.
      ******************************************************************
      * Type your full name below. -1 point if it is not done.
      ****************************************************************** 
       AUTHOR. Brianna Muleski
       DATE-WRITTEN. 4/16/14
      ******************************************************************
      * Purpose:	  
      *     This exam tests your knowledge on 
      *         1. Runtime table (execution-time table) 
      *         2. SORT, PERFORM VARYING, and SEARCH statements.
      *     
      * Input:  exam3.dat
      *      
      * Output: 
      *         1. display the total for Linda, and 
      *         2. A sorted file called sorted.dat     
      ******************************************************************	   
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
           SELECT INPUT-FILE ASSIGN TO "EXAM3.DAT"
                  ORGANIZATION IS LINE SEQUENTIAL.
           SELECT NEW-FILE ASSIGN TO "EXAM3NEW.DAT"
                  ORGANIZATION IS LINE SEQUENTIAL.
           SELECT SORTED-FILE ASSIGN TO "SORTED.DAT"
                  ORGANIZATION IS LINE SEQUENTIAL.
           SELECT SORT-TEMP-FILE ASSIGN TO "TEMP.DAT".
       DATA DIVISION.
       FILE SECTION. 
       SD  SORT-TEMP-FILE.
       01  SORT-REC.
           05  S-NAME       PIC X(8).
           05  S-COOKIES    PIC 9(6).
           05  S-TOTAL      PIC 9(4).        
       FD  INPUT-FILE.
       01  IN-REC.
           05  IN-NAME      PIC X(8).
           05  IN-MINTS     PIC 9(3).
           05  IN-SOMOAS    PIC 9(3).             
       FD  NEW-FILE.
       01  NEW-REC          PIC X(18).
       FD  SORTED-FILE.
       01  SORTED-REC       PIC X(18).	   
       WORKING-STORAGE SECTION. 
       01  WS-OUT-REC.
           05  OUT-NAME     PIC X(8).
           05  OUT-MINTS    PIC 9(3).
           05  OUT-SOMOAS   PIC 9(3). 
           05  OUT-TOTAL    PIC 9(4).
      ******************************************************************
      * Question 1: Define a runtime table for the table in exam3.dat.
      * (3 points)
      ******************************************************************	   
       01  COOKIE-TABLE.
           05 COOKIE-REC OCCURS 10 TIMES INDEXED BY INDX.
               10  WS-NAME  PIC X(8).
               10  WS-MINT  PIC 9(3).
               10  WS-SOMO  PIC 9(3).         
				  
	   01 LINDA-TOT         PIC ZZZ9.
	  
				  
       PROCEDURE DIVISION.
       000-MAIN.
           OPEN INPUT INPUT-FILE
           OPEN OUTPUT NEW-FILE
           PERFORM 100-LOAD-TABLE 
           PERFORM 200-SEARCH-LINDA
           PERFORM 300-CREATE-A-FILE-WITH-TOTAL
           CLOSE NEW-FILE
           PERFORM 400-SORT-WITH-TOTAL                    
           STOP RUN. 
      ******************************************************************
      * Question 2: Load the table in exam3.dat to the runtime table
      * (3 points)
      ******************************************************************		   
       100-LOAD-TABLE.
           PERFORM VARYING INDX FROM 1 BY 1 UNTIL INDX > 10
               READ INPUT-FILE
                   AT END
                       DISPLAY SPACE
                   NOT AT END
                       MOVE IN-NAME TO WS-NAME(INDX)
                       MOVE IN-MINTS TO WS-MINT(INDX)
                       MOVE IN-SOMOAS TO WS-SOMO(INDX)
           END-PERFORM.		   
      ******************************************************************
      * Question 3: SEARCH Linda and display the data on the screen 
      * (3 points)
      ******************************************************************	
       200-SEARCH-LINDA.
           SET INDX TO 1
           SEARCH COOKIE-REC
               AT END
                   DISPLAY "NOT FOUND!"
               WHEN "LINDA" = WS-NAME(INDX)
                   ADD WS-MINT(INDX) TO WS-SOMO(INDX) GIVING LINDA-TOT
                   DISPLAY "LINDA SOLD " LINDA-TOT " BOXES OF COOKIES."
           END-SEARCH.    

      ******************************************************************
      * Question 4: Create a new file with an addtional data item: total   
      * (3 points)
      ******************************************************************	  
       300-CREATE-A-FILE-WITH-TOTAL.
           PERFORM VARYING INDX FROM 1 BY 1 UNTIL INDX > 10
               MOVE WS-NAME(INDX) TO OUT-NAME
               MOVE WS-MINT(INDX) TO OUT-MINTS
               MOVE WS-SOMO(INDX) TO OUT-SOMOAS
               ADD WS-MINT(INDX) TO WS-SOMO(INDX) GIVING OUT-TOTAL
               WRITE NEW-REC FROM WS-OUT-REC
                   BEFORE ADVANCING 1 LINE
           END-PERFORM.
	   
	   
      ******************************************************************
      * Question 5: SORT the newly created file with the toal as primary 
      *             key in descending order, and the name as minor key 
      *             in ascending order.	  
      * (3 points)
      ******************************************************************      
       400-SORT-WITH-TOTAL.
           SORT SORT-TEMP-FILE
               ON DESCENDING KEY S-TOTAL
               ON ASCENDING KEY  S-NAME
                   USING  NEW-FILE
                   GIVING SORTED-FILE.
