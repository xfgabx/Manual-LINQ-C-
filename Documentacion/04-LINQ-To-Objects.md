4. LINQ to Objects
Introducción

LINQ to Objects es una implementación de LINQ que permite realizar consultas sobre colecciones almacenadas en memoria. Estas colecciones pueden ser arreglos, listas, diccionarios, conjuntos de datos y objetos personalizados.

A diferencia de otras implementaciones de LINQ, como LINQ to SQL o LINQ to Entities, LINQ to Objects no requiere una conexión a una base de datos. Todas las operaciones se ejecutan directamente sobre los objetos que se encuentran cargados en memoria.

Esta implementación es una de las más utilizadas debido a su simplicidad y facilidad de aprendizaje, convirtiéndose en el punto de partida ideal para comprender el funcionamiento general de LINQ.

Funcionamiento de LINQ to Objects

LINQ to Objects trabaja principalmente sobre colecciones que implementan la interfaz:

IEnumerable<T>

Esta interfaz permite recorrer secuencialmente una colección y aplicar operaciones como filtrado, ordenamiento, agrupación y transformación de datos.

Ejemplo
List<int> numeros = new List<int>()
{
    1,2,3,4,5,6,7,8,9,10
};

var resultado =
numeros.Where(numero => numero > 5);
Explicación
Where(numero => numero > 5)

Permite seleccionar únicamente los números mayores a cinco.

Resultado
6
7
8
9
10
Uso de LINQ con Arreglos

Los arreglos representan una de las estructuras de datos más utilizadas en programación. LINQ permite consultar fácilmente los elementos almacenados dentro de ellos.

Ejemplo
int[] edades =
{
    15,18,22,30,12,45,50
};

var mayoresEdad =
edades.Where(edad => edad >= 18);
Explicación

La consulta filtra únicamente las edades iguales o superiores a dieciocho años.

Resultado
18
22
30
45
50
Uso de LINQ con Listas

Las listas son colecciones dinámicas ampliamente utilizadas en aplicaciones desarrolladas con C#.

Ejemplo
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
Explicación
StartsWith("P")

Permite seleccionar únicamente los nombres que comienzan con la letra P.

Resultado
Pedro
Transformación de Datos con Select()

El método Select() permite modificar o transformar cada elemento de una colección.

Ejemplo
List<string> nombres =
new List<string>()
{
    "Carlos",
    "Ana",
    "Pedro"
};

var resultado =
nombres.Select(nombre => nombre.ToUpper());
Explicación
ToUpper()

Convierte cada nombre almacenado en la colección a letras mayúsculas.

Resultado
CARLOS
ANA
PEDRO
Ordenamiento con OrderBy()

LINQ permite ordenar los elementos de una colección de forma ascendente.

Ejemplo
List<int> numeros =
new List<int>()
{
    8,3,5,1,9,2
};

var ordenados =
numeros.OrderBy(numero => numero);
Resultado
1
2
3
5
8
9
Ordenamiento Descendente con OrderByDescending()

También es posible ordenar los datos de forma descendente.

Ejemplo
List<int> numeros =
new List<int>()
{
    8,3,5,1,9,2
};

var ordenados =
numeros.OrderByDescending(numero => numero);
Resultado
9
8
5
3
2
1
Agrupación con GroupBy()

El método GroupBy() permite agrupar elementos que comparten una característica común.

Ejemplo
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
Explicación

Los nombres serán agrupados según su primera letra.

Resultado
C
Carlos
Camila

P
Pedro
Pablo

A
Ana
Conteo de Elementos con Count()

El método Count() permite conocer la cantidad de elementos existentes en una colección.

Ejemplo
List<string> nombres =
new List<string>()
{
    "Carlos",
    "Ana",
    "Pedro"
};

int cantidad =
nombres.Count();
Resultado
3
Suma de Valores con Sum()

El método Sum() permite sumar todos los valores numéricos de una colección.

Ejemplo
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
Resultado
800
Promedio de Valores con Average()

Permite calcular el promedio de los elementos numéricos de una colección.

Ejemplo
List<int> notas =
new List<int>()
{
    8,
    9,
    10,
    7,
    9
};

double promedio =
notas.Average();
Resultado
8.6
Obtención del Valor Máximo con Max()

Permite obtener el valor más alto dentro de una colección.

Ejemplo
List<int> numeros =
new List<int>()
{
    5,
    8,
    10,
    3
};

int maximo =
numeros.Max();
Resultado
10
Obtención del Valor Mínimo con Min()

Permite obtener el valor más pequeño dentro de una colección.

Ejemplo
List<int> numeros =
new List<int>()
{
    5,
    8,
    10,
    3
};

int minimo =
numeros.Min();
Resultado
3
Búsqueda de Elementos con First()

El método First() devuelve el primer elemento que cumple una condición determinada.

Ejemplo
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
Resultado
4
Búsqueda Segura con FirstOrDefault()

Permite obtener el primer elemento que cumple una condición o devolver un valor predeterminado si no existe.

Ejemplo
List<int> numeros =
new List<int>()
{
    2,
    4,
    6
};

int resultado =
numeros.FirstOrDefault(numero => numero > 10);
Resultado
0
Ventajas de LINQ to Objects
Menor cantidad de código

Reduce significativamente la cantidad de líneas necesarias para procesar colecciones.

Mayor legibilidad

Las consultas son más fáciles de comprender y mantener.

Integración con C#

No requiere herramientas externas para funcionar.

Productividad

Permite desarrollar soluciones de forma más rápida.

Reutilización

Las consultas pueden reutilizarse en diferentes partes de una aplicación.

Desventajas de LINQ to Objects
Consumo de memoria

Los datos deben encontrarse cargados en memoria para poder ser procesados.

Rendimiento

En colecciones extremadamente grandes puede resultar menos eficiente que otras alternativas especializadas.

Curva de aprendizaje

Es necesario comprender expresiones lambda y operadores LINQ.

Caso Práctico

Supóngase una aplicación de inventario que almacena productos en una lista.

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
Explicación

La consulta selecciona todos los productos que contienen la letra "o".

Resultado
Mouse
Teclado
Monitor
Conclusión

LINQ to Objects permite realizar consultas sobre colecciones almacenadas en memoria utilizando una sintaxis uniforme y fácil de comprender. Gracias a operadores como Where(), Select(), OrderBy(), GroupBy() y Count(), es posible filtrar, transformar, ordenar y analizar información de manera eficiente. Esta implementación constituye la base para comprender las demás variantes de LINQ utilizadas en bases de datos, archivos XML y aplicaciones empresariales.
