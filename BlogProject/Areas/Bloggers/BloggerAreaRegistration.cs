using System.Web.Mvc;

namespace BlogProject.Areas.Bloggers
{
    public class BloggerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Bloggers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Bloggers_default",
                "Bloggers/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
