using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain;

namespace Service
{
    public class MouvementVService : IMouvementVService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public MouvementVService() { }

        public IEnumerable<MouvementV> GetMouvementsV()
        {
            var dep = utOfWork.MouvementVRepository.GetAll();
            return dep;
        }

        public MouvementV GetMouvementV(int id)
        {
            var Dept = utOfWork.MouvementVRepository.GetById(id);
            return Dept;
        }

        public IEnumerable<MouvementV> GetMouvementsVehicule()
        {
            var dep = utOfWork.MouvementVRepository.GetAll();
            return dep;
        }

        public MouvementV GetMouvementVehicule(int id)
        {
            var Dept = utOfWork.MouvementVRepository.GetById(id);
            return Dept;
        }

        public void CreateMouvementV(MouvementV MouvementV)
        {

            utOfWork.MouvementVRepository.Add(MouvementV);


        }

        
        public IEnumerable<Parc_auto> FindParcByBatiment(int id)

        {
            var dep = utOfWork.MouvementVRepository.FindParcByBatiment(id);
            return dep;
        }

        public IEnumerable<Vehicule> FindVehiculeByParc(int id)

        {
            var dep = utOfWork.MouvementVRepository.FindVehiculeByParc(id);
            return dep;
        }



        public void CreateMouvementVehicule(MouvementV MouvementV)
        {

            utOfWork.MouvementVRepository.Add(MouvementV);


        }
        public void DeleteMouvementV(int id)
        {

            var Dept = utOfWork.MouvementVRepository.GetById(id);
            utOfWork.MouvementVRepository.Delete(Dept);



        }

        public void SaveMouvementV()
        {
            utOfWork.Commit();
        }


        public void UpdateMouvementVDetached(MouvementV e)
        {
            utOfWork.MouvementVRepository.UpdateMouvementVDetached(e);
        }

        public int FindOrganisationByBatiment(int id)
        {

            int Dept = utOfWork.MouvementVRepository.FindOrganisationByBatiment(id);
            return Dept;
        }

        public int FindDelegationByBatiment(int id)
        {

            int Dept = utOfWork.MouvementVRepository.FindDelegationByBatiment(id);
            return Dept;
        }

        public int FindGouverneratByBatiment(int id)
        {

            int Dept = utOfWork.MouvementVRepository.FindGouverneratByBatiment(id);
            return Dept;
        }

        public int FindRegionByBatiment(int id)
        {

            int Dept = utOfWork.MouvementVRepository.FindRegionByBatiment(id);
            return Dept;
        }

        public int FindPaysByBatiment(int id)
        {

            int Dept = utOfWork.MouvementVRepository.FindPaysByBatiment(id);
            return Dept;
        }

        
    }
}

    public interface IMouvementVService
    {
        IEnumerable<MouvementV> GetMouvementVs();
        MouvementV GetMouvementV(int id);
        IEnumerable<MouvementV> GetMouvementVsVehicule();
        MouvementV GetMouvementVVehicule(int id);
        void UpdateMouvementVDetached(MouvementV e);
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


  