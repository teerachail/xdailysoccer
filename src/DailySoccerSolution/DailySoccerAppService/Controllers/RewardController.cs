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
            //Hack: Mock data
            var currentRewards = new List<YourRewardInformation>()
            {
                new YourRewardInformation
                {
                    ExpiredDate = DateTime.Now,
                    Ordering = 1,
                    Description = "โทรศัพท์มือถือ มูลค่า 25,000 บาท",
                    ReferenceCode = "Ac09D",
                    ImagePath = "img/Logos/BannerReward01Thumbnail.png"
                },
                new YourRewardInformation
                {
                    ExpiredDate = DateTime.Now,
                    Ordering = 2,
                    Description = "เสื้อสโมสรลิเวอร์พูล มูลค่า 7,000 บาท",
                    ReferenceCode = "eFr4T",
                    ImagePath = "img/Logos/BannerReward02Thumbnail.png"
                }
            };

            var passDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1);
            var allRewards = new List<YourRewardInformation>()
            {
                new YourRewardInformation
                {
                    ExpiredDate = passDate,
                    Ordering = 3,
                    Description = "จอมอนิเตอร์ มูลค่า 5,000 บาท",
                    ReferenceCode = "OcD87"
                },
                new YourRewardInformation
                {
                    ExpiredDate = passDate,
                    Ordering = 4,
                    Description = "ผ้าปูเตียง มูลค่า 2,500 บาท",
                    ReferenceCode = "96PzW"
                }
            };

            return new GetYourRewardsRespond
            {
                ContactNo = "010-0110110 ต่อ 5",
                CurrentRewards = currentRewards,
                AllRewards = allRewards
            };
        }

    }
}
