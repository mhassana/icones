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
            if (u == null)
                u = new Depot();
            try
            {
                db.creerDepot(u.adresse, u.email, u.localisation, u.nom, u.pays, u.telephone, u.ville, u.codeU);
            }
            catch (Exception ex)
            {
                u.adresse = ex.StackTrace;
            }

            return u;
        }

        public Depot modifier(Depot u)
        {
            if (u == null)
                u = new Depot();
            try
            {
                //verification de l'existence de l'objet dans la bd
                if (db.Depots.First(x => x.codeDEPOT == u.codeDEPOT) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.modifierDepot(u.codeDEPOT, u.adresse, u.email, u.localisation, u.nom, u.pays, u.telephone, u.ville, u.codeU);
                }

                else
                {
                    u.adresse = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.adresse = ex.StackTrace;
            }


            return u;
        }

        public Depot supprimer(Depot u)
        {
            if (u == null)
                u = new Depot();
            try
            {
                if (db.Depots.First(x => x.codeDEPOT == u.codeDEPOT) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerDepot(u.codeDEPOT, u.codeU);
                }

                else
                {
                    u.adresse = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.adresse = ex.StackTrace;
            }
            return u;
        }


        public Depot rechercher(string code)
        {
            Depot u = new Depot();
            try
            {
                u = db.Depots.First(x => x.codeDEPOT == code);

                //verification de l'existence de l'objet dans la bd
                if (u != null) return u;

                else
                {
                    u.adresse = "Aucun enregistrement trouve.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                u.adresse = ex.StackTrace;
            }

            return u;
        }


        public List<Depot> rechercherParMC(Func<Depot, bool> predicate)
        {
            List<Depot> us = new List<Depot>();
            try
            {
                us = db.Depots.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Depot p = new Depot();
                p.adresse = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        public Depot rechercherUnique(Depot m)
        {
            Depot u = new Depot();

            try
            {
                u = db.Depots.First(x => x.adresse == m.adresse && x.email == m.email && x.localisation == m.localisation && x.nom == m.nom && x.pays == m.pays && x.telephone == m.telephone && x.ville == m.ville);

            }

            catch (Exception ex)
            {
                u.adresse = ex.StackTrace;
            }


            return u;

        }

        public List<Depot> rechercherTous()
        {
            List<Depot> us = new List<Depot>();
            try
            {
                us = db.Depots.ToList();
            }
            catch (Exception ex)
            {
                Depot p = new Depot();
                p.adresse = ex.StackTrace;
                us.Add(p);
            }

            return us;

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
