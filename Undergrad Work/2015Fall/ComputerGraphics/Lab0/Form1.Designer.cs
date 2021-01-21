namespace Lab0
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
         this.glControl1 = new OpenTK.GLControl();
         this.btnShow = new System.Windows.Forms.Button();
         this.colorCombo = new System.Windows.Forms.ComboBox();
         this.RdBtnRotateClrs = new System.Windows.Forms.RadioButton();
         this.RdBtnSingleClr = new System.Windows.Forms.RadioButton();
         this.colorGrpBox = new System.Windows.Forms.GroupBox();
         this.colorChangeTimer = new System.Windows.Forms.Timer(this.components);
         this.colorGrpBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // glControl1
         // 
         this.glControl1.BackColor = System.Drawing.Color.Black;
         this.glControl1.Location = new System.Drawing.Point(87, 75);
         this.glControl1.Name = "glControl1";
         this.glControl1.Size = new System.Drawing.Size(443, 443);
         this.glControl1.TabIndex = 0;
         this.glControl1.VSync = false;
         // 
         // btnShow
         // 
         this.btnShow.Location = new System.Drawing.Point(22, 536);
         this.btnShow.Name = "btnShow";
         this.btnShow.Size = new System.Drawing.Size(75, 23);
         this.btnShow.TabIndex = 1;
         this.btnShow.Text = "Show";
         this.btnShow.UseVisualStyleBackColor = true;
         this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
         // 
         // colorCombo
         // 
         this.colorCombo.FormattingEnabled = true;
         this.colorCombo.Items.AddRange(new object[] {
            "Blue",
            "Red",
            "Green",
            "White"});
         this.colorCombo.Location = new System.Drawing.Point(103, 538);
         this.colorCombo.Name = "colorCombo";
         this.colorCombo.Size = new System.Drawing.Size(121, 21);
         this.colorCombo.TabIndex = 2;
         this.colorCombo.Text = "Select Color";
         this.colorCombo.SelectedIndexChanged += new System.EventHandler(this.colorCombo_SelectedIndexChanged);
         // 
         // RdBtnRotateClrs
         // 
         this.RdBtnRotateClrs.AutoSize = true;
         this.RdBtnRotateClrs.Location = new System.Drawing.Point(100, 19);
         this.RdBtnRotateClrs.Name = "RdBtnRotateClrs";
         this.RdBtnRotateClrs.Size = new System.Drawing.Size(89, 17);
         this.RdBtnRotateClrs.TabIndex = 3;
         this.RdBtnRotateClrs.TabStop = true;
         this.RdBtnRotateClrs.Text = "Rotate Colors";
         this.RdBtnRotateClrs.UseVisualStyleBackColor = true;
         this.RdBtnRotateClrs.CheckedChanged += new System.EventHandler(this.RdBtnRotateClrs_CheckedChanged);
         // 
         // RdBtnSingleClr
         // 
         this.RdBtnSingleClr.AutoSize = true;
         this.RdBtnSingleClr.Location = new System.Drawing.Point(9, 19);
         this.RdBtnSingleClr.Name = "RdBtnSingleClr";
         this.RdBtnSingleClr.Size = new System.Drawing.Size(81, 17);
         this.RdBtnSingleClr.TabIndex = 4;
         this.RdBtnSingleClr.TabStop = true;
         this.RdBtnSingleClr.Text = "Single Color";
         this.RdBtnSingleClr.UseVisualStyleBackColor = true;
         this.RdBtnSingleClr.CheckedChanged += new System.EventHandler(this.RdBtnSingleClr_CheckedChanged);
         // 
         // colorGrpBox
         // 
         this.colorGrpBox.Controls.Add(this.RdBtnRotateClrs);
         this.colorGrpBox.Controls.Add(this.RdBtnSingleClr);
         this.colorGrpBox.Location = new System.Drawing.Point(200, 12);
         this.colorGrpBox.Name = "colorGrpBox";
         this.colorGrpBox.Size = new System.Drawing.Size(200, 46);
         this.colorGrpBox.TabIndex = 5;
         this.colorGrpBox.TabStop = false;
         this.colorGrpBox.Text = "Color Effects";
         // 
         // colorChangeTimer
         // 
         this.colorChangeTimer.Enabled = true;
         this.colorChangeTimer.Interval = 1000;
         this.colorChangeTimer.Tick += new System.EventHandler(this.colorChangeTimer_Tick);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(603, 659);
         this.Controls.Add(this.colorCombo);
         this.Controls.Add(this.btnShow);
         this.Controls.Add(this.glControl1);
         this.Controls.Add(this.colorGrpBox);
         this.Name = "Form1";
         this.Text = "My First OpenGL Lab";
         this.colorGrpBox.ResumeLayout(false);
         this.colorGrpBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private OpenTK.GLControl glControl1;
      private System.Windows.Forms.Button btnShow;
      private System.Windows.Forms.ComboBox colorCombo;
      private System.Windows.Forms.RadioButton RdBtnRotateClrs;
      private System.Windows.Forms.RadioButton RdBtnSingleClr;
      private System.Windows.Forms.GroupBox colorGrpBox;
      private System.Windows.Forms.Timer colorChangeTimer;
   }
}

