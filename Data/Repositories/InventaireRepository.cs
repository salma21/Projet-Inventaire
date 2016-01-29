
using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;


namespace Data.Repositories
{

    public class InventaireRepository : RepositoryBase<Inventaire>, IInventaireRepository
    {
        public InventaireRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateInventaireDetached(Inventaire e)
        {
            Inventaire existing = this.DataContext.Inventaire.Find(e.Id_inventaire);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

     

        public IEnumerable<Batiment> FindBatimentByDelegation(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idDelegation == id
                        select p);
            return pers.ToList();
        }

        public IEnumerable<Etage> FindEtageByBatiment(int id)
        {
            var pers = (from p in DataContext.Etage
                        where p.idBatiment == id
                        select p);
            return pers.ToList();
        }




        public IEnumerable<Bien> FindBienByEtage(int id)
        {
            var pers = (from p in DataContext.Bien
                        where p.Id_etage == id
                        select p);
            return pers.ToList();
        }

        public Inventaire FindInvById(int id)
        {
            var pers = (from p in DataContext.Inventaire
                        where p.Id_inventaire == id
                        select p);
            return pers.FirstOrDefault();
        }
    }


    public interface IInventaireRepository : IRepository<Inventaire>
    {

        void UpdateInventaireDetached(Inventaire e);

        IEnumerable<Batiment> FindBatimentByDelegation(int id);

        IEnumerable<Etage> FindEtageByBatiment(int id);

        IEnumerable<Bien> FindBienByEtage(int id);
        Inventaire FindInvById(int id);
    }


   



}











