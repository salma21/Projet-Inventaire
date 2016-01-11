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
            return View();
        }

        public ActionResult GetPersonnel()
        {
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
            ViewData["role"] = new SelectList(BissInventaireEntities.Instance.Role.ToList(), "id", "libelle");

            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");

            return View();
        }

        // POST: Personnel/Create
        [HttpPost]
        public ActionResult CreatePersonnel(Personnel pers, FormCollection collection)
        {
            int idregion = db.FindRegionByBatiment(pers.idBatiment);
            int idgou = db.FindGouverneratByBatiment(pers.idBatiment);
            int idpays = db.FindPaysByBatiment(pers.idBatiment);
            int iddelegation = db.FindDelegationByBatiment(pers.idBatiment);
            int idorg = db.FindOrganisationByDelegation(pers.idBatiment);
            pers.idDelegation = iddelegation;
            pers.idRegion = idregion;
            pers.idOrganisation = idorg;
            pers.idPays = idpays;
            pers.idGouvernorat = idgou;
            try
            {
                BissInventaireEntities.Instance.Personnel.Add(pers);
                BissInventaireEntities.Instance.SaveChanges();
                return RedirectToAction("GetPersonnel");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Personnel/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["role"] = new SelectList(BissInventaireEntities.Instance.Role.ToList(), "id", "libelle");

            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            var pers =db.FindPersByID(id);
            return View(pers);
        }

        // POST: Personnel/Edit/5
        [HttpPost]
        public ActionResult Edit(Personnel pers, FormCollection collection)
        {
            int idregion = db.FindRegionByBatiment(pers.idBatiment);
            int idgou = db.FindGouverneratByBatiment(pers.idBatiment);
            int idpays = db.FindPaysByBatiment(pers.idBatiment);
            int iddelegation = db.FindDelegationByBatiment(pers.idBatiment);
            int idorg = db.FindOrganisationByDelegation(pers.idBatiment);
            pers.idDelegation = iddelegation;
            pers.idRegion = idregion;
            pers.idOrganisation = idorg;
            pers.idPays = idpays;
            pers.idGouvernorat = idgou;
           
               db.UpdatePersonnelDetached(pers);
                db.SavePersonnel();

            TempData["msg"] = "Modification Avec Succe !!!";
            return RedirectToAction("GetPersonnel");
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
