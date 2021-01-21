<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
      Me.cancelBtn = New System.Windows.Forms.Button()
      Me.okBtn = New System.Windows.Forms.Button()
      Me.serverTxt = New System.Windows.Forms.TextBox()
      Me.passwordTxt = New System.Windows.Forms.TextBox()
      Me.userTxt = New System.Windows.Forms.TextBox()
      Me.serverLbl = New System.Windows.Forms.Label()
      Me.passwordLbl = New System.Windows.Forms.Label()
      Me.userLbl = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'cancelBtn
      '
      Me.cancelBtn.Location = New System.Drawing.Point(286, 210)
      Me.cancelBtn.Name = "cancelBtn"
      Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
      Me.cancelBtn.TabIndex = 5
      Me.cancelBtn.Text = "Cancel"
      Me.cancelBtn.UseVisualStyleBackColor = True
      '
      'okBtn
      '
      Me.okBtn.Location = New System.Drawing.Point(111, 210)
      Me.okBtn.Name = "okBtn"
      Me.okBtn.Size = New System.Drawing.Size(75, 23)
      Me.okBtn.TabIndex = 4
      Me.okBtn.Text = "OK"
      Me.okBtn.UseVisualStyleBackColor = True
      '
      'serverTxt
      '
      Me.serverTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.serverTxt.Location = New System.Drawing.Point(187, 157)
      Me.serverTxt.Name = "serverTxt"
      Me.serverTxt.Size = New System.Drawing.Size(100, 20)
      Me.serverTxt.TabIndex = 3
      '
      'passwordTxt
      '
      Me.passwordTxt.Location = New System.Drawing.Point(187, 101)
      Me.passwordTxt.Name = "passwordTxt"
      Me.passwordTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.passwordTxt.Size = New System.Drawing.Size(100, 20)
      Me.passwordTxt.TabIndex = 2
      '
      'userTxt
      '
      Me.userTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.userTxt.Location = New System.Drawing.Point(187, 56)
      Me.userTxt.Name = "userTxt"
      Me.userTxt.Size = New System.Drawing.Size(100, 20)
      Me.userTxt.TabIndex = 1
      '
      'serverLbl
      '
      Me.serverLbl.AutoSize = True
      Me.serverLbl.Location = New System.Drawing.Point(121, 160)
      Me.serverLbl.Name = "serverLbl"
      Me.serverLbl.Size = New System.Drawing.Size(38, 13)
      Me.serverLbl.TabIndex = 5
      Me.serverLbl.Text = "Server"
      '
      'passwordLbl
      '
      Me.passwordLbl.AutoSize = True
      Me.passwordLbl.Location = New System.Drawing.Point(121, 108)
      Me.passwordLbl.Name = "passwordLbl"
      Me.passwordLbl.Size = New System.Drawing.Size(53, 13)
      Me.passwordLbl.TabIndex = 6
      Me.passwordLbl.Text = "Password"
      '
      'userLbl
      '
      Me.userLbl.AutoSize = True
      Me.userLbl.Location = New System.Drawing.Point(121, 63)
      Me.userLbl.Name = "userLbl"
      Me.userLbl.Size = New System.Drawing.Size(57, 13)
      Me.userLbl.TabIndex = 7
      Me.userLbl.Text = "UserName"
      '
      'Login
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(469, 308)
      Me.Controls.Add(Me.userLbl)
      Me.Controls.Add(Me.passwordLbl)
      Me.Controls.Add(Me.serverLbl)
      Me.Controls.Add(Me.userTxt)
      Me.Controls.Add(Me.passwordTxt)
      Me.Controls.Add(Me.serverTxt)
      Me.Controls.Add(Me.okBtn)
      Me.Controls.Add(Me.cancelBtn)
      Me.Name = "Login"
      Me.Text = "Login - Brianna Muleski, Brianna Miller, Ashlyn Schwoerer"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cancelBtn As System.Windows.Forms.Button
   Friend WithEvents okBtn As System.Windows.Forms.Button
   Friend WithEvents serverTxt As System.Windows.Forms.TextBox
   Friend WithEvents passwordTxt As System.Windows.Forms.TextBox
   Friend WithEvents userTxt As System.Windows.Forms.TextBox
   Friend WithEvents serverLbl As System.Windows.Forms.Label
   Friend WithEvents passwordLbl As System.Windows.Forms.Label
   Friend WithEvents userLbl As System.Windows.Forms.Label

End Class
