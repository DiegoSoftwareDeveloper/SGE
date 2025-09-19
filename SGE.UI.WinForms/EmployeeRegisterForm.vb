Imports SGE.Application.DTOs
Imports SGE.Application.Services

Public Class EmployeeRegisterForm
    Private ReadOnly _employeeService As IEmployeeService
    Private ReadOnly _employeeId As Integer?

    ' Constructor para crear
    Public Sub New(service As IEmployeeService)
        InitializeComponent()
        _employeeService = service
        _employeeId = Nothing
    End Sub

    ' Constructor para editar
    Public Sub New(service As IEmployeeService, employeeId As Integer)
        InitializeComponent()
        _employeeService = service
        _employeeId = employeeId
    End Sub

    Private Sub EmployeeRegisterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _employeeId.HasValue Then
            Dim emp As EmployeeDto = _employeeService.GetEmployeeById(_employeeId.Value)
            If emp IsNot Nothing Then
                txtFullName.Text = emp.FullName
                dtpHireDate.Value = emp.HireDate
                txtPosition.Text = emp.Position
                txtSalary.Text = emp.Salary.ToString()
                txtDepartment.Text = emp.Department
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If _employeeId.HasValue Then
                Dim emp As New EmployeeDto With {
                    .Id = _employeeId.Value,
                    .FullName = txtFullName.Text,
                    .HireDate = dtpHireDate.Value,
                    .Position = txtPosition.Text,
                    .Salary = Decimal.Parse(txtSalary.Text),
                    .Department = txtDepartment.Text
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
                    .Department = txtDepartment.Text
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
