using CoreEntites.SessionManagement;
using CoreEntites.Common;
using DMS.Areas.IndividualsArea.Models;
using ServiceLayer.Interfaces;
using System;
using System.IO;
using System.Web.Mvc;
using static CoreEntites.SessionManagement.SessionManagement;
using CoreEntites.ViewModel;
using System.Web.Security;

namespace DMS.Controllers
{
    public class AccountController : Controller
    {
        #region Variables
        private IAccountService _iAcconutService;
        private IEmailService _iEmailService;
        #endregion
        #region Constructor
        public AccountController(IAccountService AccountService, IEmailService EmailService)
        {
            this._iAcconutService = AccountService;
            this._iEmailService = EmailService;
        }
        #endregion

        #region Login

        /// <summary>
        /// CreatedDate:21-Nov-2017
        /// Desc:Login for the Users
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            if (SessionManagement.LoggedInUser == null || SessionManagement.LoggedInUser.UserId == 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AddClient", "Firm", new { area = "FirmArea" });
            }

        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var obj = _iAcconutService.LoginUser(model);
            if (obj != null)
            {
                LoggedUserDetail userdetail = new LoggedUserDetail { UserId = obj.UserId, Email = obj.Email, FirstName = obj.FirstName, IndividualRecordId = obj.IndividualRecordId, UserName = obj.UserName };
                SessionManagement.LoggedInUser = userdetail;
                return RedirectToAction("Dashboard", "Firm", new { area = "FirmArea" });
            }
            ViewBag.Message = "Invalid Email or Password!";
            return View();
        }
        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account", new { area = "" });
        }
        #endregion

        #region Registeration
        /// <summary>
        /// CreatedDate:21-Nov-2017
        /// Desc:Registraion for the Indvidual Clients
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(TempData["Result"])))
            {
                ViewBag.Message = TempData["Result"];
            }
            ViewBag.Prefix = CommonFunction.GetPrefix();
            return View();
        }

        [HttpPost]
        public ActionResult Register(IndividualRegistrationViewModel IndividualRegistrationModel)
        {
            try
            {
                bool _result = _iAcconutService.InsertIndividualClient(IndividualRegistrationModel);
                if (_result == true)
                {
                    TempData["Result"] = "You have successfully registered.";
                }
                else
                {
                    TempData["Result"] = "Error occured while registeration";
                }
                return RedirectToAction("Register");
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        /// <summary>
        /// CreatedDate:22-Nov-2017
        /// Desc:To check Email exists or not
        /// </summary>
        /// <param name="EmailAddress"></param>
        /// <returns></returns>
        public ActionResult IsEmailExists(string EmailAddress)
        {
            bool _result = _iAcconutService.IsEmailExists(EmailAddress);
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// CreatedDate:22-Nov-2017
        /// Desc:To check UserName exists or not
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public ActionResult IsUserExists(string UserName)
        {
            bool _result = _iAcconutService.IsUserExists(UserName);
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// CreatedDate:22-Nov-2017
        /// Desc:Check the SSN already exists in db or not
        /// </summary>
        /// <param name="SSN"></param>
        /// <returns></returns>
        public ActionResult IsSSNExists(string SSN)
        {
            bool _result = _iAcconutService.IsSSNExists(SSN);
            return Json(_result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Manage user

        public ActionResult ChangePassword()
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            if (SessionManagement.LoggedInUser != null)
            {
                model.UserId = SessionManagement.LoggedInUser.UserId;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            bool result = _iAcconutService.ChangePassword(model);
            if (result)
                ViewBag.Message = "Password has been Change Successfully";
            else
                ViewBag.Message = "Old Password Is not correct!";

            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SendMailForgotPassword(ForgetPasswordViewModel forgetpassword)
        {
            if (!string.IsNullOrEmpty(forgetpassword.Email))
            {

                var data = _iAcconutService.IsEmailExists(forgetpassword.Email);
                if (data)
                {
                    UserViewModel userdetail = _iAcconutService.GetUserByEmail(forgetpassword.Email);
                    forgetpassword.tempUserId = CommonFunction.EncryptPassword(userdetail.UserId.ToString());
                    forgetpassword.Name = userdetail.FirstName;
                    string mailBody = RenderRazorViewToString("~/Views/EmailTemplates/UserForgetPassword_Template.cshtml", forgetpassword);
                    _iEmailService.SendForgotPasswordEmail(userdetail.FirstName,userdetail.Email, userdetail.Email,mailBody);
                    return Json(data, JsonRequestBehavior.AllowGet);

                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);


        }

        public ActionResult ResetPassword(string id)
        {
            string userid = string.Empty;
            ResetPasswordViewModel model = new ResetPasswordViewModel();
            if (!string.IsNullOrEmpty(id))
            {
                userid = CommonFunction.DecryptPassword(id);
                model.UserId = Convert.ToInt64(userid);
            }
            else
            {
                return RedirectToAction("ForgotPassword", "Account", new { @area = "" });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel resetpassword)
        {
            string message = _iAcconutService.ResetUserPassword(resetpassword);
            return RedirectToAction("Login", "Account", new { @area = "" });
        }
        #endregion

        #region Methods
        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        #endregion

    }
}