using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
   public interface IDAODepot
    {
        Depot ajouter(Depot u);

        Depot modifier(Depot u);

        Depot rechercher(string code);

        Depot supprimer(Depot u);

        List<Depot> rechercherParMC(Func<Depot, bool> predicate);

        Depot rechercherUnique(Depot m);

        List<Depot> rechercherTous();

    }
}
