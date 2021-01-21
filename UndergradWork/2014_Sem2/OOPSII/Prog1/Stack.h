//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 1 - Getting Started, Stack & Queue review
// Purpose: This class represents a stack. This class can initalize
//          the stack, clear the stack, check if the stack is empty
//          or full, push an item onto the top of the stack, and push
//          the top item off the stack.
//-------------------------------------------------------------------
#ifndef _STACK_H
#define _STACK_H

typedef float SInfoType;
const int MAXSTACK = 80;

//#define TESTING_STACK
#ifdef TESTING_STACK
#include <iostream>
using namespace std;
#endif

class Stack
{
public:
   //----------------------------------------------------------------
   // Constructor: Initializes top to 0 (Creates an empty stack).
   //----------------------------------------------------------------
   Stack() { top = 0; }

   //----------------------------------------------------------------
   // Clears the stack and resets top to 0.
   //----------------------------------------------------------------
   void Clear() { top = 0; }

   //----------------------------------------------------------------
   // Checks whether the stack is empty or not. Returns true if empty,
   // false otherwise.
   //----------------------------------------------------------------
   bool IsEmpty() const { return top == 0; }

   //----------------------------------------------------------------
   // Checks whether the stack is full or not. Returns true if full,
   // false otherwise.
   //----------------------------------------------------------------
   bool IsFull() const { return top == MAXSTACK; }

   //----------------------------------------------------------------
   // Pushes the item passes, newItem, onto the top of the stack.
   //----------------------------------------------------------------
   void Push(const SInfoType newItem) { items[top++] = newItem; }

   //----------------------------------------------------------------
   // Pops the item on the top of the stack and returns it.
   //----------------------------------------------------------------
   SInfoType Pop();

private:
   int top;
   SInfoType items[MAXSTACK];
};



#endif

