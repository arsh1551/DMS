using CoreEntites.ViewModel;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Areas.FirmArea.Controllers
{
    public class EmployeesController : Controller
    {
        IEmployeeService _EmployeeService = null;
        public EmployeesController(IEmployeeService EmployeeService)
        {
            this._EmployeeService = EmployeeService;
        }
        // GET: FirmArea/Employees
        public ActionResult Index()
        {
            return View("Employees");
        }
        [HttpGet]
        public JsonResult GetEmployees(string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            var employees = _EmployeeService.GetEmployeesList(1);
            sord = (sord == null) ? "" : sord;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var EmployeesList = employees.Select(
                    t => new
                    {
                        t.EmployeeId,
                        t.FirstName,
                        t.Address,
                        t.HireDate,
                        t.TerminationDate,
                        t.Title,
                        t.Lastname
                    });

            //if (_search)
            //{
            //    switch (searchField)
            //    {
            //        case "PackageName":
            //            PackageList = PackageList.Where(t => t.PackageName.Contains(searchString));
            //            break;
            //        case "MonthlyRate":
            //            PackageList = PackageList.Where(t => t.MonthlyRate.ToString().Contains(searchString));
            //            break;
            //        case "YearlyRate":
            //            PackageList = PackageList.Where(t => t.YearlyRate.ToString().Contains(searchString));
            //            break;
            //        case "SetUpFee":
            //            PackageList = PackageList.Where(t => t.SetUpFee.ToString().Contains(searchString));
            //            break;
            //    }
            //}


            int totalRecords = EmployeesList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                EmployeesList = EmployeesList.OrderByDescending(t => t.FirstName);
                EmployeesList = EmployeesList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                EmployeesList = EmployeesList.OrderBy(t => t.FirstName);
                EmployeesList = EmployeesList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = EmployeesList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddEditEmployee(long? employeeid)
        {
            EmployeesViewModel emp = new EmployeesViewModel();

            if (employeeid != null)
            {
                emp = _EmployeeService.GetEmployeeDetail(Convert.ToInt64(employeeid));
            }
            emp.Clients = _EmployeeService.GetClientsDdl();
            return View(emp);
        }
        [HttpPost]
        public JsonResult AddEditEmployee(EmployeesViewModel employee)
        {
            var result = _EmployeeService.AddUpdateEmployee(employee);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteEmployee(long employeeId)
        {
            var result = _EmployeeService.DeleteEmployee(employeeId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}