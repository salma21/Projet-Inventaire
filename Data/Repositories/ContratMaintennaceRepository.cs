
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
   
   public class ContratMaintennaceRepository : RepositoryBase<Contrat_maintenance>, IContratMaintennaceRepository
    {
        public ContratMaintennaceRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateCont_MaintenanceDetached(Contrat_maintenance e)
        {
            Contrat_maintenance existing = this.DataContext.Contrat_maintenance.Find(e.Id_contrat_maintenance);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

       
    }


    public interface IContratMaintennaceRepository : IRepository<Contrat_maintenance>
    {

        void UpdateCont_MaintenanceDetached(Contrat_maintenance e);
       
    }

}

