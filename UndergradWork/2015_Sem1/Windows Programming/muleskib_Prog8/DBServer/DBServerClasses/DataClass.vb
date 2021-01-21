'----------------------------------------------
' Name: Brianna Muleski
' Date: 4/23/2015
' Description: Program 8
'              Class DataClass
'----------------------------------------------
Imports Microsoft.Win32

Public Class DataClass
    Public Shared myCon As New OleDb.OleDbConnection

    Public Shared employeeCmd As New OleDb.OleDbCommand
    Public Shared employeeAdapter As New OleDb.OleDbDataAdapter
    Public Shared employeeBuilder As OleDb.OleDbCommandBuilder

    Public Shared productCmd As New OleDb.OleDbCommand
    Public Shared productAdapter As New OleDb.OleDbDataAdapter
    Public Shared productBuilder As OleDb.OleDbCommandBuilder

    Public Shared orderCmd As New OleDb.OleDbCommand
    Public Shared orderAdapter As New OleDb.OleDbDataAdapter
    Public Shared orderBuilder As OleDb.OleDbCommandBuilder

    Public Shared detailCmd As New OleDb.OleDbCommand
    Public Shared detailAdapter As New OleDb.OleDbDataAdapter
    Public Shared detailBuilder As OleDb.OleDbCommandBuilder

    Public Shared myDataset As New Data.DataSet

    ' Sets the data tables and connection to the database. Catches all exceptions.
    ' If no database is selected, then an error message is displayed and the application
    ' is exited.
    Public Shared Sub SetUpAdapters()
        Dim dbLoc As String
        Dim connected As Boolean = False
        Try
            Dim connString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Company.mdb"
            myCon.ConnectionString = connString

            employeeCmd.Connection = myCon
            employeeCmd.CommandType = CommandType.Text
            employeeCmd.CommandText = "Select * from employees"
            employeeAdapter.SelectCommand = employeeCmd
            employeeBuilder = New OleDb.OleDbCommandBuilder(employeeAdapter)

            productCmd.Connection = myCon
            productCmd.CommandType = CommandType.Text
            productCmd.CommandText = "Select * from products"
            productAdapter.SelectCommand = productCmd
            productBuilder = New OleDb.OleDbCommandBuilder(productAdapter)

            orderCmd.Connection = myCon
            orderCmd.CommandType = CommandType.Text
            orderCmd.CommandText = "Select * from orders"
            orderAdapter.SelectCommand = orderCmd
            orderBuilder = New OleDb.OleDbCommandBuilder(orderAdapter)

            detailCmd.Connection = myCon
            detailCmd.CommandType = CommandType.Text
            detailCmd.CommandText = "Select * from orderDetails"
            detailAdapter.SelectCommand = detailCmd
            detailBuilder = New OleDb.OleDbCommandBuilder(detailAdapter)

            connected = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Sub SetUpTables()

    End Sub

End Class
