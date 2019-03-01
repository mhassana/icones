using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary.DAO
{
   public class DAOFournisseur : IDAOFournisseur
    {
        private isoftTankEntities db = null;

        public DAOFournisseur()
        {
            db = new isoftTankEntities();
        }

        public Fournisseur ajouter(Fournisseur u)
        {
            if (u == null)
                u = new Fournisseur();
            try
            {
                db.creerFournisseur(u.adresse, u.email, u.nom, u.pays, u.telephone, u.ville, u.codeU);
            }
            catch (Exception ex)
            {
                u.adresse = ex.StackTrace;
            }

            return u;
        }

        public Fournisseur modifier(Fournisseur u)
        {
            if (u == null)
                u = new Fournisseur();
            try
            {
                //verification de l'existence de l'objet dans la bd
                if (db.Fournisseurs.First(x => x.codeFOURNISSEUR == u.codeFOURNISSEUR) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.modifierFournisseur(u.codeFOURNISSEUR, u.adresse, u.email, u.nom, u.pays, u.telephone, u.ville, u.codeU);
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

        public Fournisseur supprimer(Fournisseur u)
        {
            if (u == null)
                u = new Fournisseur();
            try
            {
                if (db.Fournisseurs.First(x => x.codeFOURNISSEUR == u.codeFOURNISSEUR) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerFournisseur(u.codeFOURNISSEUR, u.codeU);
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


        public Fournisseur rechercher(string code)
        {
            Fournisseur u = new Fournisseur();
            try
            {
                u = db.Fournisseurs.First(x => x.codeFOURNISSEUR == code);

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


        public List<Fournisseur> rechercherParMC(Func<Fournisseur, bool> predicate)
        {
            List<Fournisseur> us = new List<Fournisseur>();
            try
            {
                us = db.Fournisseurs.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Fournisseur p = new Fournisseur();
                p.adresse = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        public Fournisseur rechercherUnique(Fournisseur m)
        {
            Fournisseur u = new Fournisseur();

            try
            {
                u = db.Fournisseurs.First(x => x.adresse == m.adresse && x.email == m.email && x.nom == m.nom && x.pays == m.pays && x.telephone == m.telephone && x.ville == m.ville);

            }

            catch (Exception ex)
            {
                u.adresse = ex.StackTrace;
            }


            return u;

        }

        public List<Fournisseur> rechercherTous()
        {
            List<Fournisseur> us = new List<Fournisseur>();
            try
            {
                us = db.Fournisseurs.ToList();
            }
            catch (Exception ex)
            {
                Fournisseur p = new Fournisseur();
                p.adresse = ex.StackTrace;
                us.Add(p);
            }

            return us;

        }

        ~DAOFournisseur()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
