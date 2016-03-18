using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Infrastructure;

namespace Service
{
    public class DelegationService : IDelegationService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public DelegationService() { }

        public IEnumerable<Delegation> GetDelegation()
        {
            var dep = utOfWork.DelegationRepository.GetAll();
            return dep;
        }

        public Delegation GetDelegation(int id)
        {
            var Dept = utOfWork.DelegationRepository.GetById(id);
            return Dept;
        }

        public void CreateDelegation(Delegation Delegation)
        {

            utOfWork.DelegationRepository.Add(Delegation);


        }
        public void DeleteDelegation(int id)
        {

            var Dept = utOfWork.DelegationRepository.GetById(id);
            utOfWork.DelegationRepository.Delete(Dept);

        }

        public Delegation FindDelByID(int id)
        {
            var Dept = utOfWork.DelegationRepository.FindDelByID(id);
            return Dept;
        }

        public void SaveDelegation()
        {
            utOfWork.Commit();
        }
        public IEnumerable<Delegation> FindDelegationtByGouvernerat(int id)
        {
            var dep = utOfWork.DelegationRepository.FindDelegationtByGouvernerat(id);
            return dep;
        }

        public IEnumerable<Delegation> findDelegationtByGouvernerat(string libelle)
        {
            var dep = utOfWork.DelegationRepository.findDelegationtByGouvernerat(libelle);
            return dep;
        }
     
        public void UpdateDelegationDetached(Delegation e)
        {
            utOfWork.DelegationRepository.UpdateDelegationDetached(e);
        }

    }
    public interface IDelegationService
    {
        IEnumerable<Delegation> FindDelegationtByGouvernerat(int id);

        IEnumerable<Delegation> GetDelegation();
        Delegation GetDelegation(int id);
        void CreateDelegation(Delegation Dep);
        void DeleteDelegation(int id);

        void UpdateDelegationDetached(Delegation e);

        Delegation FindDelByID(int id);
        void SaveDelegation();
        IEnumerable<Delegation> findDelegationtByGouvernerat(string libelle);
    }
}


