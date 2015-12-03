using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Facades;
using DailySoccer.Shared.Models;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class GuessMatchSteps
    {
        [When(@"ผู้ใช้ UserId: '(.*)' ทายผลแมช์ MatchId: '(.*)' IsGuessTeamHome: '(.*)' เวลาในขณะนั้นเป็น '(.*)'")]
        public void WhenผใชUserIdทายผลแมชMatchIdIsGuessTeamHomeเวลาในขณะนนเปน(string userId, int matchId, bool isGuessTeamHome, DateTime currentTime)
        {
            var mockMatchDataAccess = ScenarioContext.Current.Get<Moq.Mock<IMatchDataAccess>>();
            mockMatchDataAccess.Setup(it => it.SaveGuess(It.IsAny<GuessMatchInformation>()));

            var request = new GuessMatchRequest
            {
                UserId = userId,
                MatchId = matchId,
                IsGuessTeamHome = isGuessTeamHome,
            };
            FacadeRepository.Instance.MatchFacade.GuessMatch(request, currentTime);
        }

        [Then(@"ระบบทำการบันทึกการทายผลไว้ UserId: '(.*)', MatchId: '(.*)', GuessTeamId '(.*)', PredictionPoints '(.*)'")]
        public void ThenระบบทำการบนทกการทายผลไวUserIdMatchIdGuessTeamIdPredictionPoints(string userId, int matchId, int guessTeamId, int predictionPoints)
        {
            var mockMatchDataAccess = ScenarioContext.Current.Get<Moq.Mock<IMatchDataAccess>>();
            mockMatchDataAccess.Verify(dac => dac.SaveGuess(It.Is<GuessMatchInformation>(
                it => it.AccountSecrectCode == userId
                && it.MatchId == matchId
                && it.GuessTeamId.HasValue
                && it.GuessTeamId.Value == guessTeamId
                && it.PredictionPoints == predictionPoints
            )), Times.Once());
        }

        [Then(@"ระบบไม่ทำการบันทึกผลการทาย")]
        public void Thenระบบไมทำการบนทกผลการทาย()
        {
            var mockMatchDataAccess = ScenarioContext.Current.Get<Moq.Mock<IMatchDataAccess>>();
            mockMatchDataAccess.Verify(dac => dac.SaveGuess(It.IsAny<GuessMatchInformation>()), Times.Never());
        }

    }
}
