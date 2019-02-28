using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary.DAO
{
    public class DAODepot : IDAODepot
    {
        private isoftTankEntities db = null;

        public DAODepot()
        {
            db = new isoftTankEntities();
        }

        public Depot ajouter(Depot u)
        {
            try
            {
                if (db.creerDepot(u.adresse, u.email, u.localisation, u.nom, u.pays, u.telephone, u.ville, u.codeU) != 1)
                    
                    u.nom = "Erreur rencontree. Details >>> ";

            }
            catch (Exception ex)
            {
                u.nom = ex.StackTrace;
            }

            return u;
        }

        public Depot modifier(Depot u)
        {
            //recherche de l'objet dans la bd
            Depot u2 = new Depot();

            //verification de l'existence de l'objet dans la bd
            if (u != null)
            {
                //mise a jour des modifications
                u2.adresse = u.adresse;
                u2.email = u.email;
                u2.nom = u.nom;
                u2.pays = u.pays;
                u2.telephone = u.telephone;
                u2.ville = u.ville;
                u2.localisation = u.localisation;
            }
                //sauvegarde des nouvelles informations

                try
                {
                    if (db.modifierDepot(u2.codeDEPOT, u2.adresse, u2.email, u2.localisation, u2.nom, u2.pays, u2.telephone, u2.ville, u2.codeU) != 1)
                        u2.nom = "Erreur rencontree. Details >>> ";
                }
                catch (Exception ex)
                {
                    u2.nom = ex.StackTrace;
                }

                return u2;
        }

        public Depot rechercher(string code)
        {
            Depot u = db.Depots.First(x => x.codeDEPOT == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.nom = "Aucun enregistrement trouve.";
                return u;
            }
        }

        public Depot supprimer(Depot u)
        {

            if (u != null)
            {

                try
                {
                    db.supprimerDepot(u.codeDEPOT, u.codeU);
                    u.nom = "Erreur rencontree. Details >>> ";
                }
                catch (Exception ex)
                {
                    u.nom = ex.StackTrace;
                }

            }
                return u;
        }

        public IEnumerable<Marketer> rechercherParMC(Func<Marketer, bool> predicate)
        {
            var us = db.Marketers.Where(predicate);

            return us.ToList();
        }

        public IEnumerable<Depot> rechercherTous()
        {
            return db.Depots.ToList();

        }

        ~DAODepot()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
