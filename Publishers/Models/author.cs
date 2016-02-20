using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Publishers.Models
{
    public partial class author
    {
        public author()
        {
            this.titleauthors = new List<titleauthor>();
        }
        
        public string au_id { get; set; }
        [DisplayName("Nom")]
        [Required(ErrorMessage = "Le nom est requis")]
        public string au_lname { get; set; }
        [DisplayName("Prénom")]
        [Required(ErrorMessage = "Le prénom est requis")]
        public string au_fname { get; set; }
        [DisplayName("Téléphone")]
        public string phone { get; set; }
        [DisplayName("Adresse")]
        [Required(ErrorMessage = "L'adressse est requis")]
        public string address { get; set; }
        [DisplayName("Ville")]
        [Required(ErrorMessage = "La ville est requis")]
        public string city { get; set; }
        [DisplayName("Pays")]
        [Required(ErrorMessage = "Le pays est requis")]
        public string state { get; set; }
        [DisplayName("Code Postal")]
        public string zip { get; set; }
        [DisplayName("Sous contrat")]
        public bool contract { get; set; }
        public virtual ICollection<titleauthor> titleauthors { get; set; }
    }
}
