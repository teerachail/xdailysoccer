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
            var result = FacadeRepository.Instance.RewardFacade.GetCurrentRewards();
            return result;
        }

        [HttpGet]
        public GetCurrentWinnersRespond GetCurrentWinners()
        {
            var result = FacadeRepository.Instance.RewardFacade.GetCurrentWinners(DateTime.Now);
            return result;
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
            var request = new GetYourRewardsRequest { UserId = userId };
            var result = FacadeRepository.Instance.RewardFacade.GetYourRewards(request);
            return result;
        }

    }
}
