using System;
using System.Collections.Generic;

namespace Publishers.Models
{
    public partial class sale
    {
        public string stor_id { get; set; }
        public string ord_num { get; set; }
        public System.DateTime ord_date { get; set; }
        public short qty { get; set; }
        public string payterms { get; set; }
        public string title_id { get; set; }
        public virtual store store { get; set; }
        public virtual title title { get; set; }
    }
}
