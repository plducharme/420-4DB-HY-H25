using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstConvention
{
    public class Fabricant
    {
        public Fabricant()
        {
            Automobiles = new List<Automobile>();
        }

        public int FabricantId { get; set; }
        public string Nom { get; set; }

        public int? AnneeCreation { get; set; }

        public Pays? Pays { get; set; }

        public ICollection<Automobile>? Automobiles { get; set; } = new List<Automobile>();
    }
}
