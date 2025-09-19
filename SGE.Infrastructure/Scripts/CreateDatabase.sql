CREATE DATABASE SGEDb;
GO

USE SGEDb;
GO

CREATE TABLE Employees (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    HireDate DATE NOT NULL,
    Position NVARCHAR(50) NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    Department NVARCHAR(50) NOT NULL
);
GO

INSERT INTO Employees (FullName, HireDate, Position, Salary, Department)
VALUES 
('Daniel', '2020-01-15', 'Desarrollador', 3000.00, 'IT'),
('Diego', '2019-03-20', 'Analista', 3500.00, 'Financiera'),
('Jaime', '2021-05-10', 'Diseñador', 2800.00, 'Marketing');
GO