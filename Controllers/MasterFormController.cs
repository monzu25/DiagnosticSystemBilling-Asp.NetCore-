using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CityLab.Controllers
{
    public class MasterFormController : Controller
    {
        // GET: MasterForm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MasterInputFrom()
        {
            return View();
        }




        public ActionResult Report()
        {
            return View();
        }
        public ActionResult DailyReport()
        {
            return View();
        }

        public ActionResult DailyReportSummury()
        {
            return View();
        }
    }
}