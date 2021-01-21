#include "SortedList.h"

#include <iostream>
using namespace std;

void main()
{
   SortedList<char> list;
   char ch;
   cin.get(ch);
   while (ch != '\n')
   {
      list.Insert(ch);
      cin.get(ch);
   }
   list.Print();
   while (cin)
   {
      cout << "Which one do you want to delete?" << endl;
      cin.get(ch);
      cin.ignore(100, '\n');
      list.Delete(ch);
   }
   list.Print();

   SortedList<float> list2;
   list2.Insert(3.14);
   list2.Delete(2.17);
   list2.Print();
}


