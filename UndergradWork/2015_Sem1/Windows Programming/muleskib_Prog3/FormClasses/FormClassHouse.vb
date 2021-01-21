'----------------------------------------------
' Name: Brianna Muleski
' Date: 2/13/2015
' Description: Program 3
'              Class FormClassHouse
'---------------------------------------------
Public Class FormClassHouse

    Protected _house As House
    Protected _frmList As FormClassList
    Private _new As Boolean = True
    Private Const CHI As Integer = 0
    Private Const MAD As Integer = 1
    Private Const PLAT As Integer = 2
    Private Const ERRGRG As Integer = 34
    Private Const ERRRM As Integer = 32

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
    ' and type selected on the form. If the type is not selected an error is shown. Catches all
    ' exceptions from the house classes and shows the error.
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim _id As String = ""
        Dim _index As Integer = typeCombo.SelectedIndex

        If _new Then
            If txtID.TextLength <> 0 Then
                _id = txtID.Text
            End If
            If _index = CHI Then
                Try
                    _house = New Chicago(_id)
                    AddHandler House.HouseListUpdated, AddressOf UpdatedEvent
                Catch ex As Exception
                    errID.SetError(txtID, ex.Message)
                    Return
                End Try

                rms3.Select()
                grg2.Select()
            ElseIf _index = MAD Then
                Try
                    _house = New Madison(_id)
                    AddHandler House.HouseListUpdated, AddressOf UpdatedEvent
                Catch ex As Exception
                    errID.SetError(txtID, ex.Message)
                    Return
                End Try

                rms2.Select()
                grg1.Select()
            ElseIf _index = PLAT Then
                Try
                    _house = New Platteville(_id)
                    AddHandler House.HouseListUpdated, AddressOf UpdatedEvent
                Catch ex As Exception
                    errID.SetError(txtID, ex.Message)
                    Return
                End Try

                rms2.Select()
                grg1.Select()
            Else
                errType.SetError(typeCombo, "Select a house type please!")
                Return
            End If
            SaveInfo()
        Else
            ClearInfo()
        End If
    End Sub

    ' Closes the application.
    Protected Overridable Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
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
            errGarages.Clear()
            errRooms.Clear()
            _house.Modify(_rms, _grgs)
        Catch ex As Exception
            If ex.Message.Contains("garages") And ex.Message.Contains("rooms") Then
                errRooms.SetError(rmsGroup, ex.Message.Substring(0, ERRRM))
                errGarages.SetError(grgGroup, ex.Message.Substring(ERRGRG))
            ElseIf ex.Message.Contains("garages") Then
                errGarages.SetError(grgGroup, ex.Message)
            Else
                errRooms.SetError(rmsGroup, ex.Message)
            End If
        End Try

        txtPrice.Text = FormatCurrency(_house.Price, 0)
    End Sub

    'Shows the statistics of the selected house.
    Private Sub FormClassHouse_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Dim index As Integer = _frmList.SelectedHouse

        If index <> -1 Then
            UpdateDisplay(index)
        End If

    End Sub

    ' Handles key press events in the price textbox.
    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        e.Handled = True
    End Sub

    ' Handles the HouseListUpdated event.
    Protected Sub UpdatedEvent()
        Dim found As Boolean = False
        Dim index As Integer = -1
        For i = 0 To House.TotalCount - 1
            If txtID.Text = House.HouseByIndex(i).ID Then
                found = True
                index = i
            End If
        Next

        If Not found And _new = False Then
            ClearInfo()
        ElseIf found Then
            Dim h As House = House.HouseByIndex(index)
            If txtPrice.Text <> h.Price Then
                MessageBox.Show("The price has changed!")
            End If
            SaveInfo()
        End If
    End Sub

    ' Sets the rooms and garages that are checked on the form to correlate with the displayed house.
    Private Sub SetRoomsGarages()
        Dim _rooms As Integer = _house.Rooms
        Dim _garages As Integer = _house.Garages

        If _rooms = rms2.Tag Then
            rms2.Select()
        ElseIf _rooms = rms3.Tag Then
            rms3.Select()
        Else
            rms4.Select()
        End If
        rmsGroup.Update()

        If _garages = grg1.Tag Then
            grg1.Select()
        ElseIf _garages = grg2.Tag Then
            grg2.Select()
        Else
            grg3.Select()
        End If
        grgGroup.Update()
    End Sub

    ' Clears the current info on the display, changes the test of the button, enables the controls 
    ' used to create a listing, and disables the controls used to modify a listing.
    Private Sub ClearInfo()
        btnSave.Text = "SAVE"
        txtID.Clear()
        txtPrice.Clear()
        typeCombo.SelectedIndex = -1
        rmsGroup.Enabled = False
        grgGroup.Enabled = False
        txtID.ReadOnly = False
        typeCombo.Enabled = True
        btnModify.Enabled = False
        _new = True
    End Sub

    ' Clears the current info on the display, changes the test of the button, displays the price,
    ' disables the controls used to create a listing, and enables the controls used to modify a listing.
    Private Sub SaveInfo()
        txtPrice.Text = FormatCurrency(_house.Price, 0)
        btnSave.Text = "NEW"
        rmsGroup.Enabled = True
        grgGroup.Enabled = True
        txtID.ReadOnly = True
        typeCombo.Enabled = False
        btnModify.Enabled = True
        SetRoomsGarages()
        _new = False
    End Sub

    ' Clears the Type error.
    Private Sub typeCombo_SelectedIndexChanged(sender As Object, e As EventArgs) _
                                                Handles typeCombo.SelectedIndexChanged
        errType.Clear()
    End Sub

    ' Clears the ID error.
    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        errID.Clear()
    End Sub

    ' Updates the display.
    Private Sub UpdateDisplay(ByVal index As Integer)
        _house = House.HouseByIndex(index)

        txtID.Text = _house.ID
        If _house.Type = "Chicago" Then
            typeCombo.SelectedIndex = CHI
        ElseIf _house.Type = "Platteville" Then
            typeCombo.SelectedIndex = PLAT
        Else
            typeCombo.SelectedIndex = MAD
        End If

        SaveInfo()
    End Sub

End Class