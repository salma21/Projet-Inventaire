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
    public class MouvementBienRepository : RepositoryBase<MouvementBien>, IMouvementBienRepository
    {
        public MouvementBienRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateMouvementBienDetached(MouvementBien e)
        {
            MouvementBien existing = this.DataContext.MouvementBien.Find(e.Id_mouvementB);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public IEnumerable<Batiment> FindBatimentByDelegation(int id)
        {

            var pers = (from p in DataContext.Batiment
                        where p.idDelegation == id
                        select p);
            return pers.ToList();
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

      
        public MouvementBien FindMouvementBienByID(int id)
        {

            var pers = (from p in DataContext.MouvementBien
                        where p.Id_mouvementB == id
                        select p);
            return pers.FirstOrDefault();
        }



    }
    public interface IMouvementBienRepository : IRepository<MouvementBien>
    {

        void UpdateMouvementBienDetached(MouvementBien e);
        IEnumerable<Batiment> FindBatimentByDelegation(int id);

        IEnumerable<Etage> FindEtageByBatiment(int id);
       
        IEnumerable<Bien> FindBienByEtage(int id);

        MouvementBien FindMouvementBienByID(int id);







    }
}