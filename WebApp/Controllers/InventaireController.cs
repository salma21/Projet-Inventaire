using Domain;
using Log;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class InventaireController : Controller
    {
        IInventaireService db = new InventaireService();
        IBiensService bien = new BiensService();
        // GET: Inventaire
        public ActionResult GetInventaire()
        {
            var inv = db.GetInventaires();
            return View(inv);
        }
        public ActionResult AddBien(int id)
        {
            var bureaux = BissInventaireEntities.Instance.Bureau.ToList();
            var etage = BissInventaireEntities.Instance.Etage.ToList();
            var batiment = BissInventaireEntities.Instance.Batiment.ToList();



            ViewData["etage"] = new SelectList(etage, "Description", "Description   ");
            ViewData["batiment"] = new SelectList(batiment, "Description", "Description");
            ViewData["bureaux"] = new SelectList(bureaux, "Description", "Description");
            //var inv = BissInventaireEntities.Instance.AtbDataTest.ToList(); 
            var inv = BissInventaireEntities.Instance.Bien.ToList();
            return View(inv);
        }

        public ActionResult RapportBien(string Bureaux, string Etage, string Batiment)
        {

            var bureaux = BissInventaireEntities.Instance.Bureau.ToList();
            var etage = BissInventaireEntities.Instance.Etage.ToList();
            var batiment = BissInventaireEntities.Instance.Batiment.ToList();



            ViewData["etage"] = new SelectList(etage, "Description", "Description   ");
            ViewData["batiment"] = new SelectList(batiment, "Description", "Description");
            ViewData["bureaux"] = new SelectList(bureaux, "Description", "Description");
            var bien = BissInventaireEntities.Instance.Bien.ToList();
            int nbr = bien.ToList().Count();
            ViewBag.nbr = nbr;


            if (string.IsNullOrEmpty(Bureaux) && string.IsNullOrEmpty(Etage) && string.IsNullOrEmpty(Batiment))
            {
                return View(bien.ToList());

            }
            else
            {

                var dep = from s in bien select s;
                if (String.IsNullOrEmpty(Bureaux) || String.IsNullOrEmpty(Etage) || (String.IsNullOrEmpty(Batiment)))
                {
                    dep = dep.Where(s => (string.IsNullOrEmpty(Bureaux) || (s.Bureau.Description.ToString().StartsWith(Bureaux)))
                    && (string.IsNullOrEmpty(Etage) || (s.Bureau.Etage.description.ToString().StartsWith(Etage)))
                    && (string.IsNullOrEmpty(Batiment) || (s.Bureau.Etage.Batiment.description.ToString().StartsWith(Batiment)))

                    );

                }
                else
                {
                    dep = dep.Where(s => (s.Bureau.Description.ToString().StartsWith(Bureaux))
                    && (s.Bureau.Etage.description.ToString().StartsWith(Etage))
                    && (s.Bureau.Etage.Batiment.description.ToString().StartsWith(Batiment))

                        );

                }

                int nbr2 = dep.ToList().Count();
                ViewBag.nbr = nbr2;
                return View(dep.ToList())
                    ;
            }
        }
        [HttpPost]
        public ActionResult Ajouter(int id)
        {
            var b1 = bien.FindBienByID(id);
            Association_30 ass = new Association_30();
            ass.Id_bien = id;
           
            return View();
        }


        public ActionResult CreateInventaire()
        {

            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateInventaire(Inventaire reg)
        {
            try
            {
                reg.Date = DateTime.Now;
                db.CreateInventaire(reg);
                db.SaveInventaire();
                
                return RedirectToAction("GetInventaire");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Inventaire/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventaire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventaire/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventaire/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inventaire/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventaire/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventaire/Delete/5
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
