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

        public IEnumerable<MouvementV> GetMouvementVehicules()
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

        
      

        public IEnumerable<Vehicule> FindVehiculeByParc(int id)

        {
            var dep = utOfWork.MouvementVRepository.FindVehiculeByParc(id);
            return dep;
        }
        public IEnumerable<Parc_auto> FindParcByBatiment(int id)

        {
            var dep = utOfWork.MouvementVRepository.FindParcByBatiment(id);
            return dep;
        }
        public IEnumerable<Batiment> FindBatimentByDelegation(int id)

        {
            var dep = utOfWork.MouvementVRepository.FindBatimentByDelegation(id);
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

      

      
        
    }
}

    public interface IMouvementVService
    {
        IEnumerable<MouvementV> GetMouvementVehicules();
        MouvementV GetMouvementVehicule(int id);
    void SaveMouvementV();
    void CreateMouvementV(MouvementV MouvementV);
       void UpdateMouvementVDetached(MouvementV e);

      IEnumerable<Vehicule> FindVehiculeByParc(int id);
      IEnumerable<Parc_auto> FindParcByBatiment(int id);
      IEnumerable<Batiment> FindBatimentByDelegation(int id);




}


  