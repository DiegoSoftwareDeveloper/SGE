Option Strict On
Option Explicit On

Imports SGE.Application.DTOs
Imports SGE.Domain.Entities
Imports SGE.Domain.Repositories

Namespace SGE.Application.Services
    Public Interface IEmployeeService
        Function GetAllEmployees() As IEnumerable(Of EmployeeDto)
        Function GetEmployeeById(id As Integer) As EmployeeDto
        Function SearchEmployeesByName(name As String) As IEnumerable(Of EmployeeDto)
        Sub CreateEmployee(employee As CreateEmployeeDto)
        Sub UpdateEmployee(employee As EmployeeDto)
        Sub DeleteEmployee(id As Integer)
    End Interface

    Public Class EmployeeService
        Implements IEmployeeService

        Private ReadOnly _repository As IEmployeeRepository

        Public Sub New(repository As IEmployeeRepository)
            _repository = repository
        End Sub

        Public Function GetAllEmployees() As IEnumerable(Of EmployeeDto) Implements IEmployeeService.GetAllEmployees
            Return _repository.GetAll().Select(Function(employee) MapToDto(employee)).ToList()
        End Function

        Public Function GetEmployeeById(id As Integer) As EmployeeDto Implements IEmployeeService.GetEmployeeById
            Dim employee = _repository.GetById(id)
            If employee Is Nothing Then Return Nothing
            Return MapToDto(employee)
        End Function

        Public Function SearchEmployeesByName(name As String) As IEnumerable(Of EmployeeDto) Implements IEmployeeService.SearchEmployeesByName
            Return _repository.FindByName(name).Select(Function(employee) MapToDto(employee)).ToList()
        End Function

        Public Sub CreateEmployee(employeeDto As CreateEmployeeDto) Implements IEmployeeService.CreateEmployee
            If String.IsNullOrWhiteSpace(employeeDto.FullName) Then
                Throw New ArgumentException("El nombre del empleado es obligatorio.")
            End If
            Dim employee = MapCreateDtoToEntity(employeeDto)
            _repository.Add(employee)
        End Sub

        Public Sub UpdateEmployee(employeeDto As EmployeeDto) Implements IEmployeeService.UpdateEmployee
            Dim employee = MapDtoToEntity(employeeDto)
            _repository.Update(employee)
        End Sub

        Public Sub DeleteEmployee(id As Integer) Implements IEmployeeService.DeleteEmployee
            _repository.Delete(id)
        End Sub

        Private Function MapToDto(employee As Employee) As EmployeeDto
            Return New EmployeeDto With {
                .Id = employee.Id,
                .FullName = employee.FullName,
                .HireDate = employee.HireDate,
                .Position = employee.Position,
                .Salary = employee.Salary,
                .Department = employee.Department
            }
        End Function

        Private Function MapCreateDtoToEntity(dto As CreateEmployeeDto) As Employee
            Return New Employee With {
                .FullName = dto.FullName,
                .HireDate = dto.HireDate,
                .Position = dto.Position,
                .Salary = dto.Salary,
                .Department = dto.Department
            }
        End Function

        Private Function MapDtoToEntity(dto As EmployeeDto) As Employee
            Return New Employee With {
                .Id = dto.Id,
                .FullName = dto.FullName,
                .HireDate = dto.HireDate,
                .Position = dto.Position,
                .Salary = dto.Salary,
                .Department = dto.Department
            }
            End Function
    End Class
End Namespace
