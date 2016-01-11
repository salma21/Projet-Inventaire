using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
using System.Security.Cryptography;
using Domain;

namespace Service
{
    public class UserService : IUserService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public UserService() { }

        public IEnumerable<Utilisateur> GetUsers()
        {
            var Users = utOfWork.UserRepository.GetAll();
            return Users;
        }

      

        public Utilisateur GetUser(Expression<Func<Utilisateur, bool>> where)
        {
            return utOfWork.UserRepository.Get(where);
        
        }



        public Utilisateur GetUserById(int id)
        {

            var User = utOfWork.UserRepository.GetById(id);
            return User;
        }


        public Utilisateur Authentification(Utilisateur user)
        {

            Expression<Func<Utilisateur, bool>> where = gu => gu.login == user.login && gu.motDePasse ==user.motDePasse;
            return utOfWork.UserRepository.Get(where);
        }
       
        public void SaveEmploye()
        {
            utOfWork.Commit();
        }


        public void UpdateUserDetached(Utilisateur e)
        {
            utOfWork.UserRepository.UpdateUserDetached(e);
        }

        public void CreateUsers(Utilisateur e)
        {
            utOfWork.UserRepository.Add(e);
        }


        public void UpdateUser(Utilisateur User)
        {
            utOfWork.UserRepository.Update(User);

        }



    }
    public interface IUserService
    {
        IEnumerable<Utilisateur> GetUsers();
        Utilisateur GetUser(Expression<Func<Utilisateur, bool>> where);
        void CreateUsers(Utilisateur e);
        Utilisateur GetUserById(int id);
        Utilisateur Authentification(Utilisateur user);
        void SaveEmploye(); void UpdateUserDetached(Utilisateur e);


    }

}


