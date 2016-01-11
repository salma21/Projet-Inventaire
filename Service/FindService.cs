using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FindService : IFindService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public FindService() { }

        public IEnumerable<Region> FindRegionByPays(int id)
        {
            var dep = utOfWork.DelegationRepository.FindRegionByPays(id);
            return dep;
        }

        public IEnumerable<Bureau> FindBureauByBatiment(int id)
        {
            var dep = utOfWork.DelegationRepository.FindBureauByBatiment(id);
            return dep;
        }

        public IEnumerable<Batiment> FindBatimentByDelegation(int id)
        {
            var dep = utOfWork.DelegationRepository.FindBatimentByDelegation(id);
            return dep;
        }

        public IEnumerable<Delegation> FindDelegationtByGouvernerat(int id)
        {
            var dep = utOfWork.DelegationRepository.FindDelegationtByGouvernerat(id);
            return dep;
        }

        public IEnumerable<Gouvernorat> FindGouverneratByRegion(int id)
        {
            var dep = utOfWork.DelegationRepository.FindGouverneratByRegion(id);
            return dep;
        }



    }
    public interface IFindService
    {
        IEnumerable<Bureau> FindBureauByBatiment(int id);
        IEnumerable<Batiment> FindBatimentByDelegation(int id);
        IEnumerable<Delegation> FindDelegationtByGouvernerat(int id);
        IEnumerable<Gouvernorat> FindGouverneratByRegion(int id);
        IEnumerable<Region> FindRegionByPays(int id);



    }

}


