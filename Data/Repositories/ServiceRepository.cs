
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
   
   public class ServiceRepository : RepositoryBase<ServiceD>, IServiceRepository
    {
        public ServiceRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateServiceDetached(ServiceD e)
        {
            ServiceD existing = this.DataContext.ServiceD.Find(e.Id_service);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

       
    }


    public interface IServiceRepository : IRepository<ServiceD>
    {

        void UpdateServiceDetached(ServiceD e);
       
    }

}

