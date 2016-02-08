using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Infrastructure;


namespace Service
{
   public class InventaireVehiculeService : IInventaireVehService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public InventaireVehiculeService() { }

        public IEnumerable<InventaireVehicule> GetInventaireVehicule()
        {
            var dep = utOfWork.InventaireVehiculeRepository.GetAll();
            return dep;
        }



        public InventaireVehicule FindVehiculeByID(int id)
        {
            var Dept = utOfWork.InventaireVehiculeRepository.FindVehiculeByID(id);
            return Dept;
           
        }

        public Vehicule GetVehiculeByID(int id)
        {
            return utOfWork.InventaireVehiculeRepository.GetVehiculeByID(id);

        }
        public void CreateInventaireVehicule(InventaireVehicule InventaireVehicule)
        {
            utOfWork.InventaireVehiculeRepository.Add(InventaireVehicule);
        }


        public void SaveInventaireVehicule()
        {
            utOfWork.Commit();
        }

        public void UpdateInventaireVehiculeDetached(InventaireVehicule e)
        {
            utOfWork.InventaireVehiculeRepository.UpdateInventaireVehiculeDetached(e);
        }

        public IEnumerable<Batiment> FindBatimentByDelegation(int id)
        {
            var dep = utOfWork.InventaireVehiculeRepository.FindBatimentByDelegation(id);
            return dep;
        }

        public IEnumerable<Parc_auto> FindParcByBatiment(int id)
        {
            var dep = utOfWork.InventaireVehiculeRepository.FindParcByBatiment(id);
            return dep;
        }

        public IEnumerable<Vehicule> FindVehiculeByParc(int id)
        {
            var dep = utOfWork.InventaireVehiculeRepository.FindVehiculeByParc(id);
            return dep;
        }




    }
    public interface IInventaireVehiculeService
    {
        void UpdateInventaireVehiculeDetached(InventaireVehicule e);
        IEnumerable<Batiment> FindBatimentByDelegation(int id);
        IEnumerable<Parc_auto> FindParcByBatiment(int id);
        IEnumerable<Vehicule> FindVehiculeByParc(int id);
        InventaireVehicule FindVehiculeByID(int id);
        void SaveInventaireVehicule();
        void CreateInventaireVehicule(InventaireVehicule InventaireVehicule);
        IEnumerable<InventaireVehicule> GetInventaireVehicule();
        Vehicule GetVehiculeByID(int id);
    }
}
