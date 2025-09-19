Option Strict On
Option Explicit On

Namespace SGE.Domain.Entities
    Public Class Employee
        Public Property Id As Integer
        Public Property FullName As String
        Public Property HireDate As DateTime
        Public Property Position As String
        Public Property Salary As Decimal
        Public Property Department As String

        ' Constructor
        Public Sub New()
            ' Constructor vacío para Entity Framework
        End Sub
        Public Sub New(fullName As String, hireDate As DateTime, position As String, salary As Decimal, department As String)
            Me.FullName = fullName
            Me.HireDate = hireDate
            Me.Position = position
            Me.Salary = salary
            Me.Department = department
        End Sub

        ' Validaciones de negocio (DDD)
        Public Sub UpdateSalary(newSalary As Decimal)
            If newSalary <= 0D Then
                Throw New ArgumentException("El salario debe ser mayor a cero.")
            End If
            Salary = newSalary
        End Sub
    End Class
End Namespace
