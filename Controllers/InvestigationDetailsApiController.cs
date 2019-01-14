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
    public class InvestigationDetailsApiController : ApiController
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: api/InvestigationDetailsApi
        //public IQueryable<InvestigationDetails> GetInvestigationDetails()
        //{
        //    return db.InvestigationDetails;
        //}




        [HttpGet, ActionName("GetInvestigationByVrNo")]
        public IQueryable<InvestigationDetails> GetInvestigationByVrNo(string voucherno)
        {
            return (from a in db.InvestigationDetails where a.VoucherNo == voucherno orderby a.SlNo select a);
        }


        //Get data using date criteria//

        [HttpGet, ActionName("GetInvestigationByDate")]
        public IQueryable<InvestigationDetails> GetInvestigationByDate(DateTime d1, DateTime d2)
        {
            return (from a in db.InvestigationDetails where a.Date >= d1 && a.Date <= d2 orderby a.Date, a.VoucherNo, a.SlNo select a);
        }






















        // GET: api/InvestigationDetailsApi/5
        [ResponseType(typeof(InvestigationDetails))]
        public IHttpActionResult GetInvestigationDetails(string id)
        {
            InvestigationDetails investigationDetails = db.InvestigationDetails.Find(id);
            if (investigationDetails == null)
            {
                return NotFound();
            }

            return Ok(investigationDetails);
        }

        // PUT: api/InvestigationDetailsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvestigationDetails(string id, InvestigationDetails investigationDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != investigationDetails.VoucherNo)
            {
                return BadRequest();
            }

            db.Entry(investigationDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestigationDetailsExists(id))
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

        // POST: api/InvestigationDetailsApi
        [ResponseType(typeof(InvestigationDetails))]
        public IHttpActionResult PostInvestigationDetails(InvestigationDetails investigationDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InvestigationDetails.Add(investigationDetails);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InvestigationDetailsExists(investigationDetails.VoucherNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = investigationDetails.VoucherNo }, investigationDetails);
        }

        // DELETE: api/InvestigationDetailsApi/5
        [ResponseType(typeof(InvestigationDetails))]
        public IHttpActionResult DeleteInvestigationDetails(string id)
        {
            InvestigationDetails investigationDetails = db.InvestigationDetails.Find(id);
            if (investigationDetails == null)
            {
                return NotFound();
            }

            db.InvestigationDetails.Remove(investigationDetails);
            db.SaveChanges();

            return Ok(investigationDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvestigationDetailsExists(string id)
        {
            return db.InvestigationDetails.Count(e => e.VoucherNo == id) > 0;
        }
    }
}