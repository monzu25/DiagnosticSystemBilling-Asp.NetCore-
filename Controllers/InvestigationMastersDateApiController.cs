using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVC_CityLab;

namespace MVC_CityLab.Controllers
{
    public class InvestigationMastersDateApiController : ApiController
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: api/InvestigationMastersDateApi
        public IQueryable<InvestigationMaster> GetInvestigationMaster()
        {
            return db.InvestigationMaster;
        }





        [HttpGet, ActionName("GetInvestigationByVrNo")]
        public IQueryable<InvestigationMaster> GetInvestigationByVrNo(string voucherno)
        {
            return (from a in db.InvestigationMaster where a.VoucherNo == voucherno orderby a.SLNo select a);
        }




        //Get data using date criteria//

        [HttpGet, ActionName("GetInvestigationByDate")]
        public IQueryable<InvestigationMaster> GetInvestigationByDate(DateTime d1, DateTime d2)
        {
            return (from a in db.InvestigationMaster where a.Date >= d1 && a.Date <= d2 orderby a.Date, a.VoucherNo, a.SLNo select a);
        }














        // GET: api/InvestigationMastersDateApi/5
        [ResponseType(typeof(InvestigationMaster))]
        public IHttpActionResult GetInvestigationMaster(string id)
        {
            InvestigationMaster investigationMaster = db.InvestigationMaster.Find(id);
            if (investigationMaster == null)
            {
                return NotFound();
            }

            return Ok(investigationMaster);
        }

        // PUT: api/InvestigationMastersDateApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvestigationMaster(string id, InvestigationMaster investigationMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != investigationMaster.VoucherNo)
            {
                return BadRequest();
            }

            db.Entry(investigationMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestigationMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/InvestigationMastersDateApi
        [ResponseType(typeof(InvestigationMaster))]
        public IHttpActionResult PostInvestigationMaster(InvestigationMaster investigationMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InvestigationMaster.Add(investigationMaster);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InvestigationMasterExists(investigationMaster.VoucherNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = investigationMaster.VoucherNo }, investigationMaster);
        }

        // DELETE: api/InvestigationMastersDateApi/5
        [ResponseType(typeof(InvestigationMaster))]
        public IHttpActionResult DeleteInvestigationMaster(string id)
        {
            InvestigationMaster investigationMaster = db.InvestigationMaster.Find(id);
            if (investigationMaster == null)
            {
                return NotFound();
            }

            db.InvestigationMaster.Remove(investigationMaster);
            db.SaveChanges();

            return Ok(investigationMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvestigationMasterExists(string id)
        {
            return db.InvestigationMaster.Count(e => e.VoucherNo == id) > 0;
        }
    }
}