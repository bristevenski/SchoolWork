import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
Tests all the public methods in the Queue class.
@author Brianna Muleski
*/
public class QueueTest {
   
   public QueueTest() {
   }
   
   @BeforeClass
   public static void setUpClass() {
   }
   
   @AfterClass
   public static void tearDownClass() {
   }
   
   @Before
   public void setUp() {
   }
   
   @After
   public void tearDown() {
   }
   
   /**
   Test of isFull method, of class Queue.
   */
   @Test
   public void testIsFull() 
   {
      System.out.println("isFull");
      Queue<String> q = new Queue(10); 
      //Test for full queue
      for( int i = 0; i < 10; i++ )
      {
         assertFalse( q.isFull() );
         q.add ( "Item: " + i );
      }      
      assertTrue( q.isFull() );
      for( int i = 0; i < 10; i++ )
      {
         assertFalse( q.isEmpty() );
         assertEquals("Item: " + i, q.remove() );
      }
      assertTrue( q.isEmpty() );
      //Test for not full queue
      for( int i = 0; i < 5; i++ )
      {
         assertFalse( q.isFull() );
         q.add( "Item: " + i );
      }
      assertTrue( !q.isFull() );
      for( int i = 0; i < 5; i++ )
      {
         assertFalse( q.isEmpty() );
         assertEquals("Item: " + i, q.remove() );  
      }
      assertTrue( q.isEmpty() );
   }

   /**
   Test of isEmpty method, of class Queue.
   */
   @Test
   public void testIsEmpty() 
   {
       System.out.println("isEmpty");
       Queue<String> q = new Queue(5);
       //Test for empty queue
       for(int i = 0; i < 5; i++ )
       {
          assertFalse( q.isFull() );
          q.add( "Item: " + i);
       }
       for(int i = 0; i < 5; i++ )
       {
          assertFalse( q.isEmpty() );
          assertEquals ("Item: " + i, q.remove() );
       }
       assertTrue( q.isEmpty() );
       //Test for not empty queue
       for( int i = 0; i < 5; i++ )
       {
          assertFalse( q.isFull() ); 
          q.add( "Item: " + i);
       }
       for( int i = 0; i < 3; i++ )
       {
          assertFalse( q.isEmpty() );
          assertEquals( "Item: " + i, q.remove() );
       }
       assertTrue( !q.isEmpty() ); 
   }
   
   /**
   Test of add method, of class Queue.
   */
   @Test
   public void testAdd() 
   {
      System.out.println("add");
      Queue<String> q = new Queue(5);
      for( int i = 0; i < 5; i++ )
      {
         q.add("Item: " + i);
         assertEquals( "Item: " + i, q.remove() ); 
      }
   }

   /**
   Test of remove method, of class Queue.
   */
   @Test
   public void testRemove() 
   {
      System.out.println("remove");
      Queue<String> q = new Queue(5);
      for( int i = 0; i < 5; i++ )
      {
         q.add("Item: " + i);
         assertEquals( "Item: " + i, q.remove() );
      }
      assertTrue( q.isEmpty() );
   }

   /**
   Test of numItems method, of class Queue.
   */
   @Test
   public void testnumItems() 
   {
      System.out.println("getCount");
      Queue<String> q = new Queue(5);
      //Test for count when queue is full
      for( int i = 0; i < 5; i++ )
         q.add("Item: " + i);
      assertEquals( q.numItems(), 5);
      for( int i = 0; i < 5; i++ )
         q.remove();
      assertEquals( q.numItems(), 0);
      //Test for count when queue is not full
      for( int i = 0; i < 3; i++ )
         q.add("Item: " + i);
      assertEquals( q.numItems(), 3);
      for( int i = 0; i < 3; i++ )
         q.remove();
      assertEquals(q.numItems(), 0);
   }
}