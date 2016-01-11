
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
   
   public class RegionRepository : RepositoryBase<Region>, IRegionRepository
    {
        public RegionRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateRegionDetached(Region e)
        {
            Region existing = FindRegByID(e.idRegion);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public Region FindRegByID(int id)
        {

            var pers = (from p in DataContext.Region
                        where p.idRegion == id
                        select p);
            return pers.FirstOrDefault();
        }
        public IEnumerable<Region> FindRegByIDPays(int id)
        {

            var pers = (from p in DataContext.Region
                        where p.idPays == id
                        select p);
            return pers.ToList();
        }

        public int FindRegionByDelegation(int id)
        {

            var pers = (from p in DataContext.Delegation
                        where p.idDelegation == id
                        select p);
            return pers.FirstOrDefault().idRegion;
        }

        public int FindPaysByDelegation(int id)
        {

            var pers = (from p in DataContext.Delegation
                        where p.idDelegation == id
                        select p);
            return pers.FirstOrDefault().idPays;
        }

        public int FindGouvByDelegation(int id)
        {

            var pers = (from p in DataContext.Delegation
                        where p.idDelegation == id
                        select p);
            return pers.FirstOrDefault().idGouvernorat;
        }

        //public int FindOrganisationByDelegation(int id)
        //{

        //    var pers = (from p in DataContext.Batiment
        //                where p.idBatiment == id
        //                select p);
        //    return pers.FirstOrDefault().idOrganisation;
        //}

     

        public int FindDirectionByDelegation(int id)
        {

            var pers = (from p in DataContext.Bureau
                        where p.Id_bureau == id
                        select p);
            return pers.FirstOrDefault().Id_direction;
        }


    }


    public interface IRegionRepository : IRepository<Region>
    {
        IEnumerable<Region> FindRegByIDPays(int id);
        Region FindRegByID(int id);
        int FindPaysByDelegation(int id);
        int FindDirectionByDelegation(int id);
        void UpdateRegionDetached(Region e);
        int FindGouvByDelegation(int id);
        int FindRegionByDelegation(int id);
        //int FindOrganisationByDelegation(int id);
    }

}

