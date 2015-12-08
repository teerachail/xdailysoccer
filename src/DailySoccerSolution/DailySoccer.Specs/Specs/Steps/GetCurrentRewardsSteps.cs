using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using DailySoccer.Shared.Models;
using DailySoccer.Shared.Facades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class GetCurrentRewardsSteps
    {
        [When(@"ขอข้อมูลของรางวัลในรอบล่าสุด")]
        public void Whenขอขอมลของรางวลในรอบลาสด()
        {
            var result = FacadeRepository.Instance.RewardFacade.GetCurrentRewards();
            ScenarioContext.Current.Set(result);
        }

        [Then(@"ระบบส่งรายการของรางวัลกลับไปเป็น")]
        public void Thenระบบสงรายการของรางวลกลบไปเปน(Table table)
        {
            var expecteds = table.CreateSet<RewardInformation>()
                .OrderBy(it => it.Id)
                .ToList();
            var actuals = ScenarioContext.Current.Get<GetCurrentRewardsRespond>()
                .Rewards
                .OrderBy(it => it.Id)
                .ToList();

            Assert.AreEqual(expecteds.Count, actuals.Count, "Elements aren't equal");
            for (int elementIndex = 0; elementIndex < expecteds.Count; elementIndex++)
            {
                var errorMessage = string.Format(" Id: {0}", expecteds[elementIndex].Id);
                Assert.AreEqual(expecteds[elementIndex].Id, actuals[elementIndex].Id, "Id aren't equal" + errorMessage);

                Assert.AreEqual(expecteds[elementIndex].RewardGroupId, actuals[elementIndex].RewardGroupId, "RewardGroupId aren't equal" + errorMessage);
                Assert.AreEqual(expecteds[elementIndex].Name, actuals[elementIndex].Name, "Name aren't equal" + errorMessage);
                Assert.AreEqual(expecteds[elementIndex].Description, actuals[elementIndex].Description, "Description aren't equal" + errorMessage);
                Assert.AreEqual(expecteds[elementIndex].Amount, actuals[elementIndex].Amount, "Amount aren't equal" + errorMessage);
                Assert.AreEqual(expecteds[elementIndex].RemainingAmount, actuals[elementIndex].RemainingAmount, "RemainingAmount aren't equal" + errorMessage);
                Assert.AreEqual(expecteds[elementIndex].ImagePath, actuals[elementIndex].ImagePath, "ImagePath aren't equal" + errorMessage);
            }
        }

        [Then(@"ราคา Ticket ของเดือนนี้คือ '(.*)' Points")]
        public void ThenราคาTicketของเดอนนคอPoints(int expected)
        {
            var actual = ScenarioContext.Current.Get<GetCurrentRewardsRespond>().TicketCost;
            Assert.AreEqual(expected, actual, "Point aren't equal");
        }

    }
}
