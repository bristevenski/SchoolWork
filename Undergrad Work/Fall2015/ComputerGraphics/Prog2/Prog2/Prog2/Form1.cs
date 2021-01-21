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

      public Form1()
      {
         InitializeComponent();
         this.Text = "3D Viewer     Current Figure: None";
         axes = Axes.Instance;
         SetDefaultEye();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         GL.Enable(EnableCap.DepthTest);
         GL.MatrixMode(MatrixMode.Projection);
         Matrix4 projMat = Matrix4.CreateOrthographic(glControl.Width, glControl.Height, 0.5f, 100.0f);
         GL.LoadMatrix(ref projMat);
      }

      private void ShowFigure()
      {
         Matrix4 look_at = Matrix4.LookAt(eye_x, eye_y, eye_z, 0f, 0f, 0f, 0f, 1f, 0f); //Might need to change the last 6
         GL.MatrixMode(MatrixMode.Modelview);
         GL.LoadMatrix(ref look_at);

         axes.Show();
         if (fig != null)
         {
            fig.Show();
         }

         glControl.SwapBuffers();
      }

      private void Form1_Shown(object sender, EventArgs e)
      {
         ShowFigure();
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (openFileDialog.ShowDialog() == DialogResult.OK)
         {
            fig = new Figure(openFileDialog.FileName);
            this.Text = "3D Viewer     Current Figure: " + openFileDialog.SafeFileName;
         }
         
      }

      private void xTrackBar_Scroll(object sender, EventArgs e)
      {
         eye_x = xTrackBar.Value / 2; //need to divide by 2 to get smaller increments
         xLbl.Text = "X = " + eye_x;
         ShowFigure();
      }

      private void yTrackBar_Scroll(object sender, EventArgs e)
      {
         eye_y = yTrackBar.Value / 2;
         yLbl.Text = "Y = " + eye_y;
         ShowFigure();
      }

      private void zTrackBar_Scroll(object sender, EventArgs e)
      {
         eye_z = zTrackBar.Value / 2;
         zLbl.Text = "Z = " + eye_z;
         ShowFigure();
      }

      private void resetBtn_Click(object sender, EventArgs e)
      {
         SetDefaultEye();
         ShowFigure();
      }

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
