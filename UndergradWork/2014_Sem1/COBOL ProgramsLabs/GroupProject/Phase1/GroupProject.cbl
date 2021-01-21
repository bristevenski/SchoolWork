       IDENTIFICATION DIVISION. 
       PROGRAM-ID. GroupProject
       AUTHOR. Brianna Muleski.
               Andrew Iverson.
       DATE-WRITTEN. 2/25/14.
      ******************************************************************
      * Purpose:
      *    This program accepts transaction records entered from the 
      *    keyboard and writes the transactions to an external 
      *    transaction file.                                           
      *          
      * Input:
      *    1. Customer number - Alphanumeric
      *    2. Customer name - Alphanumeric
      *    3. Item number - Alphanumeric
      *    4. Item code - Alphanumeric
      *    5. Item description - Alphanumeric
      *    6. Unit Price - Numeric
      *    7. Quantity - Numeric
      *
      * Output:
      *    TRANSACTION.RPT - A transaction file with the information 
      *    of the customers transaction in a formatted layout.
      *     
      * Date/time due: 3/7/14, 3PM
      * 
      ******************************************************************
       ENVIRONMENT DIVISION.
       CONFIGURATION SECTION.
       INPUT-OUTPUT SECTION.
      * AUTHOR: BRIANNA  
       FILE-CONTROL.
           SELECT OUT-TRANSACTION-FILE ASSIGN TO "TRANSACTION.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
       DATA DIVISION.
       FILE SECTION.
       FD  OUT-TRANSACTION-FILE.
       01  OUT-TRANS-REC                PIC X(53).
       WORKING-STORAGE SECTION.
       01  INPUT-ITEMS.
           05  CUST-NUM                PIC X(5).
           05  CUST-NAME               PIC X(20).
           05  ITEM-NUM.
               10  DEPT-CODE            PIC X.
                   88  HOME                         VALUE '1'.
                   88  ELECTRONIC                   VALUE '2'.
                   88  GROCERY                      VALUE '3'.
                   88  AUTOMOBILE                   VALUE '4'.
               10  ITEM-CODE            PIC X(3).
           05  ITEM-DESC                PIC X(15).
           05  UNIT-PRICE               PIC 9(4)V99.
           05  QUANTITY                 PIC 9(3).
       01  WORKING-ITMES.  
           05  VALID                    PIC X.
           05  CONSTANTS. 
               10  LOW-DEPT             PIC X       VALUE '1'.
               10  HIGH-DEPT            PIC X       VALUE '4'.
               10  LOW-CODE             PIC X(3)    VALUE '101'.
               10  HIGH-CODE            PIC X(3)    VALUE '899'.
       LINKAGE SECTION.
      * 
       PROCEDURE DIVISION.
      * AUTHOR: BRIANNA
       000-MAIN.
           OPEN OUTPUT OUT-TRANSACTION-FILE
           
           PERFORM 100-ACCEPT-NAME
           PERFORM UNTIL CUST-NAME = 'QUIT'
               PERFORM 150-ACCEPT-DATA
               PERFORM 200-PRINT-TRANS-REC
               PERFORM 100-ACCEPT-NAME
           END-PERFORM.
           
           DISPLAY SPACE
           DISPLAY '--END OF SESSION--'
           
           CLOSE OUT-TRANSACTION-FILE
           STOP RUN.
      * AUTHOR: BRIANNA
       100-ACCEPT-NAME.
           DISPLAY 'ENTER CUSTOMER NAME (ENTER QUIT TO END):'
           ACCEPT CUST-NAME
           MOVE 'N' TO VALID
           PERFORM UNTIL VALID = 'Y'
               IF CUST-NAME = SPACE
                   DISPLAY 'INVALID NAME.'
                   DISPLAY 'ENTER CUSTOMER NAME (ENTER QUIT TO END):'
                   ACCEPT CUST-NAME
               ELSE
                   MOVE 'Y' TO VALID
           END-PERFORM.
      * AUTHOR: ANDREW
       150-ACCEPT-DATA.
           PERFORM 151-ACCEPT-CUSTOMER-NUMBER THRU 156-ACCEPT-QUANTITY.
      * AUTHOR: ANDREW
       151-ACCEPT-CUSTOMER-NUMBER.
           DISPLAY 'ENTER CUSTOMER NUMBER:'
           ACCEPT CUST-NUM.
           MOVE 'N' TO VALID
           PERFORM UNTIL VALID = 'Y'
               IF CUST-NUM = SPACE
                   DISPLAY 'INVALID NUMBER.'
                   DISPLAY 'ENTER CUSTOMER NUMBER:'
                   ACCEPT CUST-NUM
               ELSE
                   MOVE 'Y' TO VALID
           END-PERFORM.
      * AUTHOR: BRIANNA
       152-ACCEPT-DEPT-CODE.
           DISPLAY 'ENTER DEPARTMENT CODE:'
           ACCEPT DEPT-CODE
           MOVE 'N' TO VALID
           PERFORM UNTIL VALID = 'Y'
               IF DEPT-CODE < LOW-DEPT OR > HIGH-DEPT
                   DISPLAY 'INVALID CODE.'
                   DISPLAY 'ENTER DEPARTMENT CODE:'
                   ACCEPT DEPT-CODE
               ELSE
                   MOVE 'Y' TO VALID
           END-PERFORM.
      * AUTHOR: BRIANNA
       153-ACCEPT-ITEM-CODE.          
           DISPLAY 'ENTER ITEM CODE:'
           ACCEPT ITEM-CODE
             MOVE 'N' TO VALID
           PERFORM UNTIL VALID = 'Y'
               IF ITEM-CODE < LOW-CODE OR > HIGH-CODE
                   DISPLAY 'INVALID CODE.'
                   DISPLAY 'ENTER ITEM CODE:'
                   ACCEPT ITEM-CODE
               ELSE
                   MOVE 'Y' TO VALID
           END-PERFORM.  
      * AUTHOR: BRIANNA
       154-ACCEPT-ITEM-DESCRIPTION.    
           DISPLAY 'ENTER ITEM DESCRIPTION:'
           ACCEPT ITEM-DESC
             MOVE 'N' TO VALID
           PERFORM UNTIL VALID = 'Y'
               IF ITEM-DESC = SPACE
                   DISPLAY 'INVALID DESCRIPTION.'
                   DISPLAY 'ENTER ITEM DESCRIPTION:'
                   ACCEPT ITEM-DESC
               ELSE
                   MOVE 'Y' TO VALID
           END-PERFORM.  
      * AUTHOR: ANDREW
       155-ACCEPT-UNIT-PRICE.    
           DISPLAY 'ENTER UNIT PRICE:'
           ACCEPT UNIT-PRICE
             MOVE 'N' TO VALID
           PERFORM UNTIL VALID = 'Y'
               IF UNIT-PRICE = ZERO
                   DISPLAY 'INVALID PRICE.'
                   DISPLAY 'ENTER UNIT PRICE:'
                   ACCEPT UNIT-PRICE
               ELSE
                   MOVE 'Y' TO VALID
           END-PERFORM.
      * AUTHOR: ANDREW
       156-ACCEPT-QUANTITY.    
           DISPLAY 'ENTER QUANTITY:'
           ACCEPT QUANTITY
             MOVE 'N' TO VALID
           PERFORM UNTIL VALID = 'Y'
               IF QUANTITY = ZERO
                   DISPLAY 'INVALID QUANTITY.'
                   DISPLAY 'ENTER QUANTITY:'
                   ACCEPT QUANTITY
               ELSE
                   MOVE 'Y' TO VALID
           END-PERFORM.              
      * AUTHOR: ANDREW
       200-PRINT-TRANS-REC.
		   MOVE INPUT-ITEMS TO OUT-TRANS-REC
		   WRITE OUT-TRANS-REC BEFORE ADVANCING 1 LINE.
		   