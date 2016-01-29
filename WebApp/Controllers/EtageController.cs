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
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        public ActionResult GetEtage()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Etage = db.GetEtages();
            return View(Etage);
        }
        // GET: Etage/Details/5
        public ActionResult Details(int Etage)
        {
             if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
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
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");

            return View();
        }

        // POST: Etage/Create
        [HttpPost]
        public ActionResult CreateEtage(Etage etag, FormCollection collection)
        {
           
            int iddelegation = db.FindDelegationByBatiment(etag.idBatiment);
          
            IEtageService et = new EtageService();

            if (ModelState.IsValid)
            {

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
            else

            {
                ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");

                return View();
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

        // GET: Etage/Delete/5
        public ActionResult Delete(int Id_etage)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
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
