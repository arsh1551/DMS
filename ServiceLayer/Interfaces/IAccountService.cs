using CoreEntites.ViewModel;
using CoreEntites.Domain;
using DMS.Areas.IndividualsArea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IAccountService
    {
        #region start  21-Nov-2017
        bool InsertIndividualClient(IndividualRegistrationViewModel individualRegistrationModel);
        bool AddUser(UserViewModel userModel);
        bool IsEmailExists(string EmailId);
        bool IsUserExists(string UserName);
        string GetUserNameById(long? UserId);
        UserViewModel GetUserByEmail(string Email);
        UserViewModel LoginUser(LoginViewModel model);
        bool IsSSNExists(string SSN);
        bool ChangePassword(ChangePasswordViewModel model);
        string ResetUserPassword(ResetPasswordViewModel model);
        #endregion
    }
}
