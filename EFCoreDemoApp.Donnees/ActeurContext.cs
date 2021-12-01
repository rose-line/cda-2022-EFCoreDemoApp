using EFCoreDemoApp.Domaine;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoApp.Donnees
{
  public class ActeurContext : DbContext
  {
    public DbSet<Acteur> Acteurs { get; set; }
    public DbSet<Citation> Citations { get; set; }
    public DbSet<Film> Films { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
        "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=EFCoreDemoAppData");
    }
  }
}
