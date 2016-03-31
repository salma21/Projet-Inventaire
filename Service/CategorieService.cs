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




        public Categorie GetCategorie_materiel(int Id_categorie)
        {
            var Dept = utOfWork.CategorieRepository.GetById(Id_categorie);
            return Dept;
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


      public  void UpdateSous_ModeleDetached(Sous_modele e)
        {
            utOfWork.CategorieRepository.UpdateSous_ModeleDetached(e);
        }
       public void UpdateMarqueDetached(Marque e)
        {
            utOfWork.CategorieRepository.UpdateMarqueDetached(e);
        }
       


        public Categorie FindCategorie_materielByNom(String id)

        {
            var Dept = utOfWork.CategorieRepository.FindCategorie_materielByNom(id);
            return Dept;
        }

        public Sous_categorie FindCategorie_DesignationById(int id_sous_categorie)
        {
            var Dept = utOfWork.CategorieRepository.FindCategorie_DesignationById(id_sous_categorie);
            return Dept;
         
        }
        public Modele FindCategorie_ModeleById(int Id_categorie)
        {
            var Dept = utOfWork.CategorieRepository.FindCategorie_ModeleById(Id_categorie);
            return Dept;
        }


        public Sous_modele FindSous_ModeleById(int Id_categorie)
        {
            var Dept = utOfWork.CategorieRepository.FindSous_ModeleById(Id_categorie);
            return Dept;
        }

        public Marque FindMarqueById(int Id_categorie)
        {
            var Dept = utOfWork.CategorieRepository.FindMarqueById(Id_categorie);
            return Dept;
        }






        public IEnumerable<Sous_categorie> FindPorduitByID(int id)
        {
            var dep = utOfWork.CategorieRepository.FindPorduitByID(id);
            return dep;
        }

       public IEnumerable<Modele> findModeleBySousCategorie(string libelle)
        {
            var dep = utOfWork.CategorieRepository.findModeleByIdDes1(libelle);
            return dep;
        }
        public IEnumerable<Modele> FindModeleByIdDes(int id)
        {
            var dep = utOfWork.CategorieRepository.FindModeleByIdDes(id);
            return dep;
        }

        public IEnumerable<Sous_modele> FindSousModeleByIdModele(int id)
        {
            var dep = utOfWork.CategorieRepository.FindSousModeleByIdModele(id);
            return dep;
        }
        public IEnumerable<Sous_modele> findSousModeleByLibelleModele(string libelle)
        {
            var dep = utOfWork.CategorieRepository.findSousModeleByLibelleModele(libelle);
            return dep;
        }
        public IEnumerable<Marque> FindMarqueByIdSousModele(int id)
        {
            var dep = utOfWork.CategorieRepository.FindMarqueByIdSousModele(id);
            return dep;
        }

        public IEnumerable<Marque> findMarqueBylibelleSousModele(string libelle)
        {
            var dep = utOfWork.CategorieRepository.findMarqueByLibelleSousModele(libelle);
            return dep;
        }





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
        public IEnumerable<Sous_modele> GetAllSousModele()
        {
            var Dept = utOfWork.CategorieRepository.GetAllSousModele();
            return Dept;
        }

        public IEnumerable<Marque> GetAllMarque()
        {
            var Dept = utOfWork.CategorieRepository.GetAllMarque();
            return Dept;
        }






        public void SaveSousCategorie()
        {
            
            utOfWork.Commit();
        }

        public void SaveSousModele()
        {

            utOfWork.Commit();
        }
        public void SaveMarque()
        {

            utOfWork.Commit();
        }


        public void SaveCategorie_materiel()
        {
            utOfWork.Commit();
        }


        public void CreateCategorie_materiel(Categorie Categorie)
        {

            utOfWork.CategorieRepository.Add(Categorie);

        }
        public void DeleteCategorie_materiel(int Id_categorie)
        {

            var Dept = utOfWork.CategorieRepository.GetById(Id_categorie);
            utOfWork.CategorieRepository.Delete(Dept);

        }



    }
    public interface ICategorieService
    {
        Categorie GetCategorie_materiel(int Id_categorie);
        void UpdateCategorie_materielDetached(Categorie e);
        void UpdateCategorie_DesignationDetached(Sous_categorie e);
        void UpdateCategorie_ModeleDetached(Modele e);
        void UpdateSous_ModeleDetached(Sous_modele e);
        void UpdateMarqueDetached(Marque e);
        Categorie FindCategorie_materielByNom(String id);
        Sous_categorie FindCategorie_DesignationById(int id);
        Modele FindCategorie_ModeleById(int id);
        Sous_modele FindSous_ModeleById(int id);
        Marque FindMarqueById(int id);

        
        IEnumerable<Sous_categorie> FindPorduitByID(int id);
        
        IEnumerable<Modele> findModeleBySousCategorie(string libelle);
        IEnumerable<Modele> FindModeleByIdDes(int id);
        IEnumerable<Sous_modele> FindSousModeleByIdModele(int id);
        IEnumerable<Sous_modele> findSousModeleByLibelleModele(string libelle);
        IEnumerable<Marque> FindMarqueByIdSousModele(int id);
        IEnumerable<Marque> findMarqueBylibelleSousModele(string libelle);
        IEnumerable<Categorie> GetCategorie_materiels();
        IEnumerable<Sous_categorie> GetCategorie_Designations();
        IEnumerable<Modele> GetAllModeles();
        IEnumerable<Sous_modele> GetAllSousModele();
       
        IEnumerable<Marque> GetAllMarque();
        void SaveMarque();
        void SaveSousModele();
        void SaveCategorie_materiel();
        void SaveSousCategorie();
        void CreateCategorie_materiel(Categorie Categorie);
        void DeleteCategorie_materiel(int Id_categorie);
    }

}

