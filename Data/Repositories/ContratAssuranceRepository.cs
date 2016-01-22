
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
   
   public class ContratAssuranceRepository : RepositoryBase<Contrat_assurance>, IContratAssuranceRepository
    {
        public ContratAssuranceRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateCont_AssuranceDetached(Contrat_assurance e)
        {
            Contrat_assurance existing = FindContrat_assuranceByID(e.Id_contrat_assurance);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }
        public Contrat_assurance FindContrat_assuranceByID(int id)
        {

            var contass = (from p in this.DataContext.Contrat_assurance
                           where p.Id_contrat_assurance == id
                        select p).ToList<Contrat_assurance>();
            return contass.FirstOrDefault();


        }
        public int FindRegionByDelegation(int id)
        {

            var pers = (from p in DataContext.Delegation
                        where p.idDelegation == id
                        select p);
            return pers.FirstOrDefault().idRegion;
        }

        public int FindPaysByDelegation(int id)
        {

            var pers = (from p in DataContext.Delegation
                        where p.idDelegation == id
                        select p);
            return pers.FirstOrDefault().idPays;
        }

        public int FindGouvByDelegation(int id)
        {

            var pers = (from p in DataContext.Delegation
                        where p.idDelegation == id
                        select p);
            return pers.FirstOrDefault().idGouvernorat;
        }

    }


    public interface IContratAssuranceRepository : IRepository<Contrat_assurance>
    {
        Contrat_assurance FindContrat_assuranceByID(int id);
        void UpdateCont_AssuranceDetached(Contrat_assurance e);
        //public int FindGouvByDelegation(int id);
        //public int FindPaysByDelegation(int id);
        //public int FindPaysByDelegation(int id);
        //public int FindRegionByDelegation(int id);
    }

}

