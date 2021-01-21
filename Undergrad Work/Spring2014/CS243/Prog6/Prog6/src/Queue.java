/**
This class represents a Queue. An object can be added or removed from the 
queue, the queue can be checked to see if it's empty, and the queue can be
cleared.
@author Andrew Iverson
@author Brianna Muleski
*/
public class Queue 
{
   private Node front = null, rear = null;
    
   /**
   Tests if the queue is empty or not.
   @return true if the queue is empty, false otherwise
   */
   public boolean isEmpty()
   {
      return front == null;
   }
    
   /**
   Adds an Object to the back of the queue.
   @param x the Object being added
   */
   public void add( Object x )
   {
      if( front == null )
      {
         front = new Node( x, null );
         rear = front;
      }
      else
      {
         rear.next = new Node( x, null );
         rear = rear.next;
      }
   }
   
   /**
   Removes the Object at the front of the queue.
   @return the Object that was removed
   */
   public Object remove()
   {
      if( front == null )
         return null;
      Object x = front.info;
      front = front.next;
      if( front == null )
         rear = null;
      return x;
   }
   
   /**
   Clears the queue.
   */
   public void clear()
   {
      rear = null;
      front = null;
   }
   
   /**
   Test bed main. Tests all the methods and constructor of the class.
   @param args is unused
   */
   public static void main( String args[] )
   {
      Queue q = new Queue();
      
      //Test for false isEmpty method 
      q.add(new Fraction() );
      q.add(new Fraction() );
      q.add(new Fraction() );
      if( q.isEmpty() )
         System.out.println("false isEmpty method test: failed");
      else
         System.out.println("false isEmpty method test: passed");
      
      //Test for true isEmpty method
      q.clear();
      if( q.isEmpty() )
         System.out.println("true isEmpty method test: passed");
      else
         System.out.println("true isEmpty method test: failed");
      
      //Test for add method
      q.add(new Fraction());
      if( q.isEmpty() )
         System.out.println("add method test: failed");
      else
         System.out.println("add method test: passed");
      
      //Test for remove method
      q.add(new Fraction(2, 5));
      q.add(new Fraction(1, 5));
      q.remove();
      q.remove();
      q.remove();
      if( q.isEmpty() )
         System.out.println("remove method test: passed");
      else
         System.out.println("remove method test: failed");
      
      //Test for clear method
      q.add(new Fraction() );
      q.add(new Fraction() );
      q.add(new Fraction() );
      q.add(new Fraction() );
      q.clear();
      if( q.isEmpty() )
         System.out.println("clear method test: passed");
      else
         System.out.println("clear method test: failed");
   }
}
