using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO.IDAO
{
    public interface IDAOProduit
    {
        Produit ajouter(Produit u);

        Produit modifier(Produit u);

        Produit supprimer(Produit u);

        Produit rechercher(string code);

        List<Produit> rechercherParMC(Func<Produit, bool> predicate);

        Produit rechercherUnique(Produit m);

        List<Produit> rechercherTous();

    }
}
