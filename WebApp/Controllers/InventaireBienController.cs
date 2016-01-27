using Domain;
using Log;
using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class InventaireBienController : Controller
    {
        IInventaireBienService db = new InventaireBienService();
       
        // GET: InventaireBien
        public ActionResult GetInventaireBiens()
        {
            var inv = db.GetInventaireBiens();
            return View(inv);
        }


        public ActionResult GetDetailsInvBienBiens()
        {
          
            var inv = db.GetInventaireBiens();

            return View(inv);
        }

        public ActionResult GetBiens()
        {

            var bien = BissInventaireEntities.Instance.Bien.ToList();



            return View(bien.ToList())
                ;
        }

    
      

        // POST: Mouvement/Create
    
       
        public ActionResult Index()
        {
            return View();
        }


    }
}