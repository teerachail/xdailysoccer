using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using DailySoccer.Shared.Models;
using DailySoccer.Shared.Facades;

namespace DailySoccerAppService.Controllers
{
    public class RewardController : ApiController
    {
        public ApiServices Services { get; set; }

        [HttpGet]
        public string Get()
        {
            return "Respond by GET method";
        }

        [HttpPost]
        public string Post(int id)
        {
            return "Respond by POST method, your ID: " + id;
        }

        [HttpGet]
        public GetCurrentRewardsRespond GetCurrentRewards()
        {
            var reward = new List<RewardInformation>
            {
                new RewardInformation
                {
                    ImagePath = "img/Logos/BannerReward01.png",
                    RemainingAmount = 5
                },
                new RewardInformation
                {
                    ImagePath = "img/Logos/BannerReward02.png",
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

        [HttpGet]
        public IEnumerable<RewardGroupInformation> GetRewardGroup()
        {
            var rewardFacade = new RewardFacade();
            return rewardFacade.GetRewardGroup();
        }

        [HttpGet]
        public RewardGroupInformation GetRewardGroupById(int id)
        {
            var rewardFacade = new RewardFacade();
            return rewardFacade.GetRewardGroupById(id);
        }

        [HttpPost]
        public void CreateRewardGroup(RewardGroupInformation model)
        {
            var rewardFacade = new RewardFacade();
            rewardFacade.CreateRewardGroup(model);
        }

        [HttpPost]
        public void CreateReward(RewardInformation model)
        {
            var rewardFacade = new RewardFacade();
            rewardFacade.CreateReward(model);
        }

        public GetYourRewardsRespond GetYourRewards(string userId)
        {
            var rewardFacade = new RewardFacade();
            var getYourRewardsRequest = new GetYourRewardsRequest();
            getYourRewardsRequest.UserId = userId;
            return rewardFacade.GetYourRewards(getYourRewardsRequest);
        }

    }
}
