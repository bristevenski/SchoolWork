Imports System.Threading

Public Class DatabaseClass
    Public Enum DatabaseStatus
        Reading
        Writing
        Empty
    End Enum

    ' The data shared by all readers and writers
    Private _total As Integer

    ' To control data access 
    Private ReaderCount As Integer
    Private WriterCount As Integer

    ' To enforce mutual exclusion on ReaderCount and WriterCount
    Private DataObj As New Object

    Public Sub New(ByVal _inTotal As Integer)
        _total = _inTotal
        ReaderCount = 0
        WriterCount = 0
    End Sub
    ' Returns Reading when some readers are reading the database value,
    '         Writing when a write (or some writers if allowed) is writing the database value,
    '         Empty otherwise.
    Public ReadOnly Property TheDatabaseStatus As DatabaseStatus
        Get
            If ReaderCount > 0 Then
                Return DatabaseStatus.Reading
            ElseIf WriterCount > 0 Then
                Return DatabaseStatus.Writing
            End If
            Return DatabaseStatus.Empty
        End Get
    End Property

    ' Uses Monitor to lock DataObj before accessing ReaderCount and/or WriterCount.
    Public Sub LockDataObj()
        Monitor.Enter(DataObj)
    End Sub

    ' Releases DataObj after accessing ReaderCount and/or WriterCount.
    Public Sub ReleaseDataObj()
        Monitor.Exit(DataObj)
    End Sub

    ' Gets and sets the data value
    Public Property TotalValue As Integer
        Get
            Return _total
        End Get
        Set(value As Integer)
            _total = value
        End Set
    End Property

   ' Increments the ReaderCount by one
    Public Sub IncreaseReaderCount()
        ReaderCount += 1
    End Sub

    ' Decrements the ReaderCount by one.
    Public Sub DecreaseReaderCount()
        ReaderCount -= 1
    End Sub

    ' Increments the WriterCount by one.
    Public Sub IncreaseWriterCount()
        WriterCount += 1
    End Sub

    ' Decrements the WriterCount by one.
    Public Sub DecreaseWriterCount()
        WriterCount -= 1
    End Sub
End Class
