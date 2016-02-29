using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Infrastructure;
using Domain;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Data.Repositories
{
    class DirectionRepository : RepositoryBase<Direction>, IDirectionRepository
    {
        public DirectionRepository(DatabaseFactory dbFactory) : base(dbFactory) { }
        public void UpdateDirectionDetached(Direction e)
        {
            Direction existing = FindDirectionByID(e.Id_direction);
            ((IObjectContextAdapter)DataContext).ObjectContext.Detach(existing);
            this.DataContext.Entry(e).State = EntityState.Modified;
        }

        public Direction FindDirectionByID(int id)
        {

            var pers = (from p in DataContext.Direction
                        where p.Id_direction == id
                        select p);
            return pers.FirstOrDefault();
        }

    }


    public interface IDirectionRepository : IRepository<Direction>
    {

        void UpdateDirectionDetached(Direction e);
        Direction FindDirectionByID(int id);

    }

}
