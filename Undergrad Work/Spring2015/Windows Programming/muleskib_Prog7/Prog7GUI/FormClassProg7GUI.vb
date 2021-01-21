'----------------------------------------------
' Name: Brianna Muleski
' Date: 4/17/2015
' Description: Program 7
'              Class FormClassProg7GUI
'----------------------------------------------
Imports UWPcs3340

Public Class FormClassProg7GUI
    Dim frmEmployee, frmProduct, frmCustomer As FormGridClass

    Dim frmOrder As FormOrderClass

    ' Handles the event of clicking the exit button on the form. Exits the application.
    Private Sub exitBtn_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
        Application.Exit()
    End Sub

    ' When the form is loaded, sets each data tables properties.
    Private Sub FormClassProg7GUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmEmployee = New FormGridClass
        frmEmployee.MainForm = Me
        frmEmployee.TheAdapter = DataClass.employeeAdapter
        frmEmployee.TheTable = DataClass.employeeTbl
        frmEmployee.Text = "Employee"

        frmProduct = New FormGridClass
        frmProduct.MainForm = Me
        frmProduct.TheAdapter = DataClass.productAdapter
        frmProduct.TheTable = DataClass.productTbl
        frmProduct.Text = "Product"

        frmOrder = New FormOrderClass
        frmOrder.MainForm = Me

        frmCustomer = New FormGridClass
        frmCustomer.MainForm = Me
        frmCustomer.TheAdapter = DataClass.productAdapter
        frmCustomer.TheTable = DataClass.productTbl
        frmCustomer.Text = "Customer"
    End Sub

    ' Handles the event of clicking the employee button on the form. Hides this
    ' form and shows the employee data grid form.
    Private Sub empBtn_Click(sender As Object, e As EventArgs) Handles empBtn.Click
        Me.Hide()
        frmEmployee.Show()
        frmEmployee.BringToFront()
    End Sub

    ' Handles the event of clicking the product button on the form. Hides this
    ' form and shows the product data grid form.
    Private Sub prodBtn_Click(sender As Object, e As EventArgs) Handles prodBtn.Click
        Me.Hide()
        frmProduct.Show()
        frmProduct.BringToFront()
    End Sub

    ' Handles the event of clicking the customer button on the form. Hides this
    ' form and shows the customer data grid form.
    Private Sub custBtn_Click(sender As Object, e As EventArgs) Handles custBtn.Click
        Me.Hide()
        frmCustomer.Show()
        frmCustomer.BringToFront()
    End Sub

    ' Handles the event of clicking the order button on the form. Hides this
    ' form and shows the order data grid form.
    Private Sub orderBtn_Click(sender As Object, e As EventArgs) Handles orderBtn.Click
        Me.Hide()
        frmOrder.Show()
        frmOrder.BringToFront()
    End Sub

    ' Handles the event of clicking the employee button on the form. Shows the
    ' full path of the database file.
    Private Sub dbLocBtn_Click(sender As Object, e As EventArgs) Handles dbLocBtn.Click
        MessageBox.Show(DataClass.myCon.DataSource)
    End Sub
End Class
