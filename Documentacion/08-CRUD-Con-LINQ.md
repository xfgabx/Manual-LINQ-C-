# 8. CRUD con LINQ

## Introducción

Las operaciones CRUD constituyen la base de cualquier aplicación que interactúa con datos. El término CRUD proviene de las palabras en inglés Create, Read, Update y Delete, que representan las cuatro operaciones fundamentales para administrar información dentro de un sistema.

LINQ facilita enormemente la implementación de estas operaciones al proporcionar una sintaxis uniforme para consultar y manipular datos. Cuando se combina con Entity Framework, LINQ permite realizar operaciones CRUD utilizando objetos de C# en lugar de escribir instrucciones SQL manualmente.

Gracias a esta integración, los desarrolladores pueden trabajar de forma más productiva, reducir errores y mantener un código más limpio y fácil de comprender.

---

## ¿Qué es CRUD?

CRUD es un conjunto de operaciones utilizadas para administrar información dentro de una aplicación.

Las operaciones son:

* Create (Crear)
* Read (Leer)
* Update (Actualizar)
* Delete (Eliminar)

Estas acciones permiten gestionar completamente los datos almacenados en una base de datos.

Por ejemplo, en una aplicación de inventario:

* Crear un producto nuevo.
* Consultar productos existentes.
* Modificar información de un producto.
* Eliminar productos obsoletos.

Todas estas tareas pueden realizarse utilizando LINQ y Entity Framework.

---

## Preparación del Modelo de Datos

Antes de realizar operaciones CRUD es necesario definir una entidad.

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

La clase representa una tabla dentro de la base de datos.

Cada propiedad corresponde a una columna:

* Id → Identificador único.
* Nombre → Nombre del producto.
* Precio → Precio del producto.

---

## Configuración del DbContext

El contexto permite establecer la conexión con la base de datos.

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

La propiedad:

```csharp
DbSet<Producto>
```

representa la tabla Productos dentro de la base de datos.

A través de esta colección se realizan todas las operaciones CRUD.

---

# CREATE (Crear)

## Inserción de un Registro

La operación Create permite agregar nuevos registros a la base de datos.

### Ejemplo

```csharp
using var contexto =
new TiendaContext();

Producto producto =
new Producto
{
    Nombre = "Laptop",
    Precio = 1200
};

contexto.Productos.Add(producto);

contexto.SaveChanges();
```

### Explicación

El método:

```csharp
Add()
```

agrega la entidad al contexto.

Posteriormente:

```csharp
SaveChanges()
```

envía los cambios a la base de datos.

### Resultado

```text
Id | Nombre | Precio
--------------------
1  | Laptop | 1200
```

---

## Inserción de Múltiples Registros

También es posible agregar varios registros simultáneamente.

### Ejemplo

```csharp
contexto.Productos.AddRange(
    new Producto
    {
        Nombre = "Mouse",
        Precio = 25
    },
    new Producto
    {
        Nombre = "Teclado",
        Precio = 80
    });

contexto.SaveChanges();
```

### Explicación

```csharp
AddRange()
```

permite insertar múltiples entidades en una sola operación.

### Resultado

```text
Laptop
Mouse
Teclado
```

---

# READ (Leer)

## Obtener Todos los Registros

La operación Read permite consultar información almacenada.

### Ejemplo

```csharp
var productos =
contexto.Productos.ToList();
```

### Explicación

```csharp
ToList()
```

ejecuta la consulta y devuelve todos los registros.

### Resultado

```text
Laptop
Mouse
Teclado
```

---

## Filtrado con Where()

LINQ permite recuperar únicamente los registros que cumplen una condición.

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
```

---

## Obtención de un Registro con First()

Es posible recuperar un único registro.

### Ejemplo

```csharp
Producto producto =
contexto.Productos.First(p =>
    p.Nombre == "Laptop");
```

### Resultado

```text
Laptop
```

---

## Obtención Segura con FirstOrDefault()

Cuando no existe un registro coincidente puede utilizarse una alternativa segura.

### Ejemplo

```csharp
Producto producto =
contexto.Productos.FirstOrDefault(p =>
    p.Nombre == "Tablet");
```

### Resultado

```text
null
```

---

## Proyección de Datos con Select()

No siempre es necesario recuperar todas las columnas.

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
Teclado
```

---

## Ordenamiento de Resultados

Los registros pueden organizarse utilizando LINQ.

### Ejemplo

```csharp
var ordenados =
contexto.Productos
.OrderBy(producto =>
    producto.Precio);
```

### Resultado

```text
Mouse
Teclado
Laptop
```

---

# UPDATE (Actualizar)

## Modificación de un Registro

La operación Update permite modificar información existente.

### Ejemplo

```csharp
Producto producto =
contexto.Productos.First();

producto.Nombre =
"Laptop Gamer";

producto.Precio =
1500;

contexto.SaveChanges();
```

### Explicación

Entity Framework detecta automáticamente los cambios realizados sobre la entidad.

### Resultado

```text
Laptop Gamer
```

---

## Actualización Utilizando una Condición

También es posible localizar un registro específico antes de modificarlo.

### Ejemplo

```csharp
Producto producto =
contexto.Productos
.First(p =>
    p.Nombre == "Mouse");

producto.Precio = 35;

contexto.SaveChanges();
```

### Resultado

```text
Mouse - 35
```

---

## Verificación de Cambios

Después de actualizar un registro es posible consultar nuevamente la información.

### Ejemplo

```csharp
var productoActualizado =
contexto.Productos
.First(p =>
    p.Nombre == "Mouse");
```

### Resultado

```text
Mouse - 35
```

---

# DELETE (Eliminar)

## Eliminación de un Registro

La operación Delete permite eliminar información de la base de datos.

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

### Resultado

```text
Registro eliminado
```

---

## Eliminación Mediante una Condición

Es posible localizar primero el registro que se desea eliminar.

### Ejemplo

```csharp
Producto producto =
contexto.Productos
.First(p =>
    p.Nombre == "Mouse");

contexto.Productos.Remove(producto);

contexto.SaveChanges();
```

### Resultado

```text
Mouse eliminado
```

---

## Eliminación de Múltiples Registros

Entity Framework permite eliminar varios registros simultáneamente.

### Ejemplo

```csharp
var productos =
contexto.Productos
.Where(producto =>
    producto.Precio < 50);

contexto.Productos.RemoveRange(productos);

contexto.SaveChanges();
```

### Explicación

```csharp
RemoveRange()
```

elimina múltiples entidades en una sola operación.

---

## Conteo de Registros

Después de realizar operaciones CRUD es común verificar la cantidad de registros existentes.

### Ejemplo

```csharp
int cantidad =
contexto.Productos.Count();
```

### Resultado

```text
5
```

---

## Validación de Existencia con Any()

Antes de insertar, actualizar o eliminar registros puede verificarse si existen datos.

### Ejemplo

```csharp
bool existe =
contexto.Productos.Any(producto =>
    producto.Nombre == "Laptop");
```

### Resultado

```text
True
```

---

## Operaciones Matemáticas

LINQ permite realizar cálculos directamente sobre los registros almacenados.

### Suma

```csharp
decimal total =
contexto.Productos.Sum(producto =>
    producto.Precio);
```

Resultado:

```text
1800
```

### Promedio

```csharp
decimal promedio =
contexto.Productos.Average(producto =>
    producto.Precio);
```

Resultado:

```text
600
```

### Máximo

```csharp
decimal maximo =
contexto.Productos.Max(producto =>
    producto.Precio);
```

Resultado:

```text
1500
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

## Caso Práctico

Supóngase una aplicación de inventario que administra productos mediante Entity Framework.

### Crear

```csharp
contexto.Productos.Add(
new Producto
{
    Nombre = "Monitor",
    Precio = 300
});

contexto.SaveChanges();
```

### Leer

```csharp
var productos =
contexto.Productos.ToList();
```

### Actualizar

```csharp
var monitor =
contexto.Productos
.First(p =>
    p.Nombre == "Monitor");

monitor.Precio = 350;

contexto.SaveChanges();
```

### Eliminar

```csharp
contexto.Productos.Remove(monitor);

contexto.SaveChanges();
```

### Explicación

Este flujo representa el ciclo completo de administración de datos dentro de una aplicación real.

---

## Ventajas de Utilizar CRUD con LINQ

### Código más limpio

Permite trabajar con objetos en lugar de instrucciones SQL complejas.

### Integración con Entity Framework

Facilita el acceso a datos mediante entidades y contextos.

### Productividad

Reduce significativamente la cantidad de código necesario.

### Seguridad

Disminuye riesgos asociados a consultas SQL construidas manualmente.

### Mantenimiento

Favorece aplicaciones más organizadas y fáciles de actualizar.

### Legibilidad

Las consultas resultan más fáciles de comprender para otros desarrolladores.

---

## Desventajas de Utilizar CRUD con LINQ

### Curva de aprendizaje

Es necesario comprender LINQ, Entity Framework y bases de datos relacionales.

### Consultas complejas

Algunas operaciones avanzadas pueden requerir optimización adicional.

### Consumo de recursos

El seguimiento automático de entidades puede incrementar el uso de memoria.

### Dependencia del ORM

La aplicación depende del funcionamiento de Entity Framework.

---

## Conclusión

Las operaciones CRUD representan el núcleo de cualquier sistema de gestión de datos. Gracias a LINQ y Entity Framework, es posible implementar estas operaciones utilizando una sintaxis clara, orientada a objetos y altamente mantenible. Mediante métodos como `Add()`, `Where()`, `First()`, `Remove()` y `SaveChanges()`, los desarrolladores pueden crear, consultar, actualizar y eliminar información de manera eficiente, reduciendo la complejidad del código y aumentando la productividad en el desarrollo de aplicaciones modernas con .NET.

