namespace CodeFirstConvention
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDBContext())
            {
                // Supprime la base de données si elle existe et la recrée
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Console.WriteLine("Base de données créée avec succès.");
                Console.WriteLine("Ajout d'un fabricant, d'un pays et d'une automobile...");
                var pays = new Pays { PaysId = 1,Nom = "France" };
                var fabricant = new Fabricant { FabricantId = 1,Nom = "Renault", AnneeCreation = 1899, Pays = pays };
                var automobile = new Automobile { Id = 1, Modele = "Clio", Annee = 2020, Fabricant = fabricant };
                context.Pays.Add(pays);
                context.Fabricants.Add(fabricant);
                context.Automobiles.Add(automobile);
                context.SaveChanges();
            }
        }
    }
}
