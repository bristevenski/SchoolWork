namespace Prog5
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.menuStrip = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.glControl = new OpenTK.GLControl();
         this.timer = new System.Windows.Forms.Timer(this.components);
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.lightCol = new System.Windows.Forms.Label();
         this.timerTrackBar = new System.Windows.Forms.TrackBar();
         this.timerLbl = new System.Windows.Forms.Label();
         this.ambient = new System.Windows.Forms.NumericUpDown();
         this.lblScore = new System.Windows.Forms.Label();
         this.resetBtn = new System.Windows.Forms.Button();
         this.position = new System.Windows.Forms.Label();
         this.direction = new System.Windows.Forms.Label();
         this.menuStrip.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ambient)).BeginInit();
         this.SuspendLayout();
         // 
         // menuStrip
         // 
         this.menuStrip.BackColor = System.Drawing.SystemColors.MenuBar;
         this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
         this.menuStrip.Location = new System.Drawing.Point(0, 0);
         this.menuStrip.Name = "menuStrip";
         this.menuStrip.Size = new System.Drawing.Size(1184, 24);
         this.menuStrip.TabIndex = 0;
         this.menuStrip.Text = "menuStrip";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
         this.helpToolStripMenuItem.Text = "Help";
         this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
         this.exitToolStripMenuItem.Text = "Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // glControl
         // 
         this.glControl.BackColor = System.Drawing.Color.Black;
         this.glControl.Location = new System.Drawing.Point(12, 27);
         this.glControl.Name = "glControl";
         this.glControl.Size = new System.Drawing.Size(1160, 823);
         this.glControl.TabIndex = 1;
         this.glControl.VSync = false;
         // 
         // timer
         // 
         this.timer.Tick += new System.EventHandler(this.timer_Tick);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.BackColor = System.Drawing.SystemColors.MenuBar;
         this.label1.Location = new System.Drawing.Point(981, 6);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(74, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "Ambient Light:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.BackColor = System.Drawing.SystemColors.MenuBar;
         this.label2.Location = new System.Drawing.Point(689, 6);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(97, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Current Light Color:";
         // 
         // lightCol
         // 
         this.lightCol.AutoSize = true;
         this.lightCol.BackColor = System.Drawing.SystemColors.MenuBar;
         this.lightCol.Location = new System.Drawing.Point(792, 6);
         this.lightCol.Name = "lightCol";
         this.lightCol.Size = new System.Drawing.Size(35, 13);
         this.lightCol.TabIndex = 5;
         this.lightCol.Text = "White";
         // 
         // timerTrackBar
         // 
         this.timerTrackBar.Location = new System.Drawing.Point(319, 0);
         this.timerTrackBar.Maximum = 500;
         this.timerTrackBar.Minimum = 200;
         this.timerTrackBar.Name = "timerTrackBar";
         this.timerTrackBar.Size = new System.Drawing.Size(294, 45);
         this.timerTrackBar.TabIndex = 7;
         this.timerTrackBar.Value = 300;
         this.timerTrackBar.Scroll += new System.EventHandler(this.timerTrackBar_Scroll);
         // 
         // timerLbl
         // 
         this.timerLbl.AutoSize = true;
         this.timerLbl.Location = new System.Drawing.Point(280, 6);
         this.timerLbl.Name = "timerLbl";
         this.timerLbl.Size = new System.Drawing.Size(33, 13);
         this.timerLbl.TabIndex = 8;
         this.timerLbl.Text = "Timer";
         // 
         // ambient
         // 
         this.ambient.DecimalPlaces = 1;
         this.ambient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
         this.ambient.Location = new System.Drawing.Point(1052, 4);
         this.ambient.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.ambient.Name = "ambient";
         this.ambient.Size = new System.Drawing.Size(37, 20);
         this.ambient.TabIndex = 9;
         this.ambient.ValueChanged += new System.EventHandler(this.ambientChanged);
         // 
         // lblScore
         // 
         this.lblScore.AutoSize = true;
         this.lblScore.Location = new System.Drawing.Point(1105, 6);
         this.lblScore.Name = "lblScore";
         this.lblScore.Size = new System.Drawing.Size(35, 13);
         this.lblScore.TabIndex = 10;
         this.lblScore.Text = "label3";
         // 
         // resetBtn
         // 
         this.resetBtn.Location = new System.Drawing.Point(154, 4);
         this.resetBtn.Name = "resetBtn";
         this.resetBtn.Size = new System.Drawing.Size(75, 23);
         this.resetBtn.TabIndex = 11;
         this.resetBtn.Text = "RESET";
         this.resetBtn.UseVisualStyleBackColor = true;
         this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
         // 
         // position
         // 
         this.position.AutoSize = true;
         this.position.BackColor = System.Drawing.Color.Black;
         this.position.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.position.ForeColor = System.Drawing.Color.Lime;
         this.position.Location = new System.Drawing.Point(23, 39);
         this.position.Name = "position";
         this.position.Size = new System.Drawing.Size(45, 16);
         this.position.TabIndex = 12;
         this.position.Text = "label3";
         // 
         // direction
         // 
         this.direction.AutoSize = true;
         this.direction.BackColor = System.Drawing.Color.Black;
         this.direction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.direction.ForeColor = System.Drawing.Color.Lime;
         this.direction.Location = new System.Drawing.Point(23, 55);
         this.direction.Name = "direction";
         this.direction.Size = new System.Drawing.Size(45, 16);
         this.direction.TabIndex = 13;
         this.direction.Text = "label3";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1184, 862);
         this.Controls.Add(this.direction);
         this.Controls.Add(this.position);
         this.Controls.Add(this.resetBtn);
         this.Controls.Add(this.lblScore);
         this.Controls.Add(this.ambient);
         this.Controls.Add(this.timerLbl);
         this.Controls.Add(this.glControl);
         this.Controls.Add(this.timerTrackBar);
         this.Controls.Add(this.lightCol);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.menuStrip);
         this.KeyPreview = true;
         this.MainMenuStrip = this.menuStrip;
         this.Name = "Form1";
         this.ShowIcon = false;
         this.Text = "Program 5 - Spaceship Game";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.Shown += new System.EventHandler(this.Form1_Shown);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
         this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
         this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
         this.menuStrip.ResumeLayout(false);
         this.menuStrip.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ambient)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip menuStrip;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private OpenTK.GLControl glControl;
      private System.Windows.Forms.Timer timer;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label lightCol;
      private System.Windows.Forms.TrackBar timerTrackBar;
      private System.Windows.Forms.Label timerLbl;
      private System.Windows.Forms.NumericUpDown ambient;
      private System.Windows.Forms.Label lblScore;
      private System.Windows.Forms.Button resetBtn;
      private System.Windows.Forms.Label position;
      private System.Windows.Forms.Label direction;
   }
}

