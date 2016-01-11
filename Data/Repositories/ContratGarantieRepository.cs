
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
   
   public class ContratGarantieRepository : RepositoryBase<Contrat_garanti>, IContratGarantieRepository
    {
        public ContratGarantieRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateCont_GarantieDetached(Contrat_garanti e)
        {
            Contrat_garanti existing = this.DataContext.Contrat_garanti.Find(e.Id_contrat_garanti);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

       
    }


    public interface IContratGarantieRepository : IRepository<Contrat_garanti>
    {

        void UpdateCont_GarantieDetached(Contrat_garanti e);
       
    }

}

