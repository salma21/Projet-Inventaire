using Domain;
using Log;
using Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApp.Controllers
    {
        public class CategorieController : Controller
        {
            private ICategorieService db = new CategorieService();
            // GET: Categorie_materiel
            public ActionResult index()
            {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
            }

            public ActionResult getCategorie()
            {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Categorie_materiel = db.GetCategorie_materiels();
            return View(Categorie_materiel);
        }


        public ActionResult getSousCategorie()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var CategorieMateriel = db.GetCategorie_Designations();
            return View(CategorieMateriel);
        }


        public ActionResult getModele()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var CategorieModel = db.GetAllModeles();
            return View(CategorieModel);
        }

        public ActionResult getSousModele()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var CategorieSousModel = db.GetAllSousModele();
            return View(CategorieSousModel);
        }

        public ActionResult getMarque()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var CategorieMarque = db.GetAllMarque();
            return View(CategorieMarque);
        }


        // GET: Categorie/Details/5
        public ActionResult details(int Id_categorie)
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
            public ActionResult createCategorie()
            {
               
                return View();
            }

            // POST: Categorie/Create
            [HttpPost]
            public ActionResult createCategorie(Categorie categorie, FormCollection collection)
            {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Categorie.Add(categorie);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("getCategorie");
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

        // POST: Categorie/Edit

        public ActionResult editCategorie(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var cat = db.GetCategorie_materiel(id);
            return View(cat);
        }

        // POST: Categorie/Edit
        [HttpPost]
        public ActionResult editCategorie(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UpdateCategorie_materielDetached(categorie);
                    db.SaveCategorie_materiel();
                    return RedirectToAction("getCategorie");
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









        public ActionResult createSousCategorie()
        {
            ViewData["categorie"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "Id_categorie", "libelle");

            return View();
        }

        // POST: SousCategorie/Create
        [HttpPost]
        public ActionResult createSousCategorie(Sous_categorie sousCategorie, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Sous_categorie.Add(sousCategorie);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("getSousCategorie");
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



       public void DeleteRelationship(int idCategorie, int idSousCategorie)
        {
            using (BissInventaireEntities conn = new BissInventaireEntities())
            {
                // return one instance each entity by primary key
              
                var soucat = conn.Sous_categorie.FirstOrDefault(s => s.id_sous_categorie == idSousCategorie);
                var cat = conn.Categorie.FirstOrDefault(p => p.Id_categorie == idCategorie);
                // call Remove method from navigation property for any instance
                // supplier.Product.Remove(product);
                // also works
                //product.Sous_categorie.Remove(supplier);
                cat.Sous_categorie.Remove(soucat);
                //soucat.Id_categorie.Remove(cat);
                // call SaveChanges from context
                conn.SaveChanges();
            }
        }

        public void InsertWithData(int categorieId)
        {
            using (BissInventaireEntities conn = new BissInventaireEntities())
            {

                /*
                    * this steps follow to both entities
                    * 
                    * 1 - create instance of entity with relative primary key
                    * 
                    * 2 - add instance to context
                    * 
                    * 3 - attach instance to context
                    */

                // 1
                Categorie p = new Categorie { Id_categorie = categorieId };
                // 2
                conn.Categorie.Add(p);
                // 3
                conn.Categorie.Attach(p);

                // 1
               
                // call SaveChanges
                conn.SaveChanges();
            }
        }

        //[HttpPost]
        //public ActionResult editSousCategorie(int oldSousCategorieId, int oldCategorie , int newCategorieId ,int newSousCategorieId)
        //{
        //    DeleteRelationship(oldSousCategorieId , oldCategorie);
        //    InsertWithData(newCategorieId;

        //    return View();
        //}

        // POST: SousCategorie/Edit

        public ActionResult editSousCategorie(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["categorie"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "Id_categorie", "libelle");

            var cat = db.FindCategorie_DesignationById(id);
            return View(cat);
        }

        //POST: SousCategorie/Edit
        [HttpPost]
        public ActionResult editSousCategorie(Sous_categorie sousCategorie)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    //DeleteRelationship(oldCategorie , oldSousCategorieId);
                    //InsertWithData(newCategorieId, newSousCategorieId);
                    db.UpdateCategorie_DesignationDetached(sousCategorie);
                    //UpdateModel(sousCategorie);
                    db.SaveSousCategorie();
                    return RedirectToAction("getSousCategorie");
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






        public ActionResult createModele()
        {
            ViewData["categorie"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "Id_categorie", "libelle");
           

            return View();
        }

        // POST: Modele/Create
        [HttpPost]
        public ActionResult createModele(Modele modele, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Modele.Add(modele);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("getModele");
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


        //GetSouscatégorieByCatégorie
        [HttpPost]
        public ActionResult getSousCategorieByCategorie(int stateid)
        {

            List<Sous_categorie> objcity = new List<Sous_categorie>();

            objcity = db.FindPorduitByID(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "id_sous_categorie", "libelle", 0);
            return Json(obgcity);
        }


       

        //Create SousModele

        public ActionResult createSousModele()
        {
            ViewData["categorie"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "Id_categorie", "libelle");
           
           

            return View();
        }

        // POST: SousModele/Create
        [HttpPost]
        public ActionResult createSousModele(Sous_modele sousModele, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Sous_modele.Add(sousModele);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("getSousModele");
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

        //getModeleBySousCategorie
        [HttpPost]
        public ActionResult getModeleBySousCategorie(int stateid)
        {

            List<Modele> objcity = new List<Modele>();

            objcity = db.FindModeleByIdDes(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "IdModele", "libelle", 0);
            return Json(obgcity);
        }


        //Create Marque

        public ActionResult createMarque()
        {
            ViewData["categorie"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "Id_categorie", "libelle");
           

            return View();
        }

        // POST: Marque/Create
        [HttpPost]
        public ActionResult createMarque(Marque marque, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Marque.Add(marque);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("getMarque");
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


        //getModeleBySousCategorie
        [HttpPost]
        public ActionResult getSousModeleByModele(int stateid)
        {

            List<Sous_modele> objcity = new List<Sous_modele>();

            objcity = db.FindSousModeleByIdModele(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "Id_sous_Modele", "Libelle", 0);
            return Json(obgcity);
        }



        [HttpPost]
        public ActionResult getMarqueBySousModele(int stateid)
        {

            List<Marque> objcity = new List<Marque>();

            objcity = db.FindMarqueByIdSousModele(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "IdMarque", "Libelle", 0);
            return Json(obgcity);
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




    }
    }
