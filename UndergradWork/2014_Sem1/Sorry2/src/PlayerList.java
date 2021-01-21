import java.awt.Panel;

/**
This class represents a queue that contains the list of players. 
@author Brianna Muleski
*/
public class PlayerList
{
   private Player [] players;
   private int front, rear, count;
   private Player currentPlayer;
   
   /**
   Constructor that initializes the list and sets the front, rear, and count.
   @param numPlayers number of Players to add to the list
   */
   public PlayerList (int numPlayers)
   {
      players = new Player[numPlayers];
      front = rear = count = 0;
   }
   
   
   /**
   Checks if the PlayerList is empty or not.
   @return true if empty, false otherwise
   */
   public boolean isEmpty()
   {
      return count == 0;
   }
   
   /**
   Adds a Player to the rear of the queue and resets rear and count  
   @param p the Player being added
   */
   public void add ( Player p )
   {
      players[rear] = p;
      rear = (rear + 1) % players.length;
      ++count;
   } 
   
   /**
   Returns the current Player and sends that player to the end of the list
   @return the currentPlayer
   */
   public Player currentPlayer()
   {
      Player p = players[front];
      currentPlayer = p;
      front = (front + 1) % players.length;
      add(p);
      return p;
   }
   
   /**
   Removes the player in the front, resets front, and decrements count.
   @return the player removed
   */
   public Player remove()
   {
      Player p = players[front];
      front = (front + 1) % players.length;
      --count;
      return p;     
   }
   
   /**
   Returns the current player.
   @return the current player
   */
   public Player getCurrent()
   {
      return currentPlayer;
   }
   
   /**
   Clears the PlayerList and resets the count, front, and rear.
   */
   public void clear()
   {
      for(int i = 0; i < players.length; i++)
         players[i] = null;
      count = front = rear = 0;
   }
   
   /**
   Moves a pawn the specific number of spaces
   @param pawn the pawn being moved
   @param spaces the number of spaces to move
   */
   public void moveP(int pawn, int spaces)
   {
      currentPlayer.movePawn(pawn, spaces);
   }
   
   /**
   Adds 4 pawns to each player in the list.
   @param sb the panel the pawns are drawn on
   */
   public void addPawns(Panel sb)
   {
      for(int i = 0; i < players.length; i++)
      {
         players[i].addPawns(sb);
      }
   }
   
   public void draw()
   {
            for(int i = 0; i < players.length; i++)
      {
         players[i].show();
      }
   }
   
   public int getNumPlayers()
   {
      return count;
   }

   public Player getPlayer(int i)
   {
      return players[i];
   }
   
   /**
   Testbed main. Tests all the constructors and methods in this class.
   @param args is not used
   */
   public static void main ( String args[] ) 
   {
      //Test for contructor
      PlayerList pl = new PlayerList(4);
      System.out.println("Test for constructor:");
      System.out.println("Expected: ");
      System.out.println("null null null null");
      System.out.println("Result: ");
      for (int i = 0; i < pl.players.length; i++)
         System.out.print(pl.players[i] + " ");
      System.out.println();
      System.out.println();
      
      //Test for isEmpty method
      System.out.println("Test for isEmpty method:");
      if (pl.isEmpty())
         System.out.println("isEmpty test passed.");
      else
         System.out.println("isEmpty test failed.");
      System.out.println();
      
      //Test for add method
      Player p1 = new Player("Bri", 1);
      pl.add(p1);
      Player p2 = new Player("Sam", 2);
      pl.add(p2);
      Player p3 = new Player("Mel", 1);
      pl.add(p3);
      System.out.println("Test for add method:");
      System.out.println("Expected:");
      System.out.println("Bri Sam Mel");
      System.out.println("Result:");
      for (int i = 0; i < pl.count; i++)
         System.out.print(pl.players[i].getName() + " ");
      System.out.println();
      System.out.println();
      
      //Test for currentPlayer method
      System.out.println("Test 1 for currentPlayer method:");
      System.out.println("Expected:");
      System.out.println("Current Player: Bri");
      System.out.println("Turn 2: Sam");  
      System.out.println("Turn 3: Mel");
      System.out.println("Turn 4: Bri");
      System.out.println("Result:");
      System.out.println("Current Player: " + pl.currentPlayer().getName());
      System.out.println("Turn 2: " + pl.currentPlayer().getName()); 
      System.out.println("Turn 3: " + pl.currentPlayer().getName());
      System.out.println("Turn 4: " + pl.currentPlayer().getName()); 
      System.out.println();

      //Test for clear method
      pl.add( new Player("Bri", 1) );
      pl.add( new Player("Sam", 2) );
      pl.add( new Player("Mel", 3) );
      pl.clear();
      System.out.println("Test for clear method:");
      System.out.println("Expected:");
      System.out.println("null null null null");
      System.out.println("count = 0");
      System.out.println("front = 0");
      System.out.println("rear = 0");
      System.out.println("Results:");
      for(int i = 0; i < pl.players.length; i++)
         System.out.print(pl.players[i] + " ");
      System.out.println();
      System.out.println("count = " + pl.count);
      System.out.println("front = " + pl.front);
      System.out.println("rear = " + pl.rear);
      
      //Test for remove method
      pl.add(new Player("a", 1) );
      pl.add(new Player("b", 2) );
      pl.add(new Player("c", 3) );
      pl.add(new Player("d", 4) );
      System.out.println("Test for remove method:");
      System.out.println("Expected:");
      System.out.println("a b c d");
      for(int i = 0; i < pl.players.length; i++)
         System.out.print(pl.remove().getName().toString() + " ");
   }
}

