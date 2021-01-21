using System.Collections.Generic;
using System;
using OpenTK;

namespace Prog3
{
   /// <summary>
   /// Represents a list of Figures. Handles manipulation of all figures
   /// in the list: Move, Show, and Restore.
   /// </summary>
   class FigureList
   {

      const int RAND_MOVE = 4;
      const int RNDM = 0;
      const int FXD1 = 1;
      const int SINU = 2;
      const int FXD2 = 3;

      /// <summary>
      /// Struct. Holds a figure and its unique movement pattern.
      /// </summary>
      private struct FigureMovementPair
      {
         public Figure fig;
         public MovePattern movement;
      }        

      private List<FigureMovementPair> figlist = 
                     new List<FigureMovementPair>();

      /// <summary>
      /// Loads all the figures from the given folder. For each figure in the
      /// folder, a random movement pattern is assigned.
      /// </summary>
      /// <param name="folderName"> The folder where the figures are located. </param>
      public void LoadFigures(string folderName)
      {
         //read in all WRL files
         String[] files = System.IO.Directory.GetFiles(folderName, ".wrl");

         foreach (String file in files)
         {
            Random rnd = new Random();
            int pattern = rnd.Next(RAND_MOVE);
            MovePattern move = new RandomMovePattern();
            switch (pattern)
            {
               case RNDM:
               {
                  move = new RandomMovePattern();
                  break;
               }
               case FXD1:
               {
                  move = new FixedMovePattern1();
                  break;
               }
               case SINU:
               {
                  move = new SinusoidalMovePattern();
                  break;
               }
               case FXD2:
               {
                  move = new FixedMovePattern2();
                  break;
               }
            }

            figlist.Add(new FigureMovementPair { fig = new Figure(file), movement = move });
         }
      }

      /// <summary>
      /// Shows all the figures in figlist.
      /// </summary>
      public void Show(Matrix4 look_at)
      {
         foreach (FigureMovementPair f in figlist)
         {
            f.fig.Show(look_at);
         }
      }

      /// <summary>
      /// Moves all the figures in figlist.
      /// </summary>
      public void Move()
      {
         foreach (FigureMovementPair f in figlist)
         {
            f.fig.Move();
         }
      }

      /// <summary>
      /// Restores all the figures in figlist.
      /// </summary>
      public void Restore()
      {
         foreach (FigureMovementPair f in figlist)
         {
            f.fig.Restore();
         }
      }
   }
}
