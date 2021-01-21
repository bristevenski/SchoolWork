//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 1 - Getting Started, Stack & Queue review
// Purpose: This class represents a stack. This class can initalize
//          the stack, clear the stack, check if the stack is empty
//          or full, push an item onto the top of the stack, and push
//          the top item off the stack.
//-------------------------------------------------------------------
#include "Stack.h"

SInfoType Stack::Pop()
{
   SInfoType item = items[--top];
   return item;
};

#ifdef TESTING_STACK

// ------------------------------------------------------------------
// Testbed main. Tests all the methods of the Stack class.
// ------------------------------------------------------------------
void main()
{
   Stack s;
   //Test for IsEmpty method with empty stack
   cout << "Tests for IsEmpty method:" << endl;
   if (s.IsEmpty())
      cout << "IsEmpty test passed" << endl;
   else
      cout << "IsEmpty test failed" << endl;

   //Test for IsEmpty method with not empty stack
   for (int i = 0; i < 5; i++)
      s.Push(2);
   if (s.IsEmpty())
      cout << "IsEmpty test failed" << endl << endl;
   else
      cout << "IsEmpty test passed" << endl << endl;

   //Test for IsFull method with empty stack
   s.Clear();
   cout << "Tests for IsFull method:" << endl;
   if (s.IsFull())
      cout << "IsFull test failed." << endl;
   else
      cout << "IsFull test passed." << endl;

   //Test for IsFull method with full stack
   for (int i = 0; i < MAXSTACK; i++)
      s.Push(4);
   if (s.IsFull())
      cout << "IsFull test passed." << endl << endl;
   else
      cout << "IsFull test failed." << endl << endl;

   //Test for Push method
   s.Clear();
   s.Push(4);
   cout << "Test for Push method:" << endl
        << "Expected:" << endl
        << "4" << endl
        << "Results:" << endl
        << s.Pop() << endl << endl;

   //Test for Pop method
   s.Push(4);
   s.Push(6);
   cout << "Test for Pop method:" << endl
        << "Expected:" << endl
        << "6" << endl
        << "Results:" << endl
        << s.Pop() << endl << endl;

   //Test for Clear method
   for (int i = 0; i < 10; i++)
      s.Push(i);
   s.Clear();
   cout << "Test for Clear method:" << endl;
   if (s.IsEmpty())
      cout << "Clear test passed" << endl;
   else
      cout << "Clear test failed" << endl;
};

#endif