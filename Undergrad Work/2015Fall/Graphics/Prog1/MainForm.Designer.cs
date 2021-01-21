namespace Prog1
{
    partial class MainForm
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
         this.typeCombo = new System.Windows.Forms.ComboBox();
         this.colorCombo = new System.Windows.Forms.ComboBox();
         this.lineWidth = new System.Windows.Forms.TrackBar();
         this.typeLbl = new System.Windows.Forms.Label();
         this.colorLbl = new System.Windows.Forms.Label();
         this.lineLbl = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.lineWidth)).BeginInit();
         this.SuspendLayout();
         // 
         // glControl
         // 
         this.glControl.BackColor = System.Drawing.Color.Black;
         this.glControl.Location = new System.Drawing.Point(12, 105);
         this.glControl.Name = "glControl";
         this.glControl.Size = new System.Drawing.Size(610, 494);
         this.glControl.TabIndex = 0;
         this.glControl.VSync = false;
         this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
         this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
         this.glControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseUp);
         // 
         // typeCombo
         // 
         this.typeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.typeCombo.FormattingEnabled = true;
         this.typeCombo.Items.AddRange(new object[] {
            "Line",
            "Rectangle"});
         this.typeCombo.Location = new System.Drawing.Point(12, 54);
         this.typeCombo.Name = "typeCombo";
         this.typeCombo.Size = new System.Drawing.Size(121, 21);
         this.typeCombo.TabIndex = 1;
         // 
         // colorCombo
         // 
         this.colorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.colorCombo.FormattingEnabled = true;
         this.colorCombo.Items.AddRange(new object[] {
            "White",
            "Red",
            "Blue",
            "Green",
            "Orange",
            "Yellow",
            "Purple"});
         this.colorCombo.Location = new System.Drawing.Point(162, 54);
         this.colorCombo.Name = "colorCombo";
         this.colorCombo.Size = new System.Drawing.Size(121, 21);
         this.colorCombo.TabIndex = 2;
         // 
         // lineWidth
         // 
         this.lineWidth.Location = new System.Drawing.Point(347, 54);
         this.lineWidth.Name = "lineWidth";
         this.lineWidth.Size = new System.Drawing.Size(195, 45);
         this.lineWidth.TabIndex = 3;
         this.lineWidth.Scroll += new System.EventHandler(this.lineWidth_Scroll);
         // 
         // typeLbl
         // 
         this.typeLbl.AutoSize = true;
         this.typeLbl.Location = new System.Drawing.Point(13, 35);
         this.typeLbl.Name = "typeLbl";
         this.typeLbl.Size = new System.Drawing.Size(63, 13);
         this.typeLbl.TabIndex = 4;
         this.typeLbl.Text = "Figure Type";
         // 
         // colorLbl
         // 
         this.colorLbl.AutoSize = true;
         this.colorLbl.Location = new System.Drawing.Point(162, 35);
         this.colorLbl.Name = "colorLbl";
         this.colorLbl.Size = new System.Drawing.Size(31, 13);
         this.colorLbl.TabIndex = 5;
         this.colorLbl.Text = "Color";
         // 
         // lineLbl
         // 
         this.lineLbl.AutoSize = true;
         this.lineLbl.Location = new System.Drawing.Point(356, 35);
         this.lineLbl.Name = "lineLbl";
         this.lineLbl.Size = new System.Drawing.Size(58, 13);
         this.lineLbl.TabIndex = 6;
         this.lineLbl.Text = "Line Width";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(634, 611);
         this.Controls.Add(this.lineLbl);
         this.Controls.Add(this.colorLbl);
         this.Controls.Add(this.typeLbl);
         this.Controls.Add(this.lineWidth);
         this.Controls.Add(this.colorCombo);
         this.Controls.Add(this.typeCombo);
         this.Controls.Add(this.glControl);
         this.MaximumSize = new System.Drawing.Size(650, 650);
         this.MinimumSize = new System.Drawing.Size(650, 650);
         this.Name = "MainForm";
         this.Text = "Brianna Muleski - Program 1";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.Shown += new System.EventHandler(this.MainForm_Shown);
         ((System.ComponentModel.ISupportInitialize)(this.lineWidth)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.ComboBox typeCombo;
        private System.Windows.Forms.ComboBox colorCombo;
        private System.Windows.Forms.TrackBar lineWidth;
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.Label colorLbl;
        private System.Windows.Forms.Label lineLbl;
    }
}

