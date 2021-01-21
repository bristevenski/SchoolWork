Public Class FormClassButton
   Private _frmJump As FormClassJump

   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      _frmJump = New FormClassJump
      _frmJump.MainForm = Me
   End Sub

   Private Sub FormClassButton_Load(sender As Object, e As EventArgs) Handles MyBase.Load

   End Sub

   Private Sub SWITCHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SWITCHToolStripMenuItem.Click
      Me.Hide()
      _frmJump.Show()
      _frmJump.BringToFront()
   End Sub

   Private Sub EXITToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXITToolStripMenuItem.Click
      Application.Exit()
   End Sub

   Private Sub CREATEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CREATEToolStripMenuItem.Click
      If txtKey.TextLength = 0 Then
         MessageBox.Show("Enter the key please!")
      Else
         Try
            _frmJump.CreateButton(txtKey.Text, txtCaption.Text)
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End If

   End Sub

   Private Sub REMOVEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REMOVEToolStripMenuItem.Click
      If txtKey.TextLength = 0 Then
         MessageBox.Show("Enter the key please!")
      Else
         Try
            _frmJump.RemoveButton(txtKey.Text)
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try

      End If
   End Sub
End Class
