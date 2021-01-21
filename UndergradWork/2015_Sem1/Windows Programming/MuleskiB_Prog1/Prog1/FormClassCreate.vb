'----------------------------------------------
' Name: Brianna Muleski
' Date: 1/22/15
' Description: Program2
'              Class FormClassCreate
'----------------------------------------------
Public Class FormClassCreate

    Private Const MAX_KEY_LENGTH As Integer = 6
    Private _frmShow As FormClassShow

    'Constructor: Initializes components and _frmShow. Sets _frmShow's FormShow to this form, selects Key
    'textbox as inital textbox
    Public Sub New()

        InitializeComponent()
        _frmShow = New FormClassShow
        _frmShow.FormShow = Me
        txtKey.Select()

    End Sub

    'Switches to _frmShow
    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) _
                                            Handles ShowToolStripMenuItem.Click

        Me.Hide()
        _frmShow.Show()

    End Sub

    'Handles exit menu item, closes application
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) _
                                            Handles ExitToolStripMenuItem.Click

        Application.Exit()

    End Sub

    'Tests validity of Key and creates the button if valid. If invalid, shows an error message
    Private Sub CreateToolStripMenuItem_Click(sender As Object, e As EventArgs) _
                                              Handles CreateToolStripMenuItem.Click
        Dim key As String = txtKey.Text
        Dim caption As String = txtCaption.Text
        Dim keyLength As Integer = txtKey.TextLength

        If keyLength = 0 Then
            Beep()
            MessageBox.Show("You must specify a key!")
            Return
        End If

        Try
            _frmShow.AddButton(key, caption)
        Catch ex As TaskCanceledException
            Beep()
            MessageBox.Show("Button limit reached!")
        Catch ex As ArgumentException
            Beep()
            MessageBox.Show("Item has already been added. Key in dictionary: " & key &
                            " Key being added: " & key)
        End Try

    End Sub

    'Handles other exit attempts be user (Alt+F4)
    Private Sub FormClassCreate_FormClosing(sender As Object, e As FormClosingEventArgs) _
                                            Handles Me.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
        End If

    End Sub

    'Checks validity of Key, removes button if it exists. If invalid or does not exist, shows error message
    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) _
                                              Handles RemoveToolStripMenuItem.Click
        Dim length As Integer = txtKey.TextLength

        If length = 0 Then
            Beep()
            MessageBox.Show("You must specify a key!")
            Return
        End If

        Try
            _frmShow.removeButton(txtKey.Text)
        Catch ex As Exception
            Beep()
            MessageBox.Show("Button does not exist!")
        End Try

    End Sub

    'Checks validity of Key, handles input errors and shows error message
    Private Sub txtKey_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKey.KeyPress

        Dim length As Integer = txtKey.TextLength

        If e.KeyChar = Chr(Keys.Back) Then
            e.Handled = False

        ElseIf e.KeyChar >= "0" And e.KeyChar <= "9" And length = 0 Then
            e.Handled = True
            Beep()
            MessageBox.Show("Key cannot begin with a digit!")

        ElseIf length = MAX_KEY_LENGTH Then
            e.Handled = True
            Beep()
            MessageBox.Show("Key cannot exceed 6 characters!")
        End If

    End Sub

End Class
