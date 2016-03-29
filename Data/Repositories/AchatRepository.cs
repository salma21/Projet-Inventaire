
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
   
   public class AchatRepository : RepositoryBase<Achat>, IAchatRepository
    {
        public AchatRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateAchatDetached(Achat e)
        {
            Achat existing = this.DataContext.Achat.Find(e.Id_achat);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public int FindMaxIDAchat()
        {

            var pers = (from p in DataContext.Achat

                        select p.Id_achat).Max();

            return pers;
        }


    }


    public interface IAchatRepository : IRepository<Achat>
    {

        void UpdateAchatDetached(Achat e);
        int FindMaxIDAchat();
    }

}

