using System;
using System.Collections.Generic;

namespace ExempleWCFServeur.EFModel;

public partial class VOfficeAddress
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int AddressId { get; set; }

    public string? Street1 { get; set; }

    public string? Street2 { get; set; }

    public string? City { get; set; }

    public string? StateProvince { get; set; }

    public string? CountryRegion { get; set; }

    public string? PostalCode { get; set; }

    public string AddressType { get; set; } = null!;

    public int ContactId { get; set; }

    public DateTime ModifiedDate { get; set; }
}
