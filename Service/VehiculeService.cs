using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain;


namespace Service
{
  public  class VehiculeService : IVehiculeService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public VehiculeService() { }

        public IEnumerable<Vehicule> GetVehicules()
        {
            var dep = utOfWork.VehiculeRepository.GetAll();
            return dep;
        }

        public Vehicule GetVehicule(int id)
        {
            var Dept = utOfWork.VehiculeRepository.GetById(id);
            return Dept;
        }

        public void CreateVehicule(Vehicule Vehicule)
        {

            utOfWork.VehiculeRepository.Add(Vehicule);


        }
        public void DeleteVehicule(int id)
        {

            var Dept = utOfWork.VehiculeRepository.GetById(id);
            utOfWork.VehiculeRepository.Delete(Dept);



        }


        public int FindFournisseurByContrat(int id)
        {

            int Dept = utOfWork.VehiculeRepository.FindFournisseurByContrat(id);
            return Dept;
        }

      


        public int FindBatimentByParcAuto(int id)
        {

            int Dept = utOfWork.VehiculeRepository.FindBatimentByParcAuto(id);
            return Dept;
        }

        public Vehicule getVehicule(int id)
        {
            var Dept = utOfWork.VehiculeRepository.GetById(id);
            return Dept;
        }

        public void SaveVehicule()
        {
            utOfWork.Commit();
        }


        public void UpdateVehiculeDetached(Vehicule e)
        {
            utOfWork.VehiculeRepository.UpdateVehiculeDetached(e);
        }

    }
}
public interface IVehiculeService
{
    IEnumerable<Vehicule> GetVehicules();
    Vehicule GetVehicule(int id);
    void CreateVehicule(Vehicule Dep);
    void DeleteVehicule(int id);

    int FindFournisseurByContrat(int id);
    
    int FindBatimentByParcAuto(int id);
    void UpdateVehiculeDetached(Vehicule e);
    Vehicule getVehicule(int id);
    void SaveVehicule();
   
}
