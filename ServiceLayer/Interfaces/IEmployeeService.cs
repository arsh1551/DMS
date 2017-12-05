using CoreEntites.SubDomain;
using CoreEntites.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IEmployeeService
    {
        #region List of Employees
        List<EmployeesViewModel> GetEmployeesList(long ClientId);
        #endregion
        #region Employee Crud
        bool AddUpdateEmployee(EmployeesViewModel Employee);
        bool DeleteEmployee(long EmployeeId);
        List<ClientViewModel> GetClientsDdl();
        EmployeesViewModel GetEmployeeDetail(long employeeId);
        #endregion
    }
}
