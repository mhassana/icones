using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
   public interface IDAOTaxe
    {

        Taxe ajouter(Taxe u);

        Taxe modifier(Taxe u);

        Taxe rechercher(string code);

        Taxe supprimer(Taxe u);

        List<Taxe> rechercherParMC(Func<Taxe, bool> predicate);

        Taxe rechercherUnique(Taxe m);

        List<Taxe> rechercherTous();

    }
}
