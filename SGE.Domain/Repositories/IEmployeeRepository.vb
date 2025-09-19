Option Strict On
Option Explicit On

Imports SGE.Domain.Entities

Namespace SGE.Domain.Repositories
    Public Interface IEmployeeRepository
        Function GetAll() As IEnumerable(Of Employee)
        Function GetById(id As Integer) As Employee
        Function FindByName(name As String) As IEnumerable(Of Employee)
        Sub Add(employee As Employee)
        Sub Update(employee As Employee)
        Sub Delete(id As Integer)
    End Interface
End Namespace
