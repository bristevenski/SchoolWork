/**
Runs the main for Program 4
@author Andrew Iverson
*/
public class Prog4
{
   /**
   calls console simulation run method.
   Prints out any exceptions
   @param args  is unused
   */
   public static void main (String args[])
   {
      try
      {
         ConsoleSimulation conSim = new ConsoleSimulation();
         conSim.run();
      }
      catch (Exception e)
      {
         System.out.println("Program Error!");
      }
   }
}