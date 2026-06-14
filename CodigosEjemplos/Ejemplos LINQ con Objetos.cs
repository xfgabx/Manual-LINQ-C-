using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> estudiantes = new List<string>()
        {
            "Carlos",
            "Ana",
            "Pedro",
            "María",
            "Pablo"
        };

        var resultado = estudiantes
            .Where(nombre => nombre.StartsWith("P"))
            .OrderBy(nombre => nombre);

        Console.WriteLine("Estudiantes encontrados:");

        foreach (var estudiante in resultado)
        {
            Console.WriteLine(estudiante);
        }
    }
}
