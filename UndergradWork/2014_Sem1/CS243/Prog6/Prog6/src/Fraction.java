import java.util.StringTokenizer;

/**
This class contains the methods and constructors for fractions.
It includes 4 constructors and toString, reduce, plus, minus, times and is
equal methods. 
@author Andrew Iverson
*/
public class Fraction
{
   private int numerator, denominator;

   /**
   Constructor that initializes numerator to 0, and denominator to 1.  
   */
   public Fraction( )
   {
      numerator = 0;
      denominator = 1;
   }
   
   /**
   Constructor that copies a supplied fraction.
   @param z name of fraction to copy
   */
   public Fraction( Fraction z )
   {
      numerator = z.numerator;
      denominator = z.denominator;
   }
   
   /**
   Constructor that takes a supplied values for numerator and denominator  
   @param nu value to set numerator to
   @param de value to set denominator to.
   */
   public Fraction( int nu, int de )
   {
      numerator = nu;
      denominator = de;
      reduce();
   }
   
   /**
   Constructor that takes a supplied string and makes a fraction.
   @param fractionString string of fraction in format "numerator/denominator"
   */
   public Fraction( String fractionString )
   {
      String temp = fractionString;
      temp = temp.replace("(", "");
      temp = temp.replace(")", "");
      StringTokenizer st = new StringTokenizer ( temp, "/" );
      numerator = Integer.parseInt( st.nextToken() );
      denominator = Integer.parseInt( st.nextToken() );
      reduce();
   }
   
   /**
   Returns a string of the fraction by concatenation of the numerator and
   denominator separated with a "/"
   @return  a string of the fraction in format "numerator/denominator"
   */
   @Override
   public String toString( )
   {
      String temp;
      temp = "(" + numerator + "/" + denominator + ")";
      return temp;
   }
   
   /**
   Reduces the fraction completely. 
   */
   private void reduce( )
   {
      int low, high, temp;
      low = Math.abs( numerator );
      if ( Math.abs( denominator ) <= low )
      {
         low = Math.abs( denominator );
      }
      high = Math.abs( numerator );
      if ( Math.abs( denominator ) > high )
      {
         high = Math.abs( denominator );
      }
      while ( low != 0 )
      {
         temp = low;
         low = high % low;
         high = temp;
      }
      numerator = numerator / high;
      denominator = denominator / high;
      if ( denominator < 0 )
      {
            numerator *= -1;
            denominator *= -1;
      }
   }
   
   /**
   Adds two fractions together and returns the result as a fraction.   
   @param x the fraction to add with
   @return  returns a fraction that is this fraction plus fraction x.
   */
   public Fraction plus( Fraction x )
   {
      int temp, temp1;
      temp = denominator * x.denominator;
      temp1 = ( numerator * x.denominator ) + ( x.numerator * denominator );
      Fraction d = new Fraction ( temp1, temp );
      return d;      
   }
   
   /**
   Minus two fractions and returns the result as a fraction.
   @param x the fraction to minus with
   @return  returns a fraction that is this fraction minus fraction x.
   */
   public Fraction minus( Fraction x)
   {
      int temp, temp1;
      temp = denominator * x.denominator;
      temp1 = ( numerator * x.denominator ) - ( x.numerator * denominator );
      Fraction d = new Fraction ( temp1, temp );
      return d;
   }
   
   /**
   Multiplies two fractions together and returns the reduced fraction.
   @param x the fraction to times with this.
   @return  returns a fraction that is this fraction times fraction x.
   */
   public Fraction times( Fraction x)
   {
      int temp, temp1;
      temp = numerator * x.numerator;
      temp1 = denominator * x.denominator;
      Fraction d = new Fraction ( temp, temp1);
      return d;
   }
   
   /**
   Compares a fraction with this fraction, fractions are equal if they have 
   the same denominator and numerator. 
   @param x the fraction to compare with this to determine if equal 
   @return returns true if x is a fraction and is equal.
   */
   public Boolean isEqual( Object x )
   {
      if ( x instanceof Fraction )
      {
         Fraction d = ( Fraction )x;
         return numerator == d.numerator && denominator == d.denominator;
      }   
      return false;
   }
   
   /**
   Testbed main. Has tests to test all constructors and methods.
   Outputs each test result.
   @param args is unused
   */
   public static void main ( String args[] ) 
   {
      Fraction c1 = new Fraction( );
      Fraction c2 = new Fraction( c1 );
      Fraction c3 = new Fraction( 1, 1 );
      Fraction c4 = new Fraction( 0, 1 );
      Fraction c5 = new Fraction( "(0/1)" );
      Fraction c6 = new Fraction( 3, 6 );
      Fraction c7 = new Fraction( 1, 2 );
      Fraction c8 = new Fraction( c6.plus( c7 ) );
      Fraction c9 = new Fraction( c3.minus( c6 ) );
      Fraction c10 = new Fraction( c6.times( c7 ) );
      Fraction c11 = new Fraction( 1, 4 );
      c6.reduce();
      String temp1, temp2, temp3, temp4;
      temp1 = c1.toString( );
      temp2 = c2.toString( );
      temp3 = c1.toString( );
      temp4 = c4.toString( );
      if ( temp1.equals( "0/1" ) )
         System.out.println( "Test Bed Main test: passed on toString" );
      else
         System.out.println( "Test Bed Main test: failed on toString" );
      if ( temp1.equals( temp2 ) )
         System.out.println( "Test Bed Main test: passed on copy" );
      else
         System.out.println( "Test Bed Main test: failed on copy" );
      if ( temp3.equals( "0/1" ) )
         System.out.println( "Test Bed Main test: passed on default" );
      else
         System.out.println( "Test Bed Main test: failed on default" ); 
      if ( temp1.equals( temp4 ) )
         System.out.println( "Test Bed Main test: passed on"
                           + " constructor int, int" );
      else
         System.out.println( "Test Bed Main test: passed on"
                           + " constructor int, int" );
      if ( c1.isEqual( c2 ) )
         System.out.println( "Test Bed Main test: passed on isEqual True" );
      else
         System.out.println( "Test Bed Main test: failed on isEqual True" );
      if ( !c1.isEqual( c3 ) )
         System.out.println( "Test Bed Main test: passed on isEqual False" );
      else
         System.out.println( "Test Bed Main test: failed on isEqual False" );
      if ( c5.isEqual( c1 ) )
         System.out.println( "Test Bed Main test: passed" +
                             " on string construct" );
      else
         System.out.println( "Test Bed Main test: failed"
                           + " on string construct" );
      if ( c6.isEqual( c7 ) )
         System.out.println( "Test Bed Main test: passed on reduce" );
      else
         System.out.println( "Test Bed Main test: failed on reduce" );
      if ( c8.isEqual( c3 ) )
         System.out.println( "Test Bed Main test: passed on plus" );
      else
         System.out.println( "Test Bed Main test: failed on plus" );
      if ( c9.isEqual( c7 ) )
         System.out.println( "Test Bed Main test: passed on minus" );
      else
         System.out.println( "Test Bed Main test: failed on minus" );
      if ( c10.isEqual( c11 ) )
         System.out.println( "Test Bed Main test: passed on multi" );
      else
         System.out.println( "Test Bed Main test: failed on multi" );
   }

}
