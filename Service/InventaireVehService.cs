using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Infrastructure;


namespace Service
{
   public class InventaireVehService : IInventaireVehService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public InventaireVehService() { }

        public IEnumerable<Association_31> GetInventaireVeh()
        {
            var dep = utOfWork.InventaireVehRepository.GetAll();
            return dep;
        }



        public Association_31 FindVehByID(int id)
        {
            var Dept = utOfWork.InventaireVehRepository.FindVehByID(id);
            return Dept;
        }

        public void CreateInventaireVeh(Association_31 InventaireVeh)
        {
            utOfWork.InventaireVehRepository.Add(InventaireVeh);
        }


        public void SaveInventaireVeh()
        {
            utOfWork.Commit();
        }

        public void UpdateInventaireVehDetached(Association_31 e)
        {
            utOfWork.InventaireVehRepository.UpdateInventaireVehDetached(e);
        }

        public IEnumerable<Batiment> FindBatimentByDelegation(int id)
        {
            var dep = utOfWork.InventaireVehRepository.FindBatimentByDelegation(id);
            return dep;
        }

        public IEnumerable<Parc_auto> FindParcByBatiment(int id)
        {
            var dep = utOfWork.InventaireVehRepository.FindParcByBatiment(id);
            return dep;
        }

        public IEnumerable<Vehicule> FindVehByParc(int id)
        {
            var dep = utOfWork.InventaireVehRepository.FindVehByParc(id);
            return dep;
        }




    }
    public interface IInventaireVehService
    {
        void UpdateInventaireVehDetached(Association_31 e);
        IEnumerable<Batiment> FindBatimentByDelegation(int id);
        IEnumerable<Parc_auto> FindParcByBatiment(int id);
        IEnumerable<Vehicule> FindVehByParc(int id);
        Association_31 FindVehByID(int id);
        void SaveInventaireVeh();

    }
}
