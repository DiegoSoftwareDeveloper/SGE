# 🧑‍💼 Sistema de Gestión de Empleados (SGE)

Aplicación de escritorio para la gestión centralizada de empleados.
Permite registrar, consultar, actualizar y eliminar empleados de una empresa, además de realizar búsquedas por nombre o por ID.

Está diseñada con un enfoque modular y escalable, aplicando una Arquitectura en Capas con separación de concerns e Inversión de Dependencias, lo que facilita la extensibilidad y el mantenimiento a largo plazo.

---

## 🧱 Arquitectura y Tecnologias

- **Lenguaje:** VB.NET

- **Framework:** .NET Framework 4.8

- **Interfaz:** Windows Forms (WinForms)

- **Base de datos:** SQL Server (compatible con LocalDB, Express y versiones superiores)

- **ORM:** Entity Framework 6 (Code First)

- **Patrón Arquitectónico:** Arquitectura en Capas con Inversión de Dependencias (DI/IoC)

- **Contenedor de IoC:** AutoFac

- **Capas:**
    - **Dominio:** Entidades y contratos (Employee, IEmployeeRepository)

    - **Aplicación:** Servicios, DTOs y contratos de aplicación (EmployeeService, IEmployeeService, EmployeeDto, CreateEmployeeDto)

    - **Infraestructura:** Persistencia con Entity Framework (EmployeeRepository, SgeDbContext)

    - **Presentación:** Formularios WinForms (EmployeeListForm, EmployeeRegisterForm)

**Flujo de Dependencias:**
La Presentación depende de la Aplicación. La Aplicación y la Infraestructura dependen del Dominio. Las dependencias nunca apuntan hacia arriba (ej: el Dominio nunca depende de la Infraestructura). El contenedor de IoC se encarga de resolver estas dependencias en tiempo de ejecución, inyectando las implementaciones concretas (de Infraestructura) donde se requieren las abstracciones (definidas en el Dominio y la Aplicación).

👉 Este diseño separa responsabilidades, lo que permite reemplazar la capa de infraestructura (ej. cambiar SQL Server por MySQL o EF Core) sin afectar la lógica de negocio ni la UI.


---

## 📦 Estructura del Proyecto

```bash
SGE/
├── SGE.Application             # Lógica de aplicación (Capa de Casos de Uso)
│   ├── Dtos/                   # Objetos de Transferencia de Datos (Data Transfer Objects)
│   │   ├── CreateEmployeeDto.vb 
│   │   └── EmployeeDto.vb       
│   ├── IoC/
│   │   └── DependencyInjection.vb  ' Registro de servicios de aplicación (Interfaces de Servicios)
│   └── Services/
│       └── EmployeeService.vb      ' Implementación de los casos de uso (usa IRepository)
│
├── SGE.Domain                  # Núcleo de negocio (DDD) - Libre de dependencias externas
│   ├── Entities/
│   │   └── Employee.vb            ' Entidad de dominio
│   └── Repositories/
│       └── IEmployeeRepository.vb  ' Contrato del repositorio (Persistencia Agnóstica)
│
├── SGE.Infrastructure          # Capa de Infraestructura (Implementaciones concretas)
│   ├── Data/
│   │   └── SgeDbContext.vb         ' Contexto de Entity Framework 6 (Code First)
│   ├── IoC/
│   │   └── DependencyInjection.vb  ' Registro de implementaciones concretas
│   ├── Repositories/
│       └── EmployeeRepository.vb   ' Implementación concreta de IEmployeeRepository usando EF
│   └── Scripts/
│       └── CreateDatabase.sql      ' Script DDL
│
└── SGE.UI.WinForms             # Capa de presentación (Frontend)
    ├── EmployeeListForm.vb     
    ├── EmployeeRegisterForm.vb
    ├── MainForm.vb
    ├── Program.vb              ' Punto de entrada - Configura la inyección de dependencias
    └── App.config              ' Configuración y cadena de conexión
```
---

## 🧪 Migracion de base de datos

El proyecto utiliza Entity Framework 6 Code First. La base de datos se genera automáticamente al ejecutar la aplicación por primera vez, basándose en la configuración del SgeDbContext y la cadena de conexión.

Script para crear la tabla principal en SQL Server:

```bash
├── SGE.Infrastructure
│   └── Scripts/
│       └── CreateDatabase.sql
```

**Nota:** El script **CreateDatabase.sql** en la carpeta **Scripts/** es opcional y está disponible para migraciones manuales o como referencia del esquema.

---

## 🚀 Requisitos Previos

Antes de ejecutar el proyecto, aseguresse de tener instalado:

- Visual Studio 2019 o 2022 (con la carga de trabajo ".NET Desktop Development").

- .NET Framework 4.8 Developer Pack.

- SQL Server (cualquiera de las siguientes opciones):

- SQL Server LocalDB (viene incluido con Visual Studio)

- SQL Server Express o superior

- (Opcional) SQL Server Management Studio (SSMS).
---

## 🧰 Pasos para correr el proyecto localmente
1. **Clonar el repositorio**

``` bash
git clone https://github.com/DiegoSoftwareDeveloper/SGE
cd SGE
```

2. **Abrir la solución**

Abrir el archivo SGE.sln.

3. **Compilar la solución**
Visual Studio restaurará automáticamente los paquetes NuGet (Entity Framework, etc.). O puede presionar Ctrl + Shift + B para compilar.

4. **(Opcional) Verificar la cadena de conexión**
El proyecto está configurado para usar SQL Server LocalDB por defecto. Puede verificar o modificar la cadena de conexión en el archivo **App.config** del proyecto **SGE.UI.WinForms**.

5. **Ejecutar la aplicación**
Presione F5 en Visual Studio. Entity Framework creará automáticamente la base de datos SgeDb en tu instancia de LocalDB la primera vez que la aplicación se ejecute.

## Autor

Diego Alejandro Barreto Lopez

[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/diego-alejandro-barreto-l%C3%B3pez-4430b6185/)
