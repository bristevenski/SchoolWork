//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 1 - Getting Started, Stack & Queue review
// Purpose: This class represents an RPN evaluator. This class can
//          create a new RPN evaluator, process a single expression,
//          check the validity of the expression, return the value of
//          the expression and print the intermediate results of a 
//          single expression.
//-------------------------------------------------------------------
#include <iostream>
#include "RPNEval.h"
using namespace std; 

void RPNEval::ProcessExpression()
{
   bool done = false;
   valid = true;

   while (valid && !done)
      done = ProcessChar();

   cin.ignore( 100, '\n' );

   if (stack.IsEmpty())
      valid = false;
   else
   {
      float temp = stack.Pop();
      if (!stack.IsEmpty())
         valid = false;
      stack.Push(temp);
   }
   
   if (valid)
      answer = stack.Pop();
}

bool RPNEval::ProcessChar()
{
   char ch;   
   cin >> ch;
   if (ch >= '0' && ch <= '9')
   {
      cin.putback(ch);
      ProcessOperand();
   }
   else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
   {
      cout << ch << " ";
      valid = ProcessOperator(ch);
   }
   else if (ch == '#')
      return true;
   else
   {
      valid = false;
      cout << ch << " ";
   }

   return false;
}

void RPNEval::ProcessOperand()
{
   float num;
   cin >> num;
   cout << num << " ";
   stack.Push(num);
}

void RPNEval::PrintIntermediateResults()
{
   while (!queue.IsEmpty())
      cout << queue.Remove() << " ";
}

bool RPNEval::ProcessOperator(char ch)
{
   if (stack.IsEmpty())
      return false;
   float x, y;
   x = stack.Pop();
   if (stack.IsEmpty())
      return false;
   y = stack.Pop();

   if (ch == '+')
      Add(x, y);
   else if (ch == '-')
      Subtract(x, y);
   else if (ch == '*')
      Multiply(x, y);
   else
      return Divide(x, y);
   return true;
}

void RPNEval::Add(float x, float y)
{
   stack.Push(y + x);
   queue.Add(y + x);
}

void RPNEval::Subtract(float x, float y)
{
   stack.Push(y - x);
   queue.Add(y - x);
}
void RPNEval::Multiply(float x, float y)
{
   stack.Push(y * x);
   queue.Add(y * x);
}

bool RPNEval::Divide(float x, float y)
{
   if (x != 0)
   {
      stack.Push(y / x);
      queue.Add(y / x);
      return true;
   }
   return false;
}