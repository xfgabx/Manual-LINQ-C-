# 7. LINQ to Entities

## Introducción

LINQ to Entities es una implementación de LINQ diseñada para trabajar con bases de datos mediante Entity Framework, una de las tecnologías ORM (Object-Relational Mapping) más utilizadas dentro del ecosistema .NET.

Su principal objetivo consiste en permitir que los desarrolladores interactúen con bases de datos utilizando objetos y consultas LINQ en lugar de escribir instrucciones SQL manualmente. Gracias a esta característica, es posible manipular datos de forma más segura, mantenible y orientada a objetos.

LINQ to Entities forma parte de Entity Framework y permite realizar consultas sobre entidades que representan tablas de una base de datos. Estas consultas son traducidas automáticamente a SQL por el proveedor de Entity Framework y posteriormente ejecutadas sobre el motor de base de datos correspondiente.

Actualmente, LINQ to Entities es una de las tecnologías más utilizadas para el acceso a datos en aplicaciones empresariales, aplicaciones web, APIs REST y sistemas de gestión desarrollados con .NET.

---

## ¿Qué es LINQ to Entities?

LINQ to Entities es una implementación de LINQ que permite consultar y manipular datos almacenados en bases de datos mediante Entity Framework.

A diferencia de LINQ to Objects, que trabaja sobre colecciones cargadas en memoria, LINQ to Entities trabaja sobre entidades administradas por un contexto de base de datos.

Esta tecnología utiliza principalmente los espacios de nombres:

```csharp
Microsoft.EntityFrameworkCore
```

o en versiones clásicas:

```csharp
System.Data.Entity
```

Su funcionamiento se basa en el concepto de ORM, donde:

* Cada tabla se representa mediante una clase.
* Cada fila se representa mediante un objeto.
* Cada columna se representa mediante una propiedad.
* Las relaciones se representan mediante propiedades de navegación.

Esto permite trabajar con datos utilizando objetos de C# en lugar de instrucciones SQL tradicionales.

---

## Arquitectura de Entity Framework

Entity Framework utiliza varios componentes para administrar el acceso a datos.

Entre los más importantes se encuentran:

* DbContext
* DbSet
* Entidades
* Consultas LINQ
* Migraciones
* Seguimiento de cambios

Estos componentes permiten realizar operaciones CRUD (Create, Read, Update y Delete) de manera sencilla y eficiente.

---

## Creación de una Entidad

Las entidades representan tablas dentro de la base de datos.

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

La clase:

```csharp
Producto
```

representa una tabla dentro de la base de datos.

Cada propiedad corresponde a una columna.

### Resultado

La tabla generada conceptualmente sería:

```text
Id | Nombre  | Precio
---------------------
1  | Laptop  | 1200
2  | Mouse   | 25
```

---

## Creación del DbContext

El contexto representa la conexión entre la aplicación y la base de datos.

### Ejemplo

```csharp
public class TiendaContext : DbContext
{
    public DbSet<Producto> Productos
    {
        get;
        set;
    }
}
```

### Explicación

```csharp
DbContext
```

es la clase principal de Entity Framework.

```csharp
DbSet<T>
```

representa una colección de entidades asociadas a una tabla.

---

## Acceso a una Tabla

Las tablas se representan mediante propiedades de tipo:

```csharp
DbSet<T>
```

### Ejemplo

```csharp
using var contexto =
new TiendaContext();

DbSet<Producto> productos =
contexto.Productos;
```

### Explicación

La colección obtenida permite consultar y manipular los registros de la tabla Productos.

---

## Consultas con LINQ to Entities

Una vez obtenido el conjunto de entidades, es posible realizar consultas utilizando LINQ.

### Ejemplo

```csharp
var resultado =
from producto in contexto.Productos
select producto;
```

### Explicación

La consulta recupera todos los registros almacenados en la tabla.

### Resultado

```text
Laptop
Mouse
Monitor
```

---

## Filtrado de Datos con Where()

LINQ to Entities permite filtrar registros utilizando condiciones.

### Ejemplo

```csharp
var productosCaros =
contexto.Productos
.Where(producto =>
    producto.Precio > 100);
```

### Explicación

La consulta selecciona únicamente los productos cuyo precio supera los cien dólares.

### Resultado

```text
Laptop
Monitor
```

---

## Transformación de Datos con Select()

El método `Select()` permite proyectar únicamente la información necesaria.

### Ejemplo

```csharp
var nombres =
contexto.Productos
.Select(producto =>
    producto.Nombre);
```

### Explicación

La consulta obtiene únicamente los nombres de los productos.

### Resultado

```text
Laptop
Mouse
Monitor
```

---

## Ordenamiento con OrderBy()

Los registros pueden ordenarse fácilmente utilizando LINQ.

### Ejemplo

```csharp
var ordenados =
contexto.Productos
.OrderBy(producto =>
    producto.Precio);
```

### Explicación

Los productos son organizados desde el precio más bajo hasta el más alto.

### Resultado

```text
Mouse
Monitor
Laptop
```

---

## Ordenamiento Descendente con OrderByDescending()

También es posible ordenar los registros de mayor a menor.

### Ejemplo

```csharp
var ordenados =
contexto.Productos
.OrderByDescending(producto =>
    producto.Precio);
```

### Resultado

```text
Laptop
Monitor
Mouse
```

---

## Inserción de Registros

Entity Framework permite agregar nuevos registros mediante objetos.

### Ejemplo

```csharp
Producto producto =
new Producto
{
    Nombre = "Teclado",
    Precio = 80
};

contexto.Productos.Add(producto);

contexto.SaveChanges();
```

### Explicación

```csharp
Add()
```

agrega una nueva entidad al contexto.

```csharp
SaveChanges()
```

persiste los cambios en la base de datos.

---

## Actualización de Registros

Los registros existentes pueden modificarse directamente.

### Ejemplo

```csharp
Producto producto =
contexto.Productos.First();

producto.Nombre =
"Laptop Gamer";

contexto.SaveChanges();
```

### Explicación

Entity Framework detecta automáticamente los cambios realizados sobre las entidades.

### Resultado

```text
Laptop Gamer
```

---

## Eliminación de Registros

También es posible eliminar registros de una tabla.

### Ejemplo

```csharp
Producto producto =
contexto.Productos.First();

contexto.Productos.Remove(producto);

contexto.SaveChanges();
```

### Explicación

```csharp
Remove()
```

marca la entidad para ser eliminada.

---

## Obtención de un Registro con First()

LINQ to Entities permite recuperar el primer registro que cumpla una condición.

### Ejemplo

```csharp
Producto producto =
contexto.Productos.First(p =>
    p.Precio > 100);
```

### Resultado

```text
Laptop
```

---

## Obtención Segura con FirstOrDefault()

Cuando no existe un registro coincidente, puede utilizarse una alternativa segura.

### Ejemplo

```csharp
Producto producto =
contexto.Productos.FirstOrDefault(p =>
    p.Precio > 5000);
```

### Resultado

```text
null
```

---

## Conteo de Registros

LINQ to Entities permite conocer la cantidad de registros almacenados.

### Ejemplo

```csharp
int cantidad =
contexto.Productos.Count();
```

### Resultado

```text
3
```

---

## Operaciones Matemáticas

Las consultas pueden realizar cálculos directamente sobre los datos.

### Suma

```csharp
decimal total =
contexto.Productos.Sum(producto =>
    producto.Precio);
```

Resultado:

```text
1525
```

### Promedio

```csharp
decimal promedio =
contexto.Productos.Average(producto =>
    producto.Precio);
```

Resultado:

```text
508.33
```

### Máximo

```csharp
decimal maximo =
contexto.Productos.Max(producto =>
    producto.Precio);
```

Resultado:

```text
1200
```

### Mínimo

```csharp
decimal minimo =
contexto.Productos.Min(producto =>
    producto.Precio);
```

Resultado:

```text
25
```

---

## Relaciones entre Entidades

Entity Framework permite representar relaciones entre tablas mediante propiedades de navegación.

### Ejemplo

```csharp
public class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public ICollection<Producto>
    Productos { get; set; }
}
```

```csharp
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

Las propiedades de navegación permiten acceder a entidades relacionadas utilizando objetos.

---

## Carga de Datos Relacionados con Include()

Entity Framework permite cargar entidades relacionadas mediante el método:

```csharp
Include()
```

### Ejemplo

```csharp
var productos =
contexto.Productos
.Include(producto =>
    producto.Categoria)
.ToList();
```

### Explicación

La consulta recupera los productos junto con la información de sus categorías.

---

## Uso de LINQ to Entities con Objetos

Cada registro recuperado desde la base de datos se convierte automáticamente en una entidad.

### Ejemplo

```csharp
var productosEconomicos =
contexto.Productos.Where(producto =>
    producto.Precio < 100);
```

### Explicación

Las entidades obtenidas pueden manipularse como cualquier objeto de C#.

---

## Caso Práctico

Supóngase una aplicación de inventario que almacena productos en una base de datos.

### Ejemplo

```csharp
var productosEconomicos =
contexto.Productos.Where(producto =>
    producto.Precio < 100);
```

### Explicación

La consulta obtiene todos los productos cuyo precio es inferior a cien dólares.

### Resultado

```text
Mouse
Teclado
```

---

## Ventajas de LINQ to Entities

### Independencia del motor de base de datos

Puede trabajar con SQL Server, PostgreSQL, MySQL, SQLite y otros proveedores compatibles.

### Integración con LINQ

Permite utilizar operadores como `Where()`, `Select()`, `OrderBy()` y `GroupBy()`.

### Menor cantidad de código

Reduce significativamente la necesidad de escribir instrucciones SQL manualmente.

### Mapeo objeto-relacional

Facilita la representación de tablas mediante clases y objetos.

### Productividad

Acelera el desarrollo de aplicaciones orientadas a bases de datos.

### Mantenimiento

Favorece la creación de aplicaciones más organizadas y fáciles de mantener.

---

## Desventajas de LINQ to Entities

### Curva de aprendizaje

Es necesario comprender conceptos de LINQ, Entity Framework y bases de datos relacionales.

### Consultas complejas

Algunas consultas avanzadas pueden requerir optimización adicional.

### Consumo de recursos

El seguimiento automático de entidades puede incrementar el uso de memoria.

### Dependencia del ORM

La aplicación depende del funcionamiento y configuración de Entity Framework.

---

## Conclusión

LINQ to Entities proporciona una forma moderna y eficiente de trabajar con bases de datos mediante Entity Framework. Gracias a componentes como `DbContext`, `DbSet<T>` y las entidades, los desarrolladores pueden consultar, insertar, actualizar y eliminar registros utilizando una sintaxis clara y orientada a objetos. Su integración con LINQ y su compatibilidad con múltiples motores de bases de datos lo convierten en una de las tecnologías más importantes para el acceso a datos dentro del ecosistema .NET moderno.

