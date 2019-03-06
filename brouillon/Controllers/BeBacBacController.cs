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
    public class BeBacBacController : Controller
    {
        IDAOBeBacBac dao = new DAOBeBacBac();

        // GET: BE_bac_bac
        public ActionResult Index()
        {
            return View();
        }

        // GET: BE_bac_bac/Details/5
        public ActionResult Details(string code)
        {
            BE_bac_bac x = dao.rechercher(code);

            BEBacBacModel pm = new BEBacBacModel
            {
                codeBE_BAC_BAC = x.codeBE_BAC_BAC,
                quantite = x.quantite,
                libelle = x.libelle

            };

            if (x == null)
            {
                return HttpNotFound();
            }
            return View(pm);
        }


        // GET: BE_bac_bac/Create
        public ActionResult Create()
        {
            BEBacBacModel tm = new BEBacBacModel();

            return View("Create", tm);
        }

        // POST: BE_bac_bac/Create
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

                BE_bac_bac x = new BE_bac_bac
                {
                    libelle = collection["libelle"],
                    quantite = decimal.Parse(s),


                    //*******

                    codeU = collection["codeU"],
                    codeCOMMANDE_MARKET = collection["codeCOMMANDE_MARKET"],
                    codeDEPOT = collection["codeDEPOT"]
                    //date_c = DateTime.Now
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

        // GET: BE_bac_bac/Edit/5
        public ActionResult Edit(string code)
        {
            BE_bac_bac x = dao.rechercher(code);

            BEBacBacModel pm = new BEBacBacModel
            {
                quantite = x.quantite,
                libelle = x.libelle,


                ///*******
                /// 
                codeU = x.codeU,
                codeCOMMANDE_MARKET = x.codeCOMMANDE_MARKET,
                codeDEPOT = x.codeDEPOT


            };

            return View(pm);
        }

        // POST: BE_bac_bac/Edit/5
        [HttpPost]
        public ActionResult Edit(BE_bac_bac x)
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

        // GET: BE_bac_bac/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BE_bac_bac/Delete/5
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
            IEnumerable<BE_bac_bac> ls = dao.rechercherTous();

            ViewBag.listeBE_bac_bac = ls;

            return View();
        }
    }
}