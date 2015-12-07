using DailySoccer.Shared.Facades;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using DailySoccer.Shared.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class GetYourRewardsSteps
    {
        [When(@"ผู้ใช้ UserId: '(.*)' ขอข้อมูลของรางวัลที่เคยได้")]
        public void WhenผใชUserIdขอขอมลของรางวลทเคยได(string userId)
        {
            var request = new Shared.Models.GetYourRewardsRequest { UserId = userId };
            var result = FacadeRepository.Instance.RewardFacade.GetYourRewards(request);
            ScenarioContext.Current.Set(result);
        }

        [Then(@"ระบบส่งรายการของรางวัลที่เคยได้ปัจจุบันกลับมาเป็น")]
        public void Thenระบบสงรายการของรางวลทเคยไดปจจบนกลบมาเปน(Table table)
        {
            var expecteds = table.CreateSet<YourRewardInformation>()
                .OrderBy(it => it.Ordering)
                .ToList();
            var actuals = ScenarioContext.Current.Get<GetYourRewardsRespond>()
                .CurrentRewards
                .OrderBy(it => it.Ordering)
                .ToList();

            validateYourReward(expecteds, actuals);
        }

        [Then(@"ระบบส่งรายการของรางวัลที่เคยได้ที่ผ่านมากลับมาเป็น")]
        public void Thenระบบสงรายการของรางวลทเคยไดทผานมากลบมาเปน(Table table)
        {
            var expecteds = table.CreateSet<YourRewardInformation>()
                .OrderBy(it => it.Ordering)
                .ToList();
            var actuals = ScenarioContext.Current.Get<GetYourRewardsRespond>()
                .AllRewards
                .OrderBy(it => it.Ordering)
                .ToList();

            validateYourReward(expecteds, actuals);
        }


        private void validateYourReward(List<YourRewardInformation> expecteds, List<YourRewardInformation> actuals)
        {
            Assert.AreEqual(expecteds.Count, actuals.Count, "Element count aren't match");
            for (int elementIndex = 0; elementIndex < expecteds.Count; elementIndex++)
            {
                var errorMessage = string.Format(" Ordering: {0}", expecteds[elementIndex].Ordering);
                Assert.AreEqual(expecteds[elementIndex].Ordering, actuals[elementIndex].Ordering, "Ordering aren't match");
                Assert.AreEqual(expecteds[elementIndex].ReferenceCode, actuals[elementIndex].ReferenceCode, "ReferenceCode aren't match");
                Assert.AreEqual(expecteds[elementIndex].ImagePath, actuals[elementIndex].ImagePath, "ImagePath aren't match");
                Assert.AreEqual(expecteds[elementIndex].ExpiredDate, actuals[elementIndex].ExpiredDate, "ExpiredDate aren't match");
                Assert.AreEqual(expecteds[elementIndex].Description, actuals[elementIndex].Description, "Description aren't match");
            }
        }
    }
}
