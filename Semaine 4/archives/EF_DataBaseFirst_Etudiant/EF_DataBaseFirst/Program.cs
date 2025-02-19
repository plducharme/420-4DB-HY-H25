using EF_DataBaseFirst.EF;
using Microsoft.EntityFrameworkCore;

namespace EF_DataBaseFirst
{
    /// <summary>
    /// Auteur :      Hugo St-Louis
    /// Description : Expérimentation avec EF et DataBaseFirst.
    /// Date :        2023-01-31
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                List<Contact> contacts = context.Contacts.Include("Addresses").ToList();
                foreach (Contact c in contacts)
                {
                    Console.WriteLine("Prenom : " + c.FirstName + " Nom : " + c.LastName);
                    foreach (Address a in c.Addresses)
                        Console.WriteLine("Ville " + a.City);
                }
            }


            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                var c2 = context.Contacts.Where(c => c.FirstName == "Robert")
                                         .Select(c => c.FirstName + " " + c.LastName);
                List<string> lstC2 = c2.ToList();

                var c3 = context.Contacts
                                .Where(c => c.FirstName == "Robert")
                                .Select(c => c.FirstName + " " + c.LastName)
                                .ToList();

                var c4 = context.Contacts
                                .Where(c => c.FirstName == "Robert")
                                .Select(c => c.FirstName + " " + c.LastName)
                                .ToString();

            }


            Console.ReadKey();


        }
    }
}