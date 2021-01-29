using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using BaiNopCuoiKi7.Models;
using Models.EF;

namespace BaiNopCuoiKi7.Areas.Admin.Controllers
{
    public class SanPhamsController : Controller
    {
        private BookShop db = new BookShop();

        // GET: Admin/SanPhams
        public ActionResult Index()
        {
            var sanPham = db.SanPham.Include(s => s.DanhMucSanPham).Include(s => s.NhaCungCap).Include(s => s.NhaXuatBan);
            return View(sanPham.ToList());
        }

        // GET: Admin/SanPhams/Details/5
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

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaDMSP = new SelectList(db.DanhMucSanPham, "MaDMSP", "TenDMSP");
            ViewBag.MaNCC = new SelectList(db.NhaCungCap, "MaNCC", "TenNCC");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,GiaSP,GiaNhap,SoLuong,TacGia,HinhAnh,MoTa,NgonNgu,MaDMSP,SLDaBan,MaNCC,MaNXB")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPham.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDMSP = new SelectList(db.DanhMucSanPham, "MaDMSP", "TenDMSP", sanPham.MaDMSP);
            ViewBag.MaNCC = new SelectList(db.NhaCungCap, "MaNCC", "TenNCC", sanPham.MaNCC);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sanPham.MaNXB);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.MaDMSP = new SelectList(db.DanhMucSanPham, "MaDMSP", "TenDMSP", sanPham.MaDMSP);
            ViewBag.MaNCC = new SelectList(db.NhaCungCap, "MaNCC", "TenNCC", sanPham.MaNCC);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sanPham.MaNXB);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,GiaSP,GiaNhap,SoLuong,TacGia,HinhAnh,MoTa,NgonNgu,MaDMSP,SLDaBan,MaNCC,MaNXB")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDMSP = new SelectList(db.DanhMucSanPham, "MaDMSP", "TenDMSP", sanPham.MaDMSP);
            ViewBag.MaNCC = new SelectList(db.NhaCungCap, "MaNCC", "TenNCC", sanPham.MaNCC);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sanPham.MaNXB);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
