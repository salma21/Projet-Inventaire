using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    public class EtageService : IEtageService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public EtageService() { }

        public IEnumerable<Etage> GetEtages()
        {
            var dep = utOfWork.EtageRepository.GetAll();
            return dep;
        }

        public Etage GetEtage(int Id_etage)
        {
            var Dept = utOfWork.EtageRepository.GetById(Id_etage);
            return Dept;
        }

        public void CreateEtage(Etage Etage)
        {

            utOfWork.EtageRepository.Add(Etage);

        }

        public void DeleteEtage(int Id_etage)
        {

            var Dept = utOfWork.EtageRepository.GetById(Id_etage);
            utOfWork.EtageRepository.Delete(Dept);

        }


        public void SaveEtage()
        {
            utOfWork.Commit();
        }


        public void UpdateEtageDetached(Etage e)
        {
            utOfWork.EtageRepository.UpdateEtageDetached(e);
        }
        public int FindOrganisationByDelegation(int Id_etage)
        {
            int Dept = utOfWork.EtageRepository.FindOrganisationByBatiment(Id_etage);
            return Dept;

        }
        public int FindPaysByBatiment(int Id_etage)
        {
            int Dept = utOfWork.EtageRepository.FindPaysByBatiment(Id_etage);
            return Dept;
        }
        public int FindRegionByBatiment(int Id_etage)
        {
            int Dept = utOfWork.EtageRepository.FindRegionByBatiment(Id_etage);
            return Dept;

        }
        public int FindGouverneratByBatiment(int Id_etage)
        {
            int Dept = utOfWork.EtageRepository.FindGouverneratByBatiment(Id_etage);
            return Dept;

        }
        public int FindDelegationByBatiment(int Id_etage)
        {
            int Dept = utOfWork.EtageRepository.FindDelegationByBatiment(Id_etage);
            return Dept;

        }

        public Etage FindEtageByID(int id)
        {
            var Dept = utOfWork.EtageRepository.FindEtageByID(id);
            return Dept;

        }
    }

}
public interface IEtageService
{
    int FindRegionByBatiment(int Id_etage);
    int FindPaysByBatiment(int Id_etage);
    int FindGouverneratByBatiment(int Id_etage);
    int FindOrganisationByDelegation(int Id_etage);
    int FindDelegationByBatiment(int Id_etage);
    IEnumerable<Etage> GetEtages();
    Etage GetEtage(int Id_etage);
    void CreateEtage(Etage Dept);
    void DeleteEtage(int Id_etage);

    void UpdateEtageDetached(Etage e);
    Etage FindEtageByID(int id);

    void SaveEtage();


}




