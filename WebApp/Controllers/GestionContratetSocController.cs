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
    public class GestionContratetSocController : Controller
    {

        BissInventaireEntities db = new BissInventaireEntities();

        IGestionContratetSocService db1 = new GestionContratetSocService();
        IFournisseurService fourni = new FournisseurService();
        private IGestionContratetSocService del = new GestionContratetSocService();
        // GET: GestionContratetSoc
        public ActionResult GetContrat_Assurance()
        {
            var test = db.Contrat_assurance.ToList();
            return View(test);
        }

        public ActionResult GetContrat_Garantie()
        {
            var test = db.Contrat_garanti.ToList();
            return View(test);
        }

        public ActionResult GetContrat_Maintenance()
        {
            var test = db.Contrat_maintenance.ToList();
            return View(test);
        }

        public ActionResult GetSociete_Assurance()
        {
            var test = db.Societe_assurance.ToList();
            return View(test);
        }

        public ActionResult GetSociete_Maintenance()
        {
            var test = db.Societe_maintenance.ToList();
            return View(test);
        }

        public ActionResult GetAchat()
        {
            var test = db.Achat.ToList();
            return View(test);
        }

        // GET: GestionContratetSoc/Details/5
        public ActionResult DetailsAchat(int id)
        {
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

        // GET: GestionContratetSoc/Create
        public ActionResult CreateContrat_Assurance()
        {
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
            ViewData["societeass"] = new SelectList(BissInventaireEntities.Instance.Societe_assurance.ToList(), "Id_societe_assurance", "libelle");
            ViewData["societemain"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_societe_maintenance", "libelle");
            return View();
        }

        // POST: GestionContratetSoc/Create
        [HttpPost]
        public ActionResult CreateContrat_Assurance(Contrat_assurance contrat, FormCollection collection)
        {
            try
            {
                var soc = db1.FindSocAssByID(contrat.Id_societe_assurance);
                contrat.idDelegation = soc.idDelegation;
                db.Contrat_assurance.Add(contrat);
                db.SaveChanges();

                return RedirectToAction("GetContrat_Assurance");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult EditContrat_Assurance(int id)
        {
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["societeass"] = new SelectList(BissInventaireEntities.Instance.Societe_assurance.ToList(), "Id_societe_assurance", "libelle");
            ViewData["contratass"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_contrat_assurance", "Num");
            var bat = del.FindContrat_assuranceByID(id);
           
            return View(bat);

        }

        // POST: GestionContratetSoc/Edit/5
        [HttpPost]
        public ActionResult EditContrat_Assurance(Contrat_assurance assur, FormCollection collection)
        {
            var bat = del.FindContrat_assuranceByID(assur.Id_contrat_assurance);
            try
            {
               
                db1.UpdateContrat_assuranceDetached(assur);
                db.SaveChanges();
                return RedirectToAction("GetContrat_assurance");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult DetailsContrat_Assurance(int id)
        {
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

        public ActionResult CreateContrat_Maintenance()
        {
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
            ViewData["societeass"] = new SelectList(BissInventaireEntities.Instance.Societe_assurance.ToList(), "Id_societe_assurance", "libelle");
            ViewData["societemain"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_societe_maintenance", "libelle");
            return View();
        }

        // POST: GestionContratetSoc/Create
        [HttpPost]
        public ActionResult CreateContrat_Maintenance(Contrat_maintenance contrat, FormCollection collection)
        {
            try
            {
                var soc = db1.FindSocMainByID(contrat.Id_societe_maintenance);
                contrat.idDelegation = soc.idDelegation;
                db.Contrat_maintenance.Add(contrat);
                db.SaveChanges();

                return RedirectToAction("GetContrat_Maintenance");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult CreateContrat_garanti()
        {
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
            ViewData["societeass"] = new SelectList(BissInventaireEntities.Instance.Societe_assurance.ToList(), "Id_societe_assurance", "libelle");
            ViewData["societemain"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_societe_maintenance", "libelle");
            return View();
        }

        // POST: GestionContratetSoc/Create
        [HttpPost]
        public ActionResult CreateContrat_garanti(Contrat_garanti contrat, FormCollection collection)
        {
            try
            {
                var fu = fourni.FindFourByID(contrat.Id_fournisseur);
                contrat.idDelegation = fu.idDelegation;
                db.Contrat_garanti.Add(contrat);
                db.SaveChanges();

                return RedirectToAction("GetContrat_Garantie");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult CreateSociete_assurance()
        {
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
            ViewData["societeass"] = new SelectList(BissInventaireEntities.Instance.Societe_assurance.ToList(), "Id_societe_assurance", "libelle");
            ViewData["societemain"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_societe_maintenance", "libelle");
            return View();
        }

        // POST: GestionContratetSoc/Create
        [HttpPost]
        public ActionResult CreateSociete_assurance(Societe_assurance societe, FormCollection collection)
        {
            try
            {
                db.Societe_assurance.Add(societe);
                db.SaveChanges();

                return RedirectToAction("GetSociete_Assurance");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }


        public ActionResult CreateSociete_maintenance()
        {
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
            ViewData["societeass"] = new SelectList(BissInventaireEntities.Instance.Societe_assurance.ToList(), "Id_societe_assurance", "libelle");
            ViewData["societemain"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_societe_maintenance", "libelle");
            return View();
        }

        // POST: GestionContratetSoc/Create
        [HttpPost]
        public ActionResult CreateSociete_maintenance(Societe_maintenance societe, FormCollection collection)
        {
            try
            {
                db.Societe_maintenance.Add(societe);
                db.SaveChanges();

                return RedirectToAction("GetSociete_Maintenance");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }


        public ActionResult CreateAchat()
        {
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
            ViewData["societeass"] = new SelectList(BissInventaireEntities.Instance.Societe_assurance.ToList(), "Id_societe_assurance", "libelle");
            ViewData["contratass"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_contrat_assurance", "Num");
            ViewData["contratgar"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_contrat_garanti", "Num");
            ViewData["achats"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_achat", "Num_facture");
            return View();
        }

        // POST: GestionContratetSoc/Create
        [HttpPost]
        public ActionResult CreateAchat(Achat achat, FormCollection collection)
        {
            try
            {
                var four = fourni.FindFourByID(achat.Id_fournisseur);
              //  achat.Date_d_achat = System.DateTime.Now;
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
        // GET: GestionContratetSoc/Edit/5
        public ActionResult EditAchat(int id)
        {
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["gouvers"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["fournisseurs"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Nom");
            ViewData["societeass"] = new SelectList(BissInventaireEntities.Instance.Societe_assurance.ToList(), "Id_societe_assurance", "libelle");
            ViewData["contratass"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_contrat_assurance", "Num");
            ViewData["contratgar"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_contrat_garanti", "Num");
            ViewData["achats"] = new SelectList(BissInventaireEntities.Instance.Societe_maintenance.ToList(), "Id_achat", "Num_facture");
            
            var acht = db.Achat.Find(id);
            return View(acht);

        }

        // POST: GestionContratetSoc/Edit/5
        [HttpPost]
        public ActionResult EditAchat(Achat acht, FormCollection collection)
        {
            try
            {

                db1.UpdateAchatDetached(acht);
                db.SaveChanges();
                return RedirectToAction("GetAchat");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: GestionContratetSoc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GestionContratetSoc/Delete/5
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
