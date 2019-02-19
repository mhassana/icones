using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.ComponentModel.DataAnnotations;

namespace brouillon.Models
{
    public class MarketerModel
    {
        [Key]
        public string CodeMARKETER { get; set; }

        public string Nom { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Adresse { get; set; }

        public string Ville { get; set; }

        public string Pays { get; set; }
    
    }
}