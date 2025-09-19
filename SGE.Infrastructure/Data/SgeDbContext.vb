Option Strict On
Option Explicit On

Imports System.Data.Entity
Imports SGE.Domain.Entities

Namespace SGE.Infrastructure.Data
    Public Class SgeDbContext
        Inherits DbContext

        Public Sub New()
            ' El nombre "SgeDbConnection" debe coincidir con la cadena en App.config
            MyBase.New("name=SgeDbConnection")
        End Sub

        ' DbSet que representa la tabla Employees
        Public Property Employees As DbSet(Of Employee)

        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            MyBase.OnModelCreating(modelBuilder)

            ' Configuración Fluent API (opcional)
            modelBuilder.Entity(Of Employee)() _
                .ToTable("Employees") _
                .HasKey(Function(e) e.Id)

            modelBuilder.Entity(Of Employee)() _
                .Property(Function(e) e.FullName) _
                .IsRequired() _
                .HasMaxLength(200)

            modelBuilder.Entity(Of Employee)() _
                .Property(Function(e) e.Position) _
                .IsRequired() _
                .HasMaxLength(100)

            modelBuilder.Entity(Of Employee)() _
                .Property(Function(e) e.Department) _
                .IsRequired() _
                .HasMaxLength(100)
        End Sub
    End Class
End Namespace
