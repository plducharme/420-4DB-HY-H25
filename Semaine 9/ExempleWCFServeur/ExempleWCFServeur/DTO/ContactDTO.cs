using ExempleWCFServeur.EFModel;

namespace ExempleWCFServeur.DTO
{
    [DataContract]
    public class ContactDTO
    {
        [DataMember]
        public int ContactId { get; set; }

        [DataMember]
        public string FirstName { get; set; } = null!;

        [DataMember]
        public string LastName { get; set; } = null!;

        [DataMember]
        public string? Title { get; set; }

        [DataMember]
        public DateTime AddDate { get; set; }

        [DataMember]
        public DateTime ModifiedDate { get; set; }

        [DataMember]
        public virtual ICollection<AddressDTO> Addresses { get; set; } = new List<AddressDTO>();

     
    }
}
