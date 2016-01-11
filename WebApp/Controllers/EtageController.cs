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
    public class EtageController : Controller
    {
        private BissInventaireEntities con = new BissInventaireEntities();
        private IEtageService db = new EtageService();
        // GET: Etage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEtage()
        {
            var Etage = db.GetEtages();
            return View(Etage);
        }
        // GET: Etage/Details/5
        public ActionResult Details(int Etage)
        {
            try
            {

                var archive = BissInventaireEntities.Instance.Etage.Find(Etage);

                return View(archive);
            }
            catch (Exception ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }

        // GET: Etage/Create
        public ActionResult CreateEtage()
        {
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");

            return View();
        }

        // POST: Etage/Create
        [HttpPost]
        public ActionResult CreateEtage(Etage etag, FormCollection collection)
        {
           // int idregion = db.FindRegionByBatiment(etag.idBatiment);
           // int idgou = db.FindGouverneratByBatiment(etag.idBatiment);
          //  int idpays = db.FindPaysByBatiment(etag.idBatiment);
            int iddelegation = db.FindDelegationByBatiment(etag.idBatiment);
           // int idorg = db.FindOrganisationByDelegation(etag.idBatiment);
            etag.idDelegation = iddelegation;
            IEtageService et = new EtageService();
            try
            {
                et.CreateEtage(etag);
                et.SaveEtage();
                return RedirectToAction("GetEtage");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Etage/Edit/5
        public ActionResult Edit(int Id_etage)
        {
            return View();
        }

        // POST: Etage/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id_etage, FormCollection collection)
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

        // GET: Etage/Delete/5
        public ActionResult Delete(int Id_etage)
        {
            return View();
        }

        // POST: Etage/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id_etage, FormCollection collection)
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
