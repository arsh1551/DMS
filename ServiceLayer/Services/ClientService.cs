using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RepositoryLayer.Interfaces;
using CoreEntites.ViewModel;

namespace ServiceLayer.Services
{
    public class ClientService : IClientService
    {
        IClientRepository _IClientRepository = null;
        public ClientService(IClientRepository IClientRepository)
        {
            this._IClientRepository = IClientRepository;
        }
        public bool AddClient(ClientViewModel model)
        {
            return _IClientRepository.AddClient(model);
        }

        public bool DeleteClient(int ClientId)
        {
            try
            {
                var _entity = _IClientRepository.DeleteClient(ClientId);
                
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public ClientViewModel GetClient(long ClientId)
        {
            var res= _IClientRepository.GetClient(ClientId);
            ClientViewModel model = new ClientViewModel();
            model.AccountingFirmId = res.AccountingFirmId;
            model.ClientName = res.ClientName;
            model.ClientAddress = res.ClientAddress;
            model.PhoneNumber = res.Phone;
            model.EmailAddress = res.EmailAddress;
            model.FirstName = res.FirstName;
            model.MiddleName = res.MiddleName;
            model.LastName = res.LastName;
            model.ClientType = res.ClientType;
            model.BirthDate = Convert.ToDateTime(res.BirthDate);
            model.SSN = Convert.ToString(res.SSN);
            model.IsActive = true;
            model.IsDeleted = false;
            model.ModifiedDate = DateTime.Now;
            model.ModifiedBy = 5534534543545;
            model.CreatedDate = DateTime.Now;
            model.CreatedBy = 5534534543545;
            return model;
        }

        public List<ClientViewModel> GetClientList()
        {

            return _IClientRepository.GetClientList().Where(x => x.IsDeleted != true).Select(x => new ClientViewModel
            {
                AccountingFirmId = 1,
                BirthDate = x.BirthDate,
                ClientAddress = x.ClientAddress,
                ClientId = x.ClientId,
                ClientName = x.ClientName,
                ClientType = x.ClientType,
                //CreatedBy = x.CreatedBy.Value,
                //CreatedDate = x.CreatedDate,
                EmailAddress = x.EmailAddress,
                FirstName = x.FirstName,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                //ModifiedBy = x.ModifiedBy,
                //ModifiedDate = x.ModifiedDate,
                Password = x.Password,
                PhoneNumber = x.Phone,
                SSN=x.SSN,

            }).ToList();
        }

        public bool UpdateClient(ClientViewModel model)
        {
            return _IClientRepository.UpdateClient(model);
        }
      
    }
}
