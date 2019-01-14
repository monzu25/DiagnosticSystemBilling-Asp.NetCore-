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
    public class CashReceiveMastersApiController : ApiController
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: api/CashReceiveMastersApi
        //public IQueryable<CashReceiveMaster> GetCashReceiveMaster()
        //{
        //    return db.CashReceiveMaster;
        //}







        [HttpGet, ActionName("PaidVoucher")]
        public Int32 PaidVoucher()
        {
            Int16 a1 = 0;
            a1 = Int16.Parse(db.CashReceiveMaster
                           .OrderByDescending(p => p.VoucherNo)
                           .Select(r => r.VoucherNo)
                           .First().ToString());

            //a1 = (from a in db.InvestigationMaster select Int16.Parse(a.VoucherNo)).DefaultIfEmpty().Max();

            a1++;
            return a1;
        }




        // GET: api/CashReceiveMastersApi/5
        [ResponseType(typeof(CashReceiveMaster))]
        public IHttpActionResult GetCashReceiveMaster(string id)
        {
            CashReceiveMaster cashReceiveMaster = db.CashReceiveMaster.Find(id);
            if (cashReceiveMaster == null)
            {
                return NotFound();
            }

            return Ok(cashReceiveMaster);
        }

        // PUT: api/CashReceiveMastersApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCashReceiveMaster(string id, CashReceiveMaster cashReceiveMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cashReceiveMaster.VoucherNo)
            {
                return BadRequest();
            }

            db.Entry(cashReceiveMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashReceiveMasterExists(id))
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

        // POST: api/CashReceiveMastersApi
        [ResponseType(typeof(CashReceiveMaster))]
        public IHttpActionResult PostCashReceiveMaster(CashReceiveMaster cashReceiveMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CashReceiveMaster.Add(cashReceiveMaster);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CashReceiveMasterExists(cashReceiveMaster.VoucherNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cashReceiveMaster.VoucherNo }, cashReceiveMaster);
        }

        // DELETE: api/CashReceiveMastersApi/5
        [ResponseType(typeof(CashReceiveMaster))]
        public IHttpActionResult DeleteCashReceiveMaster(string id)
        {
            CashReceiveMaster cashReceiveMaster = db.CashReceiveMaster.Find(id);
            if (cashReceiveMaster == null)
            {
                return NotFound();
            }

            db.CashReceiveMaster.Remove(cashReceiveMaster);
            db.SaveChanges();

            return Ok(cashReceiveMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CashReceiveMasterExists(string id)
        {
            return db.CashReceiveMaster.Count(e => e.VoucherNo == id) > 0;
        }
    }
}