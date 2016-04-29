using System;
using System.Collections.Generic;


using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{

    public class LocalitéService : ILocalitéService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public LocalitéService() { }

        public IEnumerable<Localité> GetLocalités()
        {
            var dep = utOfWork.LocalitéRepository.GetAll();
            return dep;
        }

        public Localité GetLocalité(int id)
        {
            var Dept = utOfWork.LocalitéRepository.GetById(id);
            return Dept;
        }
        public Localité FindlocalByID(int id)
        {
            var Dept = utOfWork.LocalitéRepository.FindlocalByID(id);
            return Dept;
        }
        public void CreateLocalité(Localité Localité)
        {

            utOfWork.LocalitéRepository.Add(Localité);

        }


        public List<Localité> GetLocByIdDelegation(string Localité)
        {

           var jj = utOfWork.LocalitéRepository.GetLocByIdDelegation(Localité);
            return jj;

        }

        public int GetCPByLocalite(int Localité)
        {

           var cp= utOfWork.LocalitéRepository.GetCPByLocalite(Localité);
            return cp;

        }
        public void DeleteLocalité(int id)
        {

            var Dept = utOfWork.LocalitéRepository.GetById(id);
            utOfWork.LocalitéRepository.Delete(Dept);

        }


        public void SaveLocalité()
        {
            utOfWork.Commit();
        }


        public void UpdateLocalitéDetached(Localité e)
        {
            utOfWork.LocalitéRepository.UpdateLocalitéDetached(e);
        }

    }
    public interface ILocalitéService
    {
        List<Localité> GetLocByIdDelegation(string Localité);
        int GetCPByLocalite(int Localité);
        IEnumerable<Localité> GetLocalités();
        Localité GetLocalité(int id);
        void CreateLocalité(Localité Dept);
        void DeleteLocalité(int id);

        void UpdateLocalitéDetached(Localité e);
        Localité FindlocalByID(int id);
        void SaveLocalité();


    }

}
