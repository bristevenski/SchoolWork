import javax.imageio.*;
import java.io.*;
import java.awt.*;

/**

@author Brianna Muleski
*/
public class NumCard
{
   private Image img;
   private int num;
   public NumCard( int inNum ) 
   {
      num = inNum;
      File file = null;
         switch (num)
         {
            case 1:  file = new File("1Card.jpg");
                     break;
            case 2:  file = new File("2Card.jpg");
                     break;
            case 3:  file = new File("3Card.jpg");
                     break;
            case 4:  file = new File("4Card.jpg");
                     break;
            case 5:  file = new File("5Card.jpg");
                     break;
            case 6:  file = new File("6Card.jpg");
                     break;
            case 7:  file = new File("7Card.jpg");
                     break;
            case 8:  file = new File("8Card.jpg");
                     break;
            case 9:  file = new File("9Card.jpg");
                     break;
            case 10: file = new File("10Card.jpg");
                     break;
            case 11: file = new File("11Card.jpg");
                     break;
            case 12: file = new File("12Card.jpg");
                     break;
         }
       try
      {       
         img = ImageIO.read(file);
      }
      catch( Exception e )
      {
          System.out.println("NumCard Crashing: " + e);
      }
   }
   public void draw(Panel p)
   {
      if( img != null )
      {
         Graphics g = p.getGraphics();
         g.drawImage( img, 0, 0, 250, 350, null);
      }
   }
}
