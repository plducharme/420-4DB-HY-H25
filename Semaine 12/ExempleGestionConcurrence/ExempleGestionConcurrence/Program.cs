using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Globalization;

namespace ExempleGestionConcurrence
{
    /// <summary>
    /// Auteur :      Hugo St-Louis
    /// Description : Expérimentation avec la gestion de la concurrence 
    ///               avec Entity Framework Core.
    /// Date :        2023-04-20              
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            IdentifierErreurConcurrent();
            //ErreurConcurrentServeurWins();
            //ErreurConcurrentClientWins();

        }

        /// <summary>
        /// Permet d'identifier une erreur de concurrence.
        /// </summary>
        private static void IdentifierErreurConcurrent()
        {

            using (_4dbProgrammingefdb1Context context = new _4dbProgrammingefdb1Context())
            {
                Contact c = context.Contacts.FirstOrDefault();
                if (c != null)
                {
                    c.ModifiedDate = c.ModifiedDate.AddDays(1);
                    byte[] originalRowVersion = c.RowVersion;
                    try
                    {
                        context.SaveChanges();
                        byte[] newRowVersion = c.RowVersion;
                        if (originalRowVersion != newRowVersion)
                            Console.WriteLine("Les rowsversion on changés!");
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Erreur de concurrence " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Expérimentation d'une mise à jour avec une erreur de concurrence dans le 
        /// cas ou le serveur gagne.
        /// </summary>
        private static void ErreurConcurrentServeurWins()
        {

            using (_4dbProgrammingefdb1Context context = new _4dbProgrammingefdb1Context())
            {
                Contact c = context.Contacts.FirstOrDefault();
                if (c != null)
                {
                    c.ModifiedDate = c.ModifiedDate.AddDays(1);
                    c.FirstName = c.FirstName + "1";
                    byte[] originalRowVersion = c.RowVersion;
                    try
                    {
                        context.SaveChanges();
                        byte[] newRowVersion = c.RowVersion;
                        if (originalRowVersion != newRowVersion)
                            Console.WriteLine("Les rowsversion on changés!");
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        //Metttre à jour les données (Original et Current) à partir de
                        //la base de données.
                        foreach (EntityEntry entry in ex.Entries)
                            entry.Reload();

                        Console.WriteLine("Erreur de concurrence dans le scénario Serveur Win" +
                                          ex.Message);
                        context.SaveChanges();

                    }
                }
            }
        }


        /// <summary>
        /// Expérimentation d'une mise à jour avec une erreur de concurrence dans le 
        /// cas ou le client gagne.
        /// </summary>
        private static void ErreurConcurrentClientWins()
        {

            using (_4dbProgrammingefdb1Context context = new _4dbProgrammingefdb1Context())
            {
                Contact c = context.Contacts.FirstOrDefault();
                if (c != null)
                {
                    c.ModifiedDate = c.ModifiedDate.AddDays(1);
                    byte[] originalRowVersion = c.RowVersion;
                    try
                    {
                        context.SaveChanges();
                        byte[] newRowVersion = c.RowVersion;
                        if (originalRowVersion != newRowVersion)
                            Console.WriteLine("Le rowsversion a changé!");
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        bool bUpdated = false;
                        do
                        {
                            try
                            {
                                //Metttre à jour les données (Original) à partir de la base de données et restaurer les modifications dans l'entité.
                                //Réessayer de sauvegarder
                                foreach (EntityEntry entry in ex.Entries)
                                {
                                    PropertyValues? dbPropertyValues = entry.GetDatabaseValues();
                                    if (dbPropertyValues != null)
                                    {
                                        entry.OriginalValues.SetValues(dbPropertyValues);
                                        entry.CurrentValues.SetValues(entry.Entity);
                                    }
                                    else
                                    {

                                        // L'enregistrement n'existe plus, créer une nouvelle entité ContactConcurrent
                                        Contact c2 = (Contact)entry.Entity;
                                        c2.ContactId = 0;
                                        c2.RowVersion = null;
                                        entry.State = EntityState.Added;

                                    }
                                }
                                context.SaveChanges();
                                bUpdated = true;
                            }
                            catch (DbUpdateConcurrencyException ex_2)
                            {
                                Console.WriteLine("Encore!?!?");
                            }
                        }
                        while (bUpdated == false);
                        Console.WriteLine("Erreur de concurrence dans le scénario Client Wins" +
                                            ex.Message);
                    }
                }
            }
        }
    }
}