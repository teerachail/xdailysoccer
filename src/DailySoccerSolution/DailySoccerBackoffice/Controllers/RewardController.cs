using DailySoccer.Shared.Models;
using DailySoccerBackoffice.Helpers;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DailySoccerBackoffice.Controllers
{
    public class RewardController : Controller
    {
        // GET: RewardManagement
        public async Task<ActionResult> Index()
        {
            var serviceEngine = new ServiceEngine();
            var response = await serviceEngine.Client.GetAsync<IEnumerable<RewardGroupInformation>>("/Reward/GetRewardGroup");
            return View(response);
        }

        public async Task<ActionResult> Details(int id)
        {
            var serviceEngine = new ServiceEngine();
            var response = await serviceEngine.Client.GetAsync<RewardGroupInformation>("/Reward/GetRewardGroupById?id=" + id);
            return View(response);
        }

        public ActionResult Create()
        {
            return View(new RewardGroupInformation());
        }

        [HttpPost]
        public async Task<ActionResult> Create(RewardGroupInformation model)
        {
            var serviceEngine = new ServiceEngine();
            await serviceEngine.Client.PostAsync<RewardGroupInformation>("/Reward/CreateRewardGroup", model);
            return RedirectToAction("Index");
        }

        public ActionResult CreateReward(int id)
        {
            ViewBag.Id = id;
            return View(new RewardInformation());
        }

        [HttpPost]
        public async Task<ActionResult> CreateReward(int id, RewardInformation model, HttpPostedFileBase file)
        {
            var serviceEngine = new ServiceEngine();
            model.RewardGroupId = id;
            await serviceEngine.Client.PostAsync<RewardInformation>("/Reward/CreateReward" , model);
            return RedirectToAction("Details", new { id = id });
        }
    }
}