       IDENTIFICATION DIVISION.
      * DO_1: Complete the following information. 
       PROGRAM-ID. Lab02
       AUTHOR. Brianna Muleski
       DATE-WRITTEN. 2/5/2014.
      ******************************************************************
      * Purpose:	  
      *     This program computes the sales amount of the items ordered
      *     by the customers in a pizza restaurant.      
      * Input:
      *     1. pizza flavor. (alphanumeric)
      *     2. quantity ordered. (numeric)
      *     3. unit price.  (numeric)
      * Output:
      *     Display a summary of the trasaction, including the flavor
      *     chosen, unit price, sales amount, sales tax, and sales 
      *     total.
      ******************************************************************
       ENVIRONMENT DIVISION.
       CONFIGURATION SECTION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
      * 
       DATA DIVISION.
       FILE SECTION.
      * 
       WORKING-STORAGE SECTION.
       01  INPUT-ITEMS.
      * DO_2: Define 05 level items for input data. 
           05  WS-FLAVOR      PIC X(10).
           05  WS-QUANTITY    PIC 9.
           05  WS-UNIT-PRICE  PIC 99V99.
       01  COMPUTATION-ITEMS.
           05  WS-AMOUNT      PIC 999V99.    
           05  WS-TAX-RATE    PIC 9V999    VALUE .065.
           05  WS-SALES-TAX   PIC 99V99.
       01  DISPLAY-ITEMS.    
           05  DS-UNIT-PRICE  PIC $Z9.99.     
           05  DS-AMOUNT      PIC $ZZ9.99.
      * DO_3: Define 05 level display items for sales tax and total  
           05  DS-SALES-TAX   PIC $Z9.99.
           05  DS-SALES-TOTAL PIC $ZZ9.99.
      *  
       LINKAGE SECTION.
      * 
       PROCEDURE DIVISION.
       000-MAIN. 
           PERFORM 100-INPUT-RTN.
           PERFORM 200-COMPUTE-SALES-AMOUNT.
           PERFORM 300-DISPLAY-TRANSACTION.
           STOP RUN.   
       100-INPUT-RTN.  
           DISPLAY 'ENTER THE FLAVOR'  
           ACCEPT WS-FLAVOR
      * DO_4: Prompt and read the other 2 items.     
           DISPLAY 'ENTER QUANTITY'
           ACCEPT WS-QUANTITY
           DISPLAY 'ENTER UNIT PRICE'
           ACCEPT WS-UNIT-PRICE.
       
       200-COMPUTE-SALES-AMOUNT.
           MOVE WS-UNIT-PRICE TO DS-UNIT-PRICE      
           COMPUTE WS-AMOUNT = WS-QUANTITY * WS-UNIT-PRICE  
           MOVE WS-AMOUNT TO DS-AMOUNT      
      * DO_5: Compute sales tax and sales total     
           COMPUTE WS-SALES-TAX = WS-AMOUNT * WS-TAX-RATE
           MOVE WS-SALES-TAX TO DS-SALES-TAX
           COMPUTE DS-SALES-TOTAL = WS-AMOUNT + WS-SALES-TAX.
     
       300-DISPLAY-TRANSACTION.    
           DISPLAY SPACE
           DISPLAY '-----------------------'
           DISPLAY '  PIZZA SALES SUMMARY'
           DISPLAY '-----------------------'
           DISPLAY 'FLAVOR CHOSEN:  ' WS-FLAVOR
      *DO_6: Display unit price, sales amount, and sales tax     
           DISPLAY 'UNIT PRICE:     ' DS-UNIT-PRICE
           DISPLAY 'SALES AMOUNT:   ' DS-AMOUNT
           DISPLAY 'SALES TAX:      ' DS-SALES-TAX
           DISPLAY "-----------------------"          
           DISPLAY 'SALES TOTAL:   ' DS-SALES-TOTAL
           DISPLAY SPACE.
           