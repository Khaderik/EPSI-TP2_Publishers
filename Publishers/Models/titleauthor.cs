using System;
using System.Collections.Generic;

namespace Publishers.Models
{
    public partial class titleauthor
    {
        public string au_id { get; set; }
        public string title_id { get; set; }
        public Nullable<byte> au_ord { get; set; }
        public Nullable<int> royaltyper { get; set; }
        public virtual author author { get; set; }
        public virtual title title { get; set; }
    }
}
