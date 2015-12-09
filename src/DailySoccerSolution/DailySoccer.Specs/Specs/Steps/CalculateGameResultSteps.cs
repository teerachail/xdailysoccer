using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Facades;
using Moq;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Linq;

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

        [Then(@"ระบบทำการอัพเดทผลการคำนวณให้กับแมช์ดังนี้")]
        public void Thenระบบทำการอพเดทผลการคำนวณใหกบแมชดงน(Table table)
        {
            var expectedUpdateMatchIds = table.Rows.Select(it => it.ConvertToInt("MatchId"));

            var mockMatchDac = ScenarioContext.Current.Get<Moq.Mock<IMatchDataAccess>>();
            mockMatchDac.Verify(dac => dac.UpdateCalculatedGameResult(It.Is<IEnumerable<int>>(
                actual => actual.Count() == expectedUpdateMatchIds.Count()
                && actual.All(it => expectedUpdateMatchIds.Contains(it))
                )), Times.Exactly(1));
        }

        [Then(@"ระบบอัพเดทการทายผล Id: '(.*)', ผลการทาย: '(.*)', คะแนนที่ได้: '(.*)'")]
        public void ThenระบบอพเดทการทายผลIdผลการทายคะแนนทได(int expectedGuessMatchId, bool expectedGuessResult, int expectedAddictionPoints)
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Verify(dac => dac.UpdateGuessResult(
                It.Is<int>(It => It == expectedGuessMatchId),
                It.Is<bool>(it => it == expectedGuessResult),
                It.Is<int>(it => it == expectedAddictionPoints)),
                Times.AtLeastOnce());
        }

        [Then(@"ระบบทำการอัพเดทคะแนนให้กับบัญชีผู้ใช้ Id: '(.*)' เพิ่มคะแนนให้ '(.*)' คะแนน")]
        public void ThenระบบทำการอพเดทคะแนนใหกบบญชผใชIdเพมคะแนนใหคะแนน(int expectedAccountId, int expectedAdditionalPoints)
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Verify(dac => dac.UpdateAccountPoints(
                It.Is<int>(it => it == expectedAccountId),
                It.Is<int>(it => it == expectedAdditionalPoints)),
                Times.Never());
        }

        [Then(@"ระบบไม่ทำการอัพเดทการทายผล")]
        public void Thenระบบไมทำการอพเดทการทายผล()
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Verify(dac => dac.UpdateGuessResult(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<int>()), Times.Never());
        }

        [Then(@"ระบบไม่ทำการทำการอัพเดทคะแนนให้กับบัญชีผู้ใช้ใดๆ")]
        public void Thenระบบไมทำการทำการอพเดทคะแนนใหกบบญชผใชใดๆ()
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Verify(dac => dac.UpdateAccountPoints(It.IsAny<int>(), It.IsAny<int>()), Times.Never());
        }

    }
}
