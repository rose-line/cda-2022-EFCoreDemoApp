using System.Collections.Generic;

namespace EFCoreDemoApp.Domaine
{
  public class Acteur
  {
    public int Id { get; set; }
    public string Nom { get; set; }
    public List<Citation> Citations { get; set; } = new List<Citation>();
    public List<Film> Films { get; set; } = new List<Film>();
  }
}
