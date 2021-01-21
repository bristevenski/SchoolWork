<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClassThread
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
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtTransaction = New System.Windows.Forms.TextBox()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.transLbl = New System.Windows.Forms.Label()
        Me.balLbl = New System.Windows.Forms.Label()
        Me.lstAllUsers = New System.Windows.Forms.ListBox()
        Me.btnWait = New System.Windows.Forms.Button()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.btnTerminate = New System.Windows.Forms.Button()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(286, 105)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(87, 23)
        Me.btnCreate.TabIndex = 0
        Me.btnCreate.Text = "NEW"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(286, 317)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(87, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'txtTransaction
        '
        Me.txtTransaction.Location = New System.Drawing.Point(121, 50)
        Me.txtTransaction.Name = "txtTransaction"
        Me.txtTransaction.Size = New System.Drawing.Size(131, 20)
        Me.txtTransaction.TabIndex = 5
        Me.txtTransaction.Text = "$0.00"
        Me.txtTransaction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBalance
        '
        Me.txtBalance.Location = New System.Drawing.Point(406, 49)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.Size = New System.Drawing.Size(131, 20)
        Me.txtBalance.TabIndex = 6
        Me.txtBalance.Text = "$1,000.00"
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'transLbl
        '
        Me.transLbl.AutoSize = True
        Me.transLbl.Location = New System.Drawing.Point(121, 31)
        Me.transLbl.Name = "transLbl"
        Me.transLbl.Size = New System.Drawing.Size(95, 13)
        Me.transLbl.TabIndex = 7
        Me.transLbl.Text = "Total Transactions"
        '
        'balLbl
        '
        Me.balLbl.AutoSize = True
        Me.balLbl.Location = New System.Drawing.Point(406, 31)
        Me.balLbl.Name = "balLbl"
        Me.balLbl.Size = New System.Drawing.Size(73, 13)
        Me.balLbl.TabIndex = 8
        Me.balLbl.Text = "Total Balance"
        '
        'lstAllUsers
        '
        Me.lstAllUsers.FormattingEnabled = True
        Me.lstAllUsers.Location = New System.Drawing.Point(424, 102)
        Me.lstAllUsers.Name = "lstAllUsers"
        Me.lstAllUsers.Size = New System.Drawing.Size(204, 238)
        Me.lstAllUsers.TabIndex = 9
        '
        'btnWait
        '
        Me.btnWait.Location = New System.Drawing.Point(286, 158)
        Me.btnWait.Name = "btnWait"
        Me.btnWait.Size = New System.Drawing.Size(87, 23)
        Me.btnWait.TabIndex = 1
        Me.btnWait.Text = "WAIT"
        Me.btnWait.UseVisualStyleBackColor = True
        '
        'btnContinue
        '
        Me.btnContinue.Location = New System.Drawing.Point(286, 211)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(87, 23)
        Me.btnContinue.TabIndex = 2
        Me.btnContinue.Text = "CONTINUE"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'btnTerminate
        '
        Me.btnTerminate.Location = New System.Drawing.Point(286, 264)
        Me.btnTerminate.Name = "btnTerminate"
        Me.btnTerminate.Size = New System.Drawing.Size(87, 23)
        Me.btnTerminate.TabIndex = 3
        Me.btnTerminate.Text = "TERMINATE"
        Me.btnTerminate.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(31, 102)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(204, 238)
        Me.txtLog.TabIndex = 10
        '
        'FormClassThread
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 400)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.lstAllUsers)
        Me.Controls.Add(Me.balLbl)
        Me.Controls.Add(Me.transLbl)
        Me.Controls.Add(Me.txtBalance)
        Me.Controls.Add(Me.txtTransaction)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnTerminate)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.btnWait)
        Me.Controls.Add(Me.btnCreate)
        Me.Name = "FormClassThread"
        Me.Text = "Prog4 - Brianna Muleski"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents txtTransaction As System.Windows.Forms.TextBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents transLbl As System.Windows.Forms.Label
    Friend WithEvents balLbl As System.Windows.Forms.Label
    Friend WithEvents lstAllUsers As System.Windows.Forms.ListBox
    Friend WithEvents btnWait As System.Windows.Forms.Button
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents btnTerminate As System.Windows.Forms.Button
    Friend WithEvents txtLog As System.Windows.Forms.TextBox

End Class
