using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

using CoreEntites.Domain.Master;
using CoreEntites.Domain;
using CoreEntites.SubDomain;
using CoreEntites.SessionManagement;
using CoreEntites.ViewModel;

namespace RepositoryLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {

        #region Initialize
        UnityOfWork uow = null;
        UnityOfWork subuow = null;
        DmsDomainContext DataContext;
        DmsSubDomainContext SubDataContext;
        public ClientRepository()
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
        public bool AddClient(ClientViewModel model)
        {
            try
            {
                using (SubDataContext = new DmsSubDomainContext())
                {
                    Clients objClient = new Clients();
                    objClient.AccountingFirmId = Convert.ToInt32(SessionManagement.LoggedInUser.FirmId);
                    objClient.ClientName = model.ClientName;
                    objClient.ClientAddress = model.ClientAddress;
                    objClient.Phone = model.PhoneNumber;
                    objClient.EmailAddress = model.EmailAddress;
                    objClient.FirstName = model.FirstName;
                    objClient.MiddleName = model.MiddleName;
                    objClient.LastName = model.LastName;
                    objClient.ClientType = model.ClientType;
                    objClient.BirthDate = Convert.ToDateTime(model.BirthDate);
                    objClient.SSN = Convert.ToString(model.SSN);
                    objClient.IsActive = true;
                    objClient.IsDeleted = false;
                   
                    objClient.CreatedDate = DateTime.Now;
                    objClient.CreatedBy = SessionManagement.LoggedInUser.UserId;

                    subuow.Repository<Clients>().Add(objClient);
                    subuow.SaveChanges();
                    
                     if(model.ClientType == 1)
                    {
                        IndividualClient objIndividualClient = new IndividualClient();
                        objIndividualClient.ClientRecordId = 1;
                        objIndividualClient.CreatedBy = SessionManagement.LoggedInUser.UserId;
                        objIndividualClient.CreatedDate = DateTime.Now;
                        // objIndividualClient.EmployeeId = null;
                        objIndividualClient.IndividualRecordId = 1;
                        objIndividualClient.IsActive = true;
                        objIndividualClient.IsDeleted = false;
                        objIndividualClient.IsIndividualClient = true;
                        objIndividualClient.ClientRecordId = objClient.ClientId;
                        subuow.Repository<IndividualClient>().Add(objIndividualClient);
                        subuow.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateClient(ClientViewModel model)
        {
            try
            {
                using (SubDataContext = new DmsSubDomainContext())
                {
                    Clients objClient = new Clients();
                    objClient = SubDataContext.Clients.Where(x => x.ClientId == model.ClientId).FirstOrDefault();
                    objClient.AccountingFirmId = Convert.ToInt32(SessionManagement.LoggedInUser.FirmId);
                    objClient.ClientName = model.ClientName;
                    objClient.ClientAddress = model.ClientAddress;
                    objClient.Phone = model.PhoneNumber;
                    objClient.EmailAddress = model.EmailAddress;
                    objClient.FirstName = model.FirstName;
                    objClient.MiddleName = model.MiddleName;
                    objClient.LastName = model.LastName;
                    objClient.ClientType = model.ClientType;
                    objClient.BirthDate = Convert.ToDateTime(model.BirthDate);
                    objClient.SSN = Convert.ToString(model.SSN);
                    objClient.IsActive = true;
                    objClient.IsDeleted = false;
                    objClient.ModifiedDate = DateTime.Now;
                    objClient.ModifiedBy = 5534534543545;
                    objClient.CreatedDate = DateTime.Now;
                    objClient.CreatedBy = 5534534543545;

                    SubDataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Clients> GetClientList()
        {
            try
            {
                var data = SubDataContext.Clients.Where(x => !x.IsDeleted).ToList();
                return data;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        public Clients GetClient(long ClientId)
        {
            try
            {
                using (SubDataContext = new DmsSubDomainContext())
                {
                    Clients objClient = new Clients();


                    objClient = SubDataContext.Clients.Where(x => x.ClientId == ClientId).FirstOrDefault();

                    return objClient;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteClient(long ClientId)
        {
            try
            {
                using (SubDataContext = new DmsSubDomainContext())
                {
                    var _entity = SubDataContext.Clients.Where(x => x.ClientId == ClientId).FirstOrDefault();
                    _entity.IsDeleted = true;
                    SubDataContext.SaveChanges();
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
