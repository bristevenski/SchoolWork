///
///
///

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
   /// 
   /// </summary>
   public partial class MainForm : Form
   {
      private List<Figure> figlist = new List<Figure>();
      private Figure fig;
      private bool banding = false;

      /// <summary>
      /// 
      /// </summary>
      public MainForm()
      {
         InitializeComponent();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
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
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void glControl_MouseDown(object sender, MouseEventArgs e)
      {
         SetType();
         SetColor();
         banding = true;

         Point p = new Point(e.X, e.Y);
         fig.AddPoint(p);
      }

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

      private void SetType()
      {
         if (typeCombo.SelectedText.Equals("Line"))
         {
            fig = new TLine();
         }
         else
         {
            fig = new TRectangle();
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void glControl_MouseMove(object sender, MouseEventArgs e)
      {
         if (banding)
         {
            Point p = new Point(e.X, e.Y);
            fig.AddPoint(p);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            foreach (Figure f in figlist)
            {
               f.Show();
            }

            glControl.SwapBuffers();
         }

      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
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

      private void lineWidth_Scroll(object sender, EventArgs e)
      {
         fig.LineWidth = lineWidth.Value;
      }

      private void MainForm_Shown(object sender, EventArgs e)
      {
         GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
         glControl.SwapBuffers();
      }
   }
} // namespace Prog1
