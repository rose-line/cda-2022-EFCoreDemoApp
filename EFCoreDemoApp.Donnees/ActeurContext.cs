using EFCoreDemoApp.Domaine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace EFCoreDemoApp.Donnees
{
  public class ActeurContext : DbContext
  {

    // (localdb)\MSSQLLocalDB
    public DbSet<Acteur> Acteurs { get; set; }
    public DbSet<Citation> Citations { get; set; }
    public DbSet<Film> Films { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
        "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=EFCoreDemoAppData")
        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
        LogLevel.Information)
        .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Acteur>()
        .HasMany(a => a.Films)
        .WithMany(f => f.Acteurs)
        .UsingEntity<ActeurFilm>(
          af => af.HasOne<Film>().WithMany(),
          af => af.HasOne<Acteur>().WithMany())
        .Property(af => af.MinutesALEcran)
        .HasDefaultValue(10);
    }
  }
}
