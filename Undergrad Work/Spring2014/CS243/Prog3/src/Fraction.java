import java.util.StringTokenizer;

/**
This class represents a fraction and the methods used to manipulate
the fraction.
The fraction can be made with 3 different constructors (described 
below). The fraction can also be added, multiplied, and subtracted from
another fraction. The fraction can be changed into a String, reduced,
and compared to another fraction to check equality.
@author Brianna Muleski 
*/
public class Fraction
{
   private int numerator;
   private int denominator;
   
   /**
   Default constructor that sets the numerator equal to 0 and the 
   denominator equal to 1.
   */
   public Fraction()
   {
      numerator = 0;
      denominator = 1;
   }
   
   /**
   Copy constructor.
   @param f fraction to be copied
   */
   public Fraction ( Fraction f )
   {
      numerator = f.numerator;
      denominator = f.denominator;
   }
   
   /**
   Constructor that converts a string to a reduced fraction.
   @param fractionString the fraction in String format
   */
   public Fraction ( String fractionString )
   {
      StringTokenizer st = new StringTokenizer (fractionString, "/");
      numerator = Integer.parseInt(st.nextToken());
      denominator = Integer.parseInt(st.nextToken());
      if (denominator < 0)
      {
         if (numerator < 0)
         {
            denominator = Math.abs(denominator);
            numerator = Math.abs(numerator);
         }
         else
         {
            denominator = Math.abs(denominator);
            numerator = 0 - numerator;
         }
      }
      reduce();
   }
   
   /**
   Converts the fraction to a String.
   @return the fraction as a String
   */
   @Override
   public String toString()
   {
      return "(" + numerator + "/" + denominator + ")";
   }
   
   /**
   Reduces the fraction.
   */
   private void reduce()
   {
      int highest;
      int lowest;
      
      if (Math.abs(numerator) > Math.abs(denominator))
      {
         highest = numerator;
         lowest = denominator;
      }
      else
      {
         highest = denominator;
         lowest = numerator;
      }
         
      while (lowest != 0)
      {
         int temp = lowest;
         lowest = highest % lowest;
         highest = temp;
      }
      
      numerator /= highest;
      denominator /= highest;
      
      if (denominator < 0)
      {
         numerator *= -1;
         denominator *= -1;
      }
   }
   
   /**
   Adds two fractions and reduces the sum.
   @param f the fraction added to this
   @return the sum as a Fraction
   */
   public Fraction add ( Fraction f )
   {
      Fraction sum = new Fraction();
      if ( denominator == f.denominator )
      {
         sum.numerator = numerator + f.numerator;
         sum.denominator = denominator;
      }
      else
      {
         Fraction temp1 = new Fraction(f);
         Fraction temp2 = new Fraction(this);
         denominator *= f.denominator;
         numerator *= f.denominator;
         f.denominator = temp1.denominator * temp2.denominator;
         f.numerator = temp1.numerator * temp2.denominator;
         sum.denominator = denominator;
         sum.numerator = f.numerator + numerator;
      }
      reduce();
      f.reduce();
      sum.reduce();
      return sum;   
   }
   
   /**
   Subtracts the fraction f from this and reduces the difference.
   @param f the fraction to be subtracted from this
   @return the difference as a Fraction
   */
   public Fraction subtract ( Fraction f )
   {
      Fraction difference = new Fraction();
      if ( denominator == f.denominator )
      {
         difference.numerator = numerator - f.numerator;
         difference.denominator = denominator;
      }
      else
      {
         Fraction temp1 = new Fraction(f);
         Fraction temp2 = new Fraction(this);
         denominator *= f.denominator;
         numerator *= f.denominator;
         f.denominator = temp1.denominator * temp2.denominator;
         f.numerator = temp1.numerator * temp2.denominator;
         difference.denominator = denominator;
         difference.numerator = numerator - f.numerator;
      }
      reduce();
      f.reduce();
      difference.reduce();
      return difference;         
   }
   
   /**
   Multiplies this and f and reduces the product
   @param f the fraction being multiplied with this
   @return the product as a Fraction
   */
   public Fraction multiply ( Fraction f )
   {
      Fraction product = new Fraction();
      product.numerator = numerator * f.numerator;
      product.denominator = denominator * f.denominator;
      product.reduce();
      return product;
   }
   
   /**
   Testbed main. Tests all the constructors and methods in this class.
   @param args is not used
   */
   public static void main ( String args[] ) 
   {
      //Test for default constructor
      Fraction f1 = new Fraction();
      System.out.println("Defualt constructor test: ");
      System.out.println("Expected: (0/1)");
      System.out.println("Result: " + f1);
      System.out.println();
      
      //Test for copy constructor
      Fraction f2 = new Fraction(f1);
      System.out.println("Copy constructor test:");
      System.out.println("Expected: (0/1)");
      System.out.println("Result: " + f2);
      System.out.println();
      
      //Test for String constructor
      Fraction f3 = new Fraction("1/2");
      System.out.println("String constructor test:");
      System.out.println("Expected: (1/2)");
      System.out.println("Result: " + f3);
      System.out.println();
      
      //Test for toString method
      System.out.println("toString method test:");
      System.out.println("Expected: (1/2)");
      System.out.println("Result: " + f3.toString());
      System.out.println();

      //Test for reduce method
      Fraction f4 = new Fraction("2/8");
      f4.reduce();
      System.out.println("reduce method test:");
      System.out.println("Expected: (1/4)");
      System.out.println("Result: " + f4);
      System.out.println();
      
      //Test for add method
      System.out.println("add method test:");
      System.out.println("Expected: (3/4)");
      System.out.println("Result: " + f3.add(f4));
      System.out.println();
      
      //Test for subract method
      System.out.println("subtract method test:");
      System.out.println("Expected: (1/4)");
      System.out.println("Result: " + f3.subtract(f4));
      System.out.println();
      
      //Test for multiply method
      System.out.println("multiply method test:");
      System.out.println("Expected: (1/8)");
      System.out.println("Result: " + f3.multiply(f4));
      System.out.println();      
   }

}
