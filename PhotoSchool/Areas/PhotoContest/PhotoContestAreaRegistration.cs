using System.Web.Mvc;

namespace PhotoSchool.Areas.PhotoContest
{
    public class PhotoContestAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PhotoContest";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PhotoContest_default",
                "PhotoContest/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}