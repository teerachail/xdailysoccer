using DailySoccer.Shared.Facades;
using DailySoccer.Shared.Models;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class GetAllGuessHistorySteps
    {
        [When(@"ผู้ใช้ UserId: '(.*)' ขอข้อมูลการทายผลทั้งหมด")]
        public void WhenผใชUserIdขอขอมลการทายผลทงหมด(string userId)
        {
            var currentTime = ScenarioContext.Current.Get<DateTime>();
            var request = new GetAllGuessHistoryRequest { UserId = userId };
            var result = FacadeRepository.Instance.AccountFacade.GetAllGuessHistory(request, currentTime);
            ScenarioContext.Current.Set(result);
        }
        
        [Then(@"ระบบส่งรายการทายผลกลับไปเป็น")]
        public void Thenระบบสงรายการทายผลกลบไปเปน(Table table)
        {
            var expecteds = table.CreateSet<GuessHistoryMonthlyInformation>()
                .OrderBy(it => it.Month)
                .ToList();
            var actuals = ScenarioContext.Current.Get<GetAllGuessHistoryRespond>().Histories
                .OrderBy(it => it.Month)
                .ToList();

            Assert.AreEqual(expecteds.Count, actuals.Count, "Element count aren't match");
            for (int elementIndex = 0; elementIndex < expecteds.Count; elementIndex++)
            {
                var errorMessage = string.Format(" Month: {0}", expecteds[elementIndex].Month);
                Assert.AreEqual(expecteds[elementIndex].Month, actuals[elementIndex].Month, "Month aren't match" + errorMessage);
                Assert.AreEqual(expecteds[elementIndex].TotalPoints, actuals[elementIndex].TotalPoints, "TotalPoints aren't match" + errorMessage);
            }
        }
    }
}
