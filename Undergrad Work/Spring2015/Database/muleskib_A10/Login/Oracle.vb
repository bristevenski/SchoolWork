Imports System.Data.OracleClient

Public Enum ResponseType
   OK
   Cancel
End Enum

Public Class Oracle
   Friend Shared UserName As String
   Friend Shared PassWd As String
   Friend Shared Server As String
   Friend Shared result As ResponseType

   Friend Shared frmLogin As New Login
   Private Shared frmBooking As New Booking

   ' Make sure to add reference to System.Data.OracleClient
   Friend Shared myOracleDataAdapter As New OracleDataAdapter
   Friend Shared myOracleCommand As New OracleCommand
   Friend Shared myOracleConnection As New OracleConnection
   Friend Shared myOracleCommandBuilder As OracleCommandBuilder

   Friend Shared myTable As New System.Data.DataTable

   Public Shared Sub Login()
      myOracleConnection.ConnectionString = "user id=" & UserName & ";data source=" & Server & _
                                            ";password=" & PassWd & ";persist security info=False"

      myOracleCommand.CommandType = CommandType.Text
      myOracleCommand.CommandText = "Select * from booking"
      myOracleCommand.Connection = myOracleConnection

      myOracleDataAdapter.SelectCommand = myOracleCommand
      myOracleCommandBuilder = New OracleCommandBuilder(myOracleDataAdapter)

      myOracleDataAdapter.Fill(myTable)

   End Sub

Public Shared Sub main()
      Dim good As Boolean

      While Not good
         frmLogin.ShowDialog()
         If result = ResponseType.Cancel Then
            Exit While
         End If

         Try
            Login()
            good = True
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End While

      If good Then
         Application.Run(frmBooking)
      End If
   End Sub


End Class
