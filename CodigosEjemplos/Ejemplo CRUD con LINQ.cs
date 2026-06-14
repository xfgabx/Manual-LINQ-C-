using System;
using System.Collections.Generic;
using System.Linq;

class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
}

class Program
{
    static void Main()
    {
        List<Producto> productos = new List<Producto>();

        // CREATE
        productos.Add(new Producto
        {
            Id = 1,
            Nombre = "Mouse",
            Precio = 15
        });

        // READ
        var producto =
            productos.FirstOrDefault(p => p.Id == 1);

        Console.WriteLine(producto.Nombre);

        // UPDATE
        producto.Precio = 20;

        // DELETE
        productos.Remove(producto);

        Console.WriteLine("Registros restantes: "
                          + productos.Count);
    }
}
