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
using BaiNopCuoiKi7.Common;

namespace BaiNopCuoiKi7.Controllers
{
    public class Admin1Controller : Controller
    {
        
        private BookShop db = new BookShop();

        // GET: Admin
        public ActionResult Index()
        {
            var taiKhoan = db.TaiKhoan.Include(t => t.Quyen1);
            return View(taiKhoan.ToList());
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(TaiKhoan Account)
        {
            using (BookShop db = new BookShop())
            {
                var v = db.TaiKhoan.Where(x => x.Username == Account.Username && x.Pass == Account.Pass).FirstOrDefault();
                if (v == null)
                {

                    return View("Login", Account);
                }
                else
                {
                    var userSesstion = new TaiKhoan();
                    userSesstion.ID = v.ID;
                    userSesstion.Username = v.Username;
                    Session.Add(CommonConstant.USER_SESSION, userSesstion);

                    if (v.Quyen == 1)
                    {
                        Session["Session_ADMIN"] = v;
                        Session["Session_USER"] = v;
                        //var userSesstion = new TaiKhoan();
                        //userSesstion.ID = v.ID;
                        //userSesstion.Username = v.Username;
                        //Session.Add(CommonConstant.USER_SESSION, userSesstion);
                        return Redirect("/Admin/Home/Index");
                    }
                    else
                    {
                        Session["Session_USER"] = v;
                        Session["Session_ADMIN"] = null;
                        return Redirect("/Users/Home/User_Home");
                    }


                }
            }
        }
        public ActionResult LogOut()
        {
            Session["Session_ADMIN"] = null;
            Session["Session_USER"] = null;
            return Redirect("/TrangChu/TrangChu2");
        }

        // GET: Admin/Details/5
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

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.Quyen = new SelectList(db.Quyen, "MaQuyen", "TenQuyen");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,SDT,Pass,DiaChi,Email,Quyen,RePass")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoan.Add(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Quyen = new SelectList(db.Quyen, "MaQuyen", "TenQuyen", taiKhoan.Quyen);
            return View(taiKhoan);
        }

        // GET: Admin/Edit/5
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

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
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

        // POST: Admin/Delete/5
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
