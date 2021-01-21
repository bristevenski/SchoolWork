//---------------------------------------------------------------
// name: Brianna Muleski
// section: 01
//
// This program is used to calculate the income for an employee
// based on their monthly sales
//
//---------------------------------------------------------------

# include <iostream>
using namespace std;

void main ()
{
   //float monthlysales, income;
  
   //cout << "Enter monthly sales: ";
   //cin >> monthlysales;

   //if (monthlysales >= 50000)
   //   income = 375 + .16 * monthlysales;
   //else if (monthlysales < 50000 && monthlysales >= 40000)
   //   income = 350 + .14 * monthlysales;
   //else if (monthlysales < 40000 && monthlysales >= 30000)
   //   income = 325 + .12 * monthlysales;
   //else if (monthlysales < 30000 && monthlysales >= 20000)
   //   income = 300 + .09 * monthlysales;
   //else if (monthlysales < 20000 && monthlysales >= 10000)
   //   income = 250 + .05 * monthlysales;
   //else if (monthlysales < 10000)
   //   income = 200 + .03 * monthlysales;

   //if (monthlysales > 0)
   //   cout << "The income is $" << income;
   //else
   //   cout << "Sales amount cannot be 0 or negative!!";

	int divcount = 0, opencount = 0, lockers;

	cout << "Insert number of lockers: ";
	cin >> lockers;

	for( int i = lockers; i > 0; i--)
	{
		for( int j = i; j > 0; j--)
		{
			if( i % j == 0)
				divcount++;
		}
		if(divcount % 2 != 0)
			opencount++;
		divcount = 0;
	}

	cout << opencount;
	cout << endl;
}     
