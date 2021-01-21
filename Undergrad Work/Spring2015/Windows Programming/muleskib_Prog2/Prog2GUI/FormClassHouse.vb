'----------------------------------------------
' Name: Brianna Muleski
' Date: 2/2/2015
' Description: Program 2
'              Class FormClassHouse
'---------------------------------------------
Imports UWPCS3340

Public Class FormClassHouse

    Private _house As House
    Private _frmList As FormClassList
    Private Const CHI As Integer = 0
    Private Const MAD As Integer = 1
    Private Const PLAT As Integer = 2

    ' Constructor - Initializes the form components, sets _frmList to a FormClassList object, set the
    ' MainForm property of _frmList, and sets the focus to the the type combobox.
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _frmList = New FormClassList
        _frmList.MainForm() = Me
        typeCombo.Focus()

    End Sub

    ' Handles clicking the save/new button. If it is set to "save", then a house is created based on the id
    ' and type selected on the form. If the type is not selected an error message is shown. Catches all
    ' exceptions from the house classes and shows the error message. If the save is successful then the
    ' controls used to create a house are disabled and the controls used to modify are enabled. If it
    ' is set to "new", then the controls used to creat a house are cleared and enabled, and the cotnrols
    ' used to modify are disabled.
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Static _save As Boolean = True
        Dim _id As String = ""
        Dim _index As Integer = typeCombo.SelectedIndex

        If _save Then
            If txtID.TextLength <> 0 Then
                _id = txtID.Text
            End If
            If _index = CHI Then
                Try
                  _house = New Chicago(_id)
                  AddHandler _house.PriceChanged, AddressOf PriceEventHandler
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Return
                End Try

                rms3.Select()
                grg2.Select()
            ElseIf _index = MAD Then
                Try
                  _house = New Madison(_id)
                  AddHandler _house.PriceChanged, AddressOf PriceEventHandler
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Return
                End Try

                rms2.Select()
                grg1.Select()
            ElseIf _index = PLAT Then
                Try
                  _house = New Platteville(_id)
                  AddHandler _house.PriceChanged, AddressOf PriceEventHandler
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Return
                End Try

                rms2.Select()
                grg1.Select()
            Else
                MessageBox.Show("Select a house type please!")
                Return
            End If

         txtPrice.Text = FormatCurrency(_house.Price, 0)
            btnSave.Text = "NEW"
            rmsGroup.Enabled = True
            grgGroup.Enabled = True
            txtID.ReadOnly = True
            typeCombo.Enabled = False
            btnModify.Enabled = True
        Else
            btnSave.Text = "SAVE"
            txtID.Clear()
            txtPrice.Clear()
            typeCombo.SelectedIndex = -1
            rmsGroup.Enabled = False
            grgGroup.Enabled = False
            txtID.ReadOnly = False
            typeCombo.Enabled = True
            btnModify.Enabled = False
        End If
        _save = Not _save
    End Sub

    ' Closes the application.
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    ' Hides this form and shows _frmList.
    Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
        Me.Hide()
        _frmList.Show()
        _frmList.BringToFront()
    End Sub

    ' Modifies the current house selected. Catches all exceptions and shows the error message. Handles
    ' the event of the price changing. Displays the updated price.
    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click

        Dim count As Integer = House.TotalCount
        Dim _id As String = txtID.Text
        Dim _rms, _grgs As Integer

        For i = 0 To count - 1
            If House.HouseByIndex(i).ID = _id Then
                _house = House.HouseByIndex(i)
            End If
        Next

        If rms2.Checked Then
            _rms = rms2.Tag
        ElseIf rms3.Checked Then
            _rms = rms3.Tag
        ElseIf rms4.Checked Then
            _rms = rms4.Tag
        End If

        If grg1.Checked Then
            _grgs = grg1.Tag
        ElseIf grg2.Checked Then
            _grgs = grg2.Tag
        ElseIf grg3.Checked Then
            _grgs = grg3.Tag
        End If

        Try
            _house.Modify(_rms, _grgs)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

      txtPrice.Text = FormatCurrency(_house.Price, 0)
    End Sub

    ' Shows a message on the event of a price change.
    Private Sub PriceEventHandler()
        MessageBox.Show("The price has changed!")
    End Sub

    'Shows the statistics of the selected house.
    Private Sub FormClassHouse_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Dim index As Integer = _frmList.SelectedHouse

        If index <> -1 Then
            _house = House.HouseByIndex(index)

            txtID.Text = _house.ID
            If _house.Type = "Chicago" Then
                typeCombo.SelectedIndex = CHI
            ElseIf _house.Type = "Platteville" Then
                typeCombo.SelectedIndex = PLAT
            Else
                typeCombo.SelectedIndex = MAD
            End If

            txtPrice.Text = FormatCurrency(_house.Price, 0)
        End If
    End Sub

    ' Handles key press events in the price textbox
    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        e.Handled = True
    End Sub
End Class