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
    public class InvestigationDetailsController : Controller
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: InvestigationDetails
        public ActionResult Index()
        {
            var investigationDetails = db.InvestigationDetails.Include(i => i.Investigations);
            return View(investigationDetails.ToList());
        }

        // GET: InvestigationDetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestigationDetails investigationDetails = db.InvestigationDetails.Find(id);
            if (investigationDetails == null)
            {
                return HttpNotFound();
            }
            return View(investigationDetails);
        }

        // GET: InvestigationDetails/Create
        public ActionResult Create()
        {
            ViewBag.TestName = new SelectList(db.Investigations, "TestName", "TestGroup");
            return View();
        }

        // POST: InvestigationDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoucherNo,Date,SlNo,TestName,TestGroup,ReportGroup,Fee,Amount,Commision")] InvestigationDetails investigationDetails)
        {
            if (ModelState.IsValid)
            {
                db.InvestigationDetails.Add(investigationDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TestName = new SelectList(db.Investigations, "TestName", "TestGroup", investigationDetails.TestName);
            return View(investigationDetails);
        }

        // GET: InvestigationDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestigationDetails investigationDetails = db.InvestigationDetails.Find(id);
            if (investigationDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestName = new SelectList(db.Investigations, "TestName", "TestGroup", investigationDetails.TestName);
            return View(investigationDetails);
        }

        // POST: InvestigationDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoucherNo,Date,SlNo,TestName,TestGroup,ReportGroup,Fee,Amount,Commision")] InvestigationDetails investigationDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investigationDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TestName = new SelectList(db.Investigations, "TestName", "TestGroup", investigationDetails.TestName);
            return View(investigationDetails);
        }

        // GET: InvestigationDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestigationDetails investigationDetails = db.InvestigationDetails.Find(id);
            if (investigationDetails == null)
            {
                return HttpNotFound();
            }
            return View(investigationDetails);
        }

        // POST: InvestigationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            InvestigationDetails investigationDetails = db.InvestigationDetails.Find(id);
            db.InvestigationDetails.Remove(investigationDetails);
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
