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
    public class DoctorsApiController : ApiController
    {
        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: api/DoctorsApi
        //public IQueryable<Doctors> GetDoctors()
        //{
        //    return db.Doctors;
        //}



        //[ResponseType(typeof(Doctors))]
        //[HttpGet]
        [ActionName("GetDoctorsIds")]
        public List<int> GetDoctorsIds()
        {
            return (from a in db.Doctors orderby a.DoctorID ascending select a.DoctorID).ToList();
        }




        // GET: api/DoctorsApi/5
        [ResponseType(typeof(Doctors))]
        public IHttpActionResult GetDoctors(int id)
        {
            Doctors doctors = db.Doctors.Find(id);
            if (doctors == null)
            {
                return NotFound();
            }

            return Ok(doctors);
        }

        // PUT: api/DoctorsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoctors(int id, Doctors doctors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctors.DoctorID)
            {
                return BadRequest();
            }

            db.Entry(doctors).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorsExists(id))
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

        // POST: api/DoctorsApi
        [ResponseType(typeof(Doctors))]
        public IHttpActionResult PostDoctors(Doctors doctors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Doctors.Add(doctors);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = doctors.DoctorID }, doctors);
        }

        // DELETE: api/DoctorsApi/5
        [ResponseType(typeof(Doctors))]
        public IHttpActionResult DeleteDoctors(int id)
        {
            Doctors doctors = db.Doctors.Find(id);
            if (doctors == null)
            {
                return NotFound();
            }

            db.Doctors.Remove(doctors);
            db.SaveChanges();

            return Ok(doctors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoctorsExists(int id)
        {
            return db.Doctors.Count(e => e.DoctorID == id) > 0;
        }
    }
}