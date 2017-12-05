using CoreEntites.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IClientService
    {
        ClientViewModel GetClient(long ClientId);
        List<ClientViewModel> GetClientList();
        bool UpdateClient(ClientViewModel model);
        bool AddClient(ClientViewModel model);
        bool DeleteClient(int ClientId);
    }
}
