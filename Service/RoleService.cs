using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{

public class RoleService : IRoleService
    {
    static DatabaseFactory dbFactory = new DatabaseFactory();
    IUnitOfWork utOfWork = new UnitOfWork(dbFactory);

    public RoleService() { }

        public IEnumerable<Role> GetRoles()
        {
            var dep = utOfWork.RoleRepository.GetAll();
            return dep;
        }

        public Role GetRole(int id)
    {
        var Dept = utOfWork.RoleRepository.GetById(id);
        return Dept;
    }

    public void CreateRole(Role Role)
    {

        utOfWork.RoleRepository.Add(Role);

    }
    public void DeleteRole(int id)
    {

        var Dept = utOfWork.RoleRepository.GetById(id);
        utOfWork.RoleRepository.Delete(Dept);

    }


    public void SaveRole()
    {
        utOfWork.Commit();
    }


    public void UpdateRoleDetached(Role e)
    {
        utOfWork.RoleRepository.UpdateRoleDetached(e);
    }

}
public interface IRoleService
    {
    IEnumerable<Role> GetRoles();
    Role GetRole(int id);
    void CreateRole(Role Dept);
    void DeleteRole(int id);

    void UpdateRoleDetached(Role e);


    void SaveRole();


}

}
