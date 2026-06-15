# Proyecto CRUD de Pacientes utilizando LINQ y Arquitectura de 4 Capas

## Introducción

Este proyecto forma parte de los ejemplos prácticos desarrollados para el Manual de LINQ en C#. Su propósito es demostrar la aplicación real de LINQ to SQL dentro de una arquitectura de 4 capas, permitiendo realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) sobre una base de datos de pacientes.

A través de este ejemplo se puede observar cómo LINQ facilita el acceso y manipulación de datos mediante consultas integradas en el lenguaje C#, mejorando la legibilidad, mantenibilidad y productividad del código.

---

## Descripción General

El sistema permite administrar información de pacientes mediante una interfaz gráfica desarrollada en Windows Forms.

Las operaciones disponibles son:

- Registrar pacientes.
- Consultar pacientes.
- Actualizar información de pacientes.
- Eliminar pacientes.
- Gestionar géneros mediante listas desplegables.
- Visualizar registros mediante DataGridView.

Todas las operaciones sobre la base de datos son realizadas utilizando LINQ to SQL.

---

# Arquitectura del Proyecto

El proyecto está organizado siguiendo el modelo de arquitectura de 4 capas.

## 1. Capa de Entidades

Contiene las clases que representan la estructura de los datos utilizados dentro de la aplicación.

### GeneroEntidades

Representa la información de los géneros registrados en la base de datos.

Propiedades principales:

- Id
- Nombre

### PacienteEntidades

Representa la información completa de un paciente.

Propiedades principales:

- Id
- Id_Genero
- Genero
- Nombre
- Apellido
- Cedula
- FechaNacimiento
- Telefono
- Direccion
- Afiliado
- CodigoIESS

---

## 2. Capa de Datos

Es la encargada de comunicarse directamente con la base de datos utilizando LINQ to SQL.

### GeneroDatos

Funciones principales:

- Obtener todos los géneros registrados.
- Buscar un género por identificador.

Consulta LINQ utilizada:

```csharp
var resultado =
    from g in contexto.Genero
    select g;
```

### PacienteDatos

Implementa las operaciones CRUD de pacientes.

### Crear Paciente

```csharp
contexto.Paciente.InsertOnSubmit(pacienteLinQ);
contexto.SubmitChanges();
```

Inserta un nuevo registro dentro de la tabla Paciente.

### Consultar Pacientes

```csharp
var resultado =
    from p in contexto.Paciente
    select p;
```

Obtiene todos los pacientes almacenados en la base de datos.

### Buscar Paciente por ID

```csharp
Paciente pacienteLinQ =
    contexto.Paciente
            .FirstOrDefault(p => p.id == id);
```

Obtiene un paciente específico utilizando su identificador.

### Actualizar Paciente

```csharp
contexto.SubmitChanges();
```

Guarda los cambios realizados sobre un registro existente.

### Eliminar Paciente

```csharp
contexto.Paciente.DeleteOnSubmit(pacienteLinQ);
contexto.SubmitChanges();
```

Elimina un registro de la base de datos.

---

## 3. Capa de Negocio

Actúa como intermediario entre la capa de presentación y la capa de datos.

Su función principal es coordinar los procesos de la aplicación y centralizar las reglas de negocio.

### GeneroNegocio

Permite recuperar la lista de géneros disponibles para ser mostrados en la interfaz gráfica.

### PacienteNegocio

Gestiona las operaciones relacionadas con los pacientes:

- Guardar
- Consultar
- Actualizar
- Eliminar

Además, determina automáticamente si un registro debe ser insertado o actualizado dependiendo del valor del identificador.

---

## 4. Capa de Presentación

Implementada mediante Windows Forms.

Es la capa encargada de interactuar directamente con el usuario.

### Form_Paciente

Permite:

- Registrar pacientes.
- Consultar pacientes.
- Actualizar información.
- Eliminar registros.
- Seleccionar géneros desde un ComboBox.
- Visualizar información mediante DataGridView.

### Métodos principales

#### CargarComboGenero()

Carga los géneros desde la base de datos y los muestra en el ComboBox.

#### CargarListadoPacienteEnDataGridView()

Obtiene todos los pacientes registrados y los muestra en el DataGridView.

#### GuardarPaciente()

Recopila la información ingresada por el usuario y la envía a la capa de negocio para su almacenamiento.

#### EliminarPaciente()

Elimina un paciente seleccionado previa confirmación del usuario.

#### CargarValoresPacientePorId()

Carga los datos de un paciente seleccionado para permitir su edición.

---

# Consultas LINQ Utilizadas

Durante el desarrollo del proyecto se emplearon diversas consultas LINQ.

## Consulta de selección

```csharp
var resultado =
    from p in contexto.Paciente
    select p;
```

Obtiene todos los registros de una tabla.

## Consulta con filtro

```csharp
Paciente pacienteLinQ =
    contexto.Paciente
            .FirstOrDefault(p => p.id == id);
```

Obtiene el primer registro que cumpla una condición específica.

## Inserción de registros

```csharp
contexto.Paciente.InsertOnSubmit(pacienteLinQ);
contexto.SubmitChanges();
```

Agrega un nuevo registro a la base de datos.

## Actualización de registros

```csharp
contexto.SubmitChanges();
```

Guarda las modificaciones realizadas sobre una entidad.

## Eliminación de registros

```csharp
contexto.Paciente.DeleteOnSubmit(pacienteLinQ);
contexto.SubmitChanges();
```

Elimina un registro de la base de datos.

---

# Tecnologías Utilizadas

- C#
- Windows Forms
- LINQ
- LINQ to SQL
- SQL Server
- Arquitectura de 4 Capas
- Visual Studio

---

# Objetivo Académico

Este proyecto fue desarrollado como ejemplo práctico para demostrar la implementación de LINQ dentro de una aplicación empresarial organizada mediante arquitectura de 4 capas.

A través de este ejemplo se evidencia cómo LINQ permite realizar consultas, inserciones, actualizaciones y eliminaciones de registros de manera eficiente, utilizando una sintaxis integrada dentro del lenguaje C#.

---

# Relación con el Manual

Dentro de este proyecto se aplican los principales conceptos estudiados en el Manual de LINQ:

- LINQ to SQL
- Query Syntax
- Expresiones Lambda
- Método FirstOrDefault()
- Operaciones CRUD
- Arquitectura de 4 Capas
- DataContext
- Entidades
- Acceso a Bases de Datos
- Consultas Integradas en C#

Este proyecto constituye una aplicación práctica de los conceptos teóricos desarrollados en la documentación principal del repositorio.
