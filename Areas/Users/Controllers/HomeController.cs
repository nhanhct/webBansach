using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using System.Net;

namespace BaiNopCuoiKi7.Areas.Users.Controllers
{
    public class HomeController : Controller
    {
        BookShop db = new BookShop();
        // GET: Users/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult User_Home()
        {
            var sanPham = db.SanPham;
            return View(sanPham.ToList());          
        }
        public ActionResult CT_SanPham(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }
        public ActionResult Info_Account(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoan.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }
        public ActionResult EditInfo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoan.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Quyen = new SelectList(db.Quyen, "MaQuyen", "TenQuyen", taiKhoan.Quyen);
            return View(taiKhoan);
        }
    }
}