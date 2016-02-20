using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Publishers.Models
{
    public partial class publisher
    {
        public publisher()
        {
            this.employees = new List<employee>();
            this.titles = new List<title>();
        }

        public string pub_id { get; set; }
        [DisplayName("Nom de l'éditeur")]
        public string pub_name { get; set; }
        [DisplayName("Ville")]
        public string city { get; set; }
        [DisplayName("Etat")]
        public string state { get; set; }
        [DisplayName("Pays")]
        public string country { get; set; }
        public virtual ICollection<employee> employees { get; set; }
        public virtual pub_info pub_info { get; set; }
        public virtual ICollection<title> titles { get; set; }
    }
}
