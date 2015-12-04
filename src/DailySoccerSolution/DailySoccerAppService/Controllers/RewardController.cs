using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using DailySoccer.Shared.Models;

namespace DailySoccerAppService.Controllers
{
    public class RewardController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/Reward
        //[HttpGet]
        //public string Get()
        //{
        //    return "Respond by GET method";
        //}

        [HttpGet]
        public GetCurrentRewardsRespond GetCurrentRewards()
        {
            var reward = new List<RewardInformation>
            {
                new RewardInformation
                {
                    ImagePath = "http://www.samsung.com/th/consumer-images/product/smartphone/2015/SM-G920FZKACAM/features/SM-G920FZKACAM-403979-0.jpg",
                    RemainingAmount = 5
                },
                new RewardInformation
                {
                    ImagePath = "http://www.samsung.com/th/consumer-images/product/smartphone/2015/SM-G920FZKACAM/features/SM-G920FZKACAM-403979-0.jpg",
                    RemainingAmount = 3
                },
                new RewardInformation
                {
                    ImagePath = "http://www.samsung.com/th/consumer-images/product/smartphone/2015/SM-G920FZKACAM/features/SM-G920FZKACAM-403979-0.jpg",
                    RemainingAmount = 1
                }
            };

            return new GetCurrentRewardsRespond {
                TicketCost = 50,
                Rewards = reward
            };
        }

    }
}
