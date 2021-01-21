<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOrderClass
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
        Me.components = New System.ComponentModel.Container()
        Me.CompanyDataSet = New Prog7GUI.CompanyDataSet()
        Me.OrderDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrderDetailsTableAdapter = New Prog7GUI.CompanyDataSetTableAdapters.OrderDetailsTableAdapter()
        Me.TableAdapterManager = New Prog7GUI.CompanyDataSetTableAdapters.TableAdapterManager()
        Me.OrdersTableAdapter = New Prog7GUI.CompanyDataSetTableAdapters.OrdersTableAdapter()
        Me.OrdersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvOrder = New System.Windows.Forms.DataGridView()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.backBtn = New System.Windows.Forms.Button()
        Me.prevBtn = New System.Windows.Forms.Button()
        Me.nextBtn = New System.Windows.Forms.Button()
        Me.allRdBtn = New System.Windows.Forms.RadioButton()
        Me.ordEmpRdBtn = New System.Windows.Forms.RadioButton()
        Me.nameTxt = New System.Windows.Forms.TextBox()
        Me.nameLbl = New System.Windows.Forms.Label()
        Me.idTxt = New System.Windows.Forms.TextBox()
        Me.idLbl = New System.Windows.Forms.Label()
        Me.updOrdBtn = New System.Windows.Forms.Button()
        Me.updDetBtn = New System.Windows.Forms.Button()
        Me.EmployeesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeesTableAdapter = New Prog7GUI.CompanyDataSetTableAdapters.EmployeesTableAdapter()
        CType(Me.CompanyDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CompanyDataSet
        '
        Me.CompanyDataSet.DataSetName = "CompanyDataSet"
        Me.CompanyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OrderDetailsBindingSource
        '
        Me.OrderDetailsBindingSource.DataMember = "OrderDetails"
        Me.OrderDetailsBindingSource.DataSource = Me.CompanyDataSet
        '
        'OrderDetailsTableAdapter
        '
        Me.OrderDetailsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CustomersTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesTableAdapter = Nothing
        Me.TableAdapterManager.OrderDetailsTableAdapter = Me.OrderDetailsTableAdapter
        Me.TableAdapterManager.OrdersTableAdapter = Me.OrdersTableAdapter
        Me.TableAdapterManager.ProductsTableAdapter = Nothing
        Me.TableAdapterManager.SalesStaffTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Prog7GUI.CompanyDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'OrdersTableAdapter
        '
        Me.OrdersTableAdapter.ClearBeforeFill = True
        '
        'OrdersBindingSource
        '
        Me.OrdersBindingSource.DataMember = "Orders"
        Me.OrdersBindingSource.DataSource = Me.CompanyDataSet
        '
        'dgvOrder
        '
        Me.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrder.Location = New System.Drawing.Point(47, 21)
        Me.dgvOrder.Name = "dgvOrder"
        Me.dgvOrder.Size = New System.Drawing.Size(287, 150)
        Me.dgvOrder.TabIndex = 0
        '
        'dgvDetail
        '
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Location = New System.Drawing.Point(47, 236)
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.Size = New System.Drawing.Size(287, 150)
        Me.dgvDetail.TabIndex = 1
        '
        'backBtn
        '
        Me.backBtn.Location = New System.Drawing.Point(440, 315)
        Me.backBtn.Name = "backBtn"
        Me.backBtn.Size = New System.Drawing.Size(75, 23)
        Me.backBtn.TabIndex = 2
        Me.backBtn.Text = "Back"
        Me.backBtn.UseVisualStyleBackColor = True
        '
        'prevBtn
        '
        Me.prevBtn.Location = New System.Drawing.Point(366, 251)
        Me.prevBtn.Name = "prevBtn"
        Me.prevBtn.Size = New System.Drawing.Size(75, 23)
        Me.prevBtn.TabIndex = 3
        Me.prevBtn.Text = "Previous"
        Me.prevBtn.UseVisualStyleBackColor = True
        '
        'nextBtn
        '
        Me.nextBtn.Location = New System.Drawing.Point(510, 251)
        Me.nextBtn.Name = "nextBtn"
        Me.nextBtn.Size = New System.Drawing.Size(75, 23)
        Me.nextBtn.TabIndex = 4
        Me.nextBtn.Text = "Next"
        Me.nextBtn.UseVisualStyleBackColor = True
        '
        'allRdBtn
        '
        Me.allRdBtn.AutoSize = True
        Me.allRdBtn.Location = New System.Drawing.Point(426, 50)
        Me.allRdBtn.Name = "allRdBtn"
        Me.allRdBtn.Size = New System.Drawing.Size(70, 17)
        Me.allRdBtn.TabIndex = 5
        Me.allRdBtn.TabStop = True
        Me.allRdBtn.Text = "All Orders"
        Me.allRdBtn.UseVisualStyleBackColor = True
        '
        'ordEmpRdBtn
        '
        Me.ordEmpRdBtn.AutoSize = True
        Me.ordEmpRdBtn.Location = New System.Drawing.Point(426, 90)
        Me.ordEmpRdBtn.Name = "ordEmpRdBtn"
        Me.ordEmpRdBtn.Size = New System.Drawing.Size(119, 17)
        Me.ordEmpRdBtn.TabIndex = 6
        Me.ordEmpRdBtn.TabStop = True
        Me.ordEmpRdBtn.Text = "Orders by Employee"
        Me.ordEmpRdBtn.UseVisualStyleBackColor = True
        '
        'nameTxt
        '
        Me.nameTxt.Location = New System.Drawing.Point(465, 144)
        Me.nameTxt.Name = "nameTxt"
        Me.nameTxt.Size = New System.Drawing.Size(100, 20)
        Me.nameTxt.TabIndex = 7
        '
        'nameLbl
        '
        Me.nameLbl.AutoSize = True
        Me.nameLbl.Location = New System.Drawing.Point(375, 147)
        Me.nameLbl.Name = "nameLbl"
        Me.nameLbl.Size = New System.Drawing.Size(84, 13)
        Me.nameLbl.TabIndex = 8
        Me.nameLbl.Text = "Employee Name"
        '
        'idTxt
        '
        Me.idTxt.Location = New System.Drawing.Point(465, 187)
        Me.idTxt.Name = "idTxt"
        Me.idTxt.Size = New System.Drawing.Size(100, 20)
        Me.idTxt.TabIndex = 9
        '
        'idLbl
        '
        Me.idLbl.AutoSize = True
        Me.idLbl.Location = New System.Drawing.Point(392, 190)
        Me.idLbl.Name = "idLbl"
        Me.idLbl.Size = New System.Drawing.Size(67, 13)
        Me.idLbl.TabIndex = 10
        Me.idLbl.Text = "Employee ID"
        '
        'updOrdBtn
        '
        Me.updOrdBtn.Location = New System.Drawing.Point(47, 178)
        Me.updOrdBtn.Name = "updOrdBtn"
        Me.updOrdBtn.Size = New System.Drawing.Size(106, 23)
        Me.updOrdBtn.TabIndex = 11
        Me.updOrdBtn.Text = "Update Orders"
        Me.updOrdBtn.UseVisualStyleBackColor = True
        '
        'updDetBtn
        '
        Me.updDetBtn.Location = New System.Drawing.Point(47, 393)
        Me.updDetBtn.Name = "updDetBtn"
        Me.updDetBtn.Size = New System.Drawing.Size(106, 23)
        Me.updDetBtn.TabIndex = 12
        Me.updDetBtn.Text = "Update Details"
        Me.updDetBtn.UseVisualStyleBackColor = True
        '
        'EmployeesBindingSource
        '
        Me.EmployeesBindingSource.DataMember = "Employees"
        Me.EmployeesBindingSource.DataSource = Me.CompanyDataSet
        '
        'EmployeesTableAdapter
        '
        Me.EmployeesTableAdapter.ClearBeforeFill = True
        '
        'FormOrderClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 426)
        Me.ControlBox = False
        Me.Controls.Add(Me.updDetBtn)
        Me.Controls.Add(Me.updOrdBtn)
        Me.Controls.Add(Me.idLbl)
        Me.Controls.Add(Me.idTxt)
        Me.Controls.Add(Me.nameLbl)
        Me.Controls.Add(Me.nameTxt)
        Me.Controls.Add(Me.ordEmpRdBtn)
        Me.Controls.Add(Me.allRdBtn)
        Me.Controls.Add(Me.nextBtn)
        Me.Controls.Add(Me.prevBtn)
        Me.Controls.Add(Me.backBtn)
        Me.Controls.Add(Me.dgvDetail)
        Me.Controls.Add(Me.dgvOrder)
        Me.Name = "FormOrderClass"
        Me.Text = "Order"
        CType(Me.CompanyDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CompanyDataSet As Prog7GUI.CompanyDataSet
    Friend WithEvents OrderDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrderDetailsTableAdapter As Prog7GUI.CompanyDataSetTableAdapters.OrderDetailsTableAdapter
    Friend WithEvents TableAdapterManager As Prog7GUI.CompanyDataSetTableAdapters.TableAdapterManager
    Friend WithEvents OrdersTableAdapter As Prog7GUI.CompanyDataSetTableAdapters.OrdersTableAdapter
    Friend WithEvents OrdersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dgvOrder As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents backBtn As System.Windows.Forms.Button
    Friend WithEvents prevBtn As System.Windows.Forms.Button
    Friend WithEvents nextBtn As System.Windows.Forms.Button
    Friend WithEvents allRdBtn As System.Windows.Forms.RadioButton
    Friend WithEvents ordEmpRdBtn As System.Windows.Forms.RadioButton
    Friend WithEvents nameTxt As System.Windows.Forms.TextBox
    Friend WithEvents nameLbl As System.Windows.Forms.Label
    Friend WithEvents idTxt As System.Windows.Forms.TextBox
    Friend WithEvents idLbl As System.Windows.Forms.Label
    Friend WithEvents updOrdBtn As System.Windows.Forms.Button
    Friend WithEvents updDetBtn As System.Windows.Forms.Button
    Friend WithEvents EmployeesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeesTableAdapter As Prog7GUI.CompanyDataSetTableAdapters.EmployeesTableAdapter
End Class
