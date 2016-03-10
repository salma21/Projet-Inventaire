using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BatimentService : IBatimentService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public BatimentService() { }

        public IEnumerable<Batiment> FindBatimentByDelgation(int id)
        {
            var dep = utOfWork.BatimentRepository.FindBatimentByDelgation(id);
            return dep;
        }

        public IEnumerable<Batiment> GetBatiments()
        {
            var dep = utOfWork.BatimentRepository.GetAll();
            return dep;
        }

        public Batiment GetBatiment(int id)
        {
            var Dept = utOfWork.BatimentRepository.GetById(id);
            return Dept;
        }

        public void CreateBatiment(Batiment Batiment)
        {

            utOfWork.BatimentRepository.Add(Batiment);


        }
        public void DeleteBatiment(int id)
        {

            var Dept = utOfWork.BatimentRepository.GetById(id);
            utOfWork.BatimentRepository.Delete(Dept);
        }

        public Batiment FindBatimentByID(int id)
        {
            var Dept = utOfWork.BatimentRepository.FindBatimentByID(id);
            return Dept;
        }



        public void SaveBatiment()
        {
            utOfWork.Commit();
        }


        public void UpdateBatimentDetached(Batiment e)
        {
            utOfWork.BatimentRepository.UpdateBatimentDetached(e);
        }


    }
    public interface IBatimentService
    {
        Batiment FindBatimentByID(int id);
        IEnumerable<Batiment> GetBatiments();
        Batiment GetBatiment(int id);
        void CreateBatiment(Batiment Dept);
        void DeleteBatiment(int id);

        void UpdateBatimentDetached(Batiment e);

        IEnumerable<Batiment> FindBatimentByDelgation(int id);
        void SaveBatiment();







    }

}


