using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> ventas = new List<int>()
        {
            100,
            250,
            300,
            150,
            400
        };

        Console.WriteLine("Cantidad: " + ventas.Count());
        Console.WriteLine("Suma: " + ventas.Sum());
        Console.WriteLine("Promedio: " + ventas.Average());
        Console.WriteLine("Máximo: " + ventas.Max());
        Console.WriteLine("Mínimo: " + ventas.Min());
    }
}
