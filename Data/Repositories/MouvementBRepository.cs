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
    public class MouvementBRepository : RepositoryBase<MouvementB>, IMouvementBRepository
    {
        public MouvementBRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateMouvementBDetached(MouvementB e)
        {
            MouvementB existing = this.DataContext.MouvementB.Find(e.Id_mouvementB);
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


       

        public IEnumerable<Bien> FindBienByEtage(int id)
        {
            var pers = (from p in DataContext.Bien
                        where p.Id_etage == id
                        select p);
            return pers.ToList();
        }

     




    }
    public interface IMouvementBRepository : IRepository<MouvementB>
    {

        void UpdateMouvementBDetached(MouvementB e);
        int FindDelegationByBatiment(int id);
        int FindGouverneratByBatiment(int id);
        int FindRegionByBatiment(int id);
        int FindOrganisationByBatiment(int id);
       
        int FindPaysByBatiment(int id);
        IEnumerable<Etage> FindEtageByBatiment(int id);
       
        IEnumerable<Bien> FindBienByEtage(int id);
       








    }
}