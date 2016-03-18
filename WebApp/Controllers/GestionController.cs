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
    public class GestionController : Controller
    {
        private IRegionService db = new RegionService();
        private IEtageService etage = new EtageService();
        private IBatimentService batiment = new BatimentService();
        private IFournisseurService four = new FournisseurService();
        private BissInventaireEntities con = new BissInventaireEntities();
        private IServiceEtPArcAutoService parc = new ServiceEtPArcAutoService();
        //private IBiensService bien = new BiensService();
        private IDirectionService dir = new DirectionService();
        private IDelegationService del = new DelegationService();
        private IOrganisationService orga = new OrganisationService();
        private IVehiculeService vs = new VehiculeService();
        private IBureauService br = new BureauService();

        public bool etat = false;
        // GET: Gestion
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult GetBatiment()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            GetOrganisation();
            GetDelegation();
            var bat = batiment.GetBatiments();
            return View(bat);
        }
        public ActionResult CreateBatiment()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["gouv"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["organisation"] = new SelectList(BissInventaireEntities.Instance.Organisation.ToList(), "idOrganisation", "libelle");
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateBatiment(Batiment reg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    batiment.CreateBatiment(reg);
                    batiment.SaveBatiment();

                    return RedirectToAction("GetBatiment");
            }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {

                ViewData["gouv"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
                ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                ViewData["organisation"] = new SelectList(BissInventaireEntities.Instance.Organisation.ToList(), "idOrganisation", "libelle");

                return View();
            }
        }

        public ActionResult EditBatiment(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var bat = batiment.FindBatimentByID(id);
            ViewData["gouv"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["organisation"] = new SelectList(BissInventaireEntities.Instance.Organisation.ToList(), "idOrganisation", "libelle");
            return View(bat);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditBatiment(Batiment reg)
        {
            if (ModelState.IsValid)
            {
                //try
                //{
                    var bat = batiment.FindBatimentByID(reg.idBatiment);
                    //var bat2 = BissInventaireEntities.Instance.Batiment.Find(reg.idBatiment);
                    batiment.UpdateBatimentDetached(reg);
                    batiment.SaveBatiment();

                    return RedirectToAction("GetBatiment");
                }
            //    catch (Exception ex)
            //    {
            //        LogThread.WriteLine(ex.Message);
            //        return RedirectToAction("Index", "Error");
            //    }

            //}
            else

            {
                //  ViewBag.msg = "Verifier l code postal";
                ViewData["gouv"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
                ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                ViewData["organisation"] = new SelectList(BissInventaireEntities.Instance.Organisation.ToList(), "idOrganisation", "libelle");

                return View();
            }
        }

        public ActionResult EditDelegation(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var bat = del.FindDelByID(id);
            ViewData["gouvernorat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            return View(bat);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditDelegation(Delegation reg)
        {
            var bat = del.FindDelByID(reg.idDelegation);

            if (ModelState.IsValid)
            {
                try
                {
                    del.UpdateDelegationDetached(reg);
                    del.SaveDelegation();

                    return RedirectToAction("GetDelegation");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                //  ViewBag.msg = "Verifier l code postal";
                ViewData["gouvernorat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");

                return View();
            }
        }


        public ActionResult EditDirection(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var bat = BissInventaireEntities.Instance.Direction.Find(id);

            return View(bat);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditDirection(Direction reg)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    dir.UpdateDirectionDetached(reg);
                    dir.SaveDirection();

                    return RedirectToAction("GetDirection");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }

            }
            else

            {
                return View();
            }
        }
        public ActionResult GetFournisseur()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var bat = four.GetFournisseurs();
            return View(bat);
        }
        public ActionResult CreateFournisseur()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["gouv"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");

            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateFournisseur(Fournisseur reg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    four.CreateFournisseur(reg);
                    four.SaveFournisseur();

                    return RedirectToAction("GetFournisseur");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                ViewData["gouv"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
                ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                return View();
            }
        }

        public ActionResult EditFournisseur(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var fours = four.FindFourByID(id);
            ViewData["gouv"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");

            return View(fours);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditFournisseur(Fournisseur reg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    four.UpdateFournisseurDetached(reg);
                    four.SaveFournisseur();

                    return RedirectToAction("GetFournisseur");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                ViewData["gouv"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
                ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                return View();
            }
        }

        public ActionResult GetParcAuto()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var bat = parc.GetParc_autos();
            return View(bat);
        }
        public ActionResult CreateParcAuto()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "code");
            ViewData["organisation"] = new SelectList(BissInventaireEntities.Instance.Organisation.ToList(), "idOrganisation", "libelle");
            ViewData["gouv"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");

            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateParcAuto(Parc_auto reg)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    parc.CreateParc_auto(reg);
                    parc.SaveParc_auto();

                    return RedirectToAction("GetParcAuto");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }

            }
            else

            {
                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "code");
                ViewData["organisation"] = new SelectList(BissInventaireEntities.Instance.Organisation.ToList(), "idOrganisation", "libelle");
                ViewData["gouv"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
                ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                return View();
            }
        }


        public ActionResult EditParcAuto(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var par = parc.FindParcByID(id);
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "code");

            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");

            return View(par);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditParcAuto(Parc_auto reg)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    parc.UpdateParc_autoDetached(reg);
                    parc.SaveParc_auto();

                    return RedirectToAction("GetParcAuto");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }

            }
            else

            {
                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "code");

                ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }
        public ActionResult GetRegion()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }

            var region = db.GetRegionx(); return View(region);
        }

        // GET: Gestion/Details/5


        // GET: Gestion/Create
        public ActionResult CreateRegion()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateRegion(Region reg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Region.Add(reg);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetRegion");
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
                return View();
            }
        }
        public ActionResult EditRegion(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var reg = db.FindRegByID(id);
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            return View(reg);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditRegion(Region reg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.UpdateRegionDetached(reg);
                    db.SaveRegion();
                    return RedirectToAction("GetRegion");
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
                return View();
            }
        }
        public ActionResult GetBiens()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var bien = BissInventaireEntities.Instance.Bien.ToList();



            return View(bien.ToList())
                ;
        }




        // GET: Gestion/Create

        private IGouvernoratService db1 = new GouvernoratService();
        // GET: Gestion
        public ActionResult Index1()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        public ActionResult GetGouvernorat()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var gouvernorat = db1.GetGouvernorat(); return View(gouvernorat);
        }

        // GET: Gestion/Details/5
        public ActionResult Details1(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }


        public ActionResult CreateGouvernorat()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateGouvernorat(Gouvernorat gouv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Gouvernorat.Add(gouv);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetGouvernorat");
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
                return View();
            }
        }

        public ActionResult CreateGouvernorat1()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateGouvernorat1(Gouvernorat gouv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Gouvernorat.Add(gouv);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetGouvernorat1");
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
                return View();
            }
        }
        public ActionResult EditGouvernorat(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var gouv = db1.FindGouvByID(id);
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            return View(gouv);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditGouvernorat(Gouvernorat gouv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db1.UpdateGouvernoratDetached(gouv);
                    db1.SaveGouvernorat();
                    return RedirectToAction("GetGouvernorat");
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
                return View();
            }
        }

        //Delegation

        private IDelegationService db2 = new DelegationService();
        // GET: Gestion
        public ActionResult Index2()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        public ActionResult GetDelegation()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var delegation = db2.GetDelegation(); return View(delegation);
        }

        // GET: Gestion/Details/5
        public ActionResult Details2(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        // GET: Gestion/Create
        public ActionResult CreateDelegation()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["gouvernorat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateDelegation(Delegation deleg)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    BissInventaireEntities.Instance.Delegation.Add(deleg);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetDelegation");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }

            }

            else

            {
                //  ViewBag.msg = "Verifier l code postal";
                ViewData["gouvernorat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");

                return View();
            }
        }




        //Organisation

        private IOrganisationService db3 = new OrganisationService();
        // GET: Gestion
        public ActionResult Index3()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        public ActionResult GetOrganisation()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var organisation = db3.GetOrganisation(); return View(organisation);
        }

        public byte[] GetImageFromDataBase(int Id)
        {
            var q = from temp in BissInventaireEntities.Instance.Organisation where temp.idOrganisation == Id select temp.Logo;
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

        // GET: Gestion/Details/5
        public ActionResult Details3(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        // GET: Gestion/Create
        public ActionResult CreateOrganisation()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "libelle", "libelle");
            ViewData["gouvernourat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");

            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateOrganisation(Organisation org, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HttpPostedFileBase file1 = Request.Files["Image"];
                    org.Logo = ConvertToBytes(file1);
                    var logo = org.Logo;
                    BissInventaireEntities.Instance.Organisation.Add(org);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetOrganisation");
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
                ViewData["gouvernourat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                return View();
            }
        }


        public byte[] ConvertToBytes(HttpPostedFileBase logo)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(logo.InputStream);
            imageBytes = reader.ReadBytes((int)logo.ContentLength);
            return imageBytes;
        }
        public ActionResult EditOrganisation(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var org = BissInventaireEntities.Instance.Organisation.Find(id);
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "libelle", "libelle");
            ViewData["gouvernourat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            return View(org);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditOrganisation(Organisation org)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db3.UpdateOrganisationDetached(org);
                    db3.SaveOrganisation();
                    return RedirectToAction("GetOrganisation");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "libelle", "libelle");
                ViewData["gouvernourat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                return View();
            }
        }


        //Pays


        private IPaysService db4 = new PaysService();
        // GET: Gestion
        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult GetPays()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var pays = db4.GetPays(); return View(pays);
        }

        // GET: Gestion/Details/5
        public ActionResult Details4(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        // GET: Gestion/Create
        public ActionResult CreatePays()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreatePays(Pays pay)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Pays.Add(pay);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetPays");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {

                return View();
            }
        }

        //Direction


        private IDirectionService db5 = new DirectionService();
        // GET: Gestion
        public ActionResult Index5()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        public ActionResult GetDirection()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var direction = db5.GetDirection(); return View(direction);
        }

        // GET: Gestion/Details/5
        public ActionResult Details5(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        // GET: Gestion/Create
        public ActionResult CreateDirection()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }

            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateDirection(Direction direction)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Direction.Add(direction);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetDirection");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {

                return View();
            }
        }
        public ActionResult GetEtage()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var etg = con.Etage.ToList();
            return View(etg);
        }

        public ActionResult CreateEtage()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["gouvernorat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["organisation"] = new SelectList(BissInventaireEntities.Instance.Organisation.ToList(), "idOrganisation", "libelle");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");

            return View();
        }


        //employer user = BissInventaireEntities.Instance.employers.FirstOrDefault(u => u.identifiant.ToLower() == e.identifiant.ToLower());
        //    if (user == null) {
        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateEtage(Etage etg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    if(etat)
                    {
                        BissInventaireEntities.Instance.Etage.Add(etg);
                        BissInventaireEntities.Instance.SaveChanges();
                        return RedirectToAction("GetEtage");
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
                ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
                ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
                ViewData["gouvernorat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
                ViewData["organisation"] = new SelectList(BissInventaireEntities.Instance.Organisation.ToList(), "idOrganisation", "libelle");
                ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
                return View();
            }
        }
        public string OpenPopup()
        {
            Etage etg = new Etage();
            var user = BissInventaireEntities.Instance.Etage.FirstOrDefault(u => u.code.ToLower() == etg.code.ToLower());
            if (user == null)
            {
                etat = true;
            }
            
            return "<h1> Ce code existe déja !!</h1>";
            
           
        }
        public ActionResult EditEtage(int id)
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var eta = etage.FindEtageByID(id);
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["gouvernorat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["organisation"] = new SelectList(BissInventaireEntities.Instance.Organisation.ToList(), "idOrganisation", "libelle");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");

            return View(eta);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditEtage(Etage etg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    etage.UpdateEtageDetached(etg);
                    etage.SaveEtage();
                    return RedirectToAction("GetEtage");
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
                return View();
            }
        }
        public ActionResult Getmateriel()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var mat = con.Categorie.ToList();
            return View(mat);
        }

        public ActionResult Createmateriel()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult Createmateriel(Categorie reg)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BissInventaireEntities.Instance.Categorie.Add(reg);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("Getmateriel");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {

                return View();
            }
        }
        //Vehicule

        private IVehiculeService db6 = new VehiculeService();
        // GET: Vehicule
        public ActionResult Index6()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        public ActionResult GetVehicule()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            GetParcAuto();
            var Vehicule = db6.GetVehicules();
            return View(Vehicule);
        }
        // GET: Vehicule/Details/6
        public ActionResult Details6(int id)
        {
            try
            {

                var archive = BissInventaireEntities.Instance.Vehicule.Find(id);

                return View(archive);
            }
            catch (Exception ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }

        // GET: Vehicule/Create
        public ActionResult CreateVehicule()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }

            ViewData["parc"] = new SelectList(BissInventaireEntities.Instance.Parc_auto.ToList(), "Id_parc", "Libelle");

            ViewData["maintenance"] = new SelectList(BissInventaireEntities.Instance.Contrat.ToList(), "Id_contrat", "Num");
            ViewData["achat"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_facture");


            return View();
        }

        // POST: Vehicule/Create
        [HttpPost]
        public ActionResult CreateVehicule(Vehicule veh, FormCollection collection)
        {
            //int idfournisseur = db6.FindFournisseurByContrat((int)veh.Id_contrat);

            int idBat = db6.FindBatimentByParcAuto(veh.Id_parc);
            var ac = BissInventaireEntities.Instance.Achat.Find(veh.Id_achat);

            //veh.Prix_d_achat = (double)ac.Prix_d_achat;

            veh.idBatiment = idBat;

            if (ModelState.IsValid)
            {

                try
                {
                    BissInventaireEntities.Instance.Vehicule.Add(veh);
                    BissInventaireEntities.Instance.SaveChanges();
                    var Emp = (Utilisateur)Session["identifiant"];
                    Trace tr = new Trace();
                    tr.Dates = DateTime.Now;
                    tr.Actions = "Ajouter une Véhicule";
                    tr.Champs = veh.Matricule;
                    tr.Tables = "Vehicule";
                    tr.Users = (Emp.Personnel.Matricule).ToString();
                    BissInventaireEntities.Instance.Trace.Add(tr);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetVehicule");
                }
                catch (Exception ex)
                {
                    LogThread.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Error");
                }
            }
            else

            {
                ViewData["parc"] = new SelectList(BissInventaireEntities.Instance.Parc_auto.ToList(), "Id_parc", "Libelle");

                ViewData["maintenance"] = new SelectList(BissInventaireEntities.Instance.Contrat.ToList(), "Id_contrat", "Num");
                ViewData["achat"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_facture");
                return View();
            }
        }

        public ActionResult EditVehicule(int id)
        {


            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var vehi = vs.findVehiculeByID(id);

            ViewData["parc"] = new SelectList(BissInventaireEntities.Instance.Parc_auto.ToList(), "Id_parc", "Libelle");

            ViewData["maintenance"] = new SelectList(BissInventaireEntities.Instance.Contrat.ToList(), "Id_contrat", "Num");
            ViewData["achat"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_facture");
            return View(vehi);
            
        }

        [HttpPost]
        public ActionResult EditVehicule(Vehicule vehi)
        {
           
            if (ModelState.IsValid)
            {
                //try
                //{
                    int idBat = db6.FindBatimentByParcAuto(vehi.Id_parc);
                    var ac = BissInventaireEntities.Instance.Achat.Find(vehi.Id_achat);



                    vehi.idBatiment = idBat;
                    var bat = vs.findVehiculeByID(vehi.Id_Vehicule);

                    vs.UpdateVehiculeDetached(vehi);
                    vs.SaveVehicule();

                    return RedirectToAction("GetVehicule");
                //}
                //catch (Exception ex)
                //{
                //    LogThread.WriteLine(ex.Message);
                //    return RedirectToAction("Index", "Error");
                //}
            }
            else

            {
                //  ViewBag.msg = "Verifier l code postal";
                ViewData["parc"] = new SelectList(BissInventaireEntities.Instance.Parc_auto.ToList(), "Id_parc", "Libelle");

                ViewData["maintenance"] = new SelectList(BissInventaireEntities.Instance.Contrat.ToList(), "Id_contrat", "Num");
                ViewData["achat"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_facture");

                return View();
            }
        }

        //[HttpPost]
        //public ActionResult EditVehicule(Vehicule veh)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            IVehiculeService jj = new VehiculeService();
        //            jj.UpdateVehiculeDetached(veh);
        //            jj.SaveVehicule();

        //            return RedirectToAction("GetVehicule");
        //        }
        //        catch (Exception ex)
        //        {
        //            LogThread.WriteLine(ex.Message);
        //            return RedirectToAction("Index", "Error");
        //        }
        //    }
        //    else

        //    {
        //        ViewData["parc"] = new SelectList(BissInventaireEntities.Instance.Parc_auto.ToList(), "Id_parc", "Libelle");

        //        ViewData["maintenance"] = new SelectList(BissInventaireEntities.Instance.Contrat.ToList(), "Id_contrat", "Num");
        //        ViewData["achat"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_facture");
        //        return View();
        //    }
        //}


        //MouvementBien

        private IMouvementBienService db8 = new MouvementBienService();
        // GET: Mouvement
        public ActionResult Index8()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            return View();
        }

        public ActionResult GetMouvementBien()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Mouvement = db8.GetMouvementBiens();
            return View(Mouvement);
        }
        // GET: Vehicule/Details/6
        public ActionResult Details8(int id)
        {
            try
            {

                var archive = BissInventaireEntities.Instance.MouvementBien.Find(id);

                return View(archive);
            }
            catch (Exception ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }

        // GET: Mouvement/Create
        public ActionResult CreateMouvementBien()
        {

            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }

            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            ViewData["etage"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "description");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["bien"] = new SelectList(BissInventaireEntities.Instance.Bien.ToList(), "Id_bien", "Num_serie");

            return View();
        }

        // POST: Mouvement/Create
        [HttpPost]
        public ActionResult CreateMouvementBien(MouvementBien mou, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db8.CreateMouvementBien(mou);
                    db8.SaveMouvementBien();
                    var Emp = (Utilisateur)Session["identifiant"];
                    Trace tr = new Trace();
                    tr.Dates = DateTime.Now;
                    tr.Actions = "Ajout Mouvement Bien";
                    //tr.Champs = (mou.Bien.Code_a_barre).ToString();
                    tr.Tables = "Mouvement Bien";
                    tr.Users = (Emp.Personnel.Matricule).ToString();
                    BissInventaireEntities.Instance.Trace.Add(tr);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetMouvementBien");
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
                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
                ViewData["etage"] = new SelectList(BissInventaireEntities.Instance.Etage.ToList(), "Id_etage", "description");
                ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                ViewData["bien"] = new SelectList(BissInventaireEntities.Instance.Bien.ToList(), "Id_bien", "Num_serie");

                return View();
            }
        }

        [HttpPost]
        public ActionResult FindBatimentByDelegation(int delegid)
        {
            List<Batiment> objcity = new List<Batiment>();
            objcity = db8.FindBatimentByDelegation(delegid).ToList();

            SelectList obgcity = new SelectList(objcity, "idBatiment", "description", 0);
            return Json(obgcity);
        }


        [HttpPost]
        public ActionResult GetEtageByBatiment(int batid)
        {
            List<Etage> objcity = new List<Etage>();
            objcity = db8.FindEtageByBatiment(batid).ToList();

            SelectList obgcity = new SelectList(objcity, "Id_etage", "description", 0);
            return Json(obgcity);
        }

        //[HttpPost]
        //public ActionResult GetBureauByEtage(int batid)
        //{
        //    List<Bureau> objcity = new List<Bureau>();
        //    objcity = db8.FindBureauByEtage(burid).ToList();

        //    SelectList obgcity = new SelectList(objcity, "Id_bureau", "Description", 0);
        //    return Json(obgcity);
        //}

        [HttpPost]
        public ActionResult FindBienByEtage(int etid)
        {
            List<Bien> objcity = new List<Bien>();
            objcity = db8.FindBienByEtage(etid).ToList();

            SelectList obgcity = new SelectList(objcity, "Id_bien", "Num_serie", 0);
            return Json(obgcity);
        }




        //MouvementVehicule

        private IMouvementVehiculeService db7 = new MouvementVehiculeService();
        // GET: Mouvement
        public ActionResult Index7()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            else {
                return View();
            }

        }

        public ActionResult GetMouvementVehicule()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }
            var Mouvement = db7.GetMouvementVehicules();
            return View(Mouvement);
        }
        // GET: Vehicule/Details/6
        public ActionResult Details7(int id)
        {
            try
            {

                var archive = BissInventaireEntities.Instance.MouvementVehicule.Find(id);

                return View(archive);
            }
            catch (Exception ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }

        // GET: Mouvement/Create
        public ActionResult CreateMouvementVehicule()
        {
            if (Session["identifiant"] == null)
            { return RedirectToAction("Index", "Home"); }


            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            ViewData["vehicule"] = new SelectList(BissInventaireEntities.Instance.Vehicule.ToList(), "Id_Vehicule", "Matricule");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["parc"] = new SelectList(BissInventaireEntities.Instance.Parc_auto.ToList(), "Id_parc", "Libelle");

            return View();
        }

        // POST: Mouvement/Create
        [HttpPost]
        public ActionResult CreateMouvementVehicule(MouvementVehicule mouv, FormCollection collection)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    db7.CreateMouvementVehicule(mouv);
                    db7.SaveMouvementVehicule();

                    var Emp = (Utilisateur)Session["identifiant"];
                    Trace tr = new Trace();
                    tr.Dates = DateTime.Now;
                    tr.Actions = "Ajout Mouvement Véhicule";
                    tr.Champs = (mouv.Vehicule.Matricule).ToString();
                    tr.Tables = "Mouvement Vehicule";
                    tr.Users = (Emp.Personnel.Matricule).ToString();
                    BissInventaireEntities.Instance.Trace.Add(tr);
                    BissInventaireEntities.Instance.SaveChanges();
                    return RedirectToAction("GetMouvementVehicule");
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
                ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
                ViewData["vehicule"] = new SelectList(BissInventaireEntities.Instance.Vehicule.ToList(), "Id_Vehicule", "Matricule");
                ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
                ViewData["parc"] = new SelectList(BissInventaireEntities.Instance.Parc_auto.ToList(), "Id_parc", "Libelle");

                return View();
            }
        }
        [HttpPost]
        public ActionResult getBatimentByDelegation(int delegid)
        {
            List<Batiment> objcity = new List<Batiment>();
            objcity = db7.FindBatimentByDelegation(delegid).ToList();

            SelectList obgcity = new SelectList(objcity, "idBatiment", "description", 0);
            return Json(obgcity);
        }

        [HttpPost]
        public ActionResult GetParcByBatiment(int batid)
        {
            List<Parc_auto> objcity = new List<Parc_auto>(); objcity = db7.FindParcByBatiment(batid).ToList();

            SelectList obgcity = new SelectList(objcity, "Id_parc", "Libelle", 0);
            return Json(obgcity);
        }

        [HttpPost]
        public ActionResult GetVehiculeByParc(int parcid)
        {
            List<Vehicule> objcity = new List<Vehicule>(); objcity = db7.FindVehiculeByParc(parcid).ToList();

            SelectList obgcity = new SelectList(objcity, "Id_Vehicule", "Matricule", 0);
            return Json(obgcity);
        }


        [HttpPost]
        public ActionResult GetRegionByPays(int stateid)
        {
            List<Region> objcity = new List<Region>();

            objcity = db.FindRegByIDPays(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "idRegion", "libelle", 0);
            return Json(obgcity);
        }

        [HttpPost]
        public ActionResult GetBatiemntByDelegation(int stateid)
        {
            IBatimentService bat = new BatimentService();
            List<Batiment> objcity = new List<Batiment>();

            objcity = bat.FindBatimentByDelgation(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "idBatiment", "description", 0);
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
        public ActionResult GetDelegationByGouvernorat(string libelle)
        {
            IDelegationService bat = new DelegationService();
            List<Delegation> objcity = new List<Delegation>();

            objcity = bat.findDelegationtByGouvernerat(libelle).ToList();

            SelectList obgcity = new SelectList(objcity, "libelle", "libelle", 0);
            return Json(obgcity);
        }
        [HttpPost]
        public ActionResult findDelegationByGouvernorat(int stateid)
       {
            IDelegationService bat = new DelegationService();
            List<Delegation> objcity = new List<Delegation>();

            objcity = bat.FindDelegationtByGouvernerat(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "idDelegation", "libelle", 0);
            return Json(obgcity);
        }


    }



}
