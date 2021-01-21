Imports UWPCS3340
Imports System.Threading
Imports System.Windows.Forms

Public MustInherit Class ReaderWriter

    Protected Const NO_VALUE As Integer = -1000
    Protected Const MIN_VALUE As Integer = 2000
    Protected Const MAX_VALUE As Integer = 3000
    Protected Const WRITER_INC As Integer = 1000

    Public Enum ReaderWriterType
        Reader
        Writer
    End Enum

    Public Enum State
        Waiting
        Working
        Finished
    End Enum

    Public Delegate Sub PassMessage(ByVal theID As String,
                                    ByVal theState As State,
                                    ByVal Total As Integer)

    Protected Shared FIFOQueue As New Queue
    Protected Shared _database As DatabaseClass
    Private Shared endProgram As New AutoResetEvent(False)
    Private _state As State
    Protected _id As String
    Protected _thread As Threading.Thread
    Protected _passMsg As PassMessage
    Protected _mainForm As System.Windows.Forms.Form
    Protected _ReaderWriterEvent As New AutoResetEvent(False)
    Protected _randomGenerator As New System.Random

    ' Sets the value of _database.
    Public Shared WriteOnly Property TheDatabase() As DatabaseClass
        Set(value As DatabaseClass)
            _database = value
        End Set
    End Property

    ' When a writer or a reader exits the database and no other readers/writers 
    ' are in the database, the writer or reader wakes up the the first writer or
    ' reader in the waiting queue. 
    ' If the queue is empty, sets endProgram to signalled (green), since it's 
    ' possible that a thread is waiting for all readers/writers to finish the work.
    ' Mutual exclusion on the queue must be enforced.
    Protected Shared Sub WakeupNextWhenExiting()
        Monitor.Enter(FIFOQueue)
        If FIFOQueue.Count > 0 Then
            endProgram.Reset()
            Dim _worker As ReaderWriter = FIFOQueue.Dequeue()
            _worker.WakeUp()
        Else
            endProgram.Set()
        End If
        Monitor.Exit(FIFOQueue)
    End Sub

    ' Waits for all readers and writers to finish the work in order 
    ' to terminate the program.
    ' Mutual exclusion on the DataObj and the queue must be enforced.
    Public Shared Sub FinishReadWrite()
        _database.LockDataObj()
        Monitor.Enter(FIFOQueue)
        For index = FIFOQueue.Count - 1 To 0 Step -1
            WakeupNextWhenExiting()
        Next
        endProgram.WaitOne()
        Monitor.Exit(FIFOQueue)
        _database.ReleaseDataObj()
    End Sub

    Public WriteOnly Property DisplayMsg() As PassMessage
        Set(value As PassMessage)
            _passMsg = value
        End Set
    End Property

    Public WriteOnly Property MainForm() As System.Windows.Forms.Form
        Set(value As System.Windows.Forms.Form)
            _mainForm = value
        End Set
    End Property

    Public MustOverride ReadOnly Property ID() As String

    Public MustOverride ReadOnly Property type() As ReaderWriterType

    ' Creates a new ReaderWriter thread, sets its state and id, and starts the thread
    Public Sub SpinUp()
        _thread = New Thread(AddressOf Run)
        _state = State.Working
        _thread.Start()
    End Sub

    Public Sub WakeUp()
        _state = State.Working
        _ReaderWriterEvent.Set()
    End Sub

    Protected MustOverride Sub Run()

End Class
