using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ServiceDirectionController : Controller
    {
        // GET: ServiceDirection
        public ActionResult Index()
        {
            return View();
        }

        // GET: ServiceDirection/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceDirection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceDirection/Create
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

        // GET: ServiceDirection/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceDirection/Edit/5
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

        // GET: ServiceDirection/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceDirection/Delete/5
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
