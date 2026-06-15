# Proyecto CRUD de Pacientes utilizando LINQ y Arquitectura de 4 Capas

## Descripción General

Este proyecto implementa un sistema de gestión de pacientes utilizando C#, Windows Forms y LINQ to SQL. El objetivo principal es demostrar la aplicación de consultas LINQ dentro de una arquitectura de 4 capas para realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) sobre una base de datos.

---

## Arquitectura del Proyecto

### Capa de Entidades

Contiene las clases que representan la estructura de los datos utilizados por el sistema.

#### GeneroEntidades

Representa la información de los géneros registrados en la base de datos.

Propiedades principales:

* Id
* Nombre

#### PacienteEntidades

Representa la información completa de un paciente.

Propiedades principales:

* Id
* Id_Genero
* Nombre
* Apellido
* Cedula
* FechaNacimiento
* Telefono
* Direccion
* Afiliado
* CodigoIESS

---

### Capa de Datos

Encargada del acceso a la base de datos mediante LINQ to SQL.

#### GeneroDatos

Funciones principales:

* Obtener todos los géneros registrados.
* Buscar un género por identificador.

Consulta LINQ utilizada:

```csharp
var resultado =
    from g in contexto.Genero
    select g;
```

#### PacienteDatos

Implementa las operaciones CRUD de pacientes.

##### Crear Paciente

```csharp
contexto.Paciente.InsertOnSubmit(pacienteLinQ);
contexto.SubmitChanges();
```

##### Consultar Pacientes

```csharp
var resultado =
    from p in contexto.Paciente
    select p;
```

##### Buscar Paciente por ID

```csharp
Paciente pacienteLinQ =
    contexto.Paciente
            .FirstOrDefault(p => p.id == id);
```

##### Actualizar Paciente

```csharp
contexto.SubmitChanges();
```

##### Eliminar Paciente

```csharp
contexto.Paciente.DeleteOnSubmit(pacienteLinQ);
contexto.SubmitChanges();
```

---

### Capa de Negocio

Actúa como intermediario entre la presentación y la capa de datos.

#### GeneroNegocio

Permite recuperar la lista de géneros disponibles.

#### PacienteNegocio

Gestiona las operaciones relacionadas con los pacientes:

* Guardar
* Consultar
* Actualizar
* Eliminar

Además, determina automáticamente si se debe crear o actualizar un paciente según el valor del identificador.

---

### Capa de Presentación

Implementada mediante Windows Forms.

#### Form_Paciente

Permite al usuario:

* Registrar pacientes.
* Consultar pacientes.
* Actualizar información.
* Eliminar registros.
* Seleccionar géneros desde un ComboBox.
* Visualizar información mediante DataGridView.

Funciones principales:

##### CargarComboGenero()

Carga los géneros desde la base de datos al ComboBox.

##### CargarListadoPacienteEnDataGridView()

Obtiene la lista de pacientes y la muestra en el DataGridView.

##### GuardarPaciente()

Recopila la información ingresada por el usuario y la envía a la capa de negocio para su almacenamiento.

##### EliminarPaciente()

Elimina un paciente seleccionado después de la confirmación del usuario.

##### CargarValoresPacientePorId()

Carga la información de un paciente seleccionado para su edición.

---

## Tecnologías Utilizadas

* C#
* Windows Forms
* LINQ
* LINQ to SQL
* SQL Server
* Arquitectura de 4 Capas

---

## Objetivo Académico

Este proyecto fue desarrollado como ejemplo práctico para demostrar el uso de LINQ en aplicaciones empresariales organizadas mediante arquitectura de 4 capas, aplicando consultas, inserciones, actualizaciones y eliminaciones de registros dentro de una base de datos relacional.
