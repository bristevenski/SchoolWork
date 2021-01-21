/**
Runs a simulation in the console and accepts commands.
Handles all reading in and writing data calls commands from simulation
@author Andrew Iverson
*/
import java.util.Scanner;

public class ConsoleSimulation
{
   private Scanner stdin = new Scanner (System.in);
   private Simulation sim = new Simulation();
   
   /**
   Handles input of commands and calls the correct errors or methods to deal
   with the input.
   @throws Exception handles IO exception
   */
   public void run( ) throws Exception
   {
      String command = stdin.next();
      while ( !command.equals("Q") )
      {
         switch ( command )
         {
            case "A": addCustomer();
                      break;
            case "C": serviceCompleted();
                      break;
            case "T": updateTime();
                      break;
            case "P": print();
                      break;
            default:  badInput( command );
         }
         command = stdin.next();
      }
      System.out.println("\nQuit (Q) command given.");
      System.out.println("Statistics at end of the program are:");
      print();
      System.out.println("Normal Termination of Program 4!");
   }
   
   /**
   Adds calls arrive to add a customer to the queue.
   Out puts a message if added successfully or if it returned false
   prints out a message saying why
   */
   private void addCustomer()
   {
      if ( sim.arrive() )
      {
         System.out.println("A customer entered system at time " +
                            sim.curTime() + ". Number waiting in queue is " + 
                            sim.numWaiting() + ".");
      }
      else
      {
         System.out.println("Customer arrived but left immediately because" +
                            " the line was full (too long) at time " +
                            sim.curTime() + ".");
                 
      }
   }
   
   /**
   Handles serving a customer. 
   calls serviceCompleted and if it returns false it outputs the correct
   error message of why it returned false.
   */
   private void serviceCompleted( )
   {
      Customer custCompleted = sim.served();
      if (  custCompleted != null )
      {
         System.out.println("Customer " + custCompleted + 
                            " finished at time " + sim.curTime() +
                            ". Number waiting is " + sim.numWaiting() + ".");
      }
      else
      {
         System.out.println("No customer is being served at the " +
                            "present time of " + sim.curTime() + ".");
      }
   }
   
   /**
   Handles the command for updating current time.
   Calls updateTime from simulation. If it returns false it prints out an
   error message as why it was false.
   */
   private void updateTime( )
   {
       int updateAmount = stdin.nextInt();
       if ( sim.updateTime(updateAmount) )
       {
          System.out.print("Time updated by " + updateAmount);
          if( updateAmount == 1 )                   
            System.out.print(" time unit and time is now ");
          else
            System.out.print(" time units and time is now ");
          System.out.print( sim.curTime() + ".\n");
       }
       else
       {
          System.out.println("Time not updated with " + updateAmount + ".");
       }
   }
   
   /**
   Handles the command for printing out statistics.
   Calls avgWaitTime, sumOfWaitTime, numOfNowait, and numServed and prints
   out the results.
   */
   private void print()
   {
      System.out.println("\n" +
                         "The average wait time for customers who are " +
                         "finished waiting is " + sim.avgWaitTime() + ".\n" +
                         "The sum of the total wait time is " +
                         sim.sumOfWaitTime() + ".\n" +
                         "The number of people that did NOT have to wait is " 
                         + sim.numOfNoWait() + ".\n" +
                         "The number of people served is " +
                         sim.numServed() + "." + "\n");
   }
   
   /**
   Handles bad input.
   Shows users bad command and clears rest of the line
   @param command bad command that user entered
   */
   private void badInput( String command )
   {
      // we only care about the first char of the command
      command = command.substring( 0, 1); 
      System.out.println( command + " is not a valid command!");
      String temp = stdin.nextLine();
      temp = null; //helps the garbage collector
   }
}
