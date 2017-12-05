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
    public class FirmService : IFirmService
    {
        IFirmRepository _IFirmRepository = null;
        public FirmService(IFirmRepository IFirmRepository)
        {
            this._IFirmRepository = IFirmRepository;
        }
        public bool AddFirm(FirmViewModel model)
        {
            return _IFirmRepository.AddFirm(model);
        }

        public bool DeleteFirm(int FirmId)
        {
            try
            {
                var _entity = _IFirmRepository.DeleteFirm(FirmId);
                
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public FirmViewModel GetFirm(long FirmId)
        {
            var res= _IFirmRepository.GetFirm(FirmId);
            FirmViewModel model = new FirmViewModel();
            model.FirmId = res.FirmId;
            model.FirmName = res.FirmEmail;
            model.FirmEmail = res.FirmEmail;
            var user = res.Users.FirstOrDefault();
            if (user != null)
            {
                model.UserName = user.UserName;
                model.Password = user.Password;
                    }
            return model;
        }

        public List<FirmViewModel> GetFirmList()
        {

            return _IFirmRepository.GetFirmList().Where(x => x.IsDeleted != true).Select(x => new FirmViewModel
            {
                FirmId = x.FirmId,
                
                FirmName = x.FirmName,
                //ClientType = x.ClientType,
                //CreatedBy = x.CreatedBy.Value,
                //CreatedDate = x.CreatedDate,
                FirmEmail = x.FirmEmail,
                //FirstName = x.FirstName,
                //IsActive = x.IsActive,
                //IsDeleted = x.IsDeleted,
                //LastName = x.LastName,
                //MiddleName = x.MiddleName,
                //ModifiedBy = x.ModifiedBy,
                //ModifiedDate = x.ModifiedDate,
                //Password = x.Password,
                //PhoneNumber = x.Phone,
                //SSN=x.SSN,

            }).ToList();
        }

        public bool UpdateFirm(FirmViewModel model)
        {
            return _IFirmRepository.UpdateFirm(model);
        }
      
    }
}
