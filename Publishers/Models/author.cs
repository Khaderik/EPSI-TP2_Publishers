using System;
using System.Collections.Generic;

namespace Publishers.Models
{
    public partial class author
    {
        public author()
        {
            this.titleauthors = new List<titleauthor>();
        }

        public string au_id { get; set; }
        public string au_lname { get; set; }
        public string au_fname { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public bool contract { get; set; }
        public virtual ICollection<titleauthor> titleauthors { get; set; }
    }
}
