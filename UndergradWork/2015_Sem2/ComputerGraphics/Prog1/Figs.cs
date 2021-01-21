/// Program:   Program 1
/// Class:     CS3920
/// File:      Figs.cs: 
///            Figs.cs contains the attributes and functions of the namepsace
///            figures and its classes: abstract class Figure, class TLine and
///            class TRectangle. TLine and TRectangle inherit Figure.
/// Author:    Brianna Muleski

using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace Figures
{
   /// <summary>
   /// Figure represents a figure using OpenTK. The figure has the following
   /// attributes: a list of points that make up the figure, the color of the
   /// figure, and the width of the lines that make up the figure. All
   /// attributes can be set and retreived outside of the class. The figure can
   /// be shown on a GL control object.
   /// </summary>
   public abstract class Figure
   {
      protected List<Point> pts = new List<Point>();
      protected Color fgColor = Color.White;
      protected float lineWidth = 1.0F;

      /// <summary>
      /// Draws the figure using openTK and openGL with the attributes
      /// specified.
      /// </summary>
      public abstract void Show();                 

      /// <summary>
      /// Gets and sets the color of the figure using Drawing.Color.
      /// </summary>
      public Color FGColor
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

      /// <summary>
      /// Gets and sets the line width of the figure.
      /// </summary>
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

      /// <summary>
      /// Adds the point given to the list of points of the figure.
      /// </summary>
      /// <param name="p"> the point being added to the list </param>
      public void AddPoint ( Point p ) 
      {
         pts.Add(p);
      }

      /// <summary>
      /// Replaces the point at the specified index with the given point.
      /// </summary>
      /// <param name="p"> the point being added to the list </param>
      /// <param name="index"> the index of the point to replace </param>
      public void ReplacePoint ( Point p, int index ) 
      { 
         pts[index] = p; 
      }
   }

   /// <summary>
   /// TLine inherits all atributes and methods of class Figure. The
   /// Show method is overridden with specifics for a line.
   /// </summary>
   public class TLine : Figure
   {

      /// <summary>
      /// Overrides Figure.Show()
      /// Draws a line using openTK and openGL with the attributes specified.
      /// </summary>
      public override void Show() 
      {
         TLine line = new TLine();

         GL.LineWidth(lineWidth);
         GL.Begin(PrimitiveType.LineStrip);
            GL.Color3(FGColor);
            GL.Vertex2(pts[0].X, pts[0].Y);
            GL.Vertex2(pts[1].X, pts[1].Y);
         GL.End();
      }
   }

   /// <summary>
   /// TRectangle inherits all atributes and methods of class Figure. The
   /// Show method is overridden with specifics for a rectangle.
   /// </summary>
   public class TRectangle : Figure
   {

      /// <summary>
      /// Overrides Figure.Show()
      /// Draws a rectangle using openTK and openGL with the attributes 
      /// specified.
      /// </summary>
      public override void Show()
      {
         TRectangle rect = new TRectangle();

         GL.LineWidth(lineWidth);
         GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(FGColor);
            GL.Vertex2(pts[1].X, pts[1].Y);
            GL.Vertex2(pts[0].X, pts[1].Y);
            GL.Vertex2(pts[0].X, pts[0].Y);
            GL.Vertex2(pts[1].X, pts[0].Y);
         GL.End();
      }
   }

}  // Namespace Figures