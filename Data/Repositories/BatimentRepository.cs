
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
   
   public class BatimentRepository : RepositoryBase<Batiment>, IBatimentRepository
    {
        public BatimentRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateBatimentDetached(Batiment e)
        {
            Batiment existing = FindBatimentByID(e.idBatiment);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public Batiment FindBatimentByID(int id)
        {

            var pers = (from p in this.DataContext.Batiment
                        where p.idBatiment == id
                        select p).ToList<Batiment>();
            return pers.FirstOrDefault();


        }

        public IEnumerable<Batiment> FindBatimentByDelgation(int id)
        {

            var pers = (from p in this.DataContext.Batiment
                        where p.idDelegation == id
                        select p).ToList<Batiment>();
            return pers.ToList();


        }

    }


    public interface IBatimentRepository : IRepository<Batiment>
    {
        Batiment FindBatimentByID(int id);
        void UpdateBatimentDetached(Batiment e);
        IEnumerable<Batiment> FindBatimentByDelgation(int id);

    }

}

