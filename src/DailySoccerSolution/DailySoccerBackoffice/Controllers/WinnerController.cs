using DailySoccer.Shared.Models;
using DailySoccerBackoffice.Helpers;
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
                var response = await serviceEngine.Client.GetAsync<GetSelectedTicketRespond>("/Winner/GetSelectedWinner?rewardId=" + id);
                return View(response);
            }
        }
    }
}