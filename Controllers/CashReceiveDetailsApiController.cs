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
    public class CashReceiveDetailsApiController : ApiController
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: api/CashReceiveDetailsApi
        public IQueryable<CashReceiveDetails> GetCashReceiveDetails()
        {
            return db.CashReceiveDetails;
        }

        // GET: api/CashReceiveDetailsApi/5
        [ResponseType(typeof(CashReceiveDetails))]
        public IHttpActionResult GetCashReceiveDetails(string id)
        {
            CashReceiveDetails cashReceiveDetails = db.CashReceiveDetails.Find(id);
            if (cashReceiveDetails == null)
            {
                return NotFound();
            }

            return Ok(cashReceiveDetails);
        }

        // PUT: api/CashReceiveDetailsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCashReceiveDetails(string id, CashReceiveDetails cashReceiveDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cashReceiveDetails.VoucherNo)
            {
                return BadRequest();
            }

            db.Entry(cashReceiveDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashReceiveDetailsExists(id))
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

        // POST: api/CashReceiveDetailsApi
        [ResponseType(typeof(CashReceiveDetails))]
        public IHttpActionResult PostCashReceiveDetails(CashReceiveDetails cashReceiveDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CashReceiveDetails.Add(cashReceiveDetails);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CashReceiveDetailsExists(cashReceiveDetails.VoucherNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cashReceiveDetails.VoucherNo }, cashReceiveDetails);
        }

        // DELETE: api/CashReceiveDetailsApi/5
        [ResponseType(typeof(CashReceiveDetails))]
        public IHttpActionResult DeleteCashReceiveDetails(string id)
        {
            CashReceiveDetails cashReceiveDetails = db.CashReceiveDetails.Find(id);
            if (cashReceiveDetails == null)
            {
                return NotFound();
            }

            db.CashReceiveDetails.Remove(cashReceiveDetails);
            db.SaveChanges();

            return Ok(cashReceiveDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CashReceiveDetailsExists(string id)
        {
            return db.CashReceiveDetails.Count(e => e.VoucherNo == id) > 0;
        }
    }
}