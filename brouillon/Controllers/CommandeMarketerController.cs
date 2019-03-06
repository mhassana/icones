using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClassLibrary;
using ClassLibrary.DAO;
using ClassLibrary.DAO.IDAO;
using brouillon.Models;
using System.Data;

namespace brouillon.Controllers
{
    public class CommandeMarketerController : Controller
    {
        IDAOCommandeMarketer dao = new DAOCommandeMarketer();

        // GET: Commande_marketer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Commande_marketer/Details/5
        public ActionResult Details(string code)
        {
            Commande_marketer x = dao.rechercher(code);

            CommandeMarketerModel pm = new CommandeMarketerModel
            {
                codeCOMMANDE_MARKETER = x.codeCOMMANDE_MARKETER,
                quantite = x.quantite

            };

            if (x == null)
            {
                return HttpNotFound();
            }
            return View(pm);
        }


        // GET: Commande_marketer/Create
        public ActionResult Create()
        {
            CommandeMarketerModel tm = new CommandeMarketerModel();

            return View("Create", tm);
        }

        // POST: Commande_marketer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                string s = "";
                s = collection["quantite"];
                char decimalSymbol = ',';
                var curr = System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                s = s.Replace(".", curr).Replace(decimalSymbol.ToString(), curr);

                Commande_marketer x = new Commande_marketer
                {
                    quantite = decimal.Parse(s),


                    //*******

                    codeU = collection["codeU"],
                    codeFOURNISSEUR = collection["codeFOURNISSEUR"],
                    codePRODUIT = collection["codePRODUIT"],
                    codeMARKETER = collection["codeMARKETER"]
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

        // GET: Commande_marketer/Edit/5
        public ActionResult Edit(string code)
        {
            Commande_marketer x = dao.rechercher(code);

            CommandeMarketerModel pm = new CommandeMarketerModel
            {
                quantite = x.quantite,


                ///*******
                /// 
                codeU = x.codeU,
                codeCOMMANDE_MARKETER = x.codeCOMMANDE_MARKETER

            };

            return View(pm);
        }

        // POST: Commande_marketer/Edit/5
        [HttpPost]
        public ActionResult Edit(Commande_marketer x)
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

        // GET: Commande_marketer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Commande_marketer/Delete/5
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
            IEnumerable<Commande_marketer> ls = dao.rechercherTous();

            ViewBag.listeCommande_marketer = ls;

            return View();
        }
    }
}