using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConsoleApp1
{
  public partial class EFCoreDemoAppDataContext : DbContext
  {
    public EFCoreDemoAppDataContext()
    {
    }

    public EFCoreDemoAppDataContext(DbContextOptions<EFCoreDemoAppDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acteur> Acteurs { get; set; }
    public virtual DbSet<Citation> Citations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer("Data Source= (LocalDB)\\MSSQLLocalDB;Initial Catalog = EFCoreDemoAppData");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

      modelBuilder.Entity<Citation>(entity =>
      {
        entity.HasIndex(e => e.ActeurId, "IX_Citations_ActeurId");

        entity.HasOne(d => d.Acteur)
                  .WithMany(p => p.Citations)
                  .HasForeignKey(d => d.ActeurId);
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
