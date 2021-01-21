/// Program:   Program 4
/// Class:     CS3920
/// File:      Form1.cs: 
///            Represents the main form of the program. Handles all
///            user interaction of the form.
/// Authors:   Brianna Muleski, Lucas Gangstad
using System;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Prog4
{

   /// <summary>
   /// The main form of the program. Displays when the program starts.
   /// </summary>
   public partial class Form1 : Form
   {
      private const float WIN_NEAR = 2.0f;
      private const float WIN_FAR = 80.0f;
      private const float WIN_SIZE = 2.0f;

      private const float ORIG_X = 20.0f;
      private const float ORIG_Y = 20.0f;
      private const float ORIG_Z = 20.0f;
      private const float EYE_INC = 10.0f;

      private const float LIGHT_INC = 10.0f;

      private float eye_x = ORIG_X;
      private float eye_y = ORIG_Y;
      private float eye_z = ORIG_Z;

      private FigureList fig_list = new FigureList();
      private Light light = new Light();

      /// <summary>
      /// Creates the form and sets values to default.
      /// </summary>
      public Form1()
      {
         InitializeComponent();
         this.Text = "3D Viewer     Current Folder: None";
         SetDefaultEye();
         timer.Interval = timerTrackBar.Value;
      }

      /// <summary>
      /// Handles loading the form. Sets up the projection matrix and loads it.
      /// </summary>
      /// <param name="sender"> Form1 </param>
      /// <param name="e"> details about the load event </param>
      private void Form1_Load(object sender, EventArgs e)
      {
         if (ShaderLoader.Instance.Load("Prog4_VS.glsl", "Prog4_FS.glsl"))
         {
            ambient.Value = (decimal)0.5f;

            GL.Enable(EnableCap.DepthTest);

            float mult = (float)glControl.Height / (float)glControl.Width;
            Matrix4 projMat = Matrix4.CreatePerspectiveOffCenter
                                       (-WIN_SIZE, WIN_SIZE, -WIN_SIZE * mult,
                                        WIN_SIZE * mult, WIN_NEAR, WIN_FAR);

            int loc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ProjectionMatrix");
            GL.UniformMatrix4(loc, false, ref projMat);

            ShowFigs();
         }
         else
         {
            MessageBox.Show(ShaderLoader.Instance.LastLoadError);
         }
      }

      /// <summary>
      /// Clears the buffers, creates the look at matrix, and swaps the 
      /// buffers after showing the objects.
      /// Shows the figures on the glControl object, if they exist. 
      /// Shows the axes on the glControl object.
      /// </summary>
      private void ShowFigs()
      {
         GL.Clear(ClearBufferMask.ColorBufferBit |
                  ClearBufferMask.DepthBufferBit);
         Matrix4 look_at = Matrix4.LookAt
                           (eye_x, eye_y, eye_z, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);

         int loc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ViewMatrix");
         GL.UniformMatrix4(loc, false, ref look_at);

         if(fig_list != null)
         {
            fig_list.Show(look_at);
         }

         Axes.Instance.Show(look_at);

         glControl.SwapBuffers();
      }

      /// <summary>
      /// Handles showing the form. Shows the figures and starts the timer.
      /// </summary>
      /// <param name="sender"> Form1 </param>
      /// <param name="e"> details about the shown event </param>
      private void Form1_Shown(object sender, EventArgs e)
      {
         lightColor.SelectedIndex = 0;
         ShowFigs();
         timer.Start();
      }

      /// <summary>
      /// Handles scrolling of the xTrackBar. Updates the x-axis position
      /// of the eye. Shows the figures with the new eye coordinates.
      /// </summary>
      /// <param name="sender"> xTrackBar </param>
      /// <param name="e"> details about the scroll event </param>
      private void xTrackBar_Scroll(object sender, EventArgs e)
      {
         eye_x = xTrackBar.Value / EYE_INC;
         xLbl.Text = "X = " + eye_x;
         ShowFigs();
      }

      /// <summary>
      /// Handles scrolling of the yTrackBar. Updates the y-axis position
      /// of the eye. Shows the figures with the new eye coordinates.
      /// </summary>
      /// <param name="sender"> yTrackBar </param>
      /// <param name="e"> details about the scroll event </param>
      private void yTrackBar_Scroll(object sender, EventArgs e)
      {
         eye_y = yTrackBar.Value / EYE_INC;
         yLbl.Text = "Y = " + eye_y;
         ShowFigs();
      }

      /// <summary>
      /// Handles scrolling of the zTrackBar. Updates the z-axis position
      /// of the eye. Shows the figures with the new eye coordinates.
      /// </summary>
      /// <param name="sender"> zTrackBar </param>
      /// <param name="e"> details about the scroll event </param>
      private void zTrackBar_Scroll(object sender, EventArgs e)
      {
         eye_z = zTrackBar.Value / EYE_INC;
         zLbl.Text = "Z = " + eye_z;
         ShowFigs();
      }

      /// <summary>
      /// Handles clicking the reset button. Resets the eye location
      /// and restores the figures and shows them with their defaults
      /// applied.
      /// </summary>
      /// <param name="sender"> resetBtn </param>
      /// <param name="e"> details of the click event </param>
      private void resetBtn_Click(object sender, EventArgs e)
      {
         SetDefaultEye();
         fig_list.Restore();
         ShowFigs();
      }

      /// <summary>
      /// Sets the default values of the eye coordinates.
      /// Updates the trackbars with the default values.
      /// </summary>
      private void SetDefaultEye()
      {
         eye_x = ORIG_X;
         eye_y = ORIG_Y;
         eye_z = ORIG_Z;

         xLbl.Text = "X = " + eye_x;
         yLbl.Text = "Y = " + eye_y;
         zLbl.Text = "Z = " + eye_z;

         xTrackBar.Value = (int)(ORIG_X * EYE_INC);
         yTrackBar.Value = (int)(ORIG_Y * EYE_INC);
         zTrackBar.Value = (int)(ORIG_Z * EYE_INC);
      }

      /// <summary>
      /// Handles the tick event of the timer. Moves the figures
      /// in fig_list and shows the figures in their new positions.
      /// </summary>
      /// <param name="sender"> timer </param>
      /// <param name="e"> details of the tick event </param>
      private void timer_Tick(object sender, EventArgs e)
      {
         fig_list.Move();
         ShowFigs();
      }

      /// <summary>
      /// Handles scrolling the timer track bar. Increases or 
      /// decreases the timer's interval based on the new value
      /// of the track bar. If the maximun value is reached, the timer
      /// is stopped.
      /// </summary>
      /// <param name="sender"> timerTrackBar </param>
      /// <param name="e"> details of the scroll event </param>
      private void timerTrackBar_Scroll(object sender, EventArgs e)
      {
         if (timerTrackBar.Value == timerTrackBar.Minimum)
         {
            timer.Stop();
         }
         else
         {
            timer.Interval = timerTrackBar.Maximum - timerTrackBar.Value + 1;
            timer.Start();
         }
      }

      /// <summary>
      /// Handles clicking the exit menu item. Exits the application.
      /// </summary>
      /// <param name="sender"> exitToolStripMenuItem </param>
      /// <param name="e"> details of the click event </param>
      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      /// <summary>
      /// Handles clicking the open menu item. Opens a folder browser,
      /// allowing the user to choose a folder to open all VRML files held
      /// within it. Loads the figures from the form into fig_list and shows
      /// the figures. Handles all exceptions and displays an error message.
      /// </summary>
      /// <param name="sender"> openToolStripMenuItem </param>
      /// <param name="e"> details of the click event </param>
      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
         {
            try
            {
               fig_list.LoadFigures(folderBrowserDialog.SelectedPath);
               this.Text = "3D Viewer     Current Folder: " + 
                            folderBrowserDialog.SelectedPath;
               ShowFigs();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
         }
      }

      /// <summary>
      /// Handles the event of closing the form. Unloads the shaders.
      /// </summary>
      /// <param name="sender"> formClosing </param>
      /// <param name="e"> details of the closing event </param>
      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {
         ShaderLoader.Instance.Unload();
      }

      /// <summary>
      /// Handles scrolling the x position track bar. Increases or 
      /// decreases the x coordinate for the light based on the new value
      /// of the track bar. Shows the figures based on the new light position.
      /// </summary>
      /// <param name="sender"> lightX </param>
      /// <param name="e"> details of the scroll event </param>
      private void lightX_Scroll(object sender, EventArgs e)
      {
         Vector3 pos = light.Position;
         pos.X = lightX.Value / LIGHT_INC;
         light.Position = pos;
         lightXLbl.Text = "X = " + light.Position.X;
         ShowFigs();
      }

      /// <summary>
      /// Handles scrolling the z position track bar. Increases or 
      /// decreases the z coordinate for the light based on the new value
      /// of the track bar. Shows the figures based on the new light position.
      /// </summary>
      /// <param name="sender"> lightZ </param>
      /// <param name="e"> details of the scroll event </param>
      private void lightY_Scroll(object sender, EventArgs e)
      {
         Vector3 pos = light.Position;
         pos.Y = lightY.Value / LIGHT_INC;
         light.Position = pos;
         lightYLbl.Text = "Y = " + light.Position.Y;
         ShowFigs();
      }

      /// <summary>
      /// Handles scrolling the z position track bar. Increases or 
      /// decreases the z coordinate for the light based on the new value
      /// of the track bar. Shows the figures based on the new light position.
      /// </summary>
      /// <param name="sender"> lightZ </param>
      /// <param name="e"> details of the scroll event </param>
      private void lightZ_Scroll(object sender, EventArgs e)
      {
         Vector3 pos = light.Position;
         pos.Z = lightZ.Value / LIGHT_INC;
         light.Position = pos;
         lightZLbl.Text = "Z = " + light.Position.Z;
         ShowFigs();
      }

      /// <summary>
      /// Sets the color of the light. Shows the figures with the new color
      /// of the light.
      /// </summary>
      /// <param name="sender"> lightColor </param>
      /// <param name="e"> details of the selectedIndexChanged event </param>
      private void lightColor_SelectedIndexChanged(object sender, EventArgs e)
      {
         switch (lightColor.SelectedIndex)
         {
            case 0: //White
               light.Color = new Vector3(1.0f, 1.0f, 1.0f);
               break;
            default:
            case 1: //Black
               light.Color = new Vector3(0.0f, 0.0f, 0.0f);
               break;
            case 2: //Red
               light.Color = new Vector3(1.0f, 0.0f, 0.0f);
               break;
            case 3: //Green
               light.Color = new Vector3(0.0f, 1.0f, 0.0f);
               break;
            case 4: //Blue
               light.Color = new Vector3(0.0f, 0.0f, 1.0f);
               break;
            case 5: //Yellow 
               light.Color = new Vector3(1.0f, 1.0f, 0.0f);
               break;
            case 6: //Magenta
               light.Color = new Vector3(1.0f, 0.0f, 1.0f);
               break;
            case 7: //Cyan
               light.Color = new Vector3(0.0f, 1.0f, 1.0f);
               break;
         }
         ShowFigs();
      }

      /// <summary>
      /// Changes the intensity of the ambient light. Shows the figures based
      /// on the new intensity.
      /// </summary>
      /// <param name="sender"> ambient </param>
      /// <param name="e"> details of the valueChanged event </param>
      private void ambient_ValueChanged(object sender, EventArgs e)
      {
         float amb = (float)ambient.Value;
         int loc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "GlobalAmbient");
         GL.Uniform1(loc, amb);
         ShowFigs();
      }
   }
}
