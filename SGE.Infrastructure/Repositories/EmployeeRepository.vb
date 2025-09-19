Option Strict On
Option Explicit On

Imports SGE.Domain.Entities
Imports SGE.Domain.Repositories
Imports SGE.Infrastructure.Data

Namespace SGE.Infrastructure.Repositories
    Public Class EmployeeRepository
        Implements IEmployeeRepository

        Private ReadOnly _context As SgeDbContext

        Public Sub New(context As SgeDbContext)
            _context = context
        End Sub

        Public Function GetAll() As IEnumerable(Of Employee) Implements IEmployeeRepository.GetAll
            Return _context.Employees.ToList()
        End Function

        Public Function GetById(id As Integer) As Employee Implements IEmployeeRepository.GetById
            Return _context.Employees.Find(id)
        End Function

        Public Function FindByName(name As String) As IEnumerable(Of Employee) Implements IEmployeeRepository.FindByName
            Return _context.Employees.
                Where(Function(e) e.FullName.Contains(name)).
                ToList()
        End Function

        Public Sub Add(employee As Employee) Implements IEmployeeRepository.Add
            _context.Employees.Add(employee)
            _context.SaveChanges()
        End Sub

        Public Sub Update(employee As Employee) Implements IEmployeeRepository.Update
            Dim existing = _context.Employees.Find(employee.Id)
            If existing Is Nothing Then
                Throw New KeyNotFoundException($"Empleado con Id {employee.Id} no encontrado.")
            End If

            existing.FullName = employee.FullName
            existing.HireDate = employee.HireDate
            existing.Position = employee.Position
            existing.Salary = employee.Salary
            existing.Department = employee.Department

            _context.SaveChanges()
        End Sub

        Public Sub Delete(id As Integer) Implements IEmployeeRepository.Delete
            Dim existing = _context.Employees.Find(id)
            If existing Is Nothing Then
                Throw New KeyNotFoundException($"Empleado con Id {id} no encontrado.")
            End If

            _context.Employees.Remove(existing)
            _context.SaveChanges()
        End Sub
    End Class
End Namespace
