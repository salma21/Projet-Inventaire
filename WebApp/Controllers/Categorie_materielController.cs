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
        public class Categorie_materielController : Controller
        {
            private ICategorie_materielService db = new Categorie_materielService();
            // GET: Categorie_materiel
            public ActionResult Index()
            {
                return View();
            }

            public ActionResult GetCategorie_materiel()
            {
                var Categorie_materiel = db.GetCategorie_materiels();
                return View(Categorie_materiel);
            }


       
            // GET: Categorie_materiel/Details/5
            public ActionResult Details(int Id_categorie)
            {
                try
                {

                    var archive = BissInventaireEntities.Instance.Categorie_materiel.Find(Id_categorie);

                    return View(archive);
                }
                catch (Exception ex)
                {


                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }

            }

            // GET: Categorie_materiel/Create
            public ActionResult CreateCategorie_materiel()
            {
                return View();
            }

            // POST: Categorie_materiel/Create
            [HttpPost]
            public ActionResult CreateCategorie_materiel(Categorie_materiel Catm, FormCollection collection)
            {
                try
                {
                    BissInventaireEntities.Instance.Categorie_materiel.Add(Catm);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetCategorie_materiel");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }


        public ActionResult EditCategorie_materiel(int id)
        {
            var cat = db.GetCategorie_materiel(id);
            return View(cat);
        }

        // POST: Categorie_materiel/Create
        [HttpPost]
        public ActionResult EditCategorie_materiel(Categorie_materiel Catm)
        {
            try
            {
                db.UpdateCategorie_materielDetached(Catm);
               db.SaveCategorie_materiel();
                return RedirectToAction("GetCategorie_materiel");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Categorie_materiel/Edit/5
        public ActionResult Edit(int Id_categorie)
            {
                return View();
            }

            // POST: Categorie_materiel/Edit/5
            [HttpPost]
            public ActionResult Edit(int Id_categorie, FormCollection collection)
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

            // GET: Categorie_materiel/Delete/5
            public ActionResult Delete(int Id_categorie)
            {
                return View();
            }

            // POST: Categorie_materiel/Delete/5
            [HttpPost]
            public ActionResult Delete(int Id_categorie, FormCollection collection)
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
