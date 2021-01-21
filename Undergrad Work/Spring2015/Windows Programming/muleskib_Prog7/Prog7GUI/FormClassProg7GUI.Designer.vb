<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClassProg7GUI
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
        Me.exitBtn = New System.Windows.Forms.Button()
        Me.empBtn = New System.Windows.Forms.Button()
        Me.dbLocBtn = New System.Windows.Forms.Button()
        Me.orderBtn = New System.Windows.Forms.Button()
        Me.prodBtn = New System.Windows.Forms.Button()
        Me.custBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'exitBtn
        '
        Me.exitBtn.Location = New System.Drawing.Point(252, 215)
        Me.exitBtn.Name = "exitBtn"
        Me.exitBtn.Size = New System.Drawing.Size(75, 23)
        Me.exitBtn.TabIndex = 0
        Me.exitBtn.Text = "Exit"
        Me.exitBtn.UseVisualStyleBackColor = True
        '
        'empBtn
        '
        Me.empBtn.Location = New System.Drawing.Point(106, 136)
        Me.empBtn.Name = "empBtn"
        Me.empBtn.Size = New System.Drawing.Size(75, 23)
        Me.empBtn.TabIndex = 1
        Me.empBtn.Text = "Employees"
        Me.empBtn.UseVisualStyleBackColor = True
        '
        'dbLocBtn
        '
        Me.dbLocBtn.Location = New System.Drawing.Point(398, 215)
        Me.dbLocBtn.Name = "dbLocBtn"
        Me.dbLocBtn.Size = New System.Drawing.Size(75, 23)
        Me.dbLocBtn.TabIndex = 2
        Me.dbLocBtn.Text = "DB Location"
        Me.dbLocBtn.UseVisualStyleBackColor = True
        '
        'orderBtn
        '
        Me.orderBtn.Location = New System.Drawing.Point(544, 136)
        Me.orderBtn.Name = "orderBtn"
        Me.orderBtn.Size = New System.Drawing.Size(75, 23)
        Me.orderBtn.TabIndex = 3
        Me.orderBtn.Text = "Orders"
        Me.orderBtn.UseVisualStyleBackColor = True
        '
        'prodBtn
        '
        Me.prodBtn.Location = New System.Drawing.Point(252, 136)
        Me.prodBtn.Name = "prodBtn"
        Me.prodBtn.Size = New System.Drawing.Size(75, 23)
        Me.prodBtn.TabIndex = 4
        Me.prodBtn.Text = "Products"
        Me.prodBtn.UseVisualStyleBackColor = True
        '
        'custBtn
        '
        Me.custBtn.Location = New System.Drawing.Point(398, 136)
        Me.custBtn.Name = "custBtn"
        Me.custBtn.Size = New System.Drawing.Size(75, 23)
        Me.custBtn.TabIndex = 5
        Me.custBtn.Text = "Customers"
        Me.custBtn.UseVisualStyleBackColor = True
        '
        'FormClassProg7GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 375)
        Me.ControlBox = False
        Me.Controls.Add(Me.custBtn)
        Me.Controls.Add(Me.prodBtn)
        Me.Controls.Add(Me.orderBtn)
        Me.Controls.Add(Me.dbLocBtn)
        Me.Controls.Add(Me.empBtn)
        Me.Controls.Add(Me.exitBtn)
        Me.Name = "FormClassProg7GUI"
        Me.Text = "Prog7 - Brianna Muleski"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents exitBtn As System.Windows.Forms.Button
    Friend WithEvents empBtn As System.Windows.Forms.Button
    Friend WithEvents dbLocBtn As System.Windows.Forms.Button
    Friend WithEvents orderBtn As System.Windows.Forms.Button
    Friend WithEvents prodBtn As System.Windows.Forms.Button
    Friend WithEvents custBtn As System.Windows.Forms.Button

End Class
