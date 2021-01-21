import java.awt.*;

/**
This class represents a figure, its attributes, and the manipulation of those
figures. A figure can be moved, hidden, drawn, compared to other figures, and
tested for collision with other figures.
*/
public abstract class PFigure implements Comparable
{
   protected int x, y;           // Current position of the figure
   protected int width, height;  // Drawn (displayed) this size
   protected int priority;       // Can use to determine "winner"
   protected Panel panel;        // Panel the figure lives on
   
   /**
   Constructor. Takes in all the information for creating the figure.
   @param startX the starting X coordinate for the figure
   @param startY the starting Y coordinate for the figure
   @param inWidth the width of the figure
   @param inHeight the height of the figure
   @param pr the priority of the figure (used when comparing)
   @param p the panel the figure is created on
   */
   public PFigure ( int startX, int startY, int inWidth, int inHeight, 
                    int pr, Panel p )
   {
       x = startX;
       y = startY;
       width = inWidth;
       height = inHeight;
       priority = pr;
       panel = p;
   }
   
   /**
   Compares Object o to this. If Object o is not a PFigure, then the MAX_VALUE
   is returned, otherwise the priorities of o is subtracted from the priority of
   this.
   @param o the object being compared to
   @return the difference in priorities, if > 1 then this is greater, if > 1
           then o is greater
   */
   public int compareTo(Object o)
   {
      if( o instanceof PFigure )
         return priority - ((PFigure)o).priority;
      return Integer.MAX_VALUE;
   }
      
   /**
   Tests if this has collided with p. If p is null then false is returned, 
   otherwise the the width and height of this is checked against the width and
   height of p
   @param p
   @return true if this collided with p, false otherwise.
    */
   public boolean collidedWith ( PFigure p )
   {
      if (  p == null )
         return false;

      return ( x + width ) >= p.x && ( p.x + p.width ) >= x &&
             ( y + height ) >= p.y && ( p.y + p.height ) >= y;
   }
   
   /**
   Used to move a figure with an input device.
   @param deltaX the int added to the X coordinate to create new X coordinate
   @param deltaY the int added to the Y coordinate to create new Y coordinate
    */
   public void move ( int deltaX, int deltaY )
   {
      x = x + deltaX;
      y = y + deltaY;
   }
   
   /**
   Hides the figure on the panel.
   */
   public void hide()
   {
      Graphics g = panel.getGraphics();
      Color oldColor = g.getColor();
      g.setColor(panel.getBackground() );
      g.fillRect(x, y, width, height + 7);
      g.setColor(oldColor);
   }
   
   /**
   Moves a figure on the panel.
   */
   public void move()
   {
   }


   /**
   Draws the figure on the panel.
   */
   abstract public void draw();

   
}