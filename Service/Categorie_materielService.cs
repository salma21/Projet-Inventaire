using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    
    public class Categorie_materielService : ICategorie_materielService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public Categorie_materielService() { }

        public IEnumerable<Categorie> GetCategorie_materiels()
        {
            var Dept = utOfWork.CategorieRepository.GetAll();
            return Dept;
        }

        public IEnumerable<Sous_categorie> GetCategorie_Designations()
        {
            var Dept = utOfWork.CategorieRepository.GetDesignationAll();
            return Dept;
        }

        public IEnumerable<Modele> GetAllModeles()
        {
            var Dept = utOfWork.CategorieRepository.GetAllModele();
            return Dept;
        }
        public Categorie FindCategorie_materielByNom(String id)

        {
            var Dept = utOfWork.CategorieRepository.FindCategorie_materielByNom(id);
            return Dept;
        }
        public Categorie GetCategorie_materiel(int Id_categorie)
        {
            var Dept = utOfWork.CategorieRepository.GetById(Id_categorie);
            return Dept;
        }


        public void CreateCategorie_materiel(Categorie Categorie_materiel)
        {

            utOfWork.CategorieRepository.Add(Categorie_materiel);

        }
        public void DeleteCategorie_materiel(int Id_categorie)
        {

            var Dept = utOfWork.CategorieRepository.GetById(Id_categorie);
            utOfWork.CategorieRepository.Delete(Dept);

        }


        public void SaveCategorie_materiel()
        {
            utOfWork.Commit();
        }

        public void UpdateCategorie_materielDetached(Categorie e)
        {
            utOfWork.CategorieRepository.UpdateCategorie_materielDetached(e);
        }

        public void UpdateCategorie_DesignationDetached(Sous_categorie e)
        {
            utOfWork.CategorieRepository.UpdateCategorie_DesignationDetached(e);
        }

        public void UpdateCategorie_ModeleDetached(Modele e)
        {
            utOfWork.CategorieRepository.UpdateCategorie_ModeleDetached(e);
        }
        public IEnumerable<Sous_categorie> FindPorduitByID(int id)
        {
            var dep = utOfWork.CategorieRepository.FindPorduitByID(id);
            return dep;
        }
        public IEnumerable<Modele> FindModeleByIdDes(int id)
        {
            var dep = utOfWork.CategorieRepository.FindModeleByIdDes(id);
            return dep;
        }
        public Modele FindCategorie_ModeleById(int Id_categorie)
        {
            var Dept = utOfWork.CategorieRepository.FindCategorie_ModeleById(Id_categorie);
            return Dept;
        }
        public Sous_categorie FindCategorie_DesignationById(int Id_categorie)
        {
            var Dept = utOfWork.CategorieRepository.FindCategorie_DesignationById(Id_categorie);
            return Dept;
        }

    }
    public interface ICategorie_materielService
    {
        Sous_categorie FindCategorie_DesignationById(int Id_categorie);
        Modele FindCategorie_ModeleById(int Id_categorie);
        IEnumerable<Modele> FindModeleByIdDes(int id);
        IEnumerable<Sous_categorie> FindPorduitByID(int id);
        void UpdateCategorie_ModeleDetached(Modele e);
        void UpdateCategorie_DesignationDetached(Sous_categorie e);
        IEnumerable<Categorie> GetCategorie_materiels();
        Categorie GetCategorie_materiel(int Id_categorie);
        void CreateCategorie_materiel(Categorie Dept);
        void DeleteCategorie_materiel(int id);
        IEnumerable<Modele> GetAllModeles();
        IEnumerable<Sous_categorie> GetCategorie_Designations();
        void UpdateCategorie_materielDetached(Categorie e);
        Categorie FindCategorie_materielByNom(String id);
        void SaveCategorie_materiel();
       

    }

}

