Imports System.Threading
Imports UWPCS3340

Public Class ReaderWriterForm

    Private _worker As ReaderWriter
    Private dummyThread As Thread
    Private _total As Integer = 100
    Private Delegate Sub EnableButtons()
    Private btnDelegate As EnableButtons
    Private Delegate Sub PassMessage(ByVal _id As String, ByVal _state As ReaderWriter.State, ByVal _total As Integer)
    Private printDel As PassMessage
    Private _database As DatabaseClass

    ' Sets the EnableButtons delegate object to the EnableButtons delegate sub address.
    Private Sub ReaderWriterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnDelegate = AddressOf SubToEnableButtons
        printDel = AddressOf SubToPrintLog
        _database = New DatabaseClass(_total)
        ReaderWriter.TheDatabase = _database
        totalTxt.Text = _total
    End Sub

    ' Terminates all user threads and shows a message box to confirm whether user wants to exit the
    ' application or return to the main form.
    Private Sub ExitApplication()
        ReaderWriter.FinishReadWrite()
        Dim result As Microsoft.VisualBasic.MsgBoxResult
        result = MsgBox("Do you want to exit?", MsgBoxStyle.YesNo)
        If result = MsgBoxResult.Yes Then
            Application.Exit()
        Else
            Me.Invoke(btnDelegate)
        End If
    End Sub

    ' EnableButtons delegate sub that enables the buttons on the form.
    Private Sub SubToEnableButtons()
        btnNewReader.Enabled = True
        btnNewWriter.Enabled = True
        btnExit.Enabled = True
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        dummyThread = New Thread(AddressOf ExitApplication)
        dummyThread.Start()

        btnNewReader.Enabled = False
        btnNewWriter.Enabled = False
        btnExit.Enabled = False
    End Sub

    Private Sub PrintLog(ByVal _id As String, ByVal _state As ReaderWriter.State, ByVal _inTotal As Integer)
        Me.Invoke(printDel, _id, _state, _inTotal)
    End Sub

    Private Sub btnNewReader_Click(sender As Object, e As EventArgs) Handles btnNewReader.Click
        _worker = New Reader()
        InitWorker()
        If _database.TheDatabaseStatus = DatabaseClass.DatabaseStatus.Writing Then
            lstWaiting.Items.Add(_worker.ID)
        Else
            lstWorking.Items.Add(_worker.ID)
        End If
    End Sub

    Private Sub btnNewWriter_Click(sender As Object, e As EventArgs) Handles btnNewWriter.Click
        _worker = New Writer()
        InitWorker()
        If _database.TheDatabaseStatus = DatabaseClass.DatabaseStatus.Empty Then
            lstWorking.Items.Add(_worker.ID)
        Else
            lstWaiting.Items.Add(_worker.ID)
        End If
    End Sub

    Private Sub InitWorker()
        _worker.MainForm = Me
        _worker.DisplayMsg = AddressOf PrintLog
        _worker.SpinUp()
    End Sub

    Private Sub SubToPrintLog(ByVal _id As String, ByVal _state As ReaderWriter.State, ByVal _inTotal As Integer)
        If _state <> ReaderWriter.State.Working And lstWorking.Items.Contains(_id) Then
            lstWorking.Items.Remove(_id)
        End If
        If _state = ReaderWriter.State.Working And lstWaiting.Items.Contains(_id) Then
            lstWaiting.Items.Remove(_id)
            lstWorking.Items.Add(_id)
        End If
        If _state = ReaderWriter.State.Waiting Then
            lstWaiting.Items.Add(_id)
        End If
        If _state = ReaderWriter.State.Finished Or _state = ReaderWriter.State.Working Then
            txtLog.Text &= _id & ": " & _state.ToString & ": " & _inTotal & vbCrLf
            totalTxt.Text = _inTotal
            txtLog.SelectionStart = Len(txtLog.Text) - 1
            txtLog.ScrollToCaret()
        End If
    End Sub

End Class
