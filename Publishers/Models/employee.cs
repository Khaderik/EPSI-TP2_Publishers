using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Publishers.Models
{
    public partial class employee
    {
        public string emp_id { get; set; }
        [DisplayName("Prénom")]
        public string fname { get; set; }
        [DisplayName("un truc")]
        public string minit { get; set; }
        [DisplayName("Nom")]
        public string lname { get; set; }
        public short job_id { get; set; }
        [DisplayName("Niveau")]
        public Nullable<byte> job_lvl { get; set; }
        public string pub_id { get; set; }
        [DisplayName("Date d'embauche")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime hire_date { get; set; }
        public virtual job job { get; set; }
        public virtual publisher publisher { get; set; }
    }
}
