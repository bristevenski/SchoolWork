Public Class ServerClass
    Inherits MarshalByRefObject

    Public Sub New()
        DataClass.SetUpAdapters()
    End Sub

    Public Function getTable(ByVal tableName As String) As DataTable
        Dim tbl As New DataTable

        Console.WriteLine()
        Console.WriteLine("Loading table " & tableName & "...")

        If tableName.ToLower = "employees" Then
            DataClass.employeeAdapter.Fill(tbl)
        End If

        Console.WriteLine()
        Console.WriteLine("Table " & tableName & " loaded.")
        Return tbl
    End Function

    Public Sub updateTable(ByVal tableName As String, ByVal theTable As DataTable)
        Console.WriteLine()
        Console.WriteLine("Updating table " & tableName & "...")

        If tableName.ToLower = "employees" Then
            DataClass.employeeAdapter.Fill(theTable)
        End If

        Console.WriteLine()
        Console.WriteLine("Table " & tableName & " updated.")
    End Sub
End Class
