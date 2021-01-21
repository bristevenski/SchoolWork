/// Program:   Program 1
/// Class:     CS3920
/// File:      MainForm.cs: 
///            MainForm.cs contains the attributes and functions of namepsace
///            Prog1 and its class: MainForm.
/// Author:    Brianna Muleski

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using Figures;

namespace Prog1
{
   /// <summary>
   /// MainForm handles the components of the main form for program 1.
   /// </summary>
   public partial class MainForm : Form
   {
      private List<Figure> figlist = new List<Figure>();
      private Figure fig;
      private bool banding = false;

      /// <summary>
      /// Constructor: initializes the components on the form.
      /// </summary>
      public MainForm()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Handles the operations when the form is loaded. The GL control object
      /// is initialized, and all initial values are set.
      /// </summary>
      /// <param name="sender"> the object that invoked the handler </param>
      /// <param name="e"> loading of the form</param>
      private void MainForm_Load(object sender, EventArgs e)
      {
         GL.MatrixMode(MatrixMode.Projection);
         GL.LoadIdentity();
         GL.Ortho(0, glControl.Size.Width, glControl.Size.Height, 0, 1, -1);
         typeCombo.SelectedIndex = 0;
         colorCombo.SelectedIndex = 0;
         SetType();
         SetColor();
      }

      /// <summary>
      /// Handles the event of clicking down on the mouse within the GL control
      /// object. Sets the figure's type, color, and line width specified by
      /// the user and begins to draw the figure on the GL control object.
      /// Also redraws the figures already in figlist.
      /// </summary>
      /// <param name="sender"> the object that invoked the handler </param>
      /// <param name="e"> clicking down on the mouse </param>
      private void glControl_MouseDown(object sender, MouseEventArgs e)
      {
         SetType();
         SetColor();
         banding = true;

         Point p = new Point(e.X, e.Y);
         fig.AddPoint(p);
         fig.AddPoint(p);
         fig.LineWidth = (float)lineWidth.Value;

         GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
         foreach (Figure f in figlist)
         {
            f.Show();
         }

         fig.Show();
		 glControl.SwapBuffers();
      }

      /// <summary>
      /// Sets the color of the figure according to the color specified 
      /// by the user.
      /// </summary>
      private void SetColor()
      {
         int index = colorCombo.SelectedIndex;
         switch( index )
         {
            case 0:
               fig.FGColor = Color.White;
               break;
            case 1:
               fig.FGColor = Color.Red;
               break;
            case 2:
               fig.FGColor = Color.Blue;
               break;
            case 3:
               fig.FGColor = Color.Green;
               break;
            case 4:
               fig.FGColor = Color.Orange;
               break;
            case 5:
               fig.FGColor = Color.Yellow;
               break;
            case 6:
               fig.FGColor = Color.Purple;
               break;
            default:
               fig.FGColor = Color.White;
               break;
         }
      }

      /// <summary>
      /// Sets the type of figure according the the type specified by the user.
      /// </summary>
      private void SetType()
      {
         if (typeCombo.SelectedIndex == 0)
         {
            fig = new TLine();
         }
         else
         {
            fig = new TRectangle();
         }
      }

      /// <summary>
      /// Handles the event of moving the mouse within the GL control object.
      /// If the user is currently drawing a figure, the function uses the 
      /// current place of the mouse to continue to draw the figure
      /// in the GL control object. Also redraws all figures in the figlist.
      /// </summary>
      /// <param name="sender"> the object that invoked the handler </param>
      /// <param name="e"> moving the mouse </param>
      private void glControl_MouseMove(object sender, MouseEventArgs e)
      {
         if (banding)
         {
            Point p = new Point(e.X, e.Y);
            fig.ReplacePoint(p, 1);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            foreach (Figure f in figlist)
            {
               f.Show();
            }

            fig.Show();

            glControl.SwapBuffers();
         }

      }

      /// <summary>
      /// Handles the event of releasing the mouse within the GL control
      /// object. Adds the figure currently being drawn to the list of 
      /// figures (figlist) and draws all figures in the list.
      /// </summary>
      /// <param name="sender"> the object that invoked the handler </param>
      /// <param name="e"> releasing the mouse </param>
      private void glControl_MouseUp(object sender, MouseEventArgs e)
      {
         banding = false;
         figlist.Add(fig);

         GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

         foreach (Figure f in figlist)
         {
            f.Show();
         }

         glControl.SwapBuffers();
      }

      /// <summary>
      /// Handles the operations when the form is shown. Clears the GL buffer
      /// and swaps.
      /// </summary>
      /// <param name="sender">  the object that invoked the handler </param>
      /// <param name="e"> showing the form </param>
      private void MainForm_Shown(object sender, EventArgs e)
      {
         GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
         glControl.SwapBuffers();
      }
   }
} // namespace Prog1
