/// Program:   Program 3
/// Class:     CS3920
/// File:      FigureList.cs: 
///            Represents a list of figures. Each figure has a
///            movement pattern assigned to it. The list can be
///            loaded, shown, moved, and restored.
/// Authors:   Brianna Muleski, Lucas Gangstad
using System.Collections.Generic;
using System;
using OpenTK;

namespace Prog4
{
   /// <summary>
   /// Represents a list of Figures. Handles manipulation of all figures
   /// in the list: Move, Show, and Restore.
   /// </summary>
   class FigureList
   {
      const float INIT_BOUND = 15.0f;

      const float MAX_SHINY = 150.0f;
      const float MIN_SHINY = 50.0f;

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
      /// folder, a random movement pattern is assigned. The figure is then 
      /// added to the figlist, and the shine for each figure is set.
      /// </summary>
      /// <param name="folderName"> The folder where the figures are located. </param>
      public void LoadFigures(string folderName)
      {
         //read in all WRL files
         String[] files = System.IO.Directory.GetFiles(folderName, "*.wrl");
         Random rnd = new Random();

         foreach (String file in files)
         {
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

            FigureMovementPair pair = new FigureMovementPair { fig = new Figure(file), movement = move };
            pair.fig.Load();
            pair.fig.Translate(new Vector3(((float)(rnd.NextDouble()) - 0.5f) * INIT_BOUND, 
                              ((float)(rnd.NextDouble()) - 0.5f) * INIT_BOUND, 
                              ((float)(rnd.NextDouble()) - 0.5f) * INIT_BOUND));
            figlist.Add(pair);
         }
         SetShine();
      }

      /// <summary>
      /// Sets the shine of each figure in the figure list to a random number in the range [0.0, 1.0).
      /// Ensures that at least 2 and at most 50% of the figures are shiny.
      /// </summary>
      private void SetShine()
      {
         Random rnd = new Random();
         float shine = 0.0f;
         if (figlist.Count > 2)
         {
            int num = 0;
            foreach (FigureMovementPair pair in figlist)
            {
               shine = 0.0f;
               if (num % 2 != 0) //ensure 50% (rounded down) of the objects are shiny
               {
                  shine = (float)rnd.NextDouble() * MAX_SHINY;
                  if (shine < MIN_SHINY) //ensure there is some shininess for the figure
                  {
                     shine += MIN_SHINY;
                  }
               }
               pair.fig.Shininess = shine;
               num++;
            }
         }
         else
         {
            foreach (FigureMovementPair pair in figlist)
            {
               shine = (float)rnd.NextDouble() * MAX_SHINY;
               if (shine < MIN_SHINY) //ensure there is some shininess for the figure
               {
                  shine += MIN_SHINY;
               }
               pair.fig.Shininess = shine;
            }
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
      /// Moves all the figures in figlist based on its assigned movement.
      /// </summary>
      public void Move()
      {
         foreach (FigureMovementPair f in figlist)
         {
            f.movement.Move(f.fig);
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
