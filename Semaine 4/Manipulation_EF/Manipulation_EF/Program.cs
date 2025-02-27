using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulation_EF
{
    /// <summary>
    /// Auteur :      Hugo St-Louis
    /// Description : Expérimentation pour la manipulation des données avec EF.
    /// Date :        2022-02-14    
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //using (ProgEF_Entities context = new ProgEF_Entities())
            //{
            //    Contact c = new Contact()
            //    {
            //        FirstName = "Hugo",
            //        LastName = "St-Louis",
            //        Title = "Mr",
            //        AddDate = DateTime.Now,
            //        ModifiedDate = DateTime.Now
            //    };
            //    context.Contacts.Add(c);
            //    Address a = new Address()
            //    {
            //        City = "Beloeil",
            //        CountryRegion = "Canada",
            //        StateProvince = "QC",
            //        Street1 = "123 rue du Fond",
            //        ModifiedDate = DateTime.Now,
            //        PostalCode = "J3G 0F3",
            //        AddressType = "Home"
            //    };
            //    //a.Contacts.Add(c);
            //    c.Addresses.Add(a);
            //    //context.Addresses.Add(a);

            //    context.SaveChanges();
            //    Console.WriteLine(c.ContactID);
            //}

            using (ProgEF_Entities context = new ProgEF_Entities())
            {
                var product = context.Products.FirstOrDefault();
                var entry = context.Entry(product);
                Console.WriteLine("Entity name: " + entry.Entity.GetType().Name);
                Console.WriteLine("State: " + entry.State);
                Console.WriteLine("Original values: " + entry.OriginalValues);
                Console.WriteLine("Current values: " + entry.CurrentValues);
            }



            //Ajout avec plusieurs contextes
            Address address;
            //using (ProgEF_Entities context = new ProgEF_Entities())
            //{
            //    address = (Address)context.Addresses
            //                              .Where(a => a.AddressID == context.Addresses.Max(a2 => a2.AddressID)).Single();
            //}

            //using (ProgEF_Entities context = new ProgEF_Entities())
            //{
            //    address = (Address)context.Addresses
            //                              .Where(a => a.AddressID == context.Addresses.Max(a2 => a2.AddressID)).Single();
            //    Contact contact = new Contact()
            //    {
            //        FirstName = "Hugo",
            //        LastName = "St-Louis",
            //        Title = "Mr",
            //        ModifiedDate = DateTime.Now,
            //        AddDate = DateTime.Now,
            //    };
            //    contact.Addresses.Add(address);

            //    context.Contacts.Add(contact);
            //    context.SaveChanges();
            //}
            //try
            //{
            //    //Suppression de contact
            //    using (ProgEF_Entities context = new ProgEF_Entities())
            //    {

            //        //IEnumerable<Address> addresses = context.Addresses.Where(a => a.Contacts.Any(c => c.ContactID >= 706));
            //        //context.Addresses.RemoveRange(addresses);
            //        IEnumerable<Contact>  lst =  context.Contacts.Where(c => c.ContactID == 706);
            //        context.Contacts.RemoveRange(lst);


            //        context.Contacts.Remove(lst.FirstOrDefault());

            //        context.SaveChanges();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);

            //}

            try
            {
               
                using (ProgEF_Entities context = new ProgEF_Entities())
                {
                   // Contact c = context.Contacts.FirstOrDefault(c2=>c2.ContactID == 799);
                    Contact newContact = new Contact()
                    {
                        FirstName = "Hugo-14 février",
                        LastName = "St-Louis",
                        Title = "Mr.",
                        Ages = 30,
                        PourcentageDeChanceDePocherLeCours = 10
                    };

                    context.Contacts.Add(newContact);
                    //c.FirstName = "14h32";
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }



        }
    }
}
