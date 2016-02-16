using System;
using System.Collections.Generic;

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
        public string pub_name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public virtual ICollection<employee> employees { get; set; }
        public virtual pub_info pub_info { get; set; }
        public virtual ICollection<title> titles { get; set; }
    }
}
