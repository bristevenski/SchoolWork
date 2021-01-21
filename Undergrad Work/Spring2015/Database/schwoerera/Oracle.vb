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
   Private Shared frmStaff As New Staff

    Friend Shared myConnection As New OracleClient.OracleConnection

    Friend Shared staffAdapter As New OracleClient.OracleDataAdapter
    Friend Shared staffCommand As New OracleClient.OracleCommand
    Friend Shared staffBuilder As OracleClient.OracleCommandBuilder
   Friend Shared staffTable As New DataTable("UWP_Staff")

    Friend Shared qualAdapter As New OracleClient.OracleDataAdapter
    Friend Shared qualCommand As New OracleClient.OracleCommand
    Friend Shared qualBuilder As OracleClient.OracleCommandBuilder
   Friend Shared qualTable As New DataTable("UWP_Qualifications")

    Friend Shared expAdapter As New OracleClient.OracleDataAdapter
    Friend Shared expCommand As New OracleClient.OracleCommand
    Friend Shared expBuilder As OracleClient.OracleCommandBuilder
   Friend Shared expTable As New DataTable("UWP_WorkExperience")

   Public Shared Sub Login()

      myConnection.ConnectionString = "user id=" & UserName & ";data source=" & Server & _
                                            ";password=" & PassWd & ";persist security info=False"

      ' set up staff table
      staffCommand.CommandType = CommandType.Text
      staffCommand.CommandText = "Select * from UWP_Staff"
      staffCommand.Connection = myConnection

      staffAdapter.SelectCommand = staffCommand
        staffBuilder = New OracleClient.OracleCommandBuilder(staffAdapter)
      staffAdapter.Fill(staffTable)

      ' set up qualification table
      qualCommand.CommandType = CommandType.Text
      qualCommand.CommandText = "Select * from UWP_Qualifications"
      qualCommand.Connection = myConnection

      qualAdapter.SelectCommand = qualCommand
        qualBuilder = New OracleClient.OracleCommandBuilder(qualAdapter)
      qualAdapter.Fill(qualTable)

      ' set up work experience table
      expCommand.CommandType = CommandType.Text
      expCommand.CommandText = "Select * from UWP_WorkExperience"
      expCommand.Connection = myConnection

      expAdapter.SelectCommand = expCommand
        expBuilder = New OracleClient.OracleCommandBuilder(expAdapter)
      expAdapter.Fill(expTable)

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
         Application.Run(frmStaff)
      End If
   End Sub


End Class
