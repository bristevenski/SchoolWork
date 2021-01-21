import java.awt.Panel;
/**

@author nankem
*/
public class Player
{
   private String name;
   private String color;
   private int plyrNum;
   private Pawn p1, p2, p3, p4;
   private int x, y;
   private boolean pwn1dn = false, pwn2dn = false; 
   private boolean pwn3dn = false, pwn4dn = false; //flags if pawn is in home space
   
   public Player( String inName, int inNum )
   {
      name = inName;
      plyrNum = inNum;
      switch (plyrNum)
      {
         case 1: color = "red";
                 x = 524;
                 y = 654;      
                 break;
         case 2: color = "blue";
                 x = 722;
                 y = 250;
                 break;
         case 3: color = "green";
                 x = 270;
                 y = 96;                       
                 break;
         case 4: color = "yellow";
                 x = 103;
                 y = 485;
                 break;
      }

   }
   
   public void disablePawn(int pawn)
   {
      switch (pawn)
      {
         case 1: pwn1dn = true;
                 break;
         case 2: pwn2dn = true;
                 break;
         case 3: pwn3dn = true;
                 break;
         case 4: pwn4dn = true;
                 break;
      }
   }
   
   public boolean get1Home()
   {
      return pwn1dn;
   }
   
   public boolean get2Home()
   {
      return pwn2dn;
   }
      
   public boolean get3Home()
   {
      return pwn3dn;
   }
         
   public boolean get4Home()
   {
      return pwn4dn;
   }
   
   public void addPawns(Panel p)
   {
      p1 = new Pawn(x, y, color, 1, p);
      p2 = new Pawn(x, y, color, 2, p);
      p3 = new Pawn(x, y, color, 3, p);
      p4 = new Pawn(x, y, color, 4, p);
   }
   
   public String getColor()
   {
      return color;
   }
   
   public String getName()
   {
       return name;
   }
   
   public int getNum()
   {
       return plyrNum;
   }

   
   public boolean movePawn(int pawnMove, int numSpaces)
   {
      boolean inHome = false;
      switch (pawnMove)
      {
         case 1: inHome = p1.move(numSpaces);
                 break;
         case 2: inHome = p2.move(numSpaces);
                 break;
         case 3: inHome = p3.move(numSpaces);
                 break;
         case 4: inHome = p4.move(numSpaces);
                 break;
      }
      return inHome;
   }

   public void show()
   {
      p1.draw();
      p2.draw();
      p3.draw();
      p4.draw();
   }

   Pawn getPawn(int pwn)
   {
      Pawn temp = null;
      switch (pwn)
      {
         case 1: temp = p1;
                 break;
         case 2: temp = p2;
                 break;
         case 3: temp = p3;
                 break;
         case 4: temp = p4;
                 break;
      }
      return temp;
   }

   void bump(int j)
   {
     getPawn(j).bump(x,y);
   }
}
