using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
   public interface IDAOCommandeMarketer
    {
        Commande_marketer ajouter(Commande_marketer u);

        Commande_marketer modifier(Commande_marketer u);

        Commande_marketer rechercher(string code);

        Commande_marketer supprimer(Commande_marketer u);

        IEnumerable<Commande_marketer> rechercherParMC(Func<Commande_marketer, bool> predicate);

        IEnumerable<Commande_marketer> rechercherTous();
    }
}
