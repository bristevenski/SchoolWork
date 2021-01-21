'----------------------------------------------
' Name: Brianna Muleski
' Date: 4/17/2015
' Description: Program 7
'              Class FormOrderClass
'----------------------------------------------
Public Class FormOrderClass

    Dim _mainForm As Form
    Private orderView As New DataView()
    Private orderBinding As New BindingSource
    Private employeeBinding As New BindingSource
    Private detailView As New DataView(DataClass.detailTbl)
    Private detailBinding As New BindingSource

    ' Sets the main form to the given form.
    Public WriteOnly Property MainForm As Form
        Set(value As Form)
            _mainForm = value
        End Set
    End Property

    ' When the form is loaded, sets the tables, binding sources, and detail views for the
    ' orders and order details. Adds data bindings to the textboxes and sets the default 
    ' radio button.
    Private Sub FormOrderClass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        orderView.Table = DataClass.orderTbl
        orderBinding.DataSource = orderView
        detailBinding.DataSource = detailView

        dgvOrder.DataSource = orderBinding
        dgvDetail.DataSource = detailView
        employeeBinding.DataSource = DataClass.employeeTbl

        idTxt.DataBindings.Add("text", employeeBinding, "EmployeeID")
        nameTxt.DataBindings.Add("text", employeeBinding, "Name")
        allRdBtn.Checked = True
    End Sub

    ' Handles the event of clicking the back button on the form. Hides this form and 
    ' returns to the main form.
    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Me.Hide()
        _mainForm.Show()
        _mainForm.BringToFront()
    End Sub

    ' Handles the event of changing the selected item in the order data grid. Shows the order details of
    ' the selected order.
    Private Sub dgvOrder_SelectionChanged(sender As Object, e As EventArgs) Handles dgvOrder.SelectionChanged
        Dim ID As String

        If orderBinding.Position <> -1 Then
            ID = orderBinding.Current(0).ToString()
            If ID <> "" Then
                detailView.RowFilter = "OrderID = " & ID
            Else
                detailView.RowFilter = "1 = 0"
            End If
        Else
            detailView.RowFilter = "2 = 1"
        End If
    End Sub

    ' Handles the event of changing the selected radio button. Clears the data bindings and enables/disables the
    ' buttons on the form depending on which radio button is selected. Sets the data bindings if looking at orders
    ' by employees and sets the textboxes. Clears the textboxes if showing all orders.
    Private Sub allRdBtn_CheckedChanged(sender As Object, e As EventArgs) Handles allRdBtn.CheckedChanged, ordEmpRdBtn.CheckedChanged
        idTxt.DataBindings.Clear()
        nameTxt.DataBindings.Clear()

        If allRdBtn.Checked Then
            idTxt.Text = ""
            nameTxt.Text = ""
            prevBtn.Enabled = False
            nextBtn.Enabled = False
            orderView.RowFilter = ""
        ElseIf ordEmpRdBtn.Checked Then
            employeeBinding.Position = 0
            prevBtn.Enabled = False
            If employeeBinding.Count > 1 Then
                nextBtn.Enabled = True
            Else
                nextBtn.Enabled = False
            End If
            idTxt.DataBindings.Add("text", employeeBinding, "EmployeeID")
            nameTxt.DataBindings.Add("text", employeeBinding, "Name")
            orderView.RowFilter = "EmployeeID = '" & idTxt.Text & "'"
        End If
    End Sub

    ' Handles the event of clicking the update order button on the form. Saves the
    ' information entered to the data table. Catches all exceptions and ignores the changes.
    Private Sub updOrdBtn_Click(sender As Object, e As EventArgs) Handles updOrdBtn.Click
        Try
            Me.Validate()
            dgvOrder.EndEdit()
            DataClass.orderAdapter.Update(DataClass.orderTbl)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            DataClass.orderTbl.RejectChanges()
            dgvOrder.ShowRowErrors = False
        End Try
    End Sub

    ' Handles the event of clicking the previous button on the form. Shows the previous
    ' employee information in the textboxes.
    Private Sub prevBtn_Click(sender As Object, e As EventArgs) Handles prevBtn.Click
        nextBtn.Enabled = True
        employeeBinding.MovePrevious()
        If employeeBinding.Position = 0 Then
            prevBtn.Enabled = False
        End If
        orderView.RowFilter = "EmployeeID = " & idTxt.Text
    End Sub

    ' Handles the event of clicking the update details button on the form. Saves the
    ' information entered to the data table. Catches all exceptions and ignores the changes.
    Private Sub updDetBtn_Click(sender As Object, e As EventArgs) Handles updDetBtn.Click
        Try
            Me.Validate()
            dgvDetail.EndEdit()
            DataClass.detailAdapter.Update(DataClass.detailTbl)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            DataClass.detailTbl.RejectChanges()
            dgvDetail.ShowRowErrors = False
        End Try
    End Sub

    ' Handles the event of clicking the next button on the form. Shows the next
    ' employee information in the textboxes.
    Private Sub nextBtn_Click(sender As Object, e As EventArgs) Handles nextBtn.Click
        prevBtn.Enabled = True
        employeeBinding.MoveNext()
        If employeeBinding.Position = employeeBinding.Count - 1 Then
            nextBtn.Enabled = False
        End If
        orderView.RowFilter = "EmployeeID = '" & idTxt.Text & "'"
    End Sub
End Class