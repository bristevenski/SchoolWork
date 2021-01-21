/**
Runs the main for Program 2
@author T. Scanlan
*/

public class Prog2
{
   /**
   Runs FractionManipulator.
   @param args  is unused
   */
   public static void main ( String args[] ) 
   {
      try
      {
         new FractionManipulator().run();
      }
      catch ( Exception e)
      {
         System.out.println("Program Error!");
      }
   }
}

/**
//JUnit Test for ListOfFraction.java
//*/
//import org.junit.After;
//import org.junit.AfterClass;
//import org.junit.Before;
//import org.junit.BeforeClass;
//import org.junit.Test;
//import static org.junit.Assert.*;
//
///**
//@author Brianna Muleski
//*/
//public class ListOfFractionTest {
//   
//   public ListOfFractionTest() {
//   }
//   
//   @BeforeClass
//   public static void setUpClass() {
//   }
//   
//   @AfterClass
//   public static void tearDownClass() {
//   }
//   
//   @Before
//   public void setUp() {
//   }
//   
//   @After
//   public void tearDown() {
//   }
//
//   /**
//   Test of add method, of class ListOfFraction.
//   */
//   @Test
//   public void testAdd() 
//   {
//      System.out.println("add");
//      Fraction z = new Fraction(1, 2);
//      ListOfFraction instance = new ListOfFraction();
//      instance.add(z);
//   
//      boolean expResult = true;             // we expect the result of delete to
//                                            // be true since we just added it.
//      boolean result = instance.delete(z);  // Call actual delete
//      assertEquals(expResult, result);      // Test the results.
//      
//      System.out.println("add");
//      Fraction f = new Fraction(4, 9);
//      instance.add(f);
//      expResult = true;
//      result = instance.delete(f);
//      assertEquals(expResult, result);
//   }
//   /**
//   Test of delete method, of class ListOfFraction.
//   */
//   @Test
//   public void testDelete() {
//      System.out.println("delete");
//      Fraction f = new Fraction(1, 2);
//      ListOfFraction instance = new ListOfFraction();
//      boolean expResult = false;
//      boolean result = instance.delete(f);
//      assertEquals(expResult, result);
//      
//      System.out.println("delete");
//      Fraction z = new Fraction(1, 4);
//      instance = new ListOfFraction();
//      expResult = false;
//      result = instance.delete(f);
//      assertEquals(expResult, result);
//   }
//
//   /**
//   Test of sum method, of class ListOfFraction.
//   */
//   @Test
//   public void testSum() {
//      System.out.println("sum");
//      ListOfFraction instance = new ListOfFraction();
//      Fraction expResult = new Fraction(0, 1);
//      Fraction result = instance.sum();
//      assertEquals(expResult, result);
//            
//      System.out.println("sum");
//      instance = new ListOfFraction();
//      instance.add(new Fraction (3, 5));
//      expResult = new Fraction(3, 5);
//      result = instance.sum();
//      assertEquals(expResult, result);
//   }
//
//   /**
//   Test of product method, of class ListOfFraction.
//   */
//   @Test
//   public void testProduct() {
//      System.out.println("product");
//      Fraction f = null;
//      ListOfFraction instance = new ListOfFraction();
//      instance.product();
//      
//      System.out.println("product");
//      f = new Fraction(1, 3);
//      instance = new ListOfFraction();
//      instance.product();
//
//   }
//
//   /**
//   Test of print method, of class ListOfFraction.
//   */
//   @Test
//   public void testPrint() {
//      System.out.println("print");
//      int numPerLine = 0;
//      ListOfFraction instance = new ListOfFraction();
//      instance.print(numPerLine);
//      
//      System.out.println("print");
//      numPerLine = 2;
//      instance = new ListOfFraction();
//      instance.add(new Fraction(1, 2));
//      instance.add(new Fraction(2, 3));
//      instance.print(numPerLine);
//   }
//   
//}