Imports SGE.Application.Services

Public Class MainForm
    Private ReadOnly _employeeService As IEmployeeService

    ' Constructor para DI
    Public Sub New(employeeService As IEmployeeService)
        InitializeComponent()
        _employeeService = employeeService
    End Sub

    ' Botón para ir al listado de empleados
    Private Sub btnEmployees_Click(sender As Object, e As EventArgs) Handles btnEmployees.Click
        Dim listForm As New EmployeeListForm(_employeeService)
        listForm.ShowDialog()
    End Sub
End Class
