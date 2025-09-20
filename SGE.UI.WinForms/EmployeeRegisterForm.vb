Imports SGE.Application.DTOs
Imports SGE.Application.Services
Imports SGE.Application.Helpers

Public Class EmployeeRegisterForm
    Private ReadOnly _employeeService As IEmployeeService
    Private ReadOnly _employeeId As Integer?

    ' Constructor para crear
    Public Sub New(service As IEmployeeService)
        InitializeComponent()
        _employeeService = service
        _employeeId = Nothing
        LoadDepartments()
    End Sub

    ' Constructor para editar
    Public Sub New(service As IEmployeeService, employeeId As Integer)
        InitializeComponent()
        _employeeService = service
        _employeeId = employeeId
        LoadDepartments()
    End Sub


    Private Sub LoadDepartments()
        Dim departments = DepartmentHelper.GetAllDepartments()

        cbDepartment.DataSource = departments
        cbDepartment.DropDownStyle = ComboBoxStyle.DropDownList

        ' Si está en modo edición, seleccionar el departamento del empleado
        If _employeeId.HasValue Then
            Dim emp As EmployeeDto = _employeeService.GetEmployeeById(_employeeId.Value)
            If emp IsNot Nothing AndAlso departments.Contains(emp.Department) Then
                cbDepartment.SelectedItem = emp.Department
            ElseIf departments.Count > 0 Then
                cbDepartment.SelectedIndex = 0
            End If
        Else
            ' Si es nuevo, seleccionar el primero
            If departments.Count > 0 Then
                cbDepartment.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub EmployeeRegisterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _employeeId.HasValue Then
            Dim emp As EmployeeDto = _employeeService.GetEmployeeById(_employeeId.Value)
            If emp IsNot Nothing Then
                txtFullName.Text = emp.FullName
                dtpHireDate.Value = emp.HireDate
                txtPosition.Text = emp.Position
                txtSalary.Text = emp.Salary.ToString()
                If cbDepartment.Items.Contains(emp.Department) Then
                    cbDepartment.SelectedItem = emp.Department
                Else
                    cbDepartment.SelectedIndex = 0
                End If
            End If
        Else
            If cbDepartment.Items.Count > 0 Then
                cbDepartment.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If cbDepartment.SelectedItem Is Nothing Then
                MessageBox.Show("Por favor seleccione un departamento.")
                Return
            End If

            Dim selectedDepartment = cbDepartment.SelectedItem.ToString()
            If Not DepartmentHelper.IsValidDepartment(selectedDepartment) Then
                MessageBox.Show("Por favor seleccione un departamento válido.")
                Return
            End If

            If _employeeId.HasValue Then
                Dim emp As New EmployeeDto With {
                    .Id = _employeeId.Value,
                    .FullName = txtFullName.Text,
                    .HireDate = dtpHireDate.Value,
                    .Position = txtPosition.Text,
                    .Salary = Decimal.Parse(txtSalary.Text),
                    .Department = selectedDepartment
                }
                ' Editar
                _employeeService.UpdateEmployee(emp)
                MessageBox.Show("Empleado actualizado correctamente.")
            Else
                Dim newEmp As New CreateEmployeeDto With {
                    .FullName = txtFullName.Text,
                    .HireDate = dtpHireDate.Value,
                    .Position = txtPosition.Text,
                    .Salary = Decimal.Parse(txtSalary.Text),
                    .Department = selectedDepartment
                }
                ' Nuevo
                _employeeService.CreateEmployee(newEmp)
                MessageBox.Show("Empleado creado correctamente.")
            End If

            Me.Close()
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}")
        End Try
    End Sub
End Class
