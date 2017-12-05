using CoreEntites.Domain;
using CoreEntites.ViewModel;
using DMS.Areas.IndividualsArea.Models;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class AccountService : IAccountService
    {
        IAccountRepository _IAccountRepository = null;
        public AccountService(IAccountRepository IAccountRepository)
        {
            this._IAccountRepository = IAccountRepository;
        }
        #region start  21-Nov-2017
        public bool InsertIndividualClient(IndividualRegistrationViewModel individualRegistrationModel)
        {
            return _IAccountRepository.InsertIndividualClient(individualRegistrationModel);
        }
        public bool AddUser(UserViewModel userModel)
        {
            return _IAccountRepository.AddUser(userModel);
        }
        public UserViewModel LoginUser(LoginViewModel model)
        {
            return _IAccountRepository.LoginUser(model);
        }
        public bool IsEmailExists(string EmailId)
        {
            return _IAccountRepository.IsEmailExists(EmailId);
        }
        public bool IsUserExists(string UserName)
        {
            return _IAccountRepository.IsUserExists(UserName);
        }
        public string GetUserNameById(long? UserId)
        {
            return _IAccountRepository.GetUserNameById(UserId);
        }

        public bool ChangePassword(ChangePasswordViewModel model)
        {
            return _IAccountRepository.ChangePassword(model);
        }

        public UserViewModel GetUserByEmail(string Email)
        {
            return _IAccountRepository.GetUserByEmail(Email);
        }

        public string ResetUserPassword(ResetPasswordViewModel model)
        {
            User user = new User { UserId = model.UserId, Password = model.Newpassword };
            return _IAccountRepository.ResetUserPassword(user);
        }
        public bool IsSSNExists(string SSN)
        {
            return _IAccountRepository.IsSSNExists(SSN);
        }
        #endregion
    }
}
