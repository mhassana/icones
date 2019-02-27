using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
   public interface IDAOMarketer
    {

        Marketer ajouter(Marketer u);

        Marketer modifier(Marketer u);

        Marketer rechercher(string code);

        Marketer supprimer(Marketer u);
        

        IEnumerable<Marketer> rechercherParMC(Func<Marketer, bool> predicate);


        Marketer rechercherUnique(Marketer m);

        IEnumerable<Marketer> rechercherTous();
    }
}
