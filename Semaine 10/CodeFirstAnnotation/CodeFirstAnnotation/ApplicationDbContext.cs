using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstAnnotation
{
    public class ApplicationDbContext : DbContext
    {
        public string DbPath { get; }

        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Produit> Produits { get; set; }


        public ApplicationDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "commandes.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // On configure l'Enum pour qu'elle soit persistée en string plutôt qu'en int dans la BD
            modelBuilder.Entity<Commande>()
                .Property(c => c.Statut)
                .HasConversion<string>(
                    // Conversion de l'énumération en String pour que le nom de l'enum soit persisté dans la BD au lieu de 1,2,3
                    v => v.ToString(),
                    // Conversion vers l'Enum lors que l'on lit depuis la BD
                    v => (Statut)Enum.Parse(typeof(Statut), v)
                );
        }

    }

    
}
