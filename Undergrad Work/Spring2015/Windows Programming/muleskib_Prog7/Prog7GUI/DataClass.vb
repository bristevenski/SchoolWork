'----------------------------------------------
' Name: Brianna Muleski
' Date: 4/17/2015
' Description: Program 7
'              Class DataClass
'----------------------------------------------
Imports Microsoft.Win32

Public Class DataClass
    Public Shared myCon As New OleDb.OleDbConnection

    Public Shared employeeTbl As New System.Data.DataTable
    Public Shared employeeCmd As New OleDb.OleDbCommand
    Public Shared employeeAdapter As New OleDb.OleDbDataAdapter
    Public Shared employeeBuilder As OleDb.OleDbCommandBuilder

    Public Shared productTbl As New System.Data.DataTable
    Public Shared productCmd As New OleDb.OleDbCommand
    Public Shared productAdapter As New OleDb.OleDbDataAdapter
    Public Shared productBuilder As OleDb.OleDbCommandBuilder

    Public Shared orderTbl As New System.Data.DataTable("Orders")
    Public Shared orderCmd As New OleDb.OleDbCommand
    Public Shared orderAdapter As New OleDb.OleDbDataAdapter
    Public Shared orderBuilder As OleDb.OleDbCommandBuilder

    Public Shared detailTbl As New System.Data.DataTable
    Public Shared detailCmd As New OleDb.OleDbCommand
    Public Shared detailAdapter As New OleDb.OleDbDataAdapter
    Public Shared detailBuilder As OleDb.OleDbCommandBuilder

    Public Shared myDataset As New Data.DataSet

    Public Shared dbkey As Microsoft.Win32.RegistryKey

    ' Sets the data tables and connection to the database. Catches all exceptions.
    ' If no database is selected, then an error message is displayed and the application
    ' is exited.
    Public Shared Sub setUpTable()
        Dim dbLoc As String
        Dim connected As Boolean = False

        While Not connected
            Try
                dbkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\UWPCS3340Prog6")
                dbLoc = dbkey.GetValue("Software\UWPCS3340Prog7", "")
                Dim connString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbLoc
                myCon.ConnectionString = connString

                employeeCmd.Connection = myCon
                employeeCmd.CommandType = CommandType.Text
                employeeCmd.CommandText = "Select * from employees"
                employeeAdapter.SelectCommand = employeeCmd
                employeeBuilder = New OleDb.OleDbCommandBuilder(employeeAdapter)
                employeeAdapter.Fill(employeeTbl)

                productCmd.Connection = myCon
                productCmd.CommandType = CommandType.Text
                productCmd.CommandText = "Select * from products"
                productAdapter.SelectCommand = productCmd
                productBuilder = New OleDb.OleDbCommandBuilder(productAdapter)
                productAdapter.Fill(productTbl)

                orderCmd.Connection = myCon
                orderCmd.CommandType = CommandType.Text
                orderCmd.CommandText = "Select * from orders"
                orderAdapter.SelectCommand = orderCmd
                orderBuilder = New OleDb.OleDbCommandBuilder(orderAdapter)
                orderAdapter.Fill(orderTbl)

                detailCmd.Connection = myCon
                detailCmd.CommandType = CommandType.Text
                detailCmd.CommandText = "Select * from orderDetails"
                detailAdapter.SelectCommand = detailCmd
                detailBuilder = New OleDb.OleDbCommandBuilder(detailAdapter)
                detailAdapter.Fill(detailTbl)
                connected = True

            Catch ex As Exception
                Dim openDB As New OpenFileDialog
                If openDB.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dbLoc = openDB.FileName
                    dbkey.SetValue("Software\UWPCS3340Prog7", dbLoc, RegistryValueKind.String)
                Else
                    Exit While
                End If
            End Try
        End While

        If Not connected Then
            MsgBox("No database selected!")
            Application.Exit()
        End If
    End Sub
End Class
