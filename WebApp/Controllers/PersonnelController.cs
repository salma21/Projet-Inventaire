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
    public class PersonnelController : Controller
    {
        private BissInventaireEntities con = new BissInventaireEntities();
        private IPersonnelService db = new PersonnelService();
        // GET: Personnel
        public ActionResult Index()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        public ActionResult GetPersonnel()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Personnel = db.GetPersonnels();
            return View(Personnel);
        }
        // GET: Personnel/Details/5
        public ActionResult Details(int id)
        {
            try
            {

                var archive = BissInventaireEntities.Instance.Personnel.Find(id);

                return View(archive);
            }
            catch (Exception ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }

        // GET: Personnel/Create
        public ActionResult CreatePersonnel()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            //ViewData["role"] = new SelectList(BissInventaireEntities.Instance.Role.ToList(), "id", "libelle");

            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");

            return View();
        }

        // POST: Personnel/Create
        [HttpPost]
        public ActionResult CreatePersonnel(Personnel pers, FormCollection collection)
        {
            //int idregion = db.FindRegionByBatiment(pers.idBatiment);
            //int idgou = db.FindGouverneratByBatiment(pers.idBatiment);
            //int idpays = db.FindPaysByBatiment(pers.idBatiment);
            //int iddelegation = db.FindDelegationByBatiment(pers.idBatiment);
            //int idorg = db.FindOrganisationByDelegation(pers.idBatiment);
            //pers.idDelegation = iddelegation;
            //pers.idRegion = idregion;
            //pers.idOrganisation = idorg;
            //pers.idPays = idpays;
            //pers.idGouvernorat = idgou;

            if (ModelState.IsValid)
            {
                try
            {
                    BissInventaireEntities.Instance.Personnel.Add(pers);
                    BissInventaireEntities.Instance.SaveChanges();
                    var Emp = (Utilisateur)Session["identifiant"];
                    Trace tr = new Trace();
                    tr.Dates = DateTime.Now;
                    tr.Actions = "Ajout Personnel";
                    tr.Champs = (pers.Matricule).ToString();
                    tr.Tables = "Personnel";
                    tr.Users = (Emp.Personnel.Matricule).ToString();
                    BissInventaireEntities.Instance.Trace.Add(tr);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetPersonnel");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }
            else

            {
                ViewData["role"] = new SelectList(BissInventaireEntities.Instance.Role.ToList(), "id", "libelle");

                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
                return View();
            }
        }
        // GET: Personnel/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["role"] = new SelectList(BissInventaireEntities.Instance.Role.ToList(), "id", "libelle");

            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            var pers =db.FindPersByID(id);
            return View(pers);
        }

        // POST: Personnel/Edit/5
        [HttpPost]
        public ActionResult Edit(Personnel pers, FormCollection collection)
        {
            //int idregion = db.FindRegionByBatiment(pers.idBatiment);
            //int idgou = db.FindGouverneratByBatiment(pers.idBatiment);
            //int idpays = db.FindPaysByBatiment(pers.idBatiment);
            //int iddelegation = db.FindDelegationByBatiment(pers.idBatiment);
            //int idorg = db.FindOrganisationByDelegation(pers.idBatiment);
            //pers.idDelegation = iddelegation;
            //pers.idRegion = idregion;
            //pers.idOrganisation = idorg;
            //pers.idPays = idpays;
            //pers.idGouvernorat = idgou;

            if (ModelState.IsValid)
            {
                db.UpdatePersonnelDetached(pers);
                db.SavePersonnel();
                var Emp = (Utilisateur)Session["identifiant"];
                Trace tr = new Trace();
                tr.Dates = DateTime.Now;
                tr.Actions = "Modification Personnel";
                tr.Champs = (pers.Matricule).ToString();
                tr.Tables = "Personnel";
                tr.Users = (Emp.Personnel.Matricule).ToString();
                BissInventaireEntities.Instance.Trace.Add(tr);
                BissInventaireEntities.Instance.SaveChanges();
                TempData["msg"] = "Modification Avec Succe !!!";
            return RedirectToAction("GetPersonnel");
        }
            else

            {
                ViewData["role"] = new SelectList(BissInventaireEntities.Instance.Role.ToList(), "id", "libelle");

                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
                return View();
            }
        }
        // GET: Personnel/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View();
        }

        // POST: Personnel/Delete/5
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
