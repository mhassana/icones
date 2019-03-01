using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
    public interface IDAOTransactionEffectuee
    {

        Transaction_effectuee ajouter(Transaction_effectuee u);

        Transaction_effectuee modifier(Transaction_effectuee u);

        Transaction_effectuee rechercher(string code);

        Transaction_effectuee supprimer(Transaction_effectuee u);

        List<Transaction_effectuee> rechercherParMC(Func<Transaction_effectuee, bool> predicate);

        Transaction_effectuee rechercherUnique(Transaction_effectuee m);

        List<Transaction_effectuee> rechercherTous();

    }
}
