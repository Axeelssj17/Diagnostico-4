// See https://aka.ms/new-console-template for more information
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

class Participante
{
    public int Nro { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Edad { get; set;  }
    public string Tiempo { get; set; }
    public double Altura { get; set; }
    public string Categoria { get; set; }

    public Participante(int nro, string nombre, string apellido, string edad, string tiempo, double altura, string categoria)
    {
        Nro = nro;
        Apellido = apellido;
        Nombre = nombre;
        Edad = edad;
        Tiempo = tiempo;
        Altura = altura;
        Categoria = categoria;
    }
}
class carrera
{
    List<Participante> participantes = new List<Participante>();
    public void CargarParticipantes()
    {
        while (true)
        {
            Console.WriteLine("Numero: ");
            int nro = int.Parse(Console.ReadLine());
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Apellido: ");
            string apellido = Console.ReadLine();
            Console.WriteLine("Edad: ");
            string edad = Console.ReadLine();
            Console.WriteLine("Tiempo: ");
            string tiempo = (Console.ReadLine());
            Console.WriteLine("Altura: ");
            double altura = double.Parse(Console.ReadLine());
            Console.WriteLine("Categoria: ");
            string categoria = Console.ReadLine();
            Console.WriteLine("Desea cargar otro participante? S/N");
            string respuesta = Console.ReadLine();
            if (respuesta.ToUpper() == "N")
            {
                break;
            }
            Participante p = new Participante(nro, nombre, apellido, edad, tiempo, altura, categoria);
            participantes.Add(p);

        }
    }
    public void GenerarReportes()
    {
        if (participantes.Count == 0)
        {
            Console.WriteLine("No hay participantes^registrados");
            return;
        }
        //General
        Participante mejorTiempoGeneral = participantes.OrderBy(p => p.Tiempo).First();
        Console.WriteLine("Mejor tiempo general: ");
        Console.WriteLine($"Numero: {mejorTiempoGeneral.Nro}:{mejorTiempoGeneral.Nombre} {mejorTiempoGeneral.Apellido} {mejorTiempoGeneral.Tiempo} segundos");
        //Por categoria
        var mejorPorCategoria = participantes.Select(p => p.Categoria).Distinct();
        foreach (string cat in mejorPorCategoria)
        {
            Participante mejorTiempoCategoria = participantes.Where(p => p.Categoria == cat).OrderBy(p => p.Tiempo).First();
            Console.WriteLine($"Mejor tiempo {cat}: ");
            Console.WriteLine($"Numero: {mejorTiempoCategoria.Nro}:{mejorTiempoCategoria.Nombre} {mejorTiempoCategoria.Apellido} {mejorTiempoCategoria.Tiempo} segundos");
        }
    }
        class program
            {
            static void Main(string[] args)
            {
                carrera c = new carrera();
                c.CargarParticipantes();
                c.GenerarReportes();
            }
        }
}
