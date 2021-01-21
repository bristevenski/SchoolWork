<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTest4
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
      Me.txtLog = New System.Windows.Forms.TextBox()
      Me.lstWaiting = New System.Windows.Forms.ListBox()
      Me.btnOpen = New System.Windows.Forms.Button()
      Me.btnClose = New System.Windows.Forms.Button()
      Me.btnExit = New System.Windows.Forms.Button()
      Me.btnNew = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'txtLog
      '
      Me.txtLog.BackColor = System.Drawing.SystemColors.Window
      Me.txtLog.Location = New System.Drawing.Point(172, 55)
      Me.txtLog.Multiline = True
      Me.txtLog.Name = "txtLog"
      Me.txtLog.ReadOnly = True
      Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtLog.Size = New System.Drawing.Size(338, 264)
      Me.txtLog.TabIndex = 4
      Me.txtLog.TabStop = False
      '
      'lstWaiting
      '
      Me.lstWaiting.FormattingEnabled = True
      Me.lstWaiting.Location = New System.Drawing.Point(551, 55)
      Me.lstWaiting.Name = "lstWaiting"
      Me.lstWaiting.Size = New System.Drawing.Size(322, 264)
      Me.lstWaiting.TabIndex = 5
      Me.lstWaiting.TabStop = False
      '
      'btnOpen
      '
      Me.btnOpen.Location = New System.Drawing.Point(45, 106)
      Me.btnOpen.Name = "btnOpen"
      Me.btnOpen.Size = New System.Drawing.Size(75, 23)
      Me.btnOpen.TabIndex = 0
      Me.btnOpen.Text = "OPEN"
      Me.btnOpen.UseVisualStyleBackColor = True
      '
      'btnClose
      '
      Me.btnClose.Location = New System.Drawing.Point(45, 197)
      Me.btnClose.Name = "btnClose"
      Me.btnClose.Size = New System.Drawing.Size(75, 23)
      Me.btnClose.TabIndex = 2
      Me.btnClose.Text = "CLOSE"
      Me.btnClose.UseVisualStyleBackColor = True
      '
      'btnExit
      '
      Me.btnExit.Location = New System.Drawing.Point(412, 359)
      Me.btnExit.Name = "btnExit"
      Me.btnExit.Size = New System.Drawing.Size(75, 23)
      Me.btnExit.TabIndex = 3
      Me.btnExit.Text = "EXIT"
      Me.btnExit.UseVisualStyleBackColor = True
      '
      'btnNew
      '
      Me.btnNew.Location = New System.Drawing.Point(551, 359)
      Me.btnNew.Name = "btnNew"
      Me.btnNew.Size = New System.Drawing.Size(124, 23)
      Me.btnNew.TabIndex = 1
      Me.btnNew.Text = "NEW CUSTOMER"
      Me.btnNew.UseVisualStyleBackColor = True
      '
      'FormTest4
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(995, 440)
      Me.ControlBox = False
      Me.Controls.Add(Me.btnNew)
      Me.Controls.Add(Me.btnExit)
      Me.Controls.Add(Me.btnClose)
      Me.Controls.Add(Me.btnOpen)
      Me.Controls.Add(Me.lstWaiting)
      Me.Controls.Add(Me.txtLog)
      Me.Name = "FormTest4"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "BarberShop - Your Name!"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtLog As System.Windows.Forms.TextBox
   Friend WithEvents lstWaiting As System.Windows.Forms.ListBox
   Friend WithEvents btnOpen As System.Windows.Forms.Button
   Friend WithEvents btnClose As System.Windows.Forms.Button
   Friend WithEvents btnExit As System.Windows.Forms.Button
   Friend WithEvents btnNew As System.Windows.Forms.Button

End Class
