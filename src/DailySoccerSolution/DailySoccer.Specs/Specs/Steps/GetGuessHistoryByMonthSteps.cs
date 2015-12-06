using DailySoccer.Shared.Facades;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using DailySoccer.Shared.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class GetGuessHistoryByMonthSteps
    {
        [When(@"ผู้ใช้ UserId: '(.*)' ขอข้อมูลการทายผลรายเดือน month: '(.*)', year: '(.*)'")]
        public void WhenผใชUserIdขอขอมลการทายผลรายเดอนMonthYear(string userId, int month, int year)
        {
            var request = new Shared.Models.GetGuessHistoryByMonthRequest
            {
                UserId = userId,
                Month = month,
                Year = year
            };
            var result = FacadeRepository.Instance.AccountFacade.GetGuessHistoryByMonth(request);
            ScenarioContext.Current.Set(result);
        }
        
        [Then(@"ระบบส่งผลการทายผลรายเดือนกลับไปเป็น")]
        public void Thenระบบสงผลการทายผลรายเดอนกลบไปเปน(Table table)
        {
            //GuessHistoryDailyInformation
            var expecteds = table.CreateSet<MatchInformation>().OrderBy(it => it.Id).ToList();
            var actuals = ScenarioContext.Current.Get<GetGuessHistoryByMonthRespond>().Histories
                .SelectMany(it => it.Matches)
                .OrderBy(it => it.Id).ToList();

            Assert.AreEqual(expecteds.Count(), actuals.Count(), "Matches element aren't equal");
            for (int elementIndex = 0; elementIndex < expecteds.Count(); elementIndex++)
            {
                var messageMatchInfo = string.Format(" (Match's ID: {0})", expecteds[elementIndex].Id);
                Assert.AreEqual(expecteds[elementIndex].Id, actuals[elementIndex].Id, "Match's Id aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].LeagueName, actuals[elementIndex].LeagueName, "Match's LeagueName aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].Status, actuals[elementIndex].Status, "Match's Status aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].BeginDate, actuals[elementIndex].BeginDate, "Match's BeginDate aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].StartedDate, actuals[elementIndex].StartedDate, "Match's StartedDate aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].CompletedDate, actuals[elementIndex].CompletedDate, "Match's CompletedDate aren't equal" + messageMatchInfo);

                Assert.AreEqual(expecteds[elementIndex].TeamAway.Id, actuals[elementIndex].TeamAway.Id, "Match's TeamAway.Id aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].TeamAway.Name, actuals[elementIndex].TeamAway.Name, "Match's TeamAway.Name aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].TeamAway.IsSelected, actuals[elementIndex].TeamAway.IsSelected, "Match's TeamAway.IsSelected aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].TeamAway.CurrentPredictionPoints, actuals[elementIndex].TeamAway.CurrentPredictionPoints, "Match's TeamAway.CurrentPredictionPoints aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].TeamAway.CurrentScore, actuals[elementIndex].TeamAway.CurrentScore, "Match's TeamAway.CurrentScore aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].TeamAway.WinningPredictionPoints, actuals[elementIndex].TeamAway.WinningPredictionPoints, "Match's TeamAway.WinningPredictionPoints aren't equal" + messageMatchInfo);

                Assert.AreEqual(expecteds[elementIndex].TeamHome.Id, actuals[elementIndex].TeamHome.Id, "Match's TeamHome.Id aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].TeamHome.Name, actuals[elementIndex].TeamHome.Name, "Match's TeamHome.Name aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].TeamHome.IsSelected, actuals[elementIndex].TeamHome.IsSelected, "Match's TeamHome.IsSelected aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].TeamHome.CurrentPredictionPoints, actuals[elementIndex].TeamHome.CurrentPredictionPoints, "Match's TeamHome.CurrentPredictionPoints aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].TeamHome.CurrentScore, actuals[elementIndex].TeamHome.CurrentScore, "Match's TeamHome.CurrentScore aren't equal" + messageMatchInfo);
                Assert.AreEqual(expecteds[elementIndex].TeamHome.WinningPredictionPoints, actuals[elementIndex].TeamHome.WinningPredictionPoints, "Match's TeamHome.WinningPredictionPoints aren't equal" + messageMatchInfo);
            }
        }
    }
}
