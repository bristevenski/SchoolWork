using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Prog2
{
   /// <summary>
   /// The main form of the program. Displays when the program starts.
   /// </summary>
   public partial class Form1 : Form
   {
      const float ORIG_X = 5.0f;
      const float ORIG_Y = 5.0f;
      const float ORIG_Z = 5.0f;

      float eye_x = ORIG_X;
      float eye_y = ORIG_Y;
      float eye_z = ORIG_Z;
      Axes axes;
      Figure fig;
      
      /// <summary>
      /// Creates the form and sets values to default.
      /// </summary>
      public Form1()
      {
         InitializeComponent();
         this.Text = "3D Viewer     Current Figure: None";
         SetDefaultEye();
      }

      /// <summary>
      /// Fired when the forml oads. Sets up the projectin matrix and creates axes.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Form1_Load(object sender, EventArgs e)
      {
         GL.Enable(EnableCap.DepthTest);
         GL.MatrixMode(MatrixMode.Projection);
         Matrix4 projMat = Matrix4.CreateOrthographic(20.0f, 20.0f, 0.5f, 100.0f);
         GL.LoadMatrix(ref projMat);
         axes = Axes.Instance;
      }
      
      /// <summary>
      /// Creates the lookat matrix, and draws the axes and figure if one exists.
      /// </summary>
      private void ShowFigure()
      {
         GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
         Matrix4 look_at = Matrix4.LookAt(eye_x, eye_y, eye_z, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
         GL.MatrixMode(MatrixMode.Modelview);
         GL.LoadMatrix(ref look_at);

         axes.Show();
         if (fig != null)
         {
            fig.Show();
         }

         glControl.SwapBuffers();
      }

      /// <summary>
      /// Fires when the form is first shown. Draws the figures.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Form1_Shown(object sender, EventArgs e)
      {
         ShowFigure();
      }

      /// <summary>
      /// Fires when the user selects the menu item.
      /// Presents a load file dialog. Attempts to load the figure based on file.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (openFileDialog.ShowDialog() == DialogResult.OK)
         {
            fig = new Figure(openFileDialog.FileName);
            try
            {
               fig.Load();
               this.Text = "3D Viewer     Current Figure: " + fig.Name;
               ShowFigure();
            }
            catch (Exception ex)
            {
               fig = null;
               MessageBox.Show(ex.Message);
            }
         }
         
      }

      /// <summary>
      /// Fires when the x is changed.
      /// Moves the eye.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void xTrackBar_Scroll(object sender, EventArgs e)
      {
         eye_x = xTrackBar.Value / 2; //need to divide by 2 to get smaller increments
         xLbl.Text = "X = " + eye_x;
         ShowFigure();
      }

      /// <summary>
      /// Fires when the y is changed.
      /// Moves the eye.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void yTrackBar_Scroll(object sender, EventArgs e)
      {
         eye_y = yTrackBar.Value / 2;
         yLbl.Text = "Y = " + eye_y;
         ShowFigure();
      }

      /// <summary>
      /// Fires when the z is changed.
      /// Moves the eye.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void zTrackBar_Scroll(object sender, EventArgs e)
      {
         eye_z = zTrackBar.Value / 2;
         zLbl.Text = "Z = " + eye_z;
         ShowFigure();
      }

      /// <summary>
      /// Fires when the reset button is pressed.
      /// Moves the eye.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void resetBtn_Click(object sender, EventArgs e)
      {
         SetDefaultEye();
         ShowFigure();
      }
      
      /// <summary>
      /// Sets the eye to its default position.
      /// </summary>
      private void SetDefaultEye()
      {
         eye_x = ORIG_X;
         eye_y = ORIG_Y;
         eye_z = ORIG_Z;

         xLbl.Text = "X = " + eye_x;
         yLbl.Text = "Y = " + eye_y;
         zLbl.Text = "Z = " + eye_z;

         xTrackBar.Value = (int)ORIG_X * 2;
         yTrackBar.Value = (int)ORIG_Y * 2;
         zTrackBar.Value = (int)ORIG_Z * 2;
      }
   }
}
