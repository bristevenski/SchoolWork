
import java.awt.*;
import java.io.File;
import javax.imageio.ImageIO;


/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author andreskis
 */
public class Board extends SFigure
{
   private Image img;
   public Board(Panel inPanel)
   {
      super(0, 0, 850, 773, 0, inPanel);
      try
      {
         File file = new File("SorryBoard.jpg");
         img = ImageIO.read(file);
      }
      catch(Exception e)
      {
         System.out.println("Board Crashing: " + e);
      }
   }
   
   
   @Override
   public void draw()
   {
      Graphics g = panel.getGraphics();
      g.drawImage(img, x, y, width, height, null);
      g.dispose();
      System.out.println("Drawn");
   }
}
