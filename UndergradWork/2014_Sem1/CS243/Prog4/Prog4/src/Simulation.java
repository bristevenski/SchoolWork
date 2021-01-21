/**
This class handles all the data and processing of the simulation
Has a queue of customers, keeps track of all data relating to the 
simulation and methods used to manipulate that data
@author Andrew Iverson
*/
public class Simulation
{
   private static final int MAX_LINE_LENGTH = 5;
   private Queue<Customer> q = new Queue(MAX_LINE_LENGTH);
   private int curTime = 0;               // current time
   private Customer curServed = null;     // current customer being served,
                                         // null if none being served
   private int peopleCompleted = 0;
   private int peopleNoWait = 0;
   private int peopleThatHadToWait = 0;
   private int sumOfWaitTime = 0;          
  
   /**
   Adds a customer to the queue if there is a customer being served.
   Else moves the customer to being served. If the line is too long the
   customer leaves
   @return returns true if the customer was added to the queue
   */
   public boolean arrive( )
   {
      Customer newCustomer = new Customer( curTime );
      if ( curServed == null )
      {
         curServed = newCustomer;
         peopleNoWait++;
         return true;
      }
      else if ( q.isFull( ) )
      {
         //customer leaves line too long
         return false;
      }
      else
      {
         q.add( newCustomer );
         return true;
      }
   }
   
   /**
   Completes a transaction with the current customer.
   Updates all the stats and removes customer moving onto the next in queue
   @return Customer returns the customer that was being served.
   */
   public Customer served( )
   {
      if( curServed == null ) //no one being served
         return null;
      
      Customer temp = curServed;
      if ( q.isEmpty() )
      {
         curServed = null;
      }
      else
      {
         curServed = q.remove();
         sumOfWaitTime += curTime - curServed.getArrivTime();
         peopleThatHadToWait++;
      }
      peopleCompleted++;
      return temp;
   }
   
   /**
   Handles updating the current time.
   Updates current time with deltaTime.
   @param deltaTime the amount to update current time with
   @return returns true if current time was updated. 
   */
   public boolean updateTime( int deltaTime )
   {
      boolean updated = false;
      if ( deltaTime > 0 )
      {
         curTime = curTime + deltaTime;
         updated = true;
      }
      return updated;
   }
   
   /**
   Handles returning number waiting in queue
   @return number of customers waiting in queue
   */
   public int numWaiting( )
   {
      return q.numItems();
   }
   
   /**
   Returns the current time in the simulation
   @return returns current time as int
   */
   public int curTime( )
   {
      return curTime;
   }
   
   /**
   Calculates the average wait time of customers that had to wait
   @return returns the average wait time of customers that had to wait
   */
   public double avgWaitTime( )
   {
      if( peopleThatHadToWait != 0 )
         return (double) sumOfWaitTime / peopleThatHadToWait; 
      else
         return 0;
   }
   
   /**
   Returns sum of the total wait time of customers in queue
   @return returns sum of the total wait time 
   */
   public int sumOfWaitTime( )
   {
      return sumOfWaitTime;
   }
   
   /**
   Returns number of customers that did not have to wait to get served
   @return the number of customers with no wait
   */
   public int numOfNoWait( )
   {
      return peopleNoWait;
   }
   
   /**
   Returns the number of customers served
   @return number of customers served
   */
   public int numServed( )
   {
      return peopleCompleted;
   }
   
   /**
   Returns the current customer being served
   @return current customer being served
   */
   public Customer curServed( )
   {
      return curServed;
   } 
   
   /**
   Testbed main. Has tests to test all constructors and methods.
   Outputs each test result.
   @param args[] unused.
   */
   public static void main ( String args[] ) 
   {
      Simulation test = new Simulation();
      Simulation test2 = new Simulation();
      Simulation test3 = new Simulation();
      if ( test.arrive( ) && test.peopleNoWait == 1  )
         System.out.println("Test Bed Main test: passed on arrive empty");
      else
         System.out.println("Test Bed Main test: failed on arrive empty");
      if( test.arrive() && test.numWaiting() == 1 )
         System.out.println("Test Bed Main test: passed on arrive, 1 wait");
      else
         System.out.println("Test Bed Main test: failed on arrive, 1 wait");
      test.arrive();
      test.arrive();
      test.arrive();
      test.arrive();
      if ( ! test.arrive( ) )
         System.out.println("Test Bed Main test: passed on arrive full");
      else
         System.out.println("Test Bed Main test: failed on arrive full");
      test.served();
      if ( test.peopleCompleted == 1 && test.peopleNoWait == 1 )
         System.out.println("Test Bed Main test: passed on served no wait");
      else
         System.out.println("Test Bed Main test: failed on served no wait");
      if ( test.updateTime( 1 ) && test.curTime == 1 )
         System.out.println("Test Bed Main test: passed on update time");
      else
         System.out.println("Test Bed Main test: failed on update time");
      test.served();
      if ( test.peopleCompleted == 2 && test.sumOfWaitTime == 1 )
         System.out.println("Test Bed Main test: passed on served wait");
      else
         System.out.println("Test Bed Main test: failed on served wait");
      test2.arrive();
      test2.arrive();
      test2.served();
      test2.served();
      if ( test2.numServed() == 2 )
         System.out.println("Test Bed Main test: passed on numServed");
      else
         System.out.println("Test Bed Main test: failed on numServed");
      if ( test2.numOfNoWait() == 1 )
         System.out.println("Test Bed Main test: passed on numOfNoWait");
      else
         System.out.println("Test Bed Main test: failed on numOfNoWait");
      if ( ! test2.updateTime(-1) )
         System.out.println("Test Bed Main test: passed on bad input updatetime");
      else
         System.out.println("Test Bed Main test: failed on bad "
                            + "input updatetime");
      test3.arrive();
      test3.arrive();
      test3.updateTime(1);
      test3.served();
      test3.arrive();
      test3.updateTime(1);
      test3.served();
      test3.served();
      if ( test3.avgWaitTime() == 1 )
         System.out.println("Test Bed Main test: passed on avgWaitTime");
      else
         System.out.println("Test Bed Main test: failed on avgWaitTime");
      if ( test3.sumOfWaitTime == 2 )
         System.out.println("Test Bed Main test: passed on sumWaitTime");
      else
         System.out.println("Test Bed Main test: failed on sumWaitTime");
      test3.updateTime(1);
      if ( test3.curTime() == 3 )
         System.out.println("Test Bed Main test: passed on curTime");
      else
         System.out.println("Test Bed Main test: failed on curTime");
      test3.arrive();
      test3.arrive();
      if ( test3.numWaiting() == 1 )
         System.out.println("Test Bed Main test: passed on numWaiting");
      else
         System.out.println("Test Bed Main test: failed on numWaiting");
   }
}
