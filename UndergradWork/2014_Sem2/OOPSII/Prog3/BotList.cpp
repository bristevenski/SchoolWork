//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 3 - BOT wars Visual C++ Windows Program
// Purpose: Holds a list of Nodes with an InfoType stored in each.
//-------------------------------------------------------------------
#include "stdafx.h"
#include "BotList.h"

BotList::~BotList()
{
	Node *ptr = list;
   while (list != NULL)
   {
      list = list->next;
      delete ptr;
      ptr = list;
   }
}

void BotList::Insert(InfoType * x_ptr)
{
   if (list == NULL)
      list = new Node(x_ptr);
   else
   {
      Node *temp = list;
      Node *newNode = new Node(x_ptr, temp);
      list = newNode;
      temp->prev = newNode;
   }
}

void BotList::Delete(InfoType * dead)
{
   Node *ptr = list;
   while (ptr->infoPtr != dead)
      ptr = ptr->next;
   if (ptr->next == NULL)
   {
      Node *temp = ptr->prev;
      delete ptr;
      temp->next = NULL;
   }
   else if (ptr->prev == NULL)
   {
      list = list->next;
      list->prev = NULL;
      delete ptr;
   }
   else
   {
      Node *temp1 = ptr->next;
      Node *temp2 = ptr->prev;
      temp1->prev = ptr->prev;
      temp2->next = ptr->next;
      delete ptr;
   }
}

int BotList::Battles()
{
   if (list == NULL || list->next == NULL)
      return 0;
   int battles = 0;
   Node *ptr = list;
   while (ptr->next != NULL)
   {
      VBot *bot1 = ptr->infoPtr;
      Node *innerptr = ptr->next;
      while (innerptr != NULL)
      {
         VBot *bot2 = innerptr->infoPtr;
         if (bot1->CollidedWith(bot2))
         {
            bot1->DoBattleWith(bot2);
            battles++;
         }
         innerptr = innerptr->next;
      }
      ptr = ptr->next;
   }
   return battles;
}

void BotList::Move()
{
   Node *ptr = list;
   while (ptr != NULL)
   {
      ptr->infoPtr->Move();
      ptr = ptr->next;
   }
}

void BotList::Paint()
{
   Node *ptr = list;
   while (ptr != NULL)
   {
      ptr->infoPtr->Show();
      ptr = ptr->next;
   }
}

int BotList::CheckDeaths()
{
   int deaths = 0;
   if (list == NULL)
      return deaths;
   
   Node *ptr = list;
   while (ptr->next != NULL)
      ptr = ptr->next;
   while (ptr->prev != NULL)
   {
      InfoType *temp = ptr->infoPtr;
      ptr = ptr->prev;      
      if (temp->IsDead())
      {
         Delete(temp);
         deaths++;
      }
   }
   if (ptr->infoPtr->IsDead())
   {
      Delete(ptr->infoPtr);
      deaths++;
   }
   return deaths;
}

