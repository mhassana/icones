using ClassLibrary;
using System.ComponentModel.DataAnnotations;

namespace brouillon.Models
{
    public class PompeModel
    {
        public string libelle { get; set; }
        public string codeU { get; set; }
        public string codeTANKER { get; set; }

        [Key]
        public string codePOMPE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Tanker Tanker { get; set; }
    }
}