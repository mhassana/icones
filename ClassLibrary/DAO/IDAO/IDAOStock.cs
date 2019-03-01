using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
   public interface IDAOStock
    {

        Stock ajouter(Stock u);

        Stock modifier(Stock u);

        Stock rechercher(string code);

        Stock supprimer(Stock u);

        List<Stock> rechercherParMC(Func<Stock, bool> predicate);

        Stock rechercherUnique(Stock m);

        List<Stock> rechercherTous();

    }
}
