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
        public ActionResult GetInventaireBien()
        {
            var inv = db.GetInventaireBiens();
            return View(inv);
        }

        [HttpPost]
        public ActionResult GetBatimentByDelegation(int delegid)
        {
            List<Batiment> objcity = new List<Batiment>();
            objcity = db.FindBatimentByDelegation(delegid).ToList();

            SelectList obgcity = new SelectList(objcity, "idBatiment", "description", 0);
            return Json(obgcity);
        }

        [HttpPost]
        public ActionResult GetEtageByBatiment(int batid)
        {
            List<Etage> objcity = new List<Etage>();
            objcity = db.FindEtageByBatiment(batid).ToList();

            SelectList obgcity = new SelectList(objcity, "idBatiment", "description", 0);
            return Json(obgcity);
        }
        [HttpPost]
        public ActionResult GetBienByEtage(int etid)
        {
            List<Bien> objcity = new List<Bien>();
            objcity = db.FindBienByEtage(etid).ToList();

            SelectList obgcity = new SelectList(objcity, "idBatiment", "description", 0);
            return Json(obgcity);
        }

        public ActionResult CreateInventaireBien()
        {


            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            ViewData["etage"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "description");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["bien"] = new SelectList(BissInventaireEntities.Instance.Bien.ToList(), "Id_bien", "Num_serie");

            return View();
        }

        // POST: Mouvement/Create
        [HttpPost]
        public ActionResult CreateInventaireBien(Association_30 InvB, FormCollection collection)
        {

            try
            {
                db.CreateInventaireBien(InvB);
                db.SaveInventaireBien();
               
                return RedirectToAction("GetMouvement");
            }
            catch (DbEntityValidationException r)
            {


                foreach (var eve in r.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    LogThread.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors: " +
                        eve.Entry.Entity.GetType().Name + " " + eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        LogThread.WriteLine("- Property: \"{0}\", Error: \"{1}\" " +
                            ve.PropertyName + " " + ve.ErrorMessage);
                        ViewBag.msg2 = "Exeption:  " + ve.ErrorMessage;


                    }
                }

                return RedirectToAction("Index", "Error");
            }
            catch (SqlException sq)
            {
                LogThread.WriteLine(sq.Message);
                return RedirectToAction("Index", "Error");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Index()
        {
            return View();
        }


    }
}