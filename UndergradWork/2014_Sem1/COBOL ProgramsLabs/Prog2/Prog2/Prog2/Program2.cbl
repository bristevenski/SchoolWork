       IDENTIFICATION DIVISION. 
       PROGRAM-ID. Program2
       AUTHOR. Brianna Muleski.
       DATE-WRITTEN. 3/15/14.
      ******************************************************************
      * Purpose:
      *    This program creates a report that shows the old salary and
      *    the new salary of the employees at International Cherry
      *    Machine Company.
      *          
      * Input:
      *    employee.dat
      *    A line sequential file that contains the information of the 
      *    employees including:
      *        Employee Number - Alphanumeric
      *        Emplyee Name - Alphanumeric
      *        Location Code - Alphanumberic
      *        Annual Salary - Numeric
      *        Social Security Number - Alphanumeric
      *        Number of Dependents - Alphanumeric
      *        Job Classification Code - Alphanumeric
      *
      * Output:
      *    employee.rpt
      *    A line sequential file that is formatted with the employee's
      *    name, number, office number, job code, annual salary, percent
      *    increase, amount increase, and new salary.
      *
      * Date/time due: 3/26/14, 5PM
      * 
      ******************************************************************
       ENVIRONMENT DIVISION.
       CONFIGURATION SECTION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
           SELECT IN-EMPLOYEE-FILE ASSIGN TO "EMPLOYEE.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
                
           SELECT OUT-EMPLOYEE-FILE ASSIGN TO "EMPLOYEE.RPT"
               ORGANIZATION IS LINE SEQUENTIAL.
      * 
       DATA DIVISION.
       FILE SECTION.
       FD  IN-EMPLOYEE-FILE.
       01 IN-FILE-REC.
           05  EMPLOYEE-NO     PIC X(5).
           05  EMPLOYEE-NAME   PIC X(20).
           05  FILLER.
               10  FILLER      PIC X(2).
               10  OFFIC-NO    PIC X(2).
           05  ANN-SALARY      PIC 9(6).
           05  FILLER          PIC X(9).
           05  FILLER          PIC XX.
           05  JOB-CLASS-NO    PIC XX.
      * 
       FD OUT-EMPLOYEE-FILE.
       01 OUT-EMPLOYEE-REC     PIC X(80).
      *
       WORKING-STORAGE SECTION.
       01  WORK-ITEMS.
           05  NEW-SAL         PIC 9(8)V99.
           05  PER-INC         PIC 9V9.
           05  AMT-INC         PIC 9(5)V99.
           05  TOTAL-ANN       PIC 9(9).
           05  TOTAL-INC       PIC 9(8)V99.
           05  TOTAL-NEW       PIC 9(9)V99.
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
           05  LOW-INC         PIC 9V9     VALUE 3.0.
           05  MID-INC         PIC 9V9     VALUE 3.5.
           05  HIGH-INC        PIC 9V9     VALUE 4.0. 
           05  MAX-LINE        PIC 99      VALUE 55.
           05  OFF-NO-01       PIC 99      VALUE 01.
           05  OFF-NO-02       PIC 99      VALUE 02.
           05  OFF-NO-03       PIC 99      VALUE 03.
           05  OFF-NO-04       PIC 99      VALUE 04.
           05  OFF-NO-05       PIC 99      VALUE 05.
           05  OFF-NO-06       PIC 99      VALUE 06.
           05  OFF-NO-07       PIC 99      VALUE 07.
           05  JOB-NO-01       PIC 99      VALUE 01.
           05  JOB-NO-02       PIC 99      VALUE 02.
           05  JOB-NO-03       PIC 99      VALUE 03.
           05  TW-LINES        PIC 9       VALUE 2.
           05  FV-LINES        PIC 9       VALUE 5.
           05  PERC            PIC 999     VALUE 100.
       01  PAGE-HEADER1.
           05  FILLER          PIC X(6)    VALUE "DATE: ".
           05  H-MM		       PIC 99.
           05  FILLER          PIC X       VALUE '/'.
           05  H-DAY           PIC 99.
           05  FILLER          PIC X       VALUE '/'.
           05  H-YEAR          PIC 9(4).
           05  FILLER          PIC X(7)    VALUE SPACES.
           05  FILLER          PIC X(20)   VALUE "INTERNATIONAL CHERRY".
           05  FILLER          PIC X(16)   VALUE " MACHINE COMPANY".
           05  FILLER          PIC X(13)   VALUE SPACES.
           05  FILLER          PIC X(5)    VALUE "PAGE ".
           05  PAGE-NO         PIC ZZ9.
       01  PAGE-HEADER2.
           05  FILLER          PIC X(6)    VALUE "TIME: ".
           05  H-HOUR          PIC 99.
           05  FILLER          PIC X       VALUE ":".
           05  H-MIN           PIC 99.
           05  FILLER          PIC X(16)   VALUE SPACES.
           05  FILLER          PIC X(15)   VALUE "SALARY INCREASE".
           05  FILLER          PIC X(14)    VALUE " DETAIL REPORT".
           05  FILLER          PIC X(9)    VALUE SPACES.
           05  FILLER          PIC X(15)   VALUE "BRIANNA MULESKI".
       01  COLUMN-HEADER1.
           05  FILLER          PIC X(17)   VALUE "EMPLOYEE EMPLOYEE".
           05  FILLER          PIC X(12)   VALUE SPACES.
           05  FILLER          PIC X(10)   VALUE "OFFICE JOB".
           05  FILLER          PIC X(16)   VALUE "   ANNUAL  PERC.".
           05  FILLER          PIC X(7)    VALUE "    AMT".
           05  FILLER          PIC X(13)   VALUE SPACES.
           05  FILLER          PIC X(5)    VALUE "NEW  ".
       01  COLUMN-HEADER2.
           05  FILLER          PIC X(13)   VALUE "  NUM    NAME".
           05  FILLER          PIC X(18)   VALUE SPACES.
           05  FILLER          PIC X(9)    VALUE "NO   CODE".
           05  FILLER          PIC X(15)   VALUE "  SALARY  INCR.".
           05  FILLER          PIC X(10)   VALUE "  INCREASE".
           05  FILLER          PIC X(9)    VALUE SPACES.
           05  FILLER          PIC X(6)    VALUE "SALARY".
       01  PAGE-FOOTER.
           05  FILLER          PIC X(24)   VALUE SPACES.
           05  FILLER          PIC X(6)    VALUE "TOTALS".
           05  FILLER          PIC X(8)    VALUE SPACES.
           05  ANN-SAL-TOT     PIC $$$,$$$,$$9.
           05  FILLER          PIC X(3)    VALUE SPACES.
           05  AMT-INC-TOT     PIC $$,$$$,$$9.99.
           05  FILLER          PIC X       VALUE SPACE.
           05  NEW-SAL-TOT     PIC $$$,$$$,$$9.99.
       01  DISPLAY-EMPLOYEE-INFO.
           05  FILLER          PIC X       VALUE SPACE.
           05  DS-NO           PIC X(5).
           05  FILLER          PIC XXX     VALUE SPACES.
           05  DS-NAME         PIC X(20).
           05  FILLER          PIC XX      VALUE SPACES.
           05  DS-OFF-NO       PIC XX.
           05  FILLER          PIC XXX     VALUE SPACES.
           05  DS-JOB-NO       PIC XX.
           05  FILLER          PIC XXX     VALUE SPACES.
           05  DS-ANN-SAL      PIC $ZZZ,ZZ9.
           05  FILLER          PIC X       VALUE SPACE.
           05  DS-PER-INC      PIC 9.9.
           05  FILLER          PIC X       VALUE "%".
           05  FILLER          PIC X       VALUE SPACE.
           05  DS-AMT-INC      PIC $ZZ,ZZ9.99.
           05  FILLER          PIC XX      VALUE SPACES.
           05  DS-NEW-SAL      PIC $$,$$$,$$9.99.           
      *       
       LINKAGE SECTION.
      * 
       PROCEDURE DIVISION.
      * RUNS THE PROGRAM. DISPLAYS 'REPORT GENERATED' WHEN THE PROGRAM
      * IS COMPLETE.
       000-MAIN.
           PERFORM 100-OPEN
           PERFORM 200-WRITE-PAGE 
           PERFORM 900-CLOSE
           DISPLAY "REPORT GENERATED!"
           
           STOP RUN.
           
      * OPENS THE INPUT AND OUTPUT FILES.
       100-OPEN.
           OPEN INPUT IN-EMPLOYEE-FILE
           OPEN OUTPUT OUT-EMPLOYEE-FILE.
           
      * WRITES THE HEADING FOR PAGE 1 AND THE INFORMATION OF EACH 
      * EMPLOYEE UNTIL THE END OF FILE, THEN PRINTS THE TOTALS.
       200-WRITE-PAGE.
           PERFORM UNTIL EOF-SWITCH = 'Y'
                   PERFORM 600-WRITE-HEADING
                   PERFORM 300-READ UNTIL EOF-SWITCH = 'Y'
           END-PERFORM
           
           PERFORM 800-WRITE-TOTALS.
           
      * READS THE EMPLOYEE FILE AND WRITES THE INFORMATION OF THE
      * EMPLOYEE. WHEN THE LINE COUNT REACHES THE MAX (55), THE PAGE
      * COUNT IS UPDATED AND THE HEADING IS WRITTEN FOR THE NEW PAGE.
      * WHEN THE END OF THE FILE IS REACHED, THE END OF FILE SWITCH 
      * IS SWITCHED TO YES.
       300-READ.
           READ IN-EMPLOYEE-FILE
               AT END
                   MOVE 'Y' TO EOF-SWITCH
               NOT AT END
                   IF LN-COUNT < MAX-LINE
                       PERFORM 400-CALCULATIONS
                       PERFORM 700-WRITE-EMPLOYEE-INFO
                   ELSE
                       ADD 1 TO PG-COUNT 
                       MOVE 1 TO LN-COUNT
                       PERFORM 600-WRITE-HEADING
                       PERFORM 400-CALCULATIONS
                       PERFORM 700-WRITE-EMPLOYEE-INFO   
           END-READ.
           
      * CALCULATES THE NEW SALARY AND AMOUNT INCREASE OF THE EMPLOYEE.
       400-CALCULATIONS.
           PERFORM 500-PERCENT-INCREASE
           COMPUTE NEW-SAL = ANN-SALARY + (ANN-SALARY * PER-INC / PERC)                                        
           COMPUTE AMT-INC = NEW-SAL - ANN-SALARY
           
           ADD ANN-SALARY TO TOTAL-ANN
           ADD NEW-SAL    TO TOTAL-NEW
           ADD AMT-INC    TO TOTAL-INC.
           
      * EVAULATES THE OFFICE NUMBER AND JOB CLASS CODE AND DETERMINES
      * WHAT PERCENT OF INCREASE IS GIVEN.
       500-PERCENT-INCREASE.
           EVALUATE TRUE
               WHEN OFFIC-NO = OFF-NO-02 OR OFF-NO-04 OR OFF-NO-06
                   MOVE LOW-INC TO PER-INC
               WHEN OFFIC-NO = OFF-NO-01
                   IF JOB-CLASS-NO = JOB-NO-01 OR JOB-NO-02
                       MOVE MID-INC TO PER-INC
                   ELSE
                       MOVE ZEROS TO PER-INC
               WHEN OFFIC-NO = OFF-NO-03
                   IF JOB-CLASS-NO = JOB-NO-03
                       MOVE LOW-INC TO PER-INC
                   ELSE
                       MOVE MID-INC TO PER-INC
               WHEN OFFIC-NO = OFF-NO-05
                   IF JOB-CLASS-NO = JOB-NO-01 OR JOB-NO-03
                       MOVE ZEROS TO PER-INC
                   ELSE
                       MOVE MID-INC TO PER-INC
               WHEN OFFIC-NO = OFF-NO-07
                   IF JOB-CLASS-NO = JOB-NO-01
                       MOVE LOW-INC TO PER-INC
                   ELSE
                       MOVE HIGH-INC TO PER-INC
               WHEN OTHER
                   MOVE ZEROS TO PER-INC
           END-EVALUATE.
           
      * WRITES THE HEADING FOR THE PAGE.
       600-WRITE-HEADING.
           MOVE FUNCTION CURRENT-DATE TO WS-DATE
           
           MOVE WS-YEAR  TO H-YEAR
           MOVE WS-MM    TO H-MM
           MOVE WS-DAY   TO H-DAY
           MOVE WS-HR    TO H-HOUR
           MOVE WS-MIN   TO H-MIN
           MOVE PG-COUNT TO PAGE-NO
           
           IF LN-COUNT = MAX-LINE
               WRITE OUT-EMPLOYEE-REC FROM PAGE-HEADER1
                   AFTER ADVANCING PAGE
           ELSE
               WRITE OUT-EMPLOYEE-REC FROM PAGE-HEADER1
           WRITE OUT-EMPLOYEE-REC FROM PAGE-HEADER2
           WRITE OUT-EMPLOYEE-REC FROM COLUMN-HEADER1
               AFTER ADVANCING 1 LINE
           WRITE OUT-EMPLOYEE-REC FROM COLUMN-HEADER2
               AFTER ADVANCING 1 LINE
               
           ADD FV-LINES TO LN-COUNT.
           
      * WRITES THE EMPLOYEE INFORMATION FOR ONE EMPLOYEE 
       700-WRITE-EMPLOYEE-INFO.
           MOVE NEW-SAL       TO DS-NEW-SAL
           MOVE ANN-SALARY    TO DS-ANN-SAL
           MOVE PER-INC       TO DS-PER-INC
           MOVE AMT-INC       TO DS-AMT-INC
           MOVE EMPLOYEE-NO   TO DS-NO
           MOVE EMPLOYEE-NAME TO DS-NAME
           MOVE OFFIC-NO      TO DS-OFF-NO
           MOVE JOB-CLASS-NO  TO DS-JOB-NO
           
           WRITE OUT-EMPLOYEE-REC FROM DISPLAY-EMPLOYEE-INFO
               AFTER ADVANCING TW-LINES LINES.
               
           ADD TW-LINES TO LN-COUNT.
           
      * WRITES THE TOTALS OF THE ANNUAL SALARIES, AMOUNT INCREASES,
      * AND NEW SALARIES. 
       800-WRITE-TOTALS.
           MOVE TOTAL-ANN TO ANN-SAL-TOT
           MOVE TOTAL-INC TO AMT-INC-TOT
           MOVE TOTAL-NEW TO NEW-SAL-TOT
           
           WRITE OUT-EMPLOYEE-REC FROM PAGE-FOOTER
               AFTER ADVANCING TW-LINES LINES.
               
      * CLOSES THE INPUT AND OUTPUT FILES.
       900-CLOSE.
           CLOSE IN-EMPLOYEE-FILE
           CLOSE OUT-EMPLOYEE-FILE.
       