
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private BissInventaireEntities dataContext = null;
        public BissInventaireEntities Get()
        {
            return dataContext ?? (dataContext = new BissInventaireEntities());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null) dataContext.Dispose();
        }
    }
}
