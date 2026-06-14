# 5. LINQ to SQL

## Introducción

LINQ to SQL es una implementación de LINQ diseñada para trabajar con bases de datos relacionales mediante una integración directa con SQL Server. Fue introducida en .NET Framework 3.5 con el objetivo de simplificar el acceso a datos y reducir la cantidad de código necesario para realizar operaciones sobre bases de datos.

Su principal característica consiste en permitir que las tablas de una base de datos sean representadas como clases y objetos dentro de una aplicación C#. De esta manera, los desarrolladores pueden realizar consultas utilizando LINQ en lugar de escribir instrucciones SQL manualmente.

LINQ to SQL resulta especialmente útil en aplicaciones empresariales, sistemas de gestión, aplicaciones web y proyectos que requieren una interacción frecuente con bases de datos SQL Server.

---

## ¿Qué es LINQ to SQL?

LINQ to SQL es una tecnología de acceso a datos que permite mapear tablas de una base de datos relacional a clases de C#.

Esta tecnología utiliza el espacio de nombres:

```csharp
System.Data.Linq
```

Su funcionamiento se basa en el concepto de mapeo objeto-relacional (ORM), donde cada tabla se representa mediante una clase y cada registro mediante un objeto.

Entre los componentes más importantes se encuentran:

* DataContext
* Table
* Clases de entidad
* Consultas LINQ
* Métodos de persistencia

Estos elementos permiten consultar y manipular datos utilizando objetos en lugar de instrucciones SQL tradicionales.

---

## Estructura Básica de una Base de Datos

Antes de trabajar con LINQ to SQL es importante comprender la estructura básica de una tabla relacional.

### Ejemplo

```sql
CREATE TABLE Productos
(
    Id INT PRIMARY KEY,
    Nombre VARCHAR(100),
    Precio DECIMAL(10,2)
);
```

### Explicación

La tabla se denomina:

```sql
Productos
```

Cada fila representa un producto y cada columna almacena una característica específica.

Por ejemplo:

```text
Id | Nombre  | Precio
---------------------
1  | Laptop  | 1200
2  | Mouse   | 25
```

---

## Creación de una Clase de Entidad

LINQ to SQL permite representar una tabla mediante una clase.

### Ejemplo

```csharp
[Table(Name = "Productos")]
public class Producto
{
    [Column(IsPrimaryKey = true)]
    public int Id { get; set; }

    [Column]
    public string Nombre { get; set; }

    [Column]
    public decimal Precio { get; set; }
}
```

### Explicación

```csharp
[Table]
```

Indica que la clase representa una tabla de la base de datos.

```csharp
[Column]
```

Indica que una propiedad corresponde a una columna.

### Resultado

Cada registro de la tabla podrá manipularse como un objeto de tipo:

```csharp
Producto
```

---

## Creación del DataContext

El DataContext representa la conexión entre la aplicación y la base de datos.

### Ejemplo

```csharp
DataContext contexto =
new DataContext(
    "Server=.;Database=Tienda;Trusted_Connection=True;"
);
```

### Explicación

```csharp
DataContext
```

Administra la conexión y el seguimiento de cambios realizados sobre los objetos.

---

## Acceso a una Tabla

Una tabla puede obtenerse mediante el método:

```csharp
GetTable<T>()
```

### Ejemplo

```csharp
Table<Producto> productos =
contexto.GetTable<Producto>();
```

### Explicación

La colección obtenida representa todos los registros de la tabla Productos.

---

## Consultas con LINQ to SQL

Una vez obtenida la tabla, es posible realizar consultas utilizando LINQ.

### Ejemplo

```csharp
var resultado =
from producto in productos
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

LINQ to SQL permite filtrar registros utilizando condiciones.

### Ejemplo

```csharp
var productosCaros =
productos.Where(producto =>
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
productos.Select(producto =>
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
productos.OrderBy(producto =>
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

## Inserción de Registros

LINQ to SQL permite agregar nuevos registros mediante objetos.

### Ejemplo

```csharp
Producto producto =
new Producto
{
    Nombre = "Teclado",
    Precio = 80
};

productos.InsertOnSubmit(producto);

contexto.SubmitChanges();
```

### Explicación

```csharp
InsertOnSubmit()
```

Marca el objeto para ser insertado.

```csharp
SubmitChanges()
```

Ejecuta la operación en la base de datos.

---

## Actualización de Registros

Los registros existentes pueden modificarse directamente.

### Ejemplo

```csharp
Producto producto =
productos.First();

producto.Nombre =
"Laptop Gamer";

contexto.SubmitChanges();
```

### Explicación

LINQ to SQL detecta automáticamente los cambios realizados sobre el objeto.

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
productos.First();

productos.DeleteOnSubmit(producto);

contexto.SubmitChanges();
```

### Explicación

```csharp
DeleteOnSubmit()
```

Marca el registro para ser eliminado.

---

## Obtención de un Registro con First()

LINQ to SQL permite recuperar el primer registro que cumpla una condición.

### Ejemplo

```csharp
Producto producto =
productos.First(p =>
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
productos.FirstOrDefault(p =>
    p.Precio > 5000);
```

### Resultado

```text
null
```

---

## Conteo de Registros

LINQ to SQL permite conocer la cantidad de registros almacenados.

### Ejemplo

```csharp
int cantidad =
productos.Count();
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
productos.Sum(producto =>
    producto.Precio);
```

Resultado:

```text
1525
```

### Promedio

```csharp
decimal promedio =
productos.Average(producto =>
    producto.Precio);
```

Resultado:

```text
508.33
```

### Máximo

```csharp
decimal maximo =
productos.Max(producto =>
    producto.Precio);
```

Resultado:

```text
1200
```

### Mínimo

```csharp
decimal minimo =
productos.Min(producto =>
    producto.Precio);
```

Resultado:

```text
25
```

---

## Relaciones entre Tablas

LINQ to SQL permite representar relaciones entre tablas mediante propiedades de navegación.

### Ejemplo

```csharp
[Table]
public class Categoria
{
    [Column(IsPrimaryKey = true)]
    public int Id { get; set; }

    [Column]
    public string Nombre { get; set; }
}
```

```csharp
[Table]
public class Producto
{
    [Column]
    public int CategoriaId { get; set; }
}
```

### Explicación

Las relaciones permiten acceder a información relacionada utilizando objetos en lugar de consultas SQL complejas.

---

## Uso de LINQ to SQL con Objetos

Cada registro recuperado desde la base de datos se convierte automáticamente en un objeto.

### Ejemplo

```csharp
var productosEconomicos =
productos.Where(producto =>
    producto.Precio < 100);
```

### Explicación

Los registros obtenidos pueden manipularse como cualquier colección de objetos de C#.

---

## Caso Práctico

Supóngase una aplicación de inventario que almacena productos en una base de datos SQL Server.

### Ejemplo

```csharp
var productosEconomicos =
productos.Where(producto =>
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

## Ventajas de LINQ to SQL

### Sintaxis sencilla

Permite consultar bases de datos utilizando código C# legible y fácil de mantener.

### Integración con LINQ

Puede combinarse con operadores como `Where()`, `Select()` y `OrderBy()`.

### Menor cantidad de código

Reduce significativamente la necesidad de escribir instrucciones SQL manualmente.

### Mapeo objeto-relacional

Facilita la representación de tablas mediante clases y objetos.

### Productividad

Acelera el desarrollo de aplicaciones orientadas a bases de datos.

---

## Desventajas de LINQ to SQL

### Compatibilidad limitada

Está diseñado principalmente para trabajar con SQL Server.

### Menor flexibilidad

Ofrece menos funcionalidades avanzadas que tecnologías más modernas como Entity Framework.

### Dependencia del modelo

Los cambios en la estructura de la base de datos pueden requerir modificaciones en las clases.

### Curva de aprendizaje

Es necesario comprender conceptos de LINQ y bases de datos relacionales.

---

## Conclusión

LINQ to SQL proporciona una forma sencilla y eficiente de trabajar con bases de datos SQL Server utilizando objetos y consultas LINQ. Gracias a componentes como `DataContext`, `Table<T>` y las clases de entidad, los desarrolladores pueden consultar, insertar, actualizar y eliminar registros mediante una sintaxis clara y consistente. Su integración con el lenguaje C# facilita enormemente el acceso a datos y representa una excelente introducción al desarrollo basado en tecnologías ORM dentro del ecosistema .NET.

