'----------------------------------------------
' Name: Brianna Muleski
' Date: 4/23/2015
' Description: Program 8
'              Class FormGridClass
'----------------------------------------------
Imports UWPCS3340

Public Class FormGridClass
    Private _mainForm As Form
    Private _tableName As String
    Private _server As ServerClass

    ' Sets _mainForm to the given form.
    Public WriteOnly Property MainForm() As Form
        Set(ByVal value As Form)
            _mainForm = value
        End Set
    End Property

    ' Sets the table name
    Public WriteOnly Property TableName() As String
        Set(value As String)
            _tableName = value
        End Set
    End Property

    ' Sets the reference to an object (proxy) of ServerClass
    ' This should be called just before the form is shown,
    ' not after the form is created.
    Public WriteOnly Property DBServer() As ServerClass
        Set(value As ServerClass)
            _server = value
        End Set
    End Property

    'Bonus Points
    ' Sets the format of column index of the datagridview
    Public WriteOnly Property DataGridViewColumnFormat(ByVal index As Integer) As String
        Set(value As String)

        End Set
    End Property

    'Bonus Points
    ' Sets the alignment of column index of the datagridview
    Public WriteOnly Property DataGridViewColumnAlignment(ByVal index As Integer) As DataGridViewContentAlignment
        Set(value As DataGridViewContentAlignment)

        End Set
    End Property

    ' When the form is closing then the reason is verified.
    Private Sub FormGridClass_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not e.CloseReason = CloseReason.ApplicationExitCall Then
            e.Cancel = True
        End If
    End Sub

    ' Handles the event of clicking the back button on the form. Hides this form and 
    ' returns to the main form.
    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Me.Hide()
        _mainForm.Show()
        _mainForm.BringToFront()
    End Sub

    ' Handles the event of clicking the save button on the form. Saves the information
    ' changed, updates the data table, and enables the buttons on the form. Catches all
    ' exceptions when attempting to save the information. 
    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        Try
            Me.Validate()
            Me.BindingSource1.EndEdit()
            '_theAdapter.Update(_theTable)
            Enable_Buttons()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' When the form is loaded, the data source, binding source, and grid view are set.
    Private Sub FormGridClass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'BindingSource1.DataSource = _theTable
        BindingNavigator1.BindingSource = BindingSource1
        DataGridView1.DataSource = BindingSource1
    End Sub

    ' Handles the event of clicking the add new button on the form. Disables the buttons
    ' on the form that are not used when adding a new item.
    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorAddNewItem.Click
        BindingNavigator1.MoveFirstItem = Nothing
        BindingNavigator1.MovePreviousItem = Nothing
        BindingNavigatorMoveFirstItem.Enabled = False
        BindingNavigatorMoveNextItem.Enabled = False
        BindingNavigatorMoveLastItem.Enabled = False
        BindingNavigatorMovePreviousItem.Enabled = False
        reloadBtn.Enabled = False
        backBtn.Enabled = False
    End Sub

    ' Handles the event of clicking the delete item button on the form. Enables the
    ' buttons on the form.
    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.Click
        Enable_Buttons()
    End Sub

    ' Enables the buttons and sets the binding navigator buttons on the form.
    Private Sub Enable_Buttons()
        BindingNavigator1.MovePreviousItem = BindingNavigatorMovePreviousItem
        BindingNavigator1.MoveFirstItem = BindingNavigatorMoveFirstItem
        BindingNavigatorMoveFirstItem.Enabled = True
        BindingNavigatorMoveNextItem.Enabled = True
        BindingNavigatorMoveLastItem.Enabled = True
        BindingNavigatorMovePreviousItem.Enabled = True
        reloadBtn.Enabled = True
        backBtn.Enabled = True
    End Sub
End Class
