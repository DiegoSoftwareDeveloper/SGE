Imports Autofac
Imports SGE.Domain.Repositories
Imports SGE.Infrastructure.Data
Imports SGE.Infrastructure.Repositories

Namespace SGE.Infrastructure.IoC
    Public Class DependencyInjection
        Public Shared Sub Register(builder As ContainerBuilder)
            ' DbContext
            builder.RegisterType(Of SgeDbContext)().
                AsSelf().
                InstancePerLifetimeScope()

            ' Repositorios
            builder.RegisterType(Of EmployeeRepository)().
                As(Of IEmployeeRepository)().
                InstancePerDependency()
        End Sub
    End Class
End Namespace
