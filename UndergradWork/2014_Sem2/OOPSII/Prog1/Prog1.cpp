//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 1 - Getting Started, Stack & Queue review
// Purpose: This class runs the RPNEVal and prints a termination 
//          message when it is complete.
//-------------------------------------------------------------------
#include "Queue.h"
#include "RPNEval.h"
#include "Stack.h"
#include <iostream>
using namespace std;

void main()
{
   int numExp;
   cin >> numExp;
   for (int i = 1; i <= numExp; i++)
   {
      cout << "Expression " << i << ":" << endl;    
      RPNEval rpn;
      rpn.ProcessExpression();
      if (rpn.IsValid())
         cout << endl << "The value is: " << rpn.Value() << endl;
      else
         cout << endl << "Invalid Expression" << endl;
      cout << "The Intermediate Results are: ";
      rpn.PrintIntermediateResults();
      cout << endl << endl;
   }

   cout << "Normal Termination of Program 1!";
};