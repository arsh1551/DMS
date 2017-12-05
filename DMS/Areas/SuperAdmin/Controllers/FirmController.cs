using CoreEntites.Common;
using CoreEntites.SessionManagement;
using CoreEntites.ViewModel;
using DMS.Areas.FirmArea;

using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Areas.SuperAdmin.Controllers
{
    public class FirmController : Controller
    {
        private IAccountService _iAcconutService;
        IFirmService _FirmService = null;
        public FirmController(IFirmService FirmService)
        {

            _FirmService = FirmService;
        }

        // GET: SuperAdmin/Firm
        public ActionResult Dashboard()
        {
            return View();
        }

        
         public ActionResult GetFirm(long? FirmId)
        {

            FirmViewModel objmodal = new FirmViewModel();
            if (FirmId != null)
            {
                TempData["FirmId"] = FirmId.Value;
                //objmodal = _ClientService.GetClient(ClientId.Value);

            }
            return Json(new { result = "Redirect", url = Url.Action("AddFirm", "Firm", new { Area = "SuperAdmin" }), objmodal });

            // return RedirectToAction("AddClient", objmodal); //View("/Areas/FirmArea/Firm/AddClient.cshtml", objmodal);
        }
        public ActionResult AddFirm(FirmViewModel objmodel)
        {
            if (TempData["FirmId"] != null)
            {
                objmodel = _FirmService.GetFirm(Convert.ToInt64(TempData["FirmId"]));
                objmodel.FirmId = Convert.ToInt64(TempData["FirmId"]);
            }
            ViewBag.Success = TempData["resultMessage"];
                return View(objmodel);
        }
     

        [HttpGet]
        public JsonResult GetFirms(string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            var res = _FirmService.GetFirmList();
            //   var res = _adminService.GetMasterPackageList();

            sord = (sord == null) ? "" : sord;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var PackageList = res.Select(
                    t => new
                    {
                        t.FirmId,
                        t.FirmName,
                        t.FirmEmail,
                        //t.SSN,
                        //t.EmailAddress,
                        //t.PhoneNumber
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

          
            int totalRecords = PackageList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                PackageList = PackageList.OrderByDescending(t => t.FirmId);
                PackageList = PackageList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                PackageList = PackageList.OrderBy(t => t.FirmId);
                PackageList = PackageList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = PackageList
            };
            
return Json(jsonData, JsonRequestBehavior.AllowGet);


        }



        [HttpPost]
        public ActionResult SaveFirm(FirmViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.FirmId != 0)
                    {
                        model.ModifiedDate = DateTime.Now;
                        try
                        {
                            bool _result = _FirmService.UpdateFirm(model);
                            if (_result == true)
                            TempData["resultMessage"] = "Firm Information Updated Successfully";
                            return RedirectToAction("Dashboard");
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }

                    }
                    else
                    {
                        model.CreatedDate = DateTime.Now;
                        try
                        {
                            bool _result = _FirmService.AddFirm(model);
                            if (_result == true)
                                TempData["resultMessage"] = "Firm Added Successfully";
                            return RedirectToAction("Dashboard");
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }

                    }

                    //return View("AddClient");

                }
                catch (Exception ex)
                {

                    return View("AddClient");

                }

            }
            return View("Dashboard");
        }
      
        
        [HttpPost]
        public ActionResult DeleteFirm(int FirmId)
        {
            var record = _FirmService.GetFirm(FirmId);
            if (record != null)
            {
                var result = _FirmService.DeleteFirm(FirmId);
                TempData["resultMessage"] = "Firm Deleted Successfully";
                var res = new
                {
                    success = true,
                      
            };

                return Json(res, JsonRequestBehavior.AllowGet);

            }
            else
            {

                var res = new
                {
                    success = false
                };
                return Json(res, JsonRequestBehavior.AllowGet);

            }



        }
        [HttpPost]
        public ActionResult UserExists11(string UserName)
        {
            bool _result = _iAcconutService.IsUserExists(UserName);
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
    }
}