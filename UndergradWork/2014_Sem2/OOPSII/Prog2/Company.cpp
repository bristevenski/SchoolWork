//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 2 - Maintain and Manipulate a directory of companies.
// Purpose: Stores the name and phone number of a company. Overrides
//          operators <, =, ==, !=, <<, and >>.
//-------------------------------------------------------------------
#define _CRT_SECURE_NO_WARNINGS
#include "Company.h"
#include "LeakWatcher.h"


Company::Company(const Company& comp)
{
   name = comp.name;
   for (int i = 0; i < PHONE_LEN; i++)
      phone[i] = comp.phone[i];
}

Company& Company::operator=(const Company& rhs)
{
   if (this != &rhs)
   {
      name = rhs.name;
      for (int i = 0; i < PHONE_LEN; i++)
         phone[i] = rhs.phone[i];
   }
   return *this;
}

ostream& operator<<(ostream& out, const Company& rhs)
{
   out << setiosflags(ios::left) << setw(MAX_NAME_LEN) << rhs.name << " ";
   for (int i = 0; i < PHONE_LEN; i++)
      out << rhs.phone[i];
   out << endl;
   return out;
}

istream& operator>> (istream& in, Company& rhs)
{
   char buff[MAX_NAME_LEN + 1];
   in >> buff;
   rhs.name = new char[strlen(buff) + 1];
   strcpy(rhs.name, buff);

   for (int i = 0; i < PHONE_LEN; i++)
      in >> rhs.phone[i];
   return in;
}

#ifdef TESTING_COMPANY

// ------------------------------------------------------------------
// Testbed main. Tests all the methods of the Company class.
// ------------------------------------------------------------------
void main()
{
   Company *c1 = new Company;

   //Test for operator>> and operator<<
   cout << "Enter company: ";
   cin >> *c1;
   cout << "Test for operator>> and operator<<:" << endl
        << *c1;

   //Test for operator=
   Company *c3 = new Company();
   *c3 = *c1;
   cout << "Test for operator=:" << endl 
        << "Original Company: " << *c1 << endl
        << "Created Company:  " << *c3 << endl;
   
   //Test for copy constructor
   Company *c2 = new Company(*c1);
   cout << "Test for Copy constructor:" << endl
        << "Original Company: " << *c1 << endl
        << "Copied Company:   " << *c2 << endl;

   //Test for operator==
   cout << "Test for operator==:" << endl;
   if (*c1 == *c2)
      cout << "Test passed" << endl;
   else
      cout << "Test failed" << endl;

   //Test for operator!=
   cout << "Test for operator!=:" << endl;
   if (*c1 != *c2)
      cout << "Test failed" << endl;
   else
      cout << "Test passed" << endl;

   //Test for operator<
   Company *c4 = new Company();
   Company *c5 = new Company();
   cout << "Enter company 1:" << endl;
   cin >> *c4;
   cout << "Enter company 2:" << endl;
   cin >> *c5;
   if (*c4 < *c5)
      cout << "Company 1 is less than Company 2" << endl;
   else if (*c5 < *c4)
      cout << "Company 2 is less than Company 1" << endl;

   delete c1, c2, c3, c4, c5;
}

#endif