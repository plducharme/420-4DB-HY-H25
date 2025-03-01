using System;
using System.Collections.Generic;

namespace EFCoreUnitTests.Model;

public partial class Coureur
{
    public int Id { get; set; }

    public string Prenom { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Pays { get; set; } = null!;

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();

    public virtual ICollection<Commanditaire> IdCommenditaires { get; set; } = new List<Commanditaire>();

    public virtual ICollection<Entraineur> IdEntraineurs { get; set; } = new List<Entraineur>();
}
