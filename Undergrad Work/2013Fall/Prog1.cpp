//---------------------------------------------------------------------
//
// Name:    Brianna Muleski
//
// Course:  CS 1430, Section 2
//
// Purpose: The Purpose of this lab is to calculate and print the
//			perimeter, or the area of a semicircle, depending upon the
//			given radius of the circle and the given command.
//
// Input:   User will input the desired measurement between the 
//			diameter, perimeter, or area, and the radius of the circle.
//
// Output:  The user will be prompted for the input, then the
//			measurement will be displayed, or an error message will
//			be displayed.
//---------------------------------------------------------------------

#include <iostream>
#include <iomanip>
#include <string>
using namespace std;

const double PI = 3.14159265;
const int CONSTANT = 2;

int main()
{
   string command;
   float radius, measurement;

   cout << "Input a command of either diameter, perimeter or area,"
	    << " followed by a space, and float value for the radius." << endl;

   cin >> command >> radius;

   if (radius <= 0)
      cout << endl << endl << "You entered " << radius << " for the radius."
	       << endl << "You should have entered a positive value.";
   
   if (command != "diameter" && command != "perimeter" && command != "area")
   {
      cout << endl << "You entered <" << command << "> for a command."
		   << endl << "You should have entered either diameter, parimeter, area.";
	  return 0;
   }

   if (command == "diameter")
      measurement = CONSTANT * radius;
   else if (command == "perimeter")
      measurement = radius * (CONSTANT + PI);
   else
	  measurement = PI * radius * radius / CONSTANT;

   if (radius > 0)
      cout << endl << endl << "The " << command << " of a semicircle with radius "
	       << radius << " is " << measurement << ".";
      

   return 0;
}
