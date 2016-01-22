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
    class InventaireVehRepository : RepositoryBase<Association_31>, IInventaireVehRepository
    {
        public InventaireVehRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateInventaireVehDetached(Association_31 e)
        {
            Association_31 existing = FindVehByID(e.Id_Vehicule);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public Association_31 FindVehByID(int id)
        {

            var pers = (from p in DataContext.Association_31
                        where p.Id_Vehicule == id
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

        public IEnumerable<Parc_auto> FindParcByBatiment(int id)
        {
            var pers = (from p in DataContext.Parc_auto
                        where p.idBatiment == id
                        select p);
            return pers.ToList();
        }




        public IEnumerable<Vehicule> FindVehByParc(int id)
        {
            var pers = (from p in DataContext.Vehicule
                        where p.Id_parc == id
                        select p);
            return pers.ToList();
        }





    }
    public interface IInventaireVehRepository : IRepository<Association_31>
    {
        void UpdateInventaireVehDetached(Association_31 e);
        Association_31 FindVehByID(int id);
        IEnumerable<Batiment> FindBatimentByDelegation(int id);
        IEnumerable<Parc_auto> FindParcByBatiment(int id);
        IEnumerable<Vehicule> FindVehByParc(int id);
    }
}
