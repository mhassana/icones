using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
   public interface IDAOBeBacBac
    {

        BE_bac_bac ajouter(BE_bac_bac u);

        BE_bac_bac modifier(BE_bac_bac u);

        BE_bac_bac rechercher(string code);

        BE_bac_bac supprimer(BE_bac_bac u);

        IEnumerable<Marketer> rechercherParMC(Func<Marketer, bool> predicate);

        IEnumerable<BE_bac_bac> rechercherTous();
    }
}
