using System;
using System.Collections.Generic;

namespace Publishers.Models
{
    public partial class discount
    {
        public string discounttype { get; set; }
        public string stor_id { get; set; }
        public Nullable<short> lowqty { get; set; }
        public Nullable<short> highqty { get; set; }
        public decimal discount1 { get; set; }
        public virtual store store { get; set; }
    }
}
