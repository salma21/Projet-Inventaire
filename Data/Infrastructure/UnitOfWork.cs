

using Data.Repositories;
using Domain;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public BissInventaireEntities dataContext;
        DatabaseFactory dbFactory;
        public UnitOfWork(DatabaseFactory dbFactory)
        {

            this.dbFactory = dbFactory;




        }

        private IUserRepository UserRepository;
        IUserRepository IUnitOfWork.UserRepository
        {
            get
            {
                return UserRepository ?? (UserRepository = new UserRepository(dbFactory));
            }
        }

        private IAchatRepository AchatRepository;
        IAchatRepository IUnitOfWork.AchatRepository
        {
            get
            {
                return AchatRepository ?? (AchatRepository = new AchatRepository(dbFactory));
            }
        }


    

        private IBureauRepository BureauRepository;
        IBureauRepository IUnitOfWork.BureauRepository
        {
            get
            {
                return BureauRepository ?? (BureauRepository = new BureauRepository(dbFactory));
            }
        }

        private IMouvementBRepository MouvementBRepository;
        IMouvementBRepository IUnitOfWork.MouvementBRepository
        {
            get
            {
                return MouvementBRepository ?? (MouvementBRepository = new MouvementBRepository(dbFactory));
            }
        }

        private IMouvementVRepository MouvementVRepository;
        IMouvementVRepository IUnitOfWork.MouvementVRepository
        {
            get
            {
                return MouvementVRepository ?? (MouvementVRepository = new MouvementVRepository(dbFactory));
            }
        }


        private IVehiculeRepository VehiculeRepository;
        IVehiculeRepository IUnitOfWork.VehiculeRepository
        {
            get
            {
                return VehiculeRepository ?? (VehiculeRepository = new VehiculeRepository(dbFactory));
            }
        }
        private IRegionRepository RegionRepository;
        IRegionRepository IUnitOfWork.RegionRepository
        {
            get
            {
                return RegionRepository ?? (RegionRepository = new RegionRepository(dbFactory));
            }
        }

        private IContratAssuranceRepository ContratAssuranceRepository;
        IContratAssuranceRepository IUnitOfWork.ContratAssuranceRepository
        {
            get
            {
                return ContratAssuranceRepository ?? (ContratAssuranceRepository = new ContratAssuranceRepository(dbFactory));
            }
        }

        private ISocieteAssuranceRepository SocieteAssuranceRepository;
        ISocieteAssuranceRepository IUnitOfWork.SocieteAssuranceRepository
        {
            get
            {
                return SocieteAssuranceRepository ?? (SocieteAssuranceRepository = new SocieteAssuranceRepository(dbFactory));
            }
        }


        private IContratMaintennaceRepository ContratMaintennaceRepository;
        IContratMaintennaceRepository IUnitOfWork.ContratMaintennaceRepository
        {
            get
            {
                return ContratMaintennaceRepository ?? (ContratMaintennaceRepository = new ContratMaintennaceRepository(dbFactory));
            }
        }

        private IContratGarantieRepository ContratGarantieRepository;
        IContratGarantieRepository IUnitOfWork.ContratGarantieRepository
        {
            get
            {
                return ContratGarantieRepository ?? (ContratGarantieRepository = new ContratGarantieRepository(dbFactory));
            }
        }

        private ISocieteMaintenanceRepository SocieteMaintenanceRepository;
        ISocieteMaintenanceRepository IUnitOfWork.SocieteMaintenanceRepository
        {
            get
            {
                return SocieteMaintenanceRepository ?? (SocieteMaintenanceRepository = new SocieteMaintenanceRepository(dbFactory));
            }
        }


        private IBatimentRepository BatimentRepository;
        IBatimentRepository IUnitOfWork.BatimentRepository
        {
            get
            {
                return BatimentRepository ?? (BatimentRepository = new BatimentRepository(dbFactory));
            }
        }

        private IFournisseurRepository FournisseurRepository;
        IFournisseurRepository IUnitOfWork.FournisseurRepository
        {
            get
            {
                return FournisseurRepository ?? (FournisseurRepository = new FournisseurRepository(dbFactory));
            }
        }

        private IServiceRepository ServiceRepository;
        IServiceRepository IUnitOfWork.ServiceRepository
        {
            get
            {
                return ServiceRepository ?? (ServiceRepository = new ServiceRepository(dbFactory));
            }
        }
        private IParc_autoRepository Parc_autoRepository;
        IParc_autoRepository IUnitOfWork.Parc_autoRepository
        {
            get
            {
                return Parc_autoRepository ?? (Parc_autoRepository = new Parc_autoRepository(dbFactory));
            }
        }

        private IInventaireRepository InventaireRepository;
        IInventaireRepository IUnitOfWork.InventaireRepository
        {
            get
            {
                return InventaireRepository ?? (InventaireRepository = new InventaireRepository(dbFactory));
            }
        }
        //private IBiensRepository BiensRepository;
        //IBiensRepository IUnitOfWork.BiensRepository
        //{
        //    get
        //    {
        //        return BiensRepository ?? (BiensRepository = new BiensRepository(dbFactory));
        //    }
        //}

        private IGouvernoratRepository GouvernoratRepository;
        IGouvernoratRepository IUnitOfWork.GouvernoratRepository
        {
            get
            {
                return GouvernoratRepository ?? (GouvernoratRepository = new GouvernoratRepository(dbFactory));
            }
        }


        private IOrganisationRepository OrganisationRepository;
        IOrganisationRepository IUnitOfWork.OrganisationRepository
        {
            get
            {
                return OrganisationRepository ?? (OrganisationRepository = new OrganisationRepository(dbFactory));
            }
        }

        private IDelegationRepository DelegationRepository;
        IDelegationRepository IUnitOfWork.DelegationRepository
        {
            get
            {
                return DelegationRepository ?? (DelegationRepository = new DelegationRepository(dbFactory));
            }
        }

        private IPaysRepository PaysRepository;
        IPaysRepository IUnitOfWork.PaysRepository
        {
            get
            {
                return PaysRepository ?? (PaysRepository = new PaysRepository(dbFactory));
            }
        }



        private IDirectionRepository DirectionRepository;
        IDirectionRepository IUnitOfWork.DirectionRepository
        {
            get
            {
                return DirectionRepository ?? (DirectionRepository = new DirectionRepository(dbFactory));
            }
        }

        private IUtilisateurRepository UtilisateurRepository;
        IUtilisateurRepository IUnitOfWork.UtilisateurRepository
        {
            get
            {
                return UtilisateurRepository ?? (UtilisateurRepository = new UtilisateurRepository(dbFactory));
            }
        }






        private IPersonnelRepository PeronnelRepository;
        IPersonnelRepository IUnitOfWork.PersonnelRepository
        {
            get
            {
                return PeronnelRepository ?? (PeronnelRepository = new PersonnelRepository(dbFactory));
            }
        }


        private IRoleRepository RoleRepository;
        IRoleRepository IUnitOfWork.RoleRepository
        {
            get
            {
                return RoleRepository ?? (RoleRepository = new RoleRepository(dbFactory));
            }
        }


        private ICategorie_materielRepository Categorie_materielRepository;
        ICategorie_materielRepository IUnitOfWork.Categorie_materielRepository
        {
            get
            {
                return Categorie_materielRepository ?? (Categorie_materielRepository = new Categorie_materielRepository(dbFactory));
            }
        }

        private IServiceDRepository ServiceDRepository;
        IServiceDRepository IUnitOfWork.ServiceDRepository
        {
            get
            {
                return ServiceDRepository ?? (ServiceDRepository = new ServiceDRepository(dbFactory));
            }
        }



        private IEtageRepository EtageRepository;
        IEtageRepository IUnitOfWork.EtageRepository
        {
            get
            {
                return EtageRepository ?? (EtageRepository = new EtageRepository(dbFactory));
            }
        }

        private IInventaireVehRepository InventaireVehRepository;
        IInventaireVehRepository IUnitOfWork.InventaireVehRepository
        {
            get
            {
                return InventaireVehRepository ?? (InventaireVehRepository = new InventaireVehRepository(dbFactory));
            }
        }


        private IInventaireBienRepository InventaireBienRepository;
        IInventaireBienRepository IUnitOfWork.InventaireBienRepository
        {
            get
            {
                return InventaireBienRepository ?? (InventaireBienRepository = new InventaireBienRepository(dbFactory));
            }
        }


        protected BissInventaireEntities DataContext
        {
            get
            {
                return dataContext ?? (dataContext = dbFactory.Get());
            }
        }
        public void Commit()
        {
            DataContext.SaveChanges();
        }
    }
}
