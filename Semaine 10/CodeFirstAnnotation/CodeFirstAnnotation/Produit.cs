using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstAnnotation
{
    public class Produit
    {
        public Produit(string nom, string description, decimal prix) {
            this.Nom = nom;
            this.Description = description;
            this.Prix = prix;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0.01, 10000.00, ErrorMessage = "Le prix doit être compris entre 0.01 et 10000.00")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Prix { get; set; }
    }
}
