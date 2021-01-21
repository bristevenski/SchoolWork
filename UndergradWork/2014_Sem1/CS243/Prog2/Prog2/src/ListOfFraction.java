/**
This class holds a list of Fractions and the methods to manipulate it.
The list of Fractions can grow and be printed in a format specified by
the user. The user can add and delete fractions from the list. The
fractions in the list can be added and multiplied.
@author Brianna Muleski
*/
public class ListOfFraction
{
   private final int GROW_BY = 2;
   private Fraction fractions[] = new Fraction[GROW_BY];
   private int numOfFractions = 0;
   
   /**
   Increases the number of fractions that the list can hold by GROW_BY
   amount.
   */
   private void grow()
   {
      Fraction newList[] = new Fraction[fractions.length + GROW_BY];
      for ( int i = 0; i < numOfFractions; i++ )
         newList[i] = fractions[i];
      fractions = newList;
   }
   
   /**
   Finds the desired fraction (f) in the list and returns its index.
   @param f the fraction to be found
   @return the index of the fraction f, -1 if the fraction does not
   exist within the list
   */
   private int find ( Fraction f )
   {
      for ( int i = 0; i < numOfFractions; i++ )
         if ( f.equals(fractions[i]) )
            return i;
      return -1;
   }
   
   /**
   Adds a fraction to the list, if the list is full then the list is
   grown and the fraction is then added to the list.
   @param f the fraction to be added
   */
   public void add ( Fraction f )
   {
      if ( numOfFractions == fractions.length )
         grow();
      fractions[numOfFractions++] = f;
   }
   
   /**
   Deletes the desired fraction (f) from the list if it exists.
   @param f the fraction to be deleted
   @return true if the fraction is deleted, false if it does not exist
   */
   public boolean delete ( Fraction f )
   {
      int index = find(f);
      if ( index == -1 )
         return false;
      numOfFractions--;
      for( int i = index; i < numOfFractions; i++ )
         fractions[i] = fractions[i + 1];
      return true;
   }
   
   /**
   Adds the list of fractions together.
   @return the sum as a Fraction 
   */
   public Fraction sum()
   {
      Fraction sum = new Fraction();
      if ( numOfFractions == 0 )
         return sum;
      for ( int i = 0; i < numOfFractions; i++ )
         sum = sum.add(fractions[i]);
      return sum;
   }
   
   /**
   Multiplies the list of fractions together.
   @return the product as a Fraction
   */
   public Fraction product()
   {
      Fraction product = new Fraction(1, 1);
      if ( numOfFractions == 0 )
         return product;
      for ( int i = 0; i < numOfFractions; i++ )
         product = product.multiply(fractions[i]);
      return product;      
   }
   
   /**
   Prints the list of the fractions.
   @param numPerLine the number of fractions per line
   */
   public void print ( int numPerLine )
   {
      if ( numPerLine < 1 )
         numPerLine = 1;
      if ( numOfFractions == 0 )
         System.out.println();
      else
      {
         for( int currentFraction = 0; currentFraction < 
              numOfFractions; currentFraction += numPerLine )
         {
            for( int i = 0; i < numPerLine && 
                 currentFraction + i < numOfFractions; i++ )
               System.out.print(fractions[currentFraction + i] + " ");
            System.out.println();
         }            
      }
   }
}
