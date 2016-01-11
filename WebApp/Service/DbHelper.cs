using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using System.Linq.Expressions;


namespace WebApp.Service
{

    public class DbHelper
    {
      
        protected readonly DbContext _dbContext = new BissInventaireEntities();
        public async Task<List<Utilisateur>> GetCustomerDataAsync()
        {
            BissInventaireEntities db = new BissInventaireEntities();
            var query = from c in db.Utilisateur

                        select c;
            List<Utilisateur> data = await query.ToListAsync();
            return data;
        }

       

        


        public async Task<Utilisateur> Auth(Utilisateur emp)
        {
            BissInventaireEntities db = new BissInventaireEntities();
            var query = from c in db.Utilisateur.Where(x => x.login == emp.login && x.motDePasse == emp.motDePasse)

                        select c;


            Utilisateur data = await query.FirstOrDefaultAsync();
            return data;
        }

    
    }
}