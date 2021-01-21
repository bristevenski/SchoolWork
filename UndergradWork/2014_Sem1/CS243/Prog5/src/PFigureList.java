import java.awt.Panel;

/**
This class represent a list of PFigures. The figures can be moved, drawn, reset,
hidden, and tested for collision.
@author  Brianna Muleski
*/
public class PFigureList 
{
   private final int MAX_FIGURES = 50;
   private final int BASE_ZOMBIES = 3;
   private final int NUM_SURVIVORS = 2;
   private final int STRT_X = 800;
   private final int STRT_Y = 500;
   private final int ZS_COLL = 2;
   private final int ZP_COLL = 3;
   private PFigure [] figures = new PFigure[MAX_FIGURES];
   private int numFigures = 0;
   
   /**
   Constructor. Creates the array of figures with Zombies (based on the level),
   Survivors (placed randomly), and one Player.
   @param level the current level of the game
   @param p the game Panel
   */
   public PFigureList(int level, Panel p)
   {
      for( int i = 0; i < level + BASE_ZOMBIES; i++, numFigures++ )
         figures[i] = new Zombie(p, i);
      int temp = numFigures;
      for( int i = temp; i < NUM_SURVIVORS + temp; i++, numFigures++ )
      {
          int startX = (int) ( Math.random() * STRT_X ) + 1;
          int startY = (int) ( Math.random() * STRT_Y ) + 1;
          figures[i] = new Survivor(p, startX, startY);
      }
         
      figures[numFigures++] = new Player(p);  
   }
   
   /**
   Moves all the Zombies and Survivors on the panel.
   */
   public void moveFigures()
   {
      for( int i = 0; i < numFigures - 1; i++ )
            figures[i].move();
   }
   
   /**
   Moves the Player using an input device
   @param inX the number to be added to the X coordinate
   @param inY the number to be added to the Y coordinate
   */
   public void movePlayer(int inX, int inY)
   {
      figures[numFigures - 1].move(inX, inY);
   }
   
   /**
   Returns the player.
   @return The Player figure
   */
   public Player getPlayer()
   {
      return (Player) figures[numFigures - 1];
   }
   
   /**
   Hides all the figures.
   */
   public void hideFigures()
   {
      for( int i = 0; i < numFigures; i++ )
         figures[i].hide();
   }
   
   /**
   Draws all the figures.
   */
   public void drawFigures()
   {
      for( int i = 0; i < numFigures; i++ )
         figures[i].draw();
   }
   
   /**
   Resets the figures to the beginning spots. Erases what is in the array and
   creates a new array.
   @param level the current level of the game
   @param p the game Panel
   */
   public void reset(int level, Panel p)
   {
      for( int i = 0; i < numFigures; i++ )
         figures[i] = null;
      numFigures = 0;
      for( int i = 0; i < level + BASE_ZOMBIES; i++, numFigures++ )
         figures[i] = new Zombie(p, i);
      int temp = numFigures;
      for( int i = temp; i < NUM_SURVIVORS + temp; i++, numFigures++ )
      {
          int startX = (int) ( Math.random() * STRT_X ) + 1;
          int startY = (int) ( Math.random() * STRT_Y ) + 1;
          figures[i] = new Survivor(p, startX, startY);
      }
         
      figures[numFigures++] = new Player(p);  
   }
   
   /**
   Test for collision amongst the figures in the array. If a collision is
   detected, then the figures are compared and the "winner" is determined. If 
   a Survivor (winner is 2 or -2) is in the collision, then the Survivor is 
   changed into a Zombie. If the Player (winner is 3 or -3) is in the collision 
   then true is returned. If there is no collision, the collision is of both
   the same type of figures, or the collision is between the Player and a
   Survivor then false is returned.
   @param p the game Panel
   @return True if a Player-Zombie collision is detected, false otherwise
   */
   public boolean collision(Panel p)
   {
      int winner;
      for( int i = 0; i < numFigures; i++ )
      {
         for ( int j = i + 1; j < numFigures; j++)
         {
            if(figures[i].collidedWith(figures[j]))
            {
               winner = figures[i].compareTo(figures[j]);
               if( winner == ZS_COLL) //Zombie & Survivor collision 
               {
                  figures[j].hide();
                  figures[j] = new Zombie(p, figures[j].x, figures[j].y);
                  return false;
               }
               else if( winner == -ZS_COLL) //Zombie & Survivor collision
               {
                  figures[i].hide();
                  figures[i] = new Zombie(p, figures[i].x, figures[i].y);
                  return false;
               } 
               else if( winner == ZP_COLL || winner == -ZP_COLL) //Zombie & 
                   return true;                             //Player collision
            }
         }
      }
      return false; //No collision, same-type collision, 
   }                //or Player & Survivor collision
}
  