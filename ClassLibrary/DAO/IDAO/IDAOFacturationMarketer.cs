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

        List<FacturationMarketer> rechercherParMC(Func<FacturationMarketer, bool> predicate);

        FacturationMarketer rechercherUnique(FacturationMarketer m);

        List<FacturationMarketer> rechercherTous();
    }
}
