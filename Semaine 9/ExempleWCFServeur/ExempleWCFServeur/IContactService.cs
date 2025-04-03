using ExempleWCFServeur.DTO;

namespace ExempleWCFServeur
{
    [ServiceContract]
    public interface IContactService
    {
        [OperationContract]
        public ContactDTO GetContact(int id);

        [OperationContract]
        public EContactError InsertContact(ContactDTO contact);

        [OperationContract]
        public EContactError UpdateContact(ContactDTO contact);

        [OperationContract]
        public EContactError DeleteContact(int id);

        [OperationContract]
        public List<ContactDTO> GetAllContacts();

    }
}
