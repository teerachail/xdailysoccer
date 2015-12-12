using DailySoccer.Shared.Models;
using DailySoccerBackoffice.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DailySoccerBackoffice.Controllers
{
    public class WinnerController : Controller
    {
        // GET: Winner
        public async Task<ActionResult> Index(int id)
        {
            using (var serviceEngine = new ServiceHelper())
            {
                var response = await serviceEngine.Client.GetAsync<GetSelectedTicketRespond>("/Winner/GetSelectedTicket?rewardId=" + id);
                return View(response);
            }
        }

        public async Task<ActionResult> RewardList(int id)
        {
            using (var serviceEngine = new ServiceHelper())
            {
                var response = await serviceEngine.Client.GetAsync<RewardGroupInformation>("/Reward/GetRewardGroupById?id=" + id);
                return View("RewardList", response);
            }
        }

        public async Task<ActionResult> ManageTicket(int id)
        {
            using (var serviceEngine = new ServiceHelper())
            {
                var response = await serviceEngine.Client.GetAsync<GetSelectedTicketRespond>("/Winner/GetSelectedTicket?rewardId=" + id);
                ViewBag.RewardId = id;
                return View(response);
            }
        }

        public async Task<ActionResult> SelectTicket(int rewardId, int ticketId)
        {
            using (var serviceEngine = new ServiceHelper())
            {
                await serviceEngine.Client.GetAsync<GetSelectedTicketRespond>(string.Format("/Winner/SelectTicket?rewardId={0}&ticketId={1}", rewardId, ticketId));
                return RedirectToAction("ManageTicket", new { id = rewardId });
            }
        }

        public async Task<ActionResult> CalcelSelectedTicket(int rewardId, int ticketId)
        {
            using (var serviceEngine = new ServiceHelper())
            {
                await serviceEngine.Client.GetAsync<GetSelectedTicketRespond>(string.Format("/Winner/CancelSelectedTicket?rewardId={0}&ticketId={1}", rewardId, ticketId));
                return RedirectToAction("ManageTicket", new { id = rewardId });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SubmitSelectedWinner(int rewardId)
        {
            using (var serviceEngine = new ServiceHelper())
            {
                await serviceEngine.Client.GetAsync<GetSelectedTicketRespond>("/Winner/SubmitSelectedWinner?rewardId="+ rewardId);
                return RedirectToAction("ManageTicket", new { id = rewardId });
            }
        }

    }
}