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
    public class FournisseurController : Controller
    {
        DAOFournisseur dao = new DAOFournisseur();
        // GET: Marketer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Marketer/Details/5
        public ActionResult Details(string code)
        {
            Fournisseur x = dao.rechercher(code);

            FournisseurModel pm = new FournisseurModel
            {
                codeFOURNISSEUR = x.codeFOURNISSEUR,
                nom = x.nom,
                adresse = x.adresse,
                email = x.email,
                pays = x.pays,
                telephone = x.telephone,
                ville = x.ville
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

        // GET: Fournisseur/Create
        public ActionResult Create(Fournisseur m)
        {
            FournisseurModel pm = new FournisseurModel();

            return View("Create", pm);
        }

        // POST: Fournisseur/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Fournisseur x = new Fournisseur
                {
                    nom = collection["nom"],
                    ville = collection["ville"],
                    pays = collection["pays"],
                    telephone = collection["telephone"],
                    email = collection["email"],
                    adresse = collection["adresse"],


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

        // GET: Fournisseur/Edit/5
        public ActionResult Edit(string code)
        {
            return View();
        }

        // POST: Fournisseur/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("afficherTous");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fournisseur/Delete/5
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
            IEnumerable<Fournisseur> ls = dao.rechercherTous();

            ViewBag.listeFournisseur = ls;

            return View();
        }
    }
}