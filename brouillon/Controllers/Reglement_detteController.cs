using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;
using ClassLibrary.DAO.DAOImp;
using brouillon.Models;
using System.Data;
using ClassLibrary.DAO.IDAO;

namespace brouillon.Controllers
{
    public class Reglement_detteController : Controller
    {
        IDAOReglement_dette dao = new DAOReglement_dette();
        // GET: Reglement_dette
        public ActionResult Index()
        {
            try
            {
                IEnumerable<Reglement_dette> ls = dao.rechercherTous();

                ViewBag.listeReglement = ls;

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Reglement_dette/Details/5
        public ActionResult Details(string code)
        {
            Reglement_dette x = dao.rechercher(code);

            Reglement_detteModel pm = new Reglement_detteModel
            {
                codeREGLEMENT_DETTE = x.codeREGLEMENT_DETTE,
                codeDETTE = x.codeDETTE,
                libelle = x.libelle,
                montant = x.montant,
                date_paiement = x.date_paiement,
                codeU = x.codeU
            };

            if (x == null)
            {
                return HttpNotFound();
            }
            return View(pm);

        }

        // GET: Reglement_dette/Create
        public ActionResult Create()
        {
            Reglement_detteModel pm = new Reglement_detteModel();

            return View("Create", pm);
        }

        // POST: Reglement_dette/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
                try
                {
                    // TODO: Add insert logic here
                    Reglement_dette x = new Reglement_dette
                    {
                        libelle = collection["libelle"],
                        montant = Decimal.Parse(collection["montant"]),
                        codeDETTE = collection["codeDETTE"],
                        date_paiement = DateTime.Now,


                        //*******

                        codeU = collection["codeU"],
                        date_c = DateTime.Now,
                        //codePRODUIT = "PDT20192208"
                    };


                    dao.ajouter(x);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Erreur = ex.Message;
                    return View();
                }
        }

        // GET: Reglement_dette/Edit/5
        public ActionResult Edit(string code)
        {
            Reglement_dette x = dao.rechercher(code);

            Reglement_detteModel pm = new Reglement_detteModel
            {
                libelle = x.libelle,
                montant = x.montant,
                date_paiement = DateTime.Now,


                ///*******

                //codeDETTE =
                //CodeU = produit.codeU,
                //date_c = produit.date_c
            };

            return View(pm);
        }

        [HttpPost]
        public ActionResult Edit(Reglement_dette x)
        {
            try
            {

                dao.modifier(x);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reglement_dette/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reglement_dette/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
