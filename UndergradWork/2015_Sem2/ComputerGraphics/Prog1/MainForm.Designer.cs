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
         this.typeLbl = new System.Windows.Forms.Label();
         this.colorLbl = new System.Windows.Forms.Label();
         this.lineLbl = new System.Windows.Forms.Label();
         this.lineWidth = new System.Windows.Forms.NumericUpDown();
         ((System.ComponentModel.ISupportInitialize)(this.lineWidth)).BeginInit();
         this.SuspendLayout();
         // 
         // glControl
         // 
         this.glControl.BackColor = System.Drawing.Color.Black;
         this.glControl.Location = new System.Drawing.Point(18, 162);
         this.glControl.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
         this.glControl.Name = "glControl";
         this.glControl.Size = new System.Drawing.Size(745, 565);
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
         this.typeCombo.Location = new System.Drawing.Point(136, 83);
         this.typeCombo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this.typeCombo.Name = "typeCombo";
         this.typeCombo.Size = new System.Drawing.Size(180, 28);
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
         this.colorCombo.Location = new System.Drawing.Point(352, 81);
         this.colorCombo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this.colorCombo.Name = "colorCombo";
         this.colorCombo.Size = new System.Drawing.Size(180, 28);
         this.colorCombo.TabIndex = 2;
         // 
         // typeLbl
         // 
         this.typeLbl.AutoSize = true;
         this.typeLbl.Location = new System.Drawing.Point(132, 54);
         this.typeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.typeLbl.Name = "typeLbl";
         this.typeLbl.Size = new System.Drawing.Size(92, 20);
         this.typeLbl.TabIndex = 4;
         this.typeLbl.Text = "Figure Type";
         // 
         // colorLbl
         // 
         this.colorLbl.AutoSize = true;
         this.colorLbl.Location = new System.Drawing.Point(348, 54);
         this.colorLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.colorLbl.Name = "colorLbl";
         this.colorLbl.Size = new System.Drawing.Size(46, 20);
         this.colorLbl.TabIndex = 5;
         this.colorLbl.Text = "Color";
         // 
         // lineLbl
         // 
         this.lineLbl.AutoSize = true;
         this.lineLbl.Location = new System.Drawing.Point(562, 54);
         this.lineLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.lineLbl.Name = "lineLbl";
         this.lineLbl.Size = new System.Drawing.Size(84, 20);
         this.lineLbl.TabIndex = 6;
         this.lineLbl.Text = "Line Width";
         // 
         // lineWidth
         // 
         this.lineWidth.Location = new System.Drawing.Point(566, 83);
         this.lineWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this.lineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.lineWidth.Name = "lineWidth";
         this.lineWidth.Size = new System.Drawing.Size(80, 26);
         this.lineWidth.TabIndex = 7;
         this.lineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(778, 744);
         this.Controls.Add(this.lineWidth);
         this.Controls.Add(this.lineLbl);
         this.Controls.Add(this.colorLbl);
         this.Controls.Add(this.typeLbl);
         this.Controls.Add(this.colorCombo);
         this.Controls.Add(this.typeCombo);
         this.Controls.Add(this.glControl);
         this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this.MaximumSize = new System.Drawing.Size(800, 800);
         this.MinimumSize = new System.Drawing.Size(800, 800);
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
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.Label colorLbl;
        private System.Windows.Forms.Label lineLbl;
        private System.Windows.Forms.NumericUpDown lineWidth;
    }
}

