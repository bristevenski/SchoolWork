import java.awt.*;
import javax.imageio.*;
import java.io.*;

/**
This class represents a Survivor. A Survivor can be moved and drawn.
@author Brianna Muleski
@author Andrew Inverson
*/
public class Survivor extends PFigure
{
   private int xVel = 20;
   private int yVel = 20;
   private Image survivor;
   
   /**
   Constructor. Uses super and places the Survivor randomly on the lower left
   corner of the panel.
   @param p the game panel
   @param inX the random amount to be used for the starting X coordinate
   @param inY the random amount to be used for the starting Y coordinate
   */
   public Survivor(Panel p, int inX, int inY)
   {

      super(inX + 400, inY + 300, 110, 70, 2, p );
      try
      {
         File file = new File("survivor1.jpg");
         survivor = ImageIO.read(file);
      }
      catch (Exception e )
      {
         System.out.println("Crashing: " + e);
      }
   }
   
   /**
   Moves the Survivors diagonally across the board. If a side of the panel is 
   reached then the Survivor "bounces" of the side and travels in the opposite
   direction diagonally.
   */
   @Override
    public void move()
   {
      if ( xVel < 0 && x <= 0 ||
           xVel > 0 && x + width >= panel.getSize().width )
         xVel = - xVel;
      if ( yVel < 0 && y <= 0 ||
           yVel > 0 && y + height >= panel.getSize().height )
         yVel = - yVel;
      x = x + xVel;
      y = y + yVel;
   }

   /**
   Draws the Survivor using the image provided.
   */
   @Override
   public void draw()
   {
      if( survivor != null )
      {
         Graphics g = panel.getGraphics();
         g.drawImage( survivor, x, y, width, height, null );
      }
   }



}

