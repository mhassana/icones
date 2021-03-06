﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Tanker
    {
        public Tanker()
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
