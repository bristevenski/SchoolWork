/**
This class represents a Customer, with their customer number and their 
arrival time.
@author  Brianna Muleski
*/
public class Customer 
{
   private static int customerCount = 0;
   private int customerNumber;
   private int arrivalTime;
   
   /**
   Constructor that sets the customer number to 1 more than the customer
   count, increments the customer count, and sets the arrival time to the 
   time sent as a parameter.
   @param arrivTime Arrival time of the customer as an int
   */
   public Customer( int arrivTime )
   {
      customerNumber = ++customerCount;
      arrivalTime = arrivTime;
   }
   
   /**
   Returns the arrival time of the customer
   @return Arrival time of the customer as an int
   */
   public int getArrivTime()
   {
      return arrivalTime;
   }
   
   /**
   Converts the information of the customer to a String in the specified
   format.
   @return the customer information as a String
   */
   public String toString()
   {
      return "C" + customerNumber + "/T" + arrivalTime;
   }   
}