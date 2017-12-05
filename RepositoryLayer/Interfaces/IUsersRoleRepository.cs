using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntites.ViewModel;
using CoreEntites;
using CoreEntites.SubDomain;

namespace RepositoryLayer.Interfaces
{
    public interface IUsersRoleRepository
    {
        bool AddUpdateRole(Roles Role);
        List<UsersRoleViewModel> GetRoles();
        bool DeleteRole(long RoleId);        
    }
}
