using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public sealed class BackgroundSteps
    {
        [Given(@"Setup mocking")]
        public void GivenSetupMocking()
        {
            var mocks = ScenarioContext.Current.Get<Moq.MockRepository>();

            // Data accesses
            var accountDataAccess = mocks.Create<IAccountDataAccess>();
            var matchDataAccess = mocks.Create<IMatchDataAccess>();
            var rewardDataAccess = mocks.Create<IRewardDataAccess>();
            var ticketDataAccess = mocks.Create<ITicketDataAccess>();
            ScenarioContext.Current.Set(accountDataAccess);
            ScenarioContext.Current.Set(matchDataAccess);
            ScenarioContext.Current.Set(rewardDataAccess);
            ScenarioContext.Current.Set(ticketDataAccess);

            // Facade repositories
            FacadeRepository.Instance.InitializeDataAccess(accountDataAccess.Object, matchDataAccess.Object, rewardDataAccess.Object, ticketDataAccess.Object);
        }

        [Given(@"วันเวลาในปัจจุบันเป็น '(.*)'")]
        public void Givenวนเวลาในปจจบนเปน(DateTime currentTime)
        {
            ScenarioContext.Current.Set(currentTime);
        }

    }
}
