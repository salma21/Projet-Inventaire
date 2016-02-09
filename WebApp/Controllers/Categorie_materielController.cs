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
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
            }

            public ActionResult GetCategorie_materiel()
            {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Categorie_materiel = db.GetCategorie_materiels();
            return View(Categorie_materiel);
            }


        public ActionResult GetCategorie_Designation()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Categorie_materiel = db.GetCategorie_Designations();
            return View(Categorie_materiel);
        }


        public ActionResult GetCategorie_Model()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Categorie_materiel = db.GetAllModeles();
            return View(Categorie_materiel);
        }



        // GET: Categorie_materiel/Details/5
        public ActionResult Details(int Id_categorie)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            try
                {

                    var archive = BissInventaireEntities.Instance.Categorie.Find(Id_categorie);

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
            public ActionResult CreateCategorie_materiel(Categorie Catm, FormCollection collection)
            {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Categorie.Add(Catm);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetCategorie_materiel");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
               
                return View();
            }
        }

        public ActionResult CreateCategorie_Designation()
        {
            ViewData["cat"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "Id_categorie", "libelle");

            return View();
        }

        // POST: Categorie_materiel/Create
        [HttpPost]
        public ActionResult CreateCategorie_Designation(Sous_categorie Catm, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Sous_categorie.Add(Catm);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetCategorie_Designation");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {

                return View();
            }
        }

        public ActionResult CreateCategorie_Modele()
        {
            ViewData["cat"] = new SelectList(BissInventaireEntities.Instance.Sous_categorie.ToList(), "Id_categorie", "libelle");
            ViewData["des"] = new SelectList(BissInventaireEntities.Instance.Sous_categorie.ToList(), "id_categorie_Designation", "libelle");

            return View();
        }

        // POST: Categorie_materiel/Create
        [HttpPost]
        public ActionResult CreateCategorie_Modele(Sous_categorie Catm, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Sous_categorie.Add(Catm);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetCategorie_Modele");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {

                return View();
            }
        }

        public ActionResult EditCategorie_materiel(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var cat = db.GetCategorie_materiel(id);
            return View(cat);
        }

        // POST: Categorie_materiel/Create
        [HttpPost]
        public ActionResult EditCategorie_materiel(Categorie Catm)
        {
            if (ModelState.IsValid)
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
            else

            {
                return View();
            }
        }

        public ActionResult EditCategorie_Designation(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["cat"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "Id_categorie", "libelle");
           
            var cat = db.FindCategorie_DesignationById(id);
            return View(cat);
        }

        // POST: Categorie_materiel/Create
        [HttpPost]
        public ActionResult EditCategorie_Designation(Sous_categorie Catm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UpdateCategorie_DesignationDetached(Catm);
                    db.SaveCategorie_materiel();
                    return RedirectToAction("GetCategorie_Designation");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                return View();
            }
        }
        public ActionResult EditCategorie_Modele(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }

            ViewData["cat"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "Id_categorie", "libelle");
            ViewData["des"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "id_categorie_Designation", "libelle");

            var cat = db.FindCategorie_ModeleById(id);
            return View(cat);
        }

        // POST: Categorie_materiel/Create
        [HttpPost]
        public ActionResult EditCategorie_Modele(Modele Catm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UpdateCategorie_ModeleDetached(Catm);
                    db.SaveCategorie_materiel();
                    return RedirectToAction("GetCategorie_Modele");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                return View();
            }
        }

        // GET: Categorie_materiel/Edit/5
        public ActionResult Edit(int Id_categorie)
            {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
            }

            // POST: Categorie_materiel/Edit/5
            [HttpPost]
            public ActionResult Edit(int Id_categorie, FormCollection collection)
            {
            if (ModelState.IsValid)
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
            else

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


        [HttpPost]
        public ActionResult GetModeleBySousCat(int stateid)
        {
           
            List<Modele> objcity = new List<Modele>();

            objcity = db.FindModeleByIdDes(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "id_categorie_Designation", "libelle", 0);
            return Json(obgcity);
        }
    }
    }
