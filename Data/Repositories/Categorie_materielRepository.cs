
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

    public class Categorie_materielRepository : RepositoryBase<Categorie_materiel>, ICategorie_materielRepository
    {
        public Categorie_materielRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateCategorie_materielDetached(Categorie_materiel e)
        {
            Categorie_materiel existing = this.DataContext.Categorie_materiel.Find(e.Id_categorie);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public Categorie_materiel FindCategorie_materielByNom(String  id)
        {

            var pers = (from p in DataContext.Categorie_materiel
                        where p.libelle == id
                        select p);
            return pers.FirstOrDefault();
        }
    }


    public interface ICategorie_materielRepository : IRepository<Categorie_materiel>
    {
        Categorie_materiel FindCategorie_materielByNom(String id);
        void UpdateCategorie_materielDetached(Categorie_materiel e);

    }



}

