Option Strict On
Option Explicit On

Imports Autofac
Imports System.Data.Entity
Imports SGE.Infrastructure.Data
Imports WinFormsApp = System.Windows.Forms.Application
Imports InfrastructureDI = SGE.Infrastructure.IoC.DependencyInjection
Imports ApplicationDI = SGE.Application.IoC.DependencyInjection

Module Program

    <STAThread>
    Sub Main()

        ' Configuración de Windows Forms
        WinFormsApp.EnableVisualStyles()
        WinFormsApp.SetCompatibleTextRenderingDefault(False)

        ' Inicializar base de datos (EF6)
        Database.SetInitializer(Of SgeDbContext)(New CreateDatabaseIfNotExists(Of SgeDbContext)())
        Using tmp = New SgeDbContext()
            tmp.Database.Initialize(False)
        End Using

        ' Configuración del contenedor Autofac
        Dim builder As New ContainerBuilder()

        ' Registrar dependencias de Infrastructure (repositorios + DbContext)
        InfrastructureDI.Register(builder)

        ' Registrar dependencias de Application (servicios)
        ApplicationDI.Register(builder)

        ' Registrar dependencias de UI (formularios)
        builder.RegisterType(Of MainForm)().
            AsSelf().
            InstancePerDependency()

        ' Construcción del contenedor
        Dim container = builder.Build()

        ' Ejecutar aplicación resolviendo MainForm desde el contenedor
        Using scope = container.BeginLifetimeScope()
            Dim mainForm = scope.Resolve(Of MainForm)()
            WinFormsApp.Run(mainForm)
        End Using
    End Sub

End Module
