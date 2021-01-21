'----------------------------------------------
' Name: Brianna Muleski
' Date: 2/2/2015
' Description: Program 2
'              Class FormClassList
'---------------------------------------------
Public Class FormClassList

    Private _mainForm As FormClassHouse
    Private _selHouse As Integer = -1
    Private Const ID_LNGTH As Integer = 5
    Private Const TYPE_LNGTH As Integer = 16
    Private Const PRICE_LNGTH As Integer = 12

    ' Sets _mainForm
    Public WriteOnly Property MainForm As FormClassHouse
        Set(value As FormClassHouse)
            _mainForm = value
        End Set

    End Property

    ' Switches back to _mainForm
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Hide()
        _mainForm.Show()
        _mainForm.BringToFront()
    End Sub

    ' Displays the selected house on _mainForm. If no house is selected then an error message is shown.
    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click

        _selHouse = listHouses.SelectedIndex
        If _selHouse <> -1 Then
            Me.Hide()
            _mainForm.Show()
            _mainForm.BringToFront()
        Else
            MessageBox.Show("Select a house in the list!")
        End If

    End Sub

    ' Updates the list of houses and the total count of houses.
    Private Sub FormClassList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
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
    End Sub

    ' Gets the selected houses index
    Public ReadOnly Property SelectedHouse As Integer
        Get
            Return _selHouse
        End Get
    End Property

    ' Handles key press events in the count textbox
    Private Sub txtCount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCount.KeyPress
        e.Handled = True
    End Sub
End Class