using System;
using System.Collections.Generic;

namespace Publishers.Models
{
    public partial class employee
    {
        public string emp_id { get; set; }
        public string fname { get; set; }
        public string minit { get; set; }
        public string lname { get; set; }
        public short job_id { get; set; }
        public Nullable<byte> job_lvl { get; set; }
        public string pub_id { get; set; }
        public System.DateTime hire_date { get; set; }
        public virtual job job { get; set; }
        public virtual publisher publisher { get; set; }
    }
}
