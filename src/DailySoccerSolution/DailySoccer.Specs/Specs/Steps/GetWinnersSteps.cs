using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using DailySoccer.Shared.Models;
using System.Collections.Generic;
using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Facades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class GetWinnersSteps
    {
        [Given(@"กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้")]
        public void Givenกลมของรางวลทงหมดในระบบมดงน(Table table)
        {
            var rewardGroups = table.CreateSet<RewardGroupInformation>().ToList();
            ScenarioContext.Current.Set(rewardGroups);
        }
        
        [Given(@"ของรางวัลในแต่ละกลุ่มเป็นดังนี้")]
        public void Givenของรางวลในแตละกลมเปนดงน(Table table)
        {
            var rewardQry = table.CreateSet<RewardInformation>();
            var rewardGroups = ScenarioContext.Current.Get<List<RewardGroupInformation>>();
            foreach (var item in rewardGroups)
            {
                item.RewardInfo = rewardQry.Where(it => it.RewardGroupId == item.Id).ToList();
            }

            var mockRewardDac = ScenarioContext.Current.Get<Moq.Mock<IRewardDataAccess>>();
            mockRewardDac.Setup(dac => dac.GetRewardGroup()).Returns(() => rewardGroups);
        }
        
        [Given(@"รายชื่อผู้โชคดีทั้งหมดในระบบเป็นดังนี้")]
        public void Givenรายชอผโชคดทงหมดในระบบเปนดงน(Table table)
        {
            var winnerQry = table.CreateSet<WinnerInformation>();
            var mockRewardDac = ScenarioContext.Current.Get<Moq.Mock<IRewardDataAccess>>();
            mockRewardDac.Setup(dac => dac.GetAllWinners()).Returns(() => winnerQry);
        }
        
        [When(@"ขอรายชื่อผู้โชคดี")]
        public void Whenขอรายชอผโชคด()
        {
            var currentTime = ScenarioContext.Current.Get<DateTime>();
            var result = FacadeRepository.Instance.RewardFacade.GetCurrentWinners(currentTime);
            ScenarioContext.Current.Set(result);
        }

        [Then(@"ระบบส่งรายชื่อผู้โชคดีกลับไปเป็น")]
        public void Thenระบบสงรายชอผโชคดกลบไปเปน(Table table)
        {
            var expecteds = table.Rows.Select(it => new WinnerAwardInformation
            {
                Ordering = it.ConvertToInt("Ordering"),
                Description = it.GetString("Description"),
                ImagePath = it.GetString("ImagePath"),
                Winners = it.GetString("Winners").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            }).OrderBy(it => it.Ordering).ToList();
            var actuals = ScenarioContext.Current.Get<GetCurrentWinnersRespond>().Winners
                .OrderBy(it => it.Ordering)
                .ToList();

            foreach (var item in expecteds) item.Winners = item.Winners ?? Enumerable.Empty<string>();

            Assert.AreEqual(expecteds.Count, actuals.Count, "Elements aren't equal");
            for (int elementIndex = 0; elementIndex < expecteds.Count; elementIndex++)
            {
                var errorMessage = string.Format(" Ordering: {0}", expecteds[elementIndex].Ordering);
                Assert.AreEqual(expecteds[elementIndex].Ordering, actuals[elementIndex].Ordering, "Ordering aren't equal" + errorMessage);
                Assert.AreEqual(expecteds[elementIndex].Description, actuals[elementIndex].Description, "Description aren't equal" + errorMessage);
                Assert.AreEqual(expecteds[elementIndex].ImagePath, actuals[elementIndex].ImagePath, "ImagePath aren't equal" + errorMessage);

                var expectedWinners = expecteds[elementIndex].Winners;
                var actualWinners = actuals[elementIndex].Winners;
                Assert.AreEqual(expectedWinners.Count(), actualWinners.Count(), "Winners aren't equal" + errorMessage);
                Assert.IsTrue(actualWinners.All(it => expectedWinners.Contains(it)));
            }
        }
    }
}
