import java.awt.*;
import javax.imageio.*;
import java.io.*;

/**
This class represents a Zombie. A Zombie can be moved and drawn.
@author Brianna Muleski
@author Andrew Iverson
*/
public class Zombie extends PFigure
{
   private final int M_MOD1 = 10;
   private final int M_MOD2 = 110;
   private final int M_MOD3 = 70;
   private final int RND_MOD = 25;
   private int xVel = 0;
   private int yVel = 0;
   private Image zombie;
   private Boolean nearSide = false;
   private Boolean nearBot = false;
   
   /**
   Constructor. Uses super and determines X coordinate based on the current game
   level. 
   @param p the game Panel
   @param i the current game level
   */
   public Zombie(Panel p, int i)
   {
      super(200 * i , 50, 110, 70, 4, p );
      try
      {
         File file = new File("zombie.jpg");
         zombie = ImageIO.read(file);
      }
      catch (Exception e )
      {
         System.out.println("Crashing: " + e);
      }
   }
   
   /**
   Constructor. Uses super and specific X and Y coordinates.
   @param p the game Panel
   @param inX the starting X coordinate for the Zombie
   @param inY the starting Y coordinate for the Zombie
   */
   public Zombie(Panel p, int inX, int inY)
   {
      super( inX, inY, 110, 70, 4, p );
      try
      {
         File file = new File("zombie.jpg");
         zombie = ImageIO.read(file);
      }
      catch (Exception e )
      {
         System.out.println("Crashing: " + e);
      }
   }
   
   /**
   Moves the Zombie randomly across the panel. When the Zombie reaches the sides
   of the panel, it "bounces" of the side and moves randomly away from the side.
   */
   @Override
   public void move()
   {  
      if ( x + xVel + M_MOD2 > panel.getWidth() && ! nearSide )
         nearSide = true;
      if ( nearSide )
      {
         if ( x - xVel < 0 && nearSide )
            nearSide = false;
         xVel = 1 + (int)( Math.random() * -RND_MOD);
      }
      else
         xVel = 1 + (int)( Math.random() * RND_MOD );
      if ( y + yVel + M_MOD3 > panel.getHeight() && ! nearBot )
         nearBot = true;
      if ( nearBot )
      {
         if ( y - yVel - M_MOD2 < 0 && nearBot )
            nearBot = false;
         yVel = 1 + (int)( Math.random() * -RND_MOD );
      }
      else
         yVel = 1 + (int)( Math.random() * RND_MOD);
      x = x + xVel;
      y = y + yVel;
   }

   /**
   Draws the Zombie using the image provided.
   */
   @Override
   public void draw()
   {
      if( zombie != null )
      {
         Graphics g = panel.getGraphics();
         g.drawImage( zombie, x, y, width, height, null );
      }
   }



}
