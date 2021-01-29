using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using System.Net;

namespace BaiNopCuoiKi7.Areas.Users.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        BookShop db = new BookShop();

        // GET: Users/DanhMucSanPham
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SachGiaoKhoa()
        {
            var taiKhoan = db.SachGiaoKhoa;
            return View(taiKhoan.ToList());
            
        }
        public ActionResult Search(string name)
        {
            var timKiem = db.TimKiem(name);
            return View(timKiem.ToList());
        }
        public ActionResult Details(int? id)
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
        
    }
}