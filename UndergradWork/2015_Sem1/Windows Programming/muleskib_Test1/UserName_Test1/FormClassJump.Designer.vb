<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClassJump
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
      Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.mnuBACK = New System.Windows.Forms.ToolStripMenuItem()
      Me.mnuEXIT = New System.Windows.Forms.ToolStripMenuItem()
      Me.ContextMenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'ContextMenuStrip1
      '
      Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBACK, Me.mnuEXIT})
      Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
      Me.ContextMenuStrip1.Size = New System.Drawing.Size(146, 48)
      '
      'mnuBACK
      '
      Me.mnuBACK.Name = "mnuBACK"
      Me.mnuBACK.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
      Me.mnuBACK.Size = New System.Drawing.Size(145, 22)
      Me.mnuBACK.Text = "&BACK"
      '
      'mnuEXIT
      '
      Me.mnuEXIT.Name = "mnuEXIT"
      Me.mnuEXIT.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
      Me.mnuEXIT.Size = New System.Drawing.Size(152, 22)
      Me.mnuEXIT.Text = "E&XIT"
      '
      'FormClassJump
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(634, 382)
      Me.ControlBox = False
      Me.MinimumSize = New System.Drawing.Size(300, 150)
      Me.Name = "FormClassJump"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Test1 (Brianna Muleski)"
      Me.ContextMenuStrip1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents mnuBACK As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuEXIT As System.Windows.Forms.ToolStripMenuItem
End Class
