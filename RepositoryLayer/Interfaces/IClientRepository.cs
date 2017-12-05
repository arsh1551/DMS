using CoreEntites.SubDomain;
using CoreEntites.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IClientRepository
    {

        Clients GetClient(long ClientId);
        List<Clients> GetClientList();
        bool UpdateClient(ClientViewModel model);
        bool AddClient(ClientViewModel model);

        bool DeleteClient(long ClientId);
    }
}
