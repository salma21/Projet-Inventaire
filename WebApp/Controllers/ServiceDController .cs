﻿using Domain;
using Log;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApp.Controllers
{
    public class ServiceDController : Controller
    {
        private IServiceDService db = new ServiceDService();
        // GET: ServiceD
        public ActionResult Index()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        public ActionResult GetServiceD()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var ServiceD = db.GetServiceDs();
            return View(ServiceD);
        }
        // GET: ServiceD/Details/5
        public ActionResult Details(int Id_Service)
        {
            try
            {

                var archive = BissInventaireEntities.Instance.ServiceD.Find(Id_Service);

                return View(archive);
            }
            catch (Exception ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }

        // GET: ServiceD/Create
        public ActionResult CreateServiceD()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["Direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
            return View();
        }

        // POST: ServiceD/Create
        [HttpPost]
        public ActionResult CreateServiceD(ServiceD Catm, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.ServiceD.Add(Catm);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetServiceD");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                ViewData["Direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
                return View();
            }
        }
        //public ActionResult EditServiceD(int id)
        //{
        //    if (Session["identifiant"] == null)
        //    { return RedirectToAction("Index", "Home"); }
        //    var service = db.FindServByID(id);
        //    ViewData["Direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
        //    return View(service);
        //}

        //// POST: ServiceD/Create
        //[HttpPost]
        //public ActionResult EditServiceD(ServiceD Catm, FormCollection collection)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            db.UpdateServiceDDetached(Catm);
        //            BissInventaireEntities.Instance.SaveChanges();
        //            return RedirectToAction("GetServiceD");
        //        }
        //        catch (Exception ex)
        //        {
        //            LogThread.WriteLine(ex.Message);
        //            return RedirectToAction("Index", "Error");
        //        }
        //    }
        //    else

        //    {
        //        ViewData["Direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
        //        return View();
        //    }
        //}
        public ActionResult EditServiceD(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var reg = db.FindServByID(id);
      
            ViewData["Direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
            return View(reg);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditServiceD(ServiceD reg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UpdateServiceDDetached(reg);
                    db.SaveServiceD();
                    return RedirectToAction("GetServiceD");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                ViewData["Direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
                
                return View();
            }
        }





        // GET: ServiceD/Edit/5
        public ActionResult Edit(int Id_service)
        {
            return View();
        }

        // POST: ServiceD/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id_Service, FormCollection collection)
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

        // GET: ServiceD/Delete/5
        public ActionResult Delete(int Id_service)
        {
            return View();
        }

        // POST: ServiceD/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id_service, FormCollection collection)
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
