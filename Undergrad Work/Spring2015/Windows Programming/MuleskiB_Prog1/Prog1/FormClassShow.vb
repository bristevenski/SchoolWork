'----------------------------------------------
' Name: Brianna Muleski
' Date: 1/22/15
' Description: Program2
'              Class FormClassShow
'----------------------------------------------
Public Class FormClassShow
    Private Const MAX_BUTTON_COUNT As Integer = 4
    Private Const BUTTON_HEIGHT As Integer = 23
    Private Const BUTTON_WIDTH As Integer = 75
    Private Const MENU_HEIGHT As Integer = 24
    Private Const MARGIN_SIZE As Integer = 100
    Private Const MULT As Integer = 2


    Private _frmMain As Form
    Private _allButtons As New SortedList()

    'Sets _frmMain to a form object
    Public WriteOnly Property FormShow As Form

        Set(value As Form)
            _frmMain = value
        End Set

    End Property

    'Switches back to _frmMain
    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) _
                                              Handles ReturnToolStripMenuItem.Click

        Me.Hide()
        _frmMain.Show()
        _frmMain.BringToFront()

    End Sub

    'Closes application
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) _
                                            Handles ExitToolStripMenuItem.Click

        Application.Exit()

    End Sub

    'Arranges the buttons on the form with equal spacing between each button and margins. Sets the 
    'location of each button according to its index in the sortedlist
    Private Sub ArrangeButtons()

        Dim temp, index As Integer
        Dim numButtons As Integer = _allButtons.Count
        Dim aButton As Button
        Dim width As Integer = Me.ClientSize.Width - (2 * MARGIN_SIZE)

        temp = (width - numButtons * BUTTON_WIDTH) / (numButtons + 1)

        For index = 0 To numButtons - 1
            aButton = CType(_allButtons.GetByIndex(index), Button)
            aButton.Top = (Me.ClientSize.Height + MENU_HEIGHT) / MULT - BUTTON_HEIGHT / MULT
            aButton.Left = MARGIN_SIZE + temp + (index * (BUTTON_WIDTH + temp))
        Next

    End Sub

    'Changes the font of each button on the form
    Private Sub ChangeFont(ByVal f As FontStyle, ByVal m As ToolStripMenuItem)

        Dim numButtons As Integer = _allButtons.Count
        Dim index As Integer
        Dim aButton As Button

        For index = 0 To numButtons - 1
            aButton = CType(_allButtons.GetByIndex(index), Button)
            aButton.Font = New Font(aButton.Font, aButton.Font.Style Xor f)
        Next

    End Sub

    'Sets the font of the passed button
    Private Sub SetFont(ByVal b As Button)

        If mnuBold.Checked Then
            b.Font = New Font(b.Font, b.Font.Style Xor FontStyle.Bold)
        End If

        If mnuItalic.Checked Then
            b.Font = New Font(b.Font, b.Font.Style Xor FontStyle.Italic)
        End If

        If mnuUnderline.Checked Then
            b.Font = New Font(b.Font, b.Font.Style Xor FontStyle.Underline)
        End If

    End Sub

    'Creates and adds a button to the form and sortedlist based on the key and caption passed. If the max 
    'amount of buttons has been reached or the key already exists in the list, throws an exception.
    Public Sub AddButton(ByVal theKey As String, ByVal theCaption As String)

        If _allButtons.Count = MAX_BUTTON_COUNT Then
            Throw New TaskCanceledException
        End If

        Dim aButton As Button
        aButton = New Button
        aButton.Width = BUTTON_WIDTH
        aButton.Height = BUTTON_HEIGHT
        aButton.Text = theCaption
        aButton.Tag = theKey
        SetFont(aButton)

        AddHandler aButton.Click, AddressOf EventHandler

        Me.Controls.Add(aButton)
        _allButtons.Add(theKey, aButton)

    End Sub

    'removes the button given by the key passed from the form and list if it exists. Throws an exception
    ' if it does not exist
    Public Sub removeButton(ByVal theKey As String)

        Dim index As Integer
        Dim aButton As Button
        index = _allButtons.IndexOfKey(theKey)

        If index = -1 Then
            Throw New Exception
        Else
            aButton = _allButtons.GetByIndex(index)
            Me.Controls.Remove(aButton)
            _allButtons.RemoveAt(index)
        End If

    End Sub

    'Handles the event of pressign the button passed as sender. Shows a message that includes the key and
    'caption of that button.
    Private Sub EventHandler(sender As Object, e As EventArgs)

        Dim b As Button
        b = CType(sender, Button)
        MessageBox.Show("The Key: " & b.Tag & Chr(Keys.LineFeed) & "The Caption: " & b.Text)

    End Sub

    'Handles resizing the form
    Private Sub FormClassShow_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        ArrangeButtons()

    End Sub

    'Handles right-clicking the form, shows a context strip to choose how to change the font
    Private Sub FormClassShow_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick

        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(CType(sender, Control), e.Location)
        End If

    End Sub

    'Handles user attempt to exit
    Private Sub FormClassShow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
        End If

    End Sub

    'Handles clicking the bold font option in the context menu
    Private Sub mnuBold_Click(sender As Object, e As EventArgs) Handles mnuBold.Click

        ChangeFont(FontStyle.Bold, mnuBold)

    End Sub

    'Handles clicking the italic font option in the context menu
    Private Sub mnuItalic_Click(sender As Object, e As EventArgs) Handles mnuItalic.Click

        ChangeFont(FontStyle.Italic, mnuItalic)

    End Sub

    'Handles clicking the underline font option in the context menu
    Private Sub mnuUnderline_Click(sender As Object, e As EventArgs) Handles mnuUnderline.Click

        ChangeFont(FontStyle.Underline, mnuUnderline)

    End Sub

    'Handles when the form is activated
    Private Sub FormClassShow_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        ArrangeButtons()

    End Sub

End Class