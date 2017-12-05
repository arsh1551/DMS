using System.Web.Mvc;

namespace DMS.Areas.IndividualsArea
{
    public class IndividualsAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "IndividualsArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "IndividualsArea_default",
                "IndividualsArea/{controller}/{action}/{id}",
                new { action = "Dashboard", Controller= "Individual", id = UrlParameter.Optional },
                   namespaces: new string[] { "DMS.Areas.IndividualsArea.Controllers" }
            );
        }
    }
}