using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceEtPArcAutoService : IServiceEtPArcAutoService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public ServiceEtPArcAutoService() { }

        public IEnumerable<Parc_auto> GetParc_autos()
        {
            var dep = utOfWork.Parc_autoRepository.GetAll();
            return dep;
        }

        public Parc_auto GetParc_auto(int id)
        {
            var Dept = utOfWork.Parc_autoRepository.GetById(id);
            return Dept;
        }

        public Parc_auto FindParcByID(int id)
        {
            var Dept = utOfWork.Parc_autoRepository.FindParcByID(id);
            return Dept;
        }

        public void CreateParc_auto(Parc_auto Parc_auto)
        {

            utOfWork.Parc_autoRepository.Add(Parc_auto);


        }
        public void DeleteParc_auto(int id)
        {

            var Dept = utOfWork.Parc_autoRepository.GetById(id);
            utOfWork.Parc_autoRepository.Delete(Dept);



        }



        public void SaveParc_auto()
        {
            utOfWork.Commit();
        }


        public void UpdateParc_autoDetached(Parc_auto e)
        {
            utOfWork.Parc_autoRepository.UpdateParc_autoDetached(e);
        }



       




    }
    public interface IServiceEtPArcAutoService
    {
        IEnumerable<Parc_auto> GetParc_autos();
        Parc_auto GetParc_auto(int id);
        void CreateParc_auto(Parc_auto Dept);
        void DeleteParc_auto(int id);
        Parc_auto FindParcByID(int id);
        void UpdateParc_autoDetached(Parc_auto e);


        void SaveParc_auto();







    }

}


