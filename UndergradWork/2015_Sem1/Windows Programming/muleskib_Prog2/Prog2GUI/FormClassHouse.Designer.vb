<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClassHouse
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
        Me.typeCombo = New System.Windows.Forms.ComboBox()
        Me.typeLbl = New System.Windows.Forms.Label()
        Me.idLbl = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.priceLbl = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.rmsGroup = New System.Windows.Forms.GroupBox()
        Me.rms2 = New System.Windows.Forms.RadioButton()
        Me.rms3 = New System.Windows.Forms.RadioButton()
        Me.rms4 = New System.Windows.Forms.RadioButton()
        Me.grgGroup = New System.Windows.Forms.GroupBox()
        Me.grg2 = New System.Windows.Forms.RadioButton()
        Me.grg1 = New System.Windows.Forms.RadioButton()
        Me.grg3 = New System.Windows.Forms.RadioButton()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.btnList = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.rmsGroup.SuspendLayout()
        Me.grgGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'typeCombo
        '
        Me.typeCombo.Cursor = System.Windows.Forms.Cursors.Default
        Me.typeCombo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.typeCombo.FormattingEnabled = True
        Me.typeCombo.Items.AddRange(New Object() {"Chicago", "Madison", "Platteville"})
        Me.typeCombo.Location = New System.Drawing.Point(12, 153)
        Me.typeCombo.Name = "typeCombo"
        Me.typeCombo.Size = New System.Drawing.Size(121, 21)
        Me.typeCombo.TabIndex = 0
        '
        'typeLbl
        '
        Me.typeLbl.AutoSize = True
        Me.typeLbl.Location = New System.Drawing.Point(57, 132)
        Me.typeLbl.Name = "typeLbl"
        Me.typeLbl.Size = New System.Drawing.Size(31, 13)
        Me.typeLbl.TabIndex = 2
        Me.typeLbl.Text = "Type"
        '
        'idLbl
        '
        Me.idLbl.AutoSize = True
        Me.idLbl.Location = New System.Drawing.Point(63, 192)
        Me.idLbl.Name = "idLbl"
        Me.idLbl.Size = New System.Drawing.Size(18, 13)
        Me.idLbl.TabIndex = 3
        Me.idLbl.Text = "ID"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(12, 213)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(121, 20)
        Me.txtID.TabIndex = 4
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(12, 277)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(121, 20)
        Me.txtPrice.TabIndex = 5
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'priceLbl
        '
        Me.priceLbl.AutoSize = True
        Me.priceLbl.Location = New System.Drawing.Point(57, 256)
        Me.priceLbl.Name = "priceLbl"
        Me.priceLbl.Size = New System.Drawing.Size(31, 13)
        Me.priceLbl.TabIndex = 6
        Me.priceLbl.Text = "Price"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(33, 332)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'rmsGroup
        '
        Me.rmsGroup.Controls.Add(Me.rms2)
        Me.rmsGroup.Controls.Add(Me.rms3)
        Me.rmsGroup.Controls.Add(Me.rms4)
        Me.rmsGroup.Enabled = False
        Me.rmsGroup.Location = New System.Drawing.Point(244, 96)
        Me.rmsGroup.Name = "rmsGroup"
        Me.rmsGroup.Size = New System.Drawing.Size(267, 100)
        Me.rmsGroup.TabIndex = 8
        Me.rmsGroup.TabStop = False
        Me.rmsGroup.Text = "Rooms"
        '
        'rms2
        '
        Me.rms2.AutoSize = True
        Me.rms2.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.rms2.Location = New System.Drawing.Point(209, 34)
        Me.rms2.Name = "rms2"
        Me.rms2.Size = New System.Drawing.Size(17, 30)
        Me.rms2.TabIndex = 2
        Me.rms2.TabStop = True
        Me.rms2.Tag = "2"
        Me.rms2.Text = "2"
        Me.rms2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rms2.UseVisualStyleBackColor = True
        '
        'rms3
        '
        Me.rms3.AutoSize = True
        Me.rms3.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.rms3.Location = New System.Drawing.Point(123, 34)
        Me.rms3.Name = "rms3"
        Me.rms3.Size = New System.Drawing.Size(17, 30)
        Me.rms3.TabIndex = 1
        Me.rms3.Tag = "3"
        Me.rms3.Text = "3"
        Me.rms3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rms3.UseVisualStyleBackColor = True
        '
        'rms4
        '
        Me.rms4.AutoSize = True
        Me.rms4.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.rms4.Location = New System.Drawing.Point(37, 34)
        Me.rms4.Name = "rms4"
        Me.rms4.Size = New System.Drawing.Size(17, 30)
        Me.rms4.TabIndex = 0
        Me.rms4.TabStop = True
        Me.rms4.Tag = "4"
        Me.rms4.Text = "4"
        Me.rms4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rms4.UseVisualStyleBackColor = True
        '
        'grgGroup
        '
        Me.grgGroup.Controls.Add(Me.grg2)
        Me.grgGroup.Controls.Add(Me.grg1)
        Me.grgGroup.Controls.Add(Me.grg3)
        Me.grgGroup.Enabled = False
        Me.grgGroup.Location = New System.Drawing.Point(244, 211)
        Me.grgGroup.Name = "grgGroup"
        Me.grgGroup.Size = New System.Drawing.Size(267, 100)
        Me.grgGroup.TabIndex = 9
        Me.grgGroup.TabStop = False
        Me.grgGroup.Text = "Garages"
        '
        'grg2
        '
        Me.grg2.AutoSize = True
        Me.grg2.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.grg2.Location = New System.Drawing.Point(123, 36)
        Me.grg2.Name = "grg2"
        Me.grg2.Size = New System.Drawing.Size(17, 30)
        Me.grg2.TabIndex = 2
        Me.grg2.TabStop = True
        Me.grg2.Tag = "2"
        Me.grg2.Text = "2"
        Me.grg2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.grg2.UseVisualStyleBackColor = True
        '
        'grg1
        '
        Me.grg1.AutoSize = True
        Me.grg1.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.grg1.Location = New System.Drawing.Point(209, 36)
        Me.grg1.Name = "grg1"
        Me.grg1.Size = New System.Drawing.Size(17, 30)
        Me.grg1.TabIndex = 1
        Me.grg1.TabStop = True
        Me.grg1.Tag = "1"
        Me.grg1.Text = "1"
        Me.grg1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.grg1.UseVisualStyleBackColor = True
        '
        'grg3
        '
        Me.grg3.AutoSize = True
        Me.grg3.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.grg3.Location = New System.Drawing.Point(37, 36)
        Me.grg3.Name = "grg3"
        Me.grg3.Size = New System.Drawing.Size(17, 30)
        Me.grg3.TabIndex = 0
        Me.grg3.TabStop = True
        Me.grg3.Tag = "3"
        Me.grg3.Text = "3"
        Me.grg3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.grg3.UseVisualStyleBackColor = True
        '
        'btnModify
        '
        Me.btnModify.Enabled = False
        Me.btnModify.Location = New System.Drawing.Point(340, 332)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(75, 23)
        Me.btnModify.TabIndex = 10
        Me.btnModify.Text = "MODIFY"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnList
        '
        Me.btnList.Location = New System.Drawing.Point(638, 159)
        Me.btnList.Name = "btnList"
        Me.btnList.Size = New System.Drawing.Size(75, 23)
        Me.btnList.TabIndex = 11
        Me.btnList.Text = "LIST"
        Me.btnList.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(638, 214)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'FormClassHouse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 451)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnList)
        Me.Controls.Add(Me.btnModify)
        Me.Controls.Add(Me.grgGroup)
        Me.Controls.Add(Me.rmsGroup)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.priceLbl)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.idLbl)
        Me.Controls.Add(Me.typeLbl)
        Me.Controls.Add(Me.typeCombo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FormClassHouse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Program 2 - Brianna Muleski"
        Me.rmsGroup.ResumeLayout(False)
        Me.rmsGroup.PerformLayout()
        Me.grgGroup.ResumeLayout(False)
        Me.grgGroup.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents typeCombo As System.Windows.Forms.ComboBox
    Friend WithEvents typeLbl As System.Windows.Forms.Label
    Friend WithEvents idLbl As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents priceLbl As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents rmsGroup As System.Windows.Forms.GroupBox
    Friend WithEvents rms2 As System.Windows.Forms.RadioButton
    Friend WithEvents rms3 As System.Windows.Forms.RadioButton
    Friend WithEvents rms4 As System.Windows.Forms.RadioButton
    Friend WithEvents grgGroup As System.Windows.Forms.GroupBox
    Friend WithEvents grg2 As System.Windows.Forms.RadioButton
    Friend WithEvents grg1 As System.Windows.Forms.RadioButton
    Friend WithEvents grg3 As System.Windows.Forms.RadioButton
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents btnList As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
