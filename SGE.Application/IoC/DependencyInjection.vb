Imports Autofac
Imports SGE.Application.Services

Namespace SGE.Application.IoC
    Public Class DependencyInjection
        Public Shared Sub Register(builder As ContainerBuilder)
            builder.RegisterType(Of EmployeeService)().
                As(Of IEmployeeService)().
                InstancePerDependency()
        End Sub
    End Class
End Namespace
