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
    public class PersonnelController : Controller
    {
        private BissInventaireEntities con = new BissInventaireEntities();
        private IPersonnelService db = new PersonnelService();
        public bool etat = true;
        // GET: Personnel
        public ActionResult Index()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        public ActionResult GetPersonnel()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Personnel = db.GetPersonnels();
            return View(Personnel);
        }
        // GET: Personnel/Details/5
        public ActionResult Details(int id)
        {
            try
            {

                var archive = BissInventaireEntities.Instance.Personnel.Find(id);

                return View(archive);
            }
            catch (Exception ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }

        // GET: Personnel/Create
        public ActionResult CreatePersonnel()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["role"] = new SelectList(BissInventaireEntities.Instance.Role.ToList(), "id", "libelle");

            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            ViewData["direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
            ViewData["service"] = new SelectList(BissInventaireEntities.Instance.ServiceD.ToList(), "Id_service", "Libelle");
            ViewData["etage"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "description");
            ViewData["bureau"] = new SelectList(BissInventaireEntities.Instance.Bureau.ToList(), "Id_bureau", "Description");
            return View();
        }

        // POST: Personnel/Create
        [HttpPost]
        public ActionResult CreatePersonnel(Personnel pers, FormCollection collection)
        {
            //int idregion = db.FindRegionByBatiment(pers.idBatiment);
            //int idgou = db.FindGouverneratByBatiment(pers.idBatiment);
            //int idpays = db.FindPaysByBatiment(pers.idBatiment);
            //int iddelegation = db.FindDelegationByBatiment(pers.idBatiment);
            //int idorg = db.FindOrganisationByDelegation(pers.idBatiment);
            //pers.idDelegation = iddelegation;
            //pers.idRegion = idregion;
            //pers.idOrganisation = idorg;
            //pers.idPays = idpays;
            //pers.idGouvernorat = idgou;

            if (ModelState.IsValid)
            {
                try
                {
                    if (etat)
                    {
                        BissInventaireEntities.Instance.Personnel.Add(pers);
                        BissInventaireEntities.Instance.SaveChanges();
                        var Emp = (Utilisateur)Session["identifiant"];
                        Trace tr = new Trace();
                        tr.Dates = DateTime.Now;
                        tr.Actions = "Ajout Personnel";
                        tr.Champs = (pers.Matricule).ToString();
                        tr.Tables = "Personnel";
                        tr.Users = (Emp.Personnel.Matricule).ToString();
                        BissInventaireEntities.Instance.Trace.Add(tr);
                        BissInventaireEntities.Instance.SaveChanges();
                        return RedirectToAction("GetPersonnel");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Error");
                    }
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                ViewData["role"] = new SelectList(BissInventaireEntities.Instance.Role.ToList(), "id", "libelle");

                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
                ViewData["direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
                ViewData["service"] = new SelectList(BissInventaireEntities.Instance.ServiceD.ToList(), "Id_service", "Libelle");
                ViewData["etage"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "description");
                ViewData["bureau"] = new SelectList(BissInventaireEntities.Instance.Bureau.ToList(), "Id_bureau", "Description");
                return View();
            }
        }




        [HttpPost]
        public ActionResult OpenPopupPersonnel(int delegid)
        {
            String Mess = "";

            var objcity = BissInventaireEntities.Instance.Personnel.FirstOrDefault(u => u.Matricule == delegid);
            if (objcity != null)
            {
                Mess = "Cette matricule existe déja!!";
            }

            //iuoiy
            return Json(Mess);
        }
        [HttpPost]
        public ActionResult getSeviceByDirection(int stateId)
        {

            List<ServiceD> objcity = new List<ServiceD>();

            objcity = db.findServiceByDirection(stateId).ToList();

            SelectList obgcity = new SelectList(objcity, "Id_service", "Libelle", 0);
            return Json(obgcity);
        }

        [HttpPost]
        public ActionResult getPersByService(int stateId)
        {

            List<Personnel> objcity = new List<Personnel>();

            objcity = db.findPersByService(stateId).ToList();

            SelectList obgcity = new SelectList(objcity, "id_pers", "Matricule", 0);
            return Json(obgcity);
        }

        // GET: Personnel/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["role"] = new SelectList(BissInventaireEntities.Instance.Role.ToList(), "id", "libelle");
            
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            ViewData["direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
            ViewData["service"] = new SelectList(BissInventaireEntities.Instance.ServiceD.ToList(), "Id_service", "Libelle");
            ViewData["etage"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "description");
            ViewData["bureau"] = new SelectList(BissInventaireEntities.Instance.Bureau.ToList(), "Id_bureau", "Description");
            var pers =db.FindPersByID(id);
            return View(pers);
        }

        // POST: Personnel/Edit/5
        [HttpPost]
        public ActionResult Edit(Personnel pers, FormCollection collection)
        {
            //int idregion = db.FindRegionByBatiment(pers.idBatiment);
            //int idgou = db.FindGouverneratByBatiment(pers.idBatiment);
            //int idpays = db.FindPaysByBatiment(pers.idBatiment);
            //int iddelegation = db.FindDelegationByBatiment(pers.idBatiment);
            //int idorg = db.FindOrganisationByDelegation(pers.idBatiment);
            //pers.idDelegation = iddelegation;
            //pers.idRegion = idregion;
            //pers.idOrganisation = idorg;
            //pers.idPays = idpays;
            //pers.idGouvernorat = idgou;

            if (ModelState.IsValid)
            {
               
                db.UpdatePersonnelDetached(pers);
                db.SavePersonnel();
                var Emp = (Utilisateur)Session["identifiant"];
                Trace tr = new Trace();
                tr.Dates = DateTime.Now;
                tr.Actions = "Modification Personnel";
                tr.Champs = (pers.Matricule).ToString();
                tr.Tables = "Personnel";
                tr.Users = (Emp.Personnel.Matricule).ToString();
                BissInventaireEntities.Instance.Trace.Add(tr);
                BissInventaireEntities.Instance.SaveChanges();
                TempData["msg"] = "Modification Avec Succe !!!";
            return RedirectToAction("GetPersonnel");
        }
            else

            {
                ViewData["role"] = new SelectList(BissInventaireEntities.Instance.Role.ToList(), "id", "libelle");

                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
                ViewData["direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
                ViewData["service"] = new SelectList(BissInventaireEntities.Instance.ServiceD.ToList(), "Id_service", "Libelle");
                ViewData["etage"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "description");
                ViewData["bureau"] = new SelectList(BissInventaireEntities.Instance.Bureau.ToList(), "Id_bureau", "Description");
                return View();
            }
        }
        // GET: Personnel/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View();
        }

        // POST: Personnel/Delete/5
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
