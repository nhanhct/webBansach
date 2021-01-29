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

namespace BaiNopCuoiKi7.Controllers
{
    public class UserController : Controller
    {
        private BookShop db = new BookShop();

        // GET: User
        public ActionResult Index()
        {
            var taiKhoan = db.TaiKhoan.Include(t => t.Quyen1);
            return View(taiKhoan.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
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

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.Quyen = new SelectList(db.Quyen, "MaQuyen", "TenQuyen");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,SDT,Pass,DiaChi,Email,Quyen,RePass")] TaiKhoan taiKhoan)
        {

            using (BookShop db = new BookShop())
            {
                var v = db.TaiKhoan.Where(x => x.Username == taiKhoan.Username).FirstOrDefault();
                if (v != null)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        taiKhoan.Quyen = 2;
                        db.TaiKhoan.Add(taiKhoan);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewBag.Quyen = new SelectList(db.Quyen, "MaQuyen", "TenQuyen", taiKhoan.Quyen);
            
            return View(taiKhoan);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,SDT,Pass,DiaChi,Email,Quyen,RePass")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Quyen = new SelectList(db.Quyen, "MaQuyen", "TenQuyen", taiKhoan.Quyen);
            return View(taiKhoan);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoan.Find(id);
            db.TaiKhoan.Remove(taiKhoan);
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
