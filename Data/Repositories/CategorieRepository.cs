
using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{

    public class CategorieRepository : RepositoryBase<Categorie>, ICategorieRepository
    {
        public CategorieRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateCategorieDetached(Categorie e)
        {
            Categorie existing = this.DataContext.Categorie.Find(e.Id_categorie);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public void UpdateCategorie_DesignationDetached(CategorieDesignation e)
        {
            CategorieDesignation existing = FindCategorie_DesignationById(e.Id_categorie);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public void UpdateCategorie_ModeleDetached(Sous_categorie e)
        {
            Sous_categorie existing = FindCategorie_ModeleById(e.Id_categorie);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public Categorie FindCategorieByNom(String  id)
        {

            var pers = (from p in DataContext.Categorie
                        where p.libelle == id
                        select p);
            return pers.FirstOrDefault();
        }

        public CategorieDesignation FindCategorie_DesignationById(int id)
        {

            var pers = (from p in DataContext.CategorieDesignation
                        where p.id_categorie_Designation == id
                        select p);
            return pers.FirstOrDefault();
        }

        public Sous_categorie FindCategorie_ModeleById(int id)
        {

            var pers = (from p in DataContext.Sous_categorie
                        where p.IdSousCategorie == id
                        select p);
            return pers.FirstOrDefault();
        }



        public IEnumerable<CategorieDesignation> FindPorduitByID(int id)
        {

            var pers = (from p in DataContext.CategorieDesignation
                        where p.Id_categorie == id
                        select p);
            return pers.ToList();
        }


        public IEnumerable<CategorieDesignation> GetDesignationAll()
        {

            var pers = (from p in DataContext.CategorieDesignation
                       
                        select p);
            return pers.ToList();
        }

        public IEnumerable<Sous_categorie> GetAllModele()
        {

            var pers = (from p in DataContext.Sous_categorie

                        select p);
            return pers.ToList();
        }

        public IEnumerable<Sous_categorie> FindModeleByIdDes(int id)
        {

            var pers = (from p in DataContext.Sous_categorie
                        where p.id_categorie_Designation == id
                        select p);
            return pers.ToList();
        }
    }


    public interface ICategorieRepository : IRepository<Categorie>
    {
        void UpdateCategorie_ModeleDetached(Sous_categorie e);
        void UpdateCategorie_DesignationDetached(CategorieDesignation e);
        CategorieDesignation FindCategorie_DesignationById(int id);
        Sous_categorie FindCategorie_ModeleById(int id);
        IEnumerable<Sous_categorie> FindModeleByIdDes(int id);
        Categorie FindCategorieByNom(String id);
        void UpdateCategorieDetached(Categorie e);
        IEnumerable<CategorieDesignation> FindPorduitByID(int id);
        IEnumerable<CategorieDesignation> GetDesignationAll();
        IEnumerable<Sous_categorie> GetAllModele();
    }



}

