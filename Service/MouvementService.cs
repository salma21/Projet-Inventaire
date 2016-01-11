using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain;

namespace Service
{
    public class MouvementService : IMouvementService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public MouvementService() { }

        public IEnumerable<Mouvement> GetMouvements()
        {
            var dep = utOfWork.MouvementRepository.GetAll();
            return dep;
        }

        public Mouvement GetMouvement(int id)
        {
            var Dept = utOfWork.MouvementRepository.GetById(id);
            return Dept;
        }

        public IEnumerable<Mouvement> GetMouvementsVehicule()
        {
            var dep = utOfWork.MouvementRepository.GetAll();
            return dep;
        }

        public Mouvement GetMouvementVehicule(int id)
        {
            var Dept = utOfWork.MouvementRepository.GetById(id);
            return Dept;
        }

        public void CreateMouvement(Mouvement Mouvement)
        {

            utOfWork.MouvementRepository.Add(Mouvement);


        }

        public IEnumerable<Etage> FindEtageByBatiment(int id)

        {
            var dep = utOfWork.MouvementRepository.FindEtageByBatiment(id);
            return dep;
        }

        public IEnumerable<Bureau> FindBureauByEtage(int id)

        {
            var dep = utOfWork.MouvementRepository.FindBureauByEtage(id);
            return dep;
        }

        public IEnumerable<Bien> FindBienByBureau(int id)

        {
            var dep = utOfWork.MouvementRepository.FindBienByBureau(id);
            return dep;
        }



        public IEnumerable<Parc_auto> FindParcByBatiment(int id)

        {
            var dep = utOfWork.MouvementRepository.FindParcByBatiment(id);
            return dep;
        }

        public IEnumerable<Vehicule> FindVehiculeByParc(int id)

        {
            var dep = utOfWork.MouvementRepository.FindVehiculeByParc(id);
            return dep;
        }



        public void CreateMouvementVehicule(Mouvement Mouvement)
        {

            utOfWork.MouvementRepository.Add(Mouvement);


        }
        public void DeleteMouvement(int id)
        {

            var Dept = utOfWork.MouvementRepository.GetById(id);
            utOfWork.MouvementRepository.Delete(Dept);



        }

        public void SaveMouvement()
        {
            utOfWork.Commit();
        }


        public void UpdateMouvementDetached(Mouvement e)
        {
            utOfWork.MouvementRepository.UpdateMouvementDetached(e);
        }

        public int FindOrganisationByBatiment(int id)
        {

            int Dept = utOfWork.MouvementRepository.FindOrganisationByBatiment(id);
            return Dept;
        }

        public int FindDelegationByBatiment(int id)
        {

            int Dept = utOfWork.MouvementRepository.FindDelegationByBatiment(id);
            return Dept;
        }

        public int FindGouverneratByBatiment(int id)
        {

            int Dept = utOfWork.MouvementRepository.FindGouverneratByBatiment(id);
            return Dept;
        }

        public int FindRegionByBatiment(int id)
        {

            int Dept = utOfWork.MouvementRepository.FindRegionByBatiment(id);
            return Dept;
        }

        public int FindPaysByBatiment(int id)
        {

            int Dept = utOfWork.MouvementRepository.FindPaysByBatiment(id);
            return Dept;
        }

        
    }
}

    public interface IMouvementService
    {
        IEnumerable<Mouvement> GetMouvements();
        Mouvement GetMouvement(int id);
        IEnumerable<Mouvement> GetMouvementsVehicule();
        Mouvement GetMouvementVehicule(int id);
        void UpdateMouvementDetached(Mouvement e);
        int FindDelegationByBatiment(int id);
        int FindGouverneratByBatiment(int id);
        int FindRegionByBatiment(int id);
        int FindOrganisationByBatiment(int id);
        int FindPaysByBatiment(int id);
        IEnumerable<Bureau> FindBureauByEtage(int id);
        IEnumerable<Etage> FindEtageByBatiment(int id);
        IEnumerable<Bien> FindBienByBureau(int id);
        IEnumerable<Parc_auto> FindParcByBatiment(int id);
        IEnumerable<Vehicule> FindVehiculeByParc(int id);




}


  