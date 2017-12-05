using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntites.SubDomain;
using CoreEntites.ViewModel;
using CoreEntites.Domain.Master;
using CoreEntites.Domain;
using CoreEntites.SessionManagement;

namespace RepositoryLayer.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        #region Initialize
        UnityOfWork uow = null;
        UnityOfWork subuow = null;
        DmsDomainContext DataContext;
        DmsSubDomainContext SubDataContext;
        public EmployeesRepository()
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
        public bool AddUpdateEmployee(Employees Employee,long clientId)
        {
            bool success = false;
            if(Employee.EmployeeId>0)
            {
                var empdetail = SubDataContext.Employees.Where(x => x.EmployeeId == Employee.EmployeeId).FirstOrDefault();
                empdetail.Title = Employee.Title;
                empdetail.FirstName = Employee.FirstName;
                empdetail.Lastname = Employee.Lastname;
                empdetail.HireDate = Employee.HireDate;
                empdetail.TerminationDate = Employee.TerminationDate;
                empdetail.Address = Employee.Address;                
                subuow.SaveChanges();
            }
           else
            {
                subuow.Repository<Employees>().Add(Employee);
                subuow.SaveChanges();
            }
            IndividualClient iclient = new IndividualClient();
            iclient.ClientRecordId = clientId;
            iclient.EmployeeId = Employee.EmployeeId;
            iclient.CreatedBy = SessionManagement.LoggedInUser.UserId;
            iclient.CreatedDate = DateTime.Now;
            iclient.IndividualClientRecordId = 1;
            iclient.IndividualRecordId = 1;
            iclient.IsActive = true;
            iclient.IsDeleted = false;
            subuow.Repository<IndividualClient>().Add(iclient);
            subuow.SaveChanges();
            success = true;
            return success;
        }
        public bool DeleteEmployee(long EmployeeId)
        {
            var employee = SubDataContext.Employees.Where(x => x.EmployeeId == EmployeeId).FirstOrDefault();
            if(employee!=null)
            {
                employee.IsDeleted = true;                
                subuow.SaveChanges();
                return true;
            }
            return false;
        }

        public List<ClientViewModel> GetClients()
        {
            var data = (from p in SubDataContext.Clients where p.IsDeleted == false select new ClientViewModel { ClientName = p.ClientName, ClientId = p.ClientId }).ToList();
            return data;
        }

        public EmployeesViewModel GetEmployeeDetail(long employeeId)
        {
            var data = (from p in SubDataContext.Employees
                        where p.IsDeleted == false && p.EmployeeId==employeeId
                        join ic in  SubDataContext.IndividualClient on p.EmployeeId equals ic.EmployeeId
                        select new EmployeesViewModel
                        {                            
                            ClientId=ic.ClientRecordId,
                            Address = p.Address,
                            EmployeeId = p.EmployeeId,
                            FirstName = p.FirstName,
                            Lastname = p.Lastname,
                            HireDate = p.HireDate,
                            IsActive = p.IsActive,
                            IsDeleted = p.IsDeleted,
                            TerminationDate = p.TerminationDate,
                            Title = p.Title
                        }).FirstOrDefault();
            return data;
        }

        public List<EmployeesViewModel> GetEmployeesList(long ClientId)
        {
            var data = (from p in SubDataContext.Employees
                        where p.IsDeleted == false
                        select new EmployeesViewModel
                        {
                            Address = p.Address,
                            EmployeeId = p.EmployeeId,
                            FirstName = p.FirstName,
                            Lastname = p.Lastname,
                            HireDate = p.HireDate,
                            IsActive = p.IsActive,
                            IsDeleted = p.IsDeleted,
                            TerminationDate = p.TerminationDate,
                            Title = p.Title
                        }).ToList();
                
            return data;
        }
    }
}
