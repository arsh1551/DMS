using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CoreEntites.Common;
using CoreEntites.Domain.Master;
using CoreEntites.Domain;
using CoreEntites.SubDomain;
using CoreEntites.SessionManagement;
using CoreEntites.ViewModel;

namespace RepositoryLayer.Repositories
{
    public class FirmRepository : IFirmRepository
    {

        #region Initialize
        UnityOfWork uow = null;
        UnityOfWork subuow = null;
        DmsDomainContext DataContext;
        DmsSubDomainContext SubDataContext;
        public FirmRepository()
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
        public bool AddFirm(FirmViewModel model)
        {
            try
            {
                using (uow)
                {
                    Firm objFirm = new Firm();
                    objFirm.FirmId = Convert.ToInt32(SessionManagement.LoggedInUser.FirmId);
                    objFirm.FirmName = model.FirmName;

                    objFirm.FirmEmail = model.FirmEmail;

                    objFirm.IsActive = true;
                    objFirm.IsDeleted = false;

                    objFirm.CreatedDate = DateTime.Now;
                    objFirm.CreatedBy = SessionManagement.LoggedInUser.UserId;

                    uow.Repository<Firm>().Add(objFirm);
                    uow.SaveChanges();

                    using (subuow)
                    {
                        User objUser = new User();
                        objUser.FirmID = objFirm.FirmId;
                        objUser.UserName = model.UserName;
                    
                        objUser.Password = CommonFunction.EncryptPassword(model.Password);
                        objUser.CreatedBy = SessionManagement.LoggedInUser.UserId;
                        objUser.CreatedDate = DateTime.Now;
                        // objIndividualClient.EmployeeId = null;
                        // objIndividualClient.IndividualRecordId = 1;
                        objUser.IsActive = true;
                        objUser.IsDeleted = false;
                        //objIndividualClient.IsIndividualClient = true;
                        // objIndividualClient.ClientRecordId = objClient.ClientId;
                        objUser.ModifiedBy = SessionManagement.LoggedInUser.UserId;
                        objUser.ModifiedDate = DateTime.Now;
                        subuow.Repository<User>().Add(objUser);
                        subuow.SaveChanges();
                    }
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool UpdateFirm(FirmViewModel model)
        {
            try
            {
                using (DataContext = new DmsDomainContext())
                {
                    Firm objFirm = new Firm();
                    objFirm = DataContext.Firms.Where(x => x.FirmId == model.FirmId).FirstOrDefault();
                    objFirm.FirmId = Convert.ToInt32(SessionManagement.LoggedInUser.FirmId);
                    objFirm.FirmName = model.FirmName;
                    objFirm.FirmEmail = model.FirmEmail;
                    objFirm.IsActive = true;
                    objFirm.IsDeleted = false;
                    objFirm.ModifiedDate = DateTime.Now;
                    objFirm.ModifiedBy = 5534534543545;
                    objFirm.CreatedDate = DateTime.Now;
                    objFirm.CreatedBy = 5534534543545;

                    DataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Firm> GetFirmList()
        {
            try
            {
                var data = DataContext.Firms.ToList();
                return data;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        public Firm GetFirm(long FirmId)
        {
            try
            {
                using (DataContext = new DmsDomainContext())
                {
                    Firm objFirm = new Firm();


                    objFirm = DataContext.Firms.Where(x => x.FirmId == FirmId).Include(y=>y.Users).FirstOrDefault();
                    
                    return objFirm;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteFirm(long FirmId)
        {
            try
            {
                using (DataContext = new DmsDomainContext())
                {
                    var _entity = DataContext.Firms.Where(x => x.FirmId == FirmId).FirstOrDefault();
                    _entity.IsDeleted = true;
                    DataContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
