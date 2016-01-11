using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FournisseurService : IFournisseurService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public FournisseurService() { }

        public IEnumerable<Fournisseur> GetFournisseurs()
        {
            var dep = utOfWork.FournisseurRepository.GetAll();
            return dep;
        }

        public Fournisseur GetFournisseur(int id)
        {
            var Dept = utOfWork.FournisseurRepository.GetById(id);
            return Dept;
        }

        public void CreateFournisseur(Fournisseur Fournisseur)
        {

            utOfWork.FournisseurRepository.Add(Fournisseur);


        }
        public void DeleteFournisseur(int id)
        {

            var Dept = utOfWork.FournisseurRepository.GetById(id);
            utOfWork.FournisseurRepository.Delete(Dept);



        }



        public void SaveFournisseur()
        {
            utOfWork.Commit();
        }


        public void UpdateFournisseurDetached(Fournisseur e)
        {
            utOfWork.FournisseurRepository.UpdateFournisseurDetached(e);
        }



        public Fournisseur FindFourByID(int id)

        {
            var Dept = utOfWork.FournisseurRepository.FindFourByID(id);
            return Dept;
        }




    }
    public interface IFournisseurService
    {
        IEnumerable<Fournisseur> GetFournisseurs();
        Fournisseur GetFournisseur(int id);
        void CreateFournisseur(Fournisseur Dept);
        void DeleteFournisseur(int id);

        void UpdateFournisseurDetached(Fournisseur e);

        Fournisseur FindFourByID(int id);
        void SaveFournisseur();







    }

}


