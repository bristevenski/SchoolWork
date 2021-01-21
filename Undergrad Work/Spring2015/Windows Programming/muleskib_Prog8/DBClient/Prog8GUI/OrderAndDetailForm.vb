Public Class OrderAndDetailForm
    Private _mainForm As Form

    Public WriteOnly Property MainForm As Form
        Set(value As Form)
            _mainForm = value
        End Set
    End Property
    Private Sub OrderAndDetailForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class