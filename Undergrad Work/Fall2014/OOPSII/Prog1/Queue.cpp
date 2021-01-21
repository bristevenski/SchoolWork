//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 1 - Getting Started, Stack & Queue review
// Purpose: This class represents a Queue. This class can initalize
//          the queue, clear the queue, check if the queue is empty
//          or full, add an item to the back of the queue, and remove
//          an item from the front of the queue.
//-------------------------------------------------------------------
#include "Queue.h"

void Queue::Add(QInfoType newItem)
{
   items[rear] = newItem;
   rear = (rear + 1) % MAXQUEUE;
   count++;
}

QInfoType Queue::Remove()
{
   QInfoType x = items[front];
   front = (front + 1) % MAXQUEUE;
   count--;
   return x;
}

#ifdef TESTING_QUEUE

// ------------------------------------------------------------------
// Testbed main. Tests all methods of the Queue class.
// ------------------------------------------------------------------
void main()
{
   Queue q;
   //Test for IsEmpty method with empty queue
   cout << "Tests for isEmpty method:" << endl;
   if (q.IsEmpty())
      cout << "IsEmpty test passed." << endl;
   else
      cout << "IsEmpty test failed." << endl;

   //Test for IsEmpty method with not empty queue
   for (int i = 0; i < 5; i++)
      q.Add(1);
   if (q.IsEmpty())
      cout << "IsEmpty test failed." << endl << endl;
   else
      cout << "IsEmpty test passed." << endl << endl;


   //Test for IsFull method with empty queue
   q.Clear();
   cout << "Tests for isFull method:" << endl;
   if (q.IsFull())
      cout << "IsFull test failed." << endl;
   else
      cout << "IsFull test passed." << endl;

   //Test for IsFull method with full queue
   for (int i = 0; i < MAXQUEUE; i++)
      q.Add(1);
   if (q.IsFull())
      cout << "IsFull test passed." << endl << endl;
   else
      cout << "IsFull test failed." << endl << endl;

   //Test for Add method
   q.Clear();
   q.Add(2);
   q.Add(4);
   q.Add(6);
   cout << "Test for add method:" << endl
        << "Expected:" << endl
        << " 2, 4, 6" << endl
        << "Result:" << endl;
   for (int i = 0; i < 3; i++)
      cout << q.Remove() << ", ";
   cout << endl << endl;

   //Test for Remove method
   q.Add(1);
   q.Add(2);
   cout << "Test for remove method:" << endl
        << "Expected:" << endl
        << "Removed item: 1" << endl
        << "Result:" << endl
        << "Removed item: " << q.Remove() << endl << endl;

   //Test for Clear method
   cout << "Test for Clear method:" << endl;
   for (int i = 0; i < 10; i++)
      q.Add(4);
   q.Clear();
   if (q.IsEmpty())
      cout << "Clear test passed." << endl;
   else
      cout << "Clear test failed." << endl;

}

#endif