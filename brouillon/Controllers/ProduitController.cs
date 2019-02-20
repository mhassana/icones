using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;
using ClassLibrary.DAO;
using brouillon.Models;
using System.Data;

namespace brouillon.Controllers
{
    public class ProduitController : Controller
    {
        DAOProduit dao = new DAOProduit();

        // GET: Produit
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produit/Details/5
        public ActionResult Details(string code)
        {
            Produit produit = dao.rechercher(code);

            ProduitModel pm = new ProduitModel
            {
                CodePRODUIT = produit.codePRODUIT,
                CodeU = produit.codeU,
                date_c = produit.date_c,
                Designation = produit.designation,
                Libelle = produit.libelle,
                Prix = produit.prix,
                Unite_mesure = produit.unite_mesure
            };

            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(pm);
        }

        // GET: Produit/Create
        public ActionResult Create()
        {

            ProduitModel pm = new ProduitModel();

            return View("Create", pm);
        }

        // POST: Produit/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Produit produit = new Produit
                {
                    libelle = collection["libelle"],
                    designation = collection["designation"],
                    prix = decimal.Parse(collection["prix"]),
                    unite_mesure = collection["unite_mesure"],


                    //*******

                    codeU = collection["codeU"],
                    date_c = DateTime.Now,
                    codePRODUIT = "PDT20192208"
                };
                

                dao.ajouter(produit);

                return RedirectToAction("afficherTous");
            }
            catch(Exception ex)
            {
                ViewBag.Erreur = ex.Message;
                return View();
            }
        }

        // GET: Produit/Edit/5
        public ActionResult Edit(string code)
        {
            Produit produit = dao.rechercher(code);

            ProduitModel pm = new ProduitModel
            {
                Designation = produit.designation,
                Libelle = produit.libelle,
                Prix = produit.prix,
                Unite_mesure = produit.unite_mesure,


                ///*******

                CodePRODUIT = produit.codePRODUIT,
                CodeU = produit.codeU,
                date_c = produit.date_c
            };

            return View(pm);
        }

        // POST: Produit/Edit/5
        [HttpPost]
        public ActionResult Edit(Produit p)
        {
            try
            {

                dao.modifier(p);
                // TODO: Add update logic here

                return RedirectToAction("afficherTous");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produit/Delete/5
        public ActionResult Delete(string code, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Produit produit = dao.rechercher(code);

            if (produit == null)
            {
                return HttpNotFound();
            }

            ProduitModel pm = new ProduitModel
            {
                CodePRODUIT = produit.codePRODUIT,
                Libelle = produit.libelle,
                Designation = produit.designation,
                Prix = produit.prix,
                Unite_mesure = produit.unite_mesure,
                date_c = produit.date_c,
                CodeU = produit.codeU
            };

            return View(pm);
        }

        // POST: Produit/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Produit p)
        {
            try
            {
                dao.supprimer(p);
            }
            catch (DataException/* dex */)
            {
                // uncomment dex and log error. 
                return RedirectToAction("Delete", new { code = p.codePRODUIT, saveChangesError = true });
            }
            return RedirectToAction("afficherTous");
        }

        public ActionResult afficherTous()
        {
            IEnumerable<Produit> ls = dao.rechercherTous();

            ViewBag.listeProduit = ls;

            return View();
        }
    }
}
