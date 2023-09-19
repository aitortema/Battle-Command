using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Command
{
  public class Menu
  {
    private string[] opcionesMenu;
    private int opcionSeleccionada = 0;

    public Menu(string[] opciones)
    {
      this.opcionesMenu = opciones;
    }

    public int MostrarYNavegarOpciones(string[] opcionesMenu, Action redraw)
    {
      opcionSeleccionada = 0;
      ConsoleKey teclaPulsada;

      do
      {
        Console.Clear();
        redraw();

        // Mostrar las opciones
        for (int i = 0; i < opcionesMenu.Length; i++)
        {
          string opcionElegida = opcionesMenu[i];
          string prefijo;
          string sufijo;

          if (i == opcionSeleccionada)
          {
            prefijo = "💠";
            sufijo = "💠";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
          }
          else
          {
            prefijo = " ";
            sufijo = " ";
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
          }

          Console.WriteLine($"{prefijo}{opcionElegida}{sufijo}");
        }
        Console.ResetColor();

        // Navegar por las opciones
        ConsoleKeyInfo infoTecla = Console.ReadKey(true);
        teclaPulsada = infoTecla.Key;

        if (teclaPulsada == ConsoleKey.UpArrow)
        {
          if (opcionSeleccionada == 0)
          {
            opcionSeleccionada = opcionesMenu.Length - 1;
          }
          else
          {
            opcionSeleccionada--;
          }
        }
        else if (teclaPulsada == ConsoleKey.DownArrow)
        {
          if (opcionSeleccionada == opcionesMenu.Length - 1)
          {
            opcionSeleccionada = 0;
          }
          else
          {
            opcionSeleccionada++;
          }
        }
      } while (teclaPulsada != ConsoleKey.Enter);

      return opcionSeleccionada;
    }
  }

}
