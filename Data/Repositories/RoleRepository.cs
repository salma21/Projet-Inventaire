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
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(DatabaseFactory dbFactory) : base(dbFactory) { }


        public void UpdateRoleDetached(Role e)
        {
            Role existing = this.DataContext.Role.Find(e.id);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }


    }


    public interface IRoleRepository : IRepository<Role>
    {

        void UpdateRoleDetached(Role e);

    }



}
