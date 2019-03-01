using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
    public interface IDAOReglement_dette
    {
        Reglement_dette ajouter(Reglement_dette u);

        Reglement_dette modifier(Reglement_dette u);

        Reglement_dette rechercher(string code);

        Reglement_dette supprimer(Reglement_dette u);

        List<Reglement_dette> rechercherParMC(Func<Reglement_dette, bool> predicate);

        Reglement_dette rechercherUnique(Reglement_dette m);

        List<Reglement_dette> rechercherTous();
    }
}
