//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 3 - BOT wars Visual C++ Windows Program
// Purpose: Holds a list of Nodes with an InfoType stored in each. 
//          Uses a doubly linked list to store the Nodes.
//-------------------------------------------------------------------
#pragma once

#include "VBot.h"
typedef VBot InfoType;

class BotList
{

public:
   // ---------------------------------------------------------------
   // Constructor: sets  list to NULL.
   // ---------------------------------------------------------------
   BotList() { list = NULL; }

   // ---------------------------------------------------------------
   // Destructor: deletes all the Nodes and list.
   // ---------------------------------------------------------------
   ~BotList();

   // ---------------------------------------------------------------
   // Returns true if the list is empty, false otherwise.
   // ---------------------------------------------------------------
   bool IsEmpty() const { return list == NULL; }

   // ---------------------------------------------------------------
   // Inserts x_ptr into the list.
   // ---------------------------------------------------------------
   void Insert(InfoType * x_ptr);

   //----------------------------------------------------------------
   // Checks every bot in the list to see if it has collided with 
   // another bot in the list. If a collision is detected, the bots
   // battle. Returns the number of battles.
   //----------------------------------------------------------------
   int Battles();

   //----------------------------------------------------------------
   // Moves all the bots in the list.
   //----------------------------------------------------------------
   void Move();

   //----------------------------------------------------------------
   // Checks for deaths of bots. If one is dead, removes it from the
   // list. Returns the number of deaths.
   //----------------------------------------------------------------
   int CheckDeaths();

   //----------------------------------------------------------------
   // Paints all the bots in the list.
   //----------------------------------------------------------------
   void Paint();

private:
   struct Node
   {
      // ------------------------------------------------------------
      // Constructor: sets infoPtr to x and next to the pointer p.
      // ------------------------------------------------------------
      Node(InfoType * x, Node * n = NULL, Node * p = NULL) :
         infoPtr(x), next(n), prev(p) {}

      // ------------------------------------------------------------
      // Destructor: deletes infoPtr.
      // ------------------------------------------------------------
      ~Node() { delete infoPtr; }
      InfoType * infoPtr;
      Node * next, * prev;
   };

   Node * list;

   // ---------------------------------------------------------------
   // Copy constructor: creates a new linked list with the same
   // objects and order of ojects as copyFrom.
   // ---------------------------------------------------------------
   BotList(const BotList & copyFrom);

   // ---------------------------------------------------------------
   // Overloads operator=: sets the list with the same objects and 
   // order of objects as assignFrom.
   // ---------------------------------------------------------------
   BotList & operator= (const BotList & assignFrom);

   //----------------------------------------------------------------
   // Deletes the node that contains the passed infotype. 
   //----------------------------------------------------------------
   void Delete(InfoType * dead);
};

#pragma endregion