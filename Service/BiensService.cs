using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BiensService : IBiensService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public BiensService() { }

        public IEnumerable<AtbDataTest> GetBienss()
        {
            var dep = utOfWork.BiensRepository.GetAll();
            return dep;
        }
        public IEnumerable<CategorieDesignation> FindPorduitByID(int id)
        {
            var dep = utOfWork.BiensRepository.FindPorduitByID(id);
            return dep;
        }

        public AtbDataTest GetBiens(int id)
        {
            var Dept = utOfWork.BiensRepository.GetById(id);
            return Dept;
        }

        public Bien FindBienByID(int id)
        {
            var Dept = utOfWork.BiensRepository.FindBienByID(id);
            return Dept;
        }

        public void CreateBiens(AtbDataTest Biens)
        {

            utOfWork.BiensRepository.Add(Biens);


        }
        public void DeleteBiens(int id)
        {

            var Dept = utOfWork.BiensRepository.GetById(id);
            utOfWork.BiensRepository.Delete(Dept);



        }



        public void SaveBiens()
        {
            utOfWork.Commit();
        }


        public void UpdateBiensDetached(AtbDataTest e)
        {
            utOfWork.BiensRepository.UpdateBiensDetached(e);
        }

        public void UpdateStockDetached(Stock e)
        {
            utOfWork.BiensRepository.UpdateStockDetached(e);
        }







    }
    public interface IBiensService
    {
        IEnumerable<AtbDataTest> GetBienss();
        AtbDataTest GetBiens(int id);
        void CreateBiens(AtbDataTest Dept);
        void DeleteBiens(int id);
        Bien FindBienByID(int id);
        void UpdateBiensDetached(AtbDataTest e);
        void UpdateStockDetached(Stock e);
        IEnumerable<CategorieDesignation> FindPorduitByID(int id);
        void SaveBiens();







    }

}


