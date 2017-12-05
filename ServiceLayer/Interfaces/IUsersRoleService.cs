using CoreEntites.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IUsersRoleService
    {
        bool AddUpdateRole(UsersRoleViewModel Role);
        List<UsersRoleViewModel> GetRoles();
        bool DeleteRole(long RoleId);
    }
}
