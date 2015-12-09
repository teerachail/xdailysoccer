using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Facades;
using Moq;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class CalculateGameResultSteps
    {
        [When(@"เริ่มคำนวณผลคะแนน")]
        public void Whenเรมคำนวณผลคะแนน()
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Setup(dac => dac.UpdateGuessResult(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<int>()));
            mockAccountDac.Setup(dac => dac.UpdateAccountPoints(It.IsAny<int>(), It.IsAny<int>()));

            var mockMatchDac = ScenarioContext.Current.Get<Moq.Mock<IMatchDataAccess>>();
            mockMatchDac.Setup(dac => dac.UpdateCalculatedGameResult(It.IsAny<IEnumerable<int>>()));

            var currentTime = ScenarioContext.Current.Get<DateTime>();
            FacadeRepository.Instance.MatchFacade.CalculateGameResults(currentTime);
        }

        [Then(@"ระบบไม่ทำการคำนวณผลคะแนน")]
        public void Thenระบบไมทำการคำนวณผลคะแนน()
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Verify(dac => dac.UpdateGuessResult(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<int>()), Times.Never());
            mockAccountDac.Verify(dac => dac.UpdateAccountPoints(It.IsAny<int>(), It.IsAny<int>()), Times.Never());

            var mockMatchDac = ScenarioContext.Current.Get<Moq.Mock<IMatchDataAccess>>();
            mockMatchDac.Verify(dac => dac.UpdateCalculatedGameResult(It.IsAny<IEnumerable<int>>()), Times.Never());
        }
    }
}
