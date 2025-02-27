using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Projet1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Création du context");
            Entities context = new Entities();

            //Contact contact = context.Contacts.FirstOrDefault(c => c.ContactID == 367);
            List<Contact> contacts = context.Contacts.Include(p => p.Add)
            foreach(Contact c in contacts)
            { 
                Console.WriteLine(c.ContactID + " - " + c.FirstName + c.LastName);
                foreach (Projet p in c.Projets)
                    Console.WriteLine("Description Projet : " + p.Description);

            }


            Console.ReadKey();
        }
    }
}
