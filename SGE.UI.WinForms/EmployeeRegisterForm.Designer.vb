<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeRegisterForm
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
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.txtPosition = New System.Windows.Forms.TextBox()
        Me.txtSalary = New System.Windows.Forms.TextBox()
        Me.dtpHireDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbDepartment = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(312, 96)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(206, 22)
        Me.txtFullName.TabIndex = 0
        '
        'txtPosition
        '
        Me.txtPosition.Location = New System.Drawing.Point(312, 140)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Size = New System.Drawing.Size(206, 22)
        Me.txtPosition.TabIndex = 1
        '
        'txtSalary
        '
        Me.txtSalary.Location = New System.Drawing.Point(312, 185)
        Me.txtSalary.Name = "txtSalary"
        Me.txtSalary.Size = New System.Drawing.Size(206, 22)
        Me.txtSalary.TabIndex = 2
        '
        'dtpHireDate
        '
        Me.dtpHireDate.Location = New System.Drawing.Point(312, 270)
        Me.dtpHireDate.Name = "dtpHireDate"
        Me.dtpHireDate.Size = New System.Drawing.Size(200, 22)
        Me.dtpHireDate.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift SemiBold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(307, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 28)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Registrar Empleado"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(110, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 21)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre Completo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(110, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 21)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cargo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(110, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 21)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Salario"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(110, 229)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 21)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Departamento"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Bahnschrift SemiCondensed", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(110, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(157, 21)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Fecha de Contratación"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSave.Font = New System.Drawing.Font("Bahnschrift Condensed", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave.Location = New System.Drawing.Point(312, 321)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(206, 33)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Registrar"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'cbDepartment
        '
        Me.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepartment.FormattingEnabled = True
        Me.cbDepartment.Location = New System.Drawing.Point(312, 226)
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.Size = New System.Drawing.Size(206, 24)
        Me.cbDepartment.TabIndex = 12
        '
        'EmployeeRegisterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cbDepartment)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpHireDate)
        Me.Controls.Add(Me.txtSalary)
        Me.Controls.Add(Me.txtPosition)
        Me.Controls.Add(Me.txtFullName)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name = "EmployeeRegisterForm"
        Me.Text = "EmployeeRegisterForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFullName As TextBox
    Friend WithEvents txtPosition As TextBox
    Friend WithEvents txtSalary As TextBox
    Friend WithEvents dtpHireDate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents cbDepartment As ComboBox
End Class
