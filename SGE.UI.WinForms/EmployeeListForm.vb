Imports SGE.Application.Services
Imports SGE.Application.DTOs

Public Class EmployeeListForm
    Private ReadOnly _employeeService As IEmployeeService

    Public Sub New(service As IEmployeeService)
        InitializeComponent()
        _employeeService = service
    End Sub

    ' Cargar empleados al abrir
    Private Sub EmployeeListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployees()
    End Sub

    Private Sub LoadEmployees(Optional filter As String = "")
        Dim employees As IEnumerable(Of EmployeeDto)
        If String.IsNullOrWhiteSpace(filter) Then
            employees = _employeeService.GetAllEmployees()
        Else
            Dim id As Integer
            If Integer.TryParse(filter, id) Then
                Dim emp As EmployeeDto = _employeeService.GetEmployeeById(id)
                If emp IsNot Nothing Then
                    employees = New List(Of EmployeeDto) From {emp}
                Else
                    employees = New List(Of EmployeeDto)() ' vacío si no encuentra
                End If
            Else
                employees = _employeeService.SearchEmployeesByName(filter)
            End If
        End If

        dgvEmployees.DataSource = employees.ToList()
    End Sub

    ' Buscar por nombre
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadEmployees(txtSearch.Text)
    End Sub

    ' Nuevo empleado
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim regForm As New EmployeeRegisterForm(_employeeService)
        regForm.ShowDialog()
        LoadEmployees()
    End Sub

    ' Editar empleado (doble clic en fila)
    Private Sub dgvEmployees_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployees.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim selected As EmployeeDto = CType(dgvEmployees.Rows(e.RowIndex).DataBoundItem, EmployeeDto)
            Dim regForm As New EmployeeRegisterForm(_employeeService, selected.Id)
            regForm.ShowDialog()
            LoadEmployees()
        End If
    End Sub

    ' Eliminar empleado
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvEmployees.SelectedRows.Count > 0 Then
            Dim selected As EmployeeDto = CType(dgvEmployees.SelectedRows(0).DataBoundItem, EmployeeDto)
            If MessageBox.Show($"¿Eliminar empleado {selected.FullName}?", "Confirmar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                _employeeService.DeleteEmployee(selected.Id)
                LoadEmployees()
            End If
        End If
    End Sub
End Class
