using System;
using System.Collections.Generic;

namespace EF_DataBaseFirst.EF;

public partial class Projet
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int? Subvention { get; set; }

    public virtual ICollection<Contact> IdContacts { get; } = new List<Contact>();
}
