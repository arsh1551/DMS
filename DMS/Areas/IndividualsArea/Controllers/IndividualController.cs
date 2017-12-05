using CoreEntites.Common;
using CoreEntites.SessionManagement;
using CoreEntites.ViewModel;
using DMS.Areas.IndividualsArea.Models;
using DMS.Controllers;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Areas.IndividualsArea.Controllers
{
    public class IndividualController : Controller
    {
        IAccountService _AccountService = null;
        IIndividualService _IndividualService = null;
        public IndividualController(IAccountService AccountService, IIndividualService IndividualService)
        {
            _AccountService = AccountService;
            _IndividualService = IndividualService;
        }

        // GET: IndividualsArea/Individual
        public ActionResult Dashboard()
        {            
            return View();
        }
        /// <summary>
        /// CreatedDate:23-Nov-2017
        /// Desc:Get detail of Individual Client
        /// </summary>
        /// <returns></returns>
        public ActionResult GetIndividualClientDetail()
        {
            IndividualRegistrationViewModel _detail = _IndividualService.GetIndividualClientDetail(SessionManagement.LoggedInUser.UserId);
            ViewBag.Prefix = CommonFunction.GetPrefix();
            return PartialView("_EditIndividualPartial", _detail);
            //return Json(_detail, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// CreatedDate:23-Nov-2017
        /// Desc:Update Record of Individual user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditIndividualProfile(IndividualRegistrationViewModel _IndividualDetail)
        {
            try
            {
                bool _result = _IndividualService.UpdateIndividualClient(_IndividualDetail);
                if (_result == true)
                    TempData["Message"] = "Information Updated Successfully";
                return RedirectToAction("EditProfile");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private IndividualRegistrationViewModel DetailForIndividualClient(FormCollection formCollection)
        {
            IndividualRegistrationViewModel _IndividualDetail = new IndividualRegistrationViewModel();
            _IndividualDetail.IndividualRecordId = Convert.ToInt64(formCollection["IndividualRecordId"]);
            _IndividualDetail.Prefix = formCollection["Prefix"];
            _IndividualDetail.FirstName = formCollection["FirstName"];
            _IndividualDetail.MiddleName = formCollection["MiddleName"];
            _IndividualDetail.LastName = formCollection["LastName"];
            _IndividualDetail.BirthDate = formCollection["BirthDate"];
            _IndividualDetail.SSN = formCollection["SSN"];
            _IndividualDetail.Phone = formCollection["Phone"];
            _IndividualDetail.Suffix = formCollection["Suffix"];
            return _IndividualDetail;
        }
        /// <summary>
        /// CreatedDate:22-Nov-2017
        /// Desc:Check the SSN already exists in db or not when updating a user
        /// </summary>
        /// <param name="SSN"></param>
        /// <returns></returns>
        public ActionResult IsSSNExistsForIndividualClient(string SSN, string IndividualRecordId)
        {
            bool _result = _IndividualService.IsSSNExistsForIndividualClient(SSN, Convert.ToInt64(IndividualRecordId));
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// CreatedDate:25-Nov-2017
        /// Desc:To update the individual client's profile
        /// </summary>
        /// <returns></returns>
        public ActionResult EditProfile()
        {
            IndividualRegistrationViewModel _detail = _IndividualService.GetIndividualClientDetail(SessionManagement.LoggedInUser != null ? SessionManagement.LoggedInUser.UserId : 0);
            _detail.lstPrefix = CommonFunction.GetPrefix();
            if (!string.IsNullOrEmpty(Convert.ToString(TempData["Message"])))
                ViewBag.Message = TempData["Message"];
            return View(_detail);
        }

        public ActionResult ChangePassword()
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            if (SessionManagement.LoggedInUser != null)
            {
                model.UserId = SessionManagement.LoggedInUser.UserId;
            }
            return PartialView("_ChangePassword", model);
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            bool result = _AccountService.ChangePassword(model);
            if (result)
                ViewBag.Message = "Password has been Changed Successfully";
            else
                ViewBag.Message = "Old Password is not correct!";

            return PartialView("_ChangePassword", model);
        }
    }
}