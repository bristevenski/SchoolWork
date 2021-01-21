<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClassCSSE
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.grpCSSE = New System.Windows.Forms.GroupBox()
      Me.rdo334 = New System.Windows.Forms.RadioButton()
      Me.rdo234 = New System.Windows.Forms.RadioButton()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.btnModify = New System.Windows.Forms.Button()
      Me.btnScore = New System.Windows.Forms.Button()
      Me.btnDelta = New System.Windows.Forms.Button()
      Me.txtDelta = New System.Windows.Forms.TextBox()
      Me.txtScore = New System.Windows.Forms.TextBox()
      Me.btnUnload = New System.Windows.Forms.Button()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.lblMsg = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.grpCSSE.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grpCSSE
      '
      Me.grpCSSE.Controls.Add(Me.rdo334)
      Me.grpCSSE.Controls.Add(Me.rdo234)
      Me.grpCSSE.Location = New System.Drawing.Point(40, 67)
      Me.grpCSSE.Name = "grpCSSE"
      Me.grpCSSE.Size = New System.Drawing.Size(157, 100)
      Me.grpCSSE.TabIndex = 7
      Me.grpCSSE.TabStop = False
      Me.grpCSSE.Text = "Select Object"
      '
      'rdo334
      '
      Me.rdo334.AutoSize = True
      Me.rdo334.Location = New System.Drawing.Point(45, 66)
      Me.rdo334.Name = "rdo334"
      Me.rdo334.Size = New System.Drawing.Size(57, 17)
      Me.rdo334.TabIndex = 1
      Me.rdo334.Text = "CS334"
      Me.rdo334.UseVisualStyleBackColor = True
      '
      'rdo234
      '
      Me.rdo234.AutoSize = True
      Me.rdo234.Location = New System.Drawing.Point(45, 27)
      Me.rdo234.Name = "rdo234"
      Me.rdo234.Size = New System.Drawing.Size(57, 17)
      Me.rdo234.TabIndex = 0
      Me.rdo234.Text = "CS234"
      Me.rdo234.UseVisualStyleBackColor = True
      '
      'btnReset
      '
      Me.btnReset.Location = New System.Drawing.Point(40, 215)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 4
      Me.btnReset.Text = "Reset"
      Me.btnReset.UseVisualStyleBackColor = True
      '
      'btnModify
      '
      Me.btnModify.Location = New System.Drawing.Point(486, 215)
      Me.btnModify.Name = "btnModify"
      Me.btnModify.Size = New System.Drawing.Size(75, 23)
      Me.btnModify.TabIndex = 6
      Me.btnModify.Text = "Modify"
      Me.btnModify.UseVisualStyleBackColor = True
      '
      'btnScore
      '
      Me.btnScore.Location = New System.Drawing.Point(486, 155)
      Me.btnScore.Name = "btnScore"
      Me.btnScore.Size = New System.Drawing.Size(75, 23)
      Me.btnScore.TabIndex = 3
      Me.btnScore.Text = "Set Score"
      Me.btnScore.UseVisualStyleBackColor = True
      '
      'btnDelta
      '
      Me.btnDelta.Location = New System.Drawing.Point(486, 95)
      Me.btnDelta.Name = "btnDelta"
      Me.btnDelta.Size = New System.Drawing.Size(75, 23)
      Me.btnDelta.TabIndex = 1
      Me.btnDelta.Text = "Set Delta"
      Me.btnDelta.UseVisualStyleBackColor = True
      '
      'txtDelta
      '
      Me.txtDelta.Location = New System.Drawing.Point(329, 91)
      Me.txtDelta.Name = "txtDelta"
      Me.txtDelta.Size = New System.Drawing.Size(100, 20)
      Me.txtDelta.TabIndex = 0
      '
      'txtScore
      '
      Me.txtScore.Location = New System.Drawing.Point(329, 157)
      Me.txtScore.Name = "txtScore"
      Me.txtScore.Size = New System.Drawing.Size(100, 20)
      Me.txtScore.TabIndex = 2
      '
      'btnUnload
      '
      Me.btnUnload.Location = New System.Drawing.Point(185, 215)
      Me.btnUnload.Name = "btnUnload"
      Me.btnUnload.Size = New System.Drawing.Size(75, 23)
      Me.btnUnload.TabIndex = 5
      Me.btnUnload.Text = "Unload"
      Me.btnUnload.UseVisualStyleBackColor = True
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'lblMsg
      '
      Me.lblMsg.AutoSize = True
      Me.lblMsg.Location = New System.Drawing.Point(260, 29)
      Me.lblMsg.Name = "lblMsg"
      Me.lblMsg.Size = New System.Drawing.Size(0, 13)
      Me.lblMsg.TabIndex = 8
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(310, 28)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(0, 13)
      Me.Label1.TabIndex = 9
      '
      'FormClassCSSE
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(617, 304)
      Me.ControlBox = False
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblMsg)
      Me.Controls.Add(Me.btnUnload)
      Me.Controls.Add(Me.txtDelta)
      Me.Controls.Add(Me.txtScore)
      Me.Controls.Add(Me.grpCSSE)
      Me.Controls.Add(Me.btnDelta)
      Me.Controls.Add(Me.btnReset)
      Me.Controls.Add(Me.btnModify)
      Me.Controls.Add(Me.btnScore)
      Me.Name = "FormClassCSSE"
      Me.Text = "CSSE: CS234 & CS334"
      Me.grpCSSE.ResumeLayout(False)
      Me.grpCSSE.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grpCSSE As System.Windows.Forms.GroupBox
   Friend WithEvents rdo334 As System.Windows.Forms.RadioButton
   Friend WithEvents rdo234 As System.Windows.Forms.RadioButton
   Friend WithEvents btnReset As System.Windows.Forms.Button
   Friend WithEvents btnModify As System.Windows.Forms.Button
   Friend WithEvents btnScore As System.Windows.Forms.Button
   Friend WithEvents btnDelta As System.Windows.Forms.Button
   Friend WithEvents txtDelta As System.Windows.Forms.TextBox
   Friend WithEvents txtScore As System.Windows.Forms.TextBox
   Friend WithEvents btnUnload As System.Windows.Forms.Button
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents lblMsg As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
