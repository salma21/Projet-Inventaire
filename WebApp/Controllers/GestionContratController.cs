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
    public class GestionContratController : Controller
    {

        BissInventaireEntities db = new BissInventaireEntities();

        IGestionContratService db1 = new GestionContratService();
        IFournisseurService fourni = new FournisseurService();
        private IGestionContratService del = new GestionContratService();
        public bool etat = true;


        // GET: GestionContratetSoc
      

       

        public ActionResult GetContrat()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var test = db.Contrat.ToList();
            return View(test);
        }

        public ActionResult DetailsContrat(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }

            var acht = BissInventaireEntities.Instance.Contrat.Find(id);
            return View(acht);

        }
        // GET: GestionContratetSoc/Create
        public ActionResult CreateContrat()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
            return View();
        }

        // POST: GestionContrat/Create
        [HttpPost]
        public ActionResult CreateContrat(Contrat contrat, FormCollection collection)
        {
            if (ModelState.IsValid)
            {

                var soc = db1.FindFournisseurByID(contrat.Id_fournisseur);
                contrat.idDelegation = soc.idDelegation;

                db.Contrat.Add(contrat);
                db.SaveChanges();

                return RedirectToAction("GetContrat");
          
        }
            else

            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                var errors1 = ModelState.Values.SelectMany(v => v.Errors);
                var errors2 = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                //ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
                //ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
                //ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                //ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");

                return View();
            }
        }

        [HttpPost]
        public ActionResult OpenPopupContrat(int delegid)
        {
            String Mess = "";

            var objcity = BissInventaireEntities.Instance.Contrat.FirstOrDefault(u => u.Num == delegid);
            if (objcity != null)
            {
                Mess = "Ce numéro de référence existe déja!!";
            }

            //iuoiy
            return Json(Mess);
        }
        public ActionResult EditContrat(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
            var cont = BissInventaireEntities.Instance.Contrat.Find(id);
            return View(cont);

        }

        // POST: GestionContratetSoc/Edit/5
        [HttpPost]
        public ActionResult EditContrat(Contrat cont, FormCollection collection)
        {

            if (ModelState.IsValid)
            {

                //DateTime jj = Convert.ToDateTime(cont.Date_debut);
                //DateTime df = Convert.ToDateTime(cont.Date_fin);
                //String hh = jj.ToString("dd-MM-yyyy");
                //String kk = df.ToString("dd-MM-yyyy");
                var soc = db1.FindFournisseurByID(cont.Id_fournisseur);
                cont.idDelegation = soc.idDelegation;
              
                    //  achat.Date_d_achat = System.DateTime.Now;
                 

                    db1.UpdateContratDetached(cont);
                    db1.SaveChange();
                    return RedirectToAction("GetContrat");
                
               
            }
            else

            {
                ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                var errors1 = ModelState.Values.SelectMany(v => v.Errors);
                var errors2 = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                return View();
            }

        }


        public ActionResult CreateAchat()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
           
            ViewData["contratgar"] = new SelectList(BissInventaireEntities.Instance.Contrat.ToList(), "Id_contrat", "Num");
            ViewData["achats"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_facture");
            return View();
        }

        // POST: GestionContratetSoc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAchat(Achat achat, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
            {
                var four = fourni.FindFourByID(achat.Id_fournisseur);
              //achat.Date_d_achat = System.DateTime.Now;
                achat.idDelegation = four.idDelegation;
                db.Achat.Add(achat);
                db.SaveChanges();


                return RedirectToAction("GetAchat");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }
            else

            {
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
                ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
                
                ViewData["contratgar"] = new SelectList(BissInventaireEntities.Instance.Contrat.ToList(), "Id_contrat_garanti", "Num");
                ViewData["achats"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_facture");
                return View();
            }

        }
        public ActionResult GetAchat()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var test = db.Achat.ToList();
            return View(test);
        }

        // GET: GestionContratetSoc/Details/5
        public ActionResult DetailsAchat(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            try
            {
                var acht = BissInventaireEntities.Instance.Achat.Find(id);
                return View(acht);
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }
        // GET: GestionContratetSoc/Edit/5
        public ActionResult EditAchat(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
          
            ViewData["contratgar"] = new SelectList(BissInventaireEntities.Instance.Contrat.ToList(), "Id_contrat", "Num");
            ViewData["achats"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_facture");
            
            var acht = BissInventaireEntities.Instance.Achat.Find(id);
            return View(acht);

        }

        // POST: GestionContratetSoc/Edit/5
        [HttpPost]
        public ActionResult EditAchat(Achat achte, FormCollection collection)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                   DateTime jj = Convert.ToDateTime(achte.Date_d_achat);
                    String hh = jj.ToString("dd-MM-yyyy");
                    var four = fourni.FindFourByID(achte.Id_fournisseur);
                    //  achat.Date_d_achat = System.DateTime.Now;
                    achte.idDelegation = four.idDelegation;

                    db1.UpdateAchatDetached(achte);
                db1.SaveChange();
                return RedirectToAction("GetAchat");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }
            else

            {
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
                ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");

                ViewData["contratgar"] = new SelectList(BissInventaireEntities.Instance.Contrat.ToList(), "Id_contrat", "Num");
                ViewData["achats"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_facture");
                return View();
            }

        }
        public ActionResult GenerateCAContrat()
        {
            IGestionContratService kk55 = new GestionContratService();

            double maxj = kk55.FindMaxIDContrat();
            maxj = maxj + 1;
            double jj = 6500000000000;

            double kk = jj + maxj;


            return Json(kk);
        }
        public ActionResult GenerateCAchat()
        {
            IGestionContratService kk55 = new GestionContratService();

            double maxj = kk55.FindMaxIDContrat();
            maxj = maxj + 1;
            double jj = 5500000000000;

            double kk = jj + maxj;


            return Json(kk);
        }
    }
}
