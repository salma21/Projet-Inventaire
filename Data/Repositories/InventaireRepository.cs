
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
   
   public class InventaireRepository : RepositoryBase<Inventaire>, IInventaireRepository
    {
        public InventaireRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateInventaireDetached(Inventaire e)
        {
            Inventaire existing = this.DataContext.Inventaire.Find(e.Id_inventaire);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        //public IEnumerable<Bien> FindBineByInv(int id)
        //{


        //    var pers = (from p in DataContext.Bien
        //                where p.Id_inventaire == id
        //                select p).ToList();

        //    return pers;
        //}
    }


    public interface IInventaireRepository : IRepository<Inventaire>
    {

        void UpdateInventaireDetached(Inventaire e);

        //IEnumerable<Bien> FindBineByInv(int id);
    }

}

