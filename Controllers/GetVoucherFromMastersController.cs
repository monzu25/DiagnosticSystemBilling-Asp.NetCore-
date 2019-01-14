using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_CityLab.Controllers
{
    public class GetVoucherFromMastersController : ApiController
    {

        private CityLabDBEntities db = new CityLabDBEntities();

       




        [HttpGet,ActionName("GetVouchers")]
        public List<string> GetVouchers()
        {
            return (from a in db.InvestigationMaster orderby a.VoucherNo ascending select a.VoucherNo).ToList();
        }





    }
}
