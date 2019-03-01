using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary
{
    public class DAOMarketer : IDAOMarketer
    {
        private isoftTankEntities db = null;

        public DAOMarketer()
        {
            db = new isoftTankEntities();
        }

        public Marketer ajouter(Marketer u)
        {
            if (u == null)
                u = new Marketer();
            try
            {
                db.creerMarketer(u.adresse, u.email, u.nom, u.pays, u.telephone, u.ville, u.codeU);
            }
            catch (Exception ex)
            {
                u.adresse = ex.StackTrace;
            }

            return u;
        }

        public Marketer modifier(Marketer u)
        {
            if (u == null)
                u = new Marketer();
            try
            {
                //verification de l'existence de l'objet dans la bd
                if (db.Marketers.First(x => x.codeMARKETER == u.codeMARKETER) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.modifierMarketer(u.codeMARKETER, u.adresse, u.email, u.nom, u.pays, u.telephone, u.ville, u.codeU);
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

        public Marketer supprimer(Marketer u)
        {
            if (u == null)
                u = new Marketer();
            try
            {
                if (db.Marketers.First(x => x.codeMARKETER == u.codeMARKETER) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerMarketer(u.codeMARKETER, u.codeU);
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


        public Marketer rechercher(string code)
        {
            Marketer u = new Marketer();
            try
            {
                u = db.Marketers.First(x => x.codeMARKETER == code);

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


        public List<Marketer> rechercherParMC(Func<Marketer, bool> predicate)
        {
            List<Marketer> us = new List<Marketer>();
            try
            {
                us = db.Marketers.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Marketer p = new Marketer();
                p.adresse = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        public Marketer rechercherUnique(Marketer m)
        {
            Marketer u = new Marketer();

            try
            {
                u = db.Marketers.First(x => x.adresse == m.adresse && x.email == m.email && x.nom == m.nom && x.pays == m.pays && x.telephone == m.telephone && x.ville == m.ville);

            }

            catch (Exception ex)
            {
                u.adresse = ex.StackTrace;
            }


            return u;

        }

        public List<Marketer> rechercherTous()
        {
            List<Marketer> us = new List<Marketer>();
            try
            {
                us = db.Marketers.ToList();
            }
            catch (Exception ex)
            {
                Marketer p = new Marketer();
                p.adresse = ex.StackTrace;
                us.Add(p);
            }

            return us;

        }

        ~DAOMarketer()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
