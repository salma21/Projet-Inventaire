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

        public IEnumerable<Categorie_materiel> GetCategorie_materiels()
        {
            var Dept = utOfWork.Categorie_materielRepository.GetAll();
            return Dept;
        }
        public Categorie_materiel FindCategorie_materielByNom(String id)

        {
            var Dept = utOfWork.Categorie_materielRepository.FindCategorie_materielByNom(id);
            return Dept;
        }
        public Categorie_materiel GetCategorie_materiel(int Id_categorie)
        {
            var Dept = utOfWork.Categorie_materielRepository.GetById(Id_categorie);
            return Dept;
        }

        public void CreateCategorie_materiel(Categorie_materiel Categorie_materiel)
        {

            utOfWork.Categorie_materielRepository.Add(Categorie_materiel);

        }
        public void DeleteCategorie_materiel(int Id_categorie)
        {

            var Dept = utOfWork.Categorie_materielRepository.GetById(Id_categorie);
            utOfWork.Categorie_materielRepository.Delete(Dept);

        }


        public void SaveCategorie_materiel()
        {
            utOfWork.Commit();
        }

        public void UpdateCategorie_materielDetached(Categorie_materiel e)
        {
            utOfWork.Categorie_materielRepository.UpdateCategorie_materielDetached(e);
        }

    }
    public interface ICategorie_materielService
    {
        IEnumerable<Categorie_materiel> GetCategorie_materiels();
        Categorie_materiel GetCategorie_materiel(int Id_categorie);
        void CreateCategorie_materiel(Categorie_materiel Dept);
        void DeleteCategorie_materiel(int id);

        void UpdateCategorie_materielDetached(Categorie_materiel e);
        Categorie_materiel FindCategorie_materielByNom(String id);
        void SaveCategorie_materiel();


    }

}

