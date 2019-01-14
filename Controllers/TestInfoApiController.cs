using MVC_CityLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;


namespace MVC_CityLab.Controllers
{
    public class TestInfoApiController : ApiController
    {
        private CityLabDBEntities ctx = new CityLabDBEntities();

        [HttpGet]
        public IEnumerable<TestInfo> GetAlltest()
        {
            IEnumerable<TestInfo> allTest = from tst in ctx.Investigations
                                            select new TestInfo
                                            {
                                                SLNo = tst.SLNo,
                                                TestName = tst.TestName,
                                                TestGroup = tst.TestGroup,
                                                ReportGroup = tst.ReportGroup,
                                                Fee = tst.Fee
                                            };
            return allTest;
        }

        [HttpGet]
        public IHttpActionResult Get(string id)

        {
            TestInfo test = (from tst in ctx.Investigations
                             where id == tst.TestName
                             select new TestInfo
                             {
                                 SLNo = tst.SLNo,
                                 TestName = tst.TestName,
                                 TestGroup = tst.TestGroup,
                                 ReportGroup = tst.ReportGroup,
                                 Fee = tst.Fee
                             }).First();
            return Ok(test);

        }


      

        [HttpGet]
        public IEnumerable<Investigations> GetInvestigationByVrNo(string testName)
        {
            return (from a in ctx.Investigations where a.TestName == testName orderby a.TestName select a);
        }


    }
}
