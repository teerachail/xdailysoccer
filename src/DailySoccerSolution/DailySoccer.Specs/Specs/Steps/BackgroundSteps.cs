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
            ScenarioContext.Current.Set(accountDataAccess);
            ScenarioContext.Current.Set(matchDataAccess);

            // Facade
            var accountFacade = new AccountFacade();
            ScenarioContext.Current.Set(accountFacade);

            // Facade repositories
            FacadeRepository.Instance.InitializeDataAccess(accountDataAccess.Object, matchDataAccess.Object);
            
        }
     }
}
