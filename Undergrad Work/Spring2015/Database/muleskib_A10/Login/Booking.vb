Public Class Booking

   Private Sub Booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      dataGrid.DataSource = Oracle.myTable
   End Sub

   Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click
      Try
         Me.Validate()
         dataGrid.EndEdit()
         Oracle.myOracleDataAdapter.Update(Oracle.myTable)
      Catch ex As Exception
         MessageBox.Show(ex.Message)
         Oracle.myTable.RejectChanges()
         dataGrid.ShowRowErrors = False
      End Try
   End Sub

   Private Sub exitBtn_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
      Application.Exit()
   End Sub

   Private Sub allBtn_Click(sender As Object, e As EventArgs) Handles allBtn.Click
      Oracle.myTable.Clear()

      Oracle.myOracleCommand.CommandType = CommandType.Text
      Oracle.myOracleCommand.CommandText = "Select * from booking"
      Oracle.myOracleCommand.Connection = Oracle.myOracleConnection

      Oracle.myOracleDataAdapter.SelectCommand = Oracle.myOracleCommand

      Oracle.myOracleDataAdapter.Fill(Oracle.myTable)
   End Sub

   Private Sub searchBtn_Click(sender As Object, e As EventArgs) Handles searchBtn.Click
      Dim fieldString As String = field.SelectedItem.ToString
      Dim opString As String = op.SelectedItem.ToString
      If fieldString = "Hotel_No" Or fieldString = "Guest_No" Or fieldString = "Room_No" Then
         Try
            Oracle.myOracleCommand.CommandText = _
                          "Select * " & _
                          "From Booking " & _
                          "Where " & fieldString & " " & opString & " '" & value.Text & "'"
            Oracle.myTable.Clear()
            Oracle.myOracleDataAdapter.SelectCommand = Oracle.myOracleCommand
            Oracle.myOracleDataAdapter.Fill(Oracle.myTable)
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      Else
         Try
            Oracle.myOracleCommand.CommandText = _
                          "Select * " & _
                          "From Booking " & _
                          "Where " & fieldString & " " & opString & "to_Date('" & value.Text & "', 'mm/dd/yyyy')"
            Oracle.myTable.Clear()
            Oracle.myOracleDataAdapter.SelectCommand = Oracle.myOracleCommand
            Oracle.myOracleDataAdapter.Fill(Oracle.myTable)
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End If
   End Sub
End Class