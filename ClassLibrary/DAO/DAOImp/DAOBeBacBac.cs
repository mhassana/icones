using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary.DAO
{
   public class DAOBeBacBac : IDAOBeBacBac
    {
        private isoftTankEntities db = null;

        public DAOBeBacBac()
        {
            db = new isoftTankEntities();
        }

        public BE_bac_bac ajouter(BE_bac_bac u)
        {
            if (u == null)
                u = new BE_bac_bac();
            try
            {
                db.creerBE_bac_bac(u.libelle, u.quantite, u.codeCOMMANDE_MARKET, u.codeDEPOT, u.codeU);
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }

        public BE_bac_bac modifier(BE_bac_bac u)
        {
            if (u == null)
                u = new BE_bac_bac();
            try
            {
                //verification de l'existence de l'objet dans la bd
                if (db.BE_bac_bac.First(x => x.codeBE_BAC_BAC == u.codeBE_BAC_BAC) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.modifierBE_bac_bac(u.codeBE_BAC_BAC, u.libelle, u.quantite, u.codeCOMMANDE_MARKET, u.codeDEPOT, u.codeU);
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

        public BE_bac_bac supprimer(BE_bac_bac u)
        {
            if (u == null)
                u = new BE_bac_bac();
            try
            {
                if (db.BE_bac_bac.First(x => x.codeBE_BAC_BAC == u.codeBE_BAC_BAC) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerBE_bac_bac(u.codeBE_BAC_BAC, u.codeCOMMANDE_MARKET, u.codeDEPOT, u.codeU);
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


        public BE_bac_bac rechercher(string code)
        {
            BE_bac_bac u = new BE_bac_bac();
            try
            {
                u = db.BE_bac_bac.First(x => x.codeBE_BAC_BAC == code);

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


        public List<BE_bac_bac> rechercherParMC(Func<BE_bac_bac, bool> predicate)
        {
            List<BE_bac_bac> us = new List<BE_bac_bac>();
            try
            {
                us = db.BE_bac_bac.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                BE_bac_bac p = new BE_bac_bac();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        public BE_bac_bac rechercherUnique(BE_bac_bac m)
        {
            BE_bac_bac u = new BE_bac_bac();

            try
            {
                u = db.BE_bac_bac.First(x => x.libelle == m.libelle && x.quantite == m.quantite);

            }

            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }


            return u;

        }

        public List<BE_bac_bac> rechercherTous()
        {
            List<BE_bac_bac> us = new List<BE_bac_bac>();
            try
            {
                us = db.BE_bac_bac.ToList();
            }
            catch (Exception ex)
            {
                BE_bac_bac p = new BE_bac_bac();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;

        }

        ~DAOBeBacBac()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
