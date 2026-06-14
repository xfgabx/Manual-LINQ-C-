# 6. LINQ to XML

## Introducción

LINQ to XML es una implementación de LINQ diseñada para trabajar con documentos XML de manera sencilla, flexible y eficiente. Fue introducida en .NET Framework 3.5 como una alternativa moderna a tecnologías anteriores como XmlDocument y XPath.

Su principal objetivo es facilitar la lectura, creación, modificación y consulta de documentos XML utilizando una sintaxis integrada en C#. Gracias a LINQ to XML, los desarrolladores pueden manipular estructuras XML complejas mediante consultas similares a las utilizadas con colecciones de objetos.

Esta tecnología resulta especialmente útil en aplicaciones que intercambian información mediante archivos XML, servicios web, configuraciones de aplicaciones y sistemas de integración de datos.

---

## ¿Qué es LINQ to XML?

LINQ to XML es una API incluida en el espacio de nombres:

```csharp
System.Xml.Linq
```

Esta API proporciona clases que permiten representar documentos XML como objetos dentro de una aplicación .NET.

Entre las clases más importantes se encuentran:

* XDocument
* XElement
* XAttribute
* XComment
* XDeclaration
* XText

Estas clases permiten crear y manipular documentos XML utilizando una estructura orientada a objetos.

---

## Estructura Básica de un Documento XML

Antes de trabajar con LINQ to XML es importante comprender la estructura básica de un documento XML.

### Ejemplo

```xml
<productos>
    <producto>
        <nombre>Laptop</nombre>
        <precio>1200</precio>
    </producto>
    <producto>
        <nombre>Mouse</nombre>
        <precio>25</precio>
    </producto>
</productos>
```

### Explicación

El elemento principal se denomina:

```xml
<productos>
```

Dentro de él existen varios elementos:

```xml
<producto>
```

Cada producto contiene información adicional representada mediante elementos hijos.

---

## Creación de un Documento XML

LINQ to XML permite construir documentos XML directamente desde código.

### Ejemplo

```csharp
XDocument documento =
new XDocument(
    new XElement("productos",
        new XElement("producto",
            new XElement("nombre", "Laptop"),
            new XElement("precio", 1200)
        )
    )
);
```

### Explicación

```csharp
XDocument
```

Representa el documento XML completo.

```csharp
XElement
```

Representa cada nodo o elemento dentro del documento.

### Resultado

```xml
<productos>
  <producto>
    <nombre>Laptop</nombre>
    <precio>1200</precio>
  </producto>
</productos>
```

---

## Guardar un Documento XML

Una vez creado un documento XML, puede almacenarse en un archivo.

### Ejemplo

```csharp
documento.Save("productos.xml");
```

### Explicación

El método:

```csharp
Save()
```

Guarda el contenido XML en la ubicación especificada.

---

## Cargar un Documento XML

También es posible cargar documentos XML existentes.

### Ejemplo

```csharp
XDocument documento =
XDocument.Load("productos.xml");
```

### Explicación

```csharp
Load()
```

Lee el archivo XML y lo convierte en un objeto manipulable mediante LINQ.

---

## Acceso a Elementos XML

LINQ to XML permite acceder fácilmente a los elementos de un documento.

### Ejemplo

```csharp
string nombre =
documento.Root.Element("producto")
              .Element("nombre")
              .Value;
```

### Explicación

```csharp
Root
```

Obtiene el elemento raíz del documento.

```csharp
Element()
```

Permite acceder a elementos específicos.

```csharp
Value
```

Obtiene el contenido textual del elemento.

### Resultado

```text
Laptop
```

---

## Consultas con Descendants()

El método `Descendants()` permite obtener todos los elementos descendientes con un nombre determinado.

### Ejemplo

```csharp
var productos =
documento.Descendants("producto");
```

### Explicación

La consulta devuelve todos los elementos llamados:

```xml
<producto>
```

sin importar su nivel dentro del documento.

---

## Filtrado de Datos con Where()

LINQ to XML puede combinarse con operadores LINQ tradicionales.

### Ejemplo

```csharp
var productosCaros =
documento.Descendants("producto")
         .Where(producto =>
             (decimal)producto.Element("precio") > 100);
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

El método `Select()` permite proyectar información específica.

### Ejemplo

```csharp
var nombres =
documento.Descendants("producto")
         .Select(producto =>
             producto.Element("nombre").Value);
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

Los elementos XML también pueden ordenarse utilizando LINQ.

### Ejemplo

```csharp
var ordenados =
documento.Descendants("producto")
         .OrderBy(producto =>
             (decimal)producto.Element("precio"));
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

## Uso de Atributos XML

Los atributos permiten almacenar información adicional dentro de los elementos.

### Ejemplo

```xml
<producto id="1">
    <nombre>Laptop</nombre>
</producto>
```

### Ejemplo en C#

```csharp
XElement producto =
new XElement("producto",
    new XAttribute("id", 1),
    new XElement("nombre", "Laptop")
);
```

### Explicación

```csharp
XAttribute
```

Representa un atributo XML.

---

## Lectura de Atributos

Los atributos pueden recuperarse fácilmente.

### Ejemplo

```csharp
string id =
producto.Attribute("id").Value;
```

### Resultado

```text
1
```

---

## Modificación de Elementos XML

LINQ to XML permite actualizar información existente.

### Ejemplo

```csharp
producto.Element("nombre").Value =
"Laptop Gamer";
```

### Explicación

El contenido del elemento es reemplazado por un nuevo valor.

### Resultado

```xml
<nombre>Laptop Gamer</nombre>
```

---

## Eliminación de Elementos

También es posible eliminar nodos XML.

### Ejemplo

```csharp
producto.Remove();
```

### Explicación

El elemento seleccionado es eliminado completamente del documento.

---

## Agregar Nuevos Elementos

Los documentos XML pueden ampliarse dinámicamente.

### Ejemplo

```csharp
documento.Root.Add(
    new XElement("producto",
        new XElement("nombre", "Teclado"),
        new XElement("precio", 80)
    )
);
```

### Explicación

El nuevo producto es agregado al elemento raíz.

---

## Uso de LINQ to XML con Objetos

Es posible convertir objetos de C# en estructuras XML.

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

XElement xml =
new XElement("productos",
    productos.Select(producto =>
        new XElement("producto",
            new XElement("nombre", producto.Nombre),
            new XElement("precio", producto.Precio)
        )
    )
);
```

### Explicación

Cada objeto es transformado automáticamente en un elemento XML.

---

## Caso Práctico

Supóngase una aplicación que almacena información de productos en un archivo XML.

### Ejemplo

```csharp
var productosEconomicos =
documento.Descendants("producto")
         .Where(producto =>
             (decimal)producto.Element("precio") < 100);
```

### Explicación

La consulta obtiene todos los productos cuyo precio es inferior a cien dólares.

### Resultado

```text
Mouse
Teclado
```

---

## Ventajas de LINQ to XML

### Sintaxis sencilla

Permite trabajar con XML utilizando código claro y legible.

### Integración con LINQ

Puede combinarse con operadores como `Where()`, `Select()` y `OrderBy()`.

### Modelo orientado a objetos

Representa documentos XML mediante clases fáciles de utilizar.

### Flexibilidad

Facilita la creación, modificación y eliminación de elementos.

### Productividad

Reduce significativamente la cantidad de código necesaria para manipular XML.

---

## Desventajas de LINQ to XML

### Consumo de memoria

El documento completo suele cargarse en memoria.

### Rendimiento en archivos grandes

Puede resultar menos eficiente cuando se trabaja con documentos XML extremadamente extensos.

### Dependencia del formato XML

Requiere que los documentos mantengan una estructura válida.

### Curva de aprendizaje

Es necesario comprender tanto XML como los conceptos básicos de LINQ.

---

## Conclusión

LINQ to XML proporciona una forma moderna y eficiente de trabajar con documentos XML dentro de aplicaciones .NET. Gracias a clases como `XDocument`, `XElement` y `XAttribute`, los desarrolladores pueden crear, consultar, modificar y almacenar información XML utilizando una sintaxis clara y consistente. Su integración con LINQ facilita enormemente el procesamiento de datos estructurados y lo convierte en una herramienta fundamental para aplicaciones que intercambian información mediante XML.

