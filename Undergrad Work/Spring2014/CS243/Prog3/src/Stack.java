/**
This class represents a stack that contains the operands of the
expression. When the expression is completely processed, the result
is what is left in the stack.
@author Brianna Muleski
*/
public class Stack
{
   private Object[] elements;
   private int top;
   
   /**
   Constructor that initializes the stack and sets the top to zero.
   @param size the size of the stack
   */
   public Stack( int size )
   {
      elements = new Object[size];
      top = 0;
   }
   
   /**
   Checks if the stack is empty or not.
   @return true if empty, false otherwise
   */
   public boolean isEmpty()
   {
      return top == 0;
   }
   
   /**
   Checks if the stack is full or not.
   @return true if full, false otherwise
   */
   public boolean isFull()
   {
      return top == elements.length;
   }
   
   /**
   Adds an Object to the stack and increases top.
   @param x the Object being added
   */
   public void push( Object x )
   {
      elements[top++] = x;
   }
   
   /**
   Removes the last Object added.
   @return the top Object of the stack
   */
   public Object pop()
   {
      return elements[--top];
   }
   
   /**
   Clears the stack and resets top to zero.
   */
   public void clear()
   {
      for(int i = 0; i < elements.length; i++)
         elements[i] = null;
      top = 0;
   }
   
   /**
   Testbed main. Tests all the constructors and methods in this class.
   @param args is not used
   */
   public static void main ( String args[] ) 
   {
      //Test for contructor
      Stack s = new Stack(5);
      System.out.println("Test for constructor:");
      System.out.println("Expected: ");
      System.out.println("null null null null null");
      System.out.println("Result: ");
      for (int i = 0; i < s.elements.length; i++)
         System.out.print(s.elements[i] + " ");
      System.out.println();
      System.out.println();
      
      //Test for isEmpty method
      System.out.println("Test for isEmpty method:");
      if (s.isEmpty())
         System.out.println("isEmpty test passed.");
      else
         System.out.println("isEmpty test failed.");
      System.out.println();
      
      //Test for isFull method
      System.out.println("Test for isFull method:");
      if (s.isFull())
         System.out.println("isFull test failed.");
      else
         System.out.println("isFull test passed.");
      System.out.println();
      
      //Test for push method
      s.push(new Fraction("3/4"));
      s.push(new Fraction("1/2"));
      System.out.println("Test for push method:");
      System.out.println("Expected:");
      System.out.println("(0/1) (1/2)");
      System.out.println("Result:");
      for( int i = 0; i < s.top; i++ )
         System.out.print(s.elements[i] + " ");
      System.out.println();
      System.out.println();
       
      //Test for pop method
      System.out.println("Test for pop method:");
      System.out.println("Expected:");
      System.out.println("(1/2)");
      System.out.println("Result:");
      System.out.println(s.pop());
      System.out.println();
      
      //Test for clear method
      s.push(new Fraction("3/4"));
      s.push(new Fraction("5/8"));
      s.clear();
      System.out.println("Test for clear method:");
      System.out.println("Expected:");
      System.out.println("null null null null null");
      System.out.println("top = 0");
      System.out.println("Result:");
      for( int i = 0; i < s.elements.length; i++ )
         System.out.print(s.elements[i] + " ");
      System.out.println();
      System.out.println("top = " + s.top);
      System.out.println();
      
      
   }
}

