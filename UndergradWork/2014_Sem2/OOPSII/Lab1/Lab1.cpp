#include <iostream>
using namespace std;

const int MAX = 200;

void main()
{
   while (!cin.eof() && !cin.bad())
   {
      char ch;
      int answer = 0, count = 0, sum = 0, nums[MAX];
      float ave = 0;      
      cin >> ch;

      while (ch <= '9' && ch >= '0' || ch == '-')
      {
         cin.putback(ch);
         int num;
         cin >> num;
         nums[count++] = num;
         sum += num;

         cin >> ch;
      } 

      ave = float(sum) / count;

      for (int i = 0; i < count; i++)
      {
         if (nums[i] < ave)
            answer++;
      }   

      cout << answer << endl;
   }

}