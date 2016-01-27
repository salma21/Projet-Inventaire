using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Infrastructure;

namespace Service
{
  public  class InventaireBienService : IInventaireBienService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public InventaireBienService() { }

        public IEnumerable<Association_30> GetInventaireBiens()
        {
            var dep = utOfWork.InventaireBienRepository.GetAll();
            return dep;
        }



        public Association_30 FindBienByID(int id)
        {
            var Dept = utOfWork.InventaireBienRepository.FindBienByID(id);
            return Dept;
        }

        public void CreateInventaireBien(Association_30 InventaireBien)
        {
           
            
            utOfWork.InventaireBienRepository.Add(InventaireBien);
        }
       

        public void SaveInventaireBien()
        {
            utOfWork.Commit();
        }

        public void UpdateInventaireBienDetached(Association_30 e)
        {
            utOfWork.InventaireBienRepository.UpdateInventaireBienDetached(e);
        }

        public IEnumerable<Batiment> FindBatimentByDelegation(int id)
        {
            var dep = utOfWork.InventaireBienRepository.FindBatimentByDelegation(id);
            return dep;
        }

        public IEnumerable<Etage> FindEtageByBatiment(int id)
        {
            var dep = utOfWork.InventaireBienRepository.FindEtageByBatiment(id);
            return dep;
        }

        public IEnumerable<Bien> FindBienByEtage(int id)
        {
            var dep = utOfWork.InventaireBienRepository.FindBienByEtage(id);
            return dep;
        }




    }
    public interface IInventaireBienService
    {
        void UpdateInventaireBienDetached(Association_30 e);
        IEnumerable<Batiment> FindBatimentByDelegation(int id);
        IEnumerable<Etage> FindEtageByBatiment(int id);
        IEnumerable<Bien> FindBienByEtage(int id);
        Association_30 FindBienByID(int id);
        void CreateInventaireBien(Association_30 InventaireBien);
        void SaveInventaireBien();
        IEnumerable<Association_30> GetInventaireBiens();


    }

}
