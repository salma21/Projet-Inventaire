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

        public IEnumerable<Personnel> FindPersByBatiment(int id)
        {
            var pers = (from p in DataContext.Personnel
                        where p.idBatiment == id
                        select p);
            return pers.ToList();
        }







    }

   
    public interface IUserRepository : IRepository<Utilisateur>
    {

        void UpdateUserDetached(Utilisateur e);

        IEnumerable<Personnel> FindPersByBatiment(int id);





    }

}

