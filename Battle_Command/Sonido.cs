using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Command
{
  public class Sonido
  {
    public static void SonidoIntro()
    {
      Console.Beep(300, 700);
      Console.Beep(500, 500);
    }

    public static void SonidoIntro2()
    {
      Console.Beep(650, 900);
      Console.Beep(100, 100);
      Console.Beep(100, 100);
    }

    public static void SonidoPasos()
    {
      Console.Beep(400, 500);
    }
  }
}
