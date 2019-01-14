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
    public class InvestigationsApiController : ApiController
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: api/InvestigationsApi
        public IQueryable<Investigations> GetInvestigations()
        {
            return db.Investigations;
        }

        // GET: api/InvestigationsApi/5
        [ResponseType(typeof(Investigations))]
        public IHttpActionResult GetInvestigations(string id)
        {
            Investigations investigations = db.Investigations.Find(id);
            if (investigations == null)
            {
                return NotFound();
            }

            return Ok(investigations);
        }

        // PUT: api/InvestigationsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvestigations(string id, Investigations investigations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != investigations.TestName)
            {
                return BadRequest();
            }

            db.Entry(investigations).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestigationsExists(id))
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

        // POST: api/InvestigationsApi
        [ResponseType(typeof(Investigations))]
        public IHttpActionResult PostInvestigations(Investigations investigations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Investigations.Add(investigations);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InvestigationsExists(investigations.TestName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = investigations.TestName }, investigations);
        }

        // DELETE: api/InvestigationsApi/5
        [ResponseType(typeof(Investigations))]
        public IHttpActionResult DeleteInvestigations(string id)
        {
            Investigations investigations = db.Investigations.Find(id);
            if (investigations == null)
            {
                return NotFound();
            }

            db.Investigations.Remove(investigations);
            db.SaveChanges();

            return Ok(investigations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvestigationsExists(string id)
        {
            return db.Investigations.Count(e => e.TestName == id) > 0;
        }
    }
}