using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using BaiNopCuoiKi7.Areas.Users.Models;
using System.Web.Script.Serialization;
using Models.DAO;

namespace BaiNopCuoiKi7.Areas.Users.Controllers
{
    public class GioHangController : Controller
    {
        BookShop db = new BookShop();
        
        // GET: Users/GioHang
        public ActionResult Index()
        {
            var cart = Session["CartSession"];
            var list = new List<ThongTinGioHang>();
            if(cart!=null)
            {
                list = (List<ThongTinGioHang>)cart;
            }
            return View(list);
        }

        public ActionResult ThemSPvaoGH(int MaSP,int Soluong)
        {
            var session = (TaiKhoan)Session[BaiNopCuoiKi7.Common.CommonConstant.USER_SESSION];
            var giohang = new GioHang();
            if (session != null)
            {
                giohang.Ngay = DateTime.Now;
                giohang.MaKH = session.ID;
            }
            var id = new OrderDao().Insertt(giohang);
            var sanpham = db.SanPham.Find(MaSP);
            var gh = Session["CartSession"];
            if(gh!=null)
            {
                var DanhSachGH = (List<ThongTinGioHang>)gh;
                if(DanhSachGH.Exists(x=>x.SanPham.MaSP==MaSP))
                {
                    foreach (var item in DanhSachGH)
                    {
                        if (item.SanPham.MaSP == MaSP)
                        {
                            
                            item.Soluong -= -Soluong;
                        }
                    }
                }
                else
                {
                    var item = new ThongTinGioHang();
                    item.SanPham = sanpham;
                    item.Soluong = Soluong;
                    DanhSachGH.Add(item);
                }
                Session["CartSession"] = gh;
            }
            else
            {
                var item = new ThongTinGioHang();
                item.SanPham = sanpham;
                item.Soluong = Soluong;
                var list = new List<ThongTinGioHang>();
                list.Add(item);
                Session["CartSession"] = list;
            }
            return RedirectToAction("Index");
        }
        
        public JsonResult CapNhatGH(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<ThongTinGioHang>>(cartModel);
            var sessionCart = (List<ThongTinGioHang>)Session["CartSession"];
            foreach ( var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.SanPham.MaSP == item.SanPham.MaSP);
                if ( jsonItem != null )
                {
                    item.Soluong = jsonItem.Soluong;
                }
            }
            Session["CartSession"] = sessionCart;
            return Json(new { status = true });
        }
        public JsonResult XoaGH()
        {
            Session["CartSession"] = null;
            return Json(new { status = true });
        }
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<ThongTinGioHang>)Session["CartSession"];
            sessionCart.RemoveAll(x => x.SanPham.MaSP == id);
            Session["CartSession"] = sessionCart;
            return Json(new { status = true });
        }
        public ActionResult Payment()
        {
            var cart = Session["CartSession"];
            var list = new List<ThongTinGioHang>();
            if (cart != null)
            {
                list = (List<ThongTinGioHang>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string address)
        {
            var session = (TaiKhoan)Session[BaiNopCuoiKi7.Common.CommonConstant.USER_SESSION];
            var order = new DonHang();
            if (session != null)
            {
                order.NgayThanhToan = DateTime.Now;
                order.NoiNhan = address;
                order.MaKH = session.ID;
            }
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<ThongTinGioHang>)Session["CartSession"];
                var detailDao = new OrderDetailDao();
                foreach (var item in cart)
                {
                    var orderdetail = new CT_GioHang();
                    orderdetail.MaSP = item.SanPham.MaSP;
                    orderdetail.SoLuong = item.Soluong;
                    orderdetail.GiaSP = item.SanPham.GiaSP;
                    detailDao.Insert(orderdetail);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Redirect("/Users/GioHang/ThanhCong");
        }
        public ActionResult ThanhCong()
        {
            return View();
        }
    }
}