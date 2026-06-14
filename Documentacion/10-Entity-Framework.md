# 10. LINQ y Entity Framework

## Introducción

Entity Framework (EF) es una tecnología de acceso a datos desarrollada por Microsoft que permite trabajar con bases de datos utilizando objetos de C# en lugar de escribir grandes cantidades de código SQL. Esta herramienta forma parte del ecosistema .NET y se ha convertido en una de las soluciones más utilizadas para la persistencia de datos en aplicaciones empresariales.

Antes de la aparición de los ORM (Object Relational Mapping), los desarrolladores debían crear manualmente conexiones, consultas SQL, procedimientos de inserción, actualización y eliminación de registros. Este proceso implicaba una gran cantidad de código repetitivo y aumentaba la complejidad de las aplicaciones.

Entity Framework simplifica este proceso al permitir que las tablas de una base de datos sean representadas mediante clases y objetos. De esta manera, los desarrolladores pueden interactuar con los datos utilizando las características propias del lenguaje C# y aprovechar LINQ para realizar consultas de forma sencilla y segura.

El dominio de Entity Framework es fundamental para el desarrollo moderno de aplicaciones .NET, ya que facilita la productividad, mejora el mantenimiento del código y reduce significativamente el tiempo de desarrollo.

---

## ¿Qué es Entity Framework?

Entity Framework es un ORM (Object Relational Mapper) para .NET que permite mapear tablas de una base de datos a clases de C#.

Su objetivo principal es eliminar la necesidad de escribir constantemente consultas SQL para realizar operaciones básicas sobre los datos.

Con Entity Framework es posible:

* Consultar información.
* Insertar registros.
* Actualizar datos.
* Eliminar registros.
* Gestionar relaciones entre tablas.
* Trabajar con LINQ.
* Automatizar la generación de modelos.

Gracias a esta tecnología, los desarrolladores pueden concentrarse en la lógica de negocio de la aplicación en lugar de dedicar tiempo a tareas repetitivas relacionadas con el acceso a datos.

---

## Arquitectura de Entity Framework

Entity Framework se basa en varios componentes que trabajan conjuntamente para gestionar la comunicación entre la aplicación y la base de datos.

### Entidades

Las entidades representan las tablas de la base de datos mediante clases de C#.

### DbContext

Es la clase principal encargada de administrar la conexión con la base de datos y realizar operaciones sobre las entidades.

### DbSet

Representa una colección de entidades dentro del contexto.

### Base de Datos

Es el sistema de almacenamiento donde se encuentran los datos persistentes.

La interacción entre estos componentes permite que las operaciones sobre objetos sean traducidas automáticamente a instrucciones SQL.

---

## Instalación de Entity Framework Core

Actualmente, la versión más utilizada es Entity Framework Core.

Puede instalarse mediante NuGet utilizando el siguiente comando:

```powershell
Install-Package Microsoft.EntityFrameworkCore
```

Para trabajar con SQL Server también es necesario instalar el proveedor correspondiente:

```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

Y para utilizar migraciones:

```powershell
Install-Package Microsoft.EntityFrameworkCore.Tools
```

Estas bibliotecas proporcionan todas las funcionalidades necesarias para desarrollar aplicaciones basadas en Entity Framework Core.

---

## Creación de una Entidad

Las entidades son clases que representan tablas dentro de la base de datos.

### Ejemplo

```csharp
public class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public decimal Precio { get; set; }
}
```

### Explicación

La clase Producto representa una tabla llamada Productos.

Cada propiedad corresponde a una columna:

* Id representa la clave primaria.
* Nombre almacena el nombre del producto.
* Precio almacena el valor monetario.

---

## Creación del DbContext

El contexto es el componente encargado de administrar las entidades.

### Ejemplo

```csharp
using Microsoft.EntityFrameworkCore;

public class TiendaContext : DbContext
{
    public DbSet<Producto> Productos
    {
        get;
        set;
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=.;Database=TiendaDB;Trusted_Connection=True;");
    }
}
```

### Explicación

La propiedad DbSet representa la tabla Productos.

El método OnConfiguring establece la cadena de conexión utilizada para acceder a la base de datos.

---

## Consultar Datos con Entity Framework

Una de las principales ventajas de Entity Framework es la posibilidad de utilizar LINQ para consultar información.

### Ejemplo

```csharp
using(var contexto =
    new TiendaContext())
{
    var productos =
    contexto.Productos.ToList();
}
```

### Explicación

La consulta recupera todos los registros de la tabla Productos y los convierte en una lista de objetos.

---

## Filtrado de Datos con Where()

Entity Framework permite utilizar operadores LINQ para filtrar información.

### Ejemplo

```csharp
using(var contexto =
    new TiendaContext())
{
    var productos =
    contexto.Productos
    .Where(producto =>
        producto.Precio > 100)
    .ToList();
}
```

### Explicación

La consulta obtiene únicamente los productos cuyo precio sea superior a cien unidades monetarias.

### SQL Generado

```sql
SELECT *
FROM Productos
WHERE Precio > 100
```

---

## Ordenamiento de Datos

Los resultados pueden ordenarse utilizando operadores LINQ.

### Ejemplo

```csharp
using(var contexto =
    new TiendaContext())
{
    var productos =
    contexto.Productos
    .OrderBy(producto =>
        producto.Nombre)
    .ToList();
}
```

### Explicación

Los productos son ordenados alfabéticamente según su nombre.

---

## Inserción de Datos

Entity Framework simplifica la creación de nuevos registros.

### Ejemplo

```csharp
using(var contexto =
    new TiendaContext())
{
    Producto producto =
    new Producto()
    {
        Nombre = "Laptop",
        Precio = 1200
    };

    contexto.Productos.Add(producto);

    contexto.SaveChanges();
}
```

### Explicación

El método Add() agrega la entidad al contexto.

SaveChanges() ejecuta la instrucción SQL necesaria para almacenar el registro en la base de datos.

---

## Actualización de Datos

También es posible modificar registros existentes.

### Ejemplo

```csharp
using(var contexto =
    new TiendaContext())
{
    Producto producto =
    contexto.Productos
    .First();

    producto.Precio = 1500;

    contexto.SaveChanges();
}
```

### Explicación

Entity Framework detecta automáticamente los cambios realizados sobre la entidad y genera la instrucción UPDATE correspondiente.

---

## Eliminación de Datos

Los registros pueden eliminarse fácilmente.

### Ejemplo

```csharp
using(var contexto =
    new TiendaContext())
{
    Producto producto =
    contexto.Productos
    .First();

    contexto.Productos.Remove(producto);

    contexto.SaveChanges();
}
```

### Explicación

Remove() marca la entidad para eliminación y SaveChanges() ejecuta la operación en la base de datos.

---

## Relaciones entre Entidades

Las bases de datos suelen contener relaciones entre tablas.

### Ejemplo

```csharp
public class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public ICollection<Producto>
    Productos { get; set; }
}

public class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public int CategoriaId { get; set; }

    public Categoria Categoria
    {
        get;
        set;
    }
}
```

### Explicación

Una categoría puede contener múltiples productos.

Esta relación corresponde a una asociación uno a muchos.

---

## Carga de Datos Relacionados con Include()

Entity Framework permite recuperar entidades relacionadas.

### Ejemplo

```csharp
using(var contexto =
    new TiendaContext())
{
    var productos =
    contexto.Productos
    .Include(producto =>
        producto.Categoria)
    .ToList();
}
```

### Explicación

Include() carga la información de la categoría asociada a cada producto.

---

## Migraciones

Las migraciones permiten crear y actualizar la estructura de la base de datos a partir del modelo de clases.

### Crear una Migración

```powershell
Add-Migration Inicial
```

### Aplicar la Migración

```powershell
Update-Database
```

### Explicación

Entity Framework genera automáticamente las instrucciones SQL necesarias para crear o modificar las tablas.

---

## Enfoques de Desarrollo

Entity Framework ofrece diferentes estrategias para trabajar con bases de datos.

### Database First

La base de datos existe previamente y Entity Framework genera las clases correspondientes.

### Code First

Las clases son creadas primero y posteriormente se genera la base de datos.

### Model First

Se diseña un modelo visual que posteriormente genera tanto las clases como la base de datos.

Actualmente, Code First es el enfoque más utilizado en Entity Framework Core.

---

## Ventajas de Entity Framework

### Mayor productividad

Reduce significativamente la cantidad de código necesario para acceder a los datos.

### Integración con LINQ

Permite realizar consultas utilizando una sintaxis clara y expresiva.

### Mantenimiento simplificado

Los cambios en el modelo pueden gestionarse mediante migraciones.

### Seguridad

Reduce riesgos asociados a la construcción manual de consultas SQL.

### Abstracción

Permite trabajar con objetos en lugar de tablas y registros.

### Compatibilidad

Funciona con múltiples motores de bases de datos mediante proveedores específicos.

---

## Desventajas de Entity Framework

### Curva de aprendizaje

Es necesario comprender conceptos como entidades, contextos y migraciones.

### Rendimiento

En escenarios muy complejos puede generar consultas menos optimizadas que SQL escrito manualmente.

### Dependencia del ORM

El desarrollador debe comprender cómo Entity Framework traduce las consultas a SQL.

### Consumo de recursos

El seguimiento automático de entidades puede incrementar el uso de memoria en aplicaciones grandes.

---

## Caso Práctico

Supóngase una aplicación de gestión de inventario que almacena productos en una base de datos.

### Obtener Productos

```csharp
var productos =
contexto.Productos
.ToList();
```

### Filtrar Productos Costosos

```csharp
var productosCaros =
contexto.Productos
.Where(producto =>
    producto.Precio > 500)
.ToList();
```

### Ordenar Productos

```csharp
var ordenados =
contexto.Productos
.OrderBy(producto =>
    producto.Nombre)
.ToList();
```

### Calcular Promedio

```csharp
var promedio =
contexto.Productos
.Average(producto =>
    producto.Precio);
```

### Explicación

Este escenario demuestra cómo Entity Framework y LINQ pueden combinarse para consultar, filtrar, ordenar y analizar información almacenada en una base de datos utilizando una sintaxis sencilla y orientada a objetos.

---

## Conclusión

Entity Framework es una de las tecnologías más importantes dentro del ecosistema .NET para el acceso a datos. Gracias a su capacidad para mapear tablas a objetos, automatizar operaciones CRUD y trabajar de forma integrada con LINQ, permite desarrollar aplicaciones más productivas, mantenibles y seguras. Conceptos como entidades, DbContext, DbSet, relaciones, migraciones y consultas LINQ constituyen la base para aprovechar todo el potencial de esta herramienta en proyectos modernos de desarrollo de software.

