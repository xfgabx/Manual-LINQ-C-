# 4. LINQ to Objects

## Introducción

LINQ to Objects es una de las implementaciones más utilizadas de LINQ dentro del ecosistema .NET. Su principal objetivo es permitir la realización de consultas sobre colecciones de objetos que ya se encuentran cargadas en memoria.

A diferencia de tecnologías como LINQ to SQL o LINQ to Entities, LINQ to Objects no requiere una conexión a una base de datos para ejecutar consultas. Todas las operaciones se realizan directamente sobre estructuras de datos como arreglos, listas, diccionarios y colecciones de objetos personalizados.

Gracias a su simplicidad y facilidad de uso, LINQ to Objects suele ser el primer contacto de los desarrolladores con LINQ y constituye una base fundamental para comprender otras implementaciones más avanzadas.

---

## ¿Qué es LINQ to Objects?

LINQ to Objects es la implementación de LINQ diseñada para trabajar con colecciones que implementan la interfaz `IEnumerable<T>`.

Esto significa que cualquier colección que pueda recorrerse secuencialmente puede ser consultada utilizando operadores LINQ.

Entre las colecciones más utilizadas se encuentran:

* Arrays
* List
* Dictionary<TKey, TValue>
* HashSet
* Objetos personalizados
* Colecciones genéricas

Su principal ventaja consiste en permitir consultas complejas utilizando una sintaxis clara y uniforme.

---

## Funcionamiento de LINQ to Objects

LINQ to Objects trabaja sobre colecciones almacenadas en memoria y utiliza operadores para filtrar, ordenar, transformar y agrupar información.

### Ejemplo

```csharp
List<int> numeros = new List<int>()
{
    1,2,3,4,5,6,7,8,9,10
};

var resultado =
numeros.Where(numero => numero > 5);
```

### Explicación

```csharp
Where(...)
```

Permite filtrar elementos dentro de una colección.

```csharp
numero => numero > 5
```

Representa una expresión lambda que selecciona únicamente los números mayores que cinco.

### Resultado

```text
6
7
8
9
10
```

---

## Uso de LINQ con Arrays

Los arreglos son una de las estructuras de datos más utilizadas en C# y pueden consultarse fácilmente mediante LINQ.

### Ejemplo

```csharp
int[] edades =
{
    15,18,22,30,12,45,50
};

var mayoresEdad =
edades.Where(edad => edad >= 18);
```

### Explicación

La consulta recorre cada elemento del arreglo y selecciona únicamente las edades iguales o superiores a dieciocho años.

### Resultado

```text
18
22
30
45
50
```

---

## Uso de LINQ con Listas

Las listas permiten almacenar cantidades dinámicas de información y son ampliamente utilizadas junto con LINQ.

### Ejemplo

```csharp
List<string> nombres =
new List<string>()
{
    "Carlos",
    "Ana",
    "Pedro",
    "María"
};

var resultado =
nombres.Where(nombre => nombre.StartsWith("P"));
```

### Explicación

```csharp
StartsWith("P")
```

Permite identificar los nombres que comienzan con la letra P.

### Resultado

```text
Pedro
```

---

## Filtrado de Datos con Where()

El método `Where()` permite seleccionar únicamente los elementos que cumplen una condición determinada.

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    5,10,15,20,25,30
};

var resultado =
numeros.Where(numero => numero >= 20);
```

### Explicación

La condición especificada filtra todos los números menores a veinte.

### Resultado

```text
20
25
30
```

---

## Transformación de Datos con Select()

El método `Select()` permite transformar los elementos de una colección en nuevos valores.

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
nombres.Select(nombre => nombre.ToUpper());
```

### Explicación

Cada elemento de la colección es convertido a letras mayúsculas.

### Resultado

```text
CARLOS
ANA
PEDRO
```

---

## Ordenamiento Ascendente con OrderBy()

El método `OrderBy()` permite ordenar los elementos de una colección de menor a mayor.

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    8,3,5,1,9,2
};

var ordenados =
numeros.OrderBy(numero => numero);
```

### Explicación

La consulta organiza los números en orden ascendente.

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

## Ordenamiento Descendente con OrderByDescending()

También es posible ordenar los elementos de mayor a menor.

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    8,3,5,1,9,2
};

var ordenados =
numeros.OrderByDescending(numero => numero);
```

### Explicación

La colección es organizada en orden descendente.

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

## Agrupación de Datos con GroupBy()

El método `GroupBy()` permite organizar elementos en grupos utilizando una característica común.

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
nombres.GroupBy(nombre => nombre[0]);
```

### Explicación

Los nombres son agrupados utilizando la primera letra como criterio de clasificación.

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

## Conteo de Elementos con Count()

El método `Count()` devuelve la cantidad total de elementos presentes en una colección.

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

### Explicación

La consulta cuenta todos los elementos almacenados en la lista.

### Resultado

```text
3
```

---

## Operaciones Matemáticas con LINQ

LINQ incorpora diversos métodos para realizar cálculos sobre colecciones numéricas.

### Suma con Sum()

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

### Promedio con Average()

```csharp
double promedio =
ventas.Average();
```

### Resultado

```text
200
```

### Valor Máximo con Max()

```csharp
int maximo =
ventas.Max();
```

### Resultado

```text
300
```

### Valor Mínimo con Min()

```csharp
int minimo =
ventas.Min();
```

### Resultado

```text
100
```

---

## Obtención de Elementos con First()

El método `First()` devuelve el primer elemento que cumple una condición determinada.

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
numeros.First(numero => numero > 3);
```

### Explicación

La consulta devuelve el primer número mayor que tres.

### Resultado

```text
4
```

---

## Obtención Segura con FirstOrDefault()

El método `FirstOrDefault()` devuelve el primer elemento encontrado o un valor predeterminado cuando no existe coincidencia.

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
numeros.FirstOrDefault(numero => numero > 10);
```

### Explicación

Como ningún elemento cumple la condición, se devuelve el valor predeterminado para el tipo entero.

### Resultado

```text
0
```

---

## Verificación con Any()

El método `Any()` permite determinar si existe al menos un elemento que cumpla una condición.

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    1,3,5,8
};

bool existe =
numeros.Any(numero => numero % 2 == 0);
```

### Explicación

La consulta verifica si existe algún número par dentro de la colección.

### Resultado

```text
True
```

---

## Validación con All()

El método `All()` permite comprobar si todos los elementos cumplen una condición determinada.

### Ejemplo

```csharp
List<int> numeros =
new List<int>()
{
    2,4,6,8
};

bool resultado =
numeros.All(numero => numero % 2 == 0);
```

### Explicación

Todos los números de la colección son pares.

### Resultado

```text
True
```

---

## Uso de LINQ con Objetos Personalizados

LINQ también puede utilizarse sobre clases creadas por el desarrollador.

### Ejemplo

```csharp
public class Producto
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
}

List<Producto> productos =
new List<Producto>()
{
    new Producto { Nombre = "Laptop", Precio = 1200 },
    new Producto { Nombre = "Mouse", Precio = 25 },
    new Producto { Nombre = "Monitor", Precio = 300 }
};

var resultado =
productos.Where(producto => producto.Precio > 100);
```

### Explicación

La consulta selecciona únicamente los productos cuyo precio supera los cien dólares.

### Resultado

```text
Laptop
Monitor
```

---

## Caso Práctico

Supóngase una aplicación de inventario que almacena productos en una lista.

### Ejemplo

```csharp
List<string> productos =
new List<string>()
{
    "Laptop",
    "Mouse",
    "Teclado",
    "Monitor"
};

var resultado =
productos.Where(producto => producto.Contains("o"));
```

### Explicación

La consulta selecciona todos los productos cuyo nombre contiene la letra "o".

### Resultado

```text
Mouse
Teclado
Monitor
```

---

## Ventajas de LINQ to Objects

### Menor cantidad de código

Permite realizar consultas complejas utilizando pocas líneas de código.

### Mayor legibilidad

Las consultas son más fáciles de comprender y mantener.

### Integración con C#

Forma parte del lenguaje y no requiere herramientas adicionales.

### Productividad

Reduce significativamente el tiempo de desarrollo.

### Reutilización

Las consultas pueden combinarse y reutilizarse fácilmente.

---

## Desventajas de LINQ to Objects

### Consumo de memoria

Los datos deben encontrarse cargados en memoria para poder ser consultados.

### Rendimiento en grandes volúmenes

Puede resultar menos eficiente cuando se trabaja con colecciones extremadamente grandes.

### Curva de aprendizaje

Requiere comprender conceptos como expresiones lambda y delegados.

### Complejidad en consultas avanzadas

Las consultas muy extensas pueden resultar difíciles de interpretar.

---

## Conclusión

LINQ to Objects constituye la implementación más utilizada de LINQ debido a que permite consultar colecciones almacenadas en memoria de manera sencilla y eficiente. Mediante operadores como `Where()`, `Select()`, `OrderBy()`, `GroupBy()` y `Count()`, los desarrolladores pueden filtrar, transformar, ordenar y analizar información utilizando una sintaxis clara y uniforme. Su dominio resulta fundamental antes de trabajar con tecnologías más avanzadas como LINQ to SQL, LINQ to Entities o Entity Framework.
