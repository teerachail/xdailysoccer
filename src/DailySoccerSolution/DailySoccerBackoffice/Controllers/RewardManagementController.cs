using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailySoccerBackoffice.Controllers
{
    public class RewardManagementController : Controller
    {
        // GET: RewardManagement
        public ActionResult Index()
        {
            var client = new JsonServiceClient("http://host/api/");
            return View();
        }
    }
}