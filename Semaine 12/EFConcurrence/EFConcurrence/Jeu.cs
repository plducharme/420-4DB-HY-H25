using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConcurrence
{
    class Jeu
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public Editeur Editeur { get; set; }
        public int EditeurId { get; set; } // Clé étrangère vers Editeur
        public byte[] Version { get; set; } // Version de la ligne pour la gestion de la concurrence
    }
}
