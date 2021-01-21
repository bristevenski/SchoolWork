import javax.imageio.*;
import java.io.*;
import java.awt.*;

/**

@author Brianna Muleski
*/
public class SorryCard 
{
   private Image img;
   
   public SorryCard() 
   {
      
      try
      {
         File file = new File("sorryCard.jpg");
         img = ImageIO.read(file);
      }
      catch( Exception e )
      {
          System.out.println("SorryCard Crashing: " + e);
      }
   }
   
   /**
   Draws the image of the sorry card on the card panel.
   @param p the card panel
   */
   public void draw(Panel p)
   {
      if( img != null )
      {
         Graphics g = p.getGraphics();
         g.drawImage( img, 0, 0, 250, 350, null);
         
      }
   }
}
