/**
This class represents a Stack. An object can be pushed to the stack and 
popped from the stack, the stack can be checked to see if it is empty or
not, and the stack can be cleared.
@author Andrew Iverson
@author Brianna Muleski
*/
public class Stack 
{
   private Node top = null;

   /**
   Checks if the stack is empty or not.
   @return true if the stack is empty, false otherwise
   */
   public boolean isEmpty()
   {
      return top == null;
   }

   /**
   Adds an Object to the Stack.
   @param x the Object being added
   */
   public void push( Object x )
   {
      top = new Node( x, top );
   }

   /**
   Removes the top of the stack.
   @return the Object being removed
   */
   public Object pop()
   {
      Object x = top.info;
      top = top.next;
      return x;
   }

   /**
   Clears the stack.
   */
   public void clear()
   {
      top = null;
   }

   /**
   Test bed main. Tests all the methods and constructor of the class.
   @param args is unused
   */
   public static void main( String args[ ] )
   {
      Stack s = new Stack();
      
      //Test for false isEmpty method 
      s.push(new Fraction() );
      s.push(new Fraction() );
      s.push(new Fraction() );
      if( s.isEmpty() )
         System.out.println("false isEmpty method test: failed");
      else
         System.out.println("false isEmpty method test: passed");
      
      //Test for true isEmpty method
      s.clear();
      if( s.isEmpty() )
         System.out.println("true isEmpty method test: passed");
      else
         System.out.println("true isEmpty method test: failed");
      
      //Test for push method
      s.push(new Fraction());
      if( s.isEmpty() )
         System.out.println("push method test: failed");
      else
         System.out.println("push method test: passed");
      
      //Test for pop method
      s.push(new Fraction(2, 5));
      s.push(new Fraction(1, 5));
      s.pop();
      s.pop();
      s.pop();
      if( s.isEmpty() )
         System.out.println("pop method test: passed");
      else
         System.out.println("pop method test: failed");
      
      //Test for clear method
      s.push(new Fraction() );
      s.push(new Fraction() );
      s.push(new Fraction() );
      s.push(new Fraction() );
      s.clear();
      if( s.isEmpty() )
         System.out.println("clear method test: passed");
      else
         System.out.println("clear method test: failed");
   }
}
