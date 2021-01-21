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

namespace Lab0
{
   public partial class Form1 : Form
   {
      int color;

      public Form1()
      {
         InitializeComponent();
         btnShow.Enabled = false;
         colorCombo.SelectedItem = 0;
         RdBtnRotateClrs.Checked = true;
         colorCombo.Enabled = false;

         if (RdBtnSingleClr.Checked)
            colorCombo.Enabled = true;
      }

      private void btnShow_Click(object sender, EventArgs e)
      {
         Draw();
      }

      private void colorCombo_SelectedIndexChanged(object sender, EventArgs e)
      {
         int selColor = colorCombo.SelectedIndex;
         switch( selColor )
         {
            case 0:
               color = 0;
               break;
            case 1:
               color = 1;
               break;
            case 2:
               color = 2;
               break;
            case 3:
               color = 3;
               break;
            default:
               color = 0;
               break;
         }
         btnShow.Enabled = true;
      }

      private void colorChangeTimer_Tick(object sender, EventArgs e)
      {
         switch (color)
         {
            case 0:
               color = 1;
               Draw();
               break;
            case 1:
               color = 2;
               Draw();
               break;
            case 2:
               color = 3;
               Draw();
               break;
            case 3:
               color = 0;
               Draw();
               break;
            default:
               color = 0;
               Draw();
               break;
         }
      }

      private void RdBtnSingleClr_CheckedChanged(object sender, EventArgs e)
      {
         if (RdBtnSingleClr.Checked)
         {
            colorChangeTimer.Enabled = false;
            colorCombo.Enabled = true;
         }

      }

      private void RdBtnRotateClrs_CheckedChanged(object sender, EventArgs e)
      {
         if (RdBtnRotateClrs.Checked)
         {
            colorChangeTimer.Enabled = true;
            colorCombo.Enabled = false;
         }
      }

      private void Draw()
      {
         GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
         GL.Begin(PrimitiveType.Polygon);
         switch (color)
         {
            case 0:
               GL.Color3(0.0, 0.0, 1.0);
               break;
            case 1:
               GL.Color3(1.0, 0.0, 0.0);
               break;
            case 2:
               GL.Color3(0.0, 1.0, 0.0);
               break;
            case 3:
               GL.Color3(1.0, 1.0, 1.0);
               break;
            default:
               GL.Color3(0.0, 0.0, 1.0);
               break;
         }
         GL.Vertex2(-0.8, -0.8);
         GL.Vertex2(-0.8, 0.8);
         GL.Vertex2(0.8, 0.8);
         GL.Vertex2(0.8, -0.8);
         GL.End();
         glControl1.SwapBuffers();
      }
   }
}
