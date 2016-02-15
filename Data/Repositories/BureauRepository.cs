
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
   
   public class BureauRepository : RepositoryBase<Bureau>, IBureauRepository
    {
        public BureauRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateBureauDetached(Bureau e)
        {
            //Bureau existing = FindBureauByID(e.id);
            //((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public IEnumerable<Bureau> FindBureauByBatiment(int id)
        {

            var pers = (from p in DataContext.Bureau
                        where p.idBatiment == id
                        select p).ToList();

            return pers;
        }


        public void UpdateGouvernoratDetached(Gouvernorat e)
        {
            Gouvernorat existing = this.DataContext.Gouvernorat.Find(e.idGouvernorat);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public void UpdatePaysDetached(Pays e)
        {
            Pays existing = this.DataContext.Pays.Find(e.idPays);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public Bureau FindBureauByID(int id)
        {

            var pers = (from p in DataContext.Bureau
                        where p.id == id
                        select p);
            return pers.FirstOrDefault();
        }
    }


    public interface IBureauRepository : IRepository<Bureau>
    {
        Bureau FindBureauByID(int id);
        void UpdateBureauDetached(Bureau e);
        void UpdatePaysDetached(Pays e);
        IEnumerable<Bureau> FindBureauByBatiment(int id);
void UpdateGouvernoratDetached(Gouvernorat e);
    }

}

