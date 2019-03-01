using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
    public interface IDAOTrancheMarketer
    {

        TrancheMarketer ajouter(TrancheMarketer u);

        TrancheMarketer modifier(TrancheMarketer u);

        TrancheMarketer rechercher(string code);

        TrancheMarketer supprimer(TrancheMarketer u);

        List<TrancheMarketer> rechercherParMC(Func<TrancheMarketer, bool> predicate);

        TrancheMarketer rechercherUnique(TrancheMarketer m);

        List<TrancheMarketer> rechercherTous();

    }
}
