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

namespace DMS.Areas.FirmArea.Controllers
{
    public class FirmController : Controller
    {

        IClientService _ClientService = null;
        public FirmController(IClientService ClientService)
        {

            _ClientService = ClientService;
        }

        // GET: FirmArea/Firm
        public ActionResult Dashboard()
        {
            return View();
        }

        
         public ActionResult GetClient(long? ClientId)
        {

            ClientViewModel objmodal = new ClientViewModel();
            if (ClientId != null)
            {
                TempData["clientid"] = ClientId.Value;
                //objmodal = _ClientService.GetClient(ClientId.Value);

            }
            return Json(new { result = "Redirect", url = Url.Action("AddClient", "Firm", new { Area = "FirmArea" }), objmodal });

            // return RedirectToAction("AddClient", objmodal); //View("/Areas/FirmArea/Firm/AddClient.cshtml", objmodal);
        }
        public ActionResult AddClient(ClientViewModel objmodel)
        {
            if (TempData["clientid"] != null)
            {
                objmodel = _ClientService.GetClient(Convert.ToInt64(TempData["clientid"]));
                objmodel.ClientId = Convert.ToInt64(TempData["clientid"]);
            }
            ViewBag.Success = TempData["resultMessage"];
                return View(objmodel);
        }
     

        [HttpGet]
        public JsonResult GetClients(string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            var res = _ClientService.GetClientList();
            //   var res = _adminService.GetMasterPackageList();

            sord = (sord == null) ? "" : sord;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var PackageList = res.Select(
                    t => new
                    {
                        t.ClientId,
                        t.FirstName,
                        t.LastName,
                        t.SSN,
                        t.EmailAddress,
                        t.PhoneNumber
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
                PackageList = PackageList.OrderByDescending(t => t.ClientId);
                PackageList = PackageList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                PackageList = PackageList.OrderBy(t => t.ClientId);
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
        public ActionResult SaveClient(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.ClientId != 0)
                    {
                        model.ModifiedDate = DateTime.Now;
                        try
                        {
                            bool _result = _ClientService.UpdateClient(model);
                            if (_result == true)
                            TempData["resultMessage"] = "Client Information Updated Successfully";
                            return RedirectToAction("AddClient");
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
                            bool _result = _ClientService.AddClient(model);
                            if (_result == true)
                            {
                                // TempData["resultMessage"] = "Client Added Successfully";
                                //  return RedirectToAction("AddClient");
                                var jsonDataadd = new
                                {
                                    message = "client added sysssfukkkd",

                                };

                                return Json(jsonDataadd, JsonRequestBehavior.AllowGet);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }

                    }

                    return View("AddClient");

                }
                catch (Exception ex)
                {

                    return View("AddClient");

                }

            }
            return View("AddClient");
        }

        [HttpPost]
        public ActionResult DeleteClient(int Id)
        {
            var record = _ClientService.GetClient(Id);
            if (record != null)
            {
                var result = _ClientService.DeleteClient(Id);
                TempData["resultMessage"] = "Client Deleted Successfully";
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

    }
}