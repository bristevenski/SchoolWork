/**
This class represents a queue 
@author Brianna Muleski
*/
public class Queue<E>
{
   private E[] elements;
   private int front, rear, count;
   
   /**
   Constructor that initializes the queue and the front, rear, and count
   to zero.
   @param size the size of the Queue
   */
   public Queue ( int size )
   {
      elements = (E[]) new Object[size];
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
   Adds x to the rear of the queue and resets rear and count  
   @param x the item added to the queue
   */
   public void add ( E x )
   {
      elements[rear] = x;
      rear = (rear + 1) % elements.length;
      ++count;
   } 
   
   /**
   Returns the front item and resets front and count 
   @return the item from the front of the queue 
   */
   public E remove()
   {
      E x = elements[front];
      front = (front + 1) % elements.length;
      --count;
      return x;
   }
   
   /**
   Returns the count
   @return count as an int
   */
   public int numItems()
   {
      return count;
   }
}
   
