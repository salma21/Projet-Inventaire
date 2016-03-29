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

        public IEnumerable<InventaireBien> GetInventaireBiens()
        {
            var dep = utOfWork.InventaireBienRepository.GetAll();
            return dep;
        }



        public InventaireBien FindBienByID(int id)
        {
            var Dept = utOfWork.InventaireBienRepository.FindBienByID(id);
            return Dept;
        }

        public void CreateInventaireBien(InventaireBien InventaireBien)
        {
           
            
            utOfWork.InventaireBienRepository.Add(InventaireBien);
        }
       

        public void SaveInventaireBien()
        {
            utOfWork.Commit();
        }

        public void UpdateInventaireBienDetached(InventaireBien e)
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
        void UpdateInventaireBienDetached(InventaireBien e);
        IEnumerable<Batiment> FindBatimentByDelegation(int id);
        IEnumerable<Etage> FindEtageByBatiment(int id);
        IEnumerable<Bien> FindBienByEtage(int id);
        InventaireBien FindBienByID(int id);
        void CreateInventaireBien(InventaireBien InventaireBien);
        void SaveInventaireBien();
        IEnumerable<InventaireBien> GetInventaireBiens();
       

    }

}
