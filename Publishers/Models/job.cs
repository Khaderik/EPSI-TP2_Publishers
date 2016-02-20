using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Publishers.Models
{
    public partial class job
    {
        public job()
        {
            this.employees = new List<employee>();
        }

        public short job_id { get; set; }
        [DisplayName("Description du poste")]
        public string job_desc { get; set; }
        public byte min_lvl { get; set; }
        public byte max_lvl { get; set; }
        public virtual ICollection<employee> employees { get; set; }
    }
}
