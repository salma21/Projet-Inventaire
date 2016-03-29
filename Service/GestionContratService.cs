using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GestionContratService : IGestionContratService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public GestionContratService() { }

      

        public Fournisseur FindFournisseurByID(int id)

        {
            var Dept = utOfWork.FournisseurRepository.FindFourByID(id);
            return Dept;
        }

       

        public Contrat FindContratByID(int id)

        {
            var Dept = utOfWork.ContratRepository.FindContratByID(id);
            return Dept;
        }

        
        public void SaveChange()
        {
            utOfWork.Commit();
        }
        public void UpdateAchatDetached(Achat e)
        {
            utOfWork.AchatRepository.UpdateAchatDetached(e);
        }

        public int FindMaxIDContrat()
        {
            int i = utOfWork.ContratRepository.FindMaxIDContrat();
            return i;
        }
        public int FindMaxIDAchat()
        {
            int i = utOfWork.AchatRepository.FindMaxIDAchat();
            return i;
        }


        public void UpdateContratDetached(Contrat e)
        {
            utOfWork.ContratRepository.UpdateContratDetached(e);
        }


        public void UpdateFournisseurDetached(Fournisseur e)
        {
            utOfWork.FournisseurRepository.UpdateFournisseurDetached(e);
        }
      
       
    }

    }
    public interface IGestionContratService
    {
        void UpdateContratDetached(Contrat e);
        Contrat FindContratByID(int id);
        void UpdateAchatDetached(Achat e);
        void UpdateFournisseurDetached(Fournisseur e);
        void SaveChange();
        Fournisseur FindFournisseurByID(int id);
    int FindMaxIDContrat();
    int FindMaxIDAchat();

    }




