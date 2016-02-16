using System;
using System.Collections.Generic;

namespace Publishers.Models
{
    public partial class store
    {
        public store()
        {
            this.discounts = new List<discount>();
            this.sales = new List<sale>();
        }

        public string stor_id { get; set; }
        public string stor_name { get; set; }
        public string stor_address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public virtual ICollection<discount> discounts { get; set; }
        public virtual ICollection<sale> sales { get; set; }
    }
}
