using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstAnnotation
{
    
    public enum Statut
    {
        [Description("Commande soumis")]
        SOUMIS,
        [Description("Commande en traitement")]
        EN_TRAITEMENT,
        [Description("Terminée")]
        TERMINE,
        [Description("Annulée")]
        ANNULEE
    }
}
