using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Data.Infrastructure;
using Domain;

namespace Data.Repositories
{
    public class UtilisateurRepository : RepositoryBase<Utilisateur>, IUtilisateurRepository
    {
        public UtilisateurRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateUtilisateurDetached(Utilisateur e)
        {
            Utilisateur existing = this.DataContext.Utilisateur.Find(e.id);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }



    }
      
   
    public interface IUtilisateurRepository : IRepository<Utilisateur>
    {

        void UpdateUtilisateurDetached(Utilisateur e);
      
        



    }
    
}

