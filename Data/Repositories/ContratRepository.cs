
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
   
   public class ContratRepository : RepositoryBase<Contrat>, IContratRepository
    {
        public ContratRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateContratDetached(Contrat e)
        {
            Contrat existing = FindContratByID(e.Id_contrat);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public int FindMaxIDContrat()
        {

            var pers = (from p in DataContext.Contrat

                        select p.Id_contrat).Max();

            return pers;
        }


        public Contrat FindContratByID(int id)
        {

            var contass = (from p in this.DataContext.Contrat
                           where p.Id_contrat == id
                           select p).ToList<Contrat>();
            return contass.FirstOrDefault();


        }
    }


    public interface IContratRepository : IRepository<Contrat>
    {
        Contrat FindContratByID(int id);
        int FindMaxIDContrat();


        void UpdateContratDetached(Contrat e);
    }

}

