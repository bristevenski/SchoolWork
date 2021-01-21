'----------------------------------------------
' Name: Brianna Muleski
' Date: 4/2/2015
' Description: Program 6
'              Class FormAllClass
'----------------------------------------------
Imports Microsoft.Win32

Public Class FormAllClass
    Private _frmIndividual As FormIndividualClass
    Friend connString As String
    Friend dbkey As Microsoft.Win32.RegistryKey

    ' When the form is loaded, the database is located, the location is saved, and
    ' the database is shown. If a database is not selected, an error message is shown.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dblocation As String
        Dim connected As Boolean = False

        _frmIndividual = New FormIndividualClass
        _frmIndividual.MainForm = Me

        While Not connected
            Try
                dbkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\UWPCS3340Prog6")
                dblocation = dbkey.GetValue("Software\UWPCS3340Prog6", "")
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dblocation

                EmployeeTableAdapter.Connection.ConnectionString = connString

                Me.EmployeeTableAdapter.Fill(Me.ActivityDataSet.Employee)
                connected = True

            Catch ex As Exception
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="

                Dim openDB As New OpenFileDialog
                If openDB.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dblocation = openDB.FileName
                    connString &= dblocation

                    dbkey.SetValue("Software\UWPCS3340Prog6", dblocation, RegistryValueKind.String)
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

    ' Saves the database information to the database file. Catches all exceptions and shows an error message.
    Private Sub EmployeeBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Validate()
            Me.EmployeeBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.ActivityDataSet)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' Exits the application.
    Private Sub exitBtn_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
        Application.Exit()
    End Sub

    ' Shows the location of the database file
    Private Sub dbLocBtn_Click(sender As Object, e As EventArgs) Handles dbLocBtn.Click
        MessageBox.Show(EmployeeTableAdapter.Connection.DataSource)
    End Sub

    ' Reloads the database with the current information of the database. If the database has been moved
    ' it will attempt to locate the database. If no database is selected then an error message is shown.
    Private Sub reloadBtn_Click(sender As Object, e As EventArgs) Handles reloadBtn.Click
        Dim dblocation As String
        Dim connString As String
        Dim connected As Boolean = False

        While Not connected
            Try
                dbkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\UWPCS3340Prog6")
                dblocation = dbkey.GetValue("Software\UWPCS3340Prog6", "")
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dblocation

                EmployeeTableAdapter.Connection.ConnectionString = connString

                Me.EmployeeTableAdapter.Fill(Me.ActivityDataSet.Employee)
                connected = True

            Catch ex As Exception
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="

                Dim openDB As New OpenFileDialog
                If openDB.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dblocation = openDB.FileName
                    connString &= dblocation

                    dbkey.SetValue("Software\UWPCS3340Prog6", dblocation, RegistryValueKind.String)
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

    ' Hides this form and shows the indvidual information for the person selected.
    Private Sub indBtn_Click(sender As Object, e As EventArgs) Handles indBtn.Click
        Me.Hide()
        _frmIndividual.Show()
    End Sub
End Class
