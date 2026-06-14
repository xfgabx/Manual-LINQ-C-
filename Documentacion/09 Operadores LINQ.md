# 9. Operadores LINQ

## Introducción

Los operadores LINQ constituyen el conjunto de métodos que permiten realizar consultas, transformaciones y análisis sobre colecciones de datos. Estos operadores son la base del funcionamiento de LINQ y proporcionan una forma uniforme de trabajar con información almacenada en memoria, bases de datos, archivos XML y otras fuentes de datos compatibles.

Gracias a los operadores LINQ, los desarrolladores pueden filtrar registros, ordenar resultados, agrupar elementos, realizar cálculos estadísticos y transformar estructuras de datos utilizando una sintaxis clara y expresiva.

El dominio de estos operadores es fundamental para aprovechar todo el potencial de LINQ dentro de aplicaciones desarrolladas con C# y .NET.

---

## ¿Qué son los Operadores LINQ?

Los operadores LINQ son métodos de extensión que permiten realizar operaciones sobre colecciones de datos.

Estos operadores trabajan principalmente sobre las interfaces:

```csharp
IEnumerable<T>
```

y

```csharp
IQueryable<T>
```

Dependiendo del origen de los datos, las consultas pueden ejecutarse directamente en memoria o traducirse a otros lenguajes como SQL.

Los operadores LINQ se clasifican en diferentes categorías:

* Operadores de filtrado.
* Operadores de proyección.
* Operadores de ordenamiento.
* Operadores de agrupación.
* Operadores de agregación.
* Operadores de cuantificación.
* Operadores de elementos.
* Operadores de partición.
* Operadores de combinación.

---

## Operadores de Filtrado

Los operadores de filtrado permiten seleccionar únicamente los elementos que cumplen determinadas condiciones.

### Operador Where()

Es el operador de filtrado más utilizado en LINQ.

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    5,10,15,20,25,30
};

var resultado =
numeros.Where(numero =>
    numero > 15);
```

### Explicación

La consulta analiza cada elemento de la colección y devuelve únicamente aquellos valores mayores que quince.

### Resultado

```text
20
25
30
```

---

## Operadores de Proyección

Los operadores de proyección permiten transformar los datos de una colección.

### Operador Select()

### Ejemplo

```csharp
List<string> nombres =
new List<string>()
{
    "Carlos",
    "Ana",
    "Pedro"
};

var resultado =
nombres.Select(nombre =>
    nombre.ToUpper());
```

### Explicación

Cada elemento es transformado a letras mayúsculas antes de ser devuelto por la consulta.

### Resultado

```text
CARLOS
ANA
PEDRO
```

---

## Proyección de Objetos

Select() también permite crear nuevos objetos a partir de los datos originales.

### Ejemplo

```csharp
var productos =
new List<Producto>()
{
    new Producto
    {
        Nombre = "Laptop",
        Precio = 1200
    },
    new Producto
    {
        Nombre = "Mouse",
        Precio = 25
    }
};

var resultado =
productos.Select(producto =>
new
{
    producto.Nombre
});
```

### Explicación

La consulta genera una nueva estructura que contiene únicamente el nombre de cada producto.

### Resultado

```text
Laptop
Mouse
```

---

## Operadores de Ordenamiento

Los operadores de ordenamiento permiten organizar los datos según uno o varios criterios.

### Operador OrderBy()

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    8,3,5,1,9,2
};

var resultado =
numeros.OrderBy(numero =>
    numero);
```

### Resultado

```text
1
2
3
5
8
9
```

---

## Operador OrderByDescending()

Permite ordenar los elementos de forma descendente.

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    8,3,5,1,9,2
};

var resultado =
numeros.OrderByDescending(numero =>
    numero);
```

### Resultado

```text
9
8
5
3
2
1
```

---

## Ordenamiento Secundario con ThenBy()

Es posible aplicar criterios adicionales de ordenamiento.

### Ejemplo

```csharp
var personas =
new List<Persona>()
{
    new Persona
    {
        Nombre = "Carlos",
        Edad = 30
    },
    new Persona
    {
        Nombre = "Ana",
        Edad = 30
    },
    new Persona
    {
        Nombre = "Pedro",
        Edad = 25
    }
};

var resultado =
personas
.OrderBy(persona =>
    persona.Edad)
.ThenBy(persona =>
    persona.Nombre);
```

### Explicación

Primero se ordena por edad y posteriormente por nombre.

---

## Operadores de Agrupación

Los operadores de agrupación permiten organizar elementos en grupos relacionados.

### Operador GroupBy()

### Ejemplo

```csharp
List<string> nombres =
new List<string>()
{
    "Carlos",
    "Camila",
    "Pedro",
    "Pablo",
    "Ana"
};

var grupos =
nombres.GroupBy(nombre =>
    nombre[0]);
```

### Explicación

Los nombres son agrupados utilizando la primera letra como criterio.

### Resultado

```text
C
Carlos
Camila

P
Pedro
Pablo

A
Ana
```

---

## Operadores de Agregación

Los operadores de agregación permiten obtener valores resumidos a partir de una colección.

### Operador Count()

### Ejemplo

```csharp
List<string> nombres =
new List<string>()
{
    "Carlos",
    "Ana",
    "Pedro"
};

int cantidad =
nombres.Count();
```

### Resultado

```text
3
```

---

## Operador Sum()

### Ejemplo

```csharp
List<int> ventas =
new List<int>()
{
    100,
    250,
    300,
    150
};

int total =
ventas.Sum();
```

### Resultado

```text
800
```

---

## Operador Average()

### Ejemplo

```csharp
double promedio =
ventas.Average();
```

### Resultado

```text
200
```

---

## Operador Max()

### Ejemplo

```csharp
int maximo =
ventas.Max();
```

### Resultado

```text
300
```

---

## Operador Min()

### Ejemplo

```csharp
int minimo =
ventas.Min();
```

### Resultado

```text
100
```

---

## Operadores de Elementos

Estos operadores permiten recuperar elementos específicos de una colección.

### Operador First()

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    2,
    4,
    6,
    8
};

int resultado =
numeros.First(numero =>
    numero > 3);
```

### Resultado

```text
4
```

---

## Operador FirstOrDefault()

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    2,
    4,
    6
};

int resultado =
numeros.FirstOrDefault(numero =>
    numero > 10);
```

### Resultado

```text
0
```

---

## Operador Last()

Permite obtener el último elemento de una colección.

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    10,
    20,
    30,
    40
};

int resultado =
numeros.Last();
```

### Resultado

```text
40
```

---

## Operador Single()

Se utiliza cuando se espera exactamente un único resultado.

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    10
};

int resultado =
numeros.Single();
```

### Resultado

```text
10
```

---

## Operadores de Cuantificación

Permiten verificar condiciones sobre una colección completa.

### Operador Any()

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    5,
    10,
    15
};

bool existe =
numeros.Any(numero =>
    numero > 10);
```

### Resultado

```text
True
```

---

## Operador All()

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    5,
    10,
    15
};

bool resultado =
numeros.All(numero =>
    numero > 0);
```

### Resultado

```text
True
```

---

## Operadores de Partición

Permiten seleccionar una parte específica de una colección.

### Operador Take()

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    1,2,3,4,5,6
};

var resultado =
numeros.Take(3);
```

### Resultado

```text
1
2
3
```

---

## Operador Skip()

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    1,2,3,4,5,6
};

var resultado =
numeros.Skip(3);
```

### Resultado

```text
4
5
6
```

---

## Operadores de Combinación

Permiten unir o combinar múltiples colecciones.

### Operador Concat()

### Ejemplo

```csharp
List<int> lista1 =
new List<int>()
{
    1,2,3
};

List<int> lista2 =
new List<int>()
{
    4,5,6
};

var resultado =
lista1.Concat(lista2);
```

### Resultado

```text
1
2
3
4
5
6
```

---

## Operador Union()

### Ejemplo

```csharp
List<int> lista1 =
new List<int>()
{
    1,2,3
};

List<int> lista2 =
new List<int>()
{
    3,4,5
};

var resultado =
lista1.Union(lista2);
```

### Resultado

```text
1
2
3
4
5
```

---

## Caso Práctico

Supóngase una aplicación de ventas que almacena productos en memoria.

### Datos

```csharp
List<Producto> productos =
new List<Producto>()
{
    new Producto
    {
        Nombre = "Laptop",
        Precio = 1200
    },
    new Producto
    {
        Nombre = "Mouse",
        Precio = 25
    },
    new Producto
    {
        Nombre = "Monitor",
        Precio = 300
    }
};
```

### Filtrar

```csharp
var caros =
productos.Where(producto =>
    producto.Precio > 100);
```

### Ordenar

```csharp
var ordenados =
productos.OrderBy(producto =>
    producto.Precio);
```

### Calcular Promedio

```csharp
var promedio =
productos.Average(producto =>
    producto.Precio);
```

### Explicación

Este escenario demuestra cómo varios operadores LINQ pueden combinarse para resolver problemas reales de análisis y procesamiento de datos.

---

## Ventajas de los Operadores LINQ

### Sintaxis uniforme

Permiten trabajar con diferentes fuentes de datos utilizando la misma estructura.

### Mayor productividad

Reducen significativamente la cantidad de código necesario.

### Legibilidad

Las consultas son fáciles de leer y comprender.

### Integración con .NET

Funcionan de forma nativa con colecciones y tecnologías como Entity Framework.

### Reutilización

Los operadores pueden combinarse para construir consultas complejas.

### Mantenimiento

Facilitan la actualización y evolución del código.

---

## Desventajas de los Operadores LINQ

### Curva de aprendizaje

Es necesario comprender los distintos operadores y expresiones lambda.

### Rendimiento

Algunas consultas complejas pueden generar sobrecarga adicional.

### Depuración

Las consultas extensas pueden resultar más difíciles de analizar.

### Uso excesivo

El abuso de operadores encadenados puede afectar la legibilidad.

---

## Conclusión

Los operadores LINQ representan el núcleo funcional de LINQ y permiten realizar consultas, transformaciones, agrupaciones, ordenamientos y cálculos sobre colecciones de datos de manera eficiente. Operadores como `Where()`, `Select()`, `OrderBy()`, `GroupBy()`, `Count()`, `Any()` y `First()` proporcionan herramientas poderosas para manipular información utilizando una sintaxis clara y expresiva. Dominar estos operadores es esencial para desarrollar aplicaciones modernas, mantenibles y altamente productivas dentro del ecosistema .NET.

