'----------------------------------------------
' Name: Brianna Muleski
' Date: 2/13/2015
' Description: Program 3
'              Class FormClassMDI
'---------------------------------------------
Imports System.Windows.Forms
Imports UWPCS3340

Public Class FormClassMDI
    Private _branchNo As Integer

    ' Creates a FormClassHouse object, sets this to its parent, sets this to its ListForm's parent, 
    ' shows the FormClassHouse object, and displays the time.
    Private Sub FormClassMDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim f As FormClassHouse = New FormClassHouse
        f.MdiParent = Me
        f.Show()
        lblDate.Text = Now.ToLongTimeString
    End Sub

    ' Creates a new FormClassBranch object, increases the branch number, sets this to its parent, sets
    ' this to its ListForm's parant, and shoes the FormClassBranch object .
    Private Sub newButton_Click(sender As Object, e As EventArgs) Handles newButton.Click
        Dim f As FormClassBranch = New FormClassBranch
        _branchNo += 1
        f.BranchNo = _branchNo
        f.MdiParent = Me
        f.Show()
    End Sub

    ' Exits the application.
    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Application.Exit()
    End Sub

    ' Displays the child forms in a cascade layout.
    Private Sub CascadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    ' Displays the child forms in a tile horizontal layout.
    Private Sub TileHorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    ' Displays the child forms in a tile vertical layout.
    Private Sub TileVerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    ' Arranges the icons.
    Private Sub ArrangeIconsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    ' Updates the displayed time.
    Private Sub mainTimer_Tick(sender As Object, e As EventArgs) Handles mainTimer.Tick
        lblDate.Text = Now.ToLongTimeString
    End Sub
End Class
