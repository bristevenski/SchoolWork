// Put a comment block here!
// You must put a comment block on top of each class and also the methods.
// Look for ??? places to finish the code.
// Remove all my editorial comments from this file!

// To make a comment block above a class or method,
// type 3 slashes in the line above the class or method.
// Visual Studio will make a comment block.

using System.Collections.Generic;   // Use List Generic
using System.Drawing;               // Use Color and Point
using OpenTK.Graphics.OpenGL;       // Use the OpenGl control

namespace Figures
{
   public abstract class Figure
   {
      protected List<Point> pts = new List<Point>();   // List of points in the figure
      protected Color fgColor = Color.White;           // Color to draw figure in
      protected float lineWidth = 1.0F;                // Width of line segments

      public abstract void Show();                 

      public Color FGColor    // C# properties are neat!
      {
         get 
         { 
            return fgColor; 
         }
         set 
         { 
            fgColor = value; 
         }
      }

      public float LineWidth
      {
         get
         {
            return lineWidth;
         }
         set
         {
            lineWidth = value;
         }
      }

      public void AddPoint ( Point p ) 
      {
         pts.Add(p);
      }

      public void ReplacePoint ( Point p, int index ) 
      { 
         pts[index] = p; 
      }
   }

   // Note that the use of the "T" for 
   // type names is to avoid conflicts with 
   // System.Drawing objects with the same names.
   // That way the "user" can also say:  using Figures;

   public class TLine : Figure
   {
      public override void Show() 
      {
         TLine line = new TLine();

         GL.Begin(PrimitiveType.Lines);
         GL.LineWidth(lineWidth);
         GL.Color3(FGColor);
         
         //TODO: fix points
         GL.Vertex2(pts[0].X, pts[0].Y);
         GL.Vertex2(pts[pts.Count - 1].X, pts[pts.Count - 1].Y);
         GL.End();
      }
   }

   public class TRectangle : Figure
   {
      public override void Show()
      {
         TRectangle rect = new TRectangle();

         GL.Begin(PrimitiveType.Polygon);
         GL.LineWidth(lineWidth);
         GL.Color3(FGColor);

         //TODO: fix points
         GL.Vertex2(pts[pts.Count - 1].X, pts[pts.Count - 1].Y);
         GL.Vertex2(-pts[pts.Count - 1].Y, pts[pts.Count - 1].X);
         GL.Vertex2(-pts[0].Y, pts[0].X);
         GL.Vertex2(pts[0].X, pts[0].Y);
         GL.End();
      }
   }

}  // Name space Figures