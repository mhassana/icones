using ClassLibrary;
using System.Collections.Generic;

namespace brouillon.Models
{
    public class NavireModel
    {
        public NavireModel()
        {
            this.JoinBE_SoutageToNavire = new HashSet<JoinBE_SoutageToNavire>();
        }

        public decimal capacite { get; set; }
        public string nom { get; set; }
        public string codeU { get; set; }
        public string codeNAVIRE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<JoinBE_SoutageToNavire> JoinBE_SoutageToNavire { get; set; }
    }
}