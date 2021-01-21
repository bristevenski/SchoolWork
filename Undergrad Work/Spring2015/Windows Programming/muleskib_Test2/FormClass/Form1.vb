Public Class FormClassCSSE
   Private WithEvents valCSSE As CSSE
   Private val234 As UWPCS3340.CS234
   Private val334 As CS334


   Private Sub btnDelta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelta.Click
      Try
         valCSSE.Delta = txtDelta.Text
      Catch ex As Exception
         ErrorProvider1.SetError(txtDelta, ex.Message)
         btnScore.Enabled = False
         btnReset.Enabled = False
         btnModify.Enabled = False
         btnUnload.Enabled = False
         Return
      End Try

      ErrorProvider1.Clear()
      btnScore.Enabled = True
      btnReset.Enabled = True
      btnModify.Enabled = True
      btnUnload.Enabled = True
   End Sub

   Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      val234.Reset()
      val334.Reset()
      ChangeText()
   End Sub

   Private Sub btnScore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScore.Click
      Try
         valCSSE.Score = txtScore.Text
      Catch ex As Exception
         ErrorProvider1.SetError(txtScore, ex.Message)
         btnDelta.Enabled = False
         btnReset.Enabled = False
         btnModify.Enabled = False
         btnUnload.Enabled = False
         Return
      End Try

      ErrorProvider1.Clear()
      btnDelta.Enabled = True
      btnReset.Enabled = True
      btnModify.Enabled = True
      btnUnload.Enabled = True
   End Sub

   Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
      Try
         valCSSE.Modify()
      Catch ex As Exception
         ErrorProvider1.SetError(btnModify, ex.Message)
         Return
      End Try

      ErrorProvider1.Clear()
      txtScore.Text = valCSSE.Score
   End Sub

   Private Sub btnUnload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnload.Click
      val234.Dispose()
      val334.Dispose()
      Me.Close()
   End Sub

   Private Sub FormClassCSSE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      val234 = New CS234
      val334 = New CS334
      rdo234.Checked = True
      valCSSE = val234
      AddHandler valCSSE.PerfectScore, AddressOf ScoreHandler
      val234.Reset()
      val334.Reset()
      ChangeText()

   End Sub

   Private Sub TotalCountEventHandler(ByVal num As Integer) Handles valCSSE.TotalCountUpdated
      lblMsg.Text = "There are " & num & "objects"
   End Sub

   Private Sub rdo234_CheckedChanged(sender As Object, e As EventArgs) Handles rdo234.CheckedChanged
      If rdo234.Checked = True Then
         valCSSE = val234
      Else
         valCSSE = val334
      End If

      ChangeText()
   End Sub

   Private Sub ScoreHandler()
      MessageBox.Show("Perfect Score!")
   End Sub

   Private Sub ChangeText()
      txtDelta.Text = valCSSE.Delta
      txtScore.Text = valCSSE.Score
   End Sub
End Class
