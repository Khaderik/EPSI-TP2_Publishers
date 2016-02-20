using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Publishers.Models
{
    public partial class title
    {
        public title()
        {
            this.sales = new List<sale>();
            this.titleauthors = new List<titleauthor>();
        }

        public string title_id { get; set; }
        [DisplayName("Titre")]
        public string title1 { get; set; }
        [DisplayName("Type")]
        public string type { get; set; }
        public string pub_id { get; set; }
        [DisplayName("Prix")]
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> advance { get; set; }
        public Nullable<int> royalty { get; set; }
        public Nullable<int> ytd_sales { get; set; }
        public string notes { get; set; }
        [DisplayName("Date de parution")]
        public System.DateTime pubdate { get; set; }
        public virtual publisher publisher { get; set; }
        public virtual roysched roysched { get; set; }
        public virtual ICollection<sale> sales { get; set; }
        public virtual ICollection<titleauthor> titleauthors { get; set; }
    }
}
