﻿// <auto-generated />
using EFCoreDemoApp.Donnees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreDemoApp.Donnees.Migrations
{
    [DbContext(typeof(ActeurContext))]
    [Migration("20211215082929_unaun-assistant")]
    partial class unaunassistant
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreDemoApp.Domaine.Acteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Acteurs");
                });

            modelBuilder.Entity("EFCoreDemoApp.Domaine.Assistant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActeurId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActeurId")
                        .IsUnique();

                    b.ToTable("Assistant");
                });

            modelBuilder.Entity("EFCoreDemoApp.Domaine.Citation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActeurId")
                        .HasColumnType("int");

                    b.Property<string>("Texte")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActeurId");

                    b.ToTable("Citations");
                });

            modelBuilder.Entity("EFCoreDemoApp.Domaine.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("EFCoreDemoApp.Donnees.ActeurFilm", b =>
                {
                    b.Property<int>("ActeurId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("MinutesALEcran")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(10);

                    b.HasKey("ActeurId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("ActeurFilm");
                });

            modelBuilder.Entity("EFCoreDemoApp.Domaine.Assistant", b =>
                {
                    b.HasOne("EFCoreDemoApp.Domaine.Acteur", null)
                        .WithOne("Assistant")
                        .HasForeignKey("EFCoreDemoApp.Domaine.Assistant", "ActeurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreDemoApp.Domaine.Citation", b =>
                {
                    b.HasOne("EFCoreDemoApp.Domaine.Acteur", "Acteur")
                        .WithMany("Citations")
                        .HasForeignKey("ActeurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acteur");
                });

            modelBuilder.Entity("EFCoreDemoApp.Donnees.ActeurFilm", b =>
                {
                    b.HasOne("EFCoreDemoApp.Domaine.Acteur", null)
                        .WithMany()
                        .HasForeignKey("ActeurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreDemoApp.Domaine.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreDemoApp.Domaine.Acteur", b =>
                {
                    b.Navigation("Assistant");

                    b.Navigation("Citations");
                });
#pragma warning restore 612, 618
        }
    }
}