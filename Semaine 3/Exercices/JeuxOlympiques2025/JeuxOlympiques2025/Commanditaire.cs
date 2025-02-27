using System;
using System.Collections.Generic;

namespace JeuxOlympiques2025;

public partial class Commanditaire
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public decimal CommanditeParCoureur { get; set; }

    public virtual ICollection<Coureur> IdCoureurs { get; set; } = new List<Coureur>();
}
