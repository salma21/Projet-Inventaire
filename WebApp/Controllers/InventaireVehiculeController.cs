using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class InventaireVehiculeController : Controller
    {
        IInventaireVehService db = new InventaireVehService();

        // GET: InventaireBien
        public ActionResult GetInventaireVehicule()
        {
            var inv = db.GetInventaireVeh();
            return View(inv);
        }
        // GET: InventaireVehicule
        public ActionResult Index()
        {
            return View();
        }
    }
}