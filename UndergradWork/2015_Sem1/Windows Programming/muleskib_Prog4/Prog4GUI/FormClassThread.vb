'----------------------------------------------
' Name: Brianna Muleski
' Date: 2/30/2015
' Description: Program 4
'              Class FormClassThread
'---------------------------------------------
Imports System.Threading
Imports UWPCS3340

Public Class FormClassThread
    Private newUser As UserAccount
    Private dummyThread As Thread
    Private _balance As Integer = 1000
    Private _trans As Integer = 0
    Private Delegate Sub EnableButtons()
    Private btnDelegate As EnableButtons

    ' Terminates all user threads and shows a message box to confirm whether user wants to exit the
    ' application or return to the main form.
    Private Sub ExitApplication()
        UserAccount.TerminateAllUsers()

        Dim result As Microsoft.VisualBasic.MsgBoxResult
        result = MsgBox("Do you want to exit?", MsgBoxStyle.YesNo)
        If result = MsgBoxResult.Yes Then
            Application.Exit()
        Else
            Me.Invoke(btnDelegate)
        End If
    End Sub

    ' Creates a new user and sets the main form and delegates of that user.
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        newUser = New UserAccount
        newUser.MainForm = Me
        newUser.TheReport = AddressOf PrintReport
        newUser.TheTransaction = AddressOf PrintTrans
        newUser.SpinUp()
    End Sub

    ' Sets the EnableButtons delegate object to the EnableButtons delegate sub address.
    Private Sub FormClassThread_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnDelegate = AddressOf SubToEnableButtons
    End Sub

    ' Continues the selected user in the list. If no user is selected, then it does nothing.
    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Dim index = lstAllUsers.SelectedIndex
        If index <> -1 Then
            Dim user = UserAccount.GetUserByIndex(index)
            user.UserContinue()
        End If
    End Sub

    ' Terminates the selected user in the list. If no user is selected, then it does nothing.
    Private Sub btnTerminate_Click(sender As Object, e As EventArgs) Handles btnTerminate.Click
        Dim index = lstAllUsers.SelectedIndex
        If index <> -1 Then
            Dim user = UserAccount.GetUserByIndex(index)
            user.SpinDown()
        End If
    End Sub

    ' Sets the selected user to waiting state. If no user is selected, then it does nothing.
    Private Sub btnWait_Click(sender As Object, e As EventArgs) Handles btnWait.Click
        Dim index = lstAllUsers.SelectedIndex
        If index <> -1 Then
            Dim user = UserAccount.GetUserByIndex(index)
            user.UserWait()
        End If
    End Sub

    ' Exits the application and disables the buttons on the form.
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        dummyThread = New Thread(AddressOf ExitApplication)
        dummyThread.Start()

        btnCreate.Enabled = False
        btnContinue.Enabled = False
        btnWait.Enabled = False
        btnTerminate.Enabled = False
        btnExit.Enabled = False
    End Sub

    ' EnableButtons delegate sub that enables the buttons on the form.
    Private Sub SubToEnableButtons()
        btnCreate.Enabled = True
        btnContinue.Enabled = True
        btnWait.Enabled = True
        btnTerminate.Enabled = True
        btnExit.Enabled = True
    End Sub

    ' TheReport delegate sub that prints the new user in the list of users or updates the 
    ' existing user based on its state.
    Private Sub PrintReport(ByVal ID As String, ByVal State As UserAccount.UserState)
        Dim index = lstAllUsers.FindString(ID)
        If index = -1 Then
            Dim _uString = ID & ": " & State.ToString
            lstAllUsers.Items.Add(_uString)
            txtLog.Text &= ID & ": Start Working" & vbCrLf
        Else
            If State = UserAccount.UserState.Terminated Then
                lstAllUsers.Items.RemoveAt(index)
            Else
                lstAllUsers.Items.Item(index) = ID & ": " & State.ToString
            End If
        End If
    End Sub

    ' TheTransaction delegate sub that prints the transaction information of the working user threads.
    ' If the user is done working then it prints the total transaction of the user. Updates the transaction
    ' amount and the balance amount of all users.
    Private Sub PrintTrans(ByVal ID As String, ByVal Amount As Integer, ByVal Final As Boolean)
        If Final Then
            txtLog.Text &= ID & ": Total Transaction = " & FormatCurrency(Amount, 2) & vbCrLf
            _trans += Amount
            txtTransaction.Text = FormatCurrency(_trans, 2)
        Else
            txtLog.Text &= ID & ": " & Amount & vbCrLf
            _balance += Amount
            txtBalance.Text = FormatCurrency(_balance, 2)
        End If

        txtLog.SelectionStart = Len(txtLog.Text) - 1
        txtLog.ScrollToCaret()
    End Sub

    ' Suppresses key presses in the balance text box.
    Private Sub txtBalance_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBalance.KeyDown
        e.SuppressKeyPress = True
    End Sub

    ' Suppresses key presses in the transaction text box.
    Private Sub txtTransaction_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransaction.KeyDown
        e.SuppressKeyPress = True
    End Sub
End Class
