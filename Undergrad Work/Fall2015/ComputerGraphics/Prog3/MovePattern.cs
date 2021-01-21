using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;


namespace Prog3
{
   abstract class MovePattern
   {
      abstract public void Move(Figure fig);  
   }


   class RandomMovePattern : MovePattern
   {
      const int RAND_MULT = 20;

      public override void Move(Figure fig)
      {
         Random rand;
         float trans_x = (float) rand.NextDouble() * RAND_MULT;
         float trans_y = (float) rand.NextDouble() * RAND_MULT;
         float trans_z = (float) rand.NextDouble() * RAND_MULT;
         fig.Translate(trans_x, trans_y, trans_z);
         //TODO: some random rotations and scalings
      }
   }

   class FixedMovePattern1 : MovePattern
   {
      // You can declare whatever state variables you need to define the move

      public override void Move(Figure fig)
      {
         // Want rotates, scales, translates - clever moves!
         // As an example of a start - move a little in the X.
         fig.Translate(0.1f, 0, 0);
      }
   }

   class SinusoidalMovePattern : MovePattern
   {
      // You can declare whatever state variables you need to define the move

      public override void Move(Figure fig)
      {
         // Want rotates, scales, translates - clever moves!
         // As an example of a start - move a little in the X.
         fig.Translate(0.1f, 0, 0);
      }
   }

   class FixedMovePattern2 : MovePattern
   {
      // You can declare whatever state variables you need to define the move

      public override void Move(Figure fig)
      {
         // Want rotates, scales, translates - clever moves!
         // As an example of a start - move a little in the X.
         fig.Translate(0.1f, 0, 0);
      }
   }
}
