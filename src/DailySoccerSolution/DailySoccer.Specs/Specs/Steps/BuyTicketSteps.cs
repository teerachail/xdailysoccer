using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Facades;
using DailySoccer.Shared.Models;
using Moq;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class BuyTicketSteps
    {
        [When(@"ผู้ใช้ UserId: '(.*)' สั่งซื้อคูปองจำนวน '(.*)' คูปอง")]
        public void WhenผใชUserIdสงซอคปองจำนวนคปอง(string userId, int amount)
        {
            var mockTicketDac = ScenarioContext.Current.Get<Moq.Mock<ITicketDataAccess>>();
            mockTicketDac.Setup(dac => dac.BuyTicket(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));

            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Setup(dac => dac.ChargeFromBuyTicket(It.IsAny<string>(), It.IsAny<int>()));

            var currentDate = ScenarioContext.Current.Get<DateTime>();
            var request = new BuyTicketRequest
            {
                UserId = userId,
                Amount = amount
            };
            var result = FacadeRepository.Instance.TicketFacade.BuyTicket(request, currentDate);
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

        [Then(@"ข้อมูลผู้ใช้ที่ได้กลับมาจากเซิฟเวอร์เป็น")]
        public void Thenขอมลผใชทไดกลบมาจากเซฟเวอรเปน(Table table)
        {
            var expect = table.CreateSet<AccountInformation>().ToList().FirstOrDefault();
            var actual = ScenarioContext.Current.Get<BuyTicketRespond>().AccountInfo;

            Assert.IsNotNull(expect);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expect.SecretCode, actual.SecretCode, "SecretCode");
            Assert.AreEqual(expect.Points, actual.Points, "Points");
            Assert.AreEqual(expect.MaximumGuessAmount, actual.MaximumGuessAmount, "MaximumGuessAmount");
            Assert.AreEqual(expect.CurrentOrderedCoupon, actual.CurrentOrderedCoupon, "CurrentOrderedCoupon");
        }

        [Then(@"ผลการสั่งซื้อสำเร็จเป็น '(.*)' และเวลาหมดอายุของกลุ่มของรางวัลเป็น '(.*)'")]
        public void Thenผลการสงซอสำเรจเปนและเวลาหมดอายของกลมของรางวลเปน(bool isSuccess, DateTime expiredDate)
        {
            var actual = ScenarioContext.Current.Get<BuyTicketRespond>();
            Assert.AreEqual(isSuccess, actual.IsSuccessed);
            Assert.AreEqual(expiredDate, actual.RewardResultDate);
        }

        [Then(@"ระบบทำการบันทึกการสั่งซื้อคูปอง '(.*)' คูปอง จากผู้ใช้ UserId: '(.*)' จากกลุ่มของรางวัลรหัส '(.*)'")]
        public void ThenระบบทำการบนทกการสงซอคปองคปองจากผใชUserIdจากกลมของรางวลรหส(int amount, string userId, int rewardGroupId)
        {
            var mockTicketDac = ScenarioContext.Current.Get<Moq.Mock<ITicketDataAccess>>();
            mockTicketDac.Verify(dac => dac.BuyTicket(It.Is<string>(it => it == userId), It.Is<int>(it => it == amount), It.Is<int>(it => it == rewardGroupId)), Times.Exactly(1));
        }

        [Then(@"ผู้ใช้ UserId: '(.*)' ถูกหักแต้มจำนวน '(.*)' แต้ม")]
        public void ThenผใชUserIdถกหกแตมจำนวนแตม(string userId, int points)
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Verify(dac => dac.ChargeFromBuyTicket(It.Is<string>(it => it == userId), It.Is<int>(it => it == points)), Times.Exactly(1));
        }
    }
}
