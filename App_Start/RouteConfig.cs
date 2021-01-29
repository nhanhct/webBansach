using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BaiNopCuoiKi7
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "GioHang", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controller" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BaiNopCuoiKi7.Controllers" }
            );

        }
    }
}
