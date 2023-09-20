using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Battle_Command
{
  public class Programa
  {
    public static Jugador jugador1;
    private static bool detenerAnim = false;

    public static void Main(string[] args)
    {
      Sonido.SonidoIntro();
      Thread hiloTitulo = new Thread(new ThreadStart(MostrarTituloAnimado));
      hiloTitulo.Start();
      Thread.Sleep(2500);
      detenerAnim = true;
      hiloTitulo.Join(); // Esperar a que el hilo termine
      jugador1 = Jugador.PedirNombreJugador();
      Historia historia = new Historia();
      Sonido.SonidoIntro2(); // Trucazo: así muestro la bienvenida
      historia.NavegarHistoria("H001_Intro", jugador1);
      Console.ReadKey();

    }

    // ========================================== MOSTRAR TITULO ANIMADO
    public static void MostrarTituloAnimado()
    {
      char[] simbolos = { '/', '-', '\\', '|' };
      int posicionSimbolo = 0;

      while (!detenerAnim)
      {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;

        // Animar la línea superior
        for (int i = 0; i < 38; i++)
        {
          Console.Write(simbolos[posicionSimbolo]);
        }
        Console.WriteLine();

        // Animar los caracteres antes y después del título
        for (int i = 0; i < 11; i++)
        {
          Console.Write(simbolos[posicionSimbolo]);
        }

        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("BATTLE COMMAND");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(" ");

        for (int i = 0; i < 11; i++)
        {
          Console.Write(simbolos[posicionSimbolo]);
        }

        Console.WriteLine();

        // Animar la línea inferior
        for (int i = 0; i < 38; i++)
        {
          Console.Write(simbolos[posicionSimbolo]);
        }
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("                      ©2023 a1t0rmenta");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine();

        // Actualiza el índice del símbolo para el próximo ciclo
        posicionSimbolo = (posicionSimbolo + 1) % simbolos.Length;

        // Pausa antes de la próxima iteración
        System.Threading.Thread.Sleep(200);
      }
    }

    // ========================================== MOSTRAR TITULO FIJO
    public static void MostrarTituloFijo()
    {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine("//////////////////////////////////////");
      Console.Write("//////////// ");
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write("BATTLE COMMAND");
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine(" //////////");
      Console.WriteLine("//////////////////////////////////////");
      Console.ForegroundColor = ConsoleColor.DarkMagenta;
      Console.WriteLine("                      ©2023 a1t0rmenta");
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine();
      Console.SetCursorPosition(0, 6);
    }
  }
}
