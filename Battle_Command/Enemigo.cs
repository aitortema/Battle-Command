using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Command
{
  public class Enemigo
  {
    // Atributos
    public string NombreEnemigo { get; set; }
    public int VidaEnemigo { get; set; }
    public int AtaqueEnemigo { get; set; }
    public int DefensaEnemigo { get; set; }

    // Constructor
    public Enemigo(string nombreEnemigo, int vidaEnemigo, int ataqueEnemigo, int defensaEnemigo)
    {
      NombreEnemigo = nombreEnemigo;
      VidaEnemigo = vidaEnemigo;
      AtaqueEnemigo = ataqueEnemigo;
      DefensaEnemigo = defensaEnemigo;
    }
  }
}
