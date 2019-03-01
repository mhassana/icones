using ClassLibrary;

namespace brouillon.Models
{
    public class JoinBE_SoutageToNavireModel
    {
        public string codeU { get; set; }
        public string codeNAVIRE { get; set; }
        public string codeBE_SOUTAGE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual BE_Soutage BE_Soutage { get; set; }
        public virtual Navire Navire { get; set; }
    }
}