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
    
    public class EtageRepository : RepositoryBase<Etage>, IEtageRepository
    {
        public EtageRepository(DatabaseFactory dbFactory) : base(dbFactory) { }


        public void UpdateEtageDetached(Etage e)
        {
            Etage existing = FindEtageByID(e.Id_etage);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public int FindOrganisationByBatiment(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idBatiment == id
                        select p);
            return (int)pers.FirstOrDefault().idOrganisation;
        }

        public int FindDelegationByBatiment(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idBatiment == id
                        select p);
            return pers.FirstOrDefault().idDelegation;
        }
        public int FindGouverneratByBatiment(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idBatiment == id
                        select p);
            return (int)pers.FirstOrDefault().idGouvernorat;
        }
        public int FindRegionByBatiment(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idBatiment == id
                        select p);
            return (int)pers.FirstOrDefault().idRegion;
        }

        public int FindPaysByBatiment(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idBatiment == id
                        select p);
            return (int)pers.FirstOrDefault().idPays;
        }

        public Etage FindEtageByID(int id)
        {

            var pers = (from p in DataContext.Etage
                        where p.Id_etage == id
                        select p);
            return pers.FirstOrDefault();
        }
    }


    public interface IEtageRepository : IRepository<Etage>
    {
        Etage FindEtageByID(int id);
        int FindDelegationByBatiment(int id);
        int FindGouverneratByBatiment(int id);
        int FindRegionByBatiment(int id);
        int FindOrganisationByBatiment(int id);
        void UpdateEtageDetached(Etage e);
        int FindPaysByBatiment(int id);

    }



}

