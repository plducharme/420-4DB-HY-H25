using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFluentAPI.Modele
{
    internal class Groupe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateCreation { get; set; }
        public string Genre { get; set; }
        public List<Musicien> Musiciens { get; set; } = new List<Musicien>();
        public List<Album> Albums { get; set; } = new List<Album>();
    }
}
