using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntites.ViewModel;
using CoreEntites.Domain;
using DMS.Areas.IndividualsArea.Models;
using RepositoryLayer.Repositories.Interfaces;
using RepositoryLayer.Interfaces;
using CoreEntites.SubDomain;
using CoreEntites.SessionManagement;


namespace ServiceLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeesRepository _IEmployeeRepository = null;
        public EmployeeService(IEmployeesRepository IEmployeeRepository)
        {
            this._IEmployeeRepository = IEmployeeRepository;
        }
        public bool AddUpdateEmployee(EmployeesViewModel Emp)
        {
            Employees employee = new Employees
            {
                EmployeeId = Emp.EmployeeId,
                Address = Emp.Address,
                CreatedBy = SessionManagement.LoggedInUser.UserId,
                CreatedDate = DateTime.Now,
                FirstName = Emp.FirstName,
                HireDate = Emp.HireDate,
                TerminationDate = Emp.TerminationDate != DateTime.MinValue ? Emp.TerminationDate : DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                Lastname = Emp.Lastname,
                Title = Emp.Title
            };
            return this._IEmployeeRepository.AddUpdateEmployee(employee, Emp.ClientId);
        }
        public bool DeleteEmployee(long EmployeeId)
        {
            return this._IEmployeeRepository.DeleteEmployee(EmployeeId);
        }

        public List<ClientViewModel> GetClientsDdl()
        {
            return this._IEmployeeRepository.GetClients();
        }

        public EmployeesViewModel GetEmployeeDetail(long employeeId)
        {
            return this._IEmployeeRepository.GetEmployeeDetail(employeeId);
        }

        public List<EmployeesViewModel> GetEmployeesList(long ClientId)
        {
            return this._IEmployeeRepository.GetEmployeesList(ClientId);
        }
    }
}
