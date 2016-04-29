using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Data.Repositories
{
    public class MouvementVehiculeRepository : RepositoryBase<MouvementVehicule>, IMouvementVehiculeRepository
    {
        public MouvementVehiculeRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateMouvementVehiculeDetached(MouvementVehicule e)
        {
            MouvementVehicule existing = this.DataContext.MouvementVehicule.Find(e.Id_mouvementV);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

     
        
        public  IEnumerable<Batiment> FindBatimentByDelegation(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idDelegation == id
                        select p);
            return pers.ToList();
        }

        public  IEnumerable<Parc_auto> FindParcByBatiment(int id)
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
      

        public MouvementVehicule FindMouvementVehiculeByID(int id)
        {

            var pers = (from p in DataContext.MouvementVehicule
                        where p.Id_mouvementV == id
                        select p);
            return pers.FirstOrDefault();
        }

    }
    public interface IMouvementVehiculeRepository : IRepository<MouvementVehicule>
    {
        MouvementVehicule FindMouvementVehiculeByID(int id);
        void UpdateMouvementVehiculeDetached(MouvementVehicule e);
        IEnumerable<Batiment> FindBatimentByDelegation(int id);
        IEnumerable<Parc_auto> FindParcByBatiment(int id);
        IEnumerable<Vehicule> FindVehiculeByParc(int id);








    }
}