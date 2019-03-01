using ClassLibrary;

namespace brouillon.Models
{
    public class JoinTaxeToFacturationModel
    {
        public string codeU { get; set; }
        public string codeFACTURATION { get; set; }
        public string codeTAXE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Taxe Taxe { get; set; }
    }
}