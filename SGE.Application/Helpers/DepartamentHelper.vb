Namespace SGE.Application.Helpers
    Public Class DepartmentHelper
        Public Shared Function GetAllDepartments() As List(Of String)
            Return New List(Of String) From {
                "Recursos Humanos",
                "Tecnología",
                "Contabilidad",
                "Ventas",
                "Marketing",
                "Operaciones",
                "Logística",
                "Calidad",
                "Administración",
                "Producción"
            }
        End Function

        Public Shared Function IsValidDepartment(department As String) As Boolean
            Dim departments = GetAllDepartments()
            Return departments.Contains(department)
        End Function
    End Class
End Namespace