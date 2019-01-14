using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MVC_CityLab.Controllers
{
    public class ShowRecordInToFieldController : ApiController
    {

        private CityLabDBEntities db = new CityLabDBEntities();


        public IQueryable<InvestigationMaster> GetInvestigationMaster()
        {
            return db.InvestigationMaster;
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
    }
}
