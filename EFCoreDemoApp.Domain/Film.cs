using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemoApp.Domaine
{
  public class Film
  {
    public int Id { get; set; }
    public string Nom { get; set; }
    public List<Acteur> Acteurs { get; set; } = new List<Acteur>();
  }
}
