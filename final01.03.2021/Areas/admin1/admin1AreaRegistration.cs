using System.Web.Mvc;

namespace final01._03._2021.Areas.admin1
{
    public class admin1AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin1";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "admin1_default",
                "admin1/{controller}/{action}/{id}",
                new { Controller= "home", action = "Index", id = UrlParameter.Optional },
                new string[] { "final01._03._2021.Areas.admin1.Controllers" }

            );
        }
    }
}