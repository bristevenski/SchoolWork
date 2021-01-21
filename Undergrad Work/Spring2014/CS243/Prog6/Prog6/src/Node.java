/**
This class represents a Node.
@author  Brianna Muleski
*/
public class Node 
{
   public Object info;
   public Node next;
   
   /**
   Constructor. Creates a new Node with the info being the Object passed
   and next pointing to the Node passed.
   @param x the Object passed as info
   @param n the Node passed as next
   */
   public Node( Object x, Node n )
   {
      info = x;
      next = n;
   }
}
