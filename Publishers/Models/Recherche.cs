using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Publishers.Models
{
    public class Recherche
    {
        public string nomAuteur { get; set; }
        public string nomEmp { get; set; }
        public string Editeurs { get; set; }
        public int PageCourante { get; set; }
        public TypeRecherche typeRecherche { get; set; }
    }

    public enum TypeRecherche
    {
        CommencePar = 1,
        Contient = 2
    };
}