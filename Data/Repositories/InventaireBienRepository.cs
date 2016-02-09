using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Domain;
using Data.Infrastructure;

namespace Data.Repositories
{
    class InventaireBienRepository : RepositoryBase<InventaireBien>, IInventaireBienRepository
    {
        public InventaireBienRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateInventaireBienDetached(InventaireBien e)
        {
            InventaireBien existing = FindBienByID(e.Id_bien);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public InventaireBien FindBienByID(int id)
        {

            var pers = (from p in DataContext.InventaireBien
                        where p.Id_bien == id
                        select p);
            return pers.FirstOrDefault();
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


    }

    public interface IInventaireBienRepository : IRepository<InventaireBien>
    {
        void UpdateInventaireBienDetached(InventaireBien e);
       InventaireBien FindBienByID(int id);

        IEnumerable<Batiment> FindBatimentByDelegation(int id);

        IEnumerable<Etage> FindEtageByBatiment(int id);

        IEnumerable<Bien> FindBienByEtage(int id);
    }
}