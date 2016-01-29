using Domain;
using Log;
using Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class InventaireController : Controller
    {
        public static int idinv;
        public static int idin;
        
        IInventaireBienService db1 = new InventaireBienService();
        IInventaireService db = new InventaireService();
        IInventaireVehService db2 = new InventaireVehService();
        // GET: Inventaire
        public ActionResult GetInventaire()
        {

            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Emp = (Utilisateur)Session["identifiant"];
            var inv = db.GetInventaires();

           
            var ass = db1.GetInventaireBiens();
            var ass2 = db2.GetInventaireVeh();
            ViewBag.nbrvehicule = ass2.Count();
            ViewBag.nbrbien = ass.Count();


            return View(inv);
        }
     

        public ActionResult GetBiens()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var inv = db.GetInventaires();
            return View(inv);
        }
        public ActionResult AddBien(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var bureaux = BissInventaireEntities.Instance.Bureau.ToList();
            var etage = BissInventaireEntities.Instance.Etage.ToList();
            var batiment = BissInventaireEntities.Instance.Batiment.ToList();



            ViewData["etage"] = new SelectList(etage, "Description", "Description   ");
            ViewData["batiment"] = new SelectList(batiment, "Description", "Description");
            ViewData["Idinv"] = id;
            idinv = Convert.ToInt32(ViewData["Idinv"]);
           

            var inv = BissInventaireEntities.Instance.Bien.ToList();
            return View("GetBiens", inv);
        }


        public ActionResult AddVeh(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }

            ViewData["Idin"] = id;
            idin = Convert.ToInt32(ViewData["Idin"]);

            var ass = db2.GetInventaireVeh();
            var inv = BissInventaireEntities.Instance.Vehicule.ToList();

            foreach (var hh in inv)
            {
                 List< Vehicule > ff = new List<Vehicule>();
                //if (hh.Id_Vehicule) 

            }
            return View("GetVehicules", inv);
        }




        public ActionResult RapportBien( string Etage, string Batiment)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
           
            var etage = BissInventaireEntities.Instance.Etage.ToList();
            var batiment = BissInventaireEntities.Instance.Batiment.ToList();



            ViewData["etage"] = new SelectList(etage, "Description", "Description   ");
            ViewData["batiment"] = new SelectList(batiment, "Description", "Description");
           
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
                if (String.IsNullOrEmpty(Etage) || (String.IsNullOrEmpty(Batiment)))
                {
                    dep = dep.Where(s =>  (string.IsNullOrEmpty(Etage) || (s.Etage.description.ToString().StartsWith(Etage)))
                    && (string.IsNullOrEmpty(Batiment) || (s.Etage.Batiment.description.ToString().StartsWith(Batiment)))

                    );

                }
                else
                {
                    dep = dep.Where(s => ( s.Etage.description.ToString().StartsWith(Etage))
                    && (s.Etage.Batiment.description.ToString().StartsWith(Batiment))

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
            
            Association_30 ass = new Association_30();
            ass.Id_bien = id;
           
            return View();
        }
        public ActionResult ValiderBien(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            IUtilisateurService kk = new UtilisateurService();

            Association_30 nm = new Association_30();
           nm.Id_bien = id;
            nm.Id_inventaire = InventaireController.idinv;

            try
            {
                db1.CreateInventaireBien(nm);
                db1.SaveInventaireBien();

                return RedirectToAction("GetInventaire");
            }
            catch (DbEntityValidationException ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }
        [HttpPost]
        public ActionResult AjouterVehicule(int id)
        {
          
            Association_31 asss = new Association_31();
            asss.Id_Vehicule = id;

            return View();
        }
        public ActionResult ValiderVeh(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var veh = db2.GetVehByID(id);
            var Emp = (Utilisateur)Session["identifiant"];
            Trace tr = new Trace();
            tr.Dates = DateTime.Now;
            tr.Actions = "Validation Vehicule";
            tr.Champs = veh.Matricule;
            tr.Tables = "Vehicule";
            tr.Users = (Emp.Personnel.Matricule).ToString();
            BissInventaireEntities.Instance.Trace.Add(tr);
            BissInventaireEntities.Instance.SaveChanges();





            IInventaireVehService kk = new InventaireVehService();

            Association_31 nmm = new Association_31();
            nmm.Id_Vehicule = id;
            nmm.Id_inventaire = InventaireController.idin;

            try
            {
                db2.CreateInventaireVeh(nmm);
                db2.SaveInventaireVeh();

                return RedirectToAction("GetInventaire");
            }
            catch (DbEntityValidationException ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }



        public ActionResult CreateInventaire()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateInventaire(Inventaire reg)
        {
            if (ModelState.IsValid)
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
            else

            {
                
                return View();
            }
        }


        public ActionResult EditInventaire(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }

            var inv = db.GetInvById(id);
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditInventaire(Inventaire reg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    db.UpdateInventaireDetached(reg);
                    db.SaveInventaire();

                    return RedirectToAction("GetInventaire");
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

        // GET: Inventaire/Details/5
        public ActionResult Details(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        // GET: Inventaire/Create
        public ActionResult Create()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
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
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
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
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
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
