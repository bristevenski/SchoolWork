
import java.awt.Color;
import java.awt.Graphics;
import javax.swing.JPanel;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author nankem
 */
import java.awt.*;
import javax.swing.*;

/**
 *
 * @author andreskis
 */
public abstract class SFigure implements Comparable 
{
   protected int x, y;           // Current position of the figure
   protected int width, height;  // Drawn (displayed) this size
   protected int priority;       // Can use to determine "winner"
   protected Panel panel;        // Panel the figure lives on
   private Deck d = new Deck();
   
   public SFigure ( int startX, int startY, int _width, int _height, 
                    int pr, Panel p )
   {
       x = startX;
       y = startY;
       width = _width;
       height = _height;
       priority = pr;
       panel = p;
   }
   
   /**
   Can use this in "battles", which figures is "greater"
   */
   @Override
   public int compareTo(Object o)
   {
      if( o instanceof SFigure )
         return priority - ((SFigure)o).priority;
      return Integer.MAX_VALUE;
   }
      
   /**
   Has "this" figure collided with p?
   */
   public boolean collidedWith ( SFigure p )
   {
      if (  p == null )
         return false;

      return ( x + width ) >= p.x && ( p.x + p.width ) >= x &&
             ( y + height ) >= p.y && ( p.y + p.height ) >= y;
   }
   
   /**
   Can be used for moving by keyboard or mouse
   */
   public void move ( int deltaX, int deltaY )
   {
      x = x + deltaX;
      y = y + deltaY;
   }
   
   public void hide()
   {
      Graphics g = panel.getGraphics();
      Color oldColor = g.getColor();
      g.setColor(panel.getBackground() );
      g.fillRect(x, y, width, height);
      g.setColor(oldColor);
   }
   
   /**
   Can be automatic move, for example, called based on timer
   */
   public void move()
   {
   }

   /**
   Draw the figure.
   Each derived class will write their own drawing method.
   The first line should be:
   Graphics g = panel.getGraphics();
   */
   abstract public void draw();
   
   
   public int getCard()
   {
      int cardNum = d.drawCard();
      if(cardNum == -1)
      {
         d = new Deck();
         getCard();    
      }
         return cardNum;
   }
}

