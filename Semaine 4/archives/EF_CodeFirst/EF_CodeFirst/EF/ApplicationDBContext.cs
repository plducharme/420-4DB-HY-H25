using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.EF
{
    /// <summary>
    /// Auteur :      Hugo St-Louis
    /// Description : Context de mon EF Core.
    /// Date :        2023-01-31
    /// </summary>
    internal class ApplicationDBContext : DbContext
    {
        /// <summary>
        /// Permet de configurer les paramètres de mon EF Core
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=172.16.20.230;Initial Catalog=4DB-CODEFIRST;TrustServerCertificate=True; User ID=Etudiant;Password=Qwerty123!");
        }
        
        public DbSet<Personne_Hugo> Personne_Hugos { get; set; }
        public DbSet<Projet_Hugo> Projet_Hugos { get; set; }


    }
}
