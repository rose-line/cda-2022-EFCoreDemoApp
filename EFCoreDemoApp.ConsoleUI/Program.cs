using EFCoreDemoApp.Domaine;
using EFCoreDemoApp.Donnees;
using Microsoft.EntityFrameworkCore;
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
      //AjouterActeurs("Robert De Niro", "Arnold Schwarzenegger", "Meg Ryan", "Sylvester Stallone");
      //GetActeurs("Après ajout");

      //Filtrer();

      //Aggregation();

      //RecupEtMAJ();

      RecupEtSupprimer();

      Console.Write("Appuyez sur une touche...");
      Console.ReadKey();
    }

    private static void RecupEtSupprimer()
    {
      var acteur = _context.Acteurs.Find(3);
      _context.Acteurs.Remove(acteur);
      _context.SaveChanges();
    }

    private static void RecupEtMAJ()
    {
      var acteur = _context.Acteurs.FirstOrDefault();
      acteur.Nom += "_SUFFIX";
      _context.SaveChanges();
      
      var acteurs = _context.Acteurs.Skip(1).Take(3).ToList();
      //foreach (var a in acteurs)
      //{
      //  a.Nom += "_SUFFIX";
      //}

      acteurs.ForEach(a => a.Nom += "_SUFFIX");

      _context.SaveChanges();
    }

    private static void Aggregation()
    {
      var nom = "Meg Ryan";
      //var acteur = _context.Acteurs.Where(a => a.Nom == nom).FirstOrDefault();
      var acteur = _context.Acteurs.FirstOrDefault(a => a.Nom == nom);

      var acteur2 = _context.Acteurs.Find(2);
    }

    private static void Filtrer()
    {
      string nomActeur = "Meg Ryan";
      var acteurFiltre = _context.Acteurs.Where(a => a.Nom == nomActeur).ToList();
    }

    //private static void AjouterActeur()
    //{
    //  var acteur = new Acteur { Nom = "Al Pacino" };
    //  _context.Acteurs.Add(acteur);
    //  _context.SaveChanges();
    //}

    private static void AjouterActeurs(params string[] noms)
    {
      foreach (var nom in noms)
      {
        _context.Acteurs.Add(new Acteur { Nom = nom });
      }
      _context.SaveChanges();
    }

    private static void GetActeurs(string message)
    {
      var acteurs = _context.Acteurs.TagWith("Méthode GetActeurs").ToList();
      Console.WriteLine($"{message} - Nombre d'acteurs  : {acteurs.Count}");
      foreach (var acteur in acteurs)
      {
        Console.WriteLine(acteur.Nom);
      }
    }
  }
}
