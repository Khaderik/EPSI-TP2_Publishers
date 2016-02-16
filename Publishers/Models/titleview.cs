using System;
using System.Collections.Generic;

namespace Publishers.Models
{
    public partial class titleview
    {
        public string title { get; set; }
        public Nullable<byte> au_ord { get; set; }
        public string au_lname { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> ytd_sales { get; set; }
        public string pub_id { get; set; }
    }
}
