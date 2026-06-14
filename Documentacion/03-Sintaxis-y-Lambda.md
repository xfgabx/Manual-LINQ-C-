# 3. Sintaxis de LINQ y Expresiones Lambda

## Introducción

LINQ proporciona dos formas principales para escribir consultas dentro del lenguaje C#: la sintaxis de consulta (Query Syntax) y la sintaxis de métodos (Method Syntax). Ambas permiten obtener los mismos resultados, aunque presentan diferencias en la forma en que se escriben las consultas.

La sintaxis de consulta posee una estructura similar al lenguaje SQL, mientras que la sintaxis de métodos utiliza llamadas a funciones y expresiones lambda para construir las consultas.

En aplicaciones modernas desarrolladas con C# y Entity Framework, la sintaxis de métodos es la más utilizada debido a su flexibilidad y facilidad de integración con otras herramientas del ecosistema .NET.

---

## Sintaxis de Consulta (Query Syntax)

La sintaxis de consulta permite construir consultas utilizando palabras clave especiales como `from`, `where`, `select`, `orderby` y `group`.

Su apariencia es similar a una consulta SQL tradicional.

### Ejemplo

```csharp
List<int> numeros = new List<int>()
{
    10, 20, 30, 40, 50
};

var resultado =
from numero in numeros
where numero > 25
select numero;
```

### Explicación

```csharp
from numero in numeros
```

Permite recorrer la colección denominada `numeros`. La variable `numero` representa cada elemento encontrado durante el recorrido.

```csharp
where numero > 25
```

Filtra los datos y selecciona únicamente los números mayores a 25.

```csharp
select numero
```

Indica que los elementos que cumplen la condición serán devueltos por la consulta.

### Resultado

```text
30
40
50
```

---

## Sintaxis de Métodos (Method Syntax)

La sintaxis de métodos utiliza funciones proporcionadas por LINQ para construir consultas.

Esta forma de trabajo es ampliamente utilizada debido a que permite encadenar múltiples operaciones sobre una colección.

### Ejemplo

```csharp
List<int> numeros = new List<int>()
{
    10, 20, 30, 40, 50
};

var resultado =
numeros.Where(numero => numero > 25);
```

### Explicación

```csharp
Where(...)
```

Permite filtrar elementos dentro de una colección.

```csharp
numero => numero > 25
```

Representa una expresión lambda que indica que únicamente se seleccionarán los números mayores a 25.

### Resultado

```text
30
40
50
```

---

## Diferencias entre Query Syntax y Method Syntax

| Query Syntax                         | Method Syntax                      |
| ------------------------------------ | ---------------------------------- |
| Similar a SQL                        | Similar a métodos de C#            |
| Más intuitiva para principiantes     | Más utilizada profesionalmente     |
| Menor flexibilidad                   | Mayor flexibilidad                 |
| Menos utilizada con Entity Framework | Muy utilizada con Entity Framework |

Ambas sintaxis generan el mismo resultado y pueden utilizarse según las necesidades del desarrollador.

---

## Expresiones Lambda

Las expresiones lambda son funciones anónimas utilizadas para representar operaciones, transformaciones o condiciones dentro de una consulta LINQ.

Su sintaxis general es:

```csharp
(parametros) => expresion
```

Las expresiones lambda constituyen uno de los elementos más importantes dentro de LINQ debido a que permiten construir consultas compactas y fáciles de leer.

---

## Ejemplo de Expresión Lambda

```csharp
numero => numero * 2
```

### Explicación

* `numero` representa el parámetro recibido.
* `=>` representa el operador lambda.
* `numero * 2` representa la operación realizada.

Resultado:

```text
Devuelve el valor recibido multiplicado por dos.
```

---

## Expresión Lambda con Múltiples Parámetros

```csharp
(x, y) => x + y
```

### Explicación

La expresión recibe dos valores, realiza una suma y devuelve el resultado obtenido.

---

## Expresión Lambda con Cadenas de Texto

```csharp
nombre => nombre.ToUpper()
```

### Explicación

La expresión recibe una cadena de texto y devuelve el contenido convertido a letras mayúsculas.

---

## Uso de Lambda con Where()

### Ejemplo

```csharp
List<int> numeros = new List<int>()
{
    1,2,3,4,5,6,7,8
};

var pares =
numeros.Where(numero => numero % 2 == 0);
```

### Explicación

La condición:

```csharp
numero % 2 == 0
```

permite identificar los números pares dentro de la colección.

### Resultado

```text
2
4
6
8
```

---

## Uso de Lambda con Select()

### Ejemplo

```csharp
List<string> nombres = new List<string>()
{
    "Carlos",
    "Ana",
    "Pedro"
};

var resultado =
nombres.Select(nombre => nombre.ToUpper());
```

### Explicación

```csharp
Select(...)
```

permite transformar los elementos de una colección.

La expresión:

```csharp
nombre => nombre.ToUpper()
```

convierte cada nombre a letras mayúsculas.

### Resultado

```text
CARLOS
ANA
PEDRO
```

---

## Delegados Utilizados por LINQ

LINQ utiliza diferentes tipos de delegados para representar comportamientos específicos.

Los más utilizados son:

* Func<>
* Action<>
* Predicate<>

---

## Func<>

Representa una función que recibe parámetros y devuelve un valor.

### Ejemplo

```csharp
Func<int, int> duplicar =
numero => numero * 2;
```

### Uso

```csharp
Console.WriteLine(duplicar(10));
```

### Resultado

```text
20
```

---

## Action<>

Representa una función que recibe parámetros pero no devuelve ningún valor.

### Ejemplo

```csharp
Action<string> mostrarMensaje =
mensaje => Console.WriteLine(mensaje);
```

### Uso

```csharp
mostrarMensaje("Hola Mundo");
```

### Resultado

```text
Hola Mundo
```

---

## Predicate<>

Representa una función que devuelve un valor booleano.

### Ejemplo

```csharp
Predicate<int> esPar =
numero => numero % 2 == 0;
```

### Uso

```csharp
Console.WriteLine(esPar(10));
```

### Resultado

```text
True
```

---

## Ventajas de las Expresiones Lambda

### Menor cantidad de código

Permiten escribir consultas más compactas y legibles.

### Mayor productividad

Reducen el tiempo necesario para desarrollar consultas complejas.

### Integración con LINQ

Son la base de funcionamiento de la mayoría de operadores utilizados por LINQ.

### Facilidad de mantenimiento

Las consultas son más fáciles de comprender y modificar.

---

## Conclusión

La sintaxis de consulta y la sintaxis de métodos constituyen las dos formas principales de trabajar con LINQ. Aunque ambas generan resultados equivalentes, la sintaxis de métodos es la más utilizada en aplicaciones modernas debido a su flexibilidad. Las expresiones lambda representan uno de los pilares fundamentales de LINQ y permiten construir consultas más compactas, legibles y eficientes.

