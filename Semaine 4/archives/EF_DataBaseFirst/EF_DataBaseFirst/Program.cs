using EF_DataBaseFirst.EF;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
List<Contact> lstContact = new List<Contact>();
lstContact.Add(new Contact()
{
    AddDate = DateTime.Now,
    FirstName = "Hugo",
    LastName = "St-Louis"
});
lstContact.Add(new Contact()
{
    AddDate = DateTime.Now,
    FirstName = "Joe",
    LastName = "Dimagio"
});

ApplicationDBContext context = new ApplicationDBContext();
context.Contacts.AddRange(lstContact);
context.SaveChanges();


        }
    }
}