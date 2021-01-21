/// Program:   Program 5
/// Class:     CS3920
/// File:      Form1.cs: 
///            Represents the main form of the program. Handles all
///            user interaction of the form.
/// Authors:   Brianna Muleski, Lucas Gangstad
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Prog5
{
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

      private const int MAX_GARBAGE = 30;

      private const String HELP_TXT = 
      "Ship Controls:\n" +
      "W: Move the ship forward.\n" + 
      "S: Move the ship to the left.\n" + 
      "A: Move the ship to the right.\n" + 
      "D: Move the ship backward.\n" +
      "Numpad 8: Pitch the ship upward.\n" +
      "Numpad 5: Pitch the ship downward.\n" +
      "Numpad 4: Yaw the ship to the left.\n" +
      "Numpad 6: Yaw the ship to the right.\n" +
      "Space: Shoot projectiles.\n" +
      "Rotate through different light color by pressing C.\n";

      private FigureList fig_list = new FigureList();
      private FigureList projectiles = new FigureList();
      private Light light = new Light();
      private static int curr_color = 0;
      private bool change_col = false;
      private Dictionary<int, bool> key_states = new Dictionary<int, bool>();
      private Figure projectile;
      private int score = 0;


      /// <summary>
      /// Creates the form and sets values to default.
      /// </summary>
      public Form1()
      {
         InitializeComponent();
         this.Text = "Program 5 - Spaceship Game";
         timer.Interval = timerTrackBar.Value;
         key_states[(int)Keys.W] = false;
         key_states[(int)Keys.S] = false;
         key_states[(int)Keys.A] = false;
         key_states[(int)Keys.D] = false;
         key_states[(int)Keys.E] = false;
         key_states[(int)Keys.Q] = false;
         key_states[(int)Keys.NumPad8] = false;
         key_states[(int)Keys.NumPad4] = false;
         key_states[(int)Keys.NumPad5] = false;
         key_states[(int)Keys.NumPad6] = false;
         key_states[(int)Keys.Space] = false;
         key_states[(int)Keys.C] = false;
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
            GL.Enable(EnableCap.DepthTest);
            
            float mult = (float)glControl.Height / (float)glControl.Width;
            Matrix4 projMat = Matrix4.CreatePerspectiveOffCenter
                                       (-WIN_SIZE, WIN_SIZE, -WIN_SIZE * mult,
                                        WIN_SIZE * mult, WIN_NEAR, WIN_FAR);

            int loc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ProjectionMatrix");
            GL.UniformMatrix4(loc, false, ref projMat);
         }
         else
         {
            MessageBox.Show(ShaderLoader.Instance.LastLoadError);
         }
      }

      /// <summary>
      /// Loads a random amount of space garbage figures.
      /// </summary>
      private void LoadGarbage()
      {
         Random rnd = new Random();
         int num_garbage = rnd.Next(MAX_GARBAGE);
         fig_list.LoadFigures("models/garbage.wrl", num_garbage);
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
         Matrix4 look_at = Ship.Instance.LookAt();

         int loc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ViewMatrix");
         GL.UniformMatrix4(loc, false, ref look_at);

         if (fig_list != null)
         {
            fig_list.Show(look_at);
         }

         if (projectiles != null)
         {
            projectiles.Show(look_at);
         }

         glControl.SwapBuffers();
      }

      /// <summary>
      /// Handles showing the form. Shows the figures and starts the timer.
      /// </summary>
      /// <param name="sender"> Form1 </param>
      /// <param name="e"> details about the shown event </param>
      private void Form1_Shown(object sender, EventArgs e)
      {
         position.Text = "Ship's Position: " + Ship.Instance.Position;
         direction.Text = "Ship's Direction: " + Ship.Instance.Direction;
         light.Color = new Vector3(1.0f, 1.0f, 1.0f);
         LoadGarbage();
         projectile = new Figure("models/projectile.wrl");
         ambient.Value = (decimal)0.5f;
         timer.Start();
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
         projectiles.Move();
         score += projectiles.KillCollisions(fig_list);
         KeyOperations();
         ShowFigs();
         lblScore.Text = "Score: " + score.ToString();
         position.Text = "Ship's Position: " + Ship.Instance.Position;
         direction.Text = "Ship's Direction: " + Ship.Instance.Direction;
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
      /// Handles clicking the help menu item. Shows rules and controls for the game.
      /// </summary>
      /// <param name="sender"> helpToolStripMenuItem </param>
      /// <param name="e"> details of the click event </param>
      private void helpToolStripMenuItem_Click(object sender, EventArgs e)
      {
         MessageBox.Show(HELP_TXT, "HELP", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
      /// Changes the intensity of the ambient light. Shows the figures based
      /// on the new intensity.
      /// </summary>
      /// <param name="sender"> ambient </param>
      /// <param name="e"> details of the valueChanged event </param>
      private void ambientChanged(object sender, EventArgs e)
      {
         float amb = (float)ambient.Value;
         int loc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "GlobalAmbient");
         GL.Uniform1(loc, amb);
         ShowFigs();
      }

      /// <summary>
      /// Sets the state of the key pressed to true and checks if the key was
      /// the C key.
      /// </summary>
      /// <param name="sender"> Form1 </param>
      /// <param name="e"> details of the keyDown event </param>
      private void Form1_KeyDown(object sender, KeyEventArgs e)
      {
         key_states[(int)e.KeyCode] = true;
         if (e.KeyCode == Keys.C)
         {
            change_col = true;
         }
      }

      /// <summary>
      /// Sets the color of the light. Shows the figures with the new color
      /// of the light.
      /// </summary>
      /// <param name="sender"> Form1 </param>
      /// <param name="e"> details of the KeyPress event </param>
      private void Form1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         if (change_col)
         {
            curr_color++;
            if (curr_color > 7)
            {
               curr_color = 0;
            }
            switch (curr_color)
            {
               case 0: //White
                  light.Color = new Vector3(1.0f, 1.0f, 1.0f);
                  lightCol.Text = "White";
                  break;
               default:
               case 1: //Black
                  light.Color = new Vector3(0.0f, 0.0f, 0.0f);
                  lightCol.Text = "Black";
                  break;
               case 2: //Red
                  light.Color = new Vector3(1.0f, 0.0f, 0.0f);
                  lightCol.Text = "Red";
                  break;
               case 3: //Green
                  light.Color = new Vector3(0.0f, 1.0f, 0.0f);
                  lightCol.Text = "Green";
                  break;
               case 4: //Blue
                  light.Color = new Vector3(0.0f, 0.0f, 1.0f);
                  lightCol.Text = "Blue";
                  break;
               case 5: //Yellow 
                  light.Color = new Vector3(1.0f, 1.0f, 0.0f);
                  lightCol.Text = "Yellow";
                  break;
               case 6: //Magenta
                  light.Color = new Vector3(1.0f, 0.0f, 1.0f);
                  lightCol.Text = "Magenta";
                  break;
               case 7: //Cyan
                  light.Color = new Vector3(0.0f, 1.0f, 1.0f);
                  lightCol.Text = "Cyan";
                  break;
            }
            change_col = false;
            ShowFigs();
         }
      }

      /// <summary>
      /// Sets the key state of the key released to false.
      /// </summary>
      /// <param name="sender"> Form1 </param>
      /// <param name="e"> the details of the KeyUp event </param>
      private void Form1_KeyUp(object sender, KeyEventArgs e)
      {
         key_states[(int)e.KeyCode] = false;
      }

      private void MakeProjectile()
      {
         Figure temp = new Figure(projectile);
         temp.Load();
         temp.Translate(Ship.Instance.Position);
         MovePattern move = new MoveStraight(Ship.Instance.Direction, 1.0f);
         projectiles.Add(temp, move, 100000000);
      }

      /// <summary>
      /// Changes the position of the ship based on the keyboard input.
      /// </summary>
      private void KeyOperations()
      {
         if (key_states[(int)Keys.W])
         {
            Ship.Instance.Move(1);
         }
         if (key_states[(int)Keys.A])
         {
            Ship.Instance.Strafe(1);
         }
         if (key_states[(int)Keys.S])
         {
            Ship.Instance.Move(-1);
         }
         if (key_states[(int)Keys.D])
         {
            Ship.Instance.Strafe(-1);
         }
         if (key_states[(int)Keys.Q])
         {
            Ship.Instance.Rise(-1);
         }
         if (key_states[(int)Keys.E])
         {
            Ship.Instance.Rise(1);
         }
         if(key_states[(int)Keys.NumPad8])
         {
            Ship.Instance.ChangeDirection(0, -.1f);
         }
         if (key_states[(int)Keys.NumPad5])
         {
            Ship.Instance.ChangeDirection(0, .1f);
         }
         if (key_states[(int)Keys.NumPad4])
         {
            Ship.Instance.ChangeDirection(-.1f, 0);
         }
         if (key_states[(int)Keys.NumPad6])
         {
            Ship.Instance.ChangeDirection(.1f, 0);
         }
         if (key_states[(int)Keys.Space])
         {
            MakeProjectile();
         }
         light.Direction = Ship.Instance.Direction;
         light.Position = Ship.Instance.Position;
      }

      /// <summary>
      /// Resets the game.
      /// </summary>
      /// <param name="sender"> resetBtn </param>
      /// <param name="e"> the details of the click event </param>
      private void resetBtn_Click(object sender, EventArgs e)
      {
         Ship.Instance.Reset();
         score = 0;
         lblScore.Text = "Score: " + score.ToString();
         fig_list.Clear();
         projectiles.Clear();
         LoadGarbage();
      }
   }
}
