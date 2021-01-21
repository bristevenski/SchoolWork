import java.util.Scanner;

/**
This class Takes in commands to manipulate a list of fractions.
The user can input 6 different commands: Add, Delete, Multiply, Sum,
Product, and Quit. 
@author Brianna Muleski
*/
public class FractionManipulator
{
   ListOfFraction list = new ListOfFraction();
   Scanner stdin;
   
   private String command;
   
   /**
   Takes in commands from the input and performs the said command.
   When the Quit command is inputted, the normal termination message
   is printed.
   */
   public void run()
   {
      stdin = new Scanner(System.in);
      
      
      command = stdin.next();
      
      while( !command.equals("Q") )
      {
         if ( command.equalsIgnoreCase("A") )
            addCommand();
         else if ( command.equalsIgnoreCase("D") )
            deleteCommand();
         else if ( command.equalsIgnoreCase("M") )
            multiplyCommand();
         else if ( command.equalsIgnoreCase("P") )
            printCommand();
         else if ( command.equalsIgnoreCase("S") )
            sumCommand();
         else
            badCommand();
         command = stdin.next();
      }
      System.out.println( "Normal Termination of Program 2!" );
 
   }
   
   /**
   Adds the fraction from the input to the list. Prints a success 
   message.
   */
   private void addCommand()
   {
      
      Fraction f = new Fraction( stdin.next() );
      list.add(f);
      System.out.println(f.toString() + " was added to the list.");
   }
   
   /**
   Deletes the fraction from the input from the list, if it exists. A 
   success message is printed. If it does not exist then a failure 
   message is printed.
   */
   private void deleteCommand()
   {
      Fraction f = new Fraction (stdin.next());
      boolean successful = list.delete(f);
      if (successful)
         System.out.println( f + " was removed from the list." );
      else
         System.out.println( f + " is not in the list." );
      
   }
   
   /**
   Multiplies the contents of the list together. The labeled product
   is printed.
   */
   private void multiplyCommand()
   {
      Fraction product = new Fraction (list.product());
      System.out.println("The product of the list is: " 
                         + product.toString());
   }
   
   /**
   Prints the list of the fractions with a heading.
   */
   private void printCommand()
   {
      int numPerLine = stdin.nextInt();
      System.out.println("The numbers in the list are:");
      list.print(numPerLine);
   }
   
   /**
   Adds the contents of the list together. The labeled sum is printed.
   */
   private void sumCommand()
   {
      Fraction sum = new Fraction (list.sum());
      System.out.println("The sum of the list is: " + sum.toString());
   }
   
   /**
   Prints an invalid command message and ignores the rest of the line.
   */
   private void badCommand()
   {
      System.out.println(command + " is not a valid command!");
      String temp = stdin.nextLine();
      temp = null;
   }
}
