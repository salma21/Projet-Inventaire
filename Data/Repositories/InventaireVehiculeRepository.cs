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
    class InventaireVehiculeRepository : RepositoryBase<InventaireVehicule>, IInventaireVehRepository
    {
        public InventaireVehiculeRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateInventaireVehDetached(InventaireVehicule e)
        {
            InventaireVehicule existing = FindVehiculeByID(e.Id_Vehicule);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public InventaireVehicule FindVehiculeByID(int id)
        {

            var pers = (from p in DataContext.InventaireVehicule
                        where p.Id_Vehicule == id
                        select p);
            return pers.FirstOrDefault();
        }

        public Vehicule GetVehiculeByID(int id)
        {

            var pers = (from p in DataContext.Vehicule
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




        public IEnumerable<Vehicule> FindVehiculeByParc(int id)
        {
            var pers = (from p in DataContext.Vehicule
                        where p.Id_parc == id
                        select p);
            return pers.ToList();
        }





    }
    public interface IInventaireVehiculeRepository : IRepository<InventaireVehicule>
    {
        void UpdateInventaireVehDetached(InventaireVehicule e);
        InventaireVehicule FindVehiculeByID(int id);
        IEnumerable<Batiment> FindBatimentByDelegation(int id);
        IEnumerable<Parc_auto> FindParcByBatiment(int id);
        IEnumerable<Vehicule> FindVehiculeByParc(int id);
        Vehicule GetVehiculeByID(int id);
    }
}
