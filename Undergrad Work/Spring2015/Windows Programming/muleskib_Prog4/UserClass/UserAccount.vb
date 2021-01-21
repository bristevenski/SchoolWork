'----------------------------------------------
' Name: Brianna Muleski
' Date: 2/30/2015
' Description: Program 4
'              Class UserAccount
'---------------------------------------------
Imports System.Threading
Imports System.Windows.Forms

Public Class UserAccount
    Private Const MIN_WORK_TIME = 3000
    Private Const MAX_WORK_TIME = 5000
    Private Const MIN_TRANS = -100
    Private Const MAX_TRANS = 100
    Private _mainForm As Form
    Private _thread As Thread
    Private _totalTrans As Integer = 0
    Private Shared AllUsers As New List(Of UserAccount)
    Private _state As UserState
    Private _transDel As TransactionDelegate
    Private _passDel As PassMessageDelegate
    Private _id As String
    Private _randomGenerator As Random = New Random
    Private _userWait As New ManualResetEvent(False)
    Private Shared _allTerminated As New ManualResetEvent(False)

    Public Enum UserState
        Working
        Waiting
        Terminated
    End Enum

    Public Delegate Sub TransactionDelegate(ByVal ID As String, ByVal Amount As Integer,
                                            ByVal Final As Boolean)
    Public Delegate Sub PassMessageDelegate(ByVal ID As String, ByVal State As UserState)

    ' To invoke delegates on a form.
    Public WriteOnly Property MainForm As Form
        Set(value As Form)
            _mainForm = value
        End Set
    End Property

    ' Sets the TransactionDelegate object.
    Public WriteOnly Property TheTransaction As TransactionDelegate
        Set(value As TransactionDelegate)
            _transDel = value
        End Set
    End Property

    ' Sets the PassMessageDelegate object.
    Public WriteOnly Property TheReport As PassMessageDelegate
        Set(value As PassMessageDelegate)
            _passDel = value
        End Set
    End Property

    ' Creates a new user thread, sets its state and id, and starts the thread.
    Public Sub SpinUp()
        _thread = New Thread(AddressOf Run)
        _state = UserState.Working
        _thread.Start()
        _id = "BM" & _thread.GetHashCode()
    End Sub

    ' Terminates the user thread and sets the state.
    Public Sub SpinDown()
        If _state = UserState.Waiting Then
            _userWait.Set()
        End If
        _state = UserState.Terminated
    End Sub

    ' Suspends the user thread and sets the state.
    Public Sub UserWait()
        _userWait.Reset()
        _state = UserState.Waiting
    End Sub

    ' Wakes the user thread and sets the state.
    Public Sub UserContinue()
        _state = UserState.Working
        _userWait.Set()
    End Sub

    ' Terminates all user threads.
    Public Shared Sub TerminateAllUsers()
        If AllUsers.Count > 0 Then
            _allTerminated.Reset()

            For index = AllUsers.Count - 1 To 0 Step -1
                AllUsers(index).SpinDown()
            Next

            _allTerminated.WaitOne()

        End If

    End Sub

    ' Returns the user at the given index.
    Public Shared Function GetUserByIndex(ByVal index As Integer) As UserAccount
        Return AllUsers(index)
    End Function

    ' Adds the current user to the user list and updates the transactions as the user works. When the user
    ' state is changed, the ManualResetEvents are updated. When the user is terminated then it is removed
    ' from the user list and if the count in the list is 0 then the ManualResetEvent _allTerminated is set.
    Private Sub Run()
        AllUsers.Add(Me)
        _mainForm.Invoke(_passDel, _id, _state)

        While _state <> UserState.Terminated
            Dim _workTime = _randomGenerator.Next(MIN_WORK_TIME, MAX_WORK_TIME)
            Thread.Sleep(_workTime)
            Dim _transAmount = _randomGenerator.Next(MIN_TRANS, MAX_TRANS)
            _totalTrans += _transAmount
            _mainForm.Invoke(_transDel, _id, _transAmount, False)

            If _state = UserState.Waiting Then
                _mainForm.Invoke(_passDel, _id, _state)
                _userWait.WaitOne()
            End If

            If _state = UserState.Working Then
                _mainForm.Invoke(_passDel, _id, _state)
            End If
        End While

        _mainForm.Invoke(_passDel, _id, _state)
        _mainForm.Invoke(_transDel, _id, _totalTrans, True)
        AllUsers.Remove(Me)

        If AllUsers.Count = 0 Then
            _allTerminated.Set()
        End If
    End Sub
End Class
