using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstConvention
{
    public class Automobile
    {
        public int Id { get; set; }
        public Fabricant Fabricant { get; set; }
        public string Modele { get; set; }
        public int Annee { get; set; }

    }
}
