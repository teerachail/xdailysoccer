using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using DailySoccer.Shared.Models;
using DailySoccer.Shared.DAC;
using Moq;
using DailySoccer.Shared.Facades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class ConfirmPhoneNumberSteps
    {
        [Given(@"ข้อมูลการขอยืนยันเบอร์โทรทั้งหมดในระบบเป็น")]
        public void Givenขอมลการขอยนยนเบอรโทรทงหมดในระบบเปน(Table table)
        {
            var verifications = table.CreateSet<VerificationPhoneInformation>();
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Setup(dac => dac.VerifyPhoneSuccess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            mockAccountDac.Setup(dac => dac.GetVerificationPhoneByVerificationCode(It.IsAny<string>())).Returns<string>
                (it => verifications.FirstOrDefault(v => v.VerificationCode.Equals(it, StringComparison.CurrentCultureIgnoreCase)));
        }
        
        [When(@"ผู้ใช้ UserId: '(.*)' ยืนยันรหัสลับ VerificationCode: '(.*)'")]
        public void WhenผใชUserIdยนยนรหสลบVerificationCode(string userId, string verificationCode)
        {
            var request = new ConfirmPhoneNumberRequest
            {
                UserId = userId,
                VerificationCode = verificationCode
            };
            var result = FacadeRepository.Instance.AccountFacade.ConfirmPhoneNumber(request);
            ScenarioContext.Current.Set(result);
        }

        [Then(@"ระบบทำการบันทึกการยืนยันเบอร์โทรศัพ '(.*)' และ VerificationCode: '(.*)' ให้กับผู้ใช้ UserId: '(.*)' เสร็จสิ้น")]
        public void ThenระบบทำการบนทกการยนยนเบอรโทรศพและVerificationCodeใหกบผใชUserIdเสรจสน(string phoneNumber, string verificationCode, string userId)
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Verify(dac => dac.VerifyPhoneSuccess(It.Is<string>(it => it == userId), It.Is<string>(it => it == phoneNumber), It.Is<string>(it => it == verificationCode)), Times.Exactly(1));
            mockAccountDac.Verify(dac => dac.GetVerificationPhoneByVerificationCode(It.Is<string>(it => it == verificationCode)), Times.Exactly(1));

            var result = ScenarioContext.Current.Get<ConfirmPhoneNumberRespond>();
            Assert.IsTrue(result.IsSuccessed);
        }

        [Then(@"ระบบไม่ทำการบันทึกข้อมูลและแจ้งเตือนข้อผิดพลาด")]
        public void Thenระบบไมทำการบนทกขอมลและแจงเตอนขอผดพลาด()
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Verify(dac => dac.VerifyPhoneSuccess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}
