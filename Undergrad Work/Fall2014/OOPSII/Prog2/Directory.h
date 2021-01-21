//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 2 - Maintain and Manipulate a directory of companies.
// Purpose: Controls a directory of Companies. Inserts a new company,
//          deletes an existing company, and prints the directory.
//-------------------------------------------------------------------
#ifndef _DIRECTORY_H
#define _DIRECTORY_H

#include "Company.h"
#include "LList.h"

class Directory
{
public:
   //----------------------------------------------------------------
   // Performs the requested operation on the directory based on the
   // input.
   //----------------------------------------------------------------
   void Run();
private:
   //----------------------------------------------------------------
   // Inserts the given company if it is not already in the list and
   // prints an appropriate confirming if it was inserted or not. 
   //----------------------------------------------------------------
   void Insert();

   //----------------------------------------------------------------
   // Deletes the given company from the list if it is in the list
   // and prints message confirming if it was deleted or not.
   //----------------------------------------------------------------
   void Delete();
   
   //----------------------------------------------------------------
   // Prints the current list of companies (names and phone numbers)
   // in the directory, one company per line, with a header.
   //----------------------------------------------------------------
   void Print();

   //----------------------------------------------------------------
   // Reads and inserts the current companies in the directory.
   //----------------------------------------------------------------
   void CurrentDir();

   //----------------------------------------------------------------
   // Prints an invalid command message.
   //----------------------------------------------------------------
   void BadCommand();

   LList list;
};
#endif