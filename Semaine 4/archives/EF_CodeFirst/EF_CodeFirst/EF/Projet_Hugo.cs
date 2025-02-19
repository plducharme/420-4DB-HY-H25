using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.EF
{
    /// <summary>
    /// Auteur :      Hugo St-Louis
    /// Description : Contient les informations d'un projet.
    /// Date :        2023-01-31
    /// </summary>
    public class Projet_Hugo
    {
        /// <summary>
        /// ctor
        /// </summary>
        public Projet_Hugo()
        {
            Personnes = new List<Personne_Hugo>();
        }

        public int Projet_HugoId { get; set; }
        public DateTime DateDebut { get; set; }
        public float BudgetRestant { get; set; }

        public string? Descrition { get; set; }

        public ICollection<Personne_Hugo>? Personnes { get; set; }

    }
}
