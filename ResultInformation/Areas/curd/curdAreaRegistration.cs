using System.Web.Mvc;

namespace ResultInformation.Areas.curd
{
    public class curdAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "curd";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "curd_default",
                "curd/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}