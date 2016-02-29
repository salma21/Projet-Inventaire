using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Infrastructure;
using Domain;

namespace Data.Repositories
{
  public class PaysRepository : RepositoryBase<Pays>, IPaysRepository
    {
        public PaysRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdatePaysDetached(Pays e)
        {
           
            Pays existing = FindPaysByID(e.idPays);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public Pays FindPaysByID(int id)
        {

            var pers = (from p in DataContext.Pays
                        where p.idPays == id
                        select p);
            return pers.FirstOrDefault();
        }
    }


    public interface IPaysRepository : IRepository<Pays>
    {

        void UpdatePaysDetached(Pays e);
        Pays FindPaysByID(int id);

    }


}
