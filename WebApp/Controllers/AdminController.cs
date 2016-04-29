using Domain;
using Log;
using Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        private IBureauService db = new BureauService();
        private IUtilisateurService db1 = new UtilisateurService();
        private IRegionService db2 = new RegionService();
        private IDepotService depo = new DepotService();
        private ICategorieService db3 = new CategorieService();
        private IBienService db4 = new BienService();

        public bool etat = true;

        //private IEnumerable<Bureau> depts = InventaireBiss2015Entities.Instance.Bureau.ToList();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        public ActionResult GetBureuax()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["batiments"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            ViewData["etages"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "Description");
            var bure = db.GetBureaux();
            return View(bure);
        }

        public ActionResult GetTrace()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            if (Session["Role"].ToString() == "ADMIN")
            {
                var bure = BissInventaireEntities.Instance.Trace.ToList(); ;
                return View(bure);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult GetUsers()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var users = db1.GetUtilisateurs();
            return View(users);
        }



        public ActionResult Dashboard()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();

        }

        // GET: Admin/Details/5
        public ActionResult DetailsBien(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            try
            {

                var archive = BissInventaireEntities.Instance.Bien.Find(id);

                return View(archive);
            }
            catch (Exception ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }


        }
        public ActionResult CreateDepot()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "libelle", "libelle");
            ViewData["gouvernourat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            return View();
        }
        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateDepot(Depot dep, FormCollection collection)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            if (ModelState.IsValid)
            {
                if (etat)
                {
                    depo.createDepot(dep);
                    depo.SaveDepot();

                    return RedirectToAction("getDepots");
                }
                else
                {
                    return RedirectToAction("Index", "Error");
                }

            }
            else

            {
                //  ViewBag.msg = "Verifier l code postal";
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "libelle", "libelle");
                ViewData["gouvernourat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");

                return View();
            }
        }
        [HttpPost]
        public ActionResult OpenPopupDepot(string delegid)
        {
            String Mess = "";

            var objcity = BissInventaireEntities.Instance.Depot.FirstOrDefault(u => u.libelle.ToLower() == delegid);
            if (objcity != null)
            {
                Mess = "Ce depot existe déja!!";
            }

            //iuoiy
            return Json(Mess);
        }
        public ActionResult EditDepot(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var dep = depo.findDepotById(id);
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "libelle", "libelle");
            ViewData["gouvernourat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");

            return View(dep);

        }

        // POST: Bureau/Edit/5
        [HttpPost]
        public ActionResult EditDepot(Depot dep, FormCollection collection)
        {

            if (ModelState.IsValid)
            {

                depo.UpdateDepotDetached(dep);
                depo.SaveDepot();

                return RedirectToAction("getDepots");

            }
            else

            {
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "libelle", "libelle");
                ViewData["gouvernourat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");

                return View();
            }
        }
        public ActionResult getDepots()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "libelle", "libelle");
            ViewData["gouvernourat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            var bure = depo.getDepots();
            return View(bure);
        }
        // GET: Admin/Create
        public ActionResult CreateBureaux()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["batiments"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            ViewData["etages"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "Description");
            ViewData["direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");

            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateBureaux(Bureau Bur, FormCollection collection)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            if (ModelState.IsValid)
            {
                if (etat)
                {
                    db.CreateBureau(Bur);
                    db.SaveBureau();

                    return RedirectToAction("GetBureuax");
                }
                else
                {
                    return RedirectToAction("Index", "Error");
                }

            }
            else

            {
                //  ViewBag.msg = "Verifier l code postal";
                ViewData["batiments"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
                ViewData["etages"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "Description");
                ViewData["direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");

                return View();
            }
        }

        [HttpPost]
        public ActionResult OpenPopup(int delegid)
        {
            String Mess = "";

            var objcity = BissInventaireEntities.Instance.Bureau.FirstOrDefault(u => u.id == delegid);
            if (objcity != null)
            {
                Mess = "Le code Bureau existe déja!!";
                etat = false;
            }


            return Json(Mess);
        }
        public ActionResult EditUser(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var ise = db1.GetUtilisateurById(id);
            ViewData["personel"] = new SelectList(BissInventaireEntities.Instance.Personnel.ToList(), "id", "Matricule");
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");


            return View(ise);
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult EditUser(Utilisateur user, FormCollection collection)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            if (ModelState.IsValid)
            {
                db1.UpdateUtilisateurDetached(user);
                db1.SaveEmploye();
                var Emp = (Utilisateur)Session["identifiant"];
                Trace tr = new Trace();
                tr.Dates = DateTime.Now;
                tr.Actions = "Modification utilisateur";
                tr.Champs = (user.Personnel.Matricule).ToString();
                tr.Tables = "Utilisateur";
                tr.Users = (Emp.Personnel.Matricule).ToString();
                BissInventaireEntities.Instance.Trace.Add(tr);
                BissInventaireEntities.Instance.SaveChanges();

                return RedirectToAction("GetUsers");
            }
            else

            {
                //  ViewBag.msg = "Verifier l code postal";
                ViewData["personel"] = new SelectList(BissInventaireEntities.Instance.Personnel.ToList(), "id", "Matricule");
                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");


                return View();
            }
        }

        //[HttpPost]
        //public ActionResult FindPersByBatiment(int Persid)
        //{

        //    List<Personnel> objcity = new List<Personnel>();
        //    objcity = db1.FindPersByBatiment(Persid).ToList();

        //    SelectList obgcity = new SelectList(objcity, "id", "Matricule", 0);
        //    return Json(obgcity);
        //}
        public ActionResult CreateBien()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["achats"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_livraison");

            //ViewData["societemain"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_societe_maintenance", "Libelle");

            //ViewData["contratmain"] = new SelectList(BissInventaireEntities.Instance.Contrat.ToList(), "Id_contrat", "Num");
            ViewData["Bureau"] = new SelectList(BissInventaireEntities.Instance.Depot.ToList(), "id", "Description");
            ViewData["personnel"] = new SelectList(BissInventaireEntities.Instance.Personnel.ToList(), "id_pers", "Matricule");
            ViewData["pers"] = new SelectList(BissInventaireEntities.Instance.Personnel.ToList(), "id_pers", "nom");
            ViewData["categorie"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "Id_categorie", "libelle");
            ViewData["Delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["service"] = new SelectList(BissInventaireEntities.Instance.ServiceD.ToList(), "Id_service", "Libelle");
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateBien(Bien bien, FormCollection collection)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            if (ModelState.IsValid)
            {

                try
                {
                    HttpPostedFileBase file = Request.Files["ImageData"];
                    bien.Photo = ConvertToBytes(file);
                    var photo = bien.Photo;
                    BissInventaireEntities.Instance.Bien.Add(bien);
                    BissInventaireEntities.Instance.SaveChanges();

                    return RedirectToAction("RapportBien");

                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                ViewData["achats"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_livraison");

                ViewData["societemain"] = new SelectList(BissInventaireEntities.Instance.Fournisseur.ToList(), "Id_fournisseur", "Libelle");
                ViewData["pers"] = new SelectList(BissInventaireEntities.Instance.Personnel.ToList(), "id_pers", "nom", "prenom");
                ViewData["personnel"] = new SelectList(BissInventaireEntities.Instance.Personnel.ToList(), "id_pers", "Matricule");
                ViewData["categorie"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "Id_categorie", "libelle");
                ViewData["Delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                ViewData["service"] = new SelectList(BissInventaireEntities.Instance.ServiceD.ToList(), "Id_service", "Libelle");
                ViewData["contratmain"] = new SelectList(BissInventaireEntities.Instance.Contrat.ToList(), "Id_contrat_maintenance", "Num");
                ViewData["categorie"] = new SelectList(BissInventaireEntities.Instance.Categorie.ToList(), "Id_categorie", "libelle");
                ViewData["Depot"] = new SelectList(BissInventaireEntities.Instance.Depot.ToList(), "IdDepot", "libelle");
                ViewData["Bureau"] = new SelectList(BissInventaireEntities.Instance.Depot.ToList(), "id", "Description");

                return View();
            }
        }

        //[HttpPost]
        //public ActionResult Create(Bien bien)
        //{
        //    HttpPostedFileBase file = Request.Files["ImageData"];

        //    bien.Photo = ConvertToBytes(file);
        //    var photo = bien.Photo;

        //    //int i = UploadImageInDataBase(file, bien);
        //    //if (i == 1)
        //    //{
        //    //    return RedirectToAction("Index");
        //    //}
        //    return View(bien);
        // }

        //public int UploadImageInDataBase(HttpPostedFileBase file, Bien bien)
        //{
        //    bien.Photo = ConvertToBytes(file);
        //    var img = bien.Photo;

        //    int i = db.SaveChanges();
        //    if (i == 1)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}
        public byte[] ConvertToBytes(HttpPostedFileBase photo)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(photo.InputStream);
            imageBytes = reader.ReadBytes((int)photo.ContentLength);
            return imageBytes;
        }
        //public FileContentResult GetThumbnailImage(int artworkId)
        //{
        //    ArtWork art = db.ArtWorks.FirstOrDefault(p => p.ArtWorkId == artworkId);
        //    if (art != null)
        //    {
        //        return File(art.ArtworkThumbnail, art.ImageMimeType.ToString());
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public ActionResult CreateBienAdmin()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["depts"] = new SelectList(db.GetBureaux(), "Id", "Description");
            ViewData["Bureau"] = new SelectList(BissInventaireEntities.Instance.Depot.ToList(), "id", "Description");
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateBienAdmin(Bien Bur, FormCollection collection)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            if (ModelState.IsValid)
            {

                try
                {
                    BissInventaireEntities.Instance.Bien.Add(Bur);
                    BissInventaireEntities.Instance.SaveChanges();

                    return RedirectToAction("RapportBien");
                }

                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                ViewData["depts"] = new SelectList(db.GetBureaux(), "Id", "Description");
                ViewData["Bureau"] = new SelectList(BissInventaireEntities.Instance.Depot.ToList(), "id", "Description");
                return View();
            }
        }

        public byte[] GetImageFromDataBase(int Id)
        {
            var q = from temp in BissInventaireEntities.Instance.Bien where temp.Id_bien == Id select temp.Photo;
            byte[] cover = q.First();
            return cover;
        }
        public ActionResult RetrieveImage(int id)
        {
            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        public ActionResult InventaireBiens(string Delegation, string Etage, string Batiment, string Organisation,
           string Bureau, string Direction, string Service, string Depot, string Categorie, string Sous_categorie,
           string modele, string Sous_modele, string Marque, string Personnel, string Fournisseur, string n_livraison)
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
            var N_livraison = BissInventaireEntities.Instance.Achat.ToList();

            ViewData["etage"] = new SelectList(etage, "Description", "Description");
            ViewData["batiment"] = new SelectList(batiment, "Description", "Description");
            ViewData["delegation"] = new SelectList(delegation, "libelle", "libelle");
            ViewData["organisation"] = new SelectList(organisation, "libelle", "libelle");
            ViewData["bureau"] = new SelectList(bureau, "Id_bureau", "Description");
            ViewData["direction"] = new SelectList(direction, "libelle", "libelle");
            ViewData["service"] = new SelectList(service, "Libelle", "Libelle");
            ViewData["Depot"] = new SelectList(depot, "libelle", "libelle");
            ViewData["categorie"] = new SelectList(categorie, "libelle", "libelle");
            ViewData["sous_categorie"] = new SelectList(sous_categorie, "libelle", "libelle");
            ViewData["modele"] = new SelectList(model, "libelle", "libelle");
            ViewData["Sous_modele"] = new SelectList(sous_model, "Libelle", "Libelle");
            ViewData["marque"] = new SelectList(marque, "Libelle", "Libelle");
            ViewData["personnel"] = new SelectList(personnel, "Matricule", "Matricule");
            ViewData["fournisseur"] = new SelectList(fournisseur, "Nom", "Nom");
            ViewData["n_livraison"] = new SelectList(N_livraison, "Num_livraison", "Num_livraison");

            var bien = BissInventaireEntities.Instance.Bien.ToList();
            int nbr = bien.ToList().Count();
            ViewBag.nbr = nbr;


            if (string.IsNullOrEmpty(Etage) && string.IsNullOrEmpty(Batiment) && string.IsNullOrEmpty(Delegation)
                && string.IsNullOrEmpty(Organisation) && string.IsNullOrEmpty(Bureau) && string.IsNullOrEmpty(Direction)
                && string.IsNullOrEmpty(Service) && string.IsNullOrEmpty(Depot) && string.IsNullOrEmpty(Categorie)
                && string.IsNullOrEmpty(Sous_categorie) && string.IsNullOrEmpty(modele) && string.IsNullOrEmpty(Sous_modele)
                && string.IsNullOrEmpty(Marque) && string.IsNullOrEmpty(Personnel) && string.IsNullOrEmpty(Fournisseur)
                && string.IsNullOrEmpty(n_livraison) && string.IsNullOrEmpty(Batiment) && string.IsNullOrEmpty(Batiment))
            {
                return View(bien.ToList());

            }
            else
            {

                var dep = from s in bien select s;
                if (String.IsNullOrEmpty(Etage) || (String.IsNullOrEmpty(Batiment)) || (String.IsNullOrEmpty(Bureau))
                    || (String.IsNullOrEmpty(Delegation)) || (String.IsNullOrEmpty(Organisation)) || (String.IsNullOrEmpty(Direction))
                    || (String.IsNullOrEmpty(Service)) || (String.IsNullOrEmpty(Depot)) || (String.IsNullOrEmpty(Categorie))
                    || (String.IsNullOrEmpty(Sous_categorie)) || (String.IsNullOrEmpty(modele)) || (String.IsNullOrEmpty(Sous_modele))
                    || (String.IsNullOrEmpty(Marque)) || (String.IsNullOrEmpty(Personnel)) || (String.IsNullOrEmpty(Fournisseur))
                    || (String.IsNullOrEmpty(n_livraison)))
                {
                    dep = dep.Where(s => (string.IsNullOrEmpty(Etage) || (s.Etage.description.ToString().StartsWith(Etage)))

                    && (string.IsNullOrEmpty(Batiment) || (s.Etage.Batiment.description.ToString().StartsWith(Batiment)))
                     && (string.IsNullOrEmpty(Delegation) || (s.Etage.Batiment.Delegation.libelle.ToString().StartsWith(Delegation)))
                     && (string.IsNullOrEmpty(Organisation) || (s.Etage.Batiment.Organisation.libelle.ToString().StartsWith(Organisation)))
                     && (string.IsNullOrEmpty(Bureau) || (s.Id_bureau.ToString().StartsWith(Bureau)))
                     && (string.IsNullOrEmpty(Direction) || (s.Personnel.ServiceD.Direction.Libelle.ToString().StartsWith(Direction)))
                     && (string.IsNullOrEmpty(Service) || (s.Personnel.ServiceD.Libelle.ToString().StartsWith(Service)))
                     && (string.IsNullOrEmpty(Depot) || (s.Depot.libelle.ToString().StartsWith(Depot)))
                     && (string.IsNullOrEmpty(Categorie) || (s.Categorie.libelle.ToString().StartsWith(Categorie)))
                     && (string.IsNullOrEmpty(Sous_categorie) || (s.Sous_categorie.ToString().StartsWith(Sous_categorie)))
                     && (string.IsNullOrEmpty(modele) || (s.Modele.ToString().StartsWith(modele)))
                     && (string.IsNullOrEmpty(Sous_modele) || (s.Sous_Modele.ToString().StartsWith(Sous_modele)))
                     && (string.IsNullOrEmpty(Marque) || (s.Marque.ToString().StartsWith(Marque)))
                     && (string.IsNullOrEmpty(Personnel) || (s.Personnel.Matricule.ToString().StartsWith(Personnel)))
                     && (string.IsNullOrEmpty(Fournisseur) || (s.Achat.Fournisseur.Nom.ToString().StartsWith(Fournisseur)))
                     && (string.IsNullOrEmpty(n_livraison) || (s.Achat.Num_livraison.ToString().StartsWith(n_livraison)))
                    );

                }
                else
                {
                    dep = dep.Where(s => (s.Etage.description.ToString().StartsWith(Etage))
                    && (s.Etage.Batiment.description.ToString().StartsWith(Batiment))
                    && (s.Etage.Batiment.Organisation.libelle.ToString().StartsWith(Organisation))
                   && (s.Etage.Bureau.ToString().StartsWith(Bureau))
                   && (s.Personnel.ServiceD.Direction.Libelle.ToString().StartsWith(Direction))
                   && (s.Personnel.ServiceD.Libelle.ToString().StartsWith(Service))
                   && (s.Depot.libelle.ToString().StartsWith(Depot))
                   && (s.Categorie.libelle.ToString().StartsWith(Categorie))
                   && (s.Sous_categorie.ToString().StartsWith(Sous_categorie))
                   && (s.Modele.ToString().StartsWith(modele))
                   && (s.Sous_Modele.ToString().StartsWith(Sous_modele))
                   && (s.Marque.ToString().StartsWith(Marque))
                   && (s.Marque.ToString().StartsWith(Marque))
                   && (s.Personnel.Matricule.ToString().StartsWith(Personnel))
                   && (s.Achat.Fournisseur.Nom.ToString().StartsWith(Fournisseur))
                   && (s.Achat.Num_livraison.ToString().StartsWith(n_livraison))



                        );

                }

                int nbr2 = dep.ToList().Count();
                ViewBag.nbr = nbr2;
                return View(dep.ToList())
                    ;
            }
        }
        public ActionResult RapportBien(string Delegation, string Etage, string Batiment)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }


            var etage = BissInventaireEntities.Instance.Etage.ToList();
            var batiment = BissInventaireEntities.Instance.Batiment.ToList();
            var delegation = BissInventaireEntities.Instance.Delegation.ToList();
           


            ViewData["etage"] = new SelectList(etage, "Description", "Description");
            ViewData["batiment"] = new SelectList(batiment, "Description", "Description");
            ViewData["delegation"] = new SelectList(delegation, "libelle", "libelle");
          
            var bien = BissInventaireEntities.Instance.Bien.ToList();
            int nbr = bien.ToList().Count();
            ViewBag.nbr = nbr;


            if (string.IsNullOrEmpty(Etage) && string.IsNullOrEmpty(Batiment) && string.IsNullOrEmpty(Delegation))
              
            {
                return View(bien.ToList());

            }
            else
            {

                var dep = from s in bien select s;
                if (String.IsNullOrEmpty(Etage) || (String.IsNullOrEmpty(Batiment)))
                {
                    dep = dep.Where(s => (string.IsNullOrEmpty(Etage) || (s.Etage.description.ToString().StartsWith(Etage)))
                    && (string.IsNullOrEmpty(Batiment) || (s.Etage.Batiment.description.ToString().StartsWith(Batiment)))
                     && (string.IsNullOrEmpty(Delegation) || (s.Etage.Batiment.Delegation.libelle.ToString().StartsWith(Delegation)))
                   
                    );

                }
                else
                {
                    dep = dep.Where(s => (s.Etage.description.ToString().StartsWith(Etage))
                     && (s.Etage.Batiment.description.ToString().StartsWith(Batiment))
                     && (s.Etage.Batiment.Delegation.libelle.ToString().StartsWith(Delegation))

                    );
                }

                int nbr2 = dep.ToList().Count();
                ViewBag.nbr = nbr2;
                return View(dep.ToList());

            }

        }

        public ActionResult EditBureaux(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var eta = db.FindBureauByID(id);
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["gouvernorat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["organisation"] = new SelectList(BissInventaireEntities.Instance.Organisation.ToList(), "idOrganisation", "libelle");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            ViewData["etages"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "Description");

            return View(eta);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditBureaux(Bureau etg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UpdateBureauDetached(etg);
                    db.SaveBureau();
                    return RedirectToAction("GetBureuax");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
                ViewData["gouvernorat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["organisation"] = new SelectList(BissInventaireEntities.Instance.Organisation.ToList(), "idOrganisation", "libelle");
                ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
                ViewData["etages"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "Description");
                return View();
            }
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult ActDesactiveUsers(int id)
        {

            var test = db1.GetUtilisateurById(id);
            try
            {

                if (test.etatUtilisateur == true)
                {
                    test.etatUtilisateur = false;
                    db1.UpdateUtilisateurDetached(test);
                    db1.SaveEmploye();
                }
                else
                {
                    test.etatUtilisateur = true;
                    db1.UpdateUtilisateurDetached(test);
                    db1.SaveEmploye();
                }


                return RedirectToAction("GetUsers");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult CreateUsers()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["personel"] = new SelectList(BissInventaireEntities.Instance.Personnel.ToList(), "id_pers", "Matricule");
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            ViewData["Direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateUsers(Utilisateur user, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    user.etatUtilisateur = true;
                    //db1.CreateUtilisateurs(user);
                    //db1.SaveEmploye();
                    BissInventaireEntities.Instance.Utilisateur.Add(user);
                    BissInventaireEntities.Instance.SaveChanges();

                    var Emp = (Utilisateur)Session["identifiant"];
                    Trace tr = new Trace();
                    tr.Dates = DateTime.Now;
                    tr.Actions = "Ajout utilisateur";
                    tr.Champs = (user.Personnel.Matricule).ToString();
                    tr.Tables = "Utilisateur";
                    tr.Users = (Emp.Personnel.Matricule).ToString();
                    BissInventaireEntities.Instance.Trace.Add(tr);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetUsers");
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
                //catch (SqlException sq)
                //{
                //    LogThread.WriteLine(sq.Message);
                //    return RedirectToAction("Index", "Error");
                //}
                //catch (Exception ex)
                //{
                //    LogThread.WriteLine(ex.Message);
                //    return RedirectToAction("Index", "Error");
                //}
            }
            else

            {
                ViewData["personel"] = new SelectList(BissInventaireEntities.Instance.Personnel.ToList(), "id_pers", "Matricule");
                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
                ViewData["Direction"] = new SelectList(BissInventaireEntities.Instance.Direction.ToList(), "Id_direction", "Libelle");
                return View();
            }
        }


        public ActionResult CreateUsersTest()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["personel"] = new SelectList(BissInventaireEntities.Instance.Personnel.ToList(), "id", "Matricule");
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateUsersTest(Utilisateur user, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    user.etatUtilisateur = true;
                    db1.CreateUtilisateurs(user);
                    db1.SaveEmploye();

                    var Emp = (Utilisateur)Session["identifiant"];
                    Trace tr = new Trace();
                    tr.Dates = DateTime.Now;
                    tr.Actions = "Ajout utilisateur";
                    tr.Champs = (user.Personnel.Matricule).ToString();
                    tr.Tables = "Utilisateur";
                    tr.Users = (Emp.Personnel.Matricule).ToString();
                    BissInventaireEntities.Instance.Trace.Add(tr);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetUsers");
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
            else

            {
                ViewData["personel"] = new SelectList(BissInventaireEntities.Instance.Personnel.ToList(), "id", "Matricule");
                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
                return View();
            }
        }


        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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




        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        // POST: Admin/Delete/5
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


        //
        // POST: /Admin/Create
        [HttpPost]
        public ActionResult getEtageByBatiment(int stateid)
        {

            List<Etage> objcity = new List<Etage>();

            objcity = db.findEtageByBatiment(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "Id_etage", "description", 0);
            return Json(obgcity);
        }

        [HttpPost]
        public ActionResult getBureauByEtage(int stateid)
        {

            List<Bureau> objcity = new List<Bureau>();

            objcity = db.findBureauByEtage(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "Id_bureau", "Description", 0);
            return Json(obgcity);
        }

        [HttpPost]
        public ActionResult getDepotByDelegation(int stateid)
        {

            List<Depot> objcity = new List<Depot>();

            objcity = depo.findDepotByDelegation(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "IdDepot", "libelle", 0);
            return Json(obgcity);
        }

        [HttpPost]
        public ActionResult getSousCategorieByCategorie(int stateid)
        {

            List<Sous_categorie> objcity = new List<Sous_categorie>();

            objcity = db3.FindPorduitByID(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "libelle", "libelle", 0);
            return Json(obgcity);
        }
        [HttpPost]
        public ActionResult getModeleBySousCategorie(string libelle)
        {

            List<Modele> objcity = new List<Modele>();

            objcity = db3.findModeleBySousCategorie(libelle).ToList();

            SelectList obgcity = new SelectList(objcity, "libelle", "libelle", 0);
            return Json(obgcity);
        }

        [HttpPost]
        public ActionResult getSousModeleByModele(string libelle)
        {

            List<Sous_modele> objcity = new List<Sous_modele>();

            objcity = db3.findSousModeleByLibelleModele(libelle).ToList();

            SelectList obgcity = new SelectList(objcity, "Libelle", "Libelle", 0);
            return Json(obgcity);
        }

        [HttpPost]
        public ActionResult getMarqueBySousModele(string libelle)
        {

            List<Marque> objcity = new List<Marque>();

            objcity = db3.findMarqueBylibelleSousModele(libelle).ToList();

            SelectList obgcity = new SelectList(objcity, "Libelle", "Libelle", 0);
            return Json(obgcity);
        }
        [HttpPost]
        public ActionResult GetGouvernoratByPays(string stateid)
        {
            IGouvernoratService bat = new GouvernoratService();
            List<Gouvernorat> objcity = new List<Gouvernorat>();

            objcity = bat.findGouverneratByLibellePays(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "libelle", "libelle", 0);
            return Json(obgcity);
        }

        [HttpPost]
        public ActionResult GetGouvernoratByRegion(int stateid)
        {
            IGouvernoratService bat = new GouvernoratService();
            List<Gouvernorat> objcity = new List<Gouvernorat>();

            objcity = bat.FindGouverneratByRegion(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "idGouvernorat", "libelle", 0);
            return Json(obgcity);
        }

        [HttpPost]
        public ActionResult GetDelegationByGouvernorat(int libelle)
        {
            IDelegationService bat = new DelegationService();
            List<Delegation> objcity = new List<Delegation>();

            objcity = bat.FindDelegationtByGouvernerat(libelle).ToList();

            SelectList obgcity = new SelectList(objcity, "libelle", "libelle", 0);
            return Json(obgcity);
        }
        [HttpPost]
        public ActionResult getNom(int id)
        {
            IPersonnelService pers = new PersonnelService();


            string objcity = pers.findNomByMatricule(id);

            return Json(objcity);
        }

        public ActionResult getPrenom(int id)
        {
            IPersonnelService pers = new PersonnelService();


            string objcity = pers.findPrenomByNom(id);

            return Json(objcity);
        }
        [HttpPost]

        public ActionResult GenerateCABien()
        {
            IBienService kk55 = new BienService();

            double maxj = kk55.FindMaxIDBien();
            maxj = maxj + 1;
            double jj = 1500000000000;

            double kk = jj + maxj;


            return Json(kk);
        }
        public ActionResult GenerateCABureau()
        {
            IBureauService kk55 = new BureauService();

            double maxj = kk55.FindMaxIDBureau();
            maxj = maxj + 1;
            double jj = 2500000000000;

            double kk = jj + maxj;


            return Json(kk);
        }
    }
}
