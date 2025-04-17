using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFluentAPI.Modele
{
    internal class Album
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Année { get; set; }
        public Groupe Groupe { get; set; }

        public int GroupeId { get; set; }

    }
}
