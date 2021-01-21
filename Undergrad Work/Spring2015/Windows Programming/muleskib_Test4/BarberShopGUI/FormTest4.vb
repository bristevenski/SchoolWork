Imports System.Threading
Imports UWPCS3340

Public Class FormTest4

   Dim b As New BarberClass
   Dim c As CustomerClass

   Private Delegate Sub EnableButtons()
   Private dummyThread As Thread
   Private toEnableButtons As EnableButtons

   ' Figure out how to use the sub.
   Private Sub ResetButtons()
      btnOpen.Enabled = True
      btnClose.Enabled = False
      btnExit.Enabled = True
      btnNew.Enabled = True
   End Sub

   ' There may be one more task that needs to be completed here.
   Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      ResetButtons()
      toEnableButtons = AddressOf SubToEnableButtons
   End Sub

   ' Opens the Barbershop: creates a new Barber object, sets the needed properties,  and calls OpenBarberShop.
   ' It also should clear txtLog, but not lstWaiting, and disable btnOpen and btnExit, but enable btnNew and cmdClose.
   Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
      b = New BarberClass
      b.MainForm = Me
      b.BarberMessage = AddressOf HandleMessage
      b.OpenBarberShop()
   End Sub

   ' Closes the BarberShop: Disables btnClose, btnExit and btnOpen, but enable btnNew.
   ' It will close the barbershop by calling CloseBeaberShop. 
   ' While waiting for the barber to finish work, the form must display messages as it
   ' normally does and new customers can be created.
   ' After the barber finishes all waiting customers, btnNew, btnOpen and btnExit (but not btnClose) must be enabled.
   Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
      btnClose.Enabled = False
      btnOpen.Enabled = False
      btnExit.Enabled = False
      btnNew.Enabled = True
      b.CloseBarberShop()
      btnOpen.Enabled = True
      btnExit.Enabled = True
   End Sub

   ' Creates a new customer, sets the properties, and spin up the customer.
   Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
      c = New CustomerClass
      c.MainForm = Me
      c.CustomerMessage = AddressOf HandleMessage
      c.SpinUp()
   End Sub

   ' Calls ClearCustomerQueue, then use a message box with Yes/No to ask the user if to terminate.
   ' Terminates the program if the user selects Yes.
   ' Otherwise, continue the program.
   Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
      b.ClearCustomerQueue()
      dummyThread = New Thread(AddressOf ExitApplication)
      dummyThread.Start()

      btnClose.Enabled = False
      btnExit.Enabled = False
      btnNew.Enabled = False
      btnOpen.Enabled = False
   End Sub

   ' This Sub will be used for delegates of the barber and all the customers.
   Private Sub HandleMessage(ByVal msg As String)
      If msg.Contains("Waiting for the Barber") Or msg.Contains("Waking up the Barber") Then
         lstWaiting.Items.Add(msg)
      ElseIf msg.Contains("Cut Hair for Customer") Or msg.Contains("without hair cut") Then
         lstWaiting.Items.RemoveAt(0)
      End If

      If Not msg.Contains("Waiting for the Barber") Then
         txtLog.Text &= msg & vbCrLf
         txtLog.SelectionStart = Len(txtLog.Text) - 1
         txtLog.ScrollToCaret()
      End If
   End Sub

   Private Sub ExitApplication()
      Dim result As Microsoft.VisualBasic.MsgBoxResult
      result = MsgBox("Do you want to exit?", MsgBoxStyle.YesNo)
      If result = MsgBoxResult.Yes Then
         Application.Exit()
      Else
         Me.Invoke(toEnableButtons)
      End If
   End Sub

   Private Sub SubToEnableButtons()
      btnOpen.Enabled = True
      btnClose.Enabled = True
      btnExit.Enabled = True
      btnNew.Enabled = True
   End Sub

End Class
