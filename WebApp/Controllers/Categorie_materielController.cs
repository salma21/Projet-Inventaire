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
        public class CategorieController : Controller
        {
            private ICategorieService db = new CategorieService();
            // GET: Categorie
            public ActionResult Index()
            {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
            }

            public ActionResult GetCategorie()
            {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Categorie = db.GetCategories();
            return View(Categorie);
            }


        public ActionResult GetCategorie_Designation()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Categorie = db.GetCategorie_Designations();
            return View(Categorie);
        }


        public ActionResult GetCategorie_Model()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Categorie = db.GetAllModeles();
            return View(Categorie);
        }



        // GET: Categorie/Details/5
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

            // GET: Categorie/Create
            public ActionResult CreateCategorie()
            {
                return View();
            }

            // POST: Categorie/Create
            [HttpPost]
            public ActionResult CreateCategorie(Categorie Catm, FormCollection collection)
            {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Categorie.Add(Catm);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetCategorie");
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

        // POST: Categorie/Create
        [HttpPost]
        public ActionResult CreateCategorie_Designation(CategorieDesignation Catm, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.CategorieDesignation.Add(Catm);
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
            ViewData["cat"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "Id_categorie", "libelle");
            ViewData["des"] = new SelectList(BissInventaireEntities.Instance.CategorieDesignation.ToList(), "id_categorie_Designation", "libelle");

            return View();
        }

        // POST: Categorie/Create
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

        public ActionResult EditCategorie(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var cat = db.GetCategorie(id);
            return View(cat);
        }

        // POST: Categorie/Create
        [HttpPost]
        public ActionResult EditCategorie(Categorie Catm)
        {
            if (ModelState.IsValid)
            {
                try
            {
                db.UpdateCategorieDetached(Catm);
               db.SaveCategorie();
                return RedirectToAction("GetCategorie");
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

        // POST: Categorie/Create
        [HttpPost]
        public ActionResult EditCategorie_Designation(CategorieDesignation Catm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UpdateCategorie_DesignationDetached(Catm);
                    db.SaveCategorie();
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
            ViewData["des"] = new SelectList(BissInventaireEntities.Instance.CategorieDesignation.ToList(), "id_categorie_Designation", "libelle");

            var cat = db.FindCategorie_ModeleById(id);
            return View(cat);
        }

        // POST: Categorie/Create
        [HttpPost]
        public ActionResult EditCategorie_Modele(Sous_categorie Catm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UpdateCategorie_ModeleDetached(Catm);
                    db.SaveCategorie();
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

        // GET: Categorie/Edit/5
        public ActionResult Edit(int Id_categorie)
            {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
            }

            // POST: Categorie/Edit/5
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

        // GET: Categorie/Delete/5
        public ActionResult Delete(int Id_categorie)
            {   
                return View();
            }

            // POST: Categorie/Delete/5
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
           
            List<Sous_categorie> objcity = new List<Sous_categorie>();

            objcity = db.FindModeleByIdDes(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "id_categorie_Designation", "libelle", 0);
            return Json(obgcity);
        }
    }
    }
