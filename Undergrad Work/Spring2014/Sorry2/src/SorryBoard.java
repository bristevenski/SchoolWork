import java.awt.event.*;
import javax.swing.JOptionPane;
/**
 *
 * @author andreskis
 */
public class SorryBoard extends javax.swing.JFrame 
                  implements java.awt.event.ActionListener
{
   private int numPlayers;
   private final int PWN2 = 2;
   private final int PWN3 = 3;
   private final int PWN4 = 4;
   private SFigure CP[] = new SFigure [4];
   private SFigure pawn[] = new SFigure [12];
   private SFigure b;
   private Deck deck;
   private SFigure figure[];
   private boolean running = true, inHome = false;
   private Game game;
   private int currentCard;
   private PlayerList pList;
   private PlayerList second = new PlayerList(3);
   private PlayerList third = new PlayerList(2);
   private Player currentP, winner, fourth;
   private int turn = 0;
   private int time = 100;
   private javax.swing.Timer moveTimer = new javax.swing.Timer(time, this);
   private Object playChoice[];
   
   

   /**
   
   @param list 
   */
   public SorryBoard(PlayerList list)
   {
      setVisible(true);
      initComponents();
      numPlayers = list.getNumPlayers();
      moveTimer.start();
      deck = new Deck();
      pList = list;
      panelSB.requestFocus();
      b = new Board(panelSB); 
      b.draw();
      pList.addPawns(panelSB);
      pList.draw();
      currentP = pList.getPlayer(0);
      currentPlyr.setText(currentP.getName());
      disableButtons();
      //game.run();
      
   }

   public SorryBoard()
   {
      
   }
   
   public void move(int pawn)
   {
      inHome = currentP.movePawn(pawn, currentCard);//pawn is in the home space, disable the pawn button
      if( inHome )
         currentP.disablePawn(pawn);
      pList.currentPlayer();
      nextPlayer();
   }

   private void nextPlayer()
   {
      if( winner() )
      {
         disableButtons();
         btnDraw.setEnabled(false);
         JOptionPane.showMessageDialog(jpane1, "The Winner is "
                       + winner.getName() + "!!!!!");
      }
      else
      {
         turn++; // hack fix, do better     
         if(turn == 1)
         {
            pList.currentPlayer();
            currentP = pList.getCurrent();
            currentPlyr.setText(currentP.getName());
         }
         currentP = pList.getCurrent();
         currentPlyr.setText(currentP.getName());   

         disableButtons();
         btnDraw.setEnabled(true);
      }
   }
   
   private boolean winner()
   {
      if( currentP.get1Home() && currentP.get2Home() 
          && currentP.get3Home() && currentP.get4Home() )
      {
         winner = currentP;
         //determinePlaces();
        return true;
      }
      else
         return false;
   }
// 
//   private void determinePlaces()
//   {
//      int indxWinner = winner.getNum();
//      Player plyr2, plyr3, plyr4;
//      
//      
//      if( numPlayers == 2 )
//      {
//         if( indxWinner == 1)
//            plyr2 = pList.getPlayer(0);
//         else
//            plyr2 = pList.getPlayer(1);
//         second.add(plyr2);
//      }
//      else if ( numPlayers == 3 )
//      {
//         if( indxWinner == 1 )
//         {
//            plyr2 = pList.getPlayer(0);
//            plyr3 = pList.getPlayer(2);
//         }
//         else if( indxWinner == 2 )
//         {
//            plyr2 = pList.getPlayer(0);
//            plyr3 = pList.getPlayer(1);
//         }
//         else
//         {
//            plyr2 = pList.getPlayer(1);
//            plyr3 = pList.getPlayer(2);
//         }
//         places3Players(plyr2, plyr3);
//      }
//      else
//      {
//         if( indxWinner == 1 )
//         {
//            plyr2 = pList.getPlayer(0);
//            plyr3 = pList.getPlayer(2);
//            plyr4 = pList.getPlayer(3);
//         }
//         else if( indxWinner == 2 )
//         {
//            plyr2 = pList.getPlayer(0);
//            plyr3 = pList.getPlayer(1);
//            plyr4 = pList.getPlayer(3);
//         }
//         else if( indxWinner == 3 )
//         {
//            plyr2 = pList.getPlayer(1);
//            plyr3 = pList.getPlayer(2);
//            plyr4 = pList.getPlayer(4);
//         }
//         else
//         {
//            plyr2 = pList.getPlayer(1);
//            plyr3 = pList.getPlayer(2);
//            plyr4 = pList.getPlayer(3);
//         }
//         places4Players(plyr2, plyr3, plyr4);
//      }
//   }
//   
//   private void places3Players(Player p2, Player p3)
//   {
//      int p2InHome = getNumberInHome(p2);
//      int p3InHome = getNumberInHome(p3);
//
//      if( p3InHome > p2InHome )
//      {
//         second.add(p3);
//         third.add(p2);
//      }
//      else if ( p3InHome < p2InHome )
//      {
//         second.add(p2);
//         third.add(p3);
//      }
//      else
//      {
//         second.add(p2);
//         second.add(p3);
//      }
//   }
//   
//   private void places4Players(Player p2, Player p3, Player p4)
//   {
//      int p2InHome = getNumberInHome(p2);
//      int p3InHome = getNumberInHome(p3);
//      int p4InHome = getNumberInHome(p4);
//
//      if( p2InHome > p3InHome )
//      {
//         if( p2InHome > p4InHome )
//         {
//            second.add(p2);
//            if( p3InHome > p4InHome )
//            {
//               third.add(p3);
//               fourth = p4;
//            }
//            else if ( p3InHome < p4InHome )
//            {
//               third.add(p4);
//               fourth = p3;
//            }
//            else
//            {
//               third.add(p3);
//               third.add(p4);
//            }
//         }
//         else if( p2InHome < p4InHome )
//         {
//            second.add(p4);
//            third.add(p2);
//            fourth = p3;
//         }
//         else
//         {
//            second.add(p2);
//            second.add(p4);
//            fourth = p3;
//         }
//      }
//      else if ( p3InHome > p2InHome )
//      {
//         if( p3InHome > p4InHome )
//         {
//            second.add(p3);
//            if( p2InHome > p4InHome )
//            {
//               third.add(p2);
//               fourth = p4;
//            }
//            else if ( p2InHome < p4InHome )
//            {
//               third.add(p4);
//               fourth = p2;
//            }
//            else
//            {
//               third.add(p2);
//               third.add(p4);
//            }
//         }
//         else if( p3InHome < p4InHome )
//         {
//            second.add(p4);
//            third.add(p3);
//            fourth = p2;
//         }
//         else
//         {
//            second.add(p3);
//            second.add(p4);
//            fourth = p2;
//         }
//      }
//      else if( p2InHome == p3InHome )
//      {
//         if( p2InHome == p4InHome )
//         {
//            second.add(p2);
//            second.add(p3);
//            second.add(p4);
//         }
//         else
//         {
//            second.add(p2);
//            second.add(p3);
//            fourth = p4;
//         }
//
//      }
//
//   }
//   
//   private int getNumberInHome(Player p)
//   {
//      int num = 0;
//      if( p.get1Home() )
//         num++;
//      if( p.get2Home() )
//         num++;
//      if( p.get3Home() )
//         num++;
//      if( p.get4Home() )
//         num++;
//      return num;
//   }
   
   private void disableButtons()
   {
      btnpawn1.setEnabled(false);
      btnpawn2.setEnabled(false);
      btnpawn3.setEnabled(false);
      btnpawn4.setEnabled(false);
   }
   
   private void enableButtons()
   {
      if( !currentP.get1Home() )
         btnpawn1.setEnabled(true);
      if( !currentP.get2Home() )
         btnpawn2.setEnabled(true);
      if( !currentP.get3Home() )
         btnpawn3.setEnabled(true);
      if( !currentP.get4Home() )
         btnpawn4.setEnabled(true);
   }
   
   private void drawCard()
   {
      currentCard = b.getCard();
      System.out.println(currentCard);
      if( currentCard == 13 )
         sorryCard();
      else
      {
         NumCard nc = new NumCard(currentCard);
         nc.draw(cardPanel);
        btnDraw.setEnabled(false);
        enableButtons();
      }
   }
   
   
   private void sorryCard()
   {
      int plyrNum = currentP.getNum(), plyrIndx;
      SorryCard sc = new SorryCard();
      sc.draw(cardPanel);
      if(numPlayers == 2)
      {
         playChoice = new Object[1];
         if( plyrNum == 1 )
         {
            plyrIndx = 1;
            playChoice[0] = "Player 2";
         }
         else
         {
            playChoice[0] = "Player 1";
            plyrIndx = 0;
         }
         int playBump = JOptionPane.showOptionDialog(this, 
         "Pick a Player to bump", "Sorry Card", JOptionPane.YES_NO_CANCEL_OPTION,
         JOptionPane.DEFAULT_OPTION, null, playChoice, playChoice[0]);
      }
      else if (numPlayers == 3)
         plyrIndx = sorry3Plyrs(plyrNum);

      else
         plyrIndx = sorry4Plyrs(plyrNum);
      
      Pawn pwn1 = pList.getPlayer(plyrIndx).getPawn(1);
      boolean p1bump = pwn1.bumpable(pList.getPlayer(plyrIndx).getColor());
            Pawn pwn2 = pList.getPlayer(plyrIndx).getPawn(2);
      boolean p2bump = pwn2.bumpable(pList.getPlayer(plyrIndx).getColor());
            Pawn pwn3 = pList.getPlayer(plyrIndx).getPawn(3);
      boolean p3bump = pwn3.bumpable(pList.getPlayer(plyrIndx).getColor());
            Pawn pwn4 = pList.getPlayer(plyrIndx).getPawn(4);
      boolean p4bump = pwn4.bumpable(pList.getPlayer(plyrIndx).getColor());
      
      if( !p1bump && !p2bump && !p3bump && !p4bump )        
         JOptionPane.showMessageDialog(jpane1, "Error: no available moves!"); 

      else
      {
         boolean error = true;
         while( error )
         {
            Object[] pawnChoice = {"Pawn 1", "Pawn 2", "Pawn 3", "Pawn 4"};
            int pawnBump = JOptionPane.showOptionDialog(this, 
               "Pick a Pawn to bump", "Sorry Card", 
               JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.DEFAULT_OPTION,
               null, pawnChoice, pawnChoice[0]);
            if( pawnBump == 0 )
            {
               if( !p1bump )
               {
                  JOptionPane.showMessageDialog(jpane1, "Error: you cannot "
                                                         + "move that pawn");
                  error = true;
               }
               else
                  error = false;
            }
            else if( pawnBump == 1 )
            {
               if( !p2bump )
               {
                  JOptionPane.showMessageDialog(jpane1, "Error: you cannot "
                                                         + "move that pawn");
                  error = true;
               }
               else
                  error = false;
            }
            else if( pawnBump == 2 )
            {
               if( !p3bump )
               {
                  JOptionPane.showMessageDialog(jpane1, "Error: you cannot "
                                                         + "move that pawn");
                  error = true;
               }
               else
                  error = false;
            }
            else
            {
               if( !p4bump )
               {
                  JOptionPane.showMessageDialog(jpane1, "Error: you cannot "
                                                         + "move that pawn");
                  error = true;
               }
               else
                  error = false;
            }
         }
      }
      System.out.println(currentCard);
      btnDraw.setEnabled(true);
      disableButtons();
      pList.currentPlayer();
      nextPlayer();  
   }
   

   private int sorry3Plyrs( int plyrNum )
   {
      int option, plyrIndx = 0;
      playChoice = new Object[2];
      if( plyrNum == 1 )
      {
         playChoice[0] = "Player 2";
         playChoice[1] = "Player 3";
         option = 1;
         
      }
      else if( plyrNum == 2 )
      {
         playChoice[0] = "Player 1";
         playChoice[1] = "Player 3"; 
         option = 2;
      }
      else
      {
         playChoice[0] = "Player 1";
         playChoice[1] = "Player 2";
         option = 3;
      }
      
      int playBump = JOptionPane.showOptionDialog(this, 
      "Pick a Player to bump", "Sorry Card", JOptionPane.YES_NO_CANCEL_OPTION,
      JOptionPane.DEFAULT_OPTION, null, playChoice, playChoice[0]);
      if( option == 1 )
      {
         if( playBump == 0 )
            plyrIndx = 1;
         else
            plyrIndx = 2;
      }
      else if( option == 2 )
      {
         if( playBump == 0 )
            plyrIndx = 0;
         else
            plyrIndx = 2;
      }
      else if( option == 3 )
      {
         if( playBump == 0 )
            plyrIndx = 0;
         else
            plyrIndx = 1;
      }
      return plyrIndx;
   }
   
   private int sorry4Plyrs( int plyrNum )
   {
      int option, plyrIndx = 0;
      playChoice = new Object[3];
      if( plyrNum == 1 )
      {
         playChoice[0] = "Player 2";
         playChoice[1] = "Player 3";
         playChoice[2] = "Player 4";
         option = 1;
      }
      else if( plyrNum == 2 )
      {
         playChoice[0] = "Player 1";
         playChoice[1] = "Player 3"; 
         playChoice[2] = "Player 4";
         option = 2;
      }
      else if( plyrNum == 3 )
      {
         playChoice[0] = "Player 1";
         playChoice[1] = "Player 2";
         playChoice[2] = "Player 4";
         option = 3;
      } 
      else
      {
         playChoice[0] = "Player 1";
         playChoice[1] = "Player 2";
         playChoice[2] = "Player 3";   
         option = 4;
      }   
      
      int playBump = JOptionPane.showOptionDialog(this, 
      "Pick a Player to bump", "Sorry Card", JOptionPane.YES_NO_CANCEL_OPTION,
      JOptionPane.DEFAULT_OPTION, null, playChoice, playChoice[0]);
      if( option == 1)
      {
         if( playBump == 0 )
            plyrIndx = 1;
         else if( playBump == 1 )
            plyrIndx = 2;
         else
            plyrIndx = 3;
      }
      else if( option == 2 )
      {
         if( playBump == 0 )
            plyrIndx = 0;
         else if( playBump == 1 )
            plyrIndx = 2;
         else
            plyrIndx = 3;
      }
      else if( option == 3 )
      {
         if( playBump == 0 )
            plyrIndx = 0;
         else if( playBump == 1 )
            plyrIndx = 1;
         else
            plyrIndx = 3;
      }
      else if( option == 4)
      {
         if( playBump == 0 )
            plyrIndx = 0;
         else if( playBump == 1 )
            plyrIndx = 1;
         else
            plyrIndx = 2;
      }
      return plyrIndx;
   }
   /**
    * This method is called from within the constructor to initialize the
    * form. WARNING: Do NOT modify this code. The content of this method is
    * always regenerated by the Form Editor.
    */
   @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        btnDraw = new javax.swing.JButton();
        btnpawn1 = new javax.swing.JButton();
        btnpawn2 = new javax.swing.JButton();
        btnpawn3 = new javax.swing.JButton();
        btnpawn4 = new javax.swing.JButton();
        panelSB = new java.awt.Panel();
        jpane1 = new javax.swing.JLayeredPane();
        jTextField1 = new javax.swing.JTextField();
        currentPlyr = new javax.swing.JTextField();
        resetButton = new javax.swing.JButton();
        quitButton = new javax.swing.JButton();
        cardPanel = new java.awt.Panel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setName("Board"); // NOI18N
        setPreferredSize(new java.awt.Dimension(1200, 820));
        setResizable(false);

        btnDraw.setText("Draw Card");
        btnDraw.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnDrawActionPerformed(evt);
            }
        });

        btnpawn1.setText("Move Pawn 1");
        btnpawn1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnpawn1ActionPerformed(evt);
            }
        });

        btnpawn2.setText("Move Pawn 2");
        btnpawn2.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnpawn2ActionPerformed(evt);
            }
        });

        btnpawn3.setText("Move Pawn 3");
        btnpawn3.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnpawn3ActionPerformed(evt);
            }
        });

        btnpawn4.setText("Move Pawn 4");
        btnpawn4.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnpawn4ActionPerformed(evt);
            }
        });

        panelSB.setBackground(new java.awt.Color(51, 51, 51));
        panelSB.setMaximumSize(new java.awt.Dimension(850, 800));
        panelSB.setMinimumSize(new java.awt.Dimension(850, 800));
        panelSB.setPreferredSize(new java.awt.Dimension(850, 800));

        javax.swing.GroupLayout panelSBLayout = new javax.swing.GroupLayout(panelSB);
        panelSB.setLayout(panelSBLayout);
        panelSBLayout.setHorizontalGroup(
            panelSBLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(panelSBLayout.createSequentialGroup()
                .addGap(105, 105, 105)
                .addComponent(jpane1, javax.swing.GroupLayout.PREFERRED_SIZE, 353, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(392, Short.MAX_VALUE))
        );
        panelSBLayout.setVerticalGroup(
            panelSBLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(panelSBLayout.createSequentialGroup()
                .addGap(96, 96, 96)
                .addComponent(jpane1, javax.swing.GroupLayout.PREFERRED_SIZE, 129, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(575, Short.MAX_VALUE))
        );

        jTextField1.setBackground(new java.awt.Color(240, 240, 240));
        jTextField1.setFont(new java.awt.Font("Tahoma", 1, 24)); // NOI18N
        jTextField1.setText("Current Player:");
        jTextField1.setBorder(null);
        jTextField1.setDisabledTextColor(new java.awt.Color(0, 0, 0));
        jTextField1.setEnabled(false);

        currentPlyr.setBackground(new java.awt.Color(240, 240, 240));
        currentPlyr.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        currentPlyr.setBorder(null);
        currentPlyr.setDisabledTextColor(new java.awt.Color(0, 0, 0));
        currentPlyr.setEnabled(false);

        resetButton.setFont(new java.awt.Font("Tahoma", 1, 18)); // NOI18N
        resetButton.setForeground(new java.awt.Color(51, 51, 255));
        resetButton.setText("Reset");
        resetButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                resetButtonActionPerformed(evt);
            }
        });

        quitButton.setFont(new java.awt.Font("Tahoma", 1, 18)); // NOI18N
        quitButton.setForeground(new java.awt.Color(255, 0, 0));
        quitButton.setText("Quit");
        quitButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                quitButtonActionPerformed(evt);
            }
        });

        cardPanel.setPreferredSize(new java.awt.Dimension(250, 350));

        javax.swing.GroupLayout cardPanelLayout = new javax.swing.GroupLayout(cardPanel);
        cardPanel.setLayout(cardPanelLayout);
        cardPanelLayout.setHorizontalGroup(
            cardPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 250, Short.MAX_VALUE)
        );
        cardPanelLayout.setVerticalGroup(
            cardPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 350, Short.MAX_VALUE)
        );

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addComponent(panelSB, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(btnDraw, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(currentPlyr, javax.swing.GroupLayout.PREFERRED_SIZE, 286, javax.swing.GroupLayout.PREFERRED_SIZE)
                                        .addGap(0, 0, Short.MAX_VALUE))
                                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                                                .addComponent(btnpawn3, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                                .addComponent(btnpawn1, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 152, Short.MAX_VALUE))
                                            .addComponent(resetButton, javax.swing.GroupLayout.PREFERRED_SIZE, 152, javax.swing.GroupLayout.PREFERRED_SIZE))
                                        .addGap(6, 6, Short.MAX_VALUE)
                                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(quitButton, javax.swing.GroupLayout.PREFERRED_SIZE, 152, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                                .addComponent(btnpawn4, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 152, Short.MAX_VALUE)
                                                .addComponent(btnpawn2, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)))))
                                .addGap(60, 60, 60))
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jTextField1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(33, 33, 33)
                        .addComponent(cardPanel, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(0, 0, Short.MAX_VALUE))))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(cardPanel, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(btnDraw, javax.swing.GroupLayout.PREFERRED_SIZE, 71, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btnpawn2, javax.swing.GroupLayout.PREFERRED_SIZE, 71, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(btnpawn1, javax.swing.GroupLayout.PREFERRED_SIZE, 71, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btnpawn3, javax.swing.GroupLayout.PREFERRED_SIZE, 71, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(btnpawn4, javax.swing.GroupLayout.PREFERRED_SIZE, 71, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(resetButton, javax.swing.GroupLayout.DEFAULT_SIZE, 68, Short.MAX_VALUE)
                    .addComponent(quitButton, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(jTextField1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(currentPlyr, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
            .addGroup(layout.createSequentialGroup()
                .addComponent(panelSB, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(0, 7, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

   private void btnpawn1ActionPerformed(java.awt.event.ActionEvent evt)//GEN-FIRST:event_btnpawn1ActionPerformed
   {//GEN-HEADEREND:event_btnpawn1ActionPerformed
      if( currentCard != 13 )
         move(1);
      else
      {
         pList.currentPlayer();
         nextPlayer();
      }
   }//GEN-LAST:event_btnpawn1ActionPerformed

   private void btnpawn2ActionPerformed(java.awt.event.ActionEvent evt) 
   {
      if( currentCard != 13 )
         move(PWN2);
      else
      {
         pList.currentPlayer();
         nextPlayer();
      }
   }
   private void btnpawn3ActionPerformed(java.awt.event.ActionEvent evt) 
   {
      if( currentCard != 13 )
         move(PWN3);
      else
      {
         pList.currentPlayer();
         nextPlayer();
      }
   }
   private void btnpawn4ActionPerformed(java.awt.event.ActionEvent evt)  
   {
      if( currentCard != 13 )
         move(PWN4);
      else
      {
         pList.currentPlayer();
         nextPlayer();
      }
   }
    
   private void btnDrawActionPerformed(java.awt.event.ActionEvent evt)//GEN-FIRST:event_btnDrawActionPerformed
   {//GEN-HEADEREND:event_btnDrawActionPerformed
      drawCard();
   }//GEN-LAST:event_btnDrawActionPerformed

    private void resetButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_resetButtonActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_resetButtonActionPerformed

    private void quitButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_quitButtonActionPerformed
        System.exit(0);
    }//GEN-LAST:event_quitButtonActionPerformed

   /**
    * @param args the command line arguments
    */
   public static void main(String args[])
   {
      /* Set the Nimbus look and feel */
      //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
       * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
       */
      try
      {
         for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels())
         {
            if ("Nimbus".equals(info.getName()))
            {
               javax.swing.UIManager.setLookAndFeel(info.getClassName());
               break;
            }
         }
      }
      catch (ClassNotFoundException ex)
      {
         java.util.logging.Logger.getLogger(SorryBoard.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
      }
      catch (InstantiationException ex)
      {
         java.util.logging.Logger.getLogger(SorryBoard.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
      }
      catch (IllegalAccessException ex)
      {
         java.util.logging.Logger.getLogger(SorryBoard.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
      }
      catch (javax.swing.UnsupportedLookAndFeelException ex)
      {
         java.util.logging.Logger.getLogger(SorryBoard.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
      }
      //</editor-fold>

      /* Create and display the form */
      java.awt.EventQueue.invokeLater(new Runnable()
      {
         @Override
         public void run()
         {
            new SorryBoard().setVisible(true);
            
         }
      });
   }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnDraw;
    private javax.swing.JButton btnpawn1;
    private javax.swing.JButton btnpawn2;
    private javax.swing.JButton btnpawn3;
    private javax.swing.JButton btnpawn4;
    private java.awt.Panel cardPanel;
    private javax.swing.JTextField currentPlyr;
    private javax.swing.JTextField jTextField1;
    private javax.swing.JLayeredPane jpane1;
    private java.awt.Panel panelSB;
    private javax.swing.JButton quitButton;
    private javax.swing.JButton resetButton;
    // End of variables declaration//GEN-END:variables

   @Override
   public void actionPerformed(ActionEvent ae)
   {
      refresh();
      this.repaint();
      try
      {
         collision();
      }
      catch (Exception ex)
      {
         System.out.println(ex);
      }
      
   }

   private void refresh()
   {
      b.draw();
      pList.draw();
   }

   private void collision()
   {
      for (int i = 0; i < PWN4; i++)
      {
         CP[i] = currentP.getPawn(i);
      }
      for (int i = 0; i < PWN4; i++)
      {
         if (!currentP.equals(pList.getPlayer(i)))
         {
            for (int j = 0; j < PWN4; j++)
            {
               if(currentP.getPawn(i).collidedWith(pList.getPlayer(i).getPawn(j)))
               {
                  pList.getPlayer(i).bump(j);
               }
            }
         }
      }
   }
}
