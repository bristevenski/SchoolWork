Public Class FormClassJump
   Private Const BUTTON_WIDTH As Integer = 85
   Private Const BUTTON_HEIGHT As Integer = 35
   Private Const MAX_BUTTONS As Integer = 3

   Private _mainform As Form
   Private AllButtons As New SortedList

   Public WriteOnly Property MainForm As Form

      Set(value As Form)
         _mainform = value
      End Set

   End Property

   ' Required public sub
   Public Sub RemoveButton(ByVal theKey As String)
      Dim index As Integer
      Dim aButton As Button
      index = AllButtons.IndexOfKey(theKey)

      If index = -1 Then
         Throw New Exception("No button has the Key!")
      Else
         aButton = AllButtons.GetByIndex(index)
         Me.Controls.Remove(aButton)
         AllButtons.RemoveAt(index)
      End If
   End Sub

   ' Required public sub
   Public Sub CreateButton(ByVal theKey As String, ByVal theCaption As String)
      If AllButtons.Count = MAX_BUTTONS Then
         Throw New Exception("There are three buttons created already!")
      End If

      Dim button As Button
      button = New Button
      button.Width = BUTTON_WIDTH
      button.Height = BUTTON_HEIGHT
      button.Text = theCaption
      button.Tag = theKey
      button.Top = ClientSize.Height / 2 - BUTTON_HEIGHT / 2
      button.Left = ClientSize.Width / 2 - BUTTON_WIDTH / 2

      AddHandler button.Click, AddressOf JumpEvent

      AllButtons.Add(theKey, button)
      Me.Controls.Add(button)

   End Sub

   ' Required private sub
   Private Sub ArrangeButtons()
      Dim temp, index As Integer
      Dim numButtons As Integer = AllButtons.Count
      Dim aButton As Button

      temp = (ClientSize.Height - BUTTON_HEIGHT * numButtons) / (numButtons + 1)

      For index = 0 To numButtons - 1
         aButton = CType(AllButtons.GetByIndex(index), Button)
         aButton.Top = temp + ((BUTTON_HEIGHT + temp) * index)
      Next
   End Sub

   ' Required event handler
   Private Sub JumpEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Static count(3) As Integer
      For Each element As Integer In count
         If (count Is Nothing) Then
            count(element) = 0
         End If
      Next

         Dim index As Integer

         Dim button As Button
         button = CType(sender, Button)

         index = AllButtons.IndexOfKey(button.Tag)
      count(index) = count(index) + 1

         If count(index) = 1 Then
            button.Left = button.Left - BUTTON_WIDTH
         ElseIf count(index) = 2 Then
            button.Left = ClientSize.Width / 2 - BUTTON_WIDTH / 2
         ElseIf count(index) = 3 Then
            button.Left = button.Left + BUTTON_WIDTH
         ElseIf count(index) = 4 Then
            button.Left = ClientSize.Width / 2 - BUTTON_WIDTH / 2
            count(index) = 0
         End If
   End Sub

   Private Sub FormClassJump_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
      ArrangeButtons()
   End Sub

   Private Sub FormClassJump_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
      ArrangeButtons()
   End Sub

   Private Sub mnuBACK_Click(sender As Object, e As EventArgs) Handles mnuBACK.Click
      Me.Hide()
      _mainform.Show()
      _mainform.BringToFront()
   End Sub

   Private Sub mnuEXIT_Click(sender As Object, e As EventArgs) Handles mnuEXIT.Click
      Application.Exit()
   End Sub

   Private Sub FormClassJump_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick

      If e.Button = Windows.Forms.MouseButtons.Right Then
         ContextMenuStrip1.Show(CType(sender, Control), e.Location)
      End If

   End Sub
End Class