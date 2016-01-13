using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class DelegationRepository : RepositoryBase<Delegation>, IDelegationRepository
    {
        public DelegationRepository(DatabaseFactory dbFactory) : base(dbFactory) { }



        public void UpdateDelegationDetached(Delegation e)
        {
            Delegation existing = FindDelByID(e.idDelegation);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public Delegation FindDelByID(int id)
        {

            var pers = (from p in this.DataContext.Delegation
                        where p.idDelegation == id
                        select p).ToList<Delegation>();
            return pers.FirstOrDefault();


        }

        public IEnumerable<Region> FindRegionByPays(int id)
        {
            var pers = (from p in DataContext.Region
                        where p.idPays == id
                        select p).ToList();

            return pers;
        }

        public IEnumerable<Gouvernorat> FindGouverneratByRegion(int id)
        {
            var pers = (from p in DataContext.Gouvernorat
                        where p.idRegion == id
                        select p).ToList();

            return pers;
        }

        public IEnumerable<Batiment> FindBatimentByDelgation(int id)
        {

            var pers = (from p in this.DataContext.Batiment
                        where p.idDelegation == id
                        select p).ToList<Batiment>();
            return pers.ToList();


        }

        public IEnumerable<Delegation> FindDelegationtByGouvernerat(int id)
        {
            var pers = (from p in DataContext.Delegation
                        where p.idGouvernorat == id
                        select p).ToList();

            return pers;
        }


        public IEnumerable<Batiment> FindBatimentByDelegation(int id)
        {
            var pers = (from p in DataContext.Batiment
                        where p.idDelegation == id
                        select p).ToList();

            return pers;
        }


        public IEnumerable<Bureau> FindBureauByBatiment(int id)
        {
            var pers = (from p in DataContext.Bureau
                        where p.idBatiment == id
                        select p).ToList();

            return pers;
        }

    }


    public interface IDelegationRepository : IRepository<Delegation>
    {
        Delegation FindDelByID(int id);
        IEnumerable<Gouvernorat> FindGouverneratByRegion(int id);
        IEnumerable<Delegation> FindDelegationtByGouvernerat(int id);
        IEnumerable<Batiment> FindBatimentByDelegation(int id);
        IEnumerable<Region> FindRegionByPays(int id);
        IEnumerable<Bureau> FindBureauByBatiment(int id);
        void UpdateDelegationDetached(Delegation e);



    }
}


