using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace BaiNopCuoiKi7.Areas.Admin.Controllers
{
    public class DanhMucSanPhamsController : Controller
    {
        private BookShop db = new BookShop();

        // GET: Admin/DanhMucSanPhams
        public ActionResult Index()
        {
            return View(db.DanhMucSanPham.ToList());
        }

        // GET: Admin/DanhMucSanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPham.Find(id);
            if (danhMucSanPham == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSanPham);
        }

        // GET: Admin/DanhMucSanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMucSanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDMSP,TenDMSP")] DanhMucSanPham danhMucSanPham)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucSanPham.Add(danhMucSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhMucSanPham);
        }

        // GET: Admin/DanhMucSanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPham.Find(id);
            if (danhMucSanPham == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSanPham);
        }

        // POST: Admin/DanhMucSanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDMSP,TenDMSP")] DanhMucSanPham danhMucSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMucSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMucSanPham);
        }

        // GET: Admin/DanhMucSanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPham.Find(id);
            if (danhMucSanPham == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSanPham);
        }

        // POST: Admin/DanhMucSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPham.Find(id);
            db.DanhMucSanPham.Remove(danhMucSanPham);
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
