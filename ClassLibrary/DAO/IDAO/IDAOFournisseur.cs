using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
   public interface IDAOFournisseur
    {

        Fournisseur ajouter(Fournisseur u);

        Fournisseur modifier(Fournisseur u);

        Fournisseur rechercher(string code);

        Fournisseur supprimer(Fournisseur u);

        List<Fournisseur> rechercherParMC(Func<Fournisseur, bool> predicate);

        Fournisseur rechercherUnique(Fournisseur m);

        List<Fournisseur> rechercherTous();

    }
}
