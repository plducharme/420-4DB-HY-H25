using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstAnnotation
{
    public class Client
    {
        public Client(string nom, string prenom, string adresse, string adresse2, string ville, string codePostal, string pays ) {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Adresse = adresse;
            this.Adresse2 = adresse2;
            this.Ville = ville;
            this.CodePostal = codePostal;
            this.Pays = pays;

        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CleAvecNomBizarre { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")]
        [Column("NomClient")]
        public string Nom { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères.")]
        public string Prenom { get; set; }
        [Required]
        public string Adresse { get; set; }
        [AllowNull]
        public string Adresse2 { get; set; }
        [Required]
        public string Ville { get; set; }
        [Required]
        [StringLength(7, ErrorMessage = "Le code postal ne peut pas dépasser 10 caractères.")]
        public string CodePostal { get; set; }
        [Required]
        public string Pays { get; set; }

    }
}
