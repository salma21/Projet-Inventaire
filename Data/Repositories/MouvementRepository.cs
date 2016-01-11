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
    public class MouvementRepository : RepositoryBase<Mouvement>, IMouvementRepository
    {
        public MouvementRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateMouvementDetached(Mouvement e)
        {
            Mouvement existing = this.DataContext.Mouvement.Find(e.Id_mouvement);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public int FindOrganisationByBatiment(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idOrganisation == id
                        select p);
            return (int)pers.FirstOrDefault().idOrganisation;
        }

        public int FindDelegationByBatiment(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idDelegation == id
                        select p);
            return pers.FirstOrDefault().idDelegation;
        }
        public int FindGouverneratByBatiment(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idGouvernorat == id
                        select p);
            return (int)pers.FirstOrDefault().idGouvernorat;
        }
        public int FindRegionByBatiment(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idRegion == id
                        select p);
            return (int)pers.FirstOrDefault().idRegion;
        }

        public int FindPaysByBatiment(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idPays == id
                        select p);
            return (int)pers.FirstOrDefault().idPays;
        }

        public IEnumerable<Etage> FindEtageByBatiment(int id)
        {
            var pers = (from p in DataContext.Etage
                        where p.idBatiment == id
                        select p);
            return pers.ToList();
        }


        public IEnumerable<Bureau> FindBureauByEtage(int id)
        {
            var pers = (from p in DataContext.Bureau
                        where p.Id_etage == id
                        select p);
            return pers.ToList();
        }

        public IEnumerable<Bien> FindBienByBureau(int id)
        {
            var pers = (from p in DataContext.Bien
                        where p.Id_bureau == id
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
    public interface IMouvementRepository : IRepository<Mouvement>
    {

        void UpdateMouvementDetached(Mouvement e);
        int FindDelegationByBatiment(int id);
        int FindGouverneratByBatiment(int id);
        int FindRegionByBatiment(int id);
        int FindOrganisationByBatiment(int id);
       
        int FindPaysByBatiment(int id);
        IEnumerable<Etage> FindEtageByBatiment(int id);
        IEnumerable<Bureau> FindBureauByEtage(int id);
        IEnumerable<Bien> FindBienByBureau(int id);
        IEnumerable<Parc_auto> FindParcByBatiment(int id);
        IEnumerable<Vehicule> FindVehiculeByParc(int id);








    }
}