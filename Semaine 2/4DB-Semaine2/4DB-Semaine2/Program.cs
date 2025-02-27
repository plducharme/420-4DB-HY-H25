using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4DB_Semaine2
{
    /// <summary>
    /// Auteur :      Hugo St-Louis
    /// Description : Expérimentation des requêtes avec EF.
    /// Date :        2022-02-07
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Ex#1
            using (ProgEF_Entities context = new ProgEF_Entities())
            {
                List<Contact> lstContacts = context.Contacts.ToList(); //Exécution de la requête se fait ici
                foreach (Contact c in lstContacts)
                    Console.WriteLine(c.FirstName + " - " + c.LastName);
                //Différence???????
                var contacts = context.Contacts;
                foreach (Contact c in contacts) //Exécution de la requête se fait ici
                    Console.WriteLine(c.FirstName + " - " + c.LastName);
            }

            //CAS À NE PAS FAIRE
            //using (ProgEF_Entities context = new ProgEF_Entities())
            //{
            //    //Cas #1 : Le double toList
            //    List<Contact> lstContacts = context.Contacts
            //                                       .ToList()
            //                                       .Where(c2=>c2.LastName == "Hernandez")
            //                                       .ToList(); 

            //    //Cas #2 
            //    lstContacts = context.Contacts.ToList();
            //    Contact c = lstContacts.FirstOrDefault(c1 => c1.LastName == "Hernandez");
            //    Console.WriteLine(c.FirstName + " - " + c.LastName);
            //}

            //Ex#2 - Propriété de navigation
            //using (ProgEF_Entities context = new ProgEF_Entities())
            //{
            //    DbSet<Contact> lstContacts = context.Contacts; //Exécution de la requête se fait ici
            //    foreach (Contact c in lstContacts)
            //    { 
            //        Console.WriteLine(c.FirstName + " - " + c.LastName);
            //        foreach(Address a in c.Addresses)
            //            Console.WriteLine(a.City);
            //    }
            //}

            //Ex 3
            //ProgEF_Entities context;
            //using (context = new ProgEF_Entities())
            //{
            //    var c2 = context.Contacts.Where(c => c.FirstName == "Hugo")
            //                             .Select(c => c.FirstName + " " + c.LastName);
            //    List<string> lstC2 = c2.ToList();

            //    var c3 = context.Contacts.Where(c => c.FirstName == "Hugo")
            //                             .Select(c => c.FirstName + " " + c.LastName)
            //                             .ToList();
            //    var c4 = context.Contacts.Where(c => c.FirstName == "Hugo")
            //                             .Select(c => c.FirstName + " " + c.LastName)
            //                             .ToString();
            //    Console.WriteLine(context.Contacts.Where(c => c.FirstName == "Hugo")
            //                             .Select(c => c.FirstName + " " + c.LastName)
            //                             .ToString());
            //}

            //Ex 4 : LazyLoading Versus Eager Loading
            ProgEF_Entities context;
            int tempsDebut = Environment.TickCount;
            using (context = new ProgEF_Entities())
            {
                // Eager loading: les objets Addresses sont inclus dans le retour de la requête (notez le Include())
                // var contacts = context.Contacts
                //                      .Include(c => c.Addresses)
                //                      .ToList(); 
          
                
                // Lazy Loading: comportement par défaut. Les objets associées ne sont pas inclus dans l'objets. Ils seront retournés seulement lorsque accédés
                var contacts = context.Contacts.ToList(); 
  



                foreach (Contact c in contacts)
                {
                    Console.WriteLine(c.FirstName);
                    foreach (Address a in c.Addresses) // Dans le cas du lazy loading, une requête sera faite
                        Console.WriteLine(a.City);
                }

            }
            int tempsFin = Environment.TickCount;

            // Le temps d'exécution dépendra largement de votre cas d'utilisation
            // Parfois le eager loading est meilleur, parfois le lazy loading est meilleur
            Console.WriteLine(tempsFin - tempsDebut); //4266 ms VS 719 ms
            Console.ReadKey();

        }
    }
}
