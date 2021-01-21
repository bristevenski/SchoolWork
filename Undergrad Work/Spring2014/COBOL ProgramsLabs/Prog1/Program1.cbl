       IDENTIFICATION DIVISION. 
       PROGRAM-ID. Program1
       AUTHOR. Brianna Muleski.
       DATE-WRITTEN. 2/8/14.
      ******************************************************************
      * Purpose:
      *    This program calculates the shipping fees for the Acme 
      *    Shipping Company. 
      *          
      * Input:
      *    1. Customer Name - Alphamuneric
      *    2. Package Weight - Numeric, implied decimal used
      *    3. Is Hazardous - Alphanumeric
      *
      * Output:
      *    A summary of the shipping information is displayed in a 
      *    formatted chart including: package weight, charge per pound,
      *    base charge, surcharge, and shipping fee. 
      *    At the end of the session the total charge and the end of 
      *    session message is displayed.
      *
      * Date/time due: 2/21/14, 3PM
      *
      * Date assigned: 2/7/14
      * 
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
           05  WS-NAME         PIC X(15).
           05  WS-WEIGHT       PIC 99V99   VALUE 0.
           05  WS-HAZARD       PIC XXX.     
           
       01  CONSTANTS.
           05  WC-LBCHRGE1     PIC 9       VALUE 5.
           05  WC-HAZARDCHRG1  PIC 99      VALUE 17.
           05  WC-BASECHRG2    PIC 99      VALUE 20.
           05  WC-LBCHRGE2     PIC 9       VALUE 6.
           05  WC-HAZARDCHRG2  PIC 99      VALUE 22.
           05  WC-BASECHRG3    PIC 99      VALUE 41.
           05  WC-LBCHRGE3     PIC 9       VALUE 7.
           05  WC-HAZARDCHRG3  PIC 99      VALUE 27.
           05  WC-WEIGHT1      PIC 9       VALUE 5.
           05  WC-WEIGHT2      PIC 99      VALUE 10.
           
       01  COMPUTE-ITEMS.
           05  WS-SHIPPING     PIC 99V99.
           05  WT-TOTAL        PIC 9(3)V99.
       
       01  DISPLAY-ITEMS.
           05  DS-WEIGHT       PIC Z9.99.
           05  DS-LBCHRGE      PIC $ZZ9.
           05  DS-BASECHRG     PIC $ZZ9    VALUE 0.
           05  DS-SURCHARGE    PIC $ZZ9    VALUE 0.
           05  DS-SHIPPING     PIC $ZZ9.99.
           05  DS-TOTAL        PIC $ZZZ9.99.
       LINKAGE SECTION.
      * 
       PROCEDURE DIVISION.
      * 
       000-MAIN.
           PERFORM 100-ACCEPT-DATA
           PERFORM UNTIL WS-WEIGHT = ZERO
               PERFORM 200-COMPUTE-SHIPPING-FEE
               PERFORM 300-DISPLAY-SUMMARY
               PERFORM 100-ACCEPT-DATA
           END-PERFORM.
           MOVE WT-TOTAL TO DS-TOTAL
           DISPLAY WS-NAME 'YOUR TOTAL CHARGE DUE: ' DS-TOTAL
           DISPLAY SPACE
           DISPLAY '--END OF SESSION--'
           STOP RUN.   
      *
       100-ACCEPT-DATA.
           IF WS-NAME = SPACE
               DISPLAY 'ENTER CUSTOMER NAME'
               ACCEPT WS-NAME
               DISPLAY SPACE
           END-IF.
           DISPLAY 'ENTER PACKAGE WEIGHT, ENTER 0 TO END THE PROGRAM'
           ACCEPT WS-WEIGHT
           IF WS-WEIGHT NOT = ZERO
               MOVE SPACE TO WS-HAZARD
               DISPLAY 'PACKAGE CONTAINS HAZARDOUS MATERIAL? (YES/NO)'
               ACCEPT WS-HAZARD
           END-IF.
     *      
       200-COMPUTE-SHIPPING-FEE.
           MOVE ZERO TO DS-SURCHARGE
           IF WS-WEIGHT <= WC-WEIGHT1
               COMPUTE WS-SHIPPING = WS-WEIGHT * WC-LBCHRGE1
               MOVE WC-LBCHRGE1 TO DS-LBCHRGE               
               IF WS-HAZARD = 'YES'
                   ADD WC-HAZARDCHRG1 TO WS-SHIPPING
                   MOVE WC-HAZARDCHRG1 TO DS-SURCHARGE
               END-IF
           END-IF.
           IF WS-WEIGHT > WC-WEIGHT1 AND <= WC-WEIGHT2
               COMPUTE WS-SHIPPING = (WS-WEIGHT - WC-WEIGHT1) * 
                                      WC-LBCHRGE2
               ADD WC-BASECHRG2 TO WS-SHIPPING
               MOVE WC-BASECHRG2 TO DS-BASECHRG               
               MOVE WC-LBCHRGE2 TO DS-LBCHRGE
               IF WS-HAZARD = 'YES'
                   ADD WC-HAZARDCHRG2 TO WS-SHIPPING
                   MOVE WC-HAZARDCHRG2 TO DS-SURCHARGE                   
               END-IF
           END-IF.
           IF WS-WEIGHT > WC-WEIGHT2
               COMPUTE WS-SHIPPING = (WS-WEIGHT - WC-WEIGHT2) * 
                                      WC-LBCHRGE3
               ADD WC-BASECHRG3 TO WS-SHIPPING
               MOVE WC-LBCHRGE3 TO DS-LBCHRGE
               MOVE WC-BASECHRG3 TO DS-BASECHRG
               IF WS-HAZARD = 'YES'
                   ADD WC-HAZARDCHRG3 TO WS-SHIPPING
                   MOVE WC-HAZARDCHRG3 TO DS-SURCHARGE
               END-IF
           END-IF.
           ADD WS-SHIPPING TO WT-TOTAL.
      *
       300-DISPLAY-SUMMARY.
           MOVE WS-WEIGHT TO DS-WEIGHT
           MOVE WS-SHIPPING TO DS-SHIPPING
           DISPLAY SPACE
           DISPLAY '-------------------------------'
           DISPLAY 'PACKAGE WEIGHT: ' DS-WEIGHT ' POUNDS'
           DISPLAY 'CHARGE PER POUND: ' DS-LBCHRGE
           DISPLAY 'BASE CHARGE:      ' DS-BASECHRG
           DISPLAY 'SURCHARGE:        ' DS-SURCHARGE
           DISPLAY 'SHIPPING FEE:     ' DS-SHIPPING
           DISPLAY '-------------------------------'
           DISPLAY SPACE.
       