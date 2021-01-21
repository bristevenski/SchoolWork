'----------------------------------------------
' Name: Brianna Muleski
' Date: 2/13/2015
' Description: Program 3
'              Class House
'---------------------------------------------
Public MustInherit Class House
    Implements IDisposable


    Protected Shared _allHouses As New ArrayList
    Protected _rooms, _garages As Integer
    Protected _type, _id As String
    Protected _price As Single

    'Constructor: Raises the HouseListUpdated event.
    Public Sub New()
        RaiseEvent HouseListUpdated()
    End Sub

    ' Returns the total count of house objects to be built.
    Public Shared ReadOnly Property TotalCount As Integer
        Get
            Return _allHouses.Count
        End Get
    End Property

    ' Returns the house at the specified index. 
    Public Shared ReadOnly Property HouseByIndex(ByVal index As Integer) As House
        Get
            Return _allHouses(index)
        End Get
    End Property

    ' Returns the type of the house.
    Public ReadOnly Property Type As String
        Get
            Return _type
        End Get
    End Property

    ' Returns the ID of the house.
    Public ReadOnly Property ID As String
        Get
            Return _id
        End Get
    End Property

    ' Returns the number of rooms the house has.
    Public ReadOnly Property Rooms As Integer
        Get
            Return _rooms
        End Get
    End Property

    ' Returns the number of garages the house has.
    Public ReadOnly Property Garages As Integer
        Get
            Return _garages
        End Get
    End Property

    ' Returns the price of the house.
    Public ReadOnly Property Price As Single
        Get
            Return _price
        End Get
    End Property

    ' Raised when a house is created, removed, or modified (price changed or not).
    Public Shared Event HouseListUpdated()

    ' Modifies number of rooms and number of garages, and the price of the house if both parameters 
    ' are in the range. Otherwise, an exception is thrown with a message to indicate the invalid 
    ' parameters (one or two). Event PriceChanged will be raised if both parameters are valid
    ' and the new price is different from the old price.
    Public Sub Modify(ByVal numRooms As Integer, ByVal numGarages As Integer)
        Dim _oldPrice As Integer = _price

        MakeChanges(numRooms, numGarages)

        If _oldPrice <> _price Then
            RaiseEvent HouseListUpdated()
        End If
    End Sub

    ' Overrided method that changes the number of rooms, number of garages, and the price if the given
    ' number of rooms and garages are valid. Throws an exception if they are not.
    Protected MustOverride Sub MakeChanges(ByVal numRooms As Integer, ByVal numGarages As Integer)

    ' Validates given id. Throws an exception if not valid.
    Protected Sub CheckID(ByVal inID As String)
        If inID.Length <> 5 Then
            Throw New Exception("ID length must be 5!")
        End If

        For i = 0 To TotalCount - 1
            If inID = HouseByIndex(i).ID Then
                Throw New Exception("ID must be unique!")
            End If
        Next

        For i = 0 To inID.Length - 1
            Dim cur As Char = inID.Chars(i)
            If Not Char.IsLetter(cur) And Not IsNumeric(cur) Then
                Throw New Exception("Each character of ID must be a digit or letter!")
            End If
        Next
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                _allHouses.Remove(Me)
                RaiseEvent HouseListUpdated()
            End If
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Private Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class

'----------------------------------------------
' Name: Brianna Muleski
' Date: 2/13/2015
' Description: Program 3
'              Class Platteville
'              Derived from Class House
'---------------------------------------------
Public Class Platteville
    Inherits House

    Private Const MIN_RMS = 2
    Private Const MIN_GRGS = 1
    Private Const MAX_RMS = 3
    Private Const MAX_GRGS = 2
    Private Const BASE_PRICE = 200000
    Private Const ADD_GRG = 2500
    Private Const ADD_RM = 8000

    ' Constructor - Creates a new Platteville house and sets the type, id, rooms, garages, and price if the
    ' given id is valid.
    Public Sub New(ByVal inID As String)
        CheckID(inID)

        _type = "Platteville"
        _id = inID
        _rooms = MIN_RMS
        _garages = MIN_GRGS
        _price = BASE_PRICE

        _allHouses.Add(Me)
    End Sub

    ' Changes the number of rooms, number of garages, and the price if the given
    ' number of rooms and garages are valid. Throws an exception if they are not.
    Protected Overrides Sub MakeChanges(ByVal numRooms As Integer, ByVal numGarages As Integer)
        If numRooms > MAX_RMS And numGarages > MAX_GRGS Then
            Throw New Exception("Number of rooms is out of range!" + vbNewLine +
                                "Number of garages is out of range!")
        ElseIf numRooms > MAX_RMS Then
            Throw New Exception("Number of rooms is out of range!")
        ElseIf numGarages > MAX_GRGS Then
            Throw New Exception("Number of garages is out of range!")
        End If

        _price = BASE_PRICE + (numRooms - MIN_RMS) * ADD_RM + (numGarages - MIN_GRGS) * ADD_GRG
        _rooms = numRooms
        _garages = numGarages
    End Sub
End Class

'----------------------------------------------
' Name: Brianna Muleski
' Date: 2/13/2015
' Description: Program 3
'              Class Madison
'              Derived from Class House
'---------------------------------------------
Public Class Madison
    Inherits House

    Private Const MIN_RMS = 2
    Private Const MIN_GRGS = 1
    Private Const BASE_PRICE = 300000
    Private Const ADD_RM = 10000
    Private Const ADD_GRG = 5000

    ' Constructor - Creates a new Madison house and sets the type, id, rooms, garages, and price if the
    ' given id is valid.
    Public Sub New(ByVal inID As String)
        CheckID(inID)

        _type = "Madison"
        _id = inID
        _rooms = MIN_RMS
        _garages = MIN_GRGS
        _price = BASE_PRICE

        _allHouses.Add(Me)
    End Sub

    ' Changes the number of rooms, number of garages, and the price.
    Protected Overrides Sub MakeChanges(ByVal numRooms As Integer, ByVal numGarages As Integer)
        _price = BASE_PRICE + (numRooms - MIN_RMS) * ADD_RM + (numGarages - MIN_GRGS) * ADD_GRG
        _rooms = numRooms
        _garages = numGarages
    End Sub

End Class

'----------------------------------------------
' Name: Brianna Muleski
' Date: 2/13/2015
' Description: Program 3
'              Class Chicago
'              Derived from Class House
'---------------------------------------------
Public Class Chicago
    Inherits House

    Private Const MIN_RMS = 3
    Private Const MIN_GRGS = 2
    Private Const MAX_RMS = 4
    Private Const MAX_GRGS = 3
    Private Const BASE_PRICE = 400000
    Private Const R3_G3_PRICE = 410000
    Private Const R4_G2_PRICE = 420000
    Private Const R4_G3_PRICE = 428000

    ' Constructor - Creates a new Chicago house and sets the type, id, rooms, garages, and price if the
    ' given id is valid. Throws an exception if the given id is invalid.
    Public Sub New(ByVal inID As String)
        CheckID(inID)

        _type = "Chicago"
        _id = inID
        _rooms = MIN_RMS
        _garages = MIN_GRGS
        _price = BASE_PRICE

        _allHouses.Add(Me)

    End Sub

    ' Changes the number of rooms, number of garages, and the price if the given
    ' number of rooms and garages are valid. Throws an exception if they are not.
    Protected Overrides Sub MakeChanges(ByVal numRooms As Integer, ByVal numGarages As Integer)
        If numRooms < MIN_RMS And numGarages < MIN_GRGS Then
            Throw New Exception("Number of rooms is out of range!" + vbNewLine +
                                "Number of garages is out of range!")
        ElseIf numRooms < MIN_RMS Then
            Throw New Exception("Nnumber of rooms is out of range!")
        ElseIf numGarages < MIN_GRGS Then
            Throw New Exception("Number of garages is out of range!")
        End If

        If numRooms = MIN_RMS And numGarages = MIN_GRGS Then
            _price = BASE_PRICE
        ElseIf numRooms = MAX_RMS And numGarages = MIN_GRGS Then
            _price = R4_G2_PRICE
        ElseIf numRooms = MIN_RMS And numGarages = MAX_GRGS Then
            _price = R3_G3_PRICE
        ElseIf numRooms = MAX_RMS And numGarages = MAX_GRGS Then
            _price = R4_G3_PRICE
        End If

        _rooms = numRooms
        _garages = numGarages
    End Sub

End Class