using Experimentation_2024.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Data.Common;

namespace Experimentation_2024
{
	/// <summary>
	/// Auteur :      Hugo St-Louis
	/// Description : Expérimentation des modes de chargement des données
	/// Date :        2024-02-15
	/// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
			//Expérimentation sur les méthodes de chargement de donnnées
			//using (ApplicationDBContext context = new ApplicationDBContext()) 
			//{ 
			//	List<Projet> lstProjets = context.Projets.Include(p => p.IdContacts).ToList();
			//	foreach(Projet p in lstProjets)
			//	{
			//                 Console.WriteLine("Projet : " + p.Description );
			//		Console.WriteLine("Montant : " + p.Subvention + " $ ");
			//                 Console.WriteLine("================================");
			//                 Console.WriteLine("List des participants ");
			//		foreach(Contact c in p.IdContacts)
			//		{
			//                     Console.WriteLine("- " + c.FirstName + " " + c.LastName);
			//                 }
			//             }
			//             Console.ReadKey();
			//         }

			//Expérimentation sur le suivi des états
			//using (ApplicationDBContext context = new ApplicationDBContext())
			//{
			//	Contact c = context.Contacts.FirstOrDefault();
			//	c.FirstName = "Hugo";
			//	EntityEntry entityEntry = context.Entry(c);

			//	Console.WriteLine("Nom de l'entité : " + entityEntry.Entity.GetType().Name);
			//	Console.WriteLine("État de l'entité : " + entityEntry.State);
			//	Console.WriteLine("Original Values : " + entityEntry.OriginalValues);
			//	Console.WriteLine("Current Values : " + entityEntry.CurrentValues);
			//	Contact c2 = new Contact()
			//	{
			//		FirstName = "Hugo",
			//		LastName = "St-Louis",
			//		Title = "Mr.",
			//		AddDate = DateTime.Now,
			//		ModifiedDate = DateTime.Now,
			//		Ages = 0,
			//		Covid = false
			//	};
			//	context.Contacts.Add(c2);
			//	try
			//	{
			//		int nbModification = context.SaveChanges();
			//	}
			//	catch (DbException ex)
			//	{
			//                 Console.WriteLine("Exception de type DB  " + ex.Message);
			//             }
			//	catch (DBConcurrencyException ex)
			//	{
			//		Console.WriteLine("Exception de concurrence " + ex.Message);

			//	}
			//	catch(Exception ex)
			//	{
			//                 Console.WriteLine("Exception " + ex.Message);
			//             }				
			//foreach (EntityEntry o in context.ChangeTracker.Entries())
			//{
			//	Console.WriteLine("Nom de l'entité : " + o.Entity.GetType().Name);
			//	Console.WriteLine("État de l'entité : " + o.State);
			//}
			//}
			//Contact c1;
			//using (ApplicationDBContext context = new ApplicationDBContext())
			//{
			//	c1 = context.Contacts.Include(c=>c.Addresses).FirstOrDefault();
			//	c1.FirstName = "Hugo" + DateTime.Now.ToString();
			//	//Combien d'élément dans la boucle?
			//	foreach (EntityEntry modif in context.ChangeTracker.Entries())
			//		Console.WriteLine(modif.State);
			//	context.SaveChanges();
			//}



			//}
			//Contact c2;
			//using (ApplicationDBContext context = new ApplicationDBContext())
			//{
			//	c2 = context.Contacts.FirstOrDefault();
			//}
			//using (ApplicationDBContext context = new ApplicationDBContext())
			//{
			//	if (c2 != null)
			//	{

			//		c2.ContactId = 0;
			//		Console.WriteLine(context.Entry(c2).State);

			//		context.Contacts.Add(c2);
			//		Console.WriteLine(context.Entry(c2).State);

			//		//context.Entry(c2).State = EntityState.Modified;
			//		//Console.WriteLine(context.Entry(c2).State);

			//		context.SaveChanges();
			//	}
			//}

			//Address address;
			//using (ApplicationDBContext context = new ApplicationDBContext())
			//{
			//	address = (Address)context.Addresses.Where(a => a.AddressId == context.Addresses.Max(a2 => a2.AddressId)).Single();
			//}

			//using (ApplicationDBContext context = new ApplicationDBContext())
			//{
			//	address = (Address)context.Addresses.Where(a => a.AddressId == context.Addresses.Max(a2 => a2.AddressId)).Single();

			//	Contact contact = new Contact()
			//	{
			//		FirstName = "Hugo",
			//		LastName = "St-Louis",
			//		Title = "Mr",
			//		ModifiedDate = DateTime.Now,
			//		AddDate = DateTime.Now,
			//	};
			//	////address.AddressId = 0;
			//	//contact.Addresses.Add(address);

			//	context.Contacts.Add(contact);
			//	context.SaveChanges();
			//}



			Contact c1;
			Contact c2;
			using (ApplicationDBContext context = new ApplicationDBContext())
			{
				c2 = context.Contacts.FirstOrDefault(); //Vérifier le contenu de c2 et c1 pour chacune des lignes
				c1 = context.Contacts.Include("Addresses").FirstOrDefault();
				c1.FirstName = "Hugo" + DateTime.Now.ToString();
				c2 = context.Contacts.FirstOrDefault();


				context.SaveChanges();
			}







		}
	}
}
