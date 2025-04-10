using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstConvention
{
    public class Pays
    {
        public Pays()
        {
            Fabricants = new List<Fabricant>();
        }
        public int PaysId { get; set; }
        public string Nom { get; set; }
        public ICollection<Fabricant> Fabricants { get; set; } = new List<Fabricant>();
    }
}
