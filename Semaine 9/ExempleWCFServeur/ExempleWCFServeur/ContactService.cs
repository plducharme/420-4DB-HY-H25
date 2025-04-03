using ExempleWCFServeur.DTO;
using ExempleWCFServeur.EFModel;

namespace ExempleWCFServeur
{
    public class ContactService : IContactService
    {
        public ContactDTO GetContact(int id)
        {
            using (var context = new _4dbProgrammingefdb1Context()) {

                ContactDTO contact = context.Contacts
                    .Where(c => c.ContactId == id)
                    .Select(c => new ContactDTO
                    {
                        ContactId = c.ContactId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Title = c.Title,
                        AddDate = c.AddDate,
                        ModifiedDate = c.ModifiedDate,
                        Addresses = c.Addresses.Select(a => new AddressDTO
                        {
                            AddressId = a.AddressId,
                            Street1 = a.Street1,
                            Street2 = a.Street2,
                            City = a.City,
                            StateProvince = a.StateProvince,
                            CountryRegion = a.CountryRegion
                        }).ToList()
                    }).Single();
                return contact;

            }   
        }
    }
    
}
