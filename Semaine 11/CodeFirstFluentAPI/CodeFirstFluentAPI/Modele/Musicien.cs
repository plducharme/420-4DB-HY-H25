using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFluentAPI.Modele
{
    internal class Musicien
    {
        public Musicien() { 
        
        }
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public List<Groupe> Groupes { get; set; } = new List<Groupe>();
    }
}
