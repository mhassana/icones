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
    public class CompteMarketerController : Controller
    {
        DAOCompteMarketer dao = new DAOCompteMarketer();
        // GET: Marketer
        public ActionResult Index()
        {
            return View();
        }

        // GET: CompteMarketer/Details/5
        public ActionResult Details(string code)
        {
            Compte_marketer x = dao.rechercher(code);

            CompteMarketerModel pm = new CompteMarketerModel
            {
                codeCOMPTE_MARKETER = x.codeCOMPTE_MARKETER,
                montant_net = x.montant_net,
                codeMARKETER = x.codeMARKETER,

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

        // GET: CompteMarketer/Create
        public ActionResult Create(Compte_marketer m)
        {
            CompteMarketerModel pm = new CompteMarketerModel();

            return View("Create", pm);
        }

        // POST: CompteMarketer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Compte_marketer x = new Compte_marketer
                {
                    montant_net = decimal.Parse(collection["montant_net"]),


                    //*******

                    codeMARKETER = collection["codeMARKETER"],
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

        // GET: CompteMarketer/Edit/5
        public ActionResult Edit(string code)
        {
            Compte_marketer x = dao.rechercher(code);

            CompteMarketerModel pm = new CompteMarketerModel
            {
                montant_net = x.montant_net,


                ///*******
                /// 
                codeU = x.codeU,
                codeCOMPTE_MARKETER = x.codeCOMPTE_MARKETER

            };

            return View(pm);
        }

        // POST: CompteMarketer/Edit/5
        [HttpPost]
        public ActionResult Edit(Compte_marketer x)
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

        // GET: CompteMarketer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompteMarketer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("afficherTous");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult afficherTous()
        {
            IEnumerable<Compte_marketer> ls = dao.rechercherTous();

            ViewBag.listeCompte_marketer = ls;

            return View();
        }
    }
}