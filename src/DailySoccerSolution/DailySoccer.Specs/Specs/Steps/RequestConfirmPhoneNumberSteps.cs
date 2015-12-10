using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Facades;
using DailySoccer.Shared.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class RequestConfirmPhoneNumberSteps
    {
        [When(@"ผู้ใช้ UserId: '(.*)' ขอยืนยันเบอร์โทรศัพ '(.*)'")]
        public void WhenผใชUserIdขอยนยนเบอรโทรศพ(string userId, string phoneNumber)
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Setup(dac => dac.RequestConfirmPhoneNumber(It.IsAny<RequestConfirmPhoneNumberRequest>(), It.IsAny<string>()));

            var mockSMSSender = ScenarioContext.Current.Get<Moq.Mock<ISMSSender>>();
            mockSMSSender.Setup(dac => dac.Send(It.IsAny<string>(), It.IsAny<string>()));

            var request = new Shared.Models.RequestConfirmPhoneNumberRequest
            {
                UserId = userId,
                PhoneNo = phoneNumber
            };
            var result = FacadeRepository.Instance.AccountFacade.RequestConfirmPhoneNumber(request);
            ScenarioContext.Current.Set(result);
        }

        [Then(@"ระบบบันทึกเบอร์โทร '(.*)' ของผู้ใช้ UserId: '(.*)' แล้วส่งรหัสลับในการยืนยันกลับไป")]
        public void ThenระบบบนทกเบอรโทรของผใชUserIdแลวสงรหสลบในการยนยนกลบไป(string phoneNumber, string userId)
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Verify(dac => dac.RequestConfirmPhoneNumber(It.Is<RequestConfirmPhoneNumberRequest>(
                it => it.UserId == userId && it.PhoneNo == phoneNumber
                ), It.IsAny<string>()), Times.Exactly(1));

            var result = ScenarioContext.Current.Get<RequestConfirmPhoneNumberRespond>();
            Assert.IsNotNull(result);
            Assert.AreEqual(phoneNumber, result.ForPhoneNumber);
            Assert.IsNotNull(result.VerificationCode);
            Assert.IsTrue(result.IsSuccessed);

            var mockSMSSender = ScenarioContext.Current.Get<Moq.Mock<ISMSSender>>();
            mockSMSSender.Verify(dac => dac.Send(
                It.Is<string>(it => it.Equals(phoneNumber, StringComparison.CurrentCultureIgnoreCase)),
                It.IsAny<string>()),
                Times.Exactly(1));
        }

        [Then(@"ระบบไม่ทำการบันทึกเบอร์โทรและไม่ส่งรหัสลับกลับไป")]
        public void Thenระบบไมทำการบนทกเบอรโทรและไมสงรหสลบกลบไป()
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Verify(dac => dac.RequestConfirmPhoneNumber(It.IsAny<RequestConfirmPhoneNumberRequest>(), It.IsAny<string>()), Times.Never);

            var result = ScenarioContext.Current.Get<RequestConfirmPhoneNumberRespond>();
            Assert.IsNotNull(result);
            Assert.IsNull(result.ForPhoneNumber);
            Assert.IsNull(result.VerificationCode);
            Assert.IsFalse(result.IsSuccessed);

            var mockSMSSender = ScenarioContext.Current.Get<Moq.Mock<ISMSSender>>();
            mockSMSSender.Verify(dac => dac.Send(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        }
    }
}
