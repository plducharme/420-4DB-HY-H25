using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConcurrence
{
    class JeuxDBContext : DbContext
    {
        public DbSet<Jeu> Jeux { get; set; }
        public DbSet<Editeur> Editeurs { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = System.IO.Path.Join(path, "JeuConcur.mdf");
            optionsBuilder.UseSqlServer($"Server=(LocalDB)\\MSSQLLocalDB;AttachDbFileName={dbPath}");
            Console.WriteLine($"Base de données : {dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration des entités et des relations
            modelBuilder.Entity<Jeu>()
                .HasKey(j => j.Id);
            modelBuilder.Entity<Jeu>().Property(j => j.Version)
                .HasDefaultValue(new byte[8])
                .IsRowVersion()
                .IsConcurrencyToken(); // Configuration de la colonne de version pour la gestion de la concurrence
            modelBuilder.Entity<Jeu>()
                .HasOne(j => j.Editeur)
                .WithMany(e => e.Jeux)
                .HasForeignKey(j => j.EditeurId); // Clé étrangère vers Editeur


            modelBuilder.Entity<Editeur>()
                .HasKey(e => e.Id);
 
        }
    }
    
}
