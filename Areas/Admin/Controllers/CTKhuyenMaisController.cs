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
    public class CTKhuyenMaisController : Controller
    {
        private BookShop db = new BookShop();

        // GET: Admin/CTKhuyenMais
        public ActionResult Index()
        {
            return View(db.CTKhuyenMai.ToList());
        }

        // GET: Admin/CTKhuyenMais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTKhuyenMai cTKhuyenMai = db.CTKhuyenMai.Find(id);
            if (cTKhuyenMai == null)
            {
                return HttpNotFound();
            }
            return View(cTKhuyenMai);
        }

        // GET: Admin/CTKhuyenMais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CTKhuyenMais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKM,TenKM,NgayBD,NgayKT,GiamGia")] CTKhuyenMai cTKhuyenMai)
        {
            if (ModelState.IsValid)
            {
                db.CTKhuyenMai.Add(cTKhuyenMai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cTKhuyenMai);
        }

        // GET: Admin/CTKhuyenMais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTKhuyenMai cTKhuyenMai = db.CTKhuyenMai.Find(id);
            if (cTKhuyenMai == null)
            {
                return HttpNotFound();
            }
            return View(cTKhuyenMai);
        }

        // POST: Admin/CTKhuyenMais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKM,TenKM,NgayBD,NgayKT,GiamGia")] CTKhuyenMai cTKhuyenMai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTKhuyenMai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cTKhuyenMai);
        }

        // GET: Admin/CTKhuyenMais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTKhuyenMai cTKhuyenMai = db.CTKhuyenMai.Find(id);
            if (cTKhuyenMai == null)
            {
                return HttpNotFound();
            }
            return View(cTKhuyenMai);
        }

        // POST: Admin/CTKhuyenMais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTKhuyenMai cTKhuyenMai = db.CTKhuyenMai.Find(id);
            db.CTKhuyenMai.Remove(cTKhuyenMai);
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
