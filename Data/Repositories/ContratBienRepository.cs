using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data.Infrastructure;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Data.Repositories
{
    public class ContratBienRepository : RepositoryBase<ContratBien>, IContratBienRepository
    {
        public ContratBienRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateContratBienDetached(ContratBien e)
        {
            ContratBien existing = FindBienByID(e.Id_bien);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public ContratBien FindBienByID(int id)
        {

            var pers = (from p in DataContext.ContratBien
                        where p.Id_bien == id
                        select p);
            return pers.FirstOrDefault();
        }

       
    }


public interface IContratBienRepository : IRepository<ContratBien>
{
    ContratBien FindBienByID(int id);


    void UpdateContratBienDetached(ContratBien e);
}

}