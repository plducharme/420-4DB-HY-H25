using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.EF
{
    /// <summary>
    /// Auteur :      Hugo St-Louis
    /// Description : Contient les informations d'une personne.
    /// Date :        2023-01-31
    /// </summary>
    public class Personne_Hugo
    {
        /// <summary>
        /// ctor
        /// </summary>
        public Personne_Hugo()
        {
            Projets = new List<Projet_Hugo>(); 
        }

        public int Personne_HugoId { get; set; }
      
        public string? Prenom { get; set; }
        public string? Nom { get; set; }
        public string? Courriel { get; set; }
        public string? Telephone { get; set; }

        public string? Cellulaire { get; set; }

        public ICollection<Projet_Hugo>? Projets { get; set; }

    }
}
