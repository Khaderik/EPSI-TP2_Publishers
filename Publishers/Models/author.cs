using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Publishers.Models
{
    public partial class author
    {
        public author()
        {
            this.titleauthors = new List<titleauthor>();
        }
        
        public string au_id { get; set; }
        [DisplayName("Prénom")]
        public string au_lname { get; set; }
        [DisplayName("Nom")]
        public string au_fname { get; set; }
        [DisplayName("Téléphone")]
        public string phone { get; set; }
        [DisplayName("Adresse")]
        public string address { get; set; }
        [DisplayName("Ville")]
        public string city { get; set; }
        [DisplayName("Pays")]
        public string state { get; set; }
        [DisplayName("Code Postal")]
        public string zip { get; set; }
        public bool contract { get; set; }
        public virtual ICollection<titleauthor> titleauthors { get; set; }
    }
}
