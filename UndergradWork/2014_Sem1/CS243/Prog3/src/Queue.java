/**
This class represents a queue that contains the intermediate results of
the expression. 
@author Brianna Muleski
*/
public class Queue
{
   private Object [] elements;
   private int front, rear, count;
   
   /**
   Constructor that initializes the queue and the front, rear, and count
   to zero.
   @param size the size of the Queue
   */
   public Queue ( int size )
   {
      elements = new Object[size];
      front = rear = count = 0;
   }
   
   /**
   Checks if the queue is empty or not.
   @return true if empty, false otherwise
   */
   public boolean isEmpty()
   {
      return count == 0;
   }
   
   /**
   Checks if the queue is full or not.
   @return true if full, false otherwise
   */
   public boolean isFull()
   {
      return count == elements.length;
   }
   
   /**
   Adds an Object to the queue to the rear and resets rear and count  
   @param x the Object being added
   */
   public void add ( Object x )
   {
      elements[rear] = x;
      rear = (rear + 1) % elements.length;
      ++count;
   } 
   
   /**
   Returns the Object in the front position and resets front and count 
   @return the Object from the front of the queue 
   */
   public Object remove()
   {
      Object x = elements[front];
      front = (front + 1) % elements.length;
      --count;
      return x;
   }
   
   /**
   Clears the queue and resets the count, front, and rear.
   */
   public void clear()
   {
      for(int i = 0; i < elements.length; i++)
         elements[i] = null;
      count = front = rear = 0;
   }
   
   /**
   Testbed main. Tests all the constructors and methods in this class.
   @param args is not used
   */
   public static void main ( String args[] ) 
   {
      //Test for contructor
      Queue q = new Queue(5);
      System.out.println("Test for constructor:");
      System.out.println("Expected: ");
      System.out.println("null null null null null");
      System.out.println("Result: ");
      for (int i = 0; i < q.elements.length; i++)
         System.out.print(q.elements[i] + " ");
      System.out.println();
      System.out.println();
      
      //Test for isEmpty method
      System.out.println("Test for isEmpty method:");
      if (q.isEmpty())
         System.out.println("isEmpty test passed.");
      else
         System.out.println("isEmpty test failed.");
      System.out.println();
      
      //Test for isFull method
      System.out.println("Test for isFull method:");
      if (q.isFull())
         System.out.println("isFull test failed.");
      else
         System.out.println("isFull test passed.");
      System.out.println();
      
      //Test for add method
      Fraction f1 = new Fraction("4/8");
      q.add(f1);
      Fraction f2 = new Fraction("1/4");
      q.add(f2);
      Fraction f3 = new Fraction("3/7");
      q.add(f3);
      System.out.println("Test for add method:");
      System.out.println("Expected:");
      System.out.println("(1/2) (1/4) (3/7)");
      System.out.println("Result:");
      for (int i = 0; i < q.count; i++)
         System.out.print(q.elements[i] + " ");
      System.out.println();
      System.out.println();
      
      //Test for remove method
      System.out.println("Test for remove method:");
      System.out.println("Expected:");
      System.out.println("Removed fraction: (0/1)");
      System.out.println("Result:");
      System.out.println("Removed fraction: " + q.remove());
      System.out.println();
      
      //Test for clear method
      q.add(new Fraction("1/2"));
      q.add(new Fraction("1/3"));
      q.add(new Fraction("3/4"));
      q.clear();
      System.out.println("Test for clear method:");
      System.out.println("Expected:");
      System.out.println("null null null null null");
      System.out.println("count = 0");
      System.out.println("front = 0");
      System.out.println("rear = 0");
      System.out.println("Results:");
      for(int i = 0; i < q.elements.length; i++)
         System.out.print(q.elements[i] + " ");
      System.out.println();
      System.out.println("count = " + q.count);
      System.out.println("front = " + q.front);
      System.out.println("rear = " + q.rear);
   }
}
