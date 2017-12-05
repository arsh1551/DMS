using CoreEntites.Common;
using CoreEntites.Domain;
using CoreEntites.ViewModel;
using DMS.Areas.IndividualsArea.Models;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntites.SubDomain;
using CoreEntites.Domain.Master;

namespace RepositoryLayer.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        #region Initialize
        UnityOfWork uow = null;
        UnityOfWork subuow = null;
        DmsDomainContext DataContext;
        DmsSubDomainContext SubDataContext;
        public AccountRepository()
        {
            if (uow == null)
            {
                SubDataContext = new DmsSubDomainContext();
                DataContext = new DmsDomainContext();
                uow = new UnityOfWork(DataContext);
                subuow = new UnityOfWork(SubDataContext);
            }
        }
        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                this.uow.Dispose();
                this.DataContext.Database.Connection.Close();
                this.DataContext.Dispose();
            }
            // free native resources
        }
        #region start  21-Nov-2017
        /// <summary>
        /// CreatedDate:21-Nov-2017
        /// Desc:Insert data for the Indvidual clients.
        /// </summary>
        /// <param name="objIndividualRegistrationViewModel"></param>
        /// <returns></returns>
        public bool InsertIndividualClient(IndividualRegistrationViewModel objIndividualRegistrationViewModel)
        {
            try
            {
                if (objIndividualRegistrationViewModel.IsIndividualClient == 1)                          // For the main domain Individual Clients
                {
                    Individual objIndividual = new Individual();
                    objIndividual.FirstName = objIndividualRegistrationViewModel.FirstName;
                    objIndividual.MiddleName = objIndividualRegistrationViewModel.MiddleName;
                    objIndividual.LastName = objIndividualRegistrationViewModel.LastName;
                    objIndividual.BirthDate = Convert.ToDateTime(objIndividualRegistrationViewModel.BirthDate);
                    objIndividual.Prefix = objIndividualRegistrationViewModel.Prefix;            //1 for Mr., 2 for Ms.
                    objIndividual.Suffix = objIndividualRegistrationViewModel.Suffix;
                    objIndividual.SSN = Convert.ToString(objIndividualRegistrationViewModel.SSN);
                    objIndividual.Phone = objIndividualRegistrationViewModel.Phone;
                    objIndividual.EmailAddress = objIndividualRegistrationViewModel.EmailAddress.ToLower();
                    objIndividual.CreatedDate = DateTime.Now;
                    objIndividual.IsDeleted = false;
                    objIndividual.IsActive = true;
                    uow.Repository<Individual>().Add(objIndividual);
                    uow.SaveChanges();
                    UserViewModel objUserModel = new UserViewModel();
                    objUserModel.IndividualRecordId = objIndividual.IndividualRecordId;
                    objUserModel.Email = objIndividualRegistrationViewModel.EmailAddress.ToLower();
                    objUserModel.UserName = objIndividualRegistrationViewModel.UserName.ToLower();
                    objUserModel.Password = CommonFunction.EncryptPassword(objIndividualRegistrationViewModel.Password);
                    AddUser(objUserModel);
                    return true;
                }
                else
                {
                    // For the Accounting firm
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// CreatedDate:21-Nov-2017
        /// Desc:Insert data for Users
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public bool AddUser(UserViewModel objUserModel)
        {
            try
            {
                User objUser = new User();
                objUser.UserName = objUserModel.UserName;
                objUser.Password = objUserModel.Password;
                objUser.Email = objUserModel.Email;
                objUser.StartDate = DateTime.Now;
                objUser.IndividualRecordId = objUserModel.IndividualRecordId;
                objUser.CreatedDate = DateTime.Now;
                objUser.CreatedBy = objUserModel.IndividualRecordId;
                objUser.IsDeleted = false;
                objUser.IsActive = true;
                uow.Repository<User>().Add(objUser);
                uow.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// CreatedDate:22-Nov-2017
        /// Desc:To check user emails already exists 
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        public bool IsEmailExists(string EmailId)
        {
            var _result = DataContext.Users.Where(x => x.Email == EmailId.ToLower() && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            if (_result != null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// CreatedDate:22-Nov-2017
        /// Desc:To check user users already exists 
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool IsUserExists(string UserName)
        {
            var _result = DataContext.Users.Where(x => x.UserName.ToLower() == UserName.ToLower() && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            if (_result != null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// CreatedDate:23-Nov-2017
        /// Desc:To get the username by userid
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string GetUserNameById(long? UserId)
        {
            string _UserName = string.Empty;
            _UserName = DataContext.Users.Where(x => x.UserId == UserId).Select(x => x.UserName).FirstOrDefault();
            return _UserName;
        }

        public UserViewModel LoginUser(LoginViewModel model)
        {
            using (var context = new DmsDomainContext())
            {
                // If using Code First we need to make sure the model is built before we open the connection 
                // This isn't required for models created with the EF Designer 
                context.Database.Initialize(force: false);

                // Create a SQL command to execute the sproc 
                var cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "EXEC sp_userlogin @email ,@password";
                cmd.Parameters.Add(new SqlParameter("email", model.UserName));
                cmd.Parameters.Add(new SqlParameter("password", CommonFunction.EncryptPassword(model.Password)));
                context.Database.Connection.Open();
                // Run the sproc  
                var reader = cmd.ExecuteReader();
                // Read  the first result set 
                UserViewModel Userviewmodel =
                                   ((IObjectContextAdapter)context)
                                   .ObjectContext
                                   .Translate<UserViewModel>(reader)
                                   .FirstOrDefault();
                return Userviewmodel;

            }
        }

        public bool ChangePassword(ChangePasswordViewModel model)
        {
            string oldpassword = CommonFunction.EncryptPassword(model.OldPassword);
            var data = DataContext.Users.Where(x => x.UserId == model.UserId && x.Password == oldpassword).FirstOrDefault();
            if (data != null)
            {
                User user = new User { UserId = data.UserId };
                if (user != null)
                {
                    data.Password = CommonFunction.EncryptPassword(model.NewPassword);
                    uow.Repository<User>().Add(user);
                    uow.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public UserViewModel GetUserByEmail(string Email)
        {
            using (var context = new DmsDomainContext())
            {
                // If using Code First we need to make sure the model is built before we open the connection 
                // This isn't required for models created with the EF Designer 
                context.Database.Initialize(force: false);
                // Create a SQL command to execute the sproc 
                var cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "EXEC sp_getUserByEmail @email";
                cmd.Parameters.Add(new SqlParameter("email", Email));
                context.Database.Connection.Open();
                // Run the sproc  
                var reader = cmd.ExecuteReader();
                // Read  the first result set 
                UserViewModel Userviewmodel =
                                             ((IObjectContextAdapter)context)
                                             .ObjectContext
                                             .Translate<UserViewModel>(reader)
                                             .FirstOrDefault();
                return Userviewmodel;
            }
        }

        public string ResetUserPassword(User user)
        {
            var data = DataContext.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (user != null)
            {
                data.Password = CommonFunction.EncryptPassword(user.Password);
                uow.Repository<User>().Add(user);
                uow.SaveChanges();
                return "Your password reset successfully!";
            }
            return "Something went wrong!";
        }
        /// <summary>
        /// CreatedDate:23-Nov-2017
        /// Desc:To check SSNumber exists in db or not
        /// </summary>
        /// <param name="SSN"></param>
        /// <returns></returns>
        public bool IsSSNExists(string SSN)
        {
            var _result = DataContext.Individuals.Where(x => x.SSN == SSN && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            if (_result != null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// CreateDate:24-Nov-2017
        /// Desc:
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        //public bool IsEmailConfirm(long? UserID)
        //{

        //}
        #endregion
    }
}
