//-------------------------------------------------------------------
// Name:    Brianna Muleski   
// Project: 2 - Maintain and Manipulate a directory of companies.
// Purpose: Holds a list of Nodes with an InfoType stored in each.
//-------------------------------------------------------------------
#include "LList.h"
#include "LeakWatcher.h"

LList::~LList()
{
   Node *ptr = list;
   while (list != NULL)
   {
      list = list->next;
      delete ptr;
      ptr = list;
   }
}

bool LList::Insert(InfoType * x_ptr)
{
   if (IsEmpty() || *x_ptr < *list->infoPtr)
   {
      list = new Node(x_ptr, list);
      return true;
   }
   if (*list->infoPtr == *x_ptr)
      return false;
   Node *p = list;
   while (p->next != NULL && *p->next->infoPtr < *x_ptr)
      p = p->next;
   if (p->next != NULL && *p->next->infoPtr == *x_ptr)
      return false;
   p->next = new Node(x_ptr, p->next);

   return true;
}

bool LList::Delete(const InfoType & x)
{
   if (IsEmpty())
      return false;
   Node *prev = NULL;
   Node *curr = list;
   if (*curr->infoPtr == x)
   {
      list = curr->next;
      delete curr;
      return true;
   }
   while (curr != NULL && *curr->infoPtr != x)
   {
      prev = curr;
      curr = curr->next;
   }
   if (curr == NULL)
      return false;
   else
   {
      prev->next = curr->next;
      delete curr;
   }
   return true;
}

void LList::Display(ostream & out_stream) const
{
   Node *ptr = list;
   while (ptr != NULL)
   {
      out_stream << *ptr->infoPtr;
      ptr = ptr->next;
   }
}

#ifdef TESTING_LLIST
//-------------------------------------------------------------------
// Testbed main. Tests all the methods of the LList class.
//-------------------------------------------------------------------
void main()
{
   LList list;
   //Test for IsEmpty
   cout << "Test for IsEmpty method:" << endl;
   if (list.IsEmpty())
      cout << "IsEmpty test passed." << endl;
   else
      cout << "IsEmpty test failed" << endl;

   //Test for Insert
   Company *c1 = new Company();
   cout << "Enter a company:" << endl;
   cin >> *c1;
   bool passed = list.Insert(c1);
   cout << "Test for Insert method:" << endl;
   if (passed)
      cout << "Insert test passed" << endl;
   else
      cout << "Insert test failed" << endl;

   //Test for Display
   cout << "Test for Display method:" << endl;
   list.Display(cout);
   
   //Test for Delete
   cout << "Test for Delete method:" << endl;
   passed = list.Delete(*c1);
   if (passed)
      cout << "Delete test passed" << endl;
   else
      cout << "Delete test failed" << endl;

}
#endif