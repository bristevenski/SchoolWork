//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 1 - Getting Started, Stack & Queue review
// Purpose: This class represents a Queue. This class can initalize
//          the queue, clear the queue, check if the queue is empty
//          or full, add an item to the back of the queue, and remove
//          an item from the front of the queue.
//-------------------------------------------------------------------
#ifndef _QUEUE_H
#define _QUEUE_H

typedef float QInfoType;
const int MAXQUEUE = 80;

//#define TESTING_QUEUE
#ifdef TESTING_QUEUE
#include <iostream>
using namespace std;
#endif

class Queue
{
public:
   //----------------------------------------------------------------
   // Constructor: Initalizes count, front, and rear to 0.
   //----------------------------------------------------------------
   Queue() { count = rear = front = 0; }

   //----------------------------------------------------------------
   // Checks whether the queue is empty or not. Returns true if 
   // empty, false otherwise.
   //----------------------------------------------------------------
   bool IsEmpty() { return count == 0; }

   //----------------------------------------------------------------
   // Checks whether the queue is full or not. Returns true if full,
   // false otherwise.
   //----------------------------------------------------------------
   bool IsFull() { return count == MAXQUEUE; }

   //----------------------------------------------------------------
   // Clears the queue and resets count to 0.
   //----------------------------------------------------------------
   void Clear() { count = rear = front = 0; }

   //----------------------------------------------------------------
   // Adds the item passes, newItem, to the back of the stack.
   //----------------------------------------------------------------
   void Add(QInfoType newItem);

   //----------------------------------------------------------------
   // Removes the item from the front of the queue and returns it.
   //----------------------------------------------------------------
   QInfoType Remove();
   
private:
   int count, rear, front;
   QInfoType items[MAXQUEUE];

};
#endif