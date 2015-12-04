using DailySoccer.Shared.Models;
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
            var client = new JsonServiceClient("http://localhost:3728/api/");
            var response = client.Get<IEnumerable<RewardGroupInformation>>("/Reward/GetRewardGroup");
            return View();
        }
    }
}