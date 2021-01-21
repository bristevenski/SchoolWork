Imports System.Threading
Imports UWPCS3340

Public Class Reader
    Inherits ReaderWriter

    ' Sets the Reader ID then returns the ID
    Public Overrides ReadOnly Property ID As String
        Get
            _id = "Reader_BM" & _thread.GetHashCode()
            Return _id
        End Get
    End Property

    ' Returns the Reader type
    Public Overrides ReadOnly Property type As ReaderWriterType
        Get
            Return ReaderWriterType.Reader
        End Get
    End Property

    ' Works the Reader
    Protected Overrides Sub Run()
        _database.LockDataObj()
        Monitor.Enter(FIFOQueue)
        If FIFOQueue.Count <> 0 Or _database.TheDatabaseStatus = DatabaseClass.DatabaseStatus.Writing Then
            FIFOQueue.Enqueue(Me)
            _mainForm.Invoke(_passMsg, _id, State.Waiting, NO_VALUE)
            _database.ReleaseDataObj()
            Monitor.Exit(FIFOQueue)
            _ReaderWriterEvent.WaitOne()
            If FIFOQueue.Count > 0 Then
                Dim _worker As ReaderWriter = FIFOQueue.Dequeue
                _worker.WakeUp()
            End If
        Else
            _database.ReleaseDataObj()
            Monitor.Exit(FIFOQueue)
        End If

        _database.LockDataObj()
        _database.IncreaseReaderCount()
        _database.ReleaseDataObj()

        _mainForm.Invoke(_passMsg, _id, State.Working, _database.TotalValue)
        Dim _workTime As Integer = _randomGenerator.Next(MIN_VALUE, MAX_VALUE)
        Thread.Sleep(_workTime)
        _mainForm.Invoke(_passMsg, _id, State.Finished, _database.TotalValue)

        _database.LockDataObj()
        _database.DecreaseReaderCount()
        If _database.TheDatabaseStatus = DatabaseClass.DatabaseStatus.Empty Then
            If FIFOQueue.Count > 0 Then
                Dim _worker As ReaderWriter = FIFOQueue.Dequeue
                _worker.WakeUp()
            End If
        End If
        _database.ReleaseDataObj()

    End Sub

End Class