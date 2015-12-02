using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Models;
using Moq;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using DailySoccer.Shared.Facades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class GetMatchesSteps
    {
        [Given(@"ในระบบมีข้อมูลแมช์เป็น")]
        public void Givenในระบบมขอมลแมชเปน(Table table)
        {
            var matches = convertToMatchInformationList(table.Rows);
            var mockMatchDac = ScenarioContext.Current.Get<Moq.Mock<IMatchDataAccess>>();
            mockMatchDac
                .Setup(it => it.GetAllMatches())
                .Returns(() => matches);
        }

        [Given(@"ในระบบมีข้อมูลการทายเป็น")]
        public void Givenในระบบมขอมลการทายเปน(Table table)
        {
            var guesses = table.CreateSet<GuessMatchInformation>();
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac
                .Setup(it => it.GetGuessMatchsByAccountSecrectCode(It.IsAny<string>()))
                .Returns<string>(it => guesses.Where(g => g.AccountSecrectCode == it));
        }

        [When(@"ผู้ใช้ UserId: '(.*)' ขอข้อมูลแมช์, เวลาในขณะนั้นเป็น '(.*)'")]
        public void WhenผใชUserIdขอขอมลแมชเวลาในขณะนนเปน(string userId, DateTime currentTime)
        {
            var result = FacadeRepository.Instance.MatchFacade.GetMatches(new GetMatchesRequest { UserId = userId }, currentTime);
            ScenarioContext.Current.Set(result);
        }

        [Then(@"ระบบส่งข้อมูลแมช์กลับไปเป็น")]
        public void Thenระบบสงขอมลแมชกลบไปเปน(Table table)
        {
            var expecteds = convertToMatchInformationList(table.Rows).OrderBy(it => it.Id).ToList();
            var actuals = ScenarioContext.Current.Get<GetMatchesRespond>().Matches.OrderBy(it => it.Id).ToList();

            Assert.AreEqual(expecteds.Count(), actuals.Count(), "Matches element aren't equal");
            for (int elementIndex = 0; elementIndex < expecteds.Count(); elementIndex++)
            {
                Assert.AreEqual(expecteds[elementIndex].Id, actuals[elementIndex].Id, "Match's Id aren't equal");
                Assert.AreEqual(expecteds[elementIndex].LeagueName, actuals[elementIndex].LeagueName, "Match's LeagueName aren't equal");
                Assert.AreEqual(expecteds[elementIndex].Status, actuals[elementIndex].Status, "Match's Status aren't equal");
                Assert.AreEqual(expecteds[elementIndex].BeginDate, actuals[elementIndex].BeginDate, "Match's BeginDate aren't equal");
                Assert.AreEqual(expecteds[elementIndex].StartedDate, actuals[elementIndex].StartedDate, "Match's StartedDate aren't equal");
                Assert.AreEqual(expecteds[elementIndex].CompletedDate, actuals[elementIndex].CompletedDate, "Match's CompletedDate aren't equal");

                Assert.AreEqual(expecteds[elementIndex].TeamAway.Id, actuals[elementIndex].TeamAway.Id, "Match's TeamAway.Id aren't equal");
                Assert.AreEqual(expecteds[elementIndex].TeamAway.Name, actuals[elementIndex].TeamAway.Name, "Match's TeamAway.Name aren't equal");
                Assert.AreEqual(expecteds[elementIndex].TeamAway.IsSelected, actuals[elementIndex].TeamAway.IsSelected, "Match's TeamAway.IsSelected aren't equal");
                Assert.AreEqual(expecteds[elementIndex].TeamAway.CurrentPredictionPoints, actuals[elementIndex].TeamAway.CurrentPredictionPoints, "Match's TeamAway.CurrentPredictionPoints aren't equal");
                Assert.AreEqual(expecteds[elementIndex].TeamAway.CurrentScore, actuals[elementIndex].TeamAway.CurrentScore, "Match's TeamAway.CurrentScore aren't equal");
                Assert.AreEqual(expecteds[elementIndex].TeamAway.WinningPredictionPoints, actuals[elementIndex].TeamAway.WinningPredictionPoints, "Match's TeamAway.WinningPredictionPoints aren't equal");

                Assert.AreEqual(expecteds[elementIndex].TeamHome.Id, actuals[elementIndex].TeamHome.Id, "Match's TeamHome.Id aren't equal");
                Assert.AreEqual(expecteds[elementIndex].TeamHome.Name, actuals[elementIndex].TeamHome.Name, "Match's TeamHome.Name aren't equal");
                Assert.AreEqual(expecteds[elementIndex].TeamHome.IsSelected, actuals[elementIndex].TeamHome.IsSelected, "Match's TeamHome.IsSelected aren't equal");
                Assert.AreEqual(expecteds[elementIndex].TeamHome.CurrentPredictionPoints, actuals[elementIndex].TeamHome.CurrentPredictionPoints, "Match's TeamHome.CurrentPredictionPoints aren't equal");
                Assert.AreEqual(expecteds[elementIndex].TeamHome.CurrentScore, actuals[elementIndex].TeamHome.CurrentScore, "Match's TeamHome.CurrentScore aren't equal");
                Assert.AreEqual(expecteds[elementIndex].TeamHome.WinningPredictionPoints, actuals[elementIndex].TeamHome.WinningPredictionPoints, "Match's TeamHome.WinningPredictionPoints aren't equal");
            }
        }
        
        [Then(@"ระบบส่งข้อมูลผู้ใช้กลับไปเป็น")]
        public void Thenระบบสงขอมลผใชกลบไปเปน(Table table)
        {
            var expected = table.CreateInstance<AccountInformation>();
            var actual = ScenarioContext.Current.Get<GetMatchesRespond>().AccountInfo;

            Assert.AreEqual(expected.SecrectCode, actual.SecrectCode, "Account's SecrectCode isn't matched");
            Assert.AreEqual(expected.Points, actual.Points, "Account's Points isn't matched");
            Assert.AreEqual(expected.MaximumGuessAmount, actual.MaximumGuessAmount, "Account's MaximumGuessAmount isn't matched");
            Assert.AreEqual(expected.CurrentOrderedCoupon, actual.CurrentOrderedCoupon, "Account's CurrentOrderedCoupon isn't matched");
        }

        private IEnumerable<MatchInformation> convertToMatchInformationList(TableRows row)
        {
            var qry = row.Select(it => new MatchInformation
            {
                Id = it.ConvertToInt("Id"),
                LeagueName = it.GetString("LeagueName"),
                Status = it.GetString("Status"),
                BeginDate = it.ConvertToDateTime("BeginDate"),
                CompletedDate = it.ConvertToNullableDateTime("CompletedDate"),
                StartedDate = it.ConvertToNullableDateTime("StartedDate"),
                TeamAway = new TeamInformation
                {
                    Id = it.ConvertToInt("TeamAway.Id"),
                    Name = it.GetString("TeamAway.Name"),
                    IsSelected = it.ConvertToBoolean("TeamAway.IsSelected")
                },
                TeamHome = new TeamInformation
                {
                    Id = it.ConvertToInt("TeamHome.Id"),
                    Name = it.GetString("TeamHome.Name"),
                    IsSelected = it.ConvertToBoolean("TeamHome.IsSelected")
                },
            }).ToList();

            return qry;
        }
    }
}
