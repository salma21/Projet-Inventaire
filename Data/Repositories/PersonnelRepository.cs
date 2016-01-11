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





    public class PersonnelRepository : RepositoryBase<Personnel>, IPersonnelRepository
    {
        public PersonnelRepository(DatabaseFactory dbFactory) : base(dbFactory) { }


        public void UpdatePersonnelDetached(Personnel e)
        {
            Personnel existing = FindPersByID(e.id);
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

        public Personnel FindPersByID(int id)
        {

            var pers = (from p in this.DataContext.Personnel
                        where p.id == id
                        select p).ToList<Personnel>();
            return pers.FirstOrDefault();


        }
    }


    public interface IPersonnelRepository : IRepository<Personnel>
    {
        int FindDelegationByBatiment(int id);
        int FindGouverneratByBatiment(int id);
        int FindRegionByBatiment(int id);
        int FindOrganisationByBatiment(int id);
        void UpdatePersonnelDetached(Personnel e);
        int FindPaysByBatiment(int id);
        Personnel FindPersByID(int id);
    }



}

