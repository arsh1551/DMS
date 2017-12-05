using System.Web.Mvc;

namespace DMS.Areas.FirmArea
{
    public class FirmAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FirmArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FirmArea_default",
                "FirmArea/{controller}/{action}/{id}",
              new { action = "Dashboard", Controller = "Firm", id = UrlParameter.Optional },
                 namespaces: new string[] { "DMS.Areas.FirmArea.Controllers" }
            );
        }
    }
}