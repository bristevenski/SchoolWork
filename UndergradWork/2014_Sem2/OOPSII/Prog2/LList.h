//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 2 - Maintain and Manipulate a directory of companies.
// Purpose: Holds a list of Nodes with an InfoType stored in each.
//-------------------------------------------------------------------
#ifndef _LLIST_H
#define _LLIST_H

#include "Company.h"
typedef Company InfoType; //must has operators <, ==, !=, =, <<

//#define TESTING_LLIST
#ifdef TESTING_LLIST
#include <iostream>
using namespace std;
#endif

class LList
{

public:
   // ---------------------------------------------------------------
   // Constructor: sets  list to NULL.
   // ---------------------------------------------------------------
   LList() { list = NULL; }

   // ---------------------------------------------------------------
   // Destructor: deletes all the Nodes and list.
   // ---------------------------------------------------------------
   ~LList();

   // ---------------------------------------------------------------
   // Returns true if the list is empty, false otherwise.
   // ---------------------------------------------------------------
   bool IsEmpty() const { return list == NULL; }

   // ---------------------------------------------------------------
   // Inserts x_ptr into a sorted list. Returns true if the x_ptr was
   // inserted, false if the object is already in the list.
   // ---------------------------------------------------------------
   bool Insert(InfoType * x_ptr);

   // ---------------------------------------------------------------
   // Deletes x if it is found in the list. Returns true if it is
   // deleted successfully, false otherwise.
   // ---------------------------------------------------------------
   bool Delete(const InfoType & x);

   // ---------------------------------------------------------------
   // Displays the objects in the list, one per line.
   // ---------------------------------------------------------------
   void Display(ostream & out_stream) const;

private:
   struct Node
   {
      // ------------------------------------------------------------
      // Constructor: sets infoPtr to x and next to the pointer p.
      // ------------------------------------------------------------
      Node(InfoType * x, Node * p = NULL) { infoPtr = x;  next = p; }

      // ------------------------------------------------------------
      // Destructor: deletes infoPtr.
      // ------------------------------------------------------------
      ~Node() { delete infoPtr; }
      InfoType * infoPtr;
      Node * next;
   };

   Node * list;

   // ---------------------------------------------------------------
   // Copy constructor: creates a new linked list with the same
   // objects and order of ojects as copyFrom.
   // ---------------------------------------------------------------
   LList(const LList & copyFrom);

   // ---------------------------------------------------------------
   // Overloads operator=: sets the list with the same objects and 
   // order of objects as assignFrom.
   // ---------------------------------------------------------------
   LList & operator= (const LList & assignFrom);
};

#endif