using EFCoreDemoApp.Domaine;
using EFCoreDemoApp.Donnees;
using System;
using System.Linq;

namespace EFCoreDemoApp.ConsoleUI
{
  class Program
  {
    private static readonly ActeurContext _context = new();

    private static void Main()
    {
      // On force EF Core à vérifier si la DB existe.
      // Sinon, EF va inférer le schéma en étudiant le DbContext
      // et créer automatiquement la DB
      // _context.Database.EnsureCreated();

      GetActeurs("Avant ajout");
      AjouterActeur();
      GetActeurs("Après ajout");
      Console.Write("Appuyez sur une touche...");
      Console.ReadKey();
    }

    private static void AjouterActeur()
    {
      var acteur = new Acteur { Nom = "Al Pacino" };
      _context.Acteurs.Add(acteur);
      _context.SaveChanges();
    }

    private static void GetActeurs(string message)
    {
      var acteurs = _context.Acteurs.ToList();
      Console.WriteLine($"{message} - Nombre d'acteurs  : {acteurs.Count}");
      foreach (var acteur in acteurs)
      {
        Console.WriteLine(acteur.Nom);
      }
    }
  }
}
