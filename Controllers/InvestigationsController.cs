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
    public class InvestigationsController : Controller
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: Investigations
        public ActionResult Index()
        {
            return View(db.Investigations.ToList());
        }

        // GET: Investigations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investigations investigations = db.Investigations.Find(id);
            if (investigations == null)
            {
                return HttpNotFound();
            }
            return View(investigations);
        }

        // GET: Investigations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Investigations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SLNo,TestName,TestGroup,ReportGroup,Fee")] Investigations investigations)
        {
            if (ModelState.IsValid)
            {
                db.Investigations.Add(investigations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investigations);
        }

        // GET: Investigations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investigations investigations = db.Investigations.Find(id);
            if (investigations == null)
            {
                return HttpNotFound();
            }
            return View(investigations);
        }

        // POST: Investigations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SLNo,TestName,TestGroup,ReportGroup,Fee")] Investigations investigations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investigations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(investigations);
        }

        // GET: Investigations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investigations investigations = db.Investigations.Find(id);
            if (investigations == null)
            {
                return HttpNotFound();
            }
            return View(investigations);
        }

        // POST: Investigations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Investigations investigations = db.Investigations.Find(id);
            db.Investigations.Remove(investigations);
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
