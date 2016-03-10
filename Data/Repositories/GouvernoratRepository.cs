using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Data.Repositories
{
    public class GouvernoratRepository : RepositoryBase<Gouvernorat>, IGouvernoratRepository
    {
        public GouvernoratRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateGouvernoratDetached(Gouvernorat e)
        {
            Gouvernorat existing = FindGouvByID(e.idGouvernorat);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public Gouvernorat FindGouvByID(int id)
        {

            var pers = (from p in DataContext.Gouvernorat
                        where p.idGouvernorat == id
                        select p);
            return pers.FirstOrDefault();
        }
        public IEnumerable<Gouvernorat> FindGouverneratByRegion(int id)
        {

            var pers = (from p in DataContext.Gouvernorat
                        where p.idRegion == id
                        select p).ToList();

            return pers;
        }
        public IEnumerable<Gouvernorat> FindGouverneratByPays(int id)
        {

            var pers = (from p in DataContext.Gouvernorat
                        where p.idPays == id
                        select p).ToList();

            return pers;
        }


        public IEnumerable<Gouvernorat> findGouverneratByLibellePays(string libelle)
        {

            var pers = (from p in DataContext.Gouvernorat
                        where p.Region.Pays.libelle == libelle
                        select p).ToList();

            return pers;
        }
    }



    public interface IGouvernoratRepository : IRepository<Gouvernorat>
    {
        Gouvernorat FindGouvByID(int id);
        void UpdateGouvernoratDetached(Gouvernorat e);

        IEnumerable<Gouvernorat> FindGouverneratByRegion(int id);
        IEnumerable<Gouvernorat> FindGouverneratByPays(int id);
        IEnumerable<Gouvernorat> findGouverneratByLibellePays(string libelle);
    }

}


