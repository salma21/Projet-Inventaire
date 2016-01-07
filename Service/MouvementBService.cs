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

       

      

        public void CreateMouvementB(MouvementB MouvementB)
        {

            utOfWork.MouvementBRepository.Add(MouvementB);


        }

        public IEnumerable<Etage> FindEtageByBatiment(int id)

        {
            var dep = utOfWork.MouvementBRepository.FindEtageByBatiment(id);
            return dep;
        }


        public IEnumerable<Batiment> FindBatimentByDelegation(int id)

        {
            var dep = utOfWork.MouvementBRepository.FindBatimentByDelegation(id);
            return dep;
        }


        public IEnumerable<Bien> FindBienByEtage(int id)

        {
            var dep = utOfWork.MouvementBRepository.FindBienByEtage(id);
            return dep;
        }

        public void SaveMouvementB()
        {
            utOfWork.Commit();
        }


        public void UpdateMouvementBDetached(MouvementB e)
        {
            utOfWork.MouvementBRepository.UpdateMouvementBDetached(e);
        }

        

       


        
    }
}

    public interface IMouvementBService
    {
        IEnumerable<MouvementB> GetMouvementBiens();
        MouvementB GetMouvementBien(int id);
   
        void UpdateMouvementBDetached(MouvementB e);
        void SaveMouvementB();
       void CreateMouvementB(MouvementB MouvementB);
       IEnumerable<Batiment> FindBatimentByDelegation(int id);

       IEnumerable<Etage> FindEtageByBatiment(int id);

      IEnumerable<Bien> FindBienByEtage(int id);








}


