namespace Prog4
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.ambientLbl = new System.Windows.Forms.Label();
         this.ambient = new System.Windows.Forms.NumericUpDown();
         this.lightZ = new System.Windows.Forms.TrackBar();
         this.lightY = new System.Windows.Forms.TrackBar();
         this.lightX = new System.Windows.Forms.TrackBar();
         this.lightZLbl = new System.Windows.Forms.Label();
         this.lightYLbl = new System.Windows.Forms.Label();
         this.lightXLbl = new System.Windows.Forms.Label();
         this.lightClrLbl = new System.Windows.Forms.Label();
         this.lightColor = new System.Windows.Forms.ComboBox();
         this.menuStrip.SuspendLayout();
         this.coordinatesGrp.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).BeginInit();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.ambient)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lightZ)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lightY)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lightX)).BeginInit();
         this.SuspendLayout();
         // 
         // menuStrip
         // 
         this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
         this.menuStrip.Location = new System.Drawing.Point(0, 0);
         this.menuStrip.Name = "menuStrip";
         this.menuStrip.Size = new System.Drawing.Size(1184, 24);
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
         this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.exitToolStripMenuItem.Text = "Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
         this.coordinatesGrp.Location = new System.Drawing.Point(983, 38);
         this.coordinatesGrp.Name = "coordinatesGrp";
         this.coordinatesGrp.Size = new System.Drawing.Size(185, 296);
         this.coordinatesGrp.TabIndex = 1;
         this.coordinatesGrp.TabStop = false;
         this.coordinatesGrp.Text = "X, Y, Z values of the View Reference Point (Eyeball) looking at (0,0,0) with Y up" +
    "";
         // 
         // resetBtn
         // 
         this.resetBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.resetBtn.Location = new System.Drawing.Point(49, 264);
         this.resetBtn.Name = "resetBtn";
         this.resetBtn.Size = new System.Drawing.Size(75, 23);
         this.resetBtn.TabIndex = 8;
         this.resetBtn.Text = "RESET";
         this.resetBtn.UseVisualStyleBackColor = true;
         this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
         // 
         // zTrackBar
         // 
         this.zTrackBar.Location = new System.Drawing.Point(9, 224);
         this.zTrackBar.Maximum = 500;
         this.zTrackBar.Minimum = -500;
         this.zTrackBar.Name = "zTrackBar";
         this.zTrackBar.Size = new System.Drawing.Size(164, 45);
         this.zTrackBar.TabIndex = 7;
         this.zTrackBar.Scroll += new System.EventHandler(this.zTrackBar_Scroll);
         // 
         // yTrackBar
         // 
         this.yTrackBar.Location = new System.Drawing.Point(6, 160);
         this.yTrackBar.Maximum = 500;
         this.yTrackBar.Minimum = -500;
         this.yTrackBar.Name = "yTrackBar";
         this.yTrackBar.Size = new System.Drawing.Size(164, 45);
         this.yTrackBar.TabIndex = 6;
         this.yTrackBar.Scroll += new System.EventHandler(this.yTrackBar_Scroll);
         // 
         // xTrackBar
         // 
         this.xTrackBar.Location = new System.Drawing.Point(6, 96);
         this.xTrackBar.Maximum = 500;
         this.xTrackBar.Minimum = -500;
         this.xTrackBar.Name = "xTrackBar";
         this.xTrackBar.Size = new System.Drawing.Size(164, 45);
         this.xTrackBar.TabIndex = 5;
         this.xTrackBar.Scroll += new System.EventHandler(this.xTrackBar_Scroll);
         // 
         // zLbl
         // 
         this.zLbl.AutoSize = true;
         this.zLbl.Location = new System.Drawing.Point(12, 208);
         this.zLbl.Name = "zLbl";
         this.zLbl.Size = new System.Drawing.Size(32, 13);
         this.zLbl.TabIndex = 4;
         this.zLbl.Text = "Z = 5";
         // 
         // yLbl
         // 
         this.yLbl.AutoSize = true;
         this.yLbl.Location = new System.Drawing.Point(6, 144);
         this.yLbl.Name = "yLbl";
         this.yLbl.Size = new System.Drawing.Size(32, 13);
         this.yLbl.TabIndex = 3;
         this.yLbl.Text = "Y = 5";
         // 
         // xLbl
         // 
         this.xLbl.AutoSize = true;
         this.xLbl.Location = new System.Drawing.Point(12, 74);
         this.xLbl.Name = "xLbl";
         this.xLbl.Size = new System.Drawing.Size(32, 13);
         this.xLbl.TabIndex = 2;
         this.xLbl.Text = "X = 5";
         // 
         // glControl
         // 
         this.glControl.BackColor = System.Drawing.Color.Black;
         this.glControl.Location = new System.Drawing.Point(12, 38);
         this.glControl.Name = "glControl";
         this.glControl.Size = new System.Drawing.Size(953, 811);
         this.glControl.TabIndex = 2;
         this.glControl.VSync = false;
         // 
         // timer
         // 
         this.timer.Enabled = true;
         this.timer.Interval = 50;
         this.timer.Tick += new System.EventHandler(this.timer_Tick);
         // 
         // timerTrackBar
         // 
         this.timerTrackBar.Location = new System.Drawing.Point(980, 389);
         this.timerTrackBar.Maximum = 500;
         this.timerTrackBar.Minimum = 50;
         this.timerTrackBar.Name = "timerTrackBar";
         this.timerTrackBar.Size = new System.Drawing.Size(189, 45);
         this.timerTrackBar.TabIndex = 3;
         this.timerTrackBar.Value = 200;
         this.timerTrackBar.Scroll += new System.EventHandler(this.timerTrackBar_Scroll);
         // 
         // timerLbl
         // 
         this.timerLbl.AutoSize = true;
         this.timerLbl.Location = new System.Drawing.Point(986, 373);
         this.timerLbl.Name = "timerLbl";
         this.timerLbl.Size = new System.Drawing.Size(33, 13);
         this.timerLbl.TabIndex = 4;
         this.timerLbl.Text = "Timer";
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.ambientLbl);
         this.groupBox1.Controls.Add(this.ambient);
         this.groupBox1.Controls.Add(this.lightZ);
         this.groupBox1.Controls.Add(this.lightY);
         this.groupBox1.Controls.Add(this.lightX);
         this.groupBox1.Controls.Add(this.lightZLbl);
         this.groupBox1.Controls.Add(this.lightYLbl);
         this.groupBox1.Controls.Add(this.lightXLbl);
         this.groupBox1.Controls.Add(this.lightClrLbl);
         this.groupBox1.Controls.Add(this.lightColor);
         this.groupBox1.Location = new System.Drawing.Point(983, 482);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(185, 367);
         this.groupBox1.TabIndex = 5;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Lighting Settings";
         // 
         // ambientLbl
         // 
         this.ambientLbl.AutoSize = true;
         this.ambientLbl.Location = new System.Drawing.Point(6, 32);
         this.ambientLbl.Name = "ambientLbl";
         this.ambientLbl.Size = new System.Drawing.Size(78, 13);
         this.ambientLbl.TabIndex = 15;
         this.ambientLbl.Text = "Global Ambient";
         // 
         // ambient
         // 
         this.ambient.DecimalPlaces = 1;
         this.ambient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
         this.ambient.Location = new System.Drawing.Point(99, 30);
         this.ambient.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
         this.ambient.Name = "ambient";
         this.ambient.Size = new System.Drawing.Size(57, 20);
         this.ambient.TabIndex = 14;
         this.ambient.ValueChanged += new System.EventHandler(this.ambient_ValueChanged);
         // 
         // lightZ
         // 
         this.lightZ.Location = new System.Drawing.Point(6, 327);
         this.lightZ.Maximum = 500;
         this.lightZ.Minimum = -500;
         this.lightZ.Name = "lightZ";
         this.lightZ.Size = new System.Drawing.Size(164, 45);
         this.lightZ.TabIndex = 13;
         this.lightZ.Value = 50;
         this.lightZ.Scroll += new System.EventHandler(this.lightZ_Scroll);
         // 
         // lightY
         // 
         this.lightY.Location = new System.Drawing.Point(6, 248);
         this.lightY.Maximum = 500;
         this.lightY.Minimum = -500;
         this.lightY.Name = "lightY";
         this.lightY.Size = new System.Drawing.Size(164, 45);
         this.lightY.TabIndex = 12;
         this.lightY.Value = 50;
         this.lightY.Scroll += new System.EventHandler(this.lightY_Scroll);
         // 
         // lightX
         // 
         this.lightX.Location = new System.Drawing.Point(6, 160);
         this.lightX.Maximum = 500;
         this.lightX.Minimum = -500;
         this.lightX.Name = "lightX";
         this.lightX.Size = new System.Drawing.Size(164, 45);
         this.lightX.TabIndex = 11;
         this.lightX.Value = 50;
         this.lightX.Scroll += new System.EventHandler(this.lightX_Scroll);
         // 
         // lightZLbl
         // 
         this.lightZLbl.AutoSize = true;
         this.lightZLbl.Location = new System.Drawing.Point(6, 311);
         this.lightZLbl.Name = "lightZLbl";
         this.lightZLbl.Size = new System.Drawing.Size(32, 13);
         this.lightZLbl.TabIndex = 10;
         this.lightZLbl.Text = "Z = 5";
         // 
         // lightYLbl
         // 
         this.lightYLbl.AutoSize = true;
         this.lightYLbl.Location = new System.Drawing.Point(6, 232);
         this.lightYLbl.Name = "lightYLbl";
         this.lightYLbl.Size = new System.Drawing.Size(32, 13);
         this.lightYLbl.TabIndex = 9;
         this.lightYLbl.Text = "Y = 5";
         // 
         // lightXLbl
         // 
         this.lightXLbl.AutoSize = true;
         this.lightXLbl.Location = new System.Drawing.Point(6, 144);
         this.lightXLbl.Name = "lightXLbl";
         this.lightXLbl.Size = new System.Drawing.Size(32, 13);
         this.lightXLbl.TabIndex = 8;
         this.lightXLbl.Text = "X = 5";
         // 
         // lightClrLbl
         // 
         this.lightClrLbl.AutoSize = true;
         this.lightClrLbl.Location = new System.Drawing.Point(6, 86);
         this.lightClrLbl.Name = "lightClrLbl";
         this.lightClrLbl.Size = new System.Drawing.Size(31, 13);
         this.lightClrLbl.TabIndex = 1;
         this.lightClrLbl.Text = "Color";
         // 
         // lightColor
         // 
         this.lightColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.lightColor.FormattingEnabled = true;
         this.lightColor.Items.AddRange(new object[] {
            "White",
            "Black",
            "Red",
            "Green",
            "Blue",
            "Yellow",
            "Magenta",
            "Cyan"});
         this.lightColor.Location = new System.Drawing.Point(43, 83);
         this.lightColor.Name = "lightColor";
         this.lightColor.Size = new System.Drawing.Size(121, 21);
         this.lightColor.TabIndex = 0;
         this.lightColor.SelectedIndexChanged += new System.EventHandler(this.lightColor_SelectedIndexChanged);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1184, 861);
         this.Controls.Add(this.coordinatesGrp);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.timerLbl);
         this.Controls.Add(this.timerTrackBar);
         this.Controls.Add(this.glControl);
         this.Controls.Add(this.menuStrip);
         this.MainMenuStrip = this.menuStrip;
         this.Name = "Form1";
         this.ShowIcon = false;
         this.Text = "3D Viewer                  Current Figure: None";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
         this.Load += new System.EventHandler(this.Form1_Load);
         this.Shown += new System.EventHandler(this.Form1_Shown);
         this.menuStrip.ResumeLayout(false);
         this.menuStrip.PerformLayout();
         this.coordinatesGrp.ResumeLayout(false);
         this.coordinatesGrp.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.ambient)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lightZ)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lightY)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lightX)).EndInit();
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
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label lightClrLbl;
      private System.Windows.Forms.ComboBox lightColor;
      private System.Windows.Forms.Label ambientLbl;
      private System.Windows.Forms.NumericUpDown ambient;
      private System.Windows.Forms.TrackBar lightZ;
      private System.Windows.Forms.TrackBar lightY;
      private System.Windows.Forms.TrackBar lightX;
      private System.Windows.Forms.Label lightZLbl;
      private System.Windows.Forms.Label lightYLbl;
      private System.Windows.Forms.Label lightXLbl;
   }
}

