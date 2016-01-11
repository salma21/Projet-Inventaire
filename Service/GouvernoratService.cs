using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Infrastructure;

namespace Service
{
    public class GouvernoratService : IGouvernoratService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public GouvernoratService() { }

        public IEnumerable<Gouvernorat> GetGouvernorat()
        {
            var dep = utOfWork.GouvernoratRepository.GetAll();
            return dep;
        }

        public Gouvernorat GetGouvernorat(int id)
        {
            var Dept = utOfWork.GouvernoratRepository.GetById(id);
            return Dept;
        }

        public Gouvernorat FindGouvByID(int id)
        {
            var Dept = utOfWork.GouvernoratRepository.FindGouvByID(id);
            return Dept;
        }

        public void CreateGouvernorat(Gouvernorat Gouvernorat)
        {
            utOfWork.GouvernoratRepository.Add(Gouvernorat);
        }
        public void DeleteGouvernorat(int id)
        {
            var Dept = utOfWork.GouvernoratRepository.GetById(id);
            utOfWork.GouvernoratRepository.Delete(Dept);
        }

        public void SaveGouvernorat()
        {
            utOfWork.Commit();
        }

        public void UpdateGouvernoratDetached(Gouvernorat e)
        {
            utOfWork.GouvernoratRepository.UpdateGouvernoratDetached(e);
        }

        public IEnumerable<Gouvernorat> FindGouverneratByRegion(int id)
        {
            var dep = utOfWork.GouvernoratRepository.FindGouverneratByRegion(id);
            return dep;
        }
    }
    public interface IGouvernoratService
    {
        IEnumerable<Gouvernorat> GetGouvernorat();
        Gouvernorat GetGouvernorat(int id);
        void CreateGouvernorat(Gouvernorat Dep);
        void DeleteGouvernorat(int id);

        void UpdateGouvernoratDetached(Gouvernorat e);

        Gouvernorat FindGouvByID(int id);
        void SaveGouvernorat();
        IEnumerable<Gouvernorat> FindGouverneratByRegion(int id);
    }
}
