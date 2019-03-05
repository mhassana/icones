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
    public class DepotController : Controller
    {
        DAODepot dao = new DAODepot();
        // GET: Marketer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Depot/Details/5
        public ActionResult Details(string code)
        {
            Depot x = dao.rechercher(code);

            DepotModel pm = new DepotModel
            {
                codeDEPOT = x.codeDEPOT,
                nom = x.nom,
                adresse = x.adresse,
                email = x.email,
                pays = x.pays,
                telephone = x.telephone,
                ville = x.ville,
                localisation = x.localisation
               
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

        // GET: Depot/Create
        public ActionResult Create(Depot m)
        {
            DepotModel pm = new DepotModel();

            return View("Create", pm);
        }

        // POST: Depot/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Depot x = new Depot
                {
                    nom = collection["nom"],
                    ville = collection["ville"],
                    pays = collection["pays"],
                    telephone = collection["telephone"],
                    email = collection["email"],
                    adresse = collection["adresse"],
                    localisation = collection["localisation"],


                    //*******

                    codeU = collection["codeU"],
                    date_c = DateTime.Now,
                    //codePRODUIT = "PDT20192208"
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

        // GET: Depot/Edit/5
        public ActionResult Edit(string code)
        {
            Depot x = dao.rechercher(code);

            DepotModel pm = new DepotModel
            {
                nom = x.nom,
                ville = x.ville,
                pays = x.pays,
                telephone = x.telephone,
                email = x.email,
                adresse = x.adresse,
                localisation = x.localisation,


                ///*******
                /// 
                codeU = x.codeU,
                codeDEPOT = x.codeDEPOT

            };

            return View(pm);
        }

        // POST: Depot/Edit/5
        [HttpPost]
        public ActionResult Edit(Depot x)
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

        // POST: Depot/Delete/5
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
            IEnumerable<Depot> ls = dao.rechercherTous();

            ViewBag.listeDepot = ls;

            return View();
        }
    }
}