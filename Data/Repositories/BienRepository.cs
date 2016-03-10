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
    class BienRepository : RepositoryBase<Bien>, IBienRepository
    {
        public BienRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateBienDetached(Bien e)
        {
            Bien existing = this.DataContext.Bien.Find(e.Id_bien);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public Bien FindBienByID(int id)
        {

            var pers = (from p in DataContext.Bien
                        where p.id == id
                        select p);
            return pers.FirstOrDefault();
        }
    }


    public interface IBienRepository : IRepository<Bien>
    {

        void UpdateBienDetached(Bien e);
        Bien FindBienByID(int id);
    }
}