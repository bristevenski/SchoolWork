//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 2 - Maintain and Manipulate a directory of companies.
// Purpose: Stores the name and phone number of a company. Overrides
//          operators <, =, ==, !=, <<, and >>.
//-------------------------------------------------------------------
#ifndef _COMPANY_H
#define _COMPANY_H
#include <iomanip>
using namespace std;

//#define TESTING_COMPANY
#ifdef TESTING_COMPANY
#include <iostream>
#endif

enum {PHONE_LEN = 10};
enum {MAX_NAME_LEN = 30};

class Company
{
public:
   // ---------------------------------------------------------------
   // Constructor: sets name to NULL.
   // ---------------------------------------------------------------
   Company() { name = NULL; }

   // ---------------------------------------------------------------
   // Copy Constructor: creates a new Company with comp's name and 
   // phone number.
   // ---------------------------------------------------------------
   Company(const Company& comp);

   // ---------------------------------------------------------------
   // Destructor: deletes name.
   // ---------------------------------------------------------------
   ~Company() { delete name; }

   // ---------------------------------------------------------------
   // Overloads operator=: sets name to rhs's name and phone number
   // to rhs's phone number, then returns the new Company.
   // ---------------------------------------------------------------
   Company& operator= (const Company& rhs);

   // ---------------------------------------------------------------
   // Overloads operator<: returns true if name is lexicographically 
   // less than rhs's name, false otherwise.
   // ---------------------------------------------------------------
   bool operator< (const Company& rhs) { return (strcmp(name, rhs.name) < 0); }

   // ---------------------------------------------------------------
   // Overloads operator==: returns true if name is the same as rhs's
   // name, false otherwise.
   // ---------------------------------------------------------------
   bool operator== (const Company& rhs){ return (strcmp(name, rhs.name) == 0); }

   // ---------------------------------------------------------------
   // Overloads operator!=: returns true if name is not the same as
   // rhs's name, false otherwise.
   // ---------------------------------------------------------------
   bool operator!= (const Company& rhs){ return (strcmp(name, rhs.name) != 0); }

private:
   char *name;
   char phone[PHONE_LEN];

   // ---------------------------------------------------------------
   // Overloads operator<<: writes the name, left-justified, a space, 
   // and then the phone number.
   // ---------------------------------------------------------------
   friend ostream& operator<< (ostream& out, const Company& rhs);

   // ---------------------------------------------------------------
   // Overloads operator>>: reads the name and phone number of a
   // Company.
   // ---------------------------------------------------------------
   friend istream& operator>> (istream& in, Company& rhs);
};
#endif
