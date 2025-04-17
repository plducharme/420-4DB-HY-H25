using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstFluentAPI.Modele
{
    internal class ApplicationDbContext : DbContext
    {
        public string DbPath { get; }

        public DbSet<Musicien> Musiciens { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<Album> Albums { get; set; }



        public ApplicationDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Musique.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Musicien>().Property(m => m.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Musicien>().Property(m => m.Nom)
                .HasColumnName("Nom")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(1)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Musicien>().Property(m => m.Prenom)
                .HasColumnName("Prenom")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(2)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Musicien>().Property(m => m.DateNaissance)
                .HasColumnName("DateNaissance")
                .HasColumnType("datetime")
                .HasColumnOrder(3)
                .IsRequired()
                .HasDefaultValue(new DateTime(1970, 1, 1));
            modelBuilder.Entity<Musicien>().ToTable("Musiciens", "dbo");
            modelBuilder.Entity<Musicien>().HasKey(m => m.Id);

            //Relations many to many
            modelBuilder.Entity<Musicien>().HasMany(m => m.Groupes)
                .WithMany(g => g.Musiciens)
                .UsingEntity(j => j.ToTable("MusicienGroupe"));
            

            modelBuilder.Entity<Groupe>().Property(g => g.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Groupe>().Property(g => g.Nom)
                .HasColumnName("Nom")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(1)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Groupe>().Property(g => g.DateCreation)
                .HasColumnName("DateCreation")
                .HasColumnType("datetime")
                .HasColumnOrder(2)
                .IsRequired()
                .HasDefaultValue(new DateTime(1970, 1, 1));
            modelBuilder.Entity<Groupe>().Property(g => g.Genre)
                .HasColumnName("Genre")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(3)
                .HasDefaultValue("Générique")
                .HasMaxLength(50);



            modelBuilder.Entity<Album>().Property(g => g.Id)
                .HasColumnName("Id")
                .HasColumnOrder(0)
                .IsRequired()
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Album>().Property(a => a.Nom)
                .HasColumnName("Nom")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(1)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Album>().Property(a => a.Année)
                .HasColumnName("Année")
                .HasColumnType("int")
                .HasColumnName("AnneeDeSortie")
                .HasColumnOrder(2)
                .IsRequired()
                .HasDefaultValue(1970);
            modelBuilder.Entity<Album>().Property(a => a.GroupeId)
                .HasColumnName("GroupeId")
                .HasColumnType("int")
                .HasColumnOrder(3)
                .IsRequired();
            modelBuilder.Entity<Album>().ToTable("Albums", "dbo");
            modelBuilder.Entity<Album>().HasKey(a => a.Id);
            modelBuilder.Entity<Album>().HasOne(a => a.Groupe)
                .WithMany(g => g.Albums)
                .HasForeignKey(a => a.GroupeId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
