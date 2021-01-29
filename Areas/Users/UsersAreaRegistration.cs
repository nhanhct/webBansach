using System.Web.Mvc;

namespace BaiNopCuoiKi7.Areas.Users
{
    public class UsersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Users";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Users_default",
              url:  "Users/{controller}/{action}/{id}",
               defaults: new { controller= "Home",action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BaiNopCuoiKi7.Areas.Users.Controllers" }
            );
        }
    }
}