namespace ExempleWCFServeur.DTO
{
    [DataContract]
    public class AddressDTO
    {
        [DataMember]
        public int AddressId { get; set; }

        [DataMember]
        public string? Street1 { get; set; }

        [DataMember]
        public string? Street2 { get; set; }

        [DataMember]
        public string? City { get; set; }

        [DataMember]
        public string? StateProvince { get; set; }

        [DataMember]
        public string? CountryRegion { get; set; }

        [DataMember]
        public string? PostalCode { get; set; }

        [DataMember]
        public string AddressType { get; set; } = null!;

        [DataMember]
        public DateTime ModifiedDate { get; set; }

    }
}
