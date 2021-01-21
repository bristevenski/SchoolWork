#include <cstddef>

template<class ItemType>
class SortedList
{
public:
   SortedList() { list = NULL; }

   SortedList(const SortedList &orgList);

   SortedList& operator= (const SortedList & orgList);

   ~SortedList();

   void Insert(ItemType x);

   void Delete(ItemType x);

   void Print();

private:
   struct Node
   {
      Node(ItemType x, Node *n = NULL, Node *p = NULL) :
         data(x), next(n), prev(p) {}

      ItemType data;
      Node *next, *prev;
   };

   Node *list;
};


template<class ItemType>
SortedList<ItemType>::SortedList(const SortedList &orgList)
{
   if (orgList == NULL)
      list = NULL;
   else
   {
      next = prev = NULL;      
      Node *p = orgList;
      while (p != NULL)
      {
         Insert(p->data);
         p = p->next;
      }
      list = orgList;
   }
}

template<class ItemType>
SortedList<ItemType>& SortedList<ItemType>::operator= (const SortedList<ItemType> & rhs)
{
   if (this == &rhs)
      return *this;
   if (rhs == NULL)
      return NULL;
   
   Node *p = rhs;
   while (p != NULL)
   {
      Insert(p->data);
      p = p->next;
   }
   return *this;
}

template<class ItemType>
SortedList<ItemType>::~SortedList()
{
   Node *p = list;
   while (list != NULL)
   {
      list = list->next;
      delete p;
      p = list;
   }
}

template<class ItemType>
void SortedList<ItemType>::Insert(ItemType x)
{
   if (x == ' ')
      return;
   if (list == NULL)
      list = new Node(x);
   else if (list->next == NULL)
   {
      if (x < list->data)
      {
         list = new Node(x, list, NULL);
         list->next->prev = list->next;
      }
      else
         list->next = new Node(x, NULL, list);
   }
   else
   {
      Node *p = list;
      while (p->next != NULL && x > p->next->data)
         p = p->next;
      Node *newNode = new Node(x, p->next, p); 
      if (p->next != NULL)
         p->next->prev = newNode;
      p->next = newNode;
   }
}

template<class ItemType>
void SortedList<ItemType>::Delete(ItemType x)
{
   if (list == NULL)
      return;

   Node *p = list;
   if (list->data == x)
   {
      list = list->next;
      if (list != NULL)
         list->prev = NULL;
      delete p;
      return;
   }
   while (p->next != NULL && p->next->data != x)
      p = p->next;
   if (p->next == NULL)
      return;
   if (p->next->data == x)
   {
      Node *temp = p->next;
      if (temp->next != NULL)
      {
         temp->next->prev = p;
         p->next = temp->next;  
      }
      else
         p->next = NULL;
      delete temp;
   }
}

template<class ItemType>
void SortedList<ItemType>::Print()
{
   int i = 1;
   Node * p = list;
   while (p != NULL)
   {
      cout << "Node " << i << ": " << p->data << endl;
      p = p->next;
      i++;
   }
}