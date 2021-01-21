#include <string>
#include <iostream>
using namespace std;

void Perm(string fixedPart, string permPart)
{
   if (permPart.length() == 1)
      cout << fixedPart + permPart << endl;
   else
   {
      for (int i = 0; i < permPart.length(); i++)
         Perm(fixedPart + permPart[i], permPart.substr(0, i) + permPart.substr(i + 1));
   }
}


void main()
{
   string s;

   cout << "Enter a String: ";
   cin >> s;
   cout << s << endl;

   cout << "Perms are: " << endl;
   Perm("", s);
}

