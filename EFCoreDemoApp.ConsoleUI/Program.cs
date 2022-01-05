using EFCoreDemoApp.Domaine;
using EFCoreDemoApp.Donnees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

    private static void RecupEtSupprimerActeur()
    {
      var acteur = _context.Acteurs.Find(3);
      _context.Acteurs.Remove(acteur);
      _context.SaveChanges();
    }

    private static void InsererRelation()
    {
      var acteur = new Acteur
      {
        Nom = "Arnold Schwarzenegger",
        Citations = new List<Citation>
        {
          new Citation { Texte = "I'll be back" },
          new Citation { Texte = "Sarah Connor?" }
        }
      };
      _context.Acteurs.Add(acteur);
      _context.SaveChanges();
    }

    private static void InsererRelationAvecActeurExistant()
    {
      var acteur = _context.Acteurs.FirstOrDefault();
      acteur.Citations.Add(
        new Citation
        {
          Texte = "Hello!"
        });
      _context.SaveChanges();
    }

    private static void EagerLoading()
    {
      var acteursEtCitations = _context.Acteurs.Include(a => a.Citations).ToList();
      var enSplitQuery = _context.Acteurs.AsSplitQuery().Include(a => a.Citations).ToList();
      var avecFiltre = _context.Acteurs.Include(a => a.Citations.Where(c => c.Texte.Contains("Hello"))).ToList();
      var depuisUnParentSpecifique =
        _context.Acteurs.Where(a => a.Nom.Contains("Schwarz"))
                        .Include(a => a.Citations).FirstOrDefault();

      // Enfants et petits enfants
      //var acteursEtCitationsEtTraductions = _context.Acteurs.Include(a => a.Citations).ThenInclude(c => c.Traductions).ToList();

      // Petits enfants seulement
      //var acteursEtTraductions = _context.Acteurs.Include(a => a.Citations.Traductions).ToList();

      // Plusieurs catégories d'enfants
      //var acteursEtCitationsEtVoitures = _context.Acteurs.Include(a => a.Citations).Include(a => a.Voitures).ToList();
    }

    private static void Projection()
    {
      // avec type anonyme
      var desProprietes = _context.Acteurs.Select(a => new { a.Id, a.Nom }).ToList();
      // avec type existant
      var idEtNoms = _context.Acteurs.Select(a => new IdEtNom(a.Id, a.Nom)).ToList();
    }

    public struct IdEtNom
    {
      public IdEtNom(int id, string nom)
      {
        Id = id;
        Nom = nom;
      }

      public int Id { get; }  
      public string Nom { get; }  

    }

    private static void LazyLoading()
    {
      var acteur = _context.Acteurs.Find(2);
      // Ne fonctionne que si Lazy Loading est activé explicitement
      var compteCitations = acteur.Citations.Count();
    }

    private static void FiltrageDeDonneeEnRelation()
    {
      var acteurs = _context.Acteurs
                            .Where(a => a.Citations.Any(c => c.Texte.Contains("hello")))
                            .ToList();
    }

    private static void UpdateDonneesEnRelation()
    {
      var acteur = _context.Acteurs.Include(a => a.Citations)
                                   .FirstOrDefault(a => a.Id == 2);
      acteur.Citations[0].Texte = "Wrong.";
      _context.Citations.Remove(acteur.Citations[1]);
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
