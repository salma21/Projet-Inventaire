using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Data.Infrastructure;
using Domain;

namespace Data.Repositories
{
    public class UserRepository : RepositoryBase<Utilisateur>, IUserRepository
    {
        public UserRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateUserDetached(Utilisateur e)
        {
            Utilisateur existing = this.DataContext.Utilisateur.Find(e.id);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

      


       
      


       
    }

   
    public interface IUserRepository : IRepository<Utilisateur>
    {

        void UpdateUserDetached(Utilisateur e);
      
        



    }

}

