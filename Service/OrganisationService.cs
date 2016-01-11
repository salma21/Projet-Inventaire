using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Infrastructure;

namespace Service
{
   public  class OrganisationService : IOrganisationService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public OrganisationService() { }

        public IEnumerable<Organisation> GetOrganisation()
        {
            var dep = utOfWork.OrganisationRepository.GetAll();
            return dep;
        }

        public Organisation GetOrganisation(int id)
        {
            var Dept = utOfWork.OrganisationRepository.GetById(id);
            return Dept;
        }

        public void CreateOrganisation(Organisation Organisation)
        {

            utOfWork.OrganisationRepository.Add(Organisation);


        }
        public void DeleteOrganisation(int id)
        {

            var Dept = utOfWork.OrganisationRepository.GetById(id);
            utOfWork.OrganisationRepository.Delete(Dept);



        }



        public void SaveOrganisation()
        {
            utOfWork.Commit();
        }


        public void UpdateOrganisationDetached(Organisation e)
        {
            utOfWork.OrganisationRepository.UpdateOrganisationDetached(e);
        }

    }
    public interface IOrganisationService
    {
        IEnumerable<Organisation> GetOrganisation();
        Organisation GetOrganisation(int id);
        void CreateOrganisation(Organisation Dep);
        void DeleteOrganisation(int id);

        void UpdateOrganisationDetached(Organisation e);


        void SaveOrganisation();

    }
}


