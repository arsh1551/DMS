using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntites.Domain;
using CoreEntites.ViewModel;
using DMS.Areas.IndividualsArea.Models;
using CoreEntites.SubDomain;

namespace RepositoryLayer.Interfaces
{
    public interface IEmployeesRepository
    {
        #region List of Employees
        List<EmployeesViewModel> GetEmployeesList(long ClientId);
        EmployeesViewModel GetEmployeeDetail(long employeeId);
        #endregion
        #region Employee Crud
        bool AddUpdateEmployee(Employees Employee,long clientId);
        bool DeleteEmployee(long EmployeeId);
        List<ClientViewModel> GetClients();
        #endregion

    }
}
