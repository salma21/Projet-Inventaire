using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ParametreController : Controller
    {
        // GET: Parametre
        public ActionResult Index()
        {
            return View();
        }

        // GET: Parametre/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parametre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parametre/Create
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

        // GET: Parametre/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Parametre/Edit/5
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

        // GET: Parametre/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parametre/Delete/5
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
