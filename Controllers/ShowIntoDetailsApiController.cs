using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_CityLab.Controllers
{
    public class ShowIntoDetailsApiController : ApiController
    {

        private CityLabDBEntities db = new CityLabDBEntities();

        // GET: api/InvestigationDetailsApi
        public IQueryable<InvestigationDetails> GetInvestigationDetails()
        {
            return db.InvestigationDetails;
        }

        [HttpGet,ActionName("GetInvestigationByVrNo")]
        public IEnumerable<InvestigationDetails> GetInvestigationByVrNo(string voucherno)
        {
            return (from a in db.InvestigationDetails where a.VoucherNo == voucherno orderby a.SlNo select a);
        }


    }
}
