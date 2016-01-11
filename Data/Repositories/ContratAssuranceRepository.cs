
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
   
   public class ContratAssuranceRepository : RepositoryBase<Contrat_assurance>, IContratAssuranceRepository
    {
        public ContratAssuranceRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateCont_AssuranceDetached(Contrat_assurance e)
        {
            Contrat_assurance existing = this.DataContext.Contrat_assurance.Find(e.Id_contrat_assurance);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

       
    }


    public interface IContratAssuranceRepository : IRepository<Contrat_assurance>
    {

        void UpdateCont_AssuranceDetached(Contrat_assurance e);
       
    }

}

