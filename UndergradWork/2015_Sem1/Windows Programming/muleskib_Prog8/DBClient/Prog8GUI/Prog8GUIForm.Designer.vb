<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Prog8GUIForm
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
        Me.employeeBtn = New System.Windows.Forms.Button()
        Me.productsBtn = New System.Windows.Forms.Button()
        Me.customersBtn = New System.Windows.Forms.Button()
        Me.ordersBtn = New System.Windows.Forms.Button()
        Me.exitBtn = New System.Windows.Forms.Button()
        Me.localRdBtn = New System.Windows.Forms.RadioButton()
        Me.remoteRdBtn = New System.Windows.Forms.RadioButton()
        Me.hostTxt = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'employeeBtn
        '
        Me.employeeBtn.Location = New System.Drawing.Point(69, 206)
        Me.employeeBtn.Name = "employeeBtn"
        Me.employeeBtn.Size = New System.Drawing.Size(90, 23)
        Me.employeeBtn.TabIndex = 0
        Me.employeeBtn.Text = "EMPLOYEES"
        Me.employeeBtn.UseVisualStyleBackColor = True
        '
        'productsBtn
        '
        Me.productsBtn.Location = New System.Drawing.Point(211, 206)
        Me.productsBtn.Name = "productsBtn"
        Me.productsBtn.Size = New System.Drawing.Size(90, 23)
        Me.productsBtn.TabIndex = 1
        Me.productsBtn.Text = "PRODUCTS"
        Me.productsBtn.UseVisualStyleBackColor = True
        '
        'customersBtn
        '
        Me.customersBtn.Location = New System.Drawing.Point(353, 206)
        Me.customersBtn.Name = "customersBtn"
        Me.customersBtn.Size = New System.Drawing.Size(90, 23)
        Me.customersBtn.TabIndex = 2
        Me.customersBtn.Text = "CUSTOMERS"
        Me.customersBtn.UseVisualStyleBackColor = True
        '
        'ordersBtn
        '
        Me.ordersBtn.Location = New System.Drawing.Point(495, 206)
        Me.ordersBtn.Name = "ordersBtn"
        Me.ordersBtn.Size = New System.Drawing.Size(90, 23)
        Me.ordersBtn.TabIndex = 3
        Me.ordersBtn.Text = "ORDERS"
        Me.ordersBtn.UseVisualStyleBackColor = True
        '
        'exitBtn
        '
        Me.exitBtn.Location = New System.Drawing.Point(282, 287)
        Me.exitBtn.Name = "exitBtn"
        Me.exitBtn.Size = New System.Drawing.Size(90, 23)
        Me.exitBtn.TabIndex = 4
        Me.exitBtn.Text = "EXIT"
        Me.exitBtn.UseVisualStyleBackColor = True
        '
        'localRdBtn
        '
        Me.localRdBtn.AutoSize = True
        Me.localRdBtn.Location = New System.Drawing.Point(154, 78)
        Me.localRdBtn.Name = "localRdBtn"
        Me.localRdBtn.Size = New System.Drawing.Size(76, 17)
        Me.localRdBtn.TabIndex = 5
        Me.localRdBtn.TabStop = True
        Me.localRdBtn.Text = "Local Host"
        Me.localRdBtn.UseVisualStyleBackColor = True
        '
        'remoteRdBtn
        '
        Me.remoteRdBtn.AutoSize = True
        Me.remoteRdBtn.Location = New System.Drawing.Point(401, 78)
        Me.remoteRdBtn.Name = "remoteRdBtn"
        Me.remoteRdBtn.Size = New System.Drawing.Size(87, 17)
        Me.remoteRdBtn.TabIndex = 6
        Me.remoteRdBtn.TabStop = True
        Me.remoteRdBtn.Text = "Remote Host"
        Me.remoteRdBtn.UseVisualStyleBackColor = True
        '
        'hostTxt
        '
        Me.hostTxt.Location = New System.Drawing.Point(401, 120)
        Me.hostTxt.Name = "hostTxt"
        Me.hostTxt.Size = New System.Drawing.Size(100, 20)
        Me.hostTxt.TabIndex = 7
        '
        'Prog8GUIForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 382)
        Me.ControlBox = False
        Me.Controls.Add(Me.hostTxt)
        Me.Controls.Add(Me.remoteRdBtn)
        Me.Controls.Add(Me.localRdBtn)
        Me.Controls.Add(Me.exitBtn)
        Me.Controls.Add(Me.ordersBtn)
        Me.Controls.Add(Me.customersBtn)
        Me.Controls.Add(Me.productsBtn)
        Me.Controls.Add(Me.employeeBtn)
        Me.Name = "Prog8GUIForm"
        Me.Text = "Prog8 - Brianna Muleski"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents employeeBtn As System.Windows.Forms.Button
    Friend WithEvents productsBtn As System.Windows.Forms.Button
    Friend WithEvents customersBtn As System.Windows.Forms.Button
    Friend WithEvents ordersBtn As System.Windows.Forms.Button
    Friend WithEvents exitBtn As System.Windows.Forms.Button
    Friend WithEvents localRdBtn As System.Windows.Forms.RadioButton
    Friend WithEvents remoteRdBtn As System.Windows.Forms.RadioButton
    Friend WithEvents hostTxt As System.Windows.Forms.TextBox
End Class
