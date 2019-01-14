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
    public class InvestigationMastersController : Controller
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: InvestigationMasters
        public ActionResult Index()
        {
            var investigationMaster = db.InvestigationMaster.Include(i => i.Doctors);
            return View(investigationMaster.ToList());
        }

        // GET: InvestigationMasters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestigationMaster investigationMaster = db.InvestigationMaster.Find(id);
            if (investigationMaster == null)
            {
                return HttpNotFound();
            }
            return View(investigationMaster);
        }

        // GET: InvestigationMasters/Create
        public ActionResult Create()
        {
            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "DoctorName");
            return View();
        }

        // POST: InvestigationMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoucherNo,Date,PatientName,Guardian,Address,SLNo,Mobile,BirthDate,Gender,DoctorID,Total,Discount,NetAmt,PaidAmt,DueAmt")] InvestigationMaster investigationMaster)
        {
            if (ModelState.IsValid)
            {
                db.InvestigationMaster.Add(investigationMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "DoctorName", investigationMaster.DoctorID);
            return View(investigationMaster);
        }

        // GET: InvestigationMasters/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestigationMaster investigationMaster = db.InvestigationMaster.Find(id);
            if (investigationMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "DoctorName", investigationMaster.DoctorID);
            return View(investigationMaster);
        }

        // POST: InvestigationMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoucherNo,Date,PatientName,Guardian,Address,SLNo,Mobile,BirthDate,Gender,DoctorID,Total,Discount,NetAmt,PaidAmt,DueAmt")] InvestigationMaster investigationMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investigationMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "DoctorName", investigationMaster.DoctorID);
            return View(investigationMaster);
        }

        // GET: InvestigationMasters/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestigationMaster investigationMaster = db.InvestigationMaster.Find(id);
            if (investigationMaster == null)
            {
                return HttpNotFound();
            }
            return View(investigationMaster);
        }

        // POST: InvestigationMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            InvestigationMaster investigationMaster = db.InvestigationMaster.Find(id);
            db.InvestigationMaster.Remove(investigationMaster);
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
