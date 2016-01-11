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
        public class ServiceDController : Controller
        {
            private IServiceDService db = new ServiceDService();
            // GET: ServiceD
            public ActionResult Index()
            {
                return View();
            }

            public ActionResult GetServiceD()
            {
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
            ViewData["Direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
            return View();
            }

            // POST: ServiceD/Create
            [HttpPost]
            public ActionResult CreateServiceD(ServiceD Catm, FormCollection collection)
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
        public ActionResult EditServiceD(int id)
        {
            var service = db.FindServByID(id);
            ViewData["Direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
            return View(service);
        }

        // POST: ServiceD/Create
        [HttpPost]
        public ActionResult EditServiceD(ServiceD Catm, FormCollection collection)
        {
            try
            {
                db.UpdateServiceDDetached(Catm);
               db.SaveServiceD();
                return RedirectToAction("GetServiceD");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
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
