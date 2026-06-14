// CAPA ENTIDADES

public class ProductoEntidad
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; }

    public double Precio { get; set; }
}

// CAPA DATOS

using System.Collections.Generic;
using System.Linq;

public class ProductoDatos
{
    private static List<ProductoEntidad> productos =
        new List<ProductoEntidad>();

    public void Guardar(ProductoEntidad producto)
    {
        productos.Add(producto);
    }

    public List<ProductoEntidad> Listar()
    {
        return productos;
    }

    public ProductoEntidad Buscar(int id)
    {
        return productos
            .FirstOrDefault(p => p.IdProducto == id);
    }

    public void Eliminar(int id)
    {
        var producto =
            productos.FirstOrDefault(p => p.IdProducto == id);

        if (producto != null)
        {
            productos.Remove(producto);
        }
    }
}

// CAPA NEGOCIO

using System.Collections.Generic;

public class ProductoNegocio
{
    ProductoDatos datos =
        new ProductoDatos();

    public void Guardar(ProductoEntidad producto)
    {
        datos.Guardar(producto);
    }

    public List<ProductoEntidad> Listar()
    {
        return datos.Listar();
    }

    public ProductoEntidad Buscar(int id)
    {
        return datos.Buscar(id);
    }

    public void Eliminar(int id)
    {
        datos.Eliminar(id);
    }
}

// CAPA PRESENTACION

using System;

class Program
{
    static void Main()
    {
        ProductoNegocio negocio =
            new ProductoNegocio();

        ProductoEntidad producto =
            new ProductoEntidad();

        producto.IdProducto = 1;
        producto.Nombre = "Mouse";
        producto.Precio = 15;

        // CREAR

        negocio.Guardar(producto);

        // R

        var encontrado =
            negocio.Buscar(1);

        Console.WriteLine(
            encontrado.Nombre);

        // DELETE

        negocio.Eliminar(1);

        Console.WriteLine(
            "Producto eliminado");
    }
}
