'----------------------------------------------
' Name: Brianna Muleski
' Date: 2/13/2015
' Description: Program 3
'              Class FormClassList
'---------------------------------------------
Imports UWPCS3340

Public Class FormClassList
    Protected _mainForm As FormClassHouse
    Private _selHouse As Integer = -1
    Private Const ID_LNGTH As Integer = 5
    Private Const TYPE_LNGTH As Integer = 16
    Private Const PRICE_LNGTH As Integer = 12


    ' Sets _mainForm.
    Public WriteOnly Property MainForm As FormClassHouse
        Set(value As FormClassHouse)
            _mainForm = value
        End Set

    End Property

    ' Switches back to _mainForm.
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Hide()
        _mainForm.Show()
        _mainForm.BringToFront()
    End Sub

    ' Displays the selected house on _mainForm. If no house is selected then an error message is shown.
    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click

        _selHouse = listHouses.SelectedIndex
        If _selHouse = -1 Then
            errList.SetError(listHouses, "Select a house in the list!")
        Else
            errList.Clear()
            Me.Hide()
            _mainForm.Show()
            _mainForm.BringToFront()
        End If

    End Sub

    ' Updates the list of houses and the total count of houses.
    Private Sub FormClassList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.MdiParent = _mainForm.MdiParent
        UpdateList()
        AddHandler House.HouseListUpdated, AddressOf UpdatedEvent
    End Sub

    ' Gets the selected houses index.
    Public ReadOnly Property SelectedHouse As Integer
        Get
            Return _selHouse
        End Get
    End Property

    ' Handles key press events in the count textbox.
    Private Sub txtCount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCount.KeyPress
        e.Handled = True
    End Sub

    ' Removes the selected house, if no house is selected then an error is shown.
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        _selHouse = listHouses.SelectedIndex
        If _selHouse = -1 Then
            errList.SetError(listHouses, "Select a house in the list!")
        Else
            errList.Clear()
            Dim h As House = House.HouseByIndex(_selHouse)
            CType(h, IDisposable).Dispose()
            _selHouse = -1
        End If
    End Sub

    ' Handles the HouseListUpdated event.
    Protected Sub UpdatedEvent()
        UpdateList()
    End Sub

    ' Updates the house list.
    Private Sub UpdateList()
        listHouses.Items.Clear()
        txtCount.Text = House.TotalCount

        Dim _houseString, _price, _disPrice As String
        Dim _curHouse As House

        For i = 0 To House.TotalCount - 1
            _curHouse = House.HouseByIndex(i)
            _price = _curHouse.Price
            _disPrice = FormatCurrency(_price, 0)
            _houseString = _curHouse.ID.PadLeft(ID_LNGTH) + _curHouse.Type.PadLeft(TYPE_LNGTH) _
                        + _disPrice.PadLeft(PRICE_LNGTH)
            listHouses.Items.Add(_houseString)
        Next
        _selHouse = -1
        errList.Clear()
    End Sub
End Class