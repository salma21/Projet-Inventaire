using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GestionContratetSocService : IGestionContratetSocService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public GestionContratetSocService() { }

        //public IEnumerable<Contrat_maintenance> GetContrat_maintenances()
        //{
        //    var dep = utOfWork.ContratMaintennaceRepository.GetAll();
        //    return dep;
        //}
        //public IEnumerable<Contrat_garanti> GetContrat_garantis()
        //{
        //    var dep = utOfWork.ContratGarantieRepository.GetAll();
        //    return dep;
        //}
        //public IEnumerable<Contrat_assurance> GetContrat_assurances()
        //{
        //    var dep = utOfWork.ContratAssuranceRepository.GetAll();
        //    return dep;
        //}
        //public IEnumerable<Societe_maintenance> GetSociete_maintenances()
        //{
        //    var dep = utOfWork.SocieteMaintenanceRepository.GetAll();
        //    return dep;
        //}
        //public IEnumerable<Societe_assurance> GetSociete_assurances()
        //{
        //    var dep = utOfWork.SocieteAssuranceRepository.GetAll();
        //    return dep;
        //}
        //public IEnumerable<Achat> GetAchat()
        //{
        //    var dep = utOfWork.AchatRepository.GetAll();
        //    return dep;
        //}

        public Societe_maintenance FindSocMainByID(int id)

        {
            var Dept = utOfWork.SocieteMaintenanceRepository.FindSocByID(id);
            return Dept;
        }

        public Societe_assurance FindSocAssByID(int id)

        {
            var Dept = utOfWork.SocieteAssuranceRepository.FindSocByID(id);
            return Dept;
        }

        public Contrat_assurance FindContrat_assuranceByID(int id)

        {
            var Dept = utOfWork.ContratAssuranceRepository.FindContrat_assuranceByID(id);
            return Dept;
        }




        public void SaveChange()
        {
            utOfWork.Commit();
        }
        public void UpdateAchatDetached(Achat e)
        {
            utOfWork.AchatRepository.UpdateAchatDetached(e);
        }



        public void UpdateContrat_assuranceDetached(Contrat_assurance e)
        {
            utOfWork.ContratAssuranceRepository.UpdateCont_AssuranceDetached(e);
        }
        
    }
    public interface IGestionContratetSocService
    {
        Societe_maintenance FindSocMainByID(int id);
        Contrat_assurance FindContrat_assuranceByID(int id);
        Societe_assurance FindSocAssByID(int id);
        void UpdateAchatDetached(Achat e);
        void UpdateContrat_assuranceDetached(Contrat_assurance e);
        void SaveChange();
     }

}


