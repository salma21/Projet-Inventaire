using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BureauService : IBureauService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public BureauService() { }

        public IEnumerable<Bureau> GetBureaux()
        {
            var dep = utOfWork.BureauRepository.GetAll();
            return dep;
        }

        public Bureau GetBureau(int id)
        {
            var Dept = utOfWork.BureauRepository.GetById(id);
            return Dept;
        }

        public void CreateBureau(Bureau bureau)
        {

            utOfWork.BureauRepository.Add(bureau);


        }
        public void DeleteBureau(int id)
        {

            var Dept = utOfWork.BureauRepository.GetById(id);
            utOfWork.BureauRepository.Delete(Dept);

        }

        public IEnumerable<Bureau> FindBureauByBatiment(int id) {
            var dep = utOfWork.BureauRepository.FindBureauByBatiment(id);
            return dep;


        }
        public Bureau FindBureauByID(int id)
        {
            var Dept = utOfWork.BureauRepository.FindBureauByID(id);
            return Dept;

        }

        public IEnumerable<Etage> findEtageByBatiment(int id)
        {
            var Dept = utOfWork.BureauRepository.findEtageByBatiment(id);
            return Dept;

        }
        public IEnumerable<Bureau> findBureauByEtage(int id)
        {
            var Dept = utOfWork.BureauRepository.findBureauByEtage(id);
            return Dept;

        }

        public void SaveBureau()
        {
            utOfWork.Commit();
        }


        public void UpdateBureauDetached(Bureau e)
        {
            utOfWork.BureauRepository.UpdateBureauDetached(e);
        }
        public int FindMaxID()
        {
           int i = utOfWork.BureauRepository.FindMaxID();
            return i; 
        }



    }
    public interface IBureauService
    {
        Bureau FindBureauByID(int id);
        IEnumerable<Bureau> FindBureauByBatiment(int id);
        IEnumerable<Bureau> GetBureaux();
        Bureau GetBureau(int id);
        void CreateBureau(Bureau Dept);
        void DeleteBureau(int id);
        int FindMaxID();
        void UpdateBureauDetached(Bureau e);
        IEnumerable<Etage> findEtageByBatiment(int id);
        IEnumerable<Bureau> findBureauByEtage(int id);
        void SaveBureau();







    }

}


