namespace ExempleWCFServeur.DTO
{
    [DataContract]
    public enum EContactError
    {
        [EnumMember]
        OK,
        [EnumMember]
        NotFound,
        [EnumMember]
        AlreadyExists,
        [EnumMember]
        InvalidData,
        [EnumMember]
        UnknownError,
        [EnumMember]
        NotImplmented
    }
}
