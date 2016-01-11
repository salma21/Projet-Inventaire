using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Data.Repositories
{
   public class OrganisationRepository : RepositoryBase<Organisation>, IOrganisationRepository
    {
        public OrganisationRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateOrganisationDetached(Organisation e)
        {
            Organisation existing = this.DataContext.Organisation.Find(e.idOrganisation);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }


    }



    public interface IOrganisationRepository : IRepository<Organisation>
    {

        void UpdateOrganisationDetached(Organisation e);



    }

}
   
