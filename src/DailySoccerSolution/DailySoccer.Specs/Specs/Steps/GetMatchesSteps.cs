using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Models;
using Moq;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using DailySoccer.Shared.Facades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class GetMatchesSteps
    {
        [Given(@"ในระบบมีข้อมูลแมช์เป็น")]
        public void Givenในระบบมขอมลแมชเปน(Table table)
        {
            var matches = table.CreateSet<MatchInformation>();
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
            var expected = table.CreateSet<MatchInformation>();
            var actual = ScenarioContext.Current.Get<GetMatchesRespond>().Matches;

            Assert.AreEqual(expected.Count(), actual.Count(), "Matches element aren't equal");
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
    }
}
