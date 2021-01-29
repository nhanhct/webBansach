using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiNopCuoiKi7.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        public ActionResult Index()
        {
            return View("TrangChu2");
        }
        public ActionResult TrangChu2()
        {
            return View();
        }
        public ActionResult TrangChuDNTC()
        {
            return View();
        }
    }
}