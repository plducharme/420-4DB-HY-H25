using System;
using System.Collections.Generic;

namespace Exercices_Supplementaires_Solution.EF;

public partial class RegroupContact
{
    public int CustomerId { get; set; }

    public string? Title { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string? Phone { get; set; }

    public string? Cellphone { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string PostalCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public string CountryRegion { get; set; } = null!;

    public string StateProvince { get; set; } = null!;
}
