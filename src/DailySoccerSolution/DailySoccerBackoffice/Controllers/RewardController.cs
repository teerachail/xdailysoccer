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
            using (var serviceEngine = new ServiceHelper())
            {
                var response = await serviceEngine.Client.GetAsync<IEnumerable<RewardGroupInformation>>("/Reward/GetRewardGroup");
                return View(response);
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            using (var serviceEngine = new ServiceHelper())
            {
                var response = await serviceEngine.Client.GetAsync<RewardGroupInformation>("/Reward/GetRewardGroupById?id=" + id);
                return View("RewardList",response);
            }
        }

        public ActionResult Create()
        {
            return View(new RewardGroupInformation());
        }

        [HttpPost]
        public async Task<ActionResult> Create(RewardGroupInformation model)
        {
            using (var serviceEngine = new ServiceHelper())
            {
                await serviceEngine.Client.PostAsync<RewardGroupInformation>("/Reward/CreateRewardGroup", model);
                return RedirectToAction("Index");
            }
        }

        public ActionResult CreateReward(int id)
        {
            ViewBag.Id = id;
            return View(new RewardInformation());
        }

        [HttpPost]
        public async Task<ActionResult> CreateReward(int id, RewardInformation model, HttpPostedFileBase ThumbnailPath, HttpPostedFileBase ImagePath)
        {
            using (var serviceEngine = new ServiceHelper())
            {
                var uploader = new UploadImageHelper();
                const char TypeSpliter = '/';
                var thumbnailFileName = string.Format("{0}.{1}", Guid.NewGuid(), ThumbnailPath.ContentType.Split(TypeSpliter).Last());
                var imageFileName = string.Format("{0}.{1}", Guid.NewGuid(), ThumbnailPath.ContentType.Split(TypeSpliter).Last());

                model.ThumbnailPath = await uploader.UploadImage(thumbnailFileName, ThumbnailPath.InputStream, "thumbnails");
                model.ImagePath = await uploader.UploadImage(imageFileName, ImagePath.InputStream, "images");
                model.RewardGroupId = id;

                await serviceEngine.Client.PostAsync<RewardInformation>("/Reward/CreateReward", model);
                return RedirectToAction("Details", new { id = id });
            }
        }
    }
}