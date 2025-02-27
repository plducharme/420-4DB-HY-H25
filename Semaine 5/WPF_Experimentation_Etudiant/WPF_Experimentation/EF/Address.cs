using System;
using System.Collections.Generic;

namespace WPF_Experimentation.EF;

public partial class Address
{
    public int AddressId { get; set; }

    public string? Street1 { get; set; }

    public string? Street2 { get; set; }

    public string? City { get; set; }

    public string? StateProvince { get; set; }

    public string? CountryRegion { get; set; }

    public string? PostalCode { get; set; }

    public string AddressType { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Contact> Contacts { get; } = new List<Contact>();
}
