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
    public class CashReceiveDetailsController : Controller
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: CashReceiveDetails
        public ActionResult Index()
        {
            return View(db.CashReceiveDetails.ToList());
        }

        // GET: CashReceiveDetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashReceiveDetails cashReceiveDetails = db.CashReceiveDetails.Find(id);
            if (cashReceiveDetails == null)
            {
                return HttpNotFound();
            }
            return View(cashReceiveDetails);
        }

        // GET: CashReceiveDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CashReceiveDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoucherNo,Date,SlNo,InvestigationId,PatientName,Amount")] CashReceiveDetails cashReceiveDetails)
        {
            if (ModelState.IsValid)
            {
                db.CashReceiveDetails.Add(cashReceiveDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cashReceiveDetails);
        }

        // GET: CashReceiveDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashReceiveDetails cashReceiveDetails = db.CashReceiveDetails.Find(id);
            if (cashReceiveDetails == null)
            {
                return HttpNotFound();
            }
            return View(cashReceiveDetails);
        }

        // POST: CashReceiveDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoucherNo,Date,SlNo,InvestigationId,PatientName,Amount")] CashReceiveDetails cashReceiveDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cashReceiveDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cashReceiveDetails);
        }

        // GET: CashReceiveDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashReceiveDetails cashReceiveDetails = db.CashReceiveDetails.Find(id);
            if (cashReceiveDetails == null)
            {
                return HttpNotFound();
            }
            return View(cashReceiveDetails);
        }

        // POST: CashReceiveDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CashReceiveDetails cashReceiveDetails = db.CashReceiveDetails.Find(id);
            db.CashReceiveDetails.Remove(cashReceiveDetails);
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
