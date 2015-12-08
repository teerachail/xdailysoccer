using System;
using TechTalk.SpecFlow;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class ConfirmPhoneNumberSteps
    {
        [Given(@"ข้อมูลการขอยืนยันเบอร์โทรทั้งหมดในระบบเป็น")]
        public void Givenขอมลการขอยนยนเบอรโทรทงหมดในระบบเปน(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"ผู้ใช้ UserId: '(.*)' ยืนยันรหัสลับ VerificationCode: '(.*)'")]
        public void WhenผใชUserIdยนยนรหสลบVerificationCode(string userId, string verificationCode)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"ระบบทำการบันทึกการยืนยันเบอร์โทรศัพ '(.*)' ให้กับผู้ใช้ UserId: '(.*)' เสร็จสิ้น")]
        public void ThenระบบทำการบนทกการยนยนเบอรโทรศพใหกบผใชUserIdเสรจสน(string phoneNumber, string userId)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"ระบบไม่ทำการบันทึกข้อมูลและแจ้งเตือนข้อผิดพลาด")]
        public void Thenระบบไมทำการบนทกขอมลและแจงเตอนขอผดพลาด()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
