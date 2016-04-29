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
    class DepotRepository : RepositoryBase<Depot>, IDepotRepository
    {
        public DepotRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateDepotDetached(Depot e)
        {
            Depot existing = findDepotById(e.IdDepot);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
      
     
        public IEnumerable<Depot> findDepotByDelegation(int id)
        {

            var pers = (from p in DataContext.Depot
                        where p.idDelegation == id
                        select p).ToList();

            return pers;
        }

        public Depot findDepotById(int id)
        {

            var pers = (from p in DataContext.Depot
                        where p.IdDepot == id
                        select p);
            return pers.FirstOrDefault();
        }
    }


    public interface IDepotRepository : IRepository<Depot>
    {

        void UpdateDepotDetached(Depot e);
        IEnumerable<Depot> findDepotByDelegation(int id);
        Depot findDepotById(int id);
    }

}
