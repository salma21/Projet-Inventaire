using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RegionService : IRegionService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public RegionService() { }

        public IEnumerable<Region> GetRegionx()
        {
            var dep = utOfWork.RegionRepository.GetAll();
            return dep;
        }

        public Region GetRegion(int id)
        {
            var Dept = utOfWork.RegionRepository.GetById(id);
            return Dept;
        }

        public Region FindRegByID(int id)
        {
            var Dept = utOfWork.RegionRepository.FindRegByID(id);
            return Dept;
        }

        public IEnumerable<Region> FindRegByIDPays(int id)
        {
            var Dept = utOfWork.RegionRepository.FindRegByIDPays(id);
            return Dept;
        }

        public void CreateRegion(Region Region)
        {

            utOfWork.RegionRepository.Add(Region);


        }
        public void DeleteRegion(int id)
        {

            var Dept = utOfWork.RegionRepository.GetById(id);
            utOfWork.RegionRepository.Delete(Dept);



        }



        public void SaveRegion()
        {
            utOfWork.Commit();
        }


        public void UpdateRegionDetached(Region e)
        {
            utOfWork.RegionRepository.UpdateRegionDetached(e);
        }


        public int FindDirectionByDelegation(int id)
        {
            int Dept = utOfWork.RegionRepository.FindDirectionByDelegation(id);
            return Dept;
        }
        //public int FindOrganisationByDelegation(int id)
        //{
        //    int Dept = utOfWork.RegionRepository.FindOrganisationByDelegation(id);
        //    return Dept;
        //}
        public int FindGouvByDelegation(int id)
        {
            int Dept = utOfWork.RegionRepository.FindGouvByDelegation(id);
            return Dept;
        }
        public int FindPaysByDelegation(int id)
        {
            int Dept = utOfWork.RegionRepository.FindPaysByDelegation(id);
            return Dept;

        }
        public int FindRegionByDelegation(int id)
        {
            int Dept = utOfWork.RegionRepository.FindRegionByDelegation(id);
            return Dept;

        }





    }
    public interface IRegionService
    {
        //int FindOrganisationByDelegation(int id);
        int FindGouvByDelegation(int id);
        int FindPaysByDelegation(int id);
        int FindRegionByDelegation(int id);
        int FindDirectionByDelegation(int id);
        IEnumerable<Region> GetRegionx();
        Region GetRegion(int id);
        void CreateRegion(Region Dept);
        void DeleteRegion(int id);
        IEnumerable<Region> FindRegByIDPays(int id);
        void UpdateRegionDetached(Region e);

        Region FindRegByID(int id);
        void SaveRegion();







    }

}


