using brouillon.Models;
using ClassLibrary;
using ClassLibrary.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace brouillon.Controllers
{
    public class TaxeController : Controller
    {
        DAOTaxe dao = new DAOTaxe();
        // GET: Taxe
        public ActionResult Index()
        {
            return View();
        }

        // GET: Taxe/Details/5
        public ActionResult Details(string code)
        {
            Taxe x = dao.rechercher(code);

            TaxeModel pm = new TaxeModel
            {
                codeTAXE = x.codeTAXE,
                libelle = x.libelle,
                taux = x.taux,

            };

            if (x == null)
            {
                return HttpNotFound();
            }
            return View(pm);
        }

        public ActionResult Creer()
        {
            return View("Create");
        }

        // GET: Taxe/Create
        public ActionResult Create(Taxe m)
        {
            TaxeModel pm = new TaxeModel();

            return View("Create", pm);
        }

        // POST: Taxe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Taxe x = new Taxe
                {
                    libelle = collection["libelle"],
                     taux = decimal.Parse(collection["taux"]),


                    //*******

                    codeU = collection["codeU"],
                    date_c = DateTime.Now
                };


                dao.ajouter(x);

                return RedirectToAction("afficherTous");
            }
            catch (Exception ex)
            {
                ViewBag.Erreur = ex.Message;
                return View();
            }
        }

        // GET: Taxe/Edit/5
        public ActionResult Edit(string code)
        {
            Taxe x = dao.rechercher(code);

            TaxeModel pm = new TaxeModel
            {
                libelle = x.libelle,
                taux = x.taux,


                ///*******
                /// 
                codeU = x.codeU,
                codeTAXE = x.codeTAXE

            };

            return View(pm);
        }

        // POST: Taxe/Edit/5
        [HttpPost]
        public ActionResult Edit(Taxe x)
        {
            try
            {


                dao.modifier(x);
                // TODO: Add update logic here

                return RedirectToAction("afficherTous");
            }
            catch
            {
                return View();
            }
        }

        // GET: Depot/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Taxe/Delete/5
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

        public ActionResult afficherTous()
        {
            IEnumerable<Taxe> ls = dao.rechercherTous();

            ViewBag.listeTaxe = ls;

            return View();
        }
    }
}