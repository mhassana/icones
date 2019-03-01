using ClassLibrary;
using System.Collections.Generic;

namespace brouillon.Models
{
    public class TankerModel
    {
        public TankerModel()
        {
            this.Pompes = new HashSet<Pompe>();
        }

        public string libelle { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeStation { get; set; }
        public string codePRODUIT { get; set; }
        public string codeTANKER { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<Pompe> Pompes { get; set; }
        public virtual Produit Produit { get; set; }
        public virtual Station Station { get; set; }
    }
}