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
        public void UpdateVehiculeDetached(Vehicule e)
        {
            Vehicule existing = this.DataContext.Vehicule.Find(e.Id_Vehicule);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public int FindFournisseurByContratGaranti(int id)
        {

            var veh = (from v in DataContext.Contrat_garanti
                        where v.Id_contrat_garanti == id
                        select v);
            return (int)veh.FirstOrDefault().Id_fournisseur;
        }

        public int FindSocieteMaintenanceByContratMaintenance(int id)
        {

            var veh = (from v in DataContext.Contrat_maintenance
                        where v.Id_contrat_maintenance == id
                        select v);
            return veh.FirstOrDefault().Id_societe_maintenance;
        }

        public int FindSocieteAssuranceByContratAssurance(int id)
        {

            var veh = (from v in DataContext.Contrat_assurance
                       where v.Id_contrat_assurance == id
                       select v);
            return (int)veh.FirstOrDefault().Id_societe_assurance;
        }

        public int FindBatimentByParcAuto(int id)
        {

            var veh = (from v in DataContext.Parc_auto
                       where v.Id_parc == id
                       select v);
            return veh.FirstOrDefault().idBatiment;
        }

      
    }


    public interface IVehiculeRepository : IRepository<Vehicule>
    {

        void UpdateVehiculeDetached(Vehicule e);
        int FindFournisseurByContratGaranti(int id);
        int FindSocieteMaintenanceByContratMaintenance(int id);
        int FindSocieteAssuranceByContratAssurance(int id);
        int FindBatimentByParcAuto(int id);

    }

}

