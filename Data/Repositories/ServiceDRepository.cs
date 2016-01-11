using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{

    public class ServiceDRepository : RepositoryBase<ServiceD>, IServiceDRepository
    {
        public ServiceDRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateServiceDDetached(ServiceD e)
        {
            ServiceD existing = FindServByID(e.Id_service);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public ServiceD FindServByID(int id)
        {

            var pers = (from p in DataContext.ServiceD
                        where p.Id_service == id
                        select p);
            return pers.FirstOrDefault();
        }
    }


    public interface IServiceDRepository : IRepository<ServiceD>
    {

        void UpdateServiceDDetached(ServiceD e);
        ServiceD FindServByID(int id);
    }



}

