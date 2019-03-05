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
    public class FactureMarketerController : Controller
    {
            DAOFacturationMarketer dao = new DAOFacturationMarketer();
            // GET: Marketer
            public ActionResult Index()
            {
                return View();
            }

        // GET: FacturationMarketer/Details/5
        public ActionResult Details(string code)
            {
                FacturationMarketer x = dao.rechercher(code);

            FacturationMarketerModel pm = new FacturationMarketerModel
            {
                    codeFACTURATION_MARKETER = x.codeFACTURATION_MARKETER,
                    libelle = x.libelle,
                    montant_paye = x.montant_paye,
                    montant_restant = x.montant_restant,
                    montant_total = x.montant_total,
                    codeCOMMANDE_MARKETER = x.codeCOMMANDE_MARKETER,

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
            public ActionResult Create(FacturationMarketer m)
            {
                FacturationMarketerModel pm = new FacturationMarketerModel();

                return View("Create", pm);
            }

        // POST: FacturationMarketer/Create
        [HttpPost]
            public ActionResult Create(FormCollection collection)
            {
                try
                {

               
                string s, t, u = "";

                s = collection["montant_paye"];
                t = collection["montant_restant"];
                u = collection["montant_total"];
                char decimalSymbol = ',';
                var curr = System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                s = s.Replace(".", curr).Replace(decimalSymbol.ToString(), curr);
                t = t.Replace(".", curr).Replace(decimalSymbol.ToString(), curr);
                u = u.Replace(".", curr).Replace(decimalSymbol.ToString(), curr);

                // TODO: Add insert logic here
                FacturationMarketer x = new FacturationMarketer
                    {
                        libelle = collection["libelle"],
                        montant_paye = decimal.Parse(s),
                        montant_restant = decimal.Parse(t),
                        montant_total = decimal.Parse(u),


                        //*******

                        codeCOMMANDE_MARKETER = collection["codeCOMMANDE_MARKETER"],
                        codeU = collection["codeU"],
                        date_c = DateTime.Now
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

        // GET: FacturationMarketer/Edit/5
        public ActionResult Edit(string code)
            {
                FacturationMarketer x = dao.rechercher(code);

            FacturationMarketerModel pm = new FacturationMarketerModel
            {
                libelle = x.libelle,
                montant_paye = x.montant_paye,
                montant_restant = x.montant_restant,
                montant_total = x.montant_total,


                ///*******
                /// 
                codeU = x.codeU,
                codeCOMMANDE_MARKETER = x.codeCOMMANDE_MARKETER,
                codeFACTURATION_MARKETER = x.codeFACTURATION_MARKETER

                };

                return View(pm);
            }

        // POST: FacturationMarketer/Edit/5
        [HttpPost]
            public ActionResult Edit(FacturationMarketer x)
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

        // GET: FacturationMarketer/Delete/5
        public ActionResult Delete(int id)
            {
                return View();
            }

        // POST: FacturationMarketer/Delete/5
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
                IEnumerable<FacturationMarketer> ls = dao.rechercherTous();

                ViewBag.listeFacturationMarketer = ls;

                return View();
            }
        }
}