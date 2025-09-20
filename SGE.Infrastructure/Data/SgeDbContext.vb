Option Strict On
Option Explicit On

Imports System.Data.Entity
Imports SGE.Domain.Entities

Namespace SGE.Infrastructure.Data
    Public Class SgeDbContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("name=SgeDbConnection")
        End Sub

        Public Property Employees As DbSet(Of Employee)

        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            MyBase.OnModelCreating(modelBuilder)

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
