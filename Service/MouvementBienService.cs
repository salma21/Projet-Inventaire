using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain;

namespace Service
{
    public class MouvementBienService : IMouvementBienService
    {
        static DatabaseFactory dbFactory = new DatabaseFactory();
        IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

        public MouvementBienService() { }

        public IEnumerable<MouvementBien> GetMouvementBiens()
        {
            var dep = utOfWork.MouvementBienRepository.GetAll();
            return dep;
        }

        public MouvementBien GetMouvementBien(int id)
        {
            var Dept = utOfWork.MouvementBienRepository.GetById(id);
            return Dept;
        }





        public void CreateMouvementBien(MouvementBien MouvementBien)
        {

            utOfWork.MouvementBienRepository.Add(MouvementBien);


        }

        public IEnumerable<Etage> FindEtageByBatiment(int id)

        {
            var dep = utOfWork.MouvementBienRepository.FindEtageByBatiment(id);
            return dep;
        }


        public IEnumerable<Batiment> FindBatimentByDelegation(int id)

        {
            var dep = utOfWork.MouvementBienRepository.FindBatimentByDelegation(id);
            return dep;
        }


        public IEnumerable<Bien> FindBienByEtage(int id)

        {
            var dep = utOfWork.MouvementBienRepository.FindBienByEtage(id);
            return dep;
        }

        public void SaveMouvementBien()
        {
            utOfWork.Commit();
        }


        public void UpdateMouvementBienDetached(MouvementBien e)
        {
            utOfWork.MouvementBienRepository.UpdateMouvementBienDetached(e);
        }







    }
}

public interface IMouvementBienService
{
    IEnumerable<MouvementBien> GetMouvementBiens();
    MouvementBien GetMouvementBien(int id);

    void UpdateMouvementBDetached(MouvementBien e);
    void SaveMouvementBien();
    void CreateMouvementBien(MouvementBien MouvementBien);
    IEnumerable<Batiment> FindBatimentByDelegation(int id);

    IEnumerable<Etage> FindEtageByBatiment(int id);

    IEnumerable<Bien> FindBienByEtage(int id);








}


