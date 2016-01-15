using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain;

namespace Service
{
    public class MouvementBService : IMouvementBService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public MouvementBService() { }

        public IEnumerable<MouvementB> GetMouvementBiens()
        {
            var dep = utOfWork.MouvementBRepository.GetAll();
            return dep;
        }

        public MouvementB GetMouvementBien(int id)
        {
            var Dept = utOfWork.MouvementBRepository.GetById(id);
            return Dept;
        }

       
        public void CreateMouvementBien(MouvementB MouvementB)
        {

            utOfWork.MouvementBRepository.Add(MouvementB);


        }

        public IEnumerable<Etage> FindEtageByBatiment(int id)

        {
            var dep = utOfWork.MouvementBRepository.FindEtageByBatiment(id);
            return dep;
        }

      

        public IEnumerable<Bien> FindBienByEtage(int id)

        {
            var dep = utOfWork.MouvementBRepository.FindBienByEtage(id);
            return dep;
        }



      

      



       
        public void DeleteMouvementB(int id)
        {

            var Dept = utOfWork.MouvementBRepository.GetById(id);
            utOfWork.MouvementBRepository.Delete(Dept);



        }

        public void SaveMouvementB()
        {
            utOfWork.Commit();
        }


        public void UpdateMouvementBDetached(MouvementB e)
        {
            utOfWork.MouvementBRepository.UpdateMouvementBDetached(e);
        }

        public int FindOrganisationByBatiment(int id)
        {

            int Dept = utOfWork.MouvementBRepository.FindOrganisationByBatiment(id);
            return Dept;
        }

        public int FindDelegationByBatiment(int id)
        {

            int Dept = utOfWork.MouvementBRepository.FindDelegationByBatiment(id);
            return Dept;
        }

        public int FindGouverneratByBatiment(int id)
        {

            int Dept = utOfWork.MouvementBRepository.FindGouverneratByBatiment(id);
            return Dept;
        }

        public int FindRegionByBatiment(int id)
        {

            int Dept = utOfWork.MouvementBRepository.FindRegionByBatiment(id);
            return Dept;
        }

        public int FindPaysByBatiment(int id)
        {

            int Dept = utOfWork.MouvementBRepository.FindPaysByBatiment(id);
            return Dept;
        }

        
    }
}

    public interface IMouvementBService
    {
     
        MouvementB GetMouvementBien(int id);
        IEnumerable<MouvementB> GetMouvementBiens();
       
        void UpdateMouvementBDetached(MouvementB e);
        int FindDelegationByBatiment(int id);
        int FindGouverneratByBatiment(int id);
        int FindRegionByBatiment(int id);
        int FindOrganisationByBatiment(int id);
        int FindPaysByBatiment(int id);
        
        IEnumerable<Etage> FindEtageByBatiment(int id);
        IEnumerable<Bien> FindBienByEtage(int id);
       




}


  