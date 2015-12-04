using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Facades;
using DailySoccer.Shared.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class GetAllLeagueSteps
    {
        [Given(@"ข้อมูลทีมทั้งหมดในระบบมีเป็น")]
        public void Givenขอมลทมทงหมดในระบบมเปน(Table table)
        {
            var leagues = table.CreateSet<LeagueInformation>();
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Setup(it => it.GetAllLeagues()).Returns(() => leagues);
        }
        
        [When(@"ขอข้อมูลทีมทั้งหมดในระบบ")]
        public void Whenขอขอมลทมทงหมดในระบบ()
        {
            var result = FacadeRepository.Instance.AccountFacade.GetAllLeagues();
            ScenarioContext.Current.Set(result);
        }
        
        [Then(@"ระบบส่งข้อมูลทีมทั้งหมดในระบบมีเป็น")]
        public void Thenระบบสงขอมลทมทงหมดในระบบมเปน(Table table)
        {
            var expecteds = table.CreateSet<LeagueInformation>()
                .OrderBy(it => it.TeamId)
                .ThenBy(it => it.TeamName)
                .ThenBy(it => it.LeagueName)
                .ToList();
            var actuals = ScenarioContext.Current.Get<GetAllLeagueRespond>()
                .Leagues.OrderBy(it => it.TeamId)
                .ThenBy(it => it.TeamName)
                .ThenBy(it => it.LeagueName)
                .ToList();
            Assert.AreEqual(expecteds.Count, actuals.Count, "Element count aren't match");

            for (int elementIndex = 0; elementIndex < expecteds.Count; elementIndex++)
            {
                var errorMessage = string.Format(" (TeamId: {0})", expecteds[elementIndex].TeamId);
                Assert.AreEqual(expecteds[elementIndex].TeamId, actuals[elementIndex].TeamId, "Team's id aren't match" + errorMessage);
                Assert.AreEqual(expecteds[elementIndex].TeamName, actuals[elementIndex].TeamName, "Team's name aren't match" + errorMessage);
                Assert.AreEqual(expecteds[elementIndex].LeagueName, actuals[elementIndex].LeagueName, "LeagueName aren't match" + errorMessage);
            }
        }
    }
}
