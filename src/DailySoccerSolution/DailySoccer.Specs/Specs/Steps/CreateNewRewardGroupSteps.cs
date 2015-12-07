using DailySoccer.Shared.Facades;
using DailySoccer.Shared.Models;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailySoccer.Shared.DAC;
using Moq;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class CreateNewRewardGroupSteps
    {
        [Given(@"ข้อมูลrewordgroupที่อยู่ในระบบคือ")]
        public void GivenขอมลRewordgroupทอยในระบบคอ(Table table)
        {
            var rewardGroup = table.CreateSet<RewardGroupInformation>()
                .OrderBy(it => it.ExpiredDate)
                .ToList();
            var mockRewardDac = ScenarioContext.Current.Get<Moq.Mock<IRewardDataAccess>>();
            mockRewardDac
                .Setup(it => it.GetRewardGroup())
                .Returns(() => rewardGroup);
        }

        [Given(@"Admin ทำการสร้าง rewardgroup คะแนนที่ใช้ในการแลก: '(.*)', วันที่สิ้นสุดการส่งชิงโชค: '(.*)'")]
        public void GivenAdminทำการสรางRewardgroupคะแนนทใชในการแลกวนทสนสดการสงชงโชค(int points, string expiredDate)
        {
            var rewardgroupInfo = new RewardGroupInformation
            {
                RequestPoints = points,
                ExpiredDate = DateTime.Parse(expiredDate)
            };
            ScenarioContext.Current.Set(rewardgroupInfo, "rewardGroupInformation");
        }
       
        [When(@"ระบบทำการตรวจสอบความถูกต้อง")]
        public void Whenระบบทำการตรวจสอบความถกตอง()
        {
            var mockRewardDac = ScenarioContext.Current.Get<Moq.Mock<IRewardDataAccess>>();
            mockRewardDac.Setup(it => it.CreateRewardGroup(It.IsAny<RewardGroupInformation>()));

            var rewardgroupInfo = ScenarioContext.Current.Get<RewardGroupInformation>("rewardGroupInformation");
            FacadeRepository.Instance.RewardFacade.CreateRewardGroup(rewardgroupInfo);
        }
        
        [Then(@"ระบบทำการบันทึกข้อมูล rewardgroup")]
        public void ThenระบบทำการบนทกขอมลRewardgroup()
        {
            var mockRewardDac = ScenarioContext.Current.Get<Moq.Mock<IRewardDataAccess>>();
            mockRewardDac.Verify(it => it.CreateRewardGroup(It.IsAny<RewardGroupInformation>()), Times.Once);
        }

        [Then(@"ระบบไม่ทำการบันทึกข้อมูล rewardgroup")]
        public void ThenระบบไมทำการบนทกขอมลRewardgroup()
        {
            var mockRewardDac = ScenarioContext.Current.Get<Moq.Mock<IRewardDataAccess>>();
            mockRewardDac.Verify(it => it.CreateRewardGroup(It.IsAny<RewardGroupInformation>()), Times.Never);
        }

    }
}
