import java.util.Scanner;
import java.util.StringTokenizer;

/**
This class handles the reading in and handling of RPN fractions
Takes input as fraction1, fraction2, operator
Adds the fractions to a stack, removes 2 fractions from the stack when an
operator is found. Adds the result back to the stack and also to a queue of 
intermediate fractions.
@author Andrew Iverson
@author Brianna Muleski
*/
public class RpnEvaluator
{
   Scanner stdin;
   int countOfExpressions = 1;
   Stack stackOfFractions = new Stack();
   Queue queueOfFractions = new Queue();
   
   private StringTokenizer myStringTok;
   private Fraction answer;
   private boolean valid;
   private boolean done;
   
   /**
   Empty constructor.
   */
   public RpnEvaluator( )
   {
   }
   
   /**
   This constructor initializes myStringTok with a string
   @param tok used to initialize the tokenizer
   */
   public RpnEvaluator( String tok )
   {
      myStringTok = new StringTokenizer(tok);
      valid = true;
   }
   
   /**
   Handles reading in of fraction equations by calling readIn.
   Prints out a normal termination line.
   */
   public void run ( )
   {
      stdin = new Scanner(System.in);
      while ( stdin.hasNext() )
      {         
         readIn();
      }
      done = true;
      System.out.println("Normal Termination of Program 3.");
   }
   
   /**
   Handles reading in all operators and operands.
   It also calls the correct method to deal with all operators.
   It adds operands to a stack. Prints out the formated output.
   */
   private void readIn( )
   {
      System.out.print( "Expression " + countOfExpressions + " is: " );
      String nextString = stdin.next();
      boolean badInput = false; //used to handle errors correctly
      while ( !nextString.startsWith("#") && badInput == false )
      {
         badInput = readHelper(nextString, badInput);
         nextString = stdin.next();        
      }
      output( badInput, nextString );
      intermediate();
      countOfExpressions++;
      stackOfFractions.clear();
      queueOfFractions.clear();
   }
   
   /**
   Handles processing the token. Keeps track of the validity of the 
   expression.
   @param nextString the token being processed.
   @param badInput the validity flag
   @return true if the input is invalid, false otherwise
   */
   private boolean readHelper(String nextString, boolean badInput )
   {
      if ( nextString.startsWith("(") )
      {
         Fraction fractionToAdd = new Fraction(nextString);
         stackOfFractions.push(fractionToAdd);
         System.out.print(fractionToAdd);
      }
      else if ( nextString.startsWith("+") || nextString.startsWith("-") ||
                nextString.startsWith("*") )
      {
         System.out.print(nextString);
         if ( !handleFractions( nextString ))
            badInput = true;
      }
      else if ( nextString.startsWith("#") )
      {
         output( badInput, nextString );
         intermediate();
      }
      else
      {
         System.out.print(nextString);
         badInput = true;
      }
      return badInput;
   }
   
   /**
   Pops off two fractions from the stack and does the
   correct operation to them.  Pushes the result of the
   operation to the stack and adds it to the queue
   @return Returns true if the operation was successful 
   */
   private boolean handleFractions( String operation )
   {
      boolean successful = false;
      if ( !stackOfFractions.isEmpty())
      {
         Fraction f1 = new Fraction((Fraction) stackOfFractions.pop());
         if ( !stackOfFractions.isEmpty() )
         {
            Fraction f2 = (Fraction) stackOfFractions.pop();
            f2 = handleOperations( operation, f1,
                                          f2);
            queueOfFractions.add( f2 );
            stackOfFractions.push( f2 );
            successful = true;
         }
      }
      return successful;
   }
   
   /**
   This method handles the correct operation that is needed to
   do to the fractions.
   @param operation String that has the operation to do
   @param fraction1 first fraction for operation
   @param fraction2 second fraction for operation
   @return Fraction the result of the operation of the two fractions
   */
   private Fraction handleOperations( String operation, Fraction fraction1, 
                                  Fraction fraction2)
   {
      switch ( operation )
      {
         case "+":
            fraction2 = fraction2.plus(fraction1);
            break;
         case "-":
            fraction2 = fraction2.minus(fraction1);
            break;
         case "*":
            fraction2 = fraction2.times(fraction1);
            break;
      }
      return fraction2;
   }   
   
   /**
   This method outputs the result of the RPN equation
   Prints out invalid if there was a mismatch, or bad input
   @param mismatch Determines if the stack had a mismatch, triggers invalid
   @param lastString Passed to clearInput for handling errors
   */
   private void output( boolean mismatch, String lastString )
   {
      clearInput( mismatch, lastString );
      System.out.println("");
      if ( !stackOfFractions.isEmpty() && mismatch == false )
      {
         Fraction temp = new Fraction ( (Fraction) stackOfFractions.pop() );
         if ( stackOfFractions.isEmpty() )
         {
            System.out.println( "The value is: " + temp );
         }
         else
         {
            System.out.println("Invalid Expression");
         }
      }
      else
      {
         System.out.println("Invalid Expression");
      }
   }
   
   /**
   This method prints off the queue of intermediate results from operations
   applied to fractions in the stack.
   */
   private void intermediate( )
   {
      String temp = new String();
      while ( !queueOfFractions.isEmpty() )
      {
         temp = temp + queueOfFractions.remove();
      }
      System.out.println("Intermediate results: " + temp);      
   }
   
   /**
   This method clears out any remaining input from an invalid expression.
   Clears until encounters another #
   @param mismatch Bad input was entered somewhere need to clear input
   @param lastString used to determine if bad input was encountered at the #
   */
   private void clearInput( boolean mismatch, String lastString )
   {
      if ( mismatch && !lastString.startsWith("#") )
      {
         String nextString = stdin.next();
         while ( !nextString.startsWith("#") )
            nextString = stdin.next();   
      }
   }
   
   /**
   This method returns the queue of intermediate results
   @return Queue A queue of intermediate results
   */
   public Queue getQueue()
   {

      return queueOfFractions;
   }
   
   /**
   This method returns the current stack of fractions
   @return Stack A stack of fractions
   */
   public Stack getStack( )
   {
      return stackOfFractions;
   }
   
   /**
   This method returns if the RPN Expression is valid
   @return boolean true if done
   */
   public boolean getValid( )
   {
      return valid;
   }
   
   /**
   This method returns true or false if RpnEvalutor is done
   processing.
   @return boolean True if done
   */
   public boolean getDone( )
   {
      return done;
   }
   /**
   This method returns the Answer to the RPN expression
   @return Fraction the Answer to the RPN expression
   */
   public Fraction getAnswer( )
   {
      return answer;
   }
   
   /**
   Processes one token. Keeps track of the validity of the expression.
   @param tok the token being processed
   */
   public void ProcessToken ( String tok )
   {
      if (tok.startsWith("("))
      {
         Fraction fractionToAdd = new Fraction(tok);
         stackOfFractions.push(fractionToAdd);
         answer = fractionToAdd;
      }
      else if (tok.startsWith("+") || tok.startsWith("-") 
               || tok.startsWith("*"))
      {
         if (!handleFractions(tok))
            valid = false;           
      }
      else if ( tok.startsWith("#") && answer == null )
         valid = false;
      else if ( tok.startsWith("#") )
      {
         if( !stackOfFractions.isEmpty() )
            valid = false;
      }
      else
         valid = false;
   }
   
   /**
   Checks if there is still a token to be processed. If not then the
   expression is checked for validity  before flagging it as done. 
   Stores the answer.
   */
   public void ProcessToken ( )
   {
      
      if (myStringTok.hasMoreTokens())
      {
         String nextString = myStringTok.nextToken(" ");
         if ( nextString.equals("#") )
         {
            if( !stackOfFractions.isEmpty() && answer != null )
               answer = (Fraction) stackOfFractions.pop();            
            if( !stackOfFractions.isEmpty() )
               valid = false;
            else
            {
               if( answer == null )
                  valid = false;
               else
                  done = true;
            }
         }
         else
            ProcessToken(nextString);
      }
      else
         done = true;
   }
}
