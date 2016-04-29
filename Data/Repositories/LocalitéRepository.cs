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
    public class LocalitéRepository : RepositoryBase<Localité>, ILocalitéRepository
    {
        public LocalitéRepository(DatabaseFactory dbFactory) : base(dbFactory) { }


        public void UpdateLocalitéDetached(Localité e)
        {
            Localité existing = this.DataContext.Localité.Find(e.Id_localité);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }


      public List<Localité> GetLocByIdDelegation(string del)
        {
            var pers = (from p in this.DataContext.Localité
                        where p.delegation == del
                        select p).ToList();
            return pers;
        }


      public int  GetCPByLocalite(int del)
        {
            var pers = (from p in this.DataContext.Localité
                        where p.Id_localité == del
                        select p).FirstOrDefault();
            return (int)pers.CP;
        }
        public Localité FindlocalByID(int id)
        {

            var pers = (from p in this.DataContext.Localité
                        where p.Id_localité == id
                        select p).ToList<Localité>();
            return pers.FirstOrDefault();


        }
    }


    public interface ILocalitéRepository : IRepository<Localité>
    {
        Localité FindlocalByID(int id);
        List<Localité> GetLocByIdDelegation(string del);
        int GetCPByLocalite(int del);
        void UpdateLocalitéDetached(Localité e);
        
    }



}
