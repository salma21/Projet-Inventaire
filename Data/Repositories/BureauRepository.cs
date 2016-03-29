
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

            Bureau existing = FindBureauByID(e.Id_bureau);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public IEnumerable<Bureau> FindBureauByBatiment(int id)
        {

            var pers = (from p in DataContext.Bureau
                        where p.idBatiment == id
                        select p).ToList();

            return pers;
        }


        public int FindMaxID()
        {

            var pers = (from p in DataContext.Bureau
                        
                        select p.Id_bureau).Max();

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

        public IEnumerable<Etage> findEtageByBatiment(int id)
        {

            var pers = (from p in DataContext.Etage
                        where p.idBatiment == id
                        select p);
            return pers;
        }

        public IEnumerable<Bureau> findBureauByEtage(int id)
        {

            var pers = (from p in DataContext.Bureau
                        where p.Id_etage == id
                        select p);
            return pers.ToList();
        }
    }


    public interface IBureauRepository : IRepository<Bureau>
    {
        Bureau FindBureauByID(int id);
        void UpdateBureauDetached(Bureau e);
        void UpdatePaysDetached(Pays e);
        IEnumerable<Bureau> FindBureauByBatiment(int id);
        IEnumerable<Etage> findEtageByBatiment(int id);
        IEnumerable<Bureau> findBureauByEtage(int id);
        void UpdateGouvernoratDetached(Gouvernorat e);
        //object findBureauByEtage(int id);
        int FindMaxID();
    }

}

