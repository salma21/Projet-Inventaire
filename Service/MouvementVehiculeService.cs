using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain;

namespace Service
{
    public class MouvementVehiculeService : IMouvementVehiculeService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public MouvementVehiculeService() { }

        public IEnumerable<MouvementVehicule> GetMouvementVehicules()
        {
            var dep = utOfWork.MouvementVehiculeRepository.GetAll();
            return dep;
        }



        public MouvementVehicule GetMouvementVehicule(int id)
        {
            var Dept = utOfWork.MouvementVehiculeRepository.GetById(id);
            return Dept;
        }

        public void CreateMouvementVehicule(MouvementVehicule MouvementVehicule)
        {

            utOfWork.MouvementVehiculeRepository.Add(MouvementVehicule);


        }




        public IEnumerable<Vehicule> FindVehiculeByParc(int id)

        {
            var dep = utOfWork.MouvementVehiculeRepository.FindVehiculeByParc(id);
            return dep;
        }
        public IEnumerable<Parc_auto> FindParcByBatiment(int id)

        {
            var dep = utOfWork.MouvementVehiculeRepository.FindParcByBatiment(id);
            return dep;
        }
        public IEnumerable<Batiment> FindBatimentByDelegation(int id)

        {
            var dep = utOfWork.MouvementVehiculeRepository.FindBatimentByDelegation(id);
            return dep;
        }

        //public void CreateMouvementVehicule(MouvementVehicule MouvementVehicule)
        //{

        //    utOfWork.MouvementVehiculeRepository.Add(MouvementVehicule);


        //}
        public void DeleteMouvementVehicule(int id)
        {

            var Dept = utOfWork.MouvementVehiculeRepository.GetById(id);
            utOfWork.MouvementVehiculeRepository.Delete(Dept);



        }

        public void SaveMouvementVehicule()
        {
            utOfWork.Commit();
        }


        public void UpdateMouvementVehiculeDetached(MouvementVehicule e)
        {
            utOfWork.MouvementVehiculeRepository.UpdateMouvementVehiculeDetached(e);
        }


     

        public MouvementVehicule FindMouvementVehiculeByID(int id)
        {
            var Dept = utOfWork.MouvementVehiculeRepository.FindMouvementVehiculeByID(id);
            return Dept;

        }
    }
}

public interface IMouvementVehiculeService
{
   

    MouvementVehicule FindMouvementVehiculeByID(int id);
    IEnumerable<MouvementVehicule> GetMouvementVehicules();
    MouvementVehicule GetMouvementVehicule(int id);
    void SaveMouvementVehicule();
    void CreateMouvementVehicule(MouvementVehicule MouvementVehicule);
    void UpdateMouvementVehiculeDetached(MouvementVehicule e);

    IEnumerable<Vehicule> FindVehiculeByParc(int id);
    IEnumerable<Parc_auto> FindParcByBatiment(int id);
    IEnumerable<Batiment> FindBatimentByDelegation(int id);




}


