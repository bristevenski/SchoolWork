<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Booking
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
      Me.dataGrid = New System.Windows.Forms.DataGridView()
      Me.updateBtn = New System.Windows.Forms.Button()
      Me.searchBtn = New System.Windows.Forms.Button()
      Me.allBtn = New System.Windows.Forms.Button()
      Me.exitBtn = New System.Windows.Forms.Button()
      Me.field = New System.Windows.Forms.ComboBox()
      Me.op = New System.Windows.Forms.ComboBox()
      Me.value = New System.Windows.Forms.TextBox()
      CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'dataGrid
      '
      Me.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dataGrid.Location = New System.Drawing.Point(25, 22)
      Me.dataGrid.Name = "dataGrid"
      Me.dataGrid.Size = New System.Drawing.Size(407, 222)
      Me.dataGrid.TabIndex = 0
      '
      'updateBtn
      '
      Me.updateBtn.Location = New System.Drawing.Point(499, 41)
      Me.updateBtn.Name = "updateBtn"
      Me.updateBtn.Size = New System.Drawing.Size(75, 23)
      Me.updateBtn.TabIndex = 1
      Me.updateBtn.Text = "Update"
      Me.updateBtn.UseVisualStyleBackColor = True
      '
      'searchBtn
      '
      Me.searchBtn.Location = New System.Drawing.Point(499, 92)
      Me.searchBtn.Name = "searchBtn"
      Me.searchBtn.Size = New System.Drawing.Size(75, 23)
      Me.searchBtn.TabIndex = 2
      Me.searchBtn.Text = "Search"
      Me.searchBtn.UseVisualStyleBackColor = True
      '
      'allBtn
      '
      Me.allBtn.Location = New System.Drawing.Point(499, 153)
      Me.allBtn.Name = "allBtn"
      Me.allBtn.Size = New System.Drawing.Size(75, 23)
      Me.allBtn.TabIndex = 3
      Me.allBtn.Text = "All"
      Me.allBtn.UseVisualStyleBackColor = True
      '
      'exitBtn
      '
      Me.exitBtn.Location = New System.Drawing.Point(499, 205)
      Me.exitBtn.Name = "exitBtn"
      Me.exitBtn.Size = New System.Drawing.Size(75, 23)
      Me.exitBtn.TabIndex = 4
      Me.exitBtn.Text = "Exit"
      Me.exitBtn.UseVisualStyleBackColor = True
      '
      'field
      '
      Me.field.FormattingEnabled = True
      Me.field.Items.AddRange(New Object() {"Hotel_No", "Room_No", "Guest_No", "Date_From", "Date_To"})
      Me.field.Location = New System.Drawing.Point(8, 267)
      Me.field.Name = "field"
      Me.field.Size = New System.Drawing.Size(121, 21)
      Me.field.TabIndex = 5
      '
      'op
      '
      Me.op.FormattingEnabled = True
      Me.op.Items.AddRange(New Object() {"=", ">", ">=", "<", "<="})
      Me.op.Location = New System.Drawing.Point(158, 268)
      Me.op.Name = "op"
      Me.op.Size = New System.Drawing.Size(121, 21)
      Me.op.TabIndex = 6
      '
      'value
      '
      Me.value.AccessibleName = ""
      Me.value.Location = New System.Drawing.Point(316, 268)
      Me.value.Name = "value"
      Me.value.Size = New System.Drawing.Size(100, 20)
      Me.value.TabIndex = 7
      '
      'Booking
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(627, 309)
      Me.Controls.Add(Me.value)
      Me.Controls.Add(Me.op)
      Me.Controls.Add(Me.field)
      Me.Controls.Add(Me.exitBtn)
      Me.Controls.Add(Me.allBtn)
      Me.Controls.Add(Me.searchBtn)
      Me.Controls.Add(Me.updateBtn)
      Me.Controls.Add(Me.dataGrid)
      Me.Name = "Booking"
      Me.Text = "CS3630 - Brianna Muleski, Brianna Miller, Ashlyn Schwoerer"
      CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dataGrid As System.Windows.Forms.DataGridView
   Friend WithEvents updateBtn As System.Windows.Forms.Button
   Friend WithEvents searchBtn As System.Windows.Forms.Button
   Friend WithEvents allBtn As System.Windows.Forms.Button
   Friend WithEvents exitBtn As System.Windows.Forms.Button
   Friend WithEvents field As System.Windows.Forms.ComboBox
   Friend WithEvents op As System.Windows.Forms.ComboBox
   Friend WithEvents value As System.Windows.Forms.TextBox
End Class
