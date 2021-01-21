import javax.imageio.*;
import java.io.*;
import java.awt.*;
import javax.swing.JOptionPane;

public class Pawn extends SFigure
{
   private final int R_SF = 48;
   private final int R_SF1 = 83;
   private final int R_STRT = 64;
   private final int R_FRST = 52;
   private final int R_HM = 88;
   private final int B_SF = 33;
   private final int B_SF1 = 77;
   private final int B_STRT = 63;
   private final int B_FRST = 37;
   private final int B_HM = 82;
   private final int G_SF = 18;
   private final int G_SF1 = 71;
   private final int G_STRT = 62;
   private final int G_FRST = 22;
   private final int G_HM = 76;
   private final int Y_SF = 3;
   private final int Y_SF1 = 65;
   private final int Y_STRT = 61;
   private final int Y_FRST = 7;
   private final int Y_HM = 70;
   private final int MV_FR_STRT = 2;
   private final int CRNR = 60;
   private int[] xPos = { 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20,
                           20, 20, 20, 70, 120, 170, 220, 270, 320, 370, 420,
                           490, 540, 590, 640, 690, 760, 800, 800, 800, 800, 
                           800, 800, 800, 800,
                           800, 800, 800, 800, 800, 800, 800, 800, 750, 700, 
                           643, 589, 538, 483, 435, 372, 322, 273, 221, 172,
                           120, 67, 103, 270, 722, 524, 65, 123, 170, 222,
                           271, 343, 117, 117, 117, 117, 117, 117, 749, 699,
                           648, 589, 546, 474, 699, 699, 699, 699, 699, 699};
   private int[] yPos = { 725, 675, 635, 590, 545, 495, 455, 410, 360, 305, 
                           255, 205, 160, 115, 65,  20, 20, 20, 20, 20, 20,
                           20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 65, 115, 
                           160, 206, 256, 305, 353,
                           406, 452, 497, 544, 591, 636, 680, 725, 725, 725, 
                           725, 725, 725, 725, 725, 725, 725, 725, 725, 725, 
                           725, 725, 485, 96, 250, 654, 633, 633, 633, 633, 
                           633, 633, 65, 111, 161, 204, 258, 314, 114, 114, 
                           114, 114, 114, 114, 682, 637, 598, 532, 505, 451};
   
   private String color;
   private int location;
   Image img;
   boolean err = false;
   boolean inStart;
   
   public Pawn(int startX, int startY, String inColor, int num, Panel p )
   {
      
      super (startX, startY, 20, 30, 1, p );
      
      inStart = true;
      color = inColor;
      File file = null;
      if( color.equals("red") )
      {
         location = R_STRT;
         if( num == 1 )
            file = new File("redPawn1.jpg");
         else if( num == 2 )
            file = new File("redPawn2.jpg");
         else if( num == 3 )
            file = new File("redPawn3.jpg");
         else
            file = new File("redPawn4.jpg");
      }
      else if( color.equals("blue") )
      {
         location = B_STRT;
         if( num == 1 )
            file = new File("bluePawn1.jpg");
         else if( num == 2 )
            file = new File("bluePawn2.jpg");
         else if( num == 3 )
            file = new File("bluePawn3.jpg");
         else
            file = new File("bluePawn4.jpg");
      }
      else if( color.equals("green") )
      {
         location = G_STRT;
         if( num == 1 )
            file = new File("greenPawn1.jpg");
         else if( num == 2 )
            file = new File("greenPawn2.jpg");
         else if( num == 3 )
            file = new File("greenPawn3.jpg");
         else
            file = new File("greenPawn4.jpg");
      }
      else if( color.equals("yellow") )
      {
         location = Y_STRT;
         if( num == 1 )
            file = new File("yellowPawn1.jpg");
         else if( num == 2 )
            file = new File("yellowPawn2.jpg");
         else if( num == 3 )
            file = new File("yellowPawn3.jpg");
         else
            file = new File("yellowPawn4.jpg");
      }
      
      try
      {
         img = ImageIO.read(file);
      }
      catch (IOException ex)
      {
         System.out.println("Pawn Crashing: " + ex);
      }
   }
   public boolean move(int length) //if returned true on board, then disable pawn button
   { 
      boolean win = false;
         if(color.equals("red"))
            win = moveRed(length);
         if(color.equals("blue"))
            win = moveBlue(length);
         if(color.equals("green"))
            win = moveGreen(length);
         if(color.equals("yellow"))
            win = moveYellow(length);
      if( err )
      {
         JOptionPane.showMessageDialog(null, "Error: you cannot move that"
               + " pawn!");
      }
      return win;
   }
   
   private boolean moveRed(int length)
   {
      while( length > 0 )
      {
         if(inStart && length <= 2 || inStart && length == 13)
         {
            inStart = false;
            location = R_FRST - 1;
         }
         else if(inStart && length > 2)
         {
           JOptionPane.showMessageDialog(null, "Error: you must have a 1 or 2"
           + " to move that pawn");
           length = 0;
         }
         else if(location == R_SF)
            location = R_SF1;
         else if(location == R_STRT)
         {
            if(length == 1 || length == MV_FR_STRT)
            {
               location = R_FRST;
               length = 0;
            }
            else
               err = true;
         }
         else if(location == R_HM)
            return true; //pawn is in home, so pawn needs to be immovable
         else 
         {
            if(location == CRNR)
               location = 1;
            else 
            {
               location++;
               x = xPos[location - 1];
               y = yPos[location - 1];
            }
         }
         length--;
         System.out.println(location);
         System.out.println(length);
      }
      return false;
   }
   
   private boolean moveBlue(int length)
   {
      while( length > 0 )
      {
         if(inStart && length <= 2 || inStart && length == 13)
         {
            inStart = false;
            location = B_FRST - 1;
         }
         else if(inStart && length > 2)
         {
           JOptionPane.showMessageDialog(null, "Error: you must have a 1 or 2"
           + " to move that pawn");
           length = 0;
         }
         else if(location == B_SF)
            location = B_SF1;
         else if(location == B_STRT)
         {
            if(length == 1 || length == MV_FR_STRT)
            {
               location = B_FRST;
               length = 0;
            }
            else
               err = true;
         } 
         else if(location == B_HM)
            return true;
         else 
         {
            if(location == CRNR)
               location = 1;
            else 
            {
               location++;
               x = xPos[location - 1];
               y = yPos[location - 1];
            }
         }
         length--;
         System.out.println(location);
         System.out.println(length);
      }
      return false;
   }
   private boolean moveGreen(int length)
   {
      while( length > 0 )
      {
         if(inStart && length <= 2 || inStart && length == 13)
         {
            inStart = false;
            location = G_FRST - 1;
         }
         else if(inStart && length > 2)
         {
           JOptionPane.showMessageDialog(null, "Error: you must have a 1 or 2"
           + " to move that pawn");
           length = 0;
         }
         else if(location == G_SF)
            location = G_SF1;
         else if(location == G_STRT)
         {
            if(length == 1 || length == MV_FR_STRT)
            {
               location = G_FRST;
               length = 0;
            }
            else
               err = true;
          } 
         else if(location == G_HM)
            return true;
         else
         {
            if(location == CRNR)
               location = 1;
            else 
            {
               location++;
               x = xPos[location - 1];
               y = yPos[location - 1];
            }
         }
         length--;
         System.out.println(location);
         System.out.println(length);
      }
      return false;
   }
   
   private boolean moveYellow(int length)
   {
      while( length > 0 )
      {
         if(inStart && length <= 2 || inStart && length == 13)
         {
            inStart = false;
            location = Y_FRST - 1;
         }
         else if(inStart && length > 2)
         {
           JOptionPane.showMessageDialog(null, "Error: you must have a 1 or 2"
           + " to move that pawn");
           length = 0;
         }
         else if(location == Y_SF)
            location = Y_SF1;
         else if(location == Y_STRT)
         {
            if(length == 1 || length == MV_FR_STRT)
            {
               location = Y_FRST;
               length = 0;
            }
            else
               err = true;
          }  
         else if(location == Y_HM)
            return true;
         else 
         {
            if(location == CRNR)
               location = 1;
            else 
            {
               location++;
               x = xPos[location - 1];
               y = yPos[location - 1];
            }
         }
         
         length--;
         System.out.println(location);
         System.out.println(length);
      }
      return false;
   }
   
   public int getLocation()
   {
      return location;
   }
   
   @Override
   public void draw()
   {
      if( img != null )
      {
         Graphics g = panel.getGraphics();
         g.drawImage( img, x, y, width, height, null);
         g.dispose();
      }
   }
   @Override
   public int compareTo(Object t)
   {
      return 0;
   }

//   /**
//   Testbed main.
//   @param args 
//   */
//   public static void main(String[] args)
//   {
//      Pawn p = new Pawn("red");
//      Pawn q = new Pawn("blue");
//      p.move(2);
//      q.move(1);
//      q.move(11);
//      q.move(13);
//      q.move(33);
//      q.move(6);
//      q.move(1);
//   }

   void bump(int startx, int starty)
   {
      switch (color)
      {
         case "red":
                     location = R_STRT;
                     break;
         case "blue":
                     location = B_STRT;
                      break;
         case "green": 
                     location = G_STRT;
                       break;
         case "yellow":
                      location = Y_STRT;
                        break;    
      }
       x = xPos[location - 1];
       y = yPos[location - 1];
   }


      public boolean bumpable(String color)
   {
      if( inStart )
         return false;
      if( color.equals("red") )
         if( location >= 83 )
            return false;
      if( color.equals("blue") )
         if( location >= 77 && location <= 82 )
            return false;
      if( color.equals("yellow") )
         if( location >= 65 && location <= 70 )
            return false;
      if( color.equals("green") )
         if( location >= 71 && location <= 76 )
            return false;

      return true;
   }
}
