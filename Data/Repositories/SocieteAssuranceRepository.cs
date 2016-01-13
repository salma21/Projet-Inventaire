
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
   
   public class SocieteAssuranceRepository : RepositoryBase<Societe_assurance>, ISocieteAssuranceRepository
    {
        public SocieteAssuranceRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateSoc_AssuranceDetached(Societe_assurance e)
        {
            Societe_assurance existing = FindSocByID(e.Id_societe_assurance);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public Societe_assurance FindSocByID(int id)
        {

            var pers = (from p in DataContext.Societe_assurance
                        where p.Id_societe_assurance == id
                        select p);
            return pers.FirstOrDefault();
        }

    }


    public interface ISocieteAssuranceRepository : IRepository<Societe_assurance>
    {
        Societe_assurance FindSocByID(int id);
        void UpdateSoc_AssuranceDetached(Societe_assurance e);
       
    }

}

