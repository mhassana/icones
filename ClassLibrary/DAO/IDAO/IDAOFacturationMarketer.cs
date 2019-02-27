using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
   public interface IDAOFacturationMarketer
    {

        FacturationMarketer ajouter(FacturationMarketer u);

        FacturationMarketer modifier(FacturationMarketer u);

        FacturationMarketer rechercher(string code);

        FacturationMarketer supprimer(FacturationMarketer u);

        IEnumerable<FacturationMarketer> rechercherParMC(Func<FacturationMarketer, bool> predicate);

        IEnumerable<FacturationMarketer> rechercherTous();
    }
}
