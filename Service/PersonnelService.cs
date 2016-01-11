using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    public class PersonnelService : IPersonnelService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public PersonnelService() { }

        public IEnumerable<Personnel> GetPersonnels()
        {
            var dep = utOfWork.PersonnelRepository.GetAll();
            return dep;
        }

        public Personnel GetPersonnel(int id)
        {
            var Dept = utOfWork.PersonnelRepository.GetById(id);
            return Dept;
        }

        public void CreatePersonnel(Personnel Personnel)
        {

            utOfWork.PersonnelRepository.Add(Personnel);

        }

        public Personnel FindPersByID(int id)
        {
            var Dept = utOfWork.PersonnelRepository.FindPersByID(id);
            return Dept;

        }

        public void DeletePersonnel(int id)
        {

            var Dept = utOfWork.PersonnelRepository.GetById(id);
            utOfWork.PersonnelRepository.Delete(Dept);

        }


        public void SavePersonnel()
        {
            utOfWork.Commit();
        }


        public void UpdatePersonnelDetached(Personnel e)
        {
            utOfWork.PersonnelRepository.UpdatePersonnelDetached(e);
        }
        public int FindOrganisationByDelegation(int id)
        {
            int Dept = utOfWork.PersonnelRepository.FindOrganisationByBatiment(id);
            return Dept;

        }
        public int FindPaysByBatiment(int id)
        {
            int Dept = utOfWork.PersonnelRepository.FindPaysByBatiment(id);
            return Dept;
        }
        public int FindRegionByBatiment(int id)
        {
            int Dept = utOfWork.PersonnelRepository.FindRegionByBatiment(id);
            return Dept;

        }
        public int FindGouverneratByBatiment(int id)
        {
            int Dept = utOfWork.PersonnelRepository.FindGouverneratByBatiment(id);
            return Dept;

        }
        public int FindDelegationByBatiment(int id)
        {
            int Dept = utOfWork.PersonnelRepository.FindDelegationByBatiment(id);
            return Dept;

        }
    }

}
public interface IPersonnelService
{
    Personnel FindPersByID(int id);
    int FindRegionByBatiment(int id);
    int FindPaysByBatiment(int id);
    int FindGouverneratByBatiment(int id);
    int FindOrganisationByDelegation(int id);
    int FindDelegationByBatiment(int id);
    IEnumerable<Personnel> GetPersonnels();
    Personnel GetPersonnel(int id);
    void CreatePersonnel(Personnel Dept);
    void DeletePersonnel(int id);

    void UpdatePersonnelDetached(Personnel e);


    void SavePersonnel();


}




