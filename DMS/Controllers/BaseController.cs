using CoreEntites.Common;
using CoreEntites.SessionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            #region Doamin Check
            //Commented by soumitri for removing domain check
            //using (var context = new PoologicsDBContext())
            //{
            //    List<string> domains = (from s in context.Subscribers
            //                where s.IsActive == true && s.IsDeleted == false
            //                select s.Domain.ToLower()).ToList();
            //    if (Request.Url.Host.Contains('.'))
            //    {
            //        string domainname = Request.Url.Host.Substring(0, Request.Url.Host.IndexOf('.'));
            //        if (!domainname.ToLower().Equals("app"))
            //        {
            //            if (!domains.Contains(domainname))
            //            {
            //                filterContext.Result = new RedirectResult(Url.Action("DomainNotFound", "Error", new { @area = "" }));
            //            }
            //        }

            //    }
            //}
            #endregion
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
           || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            if (!skipAuthorization)
            {
                var result = filterContext.Result as RedirectResult;
                string returnUrl = "ReturnUrl=" + Request.Url.AbsolutePath.ToString() + Request.Url.Query;
                if (filterContext.HttpContext.Request.IsAjaxRequest() && (SessionManagement.LoggedInUser == null || SessionManagement.LoggedInUser.UserId == 0))
                {

                    string message = "";
                    message = "Session Expired";
                    filterContext.HttpContext.Response.StatusCode = 402;
                    filterContext.Result = new JsonResult
                    {

                        Data = new { ErrorMessage = message },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                if (SessionManagement.LoggedInUser == null || SessionManagement.LoggedInUser.UserId == 0)
                {

                    filterContext.Result = new RedirectResult(Url.Action("Login", "Account", new { @area = "" }));
                }
                base.OnAuthorization(filterContext);
            }
        }
    }
}