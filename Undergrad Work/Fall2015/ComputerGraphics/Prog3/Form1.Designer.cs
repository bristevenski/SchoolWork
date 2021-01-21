namespace Prog3
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
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.coordinatesGrp = new System.Windows.Forms.GroupBox();
         this.resetBtn = new System.Windows.Forms.Button();
         this.zTrackBar = new System.Windows.Forms.TrackBar();
         this.yTrackBar = new System.Windows.Forms.TrackBar();
         this.xTrackBar = new System.Windows.Forms.TrackBar();
         this.zLbl = new System.Windows.Forms.Label();
         this.yLbl = new System.Windows.Forms.Label();
         this.xLbl = new System.Windows.Forms.Label();
         this.glControl = new OpenTK.GLControl();
         this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
         this.timer = new System.Windows.Forms.Timer(this.components);
         this.timerTrackBar = new System.Windows.Forms.TrackBar();
         this.timerLbl = new System.Windows.Forms.Label();
         this.menuStrip.SuspendLayout();
         this.coordinatesGrp.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).BeginInit();
         this.SuspendLayout();
         // 
         // menuStrip
         // 
         this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
         this.menuStrip.Location = new System.Drawing.Point(0, 0);
         this.menuStrip.Name = "menuStrip";
         this.menuStrip.Size = new System.Drawing.Size(684, 24);
         this.menuStrip.TabIndex = 0;
         this.menuStrip.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // openToolStripMenuItem
         // 
         this.openToolStripMenuItem.Name = "openToolStripMenuItem";
         this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.openToolStripMenuItem.Text = "Open";
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.exitToolStripMenuItem.Text = "Exit";
         // 
         // coordinatesGrp
         // 
         this.coordinatesGrp.Controls.Add(this.resetBtn);
         this.coordinatesGrp.Controls.Add(this.zTrackBar);
         this.coordinatesGrp.Controls.Add(this.yTrackBar);
         this.coordinatesGrp.Controls.Add(this.xTrackBar);
         this.coordinatesGrp.Controls.Add(this.zLbl);
         this.coordinatesGrp.Controls.Add(this.yLbl);
         this.coordinatesGrp.Controls.Add(this.xLbl);
         this.coordinatesGrp.Location = new System.Drawing.Point(12, 40);
         this.coordinatesGrp.Name = "coordinatesGrp";
         this.coordinatesGrp.Size = new System.Drawing.Size(662, 90);
         this.coordinatesGrp.TabIndex = 1;
         this.coordinatesGrp.TabStop = false;
         this.coordinatesGrp.Text = "X, Y, Z values of the View Reference Point (Eyeball) looking at (0,0,0) with Y up" +
    "";
         // 
         // resetBtn
         // 
         this.resetBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.resetBtn.Location = new System.Drawing.Point(579, 39);
         this.resetBtn.Name = "resetBtn";
         this.resetBtn.Size = new System.Drawing.Size(75, 23);
         this.resetBtn.TabIndex = 8;
         this.resetBtn.Text = "RESET";
         this.resetBtn.UseVisualStyleBackColor = true;
         // 
         // zTrackBar
         // 
         this.zTrackBar.Location = new System.Drawing.Point(384, 39);
         this.zTrackBar.Maximum = 250;
         this.zTrackBar.Minimum = -250;
         this.zTrackBar.Name = "zTrackBar";
         this.zTrackBar.Size = new System.Drawing.Size(164, 45);
         this.zTrackBar.TabIndex = 7;
         // 
         // yTrackBar
         // 
         this.yTrackBar.Location = new System.Drawing.Point(201, 39);
         this.yTrackBar.Maximum = 250;
         this.yTrackBar.Minimum = -250;
         this.yTrackBar.Name = "yTrackBar";
         this.yTrackBar.Size = new System.Drawing.Size(164, 45);
         this.yTrackBar.TabIndex = 6;
         // 
         // xTrackBar
         // 
         this.xTrackBar.Location = new System.Drawing.Point(9, 39);
         this.xTrackBar.Maximum = 250;
         this.xTrackBar.Minimum = -250;
         this.xTrackBar.Name = "xTrackBar";
         this.xTrackBar.Size = new System.Drawing.Size(164, 45);
         this.xTrackBar.TabIndex = 5;
         // 
         // zLbl
         // 
         this.zLbl.AutoSize = true;
         this.zLbl.Location = new System.Drawing.Point(381, 25);
         this.zLbl.Name = "zLbl";
         this.zLbl.Size = new System.Drawing.Size(32, 13);
         this.zLbl.TabIndex = 4;
         this.zLbl.Text = "Z = 5";
         // 
         // yLbl
         // 
         this.yLbl.AutoSize = true;
         this.yLbl.Location = new System.Drawing.Point(198, 25);
         this.yLbl.Name = "yLbl";
         this.yLbl.Size = new System.Drawing.Size(32, 13);
         this.yLbl.TabIndex = 3;
         this.yLbl.Text = "Y = 5";
         // 
         // xLbl
         // 
         this.xLbl.AutoSize = true;
         this.xLbl.Location = new System.Drawing.Point(6, 25);
         this.xLbl.Name = "xLbl";
         this.xLbl.Size = new System.Drawing.Size(32, 13);
         this.xLbl.TabIndex = 2;
         this.xLbl.Text = "X = 5";
         // 
         // glControl
         // 
         this.glControl.BackColor = System.Drawing.Color.Black;
         this.glControl.Location = new System.Drawing.Point(97, 200);
         this.glControl.Name = "glControl";
         this.glControl.Size = new System.Drawing.Size(500, 500);
         this.glControl.TabIndex = 2;
         this.glControl.VSync = false;
         // 
         // timer
         // 
         this.timer.Tick += new System.EventHandler(this.timer_Tick);
         // 
         // timerTrackBar
         // 
         this.timerTrackBar.Location = new System.Drawing.Point(233, 149);
         this.timerTrackBar.Name = "timerTrackBar";
         this.timerTrackBar.Size = new System.Drawing.Size(219, 45);
         this.timerTrackBar.TabIndex = 3;
         this.timerTrackBar.Scroll += new System.EventHandler(this.timerTrackBar_Scroll);
         // 
         // timerLbl
         // 
         this.timerLbl.AutoSize = true;
         this.timerLbl.Location = new System.Drawing.Point(194, 149);
         this.timerLbl.Name = "timerLbl";
         this.timerLbl.Size = new System.Drawing.Size(33, 13);
         this.timerLbl.TabIndex = 4;
         this.timerLbl.Text = "Timer";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(684, 712);
         this.Controls.Add(this.timerLbl);
         this.Controls.Add(this.timerTrackBar);
         this.Controls.Add(this.glControl);
         this.Controls.Add(this.coordinatesGrp);
         this.Controls.Add(this.menuStrip);
         this.MainMenuStrip = this.menuStrip;
         this.MinimumSize = new System.Drawing.Size(700, 750);
         this.Name = "Form1";
         this.ShowIcon = false;
         this.Text = "3D Viewer                  Current Figure: None";
         this.menuStrip.ResumeLayout(false);
         this.menuStrip.PerformLayout();
         this.coordinatesGrp.ResumeLayout(false);
         this.coordinatesGrp.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      private void trackBar1_Scroll(object sender, System.EventArgs e)
      {
         throw new System.NotImplementedException();
      }

      #endregion

      private System.Windows.Forms.MenuStrip menuStrip;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.GroupBox coordinatesGrp;
      private System.Windows.Forms.TrackBar xTrackBar;
      private System.Windows.Forms.Label zLbl;
      private System.Windows.Forms.Label yLbl;
      private System.Windows.Forms.Label xLbl;
      private System.Windows.Forms.TrackBar zTrackBar;
      private System.Windows.Forms.TrackBar yTrackBar;
      private System.Windows.Forms.Button resetBtn;
      private OpenTK.GLControl glControl;
      private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
      private System.Windows.Forms.Timer timer;
      private System.Windows.Forms.TrackBar timerTrackBar;
      private System.Windows.Forms.Label timerLbl;
   }
}

