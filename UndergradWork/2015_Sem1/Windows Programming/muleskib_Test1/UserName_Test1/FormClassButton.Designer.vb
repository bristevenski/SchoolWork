<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClassButton
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
      Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
      Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.SWITCHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.EXITToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.ButtonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.CREATEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.REMOVEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.txtKey = New System.Windows.Forms.TextBox()
      Me.txtCaption = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.MenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'MenuStrip1
      '
      Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ButtonToolStripMenuItem})
      Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.MenuStrip1.Name = "MenuStrip1"
      Me.MenuStrip1.Size = New System.Drawing.Size(610, 24)
      Me.MenuStrip1.TabIndex = 0
      Me.MenuStrip1.Text = "MenuStrip1"
      '
      'FileToolStripMenuItem
      '
      Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SWITCHToolStripMenuItem, Me.EXITToolStripMenuItem})
      Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
      Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
      Me.FileToolStripMenuItem.Text = "&File"
      '
      'SWITCHToolStripMenuItem
      '
      Me.SWITCHToolStripMenuItem.Name = "SWITCHToolStripMenuItem"
      Me.SWITCHToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
      Me.SWITCHToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
      Me.SWITCHToolStripMenuItem.Text = "&SWITCH"
      '
      'EXITToolStripMenuItem
      '
      Me.EXITToolStripMenuItem.Name = "EXITToolStripMenuItem"
      Me.EXITToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
      Me.EXITToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
      Me.EXITToolStripMenuItem.Text = "E&XIT"
      '
      'ButtonToolStripMenuItem
      '
      Me.ButtonToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CREATEToolStripMenuItem, Me.REMOVEToolStripMenuItem})
      Me.ButtonToolStripMenuItem.Name = "ButtonToolStripMenuItem"
      Me.ButtonToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
      Me.ButtonToolStripMenuItem.Text = "&Button"
      '
      'CREATEToolStripMenuItem
      '
      Me.CREATEToolStripMenuItem.Name = "CREATEToolStripMenuItem"
      Me.CREATEToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
      Me.CREATEToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
      Me.CREATEToolStripMenuItem.Text = "&CREATE"
      '
      'REMOVEToolStripMenuItem
      '
      Me.REMOVEToolStripMenuItem.Name = "REMOVEToolStripMenuItem"
      Me.REMOVEToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
      Me.REMOVEToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
      Me.REMOVEToolStripMenuItem.Text = "&REMOVE"
      '
      'txtKey
      '
      Me.txtKey.Location = New System.Drawing.Point(331, 174)
      Me.txtKey.Name = "txtKey"
      Me.txtKey.Size = New System.Drawing.Size(100, 20)
      Me.txtKey.TabIndex = 1
      Me.txtKey.Text = "K3"
      '
      'txtCaption
      '
      Me.txtCaption.Location = New System.Drawing.Point(179, 174)
      Me.txtCaption.Name = "txtCaption"
      Me.txtCaption.Size = New System.Drawing.Size(100, 20)
      Me.txtCaption.TabIndex = 2
      Me.txtCaption.Text = "3"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(208, 145)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(43, 13)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "Caption"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(369, 145)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(25, 13)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "Key"
      '
      'FormClassButton
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(610, 368)
      Me.ControlBox = False
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtCaption)
      Me.Controls.Add(Me.txtKey)
      Me.Controls.Add(Me.MenuStrip1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MainMenuStrip = Me.MenuStrip1
      Me.Name = "FormClassButton"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Test1 (Brianna Muleski)"
      Me.MenuStrip1.ResumeLayout(False)
      Me.MenuStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
   Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents SWITCHToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents EXITToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ButtonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents CREATEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents REMOVEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents txtKey As System.Windows.Forms.TextBox
   Friend WithEvents txtCaption As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
