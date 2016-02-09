using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    
    public class CategorieService : ICategorieService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public CategorieService() { }

        public IEnumerable<Categorie> GetCategories()
        {
            var Dept = utOfWork.CategorieRepository.GetAll();
            return Dept;
        }

        public IEnumerable<CategorieDesignation> GetCategorie_Designations()
        {
            var Dept = utOfWork.CategorieRepository.GetDesignationAll();
            return Dept;
        }

        public IEnumerable<Sous_categorie> GetAllModeles()
        {
            var Dept = utOfWork.CategorieRepository.GetAllModele();
            return Dept;
        }
        public Categorie FindCategorieByNom(String id)

        {
            var Dept = utOfWork.CategorieRepository.FindCategorieByNom(id);
            return Dept;
        }
        public Categorie GetCategorie(int Id_categorie)
        {
            var Dept = utOfWork.CategorieRepository.GetById(Id_categorie);
            return Dept;
        }


        public void CreateCategorie(Categorie Categorie)
        {

            utOfWork.CategorieRepository.Add(Categorie);

        }
        public void DeleteCategorie(int Id_categorie)
        {

            var Dept = utOfWork.CategorieRepository.GetById(Id_categorie);
            utOfWork.CategorieRepository.Delete(Dept);

        }


        public void SaveCategorie()
        {
            utOfWork.Commit();
        }

        public void UpdateCategorieDetached(Categorie e)
        {
            utOfWork.CategorieRepository.UpdateCategorieDetached(e);
        }

        public void UpdateCategorie_DesignationDetached(CategorieDesignation e)
        {
            utOfWork.CategorieRepository.UpdateCategorie_DesignationDetached(e);
        }

        public void UpdateCategorie_ModeleDetached(Sous_categorie e)
        {
            utOfWork.CategorieRepository.UpdateCategorie_ModeleDetached(e);
        }
        public IEnumerable<CategorieDesignation> FindPorduitByID(int id)
        {
            var dep = utOfWork.CategorieRepository.FindPorduitByID(id);
            return dep;
        }
        public IEnumerable<Sous_categorie> FindModeleByIdDes(int id)
        {
            var dep = utOfWork.CategorieRepository.FindModeleByIdDes(id);
            return dep;
        }
        public Sous_categorie FindCategorie_ModeleById(int Id_categorie)
        {
            var Dept = utOfWork.CategorieRepository.FindCategorie_ModeleById(Id_categorie);
            return Dept;
        }
        public CategorieDesignation FindCategorie_DesignationById(int Id_categorie)
        {
            var Dept = utOfWork.CategorieRepository.FindCategorie_DesignationById(Id_categorie);
            return Dept;
        }

    }
    public interface ICategorieService
    {
        CategorieDesignation FindCategorie_DesignationById(int Id_categorie);
        Sous_categorie FindCategorie_ModeleById(int Id_categorie);
        IEnumerable<Sous_categorie> FindModeleByIdDes(int id);
        IEnumerable<CategorieDesignation> FindPorduitByID(int id);
        void UpdateCategorie_ModeleDetached(Sous_categorie e);
        void UpdateCategorie_DesignationDetached(CategorieDesignation e);
        IEnumerable<Categorie> GetCategories();
        Categorie GetCategorie(int Id_categorie);
        void CreateCategorie(Categorie Dept);
        void DeleteCategorie(int id);
        IEnumerable<Sous_categorie> GetAllModeles();
        IEnumerable<CategorieDesignation> GetCategorie_Designations();
        void UpdateCategorieDetached(Categorie e);
        Categorie FindCategorieByNom(String id);
        void SaveCategorie();
       

    }

}

