# Proyecto: Colegio San José

**Materia:** Desarrollo de Aplicaciones con Software Propietario  
**Tecnología:** ASP.NET Core MVC con Entity Framework Core  
**Desarrollado por:** *Tania Merino*  
**Año:** 2025  
**Universidad Don Bosco**

---

##  Descripción general
El sistema **Colegio San José** es una aplicación web desarrollada en **ASP.NET Core MVC** que permite administrar la información de un colegio mediante tres entidades principales: **Alumnos**, **Materias** y **Expedientes**.

El sistema ofrece operaciones **CRUD completas** (crear, leer, actualizar y eliminar) y un módulo de **reportes** con gráficas estadísticas para visualizar los promedios por alumno.

---

## Entidades principales

### Alumnos
Permite registrar y gestionar la información de los estudiantes (nombre, apellido, fecha de nacimiento, grado).

### Materias
Administra las asignaturas que imparte el colegio y los docentes responsables.

### Expedientes
Registra las notas finales y observaciones por cada alumno en una materia específica.

---

## Reportes
Incluye un apartado visual que muestra:
- Tabla de promedios por alumno.
- **Gráfica estadística** desarrollada con **Chart.js**, representando los resultados promedio de cada estudiante.

---

## Tecnologías utilizadas
- **ASP.NET Core MVC (.NET 8)**
- **Entity Framework Core**
- **Microsoft SQL Server**
- **Bootstrap 5**
- **Chart.js**
- **Visual Studio 2022**

---

## Funcionalidades
- CRUD completo para las tres entidades (Alumnos, Materias, Expedientes).  
- Reporte de promedios con visualización gráfica.  
- Validaciones de datos y diseño responsive con Bootstrap.  
- Integración con **SQL Server** mediante **Entity Framework Core**.

---

## Estructura del proyecto
# ColegioSJ

ColegioSJ/
├── Controllers/
├── Models/
├── Views/
├── Data/
├── Migrations/
├── wwwroot/
└── Program.cs
