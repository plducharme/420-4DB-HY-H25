using EFCoreUnitTests.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JeuxOlympiquesService.Tests
{
    public class TestDatabaseFixture
    {
    

        private static readonly object _lock = new();
        private static bool _databaseInitialized;
        private static _4dbJeuxOlympiqueContext? _context;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        if (context.Database.EnsureCreated())
                        {
                            Console.WriteLine("Database Created");

                            context.AddRange(
                                new Entraineur { Nom = "Langevin", Prenom = "Lucie", Id = 1 },
                                new Entraineur { Nom = "Laprise", Prenom = "Lee", Id = 2 });
                            context.SaveChanges();
                        }
                  

                    }

                    _databaseInitialized = true;
                }
            }
        }

        public _4dbJeuxOlympiqueContext CreateContext() {
            if (_context == null)
            {

                var _connection = new SqliteConnection("DataSource=file::memory:?cache=shared");
                _connection.Open();

                var _options = new DbContextOptionsBuilder<_4dbJeuxOlympiqueContext>().UseSqlite(_connection).Options;

                return new _4dbJeuxOlympiqueContext(_options);
            }
            return _context;
        }



    }
}
