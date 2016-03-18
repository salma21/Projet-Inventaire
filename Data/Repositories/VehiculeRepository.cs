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
  public  class VehiculeRepository : RepositoryBase<Vehicule>, IVehiculeRepository
    {
        public VehiculeRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        //public void UpdateVehiculeDetached(Vehicule e)
        //{
        //    Vehicule existing = this.DataContext.Vehicule.Find(e.Id_Vehicule);
        //    ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
        //    this.DataContext.Entry(e).State = EntityState.Modified;
        //}

        public void UpdateVehiculeDetached(Vehicule e)
        {
            Vehicule existing = findVehiculeByID(e.Id_Vehicule);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public int FindFournisseurByContrat(int id)
        {

            var veh = (from v in DataContext.Contrat
                        where v.Id_contrat == id
                        select v);
            return (int)veh.FirstOrDefault().Id_fournisseur;
        }




        public int FindBatimentByParcAuto(int id)
        {

            var veh = (from v in DataContext.Parc_auto
                       where v.Id_parc == id
                       select v);

           
            return (int)veh.FirstOrDefault().idBatiment;

        }


        public Vehicule findVehiculeByID(int id)
        {

            var pers = (from p in this.DataContext.Vehicule
                        where p.Id_Vehicule == id
                        select p).FirstOrDefault();
            return pers;


        }
    }


    public interface IVehiculeRepository : IRepository<Vehicule>
    {

        void UpdateVehiculeDetached(Vehicule e);
        int FindFournisseurByContrat(int id);

        int FindBatimentByParcAuto(int id);
        Vehicule findVehiculeByID(int id);
    }

}

