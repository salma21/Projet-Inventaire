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
    public class UtilisateurService : IUtilisateurService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public UtilisateurService() { }

        public IEnumerable<Utilisateur> GetUtilisateurs()
        {
            var Utilisateurs = utOfWork.UtilisateurRepository.GetAll();
            return Utilisateurs;
        }

      

        public Utilisateur GetUtilisateur(Expression<Func<Utilisateur, bool>> where)
        {
            return utOfWork.UtilisateurRepository.Get(where);
        
        }



        public Utilisateur GetUtilisateurById(int id)
        {

            var Utilisateur = utOfWork.UtilisateurRepository.GetById(id);
            return Utilisateur;
        }


        public Utilisateur Authentification(Utilisateur user)
        {

            Expression<Func<Utilisateur, bool>> where = gu => gu.login == user.login && gu.motDePasse ==user.motDePasse;
            return utOfWork.UtilisateurRepository.Get(where);
        }
       
        public void SaveEmploye()
        {
            utOfWork.Commit();
        }


        public void UpdateUtilisateurDetached(Utilisateur e)
        {
            utOfWork.UtilisateurRepository.UpdateUtilisateurDetached(e);
        }

        public void CreateUtilisateurs(Utilisateur e)
        {
            utOfWork.UtilisateurRepository.Add(e);
        }


        public void UpdateUtilisateur(Utilisateur Utilisateur)
        {
            utOfWork.UtilisateurRepository.Update(Utilisateur);

        }



    }
    public interface IUtilisateurService
    {
        IEnumerable<Utilisateur> GetUtilisateurs();
        Utilisateur GetUtilisateur(Expression<Func<Utilisateur, bool>> where);
        void CreateUtilisateurs(Utilisateur e);
        Utilisateur GetUtilisateurById(int id);
        Utilisateur Authentification(Utilisateur user);
        void SaveEmploye(); void UpdateUtilisateurDetached(Utilisateur e);


    }

}


