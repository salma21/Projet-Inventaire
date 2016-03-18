using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DepotService : IDepotService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public DepotService() { }

        public IEnumerable<Depot> getDepots()
        {
            var dep = utOfWork.DepotRepository.GetAll();
            return dep;
        }

        public Depot getDepot(int id)
        {
            var Dept = utOfWork.DepotRepository.GetById(id);
            return Dept;
        }

        public void createDepot(Depot depot)
        {

            utOfWork.DepotRepository.Add(depot);


        }


        public IEnumerable<Depot> findDepotByDelegation(int id)
        {
            var dep = utOfWork.DepotRepository.findDepotByDelegation(id);
            return dep;


        }
        public Depot findDepotById(int id)
        {
            var Dept = utOfWork.DepotRepository.findDepotById(id);
            return Dept;

        }



        public void SaveDepot()
        {
            utOfWork.Commit();
        }


        public void UpdateDepotDetached(Depot e)
        {
            utOfWork.DepotRepository.UpdateDepotDetached(e);
        }








    }
    public interface IDepotService
    {
        IEnumerable<Depot> getDepots();
        Depot getDepot(int id);
        void createDepot(Depot depot);
        IEnumerable<Depot> findDepotByDelegation(int id);
        Depot findDepotById(int id);
        void UpdateDepotDetached(Depot e);
        void SaveDepot();







    }

}
