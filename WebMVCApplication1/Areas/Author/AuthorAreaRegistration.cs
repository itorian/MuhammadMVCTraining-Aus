using System.Web.Mvc;

namespace WebMVCApplication1.Areas.Author
{
    public class AuthorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Author";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Author_default",
                "Author/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                //new { action = "Index", id = UrlParameter.Optional },
            );
        }
    }
}