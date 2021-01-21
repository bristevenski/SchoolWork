<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReaderWriterForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnNewWriter = New System.Windows.Forms.Button()
        Me.btnNewReader = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.totLbl = New System.Windows.Forms.Label()
        Me.workLbl = New System.Windows.Forms.Label()
        Me.waitLbl = New System.Windows.Forms.Label()
        Me.lstWorking = New System.Windows.Forms.ListBox()
        Me.lstWaiting = New System.Windows.Forms.ListBox()
        Me.totalTxt = New System.Windows.Forms.TextBox()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnNewWriter
        '
        Me.btnNewWriter.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNewWriter.Location = New System.Drawing.Point(380, 353)
        Me.btnNewWriter.Name = "btnNewWriter"
        Me.btnNewWriter.Size = New System.Drawing.Size(75, 23)
        Me.btnNewWriter.TabIndex = 0
        Me.btnNewWriter.Text = "New Writer"
        Me.btnNewWriter.UseVisualStyleBackColor = True
        '
        'btnNewReader
        '
        Me.btnNewReader.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNewReader.Location = New System.Drawing.Point(268, 353)
        Me.btnNewReader.Name = "btnNewReader"
        Me.btnNewReader.Size = New System.Drawing.Size(75, 23)
        Me.btnNewReader.TabIndex = 1
        Me.btnNewReader.Text = "New Reader"
        Me.btnNewReader.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExit.Location = New System.Drawing.Point(491, 353)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'totLbl
        '
        Me.totLbl.AutoSize = True
        Me.totLbl.Location = New System.Drawing.Point(341, 33)
        Me.totLbl.Name = "totLbl"
        Me.totLbl.Size = New System.Drawing.Size(34, 13)
        Me.totLbl.TabIndex = 3
        Me.totLbl.Text = "Total:"
        '
        'workLbl
        '
        Me.workLbl.AutoSize = True
        Me.workLbl.Location = New System.Drawing.Point(86, 91)
        Me.workLbl.Name = "workLbl"
        Me.workLbl.Size = New System.Drawing.Size(47, 13)
        Me.workLbl.TabIndex = 4
        Me.workLbl.Text = "Working"
        '
        'waitLbl
        '
        Me.waitLbl.AutoSize = True
        Me.waitLbl.Location = New System.Drawing.Point(704, 91)
        Me.waitLbl.Name = "waitLbl"
        Me.waitLbl.Size = New System.Drawing.Size(43, 13)
        Me.waitLbl.TabIndex = 5
        Me.waitLbl.Text = "Waiting"
        '
        'lstWorking
        '
        Me.lstWorking.FormattingEnabled = True
        Me.lstWorking.Location = New System.Drawing.Point(21, 117)
        Me.lstWorking.Name = "lstWorking"
        Me.lstWorking.Size = New System.Drawing.Size(177, 186)
        Me.lstWorking.TabIndex = 6
        '
        'lstWaiting
        '
        Me.lstWaiting.FormattingEnabled = True
        Me.lstWaiting.Location = New System.Drawing.Point(637, 117)
        Me.lstWaiting.Name = "lstWaiting"
        Me.lstWaiting.Size = New System.Drawing.Size(177, 186)
        Me.lstWaiting.TabIndex = 7
        '
        'totalTxt
        '
        Me.totalTxt.Location = New System.Drawing.Point(393, 30)
        Me.totalTxt.Name = "totalTxt"
        Me.totalTxt.Size = New System.Drawing.Size(100, 20)
        Me.totalTxt.TabIndex = 8
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(230, 77)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(375, 226)
        Me.txtLog.TabIndex = 9
        '
        'ReaderWriterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 421)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.totalTxt)
        Me.Controls.Add(Me.lstWaiting)
        Me.Controls.Add(Me.lstWorking)
        Me.Controls.Add(Me.waitLbl)
        Me.Controls.Add(Me.workLbl)
        Me.Controls.Add(Me.totLbl)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnNewReader)
        Me.Controls.Add(Me.btnNewWriter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "ReaderWriterForm"
        Me.Text = "Readers and Writers - FIFO Brianna Muleski"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNewWriter As System.Windows.Forms.Button
    Friend WithEvents btnNewReader As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents totLbl As System.Windows.Forms.Label
    Friend WithEvents workLbl As System.Windows.Forms.Label
    Friend WithEvents waitLbl As System.Windows.Forms.Label
    Friend WithEvents lstWorking As System.Windows.Forms.ListBox
    Friend WithEvents lstWaiting As System.Windows.Forms.ListBox
    Friend WithEvents totalTxt As System.Windows.Forms.TextBox
    Friend WithEvents txtLog As System.Windows.Forms.TextBox

End Class
