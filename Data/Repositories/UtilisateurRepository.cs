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
            Utilisateur existing = this.DataContext.Utilisateur.Find(e.id_user);
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

        public Bien FindBienBuId(int id)
        {
            var pers = (from p in DataContext.Bien
                        where p.Id_bien == id
                        select p);
            return pers.FirstOrDefault();
        }

    }
      
   
    public interface IUtilisateurRepository : IRepository<Utilisateur>
    {

        void UpdateUtilisateurDetached(Utilisateur e);
        IEnumerable<Personnel> FindPersByBatiment(int id);
        Bien FindBienBuId(int id);



    }
    
}

