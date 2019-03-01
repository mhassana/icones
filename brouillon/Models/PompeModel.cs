using ClassLibrary;

namespace brouillon.Models
{
    public class PompeModel
    {
        public string libelle { get; set; }
        public string codeU { get; set; }
        public string codeTANKER { get; set; }
        public string codePOMPE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Tanker Tanker { get; set; }
    }
}