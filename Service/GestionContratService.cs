using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GestionContratService : IGestionContratService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public GestionContratService() { }

      

        public Fournisseur FindFournisseurByID(int id)

        {
            var Dept = utOfWork.FournisseurRepository.FindFournisseurByID(id);
            return Dept;
        }

       

        public Contrat FindContratByID(int id)

        {
            var Dept = utOfWork.ContratRepository.FindContratByID(id);
            return Dept;
        }

        public Contrat_maintenance FindContrat_MaintenanceByID(int id)

        {
            var Dept = utOfWork.ContratMaintennaceRepository.FindContrat_MaintenanceByID(id);
            return Dept;
        }

        //public int FindPaysBySocAssurence(int Id_societe_assurance)
        //{
        //    int Dept = utOfWork.ContratAssuranceRepository.FindPaysBySocAssurence(Id_societe_assurance);
        //    return Dept;
        //}
        //public int FindRegionBySocAssurence(int Id_societe_assurance)
        //{
        //    int Dept = utOfWork.ContratAssuranceRepository.FindRegionBySocAssurence(Id_societe_assurance);
        //    return Dept;

        //}
        //public int FindGouverneratBySocAssurence(int Id_societe_assurance)
        //{
        //    int Dept = utOfWork.ContratAssuranceRepository.FindGouverneratBySocAssurence(Id_societe_assurance);
        //    return Dept;

        //}
        //public int FindDelegationBySocAssurence(int Id_societe_assurance)
        //{
        //    int Dept = utOfWork.EtageRepository.FindDelegationBySocAssurence(Id_societe_assurance);
        //    return Dept;

        //}





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


        public void UpdateSociete_assuranceDetached(Societe_assurance e)
        {
            utOfWork.SocieteAssuranceRepository.UpdateSoc_AssuranceDetached(e);
        }
        public void UpdateContrat_MaintenanceDetached(Contrat_maintenance e)
        {
            utOfWork.ContratMaintennaceRepository.UpdateCont_MaintenanceDetached(e);
        }


        public void UpdateSociete_MaintenanceDetached(Societe_maintenance e)
        {
            utOfWork.SocieteMaintenanceRepository.UpdateSoc_MaintenanceDetached(e);
        }


               public void UpdateContrat_GarantieDetached(Contrat_garanti e)
        {
            utOfWork.ContratGarantieRepository.UpdateCont_GarantieDetached(e);
        }


    }

    }
    public interface IGestionContratetSocService
    {
    Contrat_maintenance FindContrat_MaintenanceByID(int id);
    void UpdateContrat_assuranceDetached(Contrat_assurance e);
    void UpdateSociete_assuranceDetached(Societe_assurance e);
    void UpdateContrat_MaintenanceDetached(Contrat_maintenance e);
    void UpdateSociete_MaintenanceDetached(Societe_maintenance e);
    void UpdateContrat_GarantieDetached(Contrat_garanti e);
        Societe_maintenance FindSocMainByID(int id);
        Contrat_assurance FindContrat_assuranceByID(int id);
        Societe_assurance FindSocAssByID(int id);
        void UpdateAchatDetached(Achat e);
       
        void SaveChange();
        //int FindPaysBySocAssurence(int Id_societe_assurance);
        //int FindGouverneratBySocAssurence(int Id_societe_assurance);
        //int FindOrganisationBySocAssurence(int Id_societe_assurance);
        //int FindDelegationBySocAssurence(int Id_societe_assurance);
    }




