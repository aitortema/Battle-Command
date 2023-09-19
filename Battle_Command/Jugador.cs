using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Command
{
  public class Jugador
  {
    // Atributos
    public string NombreJugador { get; set; }
    private int Vida { get; set; }
    private int Ataque { get; set; }
    private int Defensa { get; set; }

    // Constructor
    public Jugador(string nombreJugador, int vida, int ataque, int defensa)
    {
      this.NombreJugador = nombreJugador;
      this.Vida = vida;
      this.Ataque = ataque;
      this.Defensa = defensa;
    }

    // ToString
    public override string ToString()
    {
      return string.Format("{0} (Vida: {1}, Ataque: {2}, Defensa: {3})", NombreJugador, Vida, Ataque, Defensa);
    }

    // ======================================== PEDIR NOMBRE JUGADOR
    public static Jugador PedirNombreJugador()
    {
      string nombre;

      do
      {
        Console.Clear();
        Programa.MostrarTituloFijo();
        Console.SetCursorPosition(0, 5);
        Console.WriteLine("Bienvenido a Battle Command. ");
        Console.WriteLine("Introduce tu nombre: ");
        Console.WriteLine("");
        nombre = Console.ReadLine();

        if (nombre == "" || nombre == null)
        {
          Console.WriteLine("El nombre no puede estar vacío. ");
          Console.WriteLine();
          Console.ReadLine();
        }
      } while (nombre == "" || nombre == null);

      Jugador nuevoJugador = new Jugador(nombre, 100, 100, 100);

      if (nombre == "Aitor")
      {
        Console.Write("Encantado de volver a verte ");
        Console.WriteLine("{0} 😀", nombre);
      }
      else
      {
        Console.Write("\nBienvenido ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("{0}", nombre);
        Console.ForegroundColor = ConsoleColor.Gray;
      }
      return nuevoJugador;
    }
  }
}
