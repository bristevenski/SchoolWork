import java.util.Scanner;
/**
This class evaluates RPN expressions that involve addition, subtraction, 
and multiplication.
@author Brianna Muleski
*/
public class RpnEvaluator
{
   private final int MAX_EXP = 50;
   
   private int expressionNum = 1;
   private Stack expression = new Stack(MAX_EXP);
   private Queue intermediates = new Queue(MAX_EXP);
   private String outexp = "";
   private boolean valid = true;
   private Fraction leftOp, rightOp;
   private Scanner stdin;
   
   /**
   Reads and processes expressions until end-of-file. When end-of-file
   is reached, a normal termination message is displayed.
   */
   public void run()
   {
      stdin = new Scanner(System.in);

      while( stdin.hasNext() )
      {
         String input = stdin.next();
         computeExpression(input);
         printResults();
         expression.clear();
         intermediates.clear();
         outexp = "";
         expressionNum++;
         valid = true;
      }
      
      System.out.println("Normal Termination of Program 3.");
   }
   
   /**
   Computes the single expression. If the expression is not valid, it is
   marked as such, the rest of the expression is thrown, and computation
   stops.
   @param input the first token of the expression
   */
   private void computeExpression(String input)
   {
      if( input.equals("#"))
         valid = false;
      while( !input.equals("#") && valid )
      {
         if(input.startsWith("("))
         {
            String fraction = input.substring(1, input.length() - 1 );
            Fraction operand = new Fraction(fraction);
            expression.push(operand);
            input = operand.toString();
         }
         else if( input.equals("+") )
            add();
         else if( input.equals("*") )
            multiply();
         else if( input.equals("-") )
            subtract();
         else
         {
            valid = false;
            String temp = stdin.nextLine();
            temp = null;
         }
         outexp += input;
         if( valid )
            input = stdin.next();
      }
   }
   
   /**
   Gets the two operands from the top of the stack. If there are not 2 
   Fractions on the stack to process, the expression is marked as invalid,
   and the rest of the expression is thrown.
   */
   private void getOperands()
   {
      if( !expression.isEmpty() )
         rightOp = (Fraction) expression.pop();
      else
      {
         valid = false;
         String temp = stdin.nextLine();
         temp = null;
         return;
      }
      if( !expression.isEmpty() )   
         leftOp = (Fraction) expression.pop();
      else
      {
         valid = false;
         String temp = stdin.nextLine();
         temp = null;
      }
   }
   
   /**
   Adds the 2 Fractions if the expression is valid. 
   */
   private void add()
   {
      getOperands();
      if( valid )
      {
         Fraction sum = new Fraction(rightOp.add(leftOp));
         expression.push(sum);
         intermediates.add(sum);
      }
   }
   
   /**
   Multiplies the 2 Fractions if the expression is valid.
   */  
   private void multiply()
   {
      getOperands();
      if( valid )
      {
         Fraction product = new Fraction(rightOp.multiply(leftOp));
         expression.push(product);
         intermediates.add(product);
      }
   }
   
   /**
   Subtracts the 2 Fractions if the expression is valid.
   */   
   private void subtract()
   {
      getOperands();
      if( valid )
      {
         Fraction difference = new Fraction(leftOp.subtract(rightOp));
         expression.push(difference);
         intermediates.add(difference);
      }
   }
   
   

   /**
   Prints the results of a single expression. The expression, the result,
   and the intermediate results are displayed. If the expression is marked
   as invalid, an invalid message is displayed. If the stack is not empty,
   an invalid message is displayed.
   */
   private void printResults()
   {
      Fraction value = null;
      
      if(!expression.isEmpty())
         value = (Fraction) expression.pop();
      
      System.out.println("Expression " + expressionNum + " is: " + outexp);
      
      if( !expression.isEmpty() || valid == false )
         System.out.println("Invalid Expression");
      else
         System.out.println("The value is: " + value);
      
      System.out.print("Intermediate results: ");
      while( !intermediates.isEmpty() )
         System.out.print(intermediates.remove());
      System.out.println();
   }
}
