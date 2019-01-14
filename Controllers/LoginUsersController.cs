using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CityLab;

namespace MVC_CityLab.Controllers
{
    public class LoginUsersController : Controller
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: LoginUsers
        public ActionResult Index()
        {
            return View(db.LoginUser.ToList());
        }

        // GET: LoginUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginUser loginUser = db.LoginUser.Find(id);
            if (loginUser == null)
            {
                return HttpNotFound();
            }
            return View(loginUser);
        }

        // GET: LoginUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,UserID,UserPassword")] LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                db.LoginUser.Add(loginUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginUser);
        }

        // GET: LoginUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginUser loginUser = db.LoginUser.Find(id);
            if (loginUser == null)
            {
                return HttpNotFound();
            }
            return View(loginUser);
        }

        // POST: LoginUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,UserID,UserPassword")] LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginUser);
        }

        // GET: LoginUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginUser loginUser = db.LoginUser.Find(id);
            if (loginUser == null)
            {
                return HttpNotFound();
            }
            return View(loginUser);
        }

        // POST: LoginUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoginUser loginUser = db.LoginUser.Find(id);
            db.LoginUser.Remove(loginUser);
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
