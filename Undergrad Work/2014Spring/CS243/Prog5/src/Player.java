import java.awt.*;

/**
This class represents a Player. The Player can be moved and drawn.
@author Brianna Muleski
*/
public class Player extends PFigure
{
   private final int MOVE_MOD1 = 10;
   private final int MOVE_MOD2 = 40;
   private final int D_MOD2 = 2;
   private final int D_MOD3 = 3;
   private final int D_MOD4 = 4;
   private final int D_MOD5 = 5;
   private final int D_MOD10 = 10;
   private final int D_MOD16 = 16;
   private final int ARMW = 30;
   private final int ARMH = 35;
   private final int ARM_END_ANG = -180;
   private final int LEG_WH = 30;
   private final int LEG_END_ANG = 180;
   private final int BODYW = 10;
   private final int BODYH = 30;
   
   /**
   Constructor. Uses the super constructor and places the Player in the middle 
   of the panel.
   @param p the game Panel
   */
   public Player(Panel p)
   {
      super(600, 400,  80, 80, 1, p);
   }
   
   /**
   Moves the Player with an input device. If the Player is against one of the
   sides of the Panel, the Player's move is reset to the current position.
   @param deltaX the amount to move in the X coordinate
   @param deltaY the amount to move in the Y coordinate
   */
   @Override
   public void move ( int deltaX, int deltaY )
   {
      super.move(deltaX, deltaY);
      if ( x < -width / MOVE_MOD1)
         x = x - deltaX;
      else if ( (x + width) > panel.getSize().width) 
         x = x - deltaX;
      if ( y < -height / MOVE_MOD1 + MOVE_MOD2)
         y = y - deltaY;
      else if ( (y + height) > panel.getSize().height)
         y = y - deltaY;
   }
   
   /**
   Draws the Player using graphics. 
   */
   @Override
   public void draw()
   {
      Graphics g = panel.getGraphics();
      g.setColor(Color.black);
      //draws arms
      g.drawArc(x + width / D_MOD3 - 1 , y + width / D_MOD4 + D_MOD2, 
                ARMW, ARMH, 0, ARM_END_ANG);
      //draws legs
      g.drawArc(x + width / D_MOD2 - D_MOD16, y + D_MOD2 * height / 
                D_MOD2 - D_MOD10, LEG_WH, LEG_WH, 0, LEG_END_ANG);  
      //draws head
      g.drawOval(x + width / D_MOD4 , y + 1, width / D_MOD2, height / D_MOD2);
      g.setColor(Color.red);
      //draws body
      g.fillRect(x + width / D_MOD2 - D_MOD5 , y + height / D_MOD2 + 1 , 
                 BODYW, BODYH); 
   } 
   
}
