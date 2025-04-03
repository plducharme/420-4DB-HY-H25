using ExempleWCFServeur.DTO;

namespace ExempleWCFServeur
{
    [ServiceContract]
    public interface IContactService
    {
        [OperationContract]
        public ContactDTO GetContact(int id);


    }
}
