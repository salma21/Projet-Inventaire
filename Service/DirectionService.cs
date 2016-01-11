using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Infrastructure;


namespace Service
{
   public class DirectionService : IDirectionService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public DirectionService() { }

        public IEnumerable<Direction> GetDirection()
        {
            var dep = utOfWork.DirectionRepository.GetAll();
            return dep;
        }

        public Direction GetDirection(int id)
        {
            var Dept = utOfWork.DirectionRepository.GetById(id);
            return Dept;
        }

        public void CreateDirection(Direction Direction)
        {

            utOfWork.DirectionRepository.Add(Direction);


        }
        public void DelelteDirection(int id)
        {

            var Dept = utOfWork.DirectionRepository.GetById(id);
            utOfWork.DirectionRepository.Delete(Dept);



        }



        public void SaveDirection()
        {
            utOfWork.Commit();
        }


        public void UpdateDirectionDetached(Direction e)
        {
            utOfWork.DirectionRepository.UpdateDirectionDetached(e);
        }


    }
    public interface IDirectionService
    {
        IEnumerable<Direction> GetDirection();
        Direction GetDirection(int id);
        void CreateDirection(Direction Dep);
        void DelelteDirection(int id);

        void UpdateDirectionDetached(Direction e);


        void SaveDirection();

    }
}

