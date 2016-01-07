using Domain;
using Log;
using Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        private IBureauService db = new BureauService();
        private IUtilisateurService db1 = new UtilisateurService();
        private IRegionService db2 = new RegionService();

        //private IEnumerable<Bureau> depts = InventaireBiss2015Entities.Instance.Bureau.ToList();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBureuax()
        {
            var bure = db.GetBureaux();
            return View(bure);
        }

        
        public ActionResult GetUsers()
        {
            
            var users = db1.GetUtilisateurs();
            return View(users);
        }

       

        public ActionResult Dashboard()
        {
            return View();
           
        }

        // GET: Admin/Details/5
        public ActionResult DetailsBien(int id)
        {
            try
            {

                var archive = BissInventaireEntities.Instance.Bien.Find(id);

                return View(archive);
            }
            catch (Exception ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }


        }

        // GET: Admin/Create
        public ActionResult CreateBureaux()
        {
            ViewData["batiments"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            ViewData["etages"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "Description");
            ViewData["direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");

            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateBureaux(Bureau Bur, FormCollection collection)
        {
            try
            {
                db.CreateBureau(Bur);
                db.SaveBureau();

                return RedirectToAction("GetBureuax");
            }
            catch(Exception ex  )
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }


        public ActionResult EditUser(int id)
        {
            IUtilisateurService kk = new UtilisateurService();
            var ise = kk.GetUtilisateurById(id);
            ViewData["personel"] = new SelectList(BissInventaireEntities.Instance.Personnel.ToList(), "id", "Matricule");
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");


            return View(ise);
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult EditUser(Utilisateur user, FormCollection collection)
        {
            IUtilisateurService kk = new UtilisateurService();
            try
            {
               kk.UpdateUtilisateurDetached(user);
                kk.SaveEmploye();

                return RedirectToAction("GetUsers");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }
        public ActionResult CreateBien()
        {
            ViewData["achats"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_facture");
            ViewData["societeass"] = new SelectList(BissInventaireEntities.Instance.Societe_assurance.ToList(), "Id_societe_assurance", "libelle");
            ViewData["societemain"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_societe_maintenance", "Libelle");
            ViewData["contratass"] = new SelectList(BissInventaireEntities.Instance.Contrat_assurance.ToList(), "Id_contrat_assurance", "Num");
            ViewData["contratmain"] = new SelectList(BissInventaireEntities.Instance.Contrat_maintenance.ToList(), "Id_contrat_maintenance", "Num");
            ViewData["categorie"] = new SelectList(BissInventaireEntities.Instance.Categorie_materiel.ToList(), "Id_categorie", "libelle");
            ViewData["Depot"] = new SelectList(BissInventaireEntities.Instance.Depot.ToList(), "IdDepot", "libelle");



            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateBien(Bien Bur, FormCollection collection)
        {
            //int region = db2.FindRegionByDelegation(Bur.idDelegation);
            //int gouv = db2.FindGouvByDelegation(Bur.idDelegation);
            //int pays = db2.FindPaysByDelegation(Bur.idDelegation);
            //int organisation = db2.FindOrganisationByDelegation(Bur.idBatiment);
            int direct = db2.FindDirectionByDelegation((int)Bur.id_bureau);

            //Bur.idRegion = region;
            //Bur.idGouvernorat = gouv;
            //Bur.idPays = pays;
            //Bur.idOrganisation = organisation;
            Bur.id_direction = direct;

            BissInventaireEntities.Instance.Bien.Add(Bur);
                BissInventaireEntities.Instance.SaveChanges();

                return RedirectToAction("RapportBien");
        
        }

        public ActionResult CreateBienAdmin()
        {
            ViewData["depts"] = new SelectList(db.GetBureaux(), "Id", "Description");
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateBienAdmin(Bien Bur, FormCollection collection)
        {
            try
            {
                BissInventaireEntities.Instance.Bien.Add(Bur);
                BissInventaireEntities.Instance.SaveChanges();

                return RedirectToAction("RapportBien");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult RapportBien( string Etage, string Batiment)
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


            if (string.IsNullOrEmpty(Etage) && string.IsNullOrEmpty(Batiment))
            {
                return View(bien.ToList());

            }
            else
            {
               
                var dep = from s in bien select s;
                if ( String.IsNullOrEmpty(Etage) || (String.IsNullOrEmpty(Batiment)))
                {
                    dep = dep.Where(s =>  (string.IsNullOrEmpty(Etage) || (s.Etage.description.ToString().StartsWith(Etage)))
                    && (string.IsNullOrEmpty(Batiment) || (s.Etage.Batiment.description.ToString().StartsWith(Batiment)))
                  
                    );

                }
                else
                {
                    dep = dep.Where(s => (s.Etage.description.ToString().StartsWith(Etage))
                    && (s.Etage.Batiment.description.ToString().StartsWith(Batiment))
                  
                        );

                }

                int nbr2 = dep.ToList().Count();
                ViewBag.nbr = nbr2;
                return View(dep.ToList())
                    ;
            }
        }
        public ActionResult EditBureaux(int id)
        {
            var pers = db.FindBureauByID(id);
            ViewData["batiments"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            ViewData["etages"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "Description");
            ViewData["direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");

            return View(pers);

        }

        // POST: Bureau/Edit/5
        [HttpPost]
        public ActionResult EditBureaux(Bureau pers, FormCollection collection)
        {

                db.UpdateBureauDetached(pers);
                db.SaveBureau();

                return RedirectToAction("GetBureaux");
          
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult ActDesactiveUsers(int id)
        {

            var test = db1.GetUtilisateurById(id);
            try
            {
              
                if (test.etatUtilisateur == true)
                {
                    test.etatUtilisateur = false;
                    db1.UpdateUtilisateurDetached(test);
                    db1.SaveEmploye();
                }
                else
                {
                    test.etatUtilisateur = true;
                    db1.UpdateUtilisateurDetached(test);
                    db1.SaveEmploye();
                }
               

                return RedirectToAction("GetUsers");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult CreateUsers()
        {
            ViewData["personel"] = new SelectList(BissInventaireEntities.Instance.Personnel.ToList(), "id", "Matricule");
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateUsers(Utilisateur user, FormCollection collection)
        {
            try
            {
                db1.CreateUtilisateurs(user);
                db1.SaveEmploye();

                return RedirectToAction("GetUsers");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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


        //
        // POST: /Admin/Create
        [HttpPost]
        public ActionResult GetEtageByBatiment(int stateid)
        {
          
            List<Bureau> objcity = new List<Bureau>();

            objcity = db.FindBureauByBatiment(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "Id_bureau", "Description", 0);
            return Json(obgcity);
        }





    }
}
