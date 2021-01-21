/// Program:   Program 5
/// Class:     CS3920
/// File:      FigureList.cs: 
///            Represents a list of figures. Each figure has a
///            movement pattern assigned to it. The list can be
///            loaded, shown, moved, and restored.
/// Authors:   Brianna Muleski, Lucas Gangstad
using System.Collections.Generic;
using System;
using OpenTK;

namespace Prog5
{
   /// <summary>
   /// Represents a list of Figures. Handles manipulation of all figures
   /// in the list: Move, Show, and Restore.
   /// </summary>
   class FigureList
   {
      const float INIT_BOUND = 50.0f;

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
      public void LoadFigures(string file, int num = 0)
      {
         Random rnd = new Random();

         for (int i = 0; i < num; i++)
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

            Figure fig;
            fig = new Figure(file);
            fig.Load();
            
            fig.Translate(new Vector3(((float)(rnd.NextDouble()) - 0.5f) * INIT_BOUND,
                              ((float)(rnd.NextDouble()) - 0.5f) * INIT_BOUND,
                              ((float)(rnd.NextDouble()) - 0.5f) * INIT_BOUND));
            Add(fig, move);
         }
         SetShine();
      }

      /// <summary>
      /// Removes a figure if it collided with another figure.
      /// </summary>
      /// <param name="list"> the list of figures to check for collision </param>
      /// <returns> number of collisions detected </returns>
      public int KillCollisions(FigureList list)
      {
         int count = 0;
         for (int i = figlist.Count - 1; i >= 0; i--)
         {
            bool collided = false;
            for (int j = 0; j < list.figlist.Count; j++)
            {
               if (figlist[i].fig.CollidesWith(list.figlist[j].fig))
               {
                  list.figlist.RemoveAt(j);
                  collided = true;
                  count++;
               }
            }
            if (collided)
               figlist.RemoveAt(i);
         }
         return count;
      }

      /// <summary>
      /// Adds the given figure to the list/
      /// </summary>
      /// <param name="fig"> figure to be added </param>
      /// <param name="movement"> the movement for the figure </param>
      /// <param name="lifetime"> the lifetime for the figure </param>
      public void Add(Figure fig, MovePattern movement, long lifetime = 0)
      {
         FigureMovementPair pair = new FigureMovementPair();
         pair.fig = fig;
         pair.movement = movement;
         pair.fig.Lifetime = lifetime;
         figlist.Add(pair);
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
         for (int i = figlist.Count - 1; i >= 0; i--)
         {
            figlist[i].movement.Move(figlist[i].fig);
            if (figlist[i].fig.Lifetime < 0)
            {
               figlist.RemoveAt(i);
            }
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

      /// <summary>
      /// Clears the list of figures.
      /// </summary>
      public void Clear()
      {
         figlist.Clear();
      }
   }
}
