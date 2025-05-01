using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConcurrence
{
    class Editeur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Pays { get; set; }
        public ICollection<Jeu> Jeux { get; set; } = new HashSet<Jeu>();
        
    }
}
