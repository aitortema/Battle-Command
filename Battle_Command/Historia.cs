using System;
using System.Collections.Generic;

namespace Battle_Command
{
  public class Historia
  {
    private int opcionSeleccionada = 0;
    private Dictionary<string, Func<string, (string[], int)>> historias;

    public Historia()
    {
      historias = new Dictionary<string, Func<string, (string[], int)>>()
      {
        { "H001_Intro", H001_Intro },
        { "H011_PuertaIzquierda", H011_PuertaIzquierda },
        { "H012_PuertaDerecha", H012_PuertaDerecha },
        { "H111_LeerCuaderno", H111_LeerCuaderno },
        { "H121_EncenderLinterna", H121_EncenderLinterna},
        { "H1211_NeutralizarObjetivo", H1211_NeutralizarObjetivo}
      };
    }

    public void NavegarHistoria(string historiaInicial, Jugador jugador)
    {
      string historiaActual = historiaInicial;

      while (true) // Navegación automática a partir de H001_Intro
      {
        if (historias.ContainsKey(historiaActual))
        {
          var historia = historias[historiaActual];
          (string[] opciones, int numOpciones) = historia(jugador.NombreJugador);
          Menu menu = new Menu(opciones);
          opcionSeleccionada = menu.MostrarYNavegarOpciones(opciones, () => historia(jugador.NombreJugador));

          if (historiaActual == "H001_Intro")
          {
            historiaActual = opcionSeleccionada == 0 ? "H011_PuertaIzquierda" : "H012_PuertaDerecha";
          }
          else if (historiaActual == "H011_PuertaIzquierda")
          {
            historiaActual = opcionSeleccionada == 0 ? "H111_LeerCuaderno" : "H001_Intro";
          }
          else if (historiaActual == "H111_LeerCuaderno")
          {
            historiaActual = "H001_Intro";
          }
          else if (historiaActual == "H012_PuertaDerecha")
          {
            historiaActual = opcionSeleccionada == 0 ? "H121_EncenderLinterna" : "H001_Intro";
          }
          else if (historiaActual == "H121_EncenderLinterna")
          {
            historiaActual = opcionSeleccionada == 0 ? "H1211_NeutralizarObjetivo" : "H001_Intro";
          }
          else if (historiaActual == "H1211_NeutralizarObjetivo")
          {
            Console.WriteLine("¡Objetivo neutralizado! Pulsa ENTER");
            Console.ReadLine();
          }
        }
        else
        {
          Console.WriteLine("¡Ups!, historia no encontrada. ");
          break;
        }
      }
    }

    public (string[], int) H001_Intro(string nombreJugador)
    {
      string[] opciones = { "Abrir la puerta izquierda. ", "Abrir la puerta derecha. " };
      int numOpciones = opciones.Length;

      Programa.MostrarTituloFijo();
      Console.Write("¡Vamos ");
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.Write(nombreJugador);
      Console.Write("!");
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine(", es hora de terminar esta misión. ");
      Console.WriteLine("Has acabado con muchos enemigos y la munición escasea. ");
      Console.WriteLine("El cargador de tu arma de mano tiene 3 balas y ");
      Console.WriteLine("en tu estado lo mejor sería evitar cualquier encuentro. ");
      Console.WriteLine("Estás en un pasillo con dos puertas al fondo. ");
      Console.WriteLine("El objetivo está cerca... ");
      Console.WriteLine();
      Console.WriteLine("¿Qué quieres hacer? ");

      for (int i = 0; i < opciones.Length; i++)
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(opciones[i]);
        Console.ForegroundColor = ConsoleColor.Gray;
      }
      Console.WriteLine();
      Console.WriteLine("Pulsa Enter para elegir...");
      Console.WriteLine();

      return (new string[] { "Abrir la puerta izquierda.", "Abrir la puerta derecha." }, 2);
    }

    public (string[], int) H011_PuertaIzquierda(string nombreJugador)
    {
      string[] opciones = { "Leer cuaderno ", "Volver al pasillo. " };
      //int numOpciones = opciones.Length;

      Programa.MostrarTituloFijo();
      Console.Write("Has elegido la puerta izquierda. ");
      Console.WriteLine();
      Console.WriteLine("Aparentemente no hay nadie en la habitación. ");
      Console.WriteLine("Miras alrededor. Es un despacho. ");
      Console.WriteLine("En la mesa hay un cuaderno manchado de sangre. ");
      Console.WriteLine("¿Qué quieres hacer? ");
      Console.WriteLine();
      for (int i = 0; i < opciones.Length; i++)
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(opciones[i]);
        Console.ForegroundColor = ConsoleColor.Gray;
      }
      Console.WriteLine();
      Console.WriteLine("Pulsa Enter para elegir...");
      Console.WriteLine();

      return (new string[] { "Leer cuaderno", "Volver al pasillo." }, 2);
    }

    public (string[], int) H012_PuertaDerecha(string nombreJugador)
    {
      string[] opciones = { "Encender la linterna ", "Volver al pasillo. " };
      int numOpciones = opciones.Length;

      Programa.MostrarTituloFijo();
      Console.Write("Has elegido la puerta derecha. ");
      Console.WriteLine();
      Console.WriteLine("La habitación está oscura. ");
      Console.WriteLine("Aparentemente no hay nadie. ");
      Console.WriteLine("¿Qué quieres hacer? ");
      Console.WriteLine();
      for (int i = 0; i < opciones.Length; i++)
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(opciones[i]);
        Console.ForegroundColor = ConsoleColor.Gray;
      }
      Console.WriteLine();
      Console.WriteLine("Pulsa Enter para elegir...");
      Console.WriteLine();

      return (new string[] { "Encender la linterna", "Volver al pasillo." }, 2);
    }

    public (string[], int) H111_LeerCuaderno(string nombreJugador)
    {
      string[] opciones = { "Volver al pasillo. " };

      Programa.MostrarTituloFijo();
      Console.Write("Has elegido leer el cuaderno. ");
      Console.WriteLine();
      Console.WriteLine("Nota: ");
      Console.WriteLine("Hace dos semanas que Petra se comporta de manera extraña. ");
      Console.WriteLine("Sospecho que ha escondido una muestra del T-Virus. ");
      Console.WriteLine("Pero no puedo pensar que quiera sacarla del laboratorio. ");
      Console.WriteLine("Es demasiado arriesgado. He decidido guardar las probetas. ");
      Console.WriteLine("La caja de seguridad es mi únic4 0pc10n. "); // Contraseña caja fuerte: 4010
      Console.WriteLine("¿Qué quieres hacer? ");
      Console.WriteLine();
      for (int i = 0; i < opciones.Length; i++)
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(opciones[i]);
        Console.ForegroundColor = ConsoleColor.Gray;
      }
      Console.WriteLine();
      Console.WriteLine("Pulsa Enter para elegir...");
      Console.WriteLine();

      return (new string[] { "Volver al pasillo." }, 1);
    }

    public (string[], int) H121_EncenderLinterna(string nombreJugador)
    {
      string[] opciones = { "Intenta neutralizar al objetivo. ", "¡Cierra la puerta!" };

      Programa.MostrarTituloFijo();
      Console.Write("Has elegido encender la linterna. ");
      Console.WriteLine("Miras alrededor. Es la habitación de Petra.");
      Console.WriteLine("En la cama hay ropa manchada de sangre. ");
      Console.Beep(400, 500);
      Console.WriteLine("Escuchas algo. ");
      Console.WriteLine("¡Hay algo detrás de la puerta! ");
      Console.WriteLine("¿Qué quieres hacer? ");
      Console.WriteLine();
      for (int i = 0; i < opciones.Length; i++)
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(opciones[i]);
        Console.ForegroundColor = ConsoleColor.Gray;
      }
      Console.WriteLine();
      Console.WriteLine("Pulsa Enter para elegir...");
      Console.WriteLine();

      return (new string[] { "Intenta neutralizar al objetivo.", "¡Cierra la puerta!" }, 2);
    }

    public (string[], int) H1211_NeutralizarObjetivo(string nombreJugador)
    {
      string[] opciones = { "Opción A ", "Opción B" };

      Programa.MostrarTituloFijo();
      Console.Write("Has elegido intentar neutralizar al objetivo. ");
      Console.WriteLine("PIM, PAM; PUM ");
      for (int i = 0; i < opciones.Length; i++)
      {
        Console.WriteLine(opciones[i]);
      }
      Console.WriteLine();
      Console.WriteLine("Pulsa Enter para elegir...");
      Console.WriteLine();

      return (new string[] { "Opción A", "Opción B" }, 2);
    }
  }
}

