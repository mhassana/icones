using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary.DAO.DAOImp
{
    public class DAOReglement_dette : IDAOReglement_dette
    {
        private isoftTankEntities db = null;

        public DAOReglement_dette()
        {
            db = new isoftTankEntities();
        }

        public Reglement_dette ajouter(Reglement_dette u)
        {
            if (u == null)
                u = new Reglement_dette();
            try
            {
                db.creerReglement_dette(u.libelle, u.montant, u.codeDETTE, u.codeU);
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }

        public Reglement_dette modifier(Reglement_dette u)
        {
            if (u == null)
                u = new Reglement_dette();
            try
            {
                //verification de l'existence de l'objet dans la bd
                if (db.Reglement_dette.First(x => x.codeREGLEMENT_DETTE == u.codeREGLEMENT_DETTE) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.modifierReglement_dette(u.codeREGLEMENT_DETTE, u.date_paiement, u.libelle, u.montant, u.codeDETTE, u.codeU);
                }

                else
                {
                    u.libelle = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }
            return u;
        }

        public Reglement_dette supprimer(Reglement_dette u)
        {
            if (u == null)
                u = new Reglement_dette();
            try
            {
                if (db.Reglement_dette.First(x => x.codeREGLEMENT_DETTE == u.codeREGLEMENT_DETTE) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerReglement_dette(u.codeREGLEMENT_DETTE, u.codeDETTE, u.codeU);
                }

                else
                {
                    u.libelle = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }
            return u;
        }


        public Reglement_dette rechercher(string code)
        {
            Reglement_dette u = new Reglement_dette();
            try
            {
                u = db.Reglement_dette.First(x => x.codeREGLEMENT_DETTE == code);

                //verification de l'existence de l'objet dans la bd
                if (u != null) return u;

                else
                {
                    u.libelle = "Aucun enregistrement trouve.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }


        public List<Reglement_dette> rechercherParMC(Func<Reglement_dette, bool> predicate)
        {
            List<Reglement_dette> us = new List<Reglement_dette>();
            try
            {
                us = db.Reglement_dette.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Reglement_dette p = new Reglement_dette();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        public Reglement_dette rechercherUnique(Reglement_dette m)
        {
            Reglement_dette u = new Reglement_dette();

            try
            {
                u = db.Reglement_dette.First(x => x.libelle == m.libelle);

            }

            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }

        public List<Reglement_dette> rechercherTous()
        {
            List<Reglement_dette> us = new List<Reglement_dette>();
            try
            {
                us = db.Reglement_dette.ToList();
            }
            catch (Exception ex)
            {
                Reglement_dette p = new Reglement_dette();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }

        ~DAOReglement_dette()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
