using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstConvention
{
    public class ApplicationDBContext : DbContext
    {

        public string DbPath { get; }
        public ApplicationDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Automobile.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
            Console.WriteLine($"Base de données : {DbPath}");
        }

        public DbSet<Automobile> Automobiles { get; set; }
        public DbSet<Fabricant> Fabricants { get; set; }
        public DbSet<Pays> Pays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        

        }

    }
    


}
