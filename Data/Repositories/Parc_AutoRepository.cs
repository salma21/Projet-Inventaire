
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
   
   public class Parc_autoRepository : RepositoryBase<Parc_auto>, IParc_autoRepository
    {
        public Parc_autoRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateParc_autoDetached(Parc_auto e)
        {
            Parc_auto existing = FindParcByID(e.Id_parc);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public Parc_auto FindParcByID(int id)
        {

            var pers = (from p in DataContext.Parc_auto
                        where p.Id_parc == id
                        select p);
            return pers.FirstOrDefault();
        }

    }


    public interface IParc_autoRepository : IRepository<Parc_auto>
    {
        Parc_auto FindParcByID(int id);
        void UpdateParc_autoDetached(Parc_auto e);
       
    }

}

