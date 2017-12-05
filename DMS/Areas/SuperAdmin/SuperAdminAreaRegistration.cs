using System.Web.Mvc;

namespace DMS.Areas.SuperAdmin
{
    public class SuperAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SuperAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SuperAdmin_default",
                "SuperAdmin/{controller}/{action}/{id}",
              //  new { action = "Index", id = UrlParameter.Optional }
                  new { action = "Dashboard", Controller = "Firm", id = UrlParameter.Optional },
                 namespaces: new string[] { "DMS.Areas.SuperAdmin.Controllers" }
            );
        }
    }
}