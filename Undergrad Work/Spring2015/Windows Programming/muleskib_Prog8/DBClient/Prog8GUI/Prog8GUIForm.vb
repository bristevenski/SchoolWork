Imports UWPCS3340

Public Class Prog8GUIForm
    Dim _url As String
    Dim _theServer As ServerClass
    Dim frmEmployee, frmProduct, frmCustomer As FormGridClass
    Dim frmOrder As OrderAndDetailForm

    Private Sub Prog8GUIForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmEmployee = New FormGridClass
        frmEmployee.MainForm = Me
        frmEmployee.TableName = "Employees"

        frmProduct = New FormGridClass
        frmProduct.MainForm = Me
        frmProduct.TableName = "Products"

        frmOrder = New OrderAndDetailForm
        frmOrder.MainForm = Me

        frmCustomer = New FormGridClass
        frmCustomer.MainForm = Me
        frmCustomer.TableName = "Customer"
    End Sub

    Private Sub exitBtn_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
        Application.Exit()
    End Sub

    Private Sub localRdBtn_CheckedChanged(sender As Object, e As EventArgs) Handles localRdBtn.CheckedChanged
        If localRdBtn.Checked Then
            _url = "tcp://localhost:8081/Prog8"
        Else
            _url = "tcp://" + hostTxt.Text + ":8081/Prog8"
        End If

        _theServer = CType(Activator.GetObject(GetType(ServerClass), _url), ServerClass)
    End Sub

    Private Sub productsBtn_Click(sender As Object, e As EventArgs) Handles productsBtn.Click
        frmProduct.DBServer = _theServer
        Me.Hide()
        frmProduct.Show()
        frmProduct.BringToFront()
    End Sub

    Private Sub customersBtn_Click(sender As Object, e As EventArgs) Handles customersBtn.Click
        frmCustomer.DBServer = _theServer
        Me.Hide()
        frmCustomer.Show()
        frmCustomer.BringToFront()
    End Sub

    Private Sub employeeBtn_Click(sender As Object, e As EventArgs) Handles employeeBtn.Click
        frmEmployee.DBServer = _theServer
        Me.Hide()
        frmEmployee.Show()
        frmEmployee.BringToFront()
    End Sub
End Class