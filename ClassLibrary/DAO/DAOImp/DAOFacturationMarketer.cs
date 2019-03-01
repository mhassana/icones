using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary.DAO
{
   public class DAOFacturationMarketer : IDAOFacturationMarketer
    {
        private isoftTankEntities db = null;

        public DAOFacturationMarketer()
        {
            db = new isoftTankEntities();
        }

        public FacturationMarketer ajouter(FacturationMarketer u)
        {
            if (u == null)
                u = new FacturationMarketer();
            try
            {
                db.creerFacturationMarketer(u.libelle, u.montant_paye, u.montant_restant, u.montant_total, u.codeCOMMANDE_MARKETER, u.codeU);
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }

        public FacturationMarketer modifier(FacturationMarketer u)
        {
            if (u == null)
                u = new FacturationMarketer();
            try
            {
                //verification de l'existence de l'objet dans la bd
                if (db.FacturationMarketers.First(x => x.codeFACTURATION_MARKETER == u.codeFACTURATION_MARKETER) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.modifierFacturationMarketer(u.codeFACTURATION_MARKETER, u.libelle, u.montant_paye, u.montant_restant, u.montant_total, u.codeCOMMANDE_MARKETER, u.codeU);
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

        public FacturationMarketer supprimer(FacturationMarketer u)
        {
            if (u == null)
                u = new FacturationMarketer();
            try
            {
                if (db.FacturationMarketers.First(x => x.codeFACTURATION_MARKETER == u.codeFACTURATION_MARKETER) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerFacturationMarketer(u.codeFACTURATION_MARKETER, u.codeCOMMANDE_MARKETER, u.codeU);
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


        public FacturationMarketer rechercher(string code)
        {
            FacturationMarketer u = new FacturationMarketer();
            try
            {
                u = db.FacturationMarketers.First(x => x.codeFACTURATION_MARKETER == code);

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


        public List<FacturationMarketer> rechercherParMC(Func<FacturationMarketer, bool> predicate)
        {
            List<FacturationMarketer> us = new List<FacturationMarketer>();
            try
            {
                us = db.FacturationMarketers.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                FacturationMarketer p = new FacturationMarketer();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        //public FacturationMarketer rechercherUnique(FacturationMarketer m)
        //{
        //    FacturationMarketer u = new FacturationMarketer();

        //    try
        //    {
        //        u = db.FacturationMarketers.First(x => x.adresse == m.adresse && x.email == m.email && x.localisation == m.localisation && x.nom == m.nom && x.pays == m.pays && x.telephone == m.telephone && x.ville == m.ville);

        //    }

        //    catch (Exception ex)
        //    {
        //        u.adresse = ex.StackTrace;
        //    }


        //    return u;

        //}

        public List<FacturationMarketer> rechercherTous()
        {
            List<FacturationMarketer> us = new List<FacturationMarketer>();
            try
            {
                us = db.FacturationMarketers.ToList();
            }
            catch (Exception ex)
            {
                FacturationMarketer p = new FacturationMarketer();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;

        }

        ~DAOFacturationMarketer()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
