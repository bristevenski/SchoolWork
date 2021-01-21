﻿/// Program:   Program 5
/// Class:     CS3920
/// File:      Ship.cs: 
///            Represents a ship that the user will control.
/// Authors:   Brianna Muleski, Lucas Gangstad
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Prog5
{
   class Ship
   {
      private float dirTheta;     // Theta for current direction
      private float dirPhi;       // Phi for current direction
      private Vector3 direction;  // Unit vector for direction ship is pointing
      private Vector3 position;   // Current position of ship
      private Vector3 up;
      private Vector3 max, min;   // Bounding Box of ship
      private static Ship _instance = null;   // Singleton instance – must be private!

      public static Ship Instance
      {
         get
         {
            if (_instance == null)
               _instance = new Ship();
            return _instance;
         }
      }

      public Vector3 BoundingBoxMax { get { return max; } }
      public Vector3 BoundingBoxMin { get { return min; } }
      public Vector3 Position { get { return position; } }
      public Vector3 Direction { get { return direction; } }

      private Ship()
      {
         Reset();
         min = new Vector3(0, 0, 0);
         max = new Vector3(1, 1, 1);    // Make it whatever size you want
         // Could have other things
      }

      public void Reset()
      {
         position = new Vector3(25, 25, 25);  // Start it wherever you want.
         direction = new Vector3(-1, 0, -1);
         up = new Vector3(0, 1, 0);

         // Looks back at origin.  You can have it point wherever you want.
         dirPhi = (float)Math.Acos(-position.Y / position.Length);
         dirTheta = (float)Math.Atan2(-position.X, -position.Z);

         ChangeDirection(0, 0);
      }

      public void ChangeDirection(float deltaTheta, float deltaPhi)
      {
         dirTheta += deltaTheta;
         dirPhi += deltaPhi;
         direction[1] = (float)Math.Cos(dirPhi);
         direction[0] = (float)(Math.Sin(dirPhi) * Math.Sin(dirTheta));
         direction[2] = (float)(Math.Sin(dirPhi) * Math.Cos(dirTheta));
         up[1] = (float)Math.Cos(dirPhi + Math.PI / 2);
         up[0] = (float)(Math.Sin(dirPhi + Math.PI / 2) * Math.Sin(dirTheta));
         up[2] = (float)(Math.Sin(dirPhi + Math.PI / 2) * Math.Cos(dirTheta));
      }

      public void Move(double amount)
      {
         // Change "position" by moving "amount" in "direction"
         for (int i = 0; i < 3; i++)
            position[i] += (float)(amount * direction[i]);
      }

      public void Strafe(double amount)
      {
         Vector3 right = Vector3.Normalize(Vector3.Cross(up, direction));
         for (int i = 0; i < 3; i++)
            position[i] += (float)(amount * right[i]);
      }

      public void Rise(double amount)
      {
         for (int i = 0; i < 3; i++)
            position[i] += (float)(amount * up[i]);
      }

      // Main form can call this to get the View Matrix
      public Matrix4 LookAt()
      {
         return Matrix4.LookAt(position[0], position[1], position[2],
            (float)(position[0] + Math.Sin(dirPhi) * Math.Sin(dirTheta)),
            (float)(position[1] + Math.Cos(dirPhi)),
            (float)(position[2] + Math.Sin(dirPhi) * Math.Cos(dirTheta)),
            up[0], up[1], up[2]);
      }
   }
}
