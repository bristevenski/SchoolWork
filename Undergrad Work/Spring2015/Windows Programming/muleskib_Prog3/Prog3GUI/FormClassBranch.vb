'----------------------------------------------
' Name: Brianna Muleski
' Date: 2/13/2015
' Description: Program 3
'              Class FormClassBranch
'              Inherits FormClassHouse
'----------------------------------------------
Public Class FormClassBranch
    Private _branchNo As Integer

    ' Sets the branch number, the title of the branch form, and the title of the list form.
    Public WriteOnly Property BranchNo As Integer
        Set(value As Integer)
            _branchNo = value
            Me.Text = "Branch #" & _branchNo
            _frmList.Text = "Branch #" & _branchNo
        End Set
    End Property

    ' Closes the branch form and the list form.
    Protected Overrides Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        _frmList.Close()
    End Sub
End Class
