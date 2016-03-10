
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
        public void UpdateCategorie_materielDetached(Categorie e)
        {
            Categorie existing = this.DataContext.Categorie.Find(e.Id_categorie);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public void UpdateCategorie_DesignationDetached(Sous_categorie e)
        {
            Sous_categorie existing = FindCategorie_DesignationById(e.id_sous_categorie);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
          
        }
        public void UpdateCategorie_ModeleDetached(Modele e)
        {
            Modele existing = FindCategorie_ModeleById(e.IdModele);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public void UpdateSous_ModeleDetached(Sous_modele e)
        {
            Sous_modele existing = FindSous_ModeleById(e.Id_sous_Modele);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public void UpdateMarqueDetached(Marque e)
        {
            Marque existing = FindMarqueById(e.IdMarque);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public Categorie FindCategorie_materielByNom(String id)
        {

            var pers = (from p in DataContext.Categorie
                        where p.libelle == id
                        select p);
            return pers.FirstOrDefault();
        }

        public Sous_categorie FindCategorie_DesignationById(int id)
        {

            var pers = (from p in DataContext.Sous_categorie
                        where p.id_sous_categorie == id
                        select p);
            return pers.FirstOrDefault();
        }
       
        public Modele FindCategorie_ModeleById(int id)
        {

            var pers = (from p in DataContext.Modele
                        where p.IdModele == id
                        select p);
            return pers.FirstOrDefault();
        }

        public Sous_modele FindSous_ModeleById(int id)
        {

            var pers = (from p in DataContext.Sous_modele
                        where p.Id_sous_Modele== id
                        select p);
            return pers.FirstOrDefault();
        }
        public Marque FindMarqueById(int id)
        {

            var pers = (from p in DataContext.Marque
                        where p.IdMarque == id
                        select p);
            return pers.FirstOrDefault();
        }

        public IEnumerable<Sous_categorie> FindPorduitByID(int id)
        {

            var pers = (from p in DataContext.Sous_categorie
                        where p.Id_categorie == id
                        select p);
            return pers.ToList();
        }


        public IEnumerable<Modele> FindModeleByIdDes(int id)
        {

            var pers = (from p in DataContext.Modele
                        where p.id_sous_categorie == id
                        select p);
            return pers.ToList();
        }
        public IEnumerable<Modele> findModeleByIdDes1(string libe)
        {

            var pers = (from p in DataContext.Modele
                        where p.Sous_categorie.libelle == libe
                        select p);
            return pers.ToList();
        }
        public IEnumerable<Sous_modele> FindSousModeleByIdModele(int id)
        {

            var pers = (from p in DataContext.Sous_modele
                        where p.IdModele == id
                        select p);
            return pers.ToList();
        }

        public IEnumerable<Sous_modele> findSousModeleByLibelleModele(string libe)
        {

            var pers = (from p in DataContext.Sous_modele
                        where p.Modele.libelle == libe
                        select p);
            return pers.ToList();
        }


        public IEnumerable<Marque> FindMarqueByIdSousModele(int id)
        {

            var pers = (from p in DataContext.Marque
                        where p.Id_sous_Modele == id
                        select p);
            return pers.ToList();
        }

        public IEnumerable<Marque> findMarqueByLibelleSousModele(string libe)
        {

            var pers = (from p in DataContext.Marque
                        where p.Sous_modele.Libelle == libe
                        select p);
            return pers.ToList();
        }

        public IEnumerable<Sous_categorie> GetDesignationAll()
        {

            var pers = (from p in DataContext.Sous_categorie
                       
                        select p);
            return pers.ToList();
        }

        public IEnumerable<Modele> GetAllModele()
        {

            var pers = (from p in DataContext.Modele

                        select p);
            return pers.ToList();
        }
        public IEnumerable<Sous_modele> GetAllSousModele()
        {

            var pers = (from p in DataContext.Sous_modele

                        select p);
            return pers.ToList();
        }
        public IEnumerable<Marque> GetAllMarque()
        {

            var pers = (from p in DataContext.Marque

                        select p);
            return pers.ToList();
        }
      
    }


    public interface ICategorieRepository : IRepository<Categorie>
    {
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
        IEnumerable<Modele> findModeleByIdDes1(string libe);
        IEnumerable<Modele> FindModeleByIdDes(int id);
        IEnumerable<Sous_modele> FindSousModeleByIdModele(int id);
        IEnumerable<Sous_modele> findSousModeleByLibelleModele(string libe);
        IEnumerable<Marque> FindMarqueByIdSousModele(int id);
        IEnumerable<Marque> findMarqueByLibelleSousModele(string libe);
        IEnumerable<Sous_categorie> GetDesignationAll();
        IEnumerable<Modele> GetAllModele();
        IEnumerable<Sous_modele> GetAllSousModele();
        IEnumerable<Marque> GetAllMarque();
    }



}

