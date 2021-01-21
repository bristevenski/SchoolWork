
import java.util.Random;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author nankem
 */
public class Deck
{
   private final int NUM_CARDS = 52;
   private Card[] deck = new Card[NUM_CARDS];
   int index = 0;
   
   public Deck()
   {
      Random rn = new Random();
      int j = 1;
      int r;
      for(int x = 0; x < NUM_CARDS; x++ )
      {
         deck[x] = new Card(-1);
      }
      for(int i = 1; i < NUM_CARDS + 1; i++ )
      {
         r =  rn.nextInt(Integer.MAX_VALUE) % NUM_CARDS; 
         if (deck[r].getNum() == -1)
         {
            deck[r] = new Card(j);
            //System.out.println(r);
         }
         else
         {
            int t;
            for(t = r; deck[t].getNum() != -1; t = (t + 1) % NUM_CARDS)
            {
               
            }
               deck[t] = new Card(j);
              // System.out.println(t);
         }
         j = i/4 + 1;
      }
   }
   
   public int drawCard()
   {
      if (index < NUM_CARDS)
      {
         return deck[index++].getNum();
      }
      else 
         return -1;
   }
}
