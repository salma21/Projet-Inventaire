using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    public class ServiceDService : IServiceDService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public ServiceDService() { }

        public IEnumerable<ServiceD> GetServiceDs()
        {
            var Dept = utOfWork.ServiceDRepository.GetAll();
            return Dept;
        }

        public ServiceD GetServiceD(int Id_service)
        {
            var Dept = utOfWork.ServiceDRepository.GetById(Id_service);
            return Dept;
        }

        public ServiceD FindServByID(int id)
        {
            var Dept = utOfWork.ServiceDRepository.FindServByID(id);
            return Dept;
        }

        public void CreateServiceD(ServiceD ServiceD)
        {

            utOfWork.ServiceDRepository.Add(ServiceD);

        }
        public void DeleteServiceD(int Id_service)
        {

            var Dept = utOfWork.ServiceDRepository.GetById(Id_service);
            utOfWork.ServiceDRepository.Delete(Dept);

        }


        public void SaveServiceD()
        {
            utOfWork.Commit();
        }

        public void UpdateServiceDDetached(ServiceD e)
        {
            utOfWork.ServiceDRepository.UpdateServiceDDetached(e);
        }

    }
    public interface IServiceDService
    {
        ServiceD FindServByID(int id);
        IEnumerable<ServiceD> GetServiceDs();
        ServiceD GetServiceD(int Id_service);
        void CreateServiceD(ServiceD Dept);
        void DeleteServiceD(int id);

        void UpdateServiceDDetached(ServiceD e);

        void SaveServiceD();


    }

}

