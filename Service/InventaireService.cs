using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class InventaireService : IInventaireService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public InventaireService() { }

        public IEnumerable<Inventaire> GetInventaires()
        {
            var dep = utOfWork.InventaireRepository.GetAll();
            return dep;
        }

        public Inventaire GetInventaire(int id)
        {
            var Dept = utOfWork.InventaireRepository.GetById(id);
            return Dept;
        }

        public void CreateInventaire(Inventaire Inventaire)
        {

            utOfWork.InventaireRepository.Add(Inventaire);


        }
        public void DeleteInventaire(int id)
        {

            var Dept = utOfWork.InventaireRepository.GetById(id);
            utOfWork.InventaireRepository.Delete(Dept);



        }



        public void SaveInventaire()
        {
            utOfWork.Commit();
        }


        public void UpdateInventaireDetached(Inventaire e)
        {
            utOfWork.InventaireRepository.UpdateInventaireDetached(e);
        }

        //public IEnumerable<Bien> FindBineByInv(int id)
        //{
        //    var dep = utOfWork.InventaireRepository.FindBineByInv(id);
        //    return dep;
        //}
       






    }
    public interface IInventaireService
    {
        IEnumerable<Inventaire> GetInventaires();
        Inventaire GetInventaire(int id);
        void CreateInventaire(Inventaire Dept);
        void DeleteInventaire(int id);
        //IEnumerable<Bien> FindBineByInv(int id);
        void UpdateInventaireDetached(Inventaire e);


        void SaveInventaire();







    }

}


