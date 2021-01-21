#include "Lab9.h"
#include <iostream>
using namespace std;

// Do 1: finish the Insert function
void BSTree::Insert ( TreeNode * & t, InfoType x )
{
   if( t == NULL )
      t = new TreeNode( x );
   else if( x > t->info )
      Insert( t->left, x);
   else if( x < t->info )
      Insert( t->right, x );
}

// Do 2: finish the Clean function used for the desctructor
void BSTree::Clean( TreeNode * t )
{
	if( t != NULL )
   {
      Clean( t->left );
      Clean( t->right );
      delete t;
   }
}

// Do 3: finish the depth function
int BSTree::Depth ( const TreeNode * t ) const
{  
   if( t == NULL )
      return 0;
   else 
   {
      int lDepth = Depth( t->left );
      int rDepth = Depth( t->right );
      if( lDepth > rDepth )
         return lDepth + 1;
      else
         return rDepth + 1;
   }
}

// Do 4: finish the RevOrderPrint function to 
// recursively print the tree in non-ascending order
void BSTree::RevOrderPrint( const TreeNode * t ) const
{
   if( t != NULL )
   {
      RevOrderPrint( t->left );
      cout << t->info << endl;
      RevOrderPrint( t->right );
   }
}

// Do 5: finish the LevelPrint function to print the tree
// in a top-down manner
// hint: you may use a queue to do that
void BSTree::LevelPrint() const
{
   // If the tree is empty, what to do?
   if( tree == NULL )
      return;  
   
   queue<TreeNode * > q;
   q.push ( tree );
   while ( ! q.empty() )
   {
      TreeNode * cur = q.front();
      q.pop();
      cout << cur->info << endl;
      if( cur->right != NULL )
         q.push(cur->right);
      if( cur->left != NULL )
         q.push(cur->left);
   }
}

//-----test main ---------
void main()
{
	BSTree bst;
	InfoType x;
	cin >> x;
	while ( cin )
	{
		bst.Insert( x );
		cin >> x;
	}
	cout << "The depth of the tree is " << bst.Depth() << endl;
	cout << "Print in reverse order: " << endl;
	bst.RevOrderPrint();
	cout << "Print in level order: " << endl;
	bst.LevelPrint();
}
