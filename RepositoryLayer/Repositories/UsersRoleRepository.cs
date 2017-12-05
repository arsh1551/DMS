using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntites.SubDomain;
using CoreEntites.ViewModel;

namespace RepositoryLayer.Repositories
{
    public class UsersRoleRepository : IUsersRoleRepository
    {
        public bool AddUpdateRole(Roles Role)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRole(long RoleId)
        {
            throw new NotImplementedException();
        }

        public List<UsersRoleViewModel> GetRoles()
        {
            throw new NotImplementedException();
        }
    }
}
