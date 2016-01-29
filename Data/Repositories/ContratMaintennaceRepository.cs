
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
            Contrat_maintenance existing = FindContrat_MaintenanceByID(e.Id_contrat_maintenance);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public Contrat_maintenance FindContrat_MaintenanceByID(int id)
        {

            var contass = (from p in this.DataContext.Contrat_maintenance
                           where p.Id_contrat_maintenance == id
                           select p).ToList<Contrat_maintenance>();
            return contass.FirstOrDefault();


        }
    }


    public interface IContratMaintennaceRepository : IRepository<Contrat_maintenance>
    {
        Contrat_maintenance FindContrat_MaintenanceByID(int id);

        void UpdateCont_MaintenanceDetached(Contrat_maintenance e);
       
    }

}

