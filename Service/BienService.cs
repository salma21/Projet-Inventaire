using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
 public   class BienService : IBienService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public BienService() { }

        //public IEnumerable<Bien> FindBienByDelgation(int id)
        //{
        //    var dep = utOfWork.BienRepository.FindBienByDelgation(id);
        //    return dep;
        //}

        public IEnumerable<Bien> GetBiens()
        {
            var dep = utOfWork.BienRepository.GetAll();
            return dep;
        }

        public Bien GetBien(int id)
        {
            var Dept = utOfWork.BienRepository.GetById(id);
            return Dept;
        }

        public void CreateBien(Bien Bien)
        {

            utOfWork.BienRepository.Add(Bien);


        }
        public void DeleteBien(int id)
        {

            var Dept = utOfWork.BienRepository.GetById(id);
            utOfWork.BienRepository.Delete(Dept);
        }

        //public Bien FindBienByID(int id)
        //{
        //    var Dept = utOfWork.BienRepository.FindBienByID(id);
        //    return Dept;
        //}
        public int FindMaxIDBien()
        {
            int i = utOfWork.BienRepository.FindMaxIDBien();
            return i;
        }


        public void SaveBien()
        {
            utOfWork.Commit();
        }


        public void UpdateBienDetached(Bien e)
        {
            utOfWork.BienRepository.UpdateBienDetached(e);
        }




    }
    public interface IBienService 
    {
        //Bien FindBienByID(int id);
        IEnumerable<Bien> GetBiens();
        Bien GetBien(int id);
        void CreateBien(Bien Dept);
        void DeleteBien(int id);
        int FindMaxIDBien();
        void UpdateBienDetached(Bien e);

        //IEnumerable<Bien> FindBienByDelgation(int id);
        void SaveBien();


    }
}