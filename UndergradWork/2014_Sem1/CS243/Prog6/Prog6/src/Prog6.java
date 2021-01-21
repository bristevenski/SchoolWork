/**
Runs the main for Program 6
@author Andrew Iverson
@author Brianna Muleski
*/
public class Prog6
{
   /**
   Runs RpnEvaluator or the GUI frame depending on the arguments. Runs the
   GUI frame if 1 argument is provided and runs the RpnEvaluator method "run"
   if no argument is provided. If an error is found, an error message is 
   printed.
   @param args  is unused
   */
   public static void main (String args[])
   {
      try
      {
         if( args.length == 0 )
         {
            RpnEvaluator rpne = new RpnEvaluator();
            rpne.run();
         }
         else if( args.length == 1 )
         {
            Prog6Frame frame = new Prog6Frame();
            frame.setVisible(true);
         }
      }
      catch (Exception e)
      {
         System.out.println("Program Error!");
      }
   }
}
