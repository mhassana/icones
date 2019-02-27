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

        IEnumerable<Marketer> rechercherParMC(Func<Marketer, bool> predicate);

        IEnumerable<Transaction_effectuee> rechercherTous();

    }
}
