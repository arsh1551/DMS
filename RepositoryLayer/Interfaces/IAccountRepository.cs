using CoreEntites.Domain;
using CoreEntites.ViewModel;
using DMS.Areas.IndividualsArea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        #region Registration
        bool InsertIndividualClient(IndividualRegistrationViewModel IndividualRegistrationViewModel);
        bool AddUser(UserViewModel userModel);
        bool IsEmailExists(string EmailId);
        bool IsUserExists(string UserName);
        string GetUserNameById(long? UserId);
        bool IsSSNExists(string SSN);       
        #endregion
        #region Login Method
        UserViewModel LoginUser(LoginViewModel model);
        UserViewModel GetUserByEmail(string Email);
        #endregion
        #region ChangePassword
        bool ChangePassword(ChangePasswordViewModel model);
        string ResetUserPassword(User user);
        #endregion
    }
}
