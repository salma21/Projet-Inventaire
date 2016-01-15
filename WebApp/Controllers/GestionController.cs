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
        // GET: Gestion
        public ActionResult Index()
        {
          
            return View();
        }
        public ActionResult GetBatiment()
        {
            var bat = batiment.GetBatiments();
            return View(bat);
        }
        public ActionResult CreateBatiment()
        {
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

        public ActionResult EditBatiment(int id )
        {
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
            try
            {
                var bat = batiment.FindBatimentByID(reg.idBatiment);
            //var bat2 = BissInventaireEntities.Instance.Batiment.Find(reg.idBatiment);
            batiment.UpdateBatimentDetached(reg);
                batiment.SaveBatiment();

                return RedirectToAction("GetBatiment");
        }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
    }

}

        public ActionResult EditDelegation(int id)
         {
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

        public ActionResult EditDirection(int id)
        {
            var bat = BissInventaireEntities.Instance.Direction.Find(id);
          
            return View(bat);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditDirection(Direction reg)
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
        public ActionResult GetFournisseur()
        {
            var bat = four.GetFournisseurs();
            return View(bat);
        }
        public ActionResult CreateFournisseur()
        {
            
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

        public ActionResult EditFournisseur(int id)
        {
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

        public ActionResult GetParcAuto()
        {
            var bat = parc.GetParc_autos();
            return View(bat);
        }
        public ActionResult CreateParcAuto()
        {
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


        public ActionResult EditParcAuto(int id)
        {

            var par = parc.FindParcByID(id);
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "code");
        
            ViewData["delegations"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");

            return View(par);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditParcAuto(Parc_auto reg)
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
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult GetRegion()
        {
           

                var region = db.GetRegionx();            return View(region);
        }

        // GET: Gestion/Details/5
       

        // GET: Gestion/Create
        public ActionResult CreateRegion()
        {
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList() ,"idPays", "libelle");
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateRegion(Region reg)
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
        public ActionResult EditRegion(int id)
        {
            var reg = db.FindRegByID(id);
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            return View(reg);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditRegion(Region reg)
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

        public ActionResult GetBiens()
        {
         
            var bien = BissInventaireEntities.Instance.Bien.ToList();
          
            
              
                return View(bien.ToList())
                    ;
            }
        

        // GET: Gestion/Details/5


        // GET: Gestion/Create
        //public ActionResult CreateBiens()
        //{
        //    ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
        //    return View();
        //}

        //// POST: Gestion/Create
        //[HttpPost]
        //public ActionResult CreateBiens(AtbDataTest reg)
        //{
        //    try
        //    {
        //        BissInventaireEntities.Instance.AtbDataTest.Add(reg);
        //        BissInventaireEntities.Instance.SaveChanges();
        //        return RedirectToAction("GetRegion");
        //    }
        //    catch (Exception ex)
        //    {
        //        LogThread.WriteLine(ex.Message);
        //        return RedirectToAction("Index", "Error");
        //    }
        //}

        // GET: Gestion/Details/5


        // GET: Gestion/Create

        private IGouvernoratService db1 = new GouvernoratService();
        // GET: Gestion
        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult GetGouvernorat()
        {
            var gouvernorat = db1.GetGouvernorat(); return View(gouvernorat);
        }

        // GET: Gestion/Details/5
        public ActionResult Details1(int id)
        {
            return View();
        }

      
        public ActionResult CreateGouvernorat()
        {
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateGouvernorat(Gouvernorat gouv)
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

        public ActionResult CreateGouvernorat1()
        {
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateGouvernorat1(Gouvernorat gouv)
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
        public ActionResult EditGouvernorat(int id)
        {
            var gouv = db1.FindGouvByID(id);
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            return View(gouv);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditGouvernorat(Gouvernorat gouv)
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


        //Delegation

        private IDelegationService db2 = new DelegationService();
        // GET: Gestion
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult GetDelegation()
        {
            var delegation = db2.GetDelegation(); return View(delegation);
        }

        // GET: Gestion/Details/5
        public ActionResult Details2(int id)
        {
            return View();
        }

        // GET: Gestion/Create
        public ActionResult CreateDelegation()
        {

            ViewData["gouvernorat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateDelegation(Delegation deleg)
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



        //Organisation

        private IOrganisationService db3 = new OrganisationService();
        // GET: Gestion
        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult GetOrganisation()
        {
            var organisation = db3.GetOrganisation(); return View(organisation);
        }

        // GET: Gestion/Details/5
        public ActionResult Details3(int id)
        {
            return View();
        }

        // GET: Gestion/Create
        public ActionResult CreateOrganisation()
        {

            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateOrganisation(Organisation org)
        {
            try
            {
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
        public ActionResult EditOrganisation(int id)
        {
            var org = BissInventaireEntities.Instance.Organisation.Find(id);

            return View(org);
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult EditOrganisation(Organisation org)
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



        //Pays


        private IPaysService db4 = new PaysService();
        // GET: Gestion
        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult GetPays()
        {
            var pays = db4.GetPays(); return View(pays);
        }

        // GET: Gestion/Details/5
        public ActionResult Details4(int id)
        {
            return View();
        }

        // GET: Gestion/Create
        public ActionResult CreatePays()
        {

            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreatePays(Pays pay)
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


        //Direction


        private IDirectionService db5 = new DirectionService();
        // GET: Gestion
        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult GetDirection()
        {
            var direction = db5.GetDirection(); return View(direction);
        }

        // GET: Gestion/Details/5
        public ActionResult Details5(int id)
        {
            return View();
        }

        // GET: Gestion/Create
        public ActionResult CreateDirection()
        {

            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateDirection(Direction direction)
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
        public ActionResult GetEtage()
        {
            var etg = con.Etage.ToList();
            return View(etg);
        }

        public ActionResult CreateEtage()
        {
            ViewData["pays"] = new SelectList(BissInventaireEntities.Instance.Pays.ToList(), "idPays", "libelle");
            ViewData["region"] = new SelectList(BissInventaireEntities.Instance.Region.ToList(), "idRegion", "libelle");
            ViewData["gouvernorat"] = new SelectList(BissInventaireEntities.Instance.Gouvernorat.ToList(), "idGouvernorat", "libelle");
            ViewData["organisation"] = new SelectList(BissInventaireEntities.Instance.Organisation.ToList(), "idOrganisation", "libelle");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");

            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult CreateEtage(Etage etg)
        {
            try
            {
                BissInventaireEntities.Instance.Etage.Add(etg);
                BissInventaireEntities.Instance.SaveChanges();
                return RedirectToAction("GetEtage");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult EditEtage(int id)
        {

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

        public ActionResult Getmateriel()
        {
            var mat = con.Categorie_materiel.ToList();
            return View(mat);
        }

        public ActionResult Createmateriel()
        {
            return View();
        }

        // POST: Gestion/Create
        [HttpPost]
        public ActionResult Createmateriel(Categorie_materiel reg)
        {
            try
            {
                BissInventaireEntities.Instance.Categorie_materiel.Add(reg);
                BissInventaireEntities.Instance.SaveChanges();
                return RedirectToAction("Getmateriel");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        //Vehicule

        private IVehiculeService db6 = new VehiculeService();
        // GET: Vehicule
        public ActionResult Index6()
        {
            return View();
        }

        public ActionResult GetVehicule()
        {
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

            ViewData["parc"] = new SelectList(BissInventaireEntities.Instance.Parc_auto.ToList(), "Id_parc", "Libelle");
            ViewData["garanti"] = new SelectList(BissInventaireEntities.Instance.Contrat_garanti.ToList(), "Id_contrat_garanti", "Num");
            ViewData["assurance"] = new SelectList(BissInventaireEntities.Instance.Contrat_assurance.ToList(), "Id_contrat_assurance", "Num");
            ViewData["maintenance"] = new SelectList(BissInventaireEntities.Instance.Contrat_maintenance.ToList(), "Id_contrat_maintenance", "Num");
            ViewData["achat"] = new SelectList(BissInventaireEntities.Instance.Achat.ToList(), "Id_achat", "Num_facture");


            return View();
        }

        // POST: Vehicule/Create
        [HttpPost]
        public ActionResult CreateVehicule(Vehicule veh, FormCollection collection)
        {
            int idfournisseur = db6.FindFournisseurByContratGaranti((int)veh.Id_contrat_garanti);
            int idSocM = db6.FindSocieteMaintenanceByContratMaintenance((int)veh.Id_contrat_maintenance);
            int idSocA = db6.FindSocieteAssuranceByContratAssurance((int)veh.Id_contrat_assurance);
            int idBat = db6.FindBatimentByParcAuto(veh.Id_parc);
            var ac = BissInventaireEntities.Instance.Achat.Find(veh.Id_achat);

            veh.Prix_d_achat = ac.Prix_d_achat;
         
            veh.Id_societe_maintenance = idSocM;
            veh.Id_societe_assurance = idSocA;
            veh.idBatiment = idBat;

            try
            {
                BissInventaireEntities.Instance.Vehicule.Add(veh);
                BissInventaireEntities.Instance.SaveChanges();
                return RedirectToAction("GetVehicule");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }
         

        //MouvementVehicule

        private IMouvementVService db7 = new MouvementVService();
        // GET: Mouvement
        public ActionResult Index7()
        {
            return View();
        }

        public ActionResult GetMouvement()
        {
            var Mouvement = db7.GetMouvementVehicules();
            return View(Mouvement);
        }
        // GET: Vehicule/Details/6
        public ActionResult Details7(int id)
        {
            try
            {

                var archive = BissInventaireEntities.Instance.MouvementV.Find(id);

                return View(archive);
            }
            catch (Exception ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }

        // GET: Mouvement/Create
        public ActionResult CreateMouvementV()
        {


            
            ViewData["batiment"] = new SelectList(BissInventaireEntities.Instance.Batiment.ToList(), "idBatiment", "description");
            ViewData["vehicule"] = new SelectList(BissInventaireEntities.Instance.Vehicule.ToList(), "Id_Vehicule", "Matricule");
            ViewData["delegation"] = new SelectList(BissInventaireEntities.Instance.Delegation.ToList(), "idDelegation", "libelle");
            ViewData["parc"] = new SelectList(BissInventaireEntities.Instance.Parc_auto.ToList(), "Id_parc", "Libelle");
          
            return View();
        }

        // POST: Mouvement/Create
        [HttpPost]
        public ActionResult CreateMouvementV(MouvementV mouv, FormCollection collection)
        {

            try
            {
                db7.CreateMouvementV(mouv);
            db7.SaveMouvementV();
                //BissInventaireEntities.Instance.MouvementV.Add(mouv);
                //BissInventaireEntities.Instance.SaveChanges();
               return RedirectToAction("CreateOrganisation");
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

        [HttpPost]
        public ActionResult GetBatimentByDelegation(int delegid)
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
        //[HttpPost]
        //public ActionResult GetProduitByCAt(int stateid)
        //{
        //    IBatimentService bat = new BatimentService();
        //    List<CategorieDesignation> objcity = new List<CategorieDesignation>();

        //    objcity = bien.FindPorduitByID(stateid).ToList();

        //    SelectList obgcity = new SelectList(objcity, "libelle", "libelle", 0);
        //    return Json(obgcity);
        //}

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
        public ActionResult GetDelegationByGouvernorat(int stateid)
        {
            IDelegationService bat = new DelegationService();
            List<Delegation> objcity = new List<Delegation>();

            objcity = bat.FindDelegationtByGouvernerat(stateid).ToList();

            SelectList obgcity = new SelectList(objcity, "idDelegation", "libelle", 0);
            return Json(obgcity);
        }
        // POST: TPE/Create

    }

}
