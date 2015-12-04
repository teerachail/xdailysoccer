using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Facades;
using DailySoccer.Shared.Models;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public class SetFavoriteTeamSteps
    {
        [When(@"ผู้ใช้ UserId: '(.*)' เลือกทีมที่ชอบเป็น SelectedTeamId: '(.*)'")]
        public void WhenผใชUserIdเลอกทมทชอบเปนSelectedTeamId(string userId, int selectedTeamId)
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Setup(dac => dac.SetFavoriteTeam(It.IsAny<SetFavoriteTeamRequest>()));

            FacadeRepository.Instance.AccountFacade.SetFavoriteTeam(new Shared.Models.SetFavoriteTeamRequest
            {
                UserId = userId,
                SelectedTeamId = selectedTeamId
            });
        }
        
        [Then(@"ระบบทำการบันทึกข้อมูลทีมที่ชอบ ผู้ใช้ UserId: '(.*)' เลือกทีมที่ชอบเป็น SelectedTeamId: '(.*)'")]
        public void ThenระบบทำการบนทกขอมลทมทชอบผใชUserIdเลอกทมทชอบเปนSelectedTeamId(string userId, int selectedTeamId)
        {
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Verify(dac => dac.SetFavoriteTeam(It.Is<SetFavoriteTeamRequest>(
                it => it.UserId.Equals(userId, StringComparison.CurrentCultureIgnoreCase)
                && it.SelectedTeamId == selectedTeamId
                )), Times.Once());
        }
    }
}
