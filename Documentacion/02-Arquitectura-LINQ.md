# 2. Arquitectura de LINQ

## Introducción

Para comprender completamente LINQ es necesario conocer los componentes internos que participan en la ejecución de una consulta.

Aunque desde la perspectiva del programador una consulta LINQ parece simple, internamente intervienen diversos elementos que permiten traducir, procesar y ejecutar las consultas sobre distintas fuentes de datos.

---

# Componentes principales de LINQ

La arquitectura de LINQ está formada por:

1. Fuente de datos (Data Source)
2. Consulta (Query)
3. Proveedor de consultas (Query Provider)
4. Expresiones Lambda
5. Árboles de expresiones (Expression Trees)
6. IEnumerable
7. IQueryable

---

# Fuente de Datos (Data Source)

Es el origen de la información sobre la cual se realizará la consulta.

Ejemplos:

```csharp
List<string> nombres = new List<string>();

int[] numeros = {1,2,3,4,5};

DbSet<Producto> productos;
```

Las fuentes de datos pueden ser:

- Colecciones
- Arreglos
- Bases de datos
- XML
- Entity Framework

---

# Consulta (Query)

La consulta define qué información se desea obtener.

Ejemplo:

```csharp
var resultado =
numeros.Where(n => n > 3);
```

En este caso la consulta solicita únicamente los números mayores que 3.

---

# Expresiones Lambda

Las expresiones lambda permiten representar funciones anónimas.

Ejemplo:

```csharp
n => n > 3
```

Significado:

```text
Para cada valor n,
devuelve verdadero si n es mayor que 3.
```

---

## Sintaxis General

```csharp
(parametros) => expresion
```

Ejemplos:

```csharp
x => x * 2
```

```csharp
(x,y) => x + y
```

```csharp
nombre => nombre.ToUpper()
```

---

# IEnumerable<T>

Representa una colección que puede recorrerse secuencialmente.

Es utilizado principalmente por LINQ to Objects.

Ejemplo:

```csharp
List<int> numeros =
new List<int>()
{
    1,2,3,4,5
};

IEnumerable<int> resultado =
numeros.Where(n => n > 2);
```

---

## Características de IEnumerable

- Trabaja sobre datos en memoria.
- Utiliza ejecución diferida.
- Es ideal para listas y arreglos.

---

# IQueryable<T>

Representa una consulta que puede ser traducida a otro lenguaje.

Generalmente se utiliza con Entity Framework.

Ejemplo:

```csharp
IQueryable<Producto> productos =
db.Productos;
```

---

## Ventajas de IQueryable

Permite que LINQ genere consultas SQL automáticamente.

Por ejemplo:

```csharp
var consulta =
db.Productos
.Where(p => p.Precio > 100);
```

Entity Framework puede traducir la consulta anterior a:

```sql
SELECT *
FROM Productos
WHERE Precio > 100
```

---

# Diferencia entre IEnumerable e IQueryable

| Característica | IEnumerable | IQueryable |
|---------------|------------|------------|
| Datos en memoria | Sí | No necesariamente |
| Traducción a SQL | No | Sí |
| Entity Framework | Limitado | Principal |
| Rendimiento en BD | Menor | Mayor |

---

# Query Providers

Los Query Providers son componentes encargados de interpretar las consultas LINQ.

Algunos ejemplos son:

- LINQ to Objects Provider
- LINQ to SQL Provider
- Entity Framework Provider
- LINQ to XML Provider

---

# Árboles de Expresiones (Expression Trees)

Un Expression Tree representa una consulta en forma de estructura de datos.

Esto permite que Entity Framework analice la consulta y la convierta en SQL.

Ejemplo:

```csharp
Expression<Func<Producto,bool>>
```

Esta estructura puede ser interpretada por el proveedor de consultas para generar instrucciones SQL.

---

# Ejecución Diferida (Deferred Execution)

Una de las características más importantes de LINQ es la ejecución diferida.

Ejemplo:

```csharp
var resultado =
numeros.Where(n => n > 3);
```

Hasta este momento la consulta no se ejecuta.

La ejecución ocurre cuando:

```csharp
resultado.ToList();
```

o

```csharp
foreach(var item in resultado)
{
}
```

---

# Beneficios de la Ejecución Diferida

- Mejor rendimiento.
- Menor consumo de memoria.
- Consultas más eficientes.
- Posibilidad de construir consultas dinámicamente.

---

# Conclusión

La arquitectura de LINQ está diseñada para proporcionar una forma flexible y eficiente de consultar datos. Componentes como IEnumerable, IQueryable, expresiones lambda y ejecución diferida permiten que LINQ funcione tanto sobre colecciones en memoria como sobre bases de datos empresariales.
