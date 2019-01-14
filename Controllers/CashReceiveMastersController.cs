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
    public class CashReceiveMastersController : Controller
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: CashReceiveMasters
        public ActionResult Index()
        {
            return View(db.CashReceiveMaster.ToList());
        }

        // GET: CashReceiveMasters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashReceiveMaster cashReceiveMaster = db.CashReceiveMaster.Find(id);
            if (cashReceiveMaster == null)
            {
                return HttpNotFound();
            }
            return View(cashReceiveMaster);
        }

        // GET: CashReceiveMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CashReceiveMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoucherNo,Date,InvestigationId,PatientName,TotalAmount")] CashReceiveMaster cashReceiveMaster)
        {
            if (ModelState.IsValid)
            {
                db.CashReceiveMaster.Add(cashReceiveMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cashReceiveMaster);
        }

        // GET: CashReceiveMasters/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashReceiveMaster cashReceiveMaster = db.CashReceiveMaster.Find(id);
            if (cashReceiveMaster == null)
            {
                return HttpNotFound();
            }
            return View(cashReceiveMaster);
        }

        // POST: CashReceiveMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoucherNo,Date,InvestigationId,PatientName,TotalAmount")] CashReceiveMaster cashReceiveMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cashReceiveMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cashReceiveMaster);
        }

        // GET: CashReceiveMasters/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashReceiveMaster cashReceiveMaster = db.CashReceiveMaster.Find(id);
            if (cashReceiveMaster == null)
            {
                return HttpNotFound();
            }
            return View(cashReceiveMaster);
        }

        // POST: CashReceiveMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CashReceiveMaster cashReceiveMaster = db.CashReceiveMaster.Find(id);
            db.CashReceiveMaster.Remove(cashReceiveMaster);
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
