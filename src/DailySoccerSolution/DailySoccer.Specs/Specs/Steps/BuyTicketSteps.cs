using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Facades;
using DailySoccer.Shared.Models;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class BuyTicketSteps
    {
        [When(@"ผู้ใช้ UserId: '(.*)' สั่งซื้อคูปองจำนวน '(.*)' คูปอง")]
        public void WhenผใชUserIdสงซอคปองจำนวนคปอง(string userId, int amount)
        {
            var request = new BuyTicketRequest
            {
                UserId = userId,
                Amount = amount
            };
            var result = FacadeRepository.Instance.TicketFacade.BuyTicket(request);
            ScenarioContext.Current.Set(result);
        }
        
        [Then(@"ระบบไม่ทำการบันทึกการสั่งซื้อ")]
        public void Thenระบบไมทำการบนทกการสงซอ()
        {
            var mockTicketDac = ScenarioContext.Current.Get<Moq.Mock<ITicketDataAccess>>();
            mockTicketDac.Verify(dac => dac.BuyTicket(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }
        
        [Then(@"แต้มผู้ใช้ไม่ถูกหัก")]
        public void Thenแตมผใชไมถกหก()
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Verify(dac => dac.ChargeFromBuyTicket(It.IsAny<string>(), It.IsAny<int>()), Times.Never);
        }
    }
}
