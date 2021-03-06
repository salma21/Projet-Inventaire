﻿using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class InventaireVehiculeController : Controller
    {
        IInventaireVehiculeService db = new InventaireVehiculeService();

        // GET: InventaireBien
        public ActionResult GetInventaireVehicule()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var inv = db.GetInventaireVehicule();
            return View(inv);
        }
        // GET: InventaireVehicule
        public ActionResult Index()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }
    }
}