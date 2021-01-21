'----------------------------------------------
' Name: Brianna Muleski
' Date: 4/2/2015
' Description: Program 6
'              Class FormIndividualClass
'----------------------------------------------
Imports Microsoft.Win32

Public Class FormIndividualClass
    Private _mainForm As FormAllClass

    ' Sets the main form object.
    Public WriteOnly Property MainForm As FormAllClass
        Set(ByVal value As FormAllClass)
            _mainForm = value
        End Set
    End Property

    ' Loads the information of the employee from the database. Catches all exceptions and shows
    ' and error message.
    Private Sub FormIndividualClass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            EmployeeTableAdapter.Connection.ConnectionString = _mainForm.connString
            Me.EmployeeTableAdapter.Fill(Me.ActivityDataSet.Employee)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' Disables the reload, all employees, exit and first item navigation buttons and sets the first item as nothing.
    ' The empty detial page can then be used to create a new employee, but it will not be saved in the database until
    ' the user clicks the save button.
    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorAddNewItem.Click
        reloadBtn.Enabled = False
        allEmpBtn.Enabled = False
        exitBtn.Enabled = False
        BindingNavigatorMoveFirstItem.Enabled = False

        EmployeeBindingNavigator.MoveFirstItem = Nothing
    End Sub

    ' Enables the reload, all employees, exit and first item navigation buttons and sets the first item. 
    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.Click
        reloadBtn.Enabled = True
        allEmpBtn.Enabled = True
        exitBtn.Enabled = True
        BindingNavigatorMoveFirstItem.Enabled = True
        EmployeeBindingNavigator.MoveFirstItem = BindingNavigatorMoveFirstItem
    End Sub

    ' Reloads the database. Catches all exceptions and shows an error message.
    Private Sub reloadBtn_Click(sender As Object, e As EventArgs) Handles reloadBtn.Click
        Try
            Me.EmployeeTableAdapter.Fill(Me.ActivityDataSet.Employee)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' Exits the application.
    Private Sub exitBtn_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
        Application.Exit()
    End Sub

    ' Saves the information. Catches all exceptions and shows an error message.
    Private Sub saveItemBtn_Click(sender As Object, e As EventArgs) Handles saveItemBtn.Click
        Try
            Me.Validate()
            Me.EmployeeBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.ActivityDataSet)

            reloadBtn.Enabled = True
            allEmpBtn.Enabled = True
            exitBtn.Enabled = True
            BindingNavigatorMoveFirstItem.Enabled = True
            EmployeeBindingNavigator.MoveFirstItem = BindingNavigatorMoveFirstItem

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' Hides this form and shows the main form.
    Private Sub allEmpBtn_Click(sender As Object, e As EventArgs) Handles allEmpBtn.Click
        Me.Hide()
        _mainForm.Show()
    End Sub

    ' Handles the invalid input in the Deptartment textbox.
    Private Sub DepartmentTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DepartmentTextBox.KeyPress
        Dim ch As Char = e.KeyChar
        If Char.IsDigit(ch) And DepartmentTextBox.TextLength < 2 Then
            e.Handled = False
        ElseIf ch.Equals(ControlChars.Back) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class