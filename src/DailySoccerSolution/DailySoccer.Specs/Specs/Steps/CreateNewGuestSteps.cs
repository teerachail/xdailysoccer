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
            ScenarioContext.Current.Pending();
        }

        [When(@"ระบบทำการสร้างguestให้ใหม่")]
        public void WhenระบบทำการสรางGuestใหใหม()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"ระบบทำการส่งข้อมูลguestกลับ")]
        public void ThenระบบทำการสงขอมลGuestกลบ()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
