using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Infrastructure;

namespace Service
{
  public  class PaysService : IPaysService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public PaysService() { }

        public IEnumerable<Pays> GetPays()
        {
            var dep = utOfWork.PaysRepository.GetAll();
            return dep;
        }

        public Pays GetPays(int id)
        {
            var Dept = utOfWork.PaysRepository.GetById(id);
            return Dept;
        }

        public void CreatePays(Pays Pays)
        {

            utOfWork.PaysRepository.Add(Pays);


        }
        public void DeletePays(int id)
        {

            var Dept = utOfWork.PaysRepository.GetById(id);
            utOfWork.PaysRepository.Delete(Dept);



        }



        public void SavePays()
        {
            utOfWork.Commit();
        }


        public void UpdatePaysDetached(Pays e)
        {
            utOfWork.PaysRepository.UpdatePaysDetached(e);
        }

       
    }
    public interface IPaysService
    {
        IEnumerable<Pays> GetPays();
        Pays GetPays(int id);
        void CreatePays(Pays Dep);
        void DeletePays(int id);

        void UpdatePaysDetached(Pays e);


        void SavePays();

    }
}

