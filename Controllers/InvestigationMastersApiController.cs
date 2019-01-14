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
    public class InvestigationMastersApiController : ApiController
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: api/InvestigationMastersApi
        //public IQueryable<InvestigationMaster> GetInvestigationMaster()
        //{
        //    return db.InvestigationMaster;
        //}






        //[ActionName("GetVouchers")]
        //public List<string> GetVouchers()
        //{

        //    return (from a in db.InvestigationMaster orderby a.VoucherNo ascending select a.VoucherNo).ToList();

        //}



        [HttpGet,ActionName("CreateVoucher")]
        public Int32 CreateVoucher()
        {
            Int16 a1 = 0;
             a1 = Int16.Parse(db.InvestigationMaster
                            .OrderByDescending(p => p.VoucherNo)
                            .Select(r => r.VoucherNo)
                            .First().ToString());
           
            //a1 = (from a in db.InvestigationMaster select Int16.Parse(a.VoucherNo)).DefaultIfEmpty().Max();
           
            a1++;
            return a1;
        }









        // GET: api/InvestigationMastersApi/5
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

        // PUT: api/InvestigationMastersApi/5
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

        // POST: api/InvestigationMastersApi
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

        // DELETE: api/InvestigationMastersApi/5
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