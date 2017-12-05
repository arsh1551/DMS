using CoreEntites.Common;
using CoreEntites.Domain;
using CoreEntites.Domain.Master;
using CoreEntites.ViewModel;
using DMS.Areas.IndividualsArea.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class IndividualRepository : IIndividualRepository
    {
        #region Initialize
        UnityOfWork uow = null;
        DmsDomainContext DataContext;
        public IndividualRepository()
        {
            if (uow == null)
            {
                DataContext = new DmsDomainContext();
                uow = new UnityOfWork(DataContext);
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
        #region MyRegion
        /// <summary>
        /// CreatedDate:23-Nov-2017
        /// Desc:Get Detail of Individual Users
        /// </summary>
        /// <returns></returns>
        public IndividualRegistrationViewModel GetIndividualClientDetail(long? UserID)
        {
            using (DataContext = new DmsDomainContext())
            {
                User objUser = new User();
                objUser = DataContext.Users.Where(x => x.UserId == UserID).FirstOrDefault();
                IndividualRegistrationViewModel objIndividualRegistrationViewModel = new IndividualRegistrationViewModel();
                objIndividualRegistrationViewModel.IndividualRecordId = objUser.IndividualRecordId;
                objIndividualRegistrationViewModel.FirstName = objUser.Individual.FirstName;
                objIndividualRegistrationViewModel.MiddleName = objUser.Individual.MiddleName;
                objIndividualRegistrationViewModel.LastName = objUser.Individual.LastName;
                objIndividualRegistrationViewModel.BirthDate = Convert.ToDateTime(objUser.Individual.BirthDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                objIndividualRegistrationViewModel.SSN = objUser.Individual.SSN;
                objIndividualRegistrationViewModel.Prefix = objUser.Individual.Prefix;
                objIndividualRegistrationViewModel.Suffix = objUser.Individual.Suffix;
                objIndividualRegistrationViewModel.Phone = objUser.Individual.Phone;
                objIndividualRegistrationViewModel.UserName = objUser.UserName;
                objIndividualRegistrationViewModel.EmailAddress = objUser.Email;
                return objIndividualRegistrationViewModel;
            }
        }
        /// <summary>
        /// CreatedDate:23-Nov-2017
        /// Desc:Update record of Individual Users
        /// </summary>
        /// <param name="objIndividualRegistrationViewModel"></param>
        /// <returns></returns>
        public bool UpdateIndividualClient(IndividualRegistrationViewModel objIndividualRegistrationViewModel)
        {
            try
            {
                using (DataContext = new DmsDomainContext())
                {
                    Individual objIndividual = new Individual();
                    objIndividual = DataContext.Individuals.Where(x => x.IndividualRecordId == objIndividualRegistrationViewModel.IndividualRecordId).FirstOrDefault();
                    objIndividual.FirstName = objIndividualRegistrationViewModel.FirstName;
                    objIndividual.MiddleName = objIndividualRegistrationViewModel.MiddleName;
                    objIndividual.LastName = objIndividualRegistrationViewModel.LastName;
                    objIndividual.BirthDate = Convert.ToDateTime(objIndividualRegistrationViewModel.BirthDate);
                    objIndividual.Prefix = objIndividualRegistrationViewModel.Prefix;            //1 for Mr., 2 for Ms.
                    objIndividual.Suffix = objIndividualRegistrationViewModel.Suffix;
                    objIndividual.SSN = Convert.ToString(objIndividualRegistrationViewModel.SSN);
                    objIndividual.Phone = objIndividualRegistrationViewModel.Phone;
                    objIndividual.ModifiedDate = DateTime.Now;
                    objIndividual.ModifiedBy = objIndividualRegistrationViewModel.IndividualRecordId;
                    objIndividual.IsDeleted = false;
                    DataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// CreatedDate:23-Nov-2017
        /// Desc:To check SSNumber exists for the existed Clients
        /// </summary>
        /// <param name="SSN"></param>
        /// <returns></returns>
        public bool IsSSNExistsForIndividualClient(string SSN, long? IndividualRecordId)
        {
            var _result = DataContext.Individuals.Where(x => x.SSN == SSN && x.IsActive == true && x.IsDeleted == false && x.IndividualRecordId != IndividualRecordId).FirstOrDefault();
            if (_result != null)
                return true;
            else
                return false;
        }
        #endregion
    }
}
