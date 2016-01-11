
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
   
   public class FournisseurRepository : RepositoryBase<Fournisseur>, IFournisseurRepository
    {
        public FournisseurRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateFournisseurDetached(Fournisseur e)
        {
            Fournisseur existing = FindFourByID(e.Id_fournisseur);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public Fournisseur FindFourByID(int id)
        {

            var pers = (from p in DataContext.Fournisseur
                        where p.Id_fournisseur == id
                        select p);
            return pers.FirstOrDefault();
        }

    }


    public interface IFournisseurRepository : IRepository<Fournisseur>
    {
        Fournisseur FindFourByID(int id);
        void UpdateFournisseurDetached(Fournisseur e);


    }

}

