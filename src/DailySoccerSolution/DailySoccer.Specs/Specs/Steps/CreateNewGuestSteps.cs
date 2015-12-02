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
    public class CreateNewGuestSteps
    {
        [Given(@"มีการเรียกใช้serviceให้สร้าง guest user")]
        public void GivenมการเรยกใชServiceใหสรางGuestUser()
        {
            var accountDataAccess = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            accountDataAccess.Setup(dac => dac.CreateAccount()).Returns(() =>
            {
                return new AccountInformation();
            }); 

        }
        
        [When(@"ระบบทำการสร้างguestให้ใหม่")]
        public void WhenระบบทำการสรางGuestใหใหม()
        {
            var accountFacade = new AccountFacade();
            var guestAccount = accountFacade.CreateNewGuest();
            ScenarioContext.Current.Set(guestAccount);
        }

        [Then(@"ระบบทำการบันทึกขอมูลaccount")]
        public void ThenระบบทำการบนทกขอมลAccount()
        {
            var accountDataAccess = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            accountDataAccess.Verify(it => it.CreateAccount(), Times.Once);
        }


        [Then(@"ระบบทำการส่งข้อมูลguestกลับ")]
        public void ThenระบบทำการสงขอมลGuestกลบ()
        {
            var guestAccount = ScenarioContext.Current.Get<CreateNewGuestRespond>();
            Assert.IsNotNull(guestAccount);
        }
    }
}
