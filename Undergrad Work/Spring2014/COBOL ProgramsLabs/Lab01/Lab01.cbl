       IDENTIFICATION DIVISION.
       PROGRAM-ID. LAB01
       AUTHOR. Brianna Muleski
       DATE-WRITTEN. 1/24/14.
      *****************************************************************
      * Purpose:
      *    This program shows a general structure of a COBOL program.
      *    You can use this program as a template for your labs or
      *    programs. Use ALL UPPERCASE letters for your COBOL codes.
      *    Use lowercase letters for your comments.
      * Input:
      *    None.
      * Output:
      *    Display a message: Hello World!!
      *****************************************************************
       ENVIRONMENT DIVISION.
       CONFIGURATION SECTION.
      *
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
      *
       DATA DIVISION.
       FILE SECTION.
      *
       WORKING-STORAGE SECTION.
      *
       LINKAGE SECTION.
      *
       PROCEDURE DIVISION.
       000-MAIN.
           DISPLAY 'Hello World!!'
           STOP RUN.