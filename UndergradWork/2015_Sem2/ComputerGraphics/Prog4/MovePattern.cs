/// Program:   Program 4
/// Class:     CS3920
/// File:      MovePattern.cs: 
///            Handles all the movement patterns for the figures. Uses
///            different patterns of translations, rotations, and scalings.
/// Authors:   Brianna Muleski, Lucas Gangstad
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace Prog4
{

   /// <summary>
   /// Abstract class. Represents a movement pattern for a figure.
   /// </summary>
   abstract class MovePattern
   {
      abstract public void Move(Figure fig);
   }

   /// <summary>
   /// Decsendant of abstract MovePattern class. Creates a movement pattern
   /// using randomly generated translation amounts and rotation amounts.
   /// </summary>
   class RandomMovePattern : MovePattern
   {
      protected static Random rand = new Random();

      private const float TRANS_MULT = 1f;
      private const float ROT_MULT = 0.2f;
      private const float LIMIT = 15.0f;

      private float x = 0;
      private float y = 0;
      private float z = 0;

      private int xDir = 1;
      private int yDir = 1;
      private int zDir = 1;

      /// <summary>
      /// Moves the figure based on the randomly generated translation and
      /// rotation amounts. Uses a limit for the translations to keep the
      /// figure within a certain bound in each direction. Translates and
      /// Rotates in all 3 axes.
      /// </summary>
      /// <param name="fig"> the figure doing the movement </param>
      public override void Move(Figure fig)
      {
         float trans_x = (float)(rand.NextDouble()) * xDir * TRANS_MULT;
         float trans_y = (float)(rand.NextDouble()) * yDir * TRANS_MULT;
         float trans_z = (float)(rand.NextDouble()) * zDir * TRANS_MULT;

         x += trans_x;
         y += trans_y;
         z += trans_z;
         if ((x >= LIMIT && xDir > 0) || (x < 0 && xDir < 0))
            xDir *= -1;
         if ((y >= LIMIT && yDir > 0) || (y < 0 && yDir < 0))
            yDir *= -1;
         if ((z >= LIMIT && zDir > 0) || (z < 0 && zDir < 0))
            zDir *= -1;

         fig.Translate(new Vector3(trans_x, trans_y, trans_z));

         float rot_x = ((float)(rand.NextDouble()) - 0.5f) * ROT_MULT;
         float rot_y = ((float)(rand.NextDouble()) - 0.5f) * ROT_MULT;
         float rot_z = ((float)(rand.NextDouble()) - 0.5f) * ROT_MULT;

         fig.RotateX(rot_x);
         fig.RotateY(rot_y);
         fig.RotateZ(rot_z);
      }
   }

   /// <summary>
   /// Decsendant of abstract MovePattern class. Creates a movement pattern
   /// using fixed translation amounts and scale amounts.
   /// </summary>
   class FixedMovePattern1 : MovePattern
   {
      private const float Z_DIST = 0.2f;
      private const float LIMIT = 25.0f;
      private const float SCALE_MULT = 1.015f;

      private float z = 0.0f;

      private int zDir = 1;

      /// <summary>
      /// Moves the figure based on the fixed translation and
      /// scale amounts. Uses a limit for the translation to keep the
      /// figure within a certain bound. Translates in z-direction only,
      /// keeping x and y intact. Scales in z-direction only, keeping x
      /// and y intact.
      /// </summary>
      /// <param name="fig"> the figure doing the movement </param>
      public override void Move(Figure fig)
      {
         float trans_z = (float)(zDir * Z_DIST);

         z += trans_z;
         if ((z >= LIMIT && zDir > 0) || (z < 0 && zDir < 0))
            zDir *= -1;

         fig.Translate(new Vector3(0.0f, 0.0f, trans_z));
         fig.Scale(new Vector3(1.0f, 1.0f, (float)Math.Pow(SCALE_MULT, zDir)));
      }
   }

   /// <summary>
   /// Decsendant of abstract MovePattern class. Creates a movement pattern
   /// using a sinusoidal translation movement along with a fixed rotation.
   /// </summary>
   class SinusoidalMovePattern : MovePattern
   {
      private const float DIST = 0.3f;
      private const float Y_DIST = 0.5f;
      private const float LIMIT = 20.0f;
      private const float ROT_Y = 0.3f;

      private float x = 0.0f;

      private int xDir = 1;

      /// <summary>
      /// Moves the figure based a sinusoidal translation. Creates a
      /// "wave" like movement. Rotates the figure during this translation
      /// in the around the y-axis.
      /// </summary>
      /// <param name="fig"> the figure doing the movement </param>
      public override void Move(Figure fig)
      {
         float trans_x = (float)(xDir * DIST);
         float trans_z = -(float)(xDir * DIST);
         float trans_y = (float)Math.Sin(x) * Y_DIST;

         x += trans_x;
         if ((x >= LIMIT && xDir > 0) || (x < 0 && xDir < 0))
            xDir *= -1;

         fig.Translate(new Vector3(trans_x, trans_y, trans_z));
         fig.RotateY(ROT_Y);
      }
   }

   /// <summary>
   /// Decsendant of abstract MovePattern class. Creates a movement pattern
   /// using fixed translation amounts and rotation amounts.
   /// </summary>
   class FixedMovePattern2 : MovePattern
   {
      private const float DIST = 0.2f;
      private const float LIMIT = 10.0f;
      private const float ROTATE = 0.8f;

      private float y = 0.0f;
      private float z = 0.0f;

      private float y_dir = 1.0f;
      private float z_dir = 1.0f;

      /// <summary>
      /// Moves the figure based on the fixed translation and
      /// rotation amounts. Uses a limit for the translations to keep the
      /// figure within a certain bound in both y and z directions. Translates 
      /// in the y and z directions, leaving x intact. Rotates around the 
      /// x-axis.
      /// </summary>
      /// <param name="fig"> the figure doing the movement </param>
      public override void Move(Figure fig)
      {
         float trans_y = (float)(y_dir * DIST);
         float trans_z = (float)(z_dir * DIST);

         y += trans_y;
         z += trans_z;
         if ((y >= LIMIT && y_dir > 0) || (y < 0 && y_dir < 0))
            y_dir *= -1;
         if ((z >= LIMIT && z_dir > 0) || (z < 0 && z_dir < 0))
            z_dir *= -1;

         fig.Translate(new Vector3(0.0f, trans_y, trans_z));
         fig.RotateX(ROTATE);
      }
   }
}
