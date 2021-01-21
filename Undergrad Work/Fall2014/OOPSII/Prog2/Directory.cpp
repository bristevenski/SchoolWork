//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 2 - Maintain and Manipulate a directory of companies.
// Purpose: Controls a directory of Companies. Inserts a new company,
//          deletes an existing company, and prints the directory.
//-------------------------------------------------------------------
#include "Directory.h"
#include "LeakWatcher.h"
#include <iostream>

void Directory::Run()
{
   CurrentDir();

   char command;

   cin >> command;
   while (command != 'S')
   {
      if (command == 'I')
      {
         Insert();
         cout << endl;
      }
      else if (command == 'D')
         Delete();
      else if (command == 'P')
         Print();
      else
         BadCommand();
      cin >> command;
   }

   cout << "Normal Termination of Program 2!";
}

void Directory::CurrentDir()
{
   int numComp;

   cin >> numComp;

   cout << "There are " << numComp << " companies initially in the " 
        << "directory." << endl << "They will be read in and "
        << "inserted in the list in order." << endl;

   for (int i = 0; i < numComp; i++)
      Insert();

   cout << endl;
}

void Directory::Insert()
{
   Company *newComp = new Company;

   cin >> *newComp;

   bool successful = list.Insert(newComp);
   
   if (successful)
      cout << "Added to directory:     " << *newComp;
   else
   {
      cout << "Already in directory:   " << *newComp;
      delete newComp;
   }

}

void Directory::Delete()
{
   Company *delComp = new Company;
  
   cin >> *delComp;
   
   bool successful = list.Delete(*delComp);
   
   if (!successful)
      cout << "Wasn't in directory:    " << *delComp << endl;
   else
      cout << "Deleted from directory: " << *delComp << endl;

   delete delComp;
}


void Directory::Print()
{
   cout << "Below are the companies currently in the directory:"
        << endl;

   list.Display(cout);

   cout << endl;
}

void Directory::BadCommand()
{
   cin.ignore(256, '\n');

   cout << "Invalid Command!" << endl << endl;
}


