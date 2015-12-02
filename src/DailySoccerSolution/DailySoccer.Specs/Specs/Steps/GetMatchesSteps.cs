using System;
using TechTalk.SpecFlow;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class GetMatchesSteps
    {
        [Given(@"ในระบบมีข้อมูลแมช์เป็น")]
        public void Givenในระบบมขอมลแมชเปน(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"ในระบบมีข้อมูลการทายเป็น")]
        public void Givenในระบบมขอมลการทายเปน(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"ผู้ใช้ UserId: '(.*)' ขอข้อมูลแมช์")]
        public void WhenผใชUserIdขอขอมลแมช(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"ระบบส่งข้อมูลแมช์กลับไปเป็น")]
        public void Thenระบบสงขอมลแมชกลบไปเปน(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"ระบบส่งข้อมูลผู้ใช้กลับไปเป็น")]
        public void Thenระบบสงขอมลผใชกลบไปเปน(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
