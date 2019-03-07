using ClassLibrary.Metier.IServices;
using ClassLibrary.DAO.IDAO;
using ClassLibrary.DAO;
using System;

namespace ClassLibrary.Metier.ServicesImp
{
    public class Creation : ICreation
    {
        private IDAOProduit daoProduit;

        public Creation()
        {
            daoProduit = new DAOProduit();
        }
        public Produit enregistrerProduit(Produit p)
        {
            Produit p2 = new Produit();
            try
            {
                if (p != null)
                {
                    p2 = daoProduit.rechercherUnique(p);

                    if (p2.designation == p.designation && p2.libelle == p.libelle && p2.prix == p.prix
                         && p2.unite_mesure == p.unite_mesure) ;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return x;
        }
    }
}
