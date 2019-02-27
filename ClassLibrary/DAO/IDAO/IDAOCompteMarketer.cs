using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
    public interface IDAOCompteMarketer
    {
        Compte_marketer ajouter(Compte_marketer u);

        Compte_marketer modifier(Compte_marketer u);

        Compte_marketer rechercher(string code);

        Compte_marketer supprimer(Compte_marketer u);

        IEnumerable<Compte_marketer> rechercherParMC(Func<Compte_marketer, bool> predicate);

        IEnumerable<Compte_marketer> rechercherTous();

    }
}
