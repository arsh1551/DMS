using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntites.ViewModel;
using RepositoryLayer.Interfaces;
using CoreEntites.SubDomain;

namespace ServiceLayer.Services
{
    public class UsersRoleService : IUsersRoleService
    {
        IUsersRoleRepository _IUsersRoleRepository;
        public UsersRoleService(IUsersRoleRepository IUsersRoleRepository)
        {
            this._IUsersRoleRepository = IUsersRoleRepository;
        }

        public bool AddUpdateRole(UsersRoleViewModel Role)
        {
            Roles userrole = new Roles { RoleName = Role.RoleName };
            return this._IUsersRoleRepository.AddUpdateRole(userrole);
        }

        public bool DeleteRole(long RoleId)
        {
            return this.DeleteRole(RoleId);
        }

        public List<UsersRoleViewModel> GetRoles()
        {
            return this.GetRoles();
        }
    }
}
