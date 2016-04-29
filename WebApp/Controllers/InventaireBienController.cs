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
        public ActionResult GetInventaireBiens(string Delegation, string Etage, string Batiment, string Organisation, 
            string Bureau, string Direction, string ServiceD, string Depot, string Categorie, string Sous_categorie,
            string Modele ,string Sous_modele, string Marque, string Personnel, string Fournisseur, string Achat)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var etage = BissInventaireEntities.Instance.Etage.ToList();
            var batiment = BissInventaireEntities.Instance.Batiment.ToList();
            var delegation = BissInventaireEntities.Instance.Delegation.ToList();
             var organisation = BissInventaireEntities.Instance.Organisation.ToList();
            var bureau = BissInventaireEntities.Instance.Bureau.ToList();
            var direction = BissInventaireEntities.Instance.Direction.ToList();
            var service = BissInventaireEntities.Instance.ServiceD.ToList();
            var depot = BissInventaireEntities.Instance.Depot.ToList();
         
            var categorie = BissInventaireEntities.Instance.Categorie.ToList();
            var sous_categorie = BissInventaireEntities.Instance.Sous_categorie.ToList();
            var model = BissInventaireEntities.Instance.Modele.ToList();
            var sous_model = BissInventaireEntities.Instance.Sous_modele.ToList();
            var marque = BissInventaireEntities.Instance.Marque.ToList();
            var personnel = BissInventaireEntities.Instance.Personnel.ToList();
            var fournisseur = BissInventaireEntities.Instance.Fournisseur.ToList();
            var n_livraison = BissInventaireEntities.Instance.Achat.ToList();
            
            ViewData["etage"] = new SelectList(etage, "Description", "Description");
            ViewData["batiment"] = new SelectList(batiment, "Description", "Description");
            ViewData["delegation"] = new SelectList(delegation, "libelle", "libelle");
            ViewData["organisation"] = new SelectList(organisation, "libelle", "libelle");
            ViewData["bureau"] = new SelectList(bureau, "Description", "Description");
            ViewData["direction"] = new SelectList(direction, "libelle", "libelle");
            ViewData["service"] = new SelectList(service, "Libelle", "Libelle");
            ViewData["Depot"] = new SelectList(depot, "libelle", "libelle");
        
            ViewData["categorie"] = new SelectList(categorie, "libelle", "libelle");
            ViewData["sous_categorie"] = new SelectList(sous_categorie, "libelle", "libelle");
            ViewData["model"] = new SelectList(model, "libelle", "libelle");
            ViewData["sous_model"] = new SelectList(sous_model, "Libelle", "Libelle");
            ViewData["marque"] = new SelectList(marque, "Libelle", "Libelle");
            ViewData["personnel"] = new SelectList(personnel, "Matricule", "Matricule");
            ViewData["fournisseur"] = new SelectList(fournisseur, "Nom", "Nom");
            ViewData["n_livraison"] = new SelectList(n_livraison, "Num_livraison", "Num_livraison");

            var bien = BissInventaireEntities.Instance.InventaireBien.ToList();
            int nbr = bien.ToList().Count();
            ViewBag.nbr = nbr;


            if (string.IsNullOrEmpty(Etage) && string.IsNullOrEmpty(Batiment) && string.IsNullOrEmpty(Delegation)
                && string.IsNullOrEmpty(Organisation) && string.IsNullOrEmpty(Bureau) && string.IsNullOrEmpty(Direction)
                && string.IsNullOrEmpty(ServiceD) && string.IsNullOrEmpty(Depot) && string.IsNullOrEmpty(Categorie)
                && string.IsNullOrEmpty(Sous_categorie) && string.IsNullOrEmpty(Modele) && string.IsNullOrEmpty(Sous_modele)
                && string.IsNullOrEmpty(Marque) && string.IsNullOrEmpty(Personnel) && string.IsNullOrEmpty(Fournisseur) 
                && string.IsNullOrEmpty(Achat) )
            {
                return View(bien.ToList());

            }
            else
            {

                var dep = from s in bien select s;
                if (String.IsNullOrEmpty(Etage) || (String.IsNullOrEmpty(Batiment)))
                {
                    //dep = dep.Where(s => (string.IsNullOrEmpty(Etage) || (s.Bien.Etage.description.ToString().StartsWith(Etage)))

                    //&& (string.IsNullOrEmpty(Batiment) || (s.Bien.Etage.Batiment.description.ToString().StartsWith(Batiment)))
                    // && (string.IsNullOrEmpty(Delegation) || (s.Bien.Etage.Batiment.Delegation.libelle.ToString().StartsWith(Delegation)))
                    // && (string.IsNullOrEmpty(Organisation) || (s.Bien.Etage.Batiment.Organisation.libelle.ToString().StartsWith(Organisation)))
                    // && (string.IsNullOrEmpty(Bureau) || (s.Bien.Etage.Bureau.ToString().StartsWith(Bureau)))
                    // && (string.IsNullOrEmpty(Direction) || (s.Bien.Personnel.ServiceD.Direction.Libelle.ToString().StartsWith(Direction)))
                    // && (string.IsNullOrEmpty(ServiceD) || (s.Bien.Personnel.ServiceD.Libelle.ToString().StartsWith(ServiceD)))
                    // && (string.IsNullOrEmpty(Depot) || (s.Bien.Depot.libelle.ToString().StartsWith(Depot)))
                    // && (string.IsNullOrEmpty(Categorie) || (s.Bien.Categorie.libelle.ToString().StartsWith(Categorie)))
                    // && (string.IsNullOrEmpty(Sous_categorie) || (s.Bien.Sous_categorie.ToString().StartsWith(Sous_categorie)))
                    // && (string.IsNullOrEmpty(Modele) || (s.Bien.Modele.ToString().StartsWith(Modele)))
                    // && (string.IsNullOrEmpty(Sous_modele) || (s.Bien.Sous_Modele.ToString().StartsWith(Sous_modele)))
                    // && (string.IsNullOrEmpty(Marque) || (s.Bien.Marque.ToString().StartsWith(Marque)))
                    // && (string.IsNullOrEmpty(Personnel) || (s.Bien.Personnel.Matricule.ToString().StartsWith(Personnel)))
                    // && (string.IsNullOrEmpty(Fournisseur) || (s.Bien.Achat.Fournisseur.Nom.ToString().StartsWith(Fournisseur)))
                    // && (string.IsNullOrEmpty(Achat) || (s.Bien.Achat.Num_livraison.ToString().StartsWith(Achat)))
                    //);



                    dep = dep.Where(s => ( s.Bien.Etage.Batiment.Delegation.libelle.ToString().StartsWith(Delegation))

                    
                       );

                }
                else
                {
                    dep = dep.Where(s => (s.Bien.Etage.description.ToString().StartsWith(Etage))


                    && (s.Bien.Etage.Batiment.Delegation.libelle.ToString().StartsWith(Delegation))
                    && (s.Bien.Etage.Batiment.description.ToString().StartsWith(Batiment))
                    &&(s.Bien.Etage.Batiment.Organisation.libelle.ToString().StartsWith(Organisation))
                   && (s.Bien.Etage.Bureau.ToString().StartsWith(Bureau))
                   && (s.Bien.Personnel.ServiceD.Direction.Libelle.ToString().StartsWith(Direction))
                   && (s.Bien.Personnel.ServiceD.Libelle.ToString().StartsWith(ServiceD))
                   && (s.Bien.Depot.libelle.ToString().StartsWith(Depot))
                   && (s.Bien.Categorie.libelle.ToString().StartsWith(Categorie))
                   && (s.Bien.Sous_categorie.ToString().StartsWith(Sous_categorie))
                   && (s.Bien.Modele.ToString().StartsWith(Modele))
                   && (s.Bien.Sous_Modele.ToString().StartsWith(Sous_modele))
                   && (s.Bien.Marque.ToString().StartsWith(Marque))
                   && (s.Bien.Marque.ToString().StartsWith(Marque))
                   && (s.Bien.Personnel.Matricule.ToString().StartsWith(Personnel))
                   && (s.Bien.Achat.Fournisseur.Nom.ToString().StartsWith(Fournisseur))
                   && (s.Bien.Achat.Num_livraison.ToString().StartsWith(Achat))

                   

                        );

                }

                int nbr2 = dep.ToList().Count();
                ViewBag.nbr = nbr2;
                return View(dep.ToList())
                    ;
            }
        }

        //var inv = db.GetInventaireBiens();
        //    return View(inv);
        //}


        public ActionResult GetDetailsInvBienBiens()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var inv = db.GetInventaireBiens();

            return View(inv);
        }

        public ActionResult GetBiens()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var bien = BissInventaireEntities.Instance.Bien.ToList();



            return View(bien.ToList())
                ;
        }

    
      

        // POST: Mouvement/Create
    
       
        public ActionResult Index()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }


    }
}