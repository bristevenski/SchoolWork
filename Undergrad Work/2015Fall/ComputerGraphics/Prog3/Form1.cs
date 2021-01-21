using System;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Prog3
{
   public partial class Form1 : Form
   {
      const float ORIG_X = 5.0f;
      const float ORIG_Y = 5.0f;
      const float ORIG_Z = 5.0f;
      const float EYE_INC = 10.0f;

      float eye_x = ORIG_X;
      float eye_y = ORIG_Y;
      float eye_z = ORIG_Z;
      FigureList fig_list = new FigureList();

      public Form1()
      {
         InitializeComponent();
         this.Text = "3D Viewer     Current Folder: None";
         SetDefaultEye();
         timerTrackBar.Value = timer.Interval;
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         GL.Enable(EnableCap.DepthTest);
         GL.MatrixMode(MatrixMode.Projection);
         Matrix4 projMat = Matrix4.CreateOrthographic(glControl.Width, glControl.Height, 0.5f, 100.0f);
         GL.LoadMatrix(ref projMat);
      }

      private void ShowFigs()
      {
         Matrix4 look_at = Matrix4.LookAt(eye_x, eye_y, eye_z, 0f, 0f, 0f, 0f, 1f, 0f);

         if( fig_list != null)
         {
            fig_list.Show(look_at);
         }

         Axes.Instance.Show(look_at);

         glControl.SwapBuffers();
      }

      private void Form1_Shown(object sender, EventArgs e)
      {
         ShowFigs();
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
         {
            fig_list.LoadFigures(folderBrowserDialog.SelectedPath);
            this.Text = "3D Viewer     Current Folder: " + folderBrowserDialog.SelectedPath;
         }
      }

      private void xTrackBar_Scroll(object sender, EventArgs e)
      {
         eye_x = xTrackBar.Value / EYE_INC;
         xLbl.Text = "X = " + eye_x;
         ShowFigs();
      }

      private void yTrackBar_Scroll(object sender, EventArgs e)
      {
         eye_y = yTrackBar.Value / EYE_INC;
         yLbl.Text = "Y = " + eye_y;
         ShowFigs();
      }

      private void zTrackBar_Scroll(object sender, EventArgs e)
      {
         eye_z = zTrackBar.Value / EYE_INC;
         zLbl.Text = "Z = " + eye_z;
         ShowFigs();
      }

      private void resetBtn_Click(object sender, EventArgs e)
      {
         SetDefaultEye();
         ShowFigs();
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

      private void timer_Tick(object sender, EventArgs e)
      {
         fig_list.Move();
         ShowFigs();
      }

      private void timerTrackBar_Scroll(object sender, EventArgs e)
      {
         timer.Interval = timerTrackBar.Value;
      }
   }
}
