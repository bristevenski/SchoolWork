Public Class Login

   Private Sub okBtn_Click(sender As Object, e As EventArgs) Handles okBtn.Click
      Oracle.UserName = userTxt.Text
      Oracle.PassWd = passwordTxt.Text
      Oracle.Server = serverTxt.Text
      Oracle.result = ResponseType.OK
      Me.Close()
   End Sub

   Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
      Oracle.result = ResponseType.Cancel
      Me.Close()
   End Sub
End Class
