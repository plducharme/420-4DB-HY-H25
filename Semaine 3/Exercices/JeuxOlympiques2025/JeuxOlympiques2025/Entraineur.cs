using System;
using System.Collections.Generic;

namespace JeuxOlympiques2025;

public partial class Entraineur
{
    public int Id { get; set; }

    public string Prenom { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public virtual ICollection<Coureur> IdCoureurs { get; set; } = new List<Coureur>();
}
