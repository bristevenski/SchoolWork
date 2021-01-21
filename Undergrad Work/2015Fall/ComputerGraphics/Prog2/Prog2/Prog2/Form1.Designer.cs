namespace Prog2
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
         this.glControl = new OpenTK.GLControl();
         this.xTrackBar = new System.Windows.Forms.TrackBar();
         this.yTrackBar = new System.Windows.Forms.TrackBar();
         this.zTrackBar = new System.Windows.Forms.TrackBar();
         this.xLbl = new System.Windows.Forms.Label();
         this.yLbl = new System.Windows.Forms.Label();
         this.zLbl = new System.Windows.Forms.Label();
         this.resetBtn = new System.Windows.Forms.Button();
         this.coordinatesGrp = new System.Windows.Forms.GroupBox();
         this.menuStrip = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
         ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).BeginInit();
         this.coordinatesGrp.SuspendLayout();
         this.menuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // glControl
         // 
         this.glControl.BackColor = System.Drawing.Color.Black;
         this.glControl.Location = new System.Drawing.Point(12, 136);
         this.glControl.Name = "glControl";
         this.glControl.Size = new System.Drawing.Size(662, 560);
         this.glControl.TabIndex = 0;
         this.glControl.VSync = false;
         // 
         // xTrackBar
         // 
         this.xTrackBar.Location = new System.Drawing.Point(9, 39);
         this.xTrackBar.Maximum = 50;
         this.xTrackBar.Minimum = -50;
         this.xTrackBar.Name = "xTrackBar";
         this.xTrackBar.Size = new System.Drawing.Size(164, 45);
         this.xTrackBar.TabIndex = 1;
         this.xTrackBar.Scroll += new System.EventHandler(this.xTrackBar_Scroll);
         // 
         // yTrackBar
         // 
         this.yTrackBar.Location = new System.Drawing.Point(201, 39);
         this.yTrackBar.Maximum = 50;
         this.yTrackBar.Minimum = -50;
         this.yTrackBar.Name = "yTrackBar";
         this.yTrackBar.Size = new System.Drawing.Size(164, 45);
         this.yTrackBar.TabIndex = 2;
         this.yTrackBar.Scroll += new System.EventHandler(this.yTrackBar_Scroll);
         // 
         // zTrackBar
         // 
         this.zTrackBar.Location = new System.Drawing.Point(384, 39);
         this.zTrackBar.Maximum = 50;
         this.zTrackBar.Minimum = -50;
         this.zTrackBar.Name = "zTrackBar";
         this.zTrackBar.Size = new System.Drawing.Size(164, 45);
         this.zTrackBar.TabIndex = 3;
         this.zTrackBar.Scroll += new System.EventHandler(this.zTrackBar_Scroll);
         // 
         // xLbl
         // 
         this.xLbl.AutoSize = true;
         this.xLbl.Location = new System.Drawing.Point(6, 25);
         this.xLbl.Name = "xLbl";
         this.xLbl.Size = new System.Drawing.Size(32, 13);
         this.xLbl.TabIndex = 4;
         this.xLbl.Text = "X = 5";
         // 
         // yLbl
         // 
         this.yLbl.AutoSize = true;
         this.yLbl.Location = new System.Drawing.Point(198, 25);
         this.yLbl.Name = "yLbl";
         this.yLbl.Size = new System.Drawing.Size(32, 13);
         this.yLbl.TabIndex = 5;
         this.yLbl.Text = "Y = 5";
         // 
         // zLbl
         // 
         this.zLbl.AutoSize = true;
         this.zLbl.Location = new System.Drawing.Point(381, 25);
         this.zLbl.Name = "zLbl";
         this.zLbl.Size = new System.Drawing.Size(32, 13);
         this.zLbl.TabIndex = 6;
         this.zLbl.Text = "Z = 5";
         // 
         // resetBtn
         // 
         this.resetBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.resetBtn.Location = new System.Drawing.Point(579, 39);
         this.resetBtn.Name = "resetBtn";
         this.resetBtn.Size = new System.Drawing.Size(75, 23);
         this.resetBtn.TabIndex = 7;
         this.resetBtn.Text = "RESET";
         this.resetBtn.UseVisualStyleBackColor = true;
         this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
         // 
         // coordinatesGrp
         // 
         this.coordinatesGrp.Controls.Add(this.yLbl);
         this.coordinatesGrp.Controls.Add(this.zLbl);
         this.coordinatesGrp.Controls.Add(this.resetBtn);
         this.coordinatesGrp.Controls.Add(this.xLbl);
         this.coordinatesGrp.Controls.Add(this.yTrackBar);
         this.coordinatesGrp.Controls.Add(this.zTrackBar);
         this.coordinatesGrp.Controls.Add(this.xTrackBar);
         this.coordinatesGrp.Location = new System.Drawing.Point(12, 40);
         this.coordinatesGrp.Name = "coordinatesGrp";
         this.coordinatesGrp.Size = new System.Drawing.Size(662, 90);
         this.coordinatesGrp.TabIndex = 8;
         this.coordinatesGrp.TabStop = false;
         this.coordinatesGrp.Text = "X, Y, Z values of the View Reference Point (Eyeball) looking at (0,0,0) with Y up" +
    "";
         // 
         // menuStrip
         // 
         this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
         this.menuStrip.Location = new System.Drawing.Point(0, 0);
         this.menuStrip.Name = "menuStrip";
         this.menuStrip.Size = new System.Drawing.Size(684, 24);
         this.menuStrip.TabIndex = 9;
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
         this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.exitToolStripMenuItem.Text = "Exit";
         // 
         // openFileDialog
         // 
         this.openFileDialog.FileName = "openFileDialog";
         this.openFileDialog.Filter = "VRML files|*.wrl";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(684, 711);
         this.Controls.Add(this.glControl);
         this.Controls.Add(this.coordinatesGrp);
         this.Controls.Add(this.menuStrip);
         this.MainMenuStrip = this.menuStrip;
         this.MinimumSize = new System.Drawing.Size(700, 750);
         this.Name = "Form1";
         this.ShowIcon = false;
         this.Text = "3D Viewer                  Current Figure: None";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.Shown += new System.EventHandler(this.Form1_Shown);
         ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).EndInit();
         this.coordinatesGrp.ResumeLayout(false);
         this.coordinatesGrp.PerformLayout();
         this.menuStrip.ResumeLayout(false);
         this.menuStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private OpenTK.GLControl glControl;
      private System.Windows.Forms.TrackBar xTrackBar;
      private System.Windows.Forms.TrackBar yTrackBar;
      private System.Windows.Forms.TrackBar zTrackBar;
      private System.Windows.Forms.Label xLbl;
      private System.Windows.Forms.Label yLbl;
      private System.Windows.Forms.Label zLbl;
      private System.Windows.Forms.Button resetBtn;
      private System.Windows.Forms.GroupBox coordinatesGrp;
      private System.Windows.Forms.MenuStrip menuStrip;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.OpenFileDialog openFileDialog;
   }
}

