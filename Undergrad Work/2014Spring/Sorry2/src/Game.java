/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author andreskis
 */
public class Game
{
   private SFigure figure[];
   private int count = 0;
   Game()
   {
      figure = new SFigure [1000];
   }
   public void run()
   {
      boolean gameOver = false;
      while(!gameOver)
      {
        
      }
   }
   
   public static void main ( String args[] ) 
   {
      SorryMenu sm = new SorryMenu();
      sm.setVisible(true);
   }
   public void add(SFigure s)
   {
      figure[count] = s;
      count++;
   }
   public void refresh()
   {
      for (int i = 0; i < count; i++)
         figure[i].draw();
   }
}
