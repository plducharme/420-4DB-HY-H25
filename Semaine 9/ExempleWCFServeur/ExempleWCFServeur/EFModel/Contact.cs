using System;
using System.Collections.Generic;

namespace ExempleWCFServeur.EFModel;

public partial class Contact
{
    public int ContactId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Title { get; set; }

    public DateTime AddDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public byte[]? ImageContact { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public int Age { get; set; }

    public bool? Covid { get; set; }

    public byte[]? Photo { get; set; }

    public string? PhotoPath { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Projet> IdProjets { get; set; } = new List<Projet>();
}
