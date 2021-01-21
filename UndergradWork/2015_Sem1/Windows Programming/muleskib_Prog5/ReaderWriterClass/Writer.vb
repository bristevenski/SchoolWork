Imports System.Threading
Imports UWPCS3340

Public Class Writer
    Inherits ReaderWriter

    Private Const MIN_VAL As Integer = -10
    Private Const MAX_VAL As Integer = 10

    ' Sets the Reader ID then returns the ID
    Public Overrides ReadOnly Property ID As String
        Get
            _id = "Writer_BM" & _thread.GetHashCode()
            Return _id
        End Get
    End Property

    ' Returns the Writer type
    Public Overrides ReadOnly Property type As ReaderWriterType
        Get
            Return ReaderWriterType.Writer
        End Get
    End Property

    ' Works the Writer
    Protected Overrides Sub Run()
        _database.LockDataObj()
        Monitor.Enter(FIFOQueue)
        If FIFOQueue.Count <> 0 Or _database.TheDatabaseStatus <> DatabaseClass.DatabaseStatus.Empty Then
            FIFOQueue.Enqueue(Me)
            _mainForm.Invoke(_passMsg, _id, State.Waiting, NO_VALUE)
            _database.ReleaseDataObj()
            Monitor.Exit(FIFOQueue)
            _ReaderWriterEvent.WaitOne()
        Else
            _database.ReleaseDataObj()
            Monitor.Exit(FIFOQueue)
        End If

        _database.LockDataObj()
        _database.IncreaseWriterCount()
        _database.ReleaseDataObj()
        _mainForm.Invoke(_passMsg, _id, State.Working, _database.TotalValue)

        Dim _workTime As Integer = _randomGenerator.Next(MIN_VALUE + WRITER_INC, MAX_VALUE + WRITER_INC)
        Thread.Sleep(_workTime)
        Dim _value As Integer = _randomGenerator.Next(MIN_VAL, MAX_VAL)
        _database.TotalValue += _value
        _mainForm.Invoke(_passMsg, _id, State.Finished, _database.TotalValue)

        _database.LockDataObj()
        _database.DecreaseWriterCount()
        If FIFOQueue.Count > 0 Then
            Dim _worker As ReaderWriter = FIFOQueue.Dequeue
            _worker.WakeUp()
        End If
        _database.ReleaseDataObj()

    End Sub

End Class