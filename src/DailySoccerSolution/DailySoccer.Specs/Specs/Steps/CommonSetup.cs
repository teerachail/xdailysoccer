using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DailySoccer.Specs.Steps
{
    [Binding]
    public sealed class CommonSetup
    {
        [Given(@"ผู้ใช้ในระบบมีดังนี้")]
        public void Givenผใชในระบบมดงน(Table table)
        {
            var accounts = table.CreateSet<AccountInformation>().ToList();
            var mockAccountDac = ScenarioContext.Current.Get<Moq.Mock<IAccountDataAccess>>();
            mockAccountDac.Setup(it => it.GetAccountBySecrectCode(It.IsAny<string>())).Returns<string>(it =>
            {
                return accounts.FirstOrDefault(account => account.SecretCode == it);
            });
        }

        public static IEnumerable<MatchInformation> ConvertToMatchInformationList(TableRows row)
        {
            var qry = row.Select(it => new MatchInformation
            {
                Id = it.ConvertToInt("Id"),
                LeagueName = it.GetString("LeagueName"),
                Status = it.GetString("Status"),
                BeginDate = it.ConvertToDateTime("BeginDate"),
                CompletedDate = it.ConvertToNullableDateTime("CompletedDate"),
                StartedDate = it.ConvertToNullableDateTime("StartedDate"),
                CalculatedDate = it.ConvertToNullableDateTime("CalculatedDate"),
                TeamAway = new TeamInformation
                {
                    Id = it.ConvertToInt("TeamAway.Id"),
                    Name = it.GetString("TeamAway.Name"),
                    CurrentScore = it.ConvertToInt("TeamAway.CurrentScore"),
                    IsSelected = it.ConvertToBoolean("TeamAway.IsSelected"),
                    CurrentPredictionPoints = it.ConvertToInt("TeamAway.CurrentPredictionPoints"),
                    WinningPredictionPoints = it.ConvertToInt("TeamAway.WinningPredictionPoints")
                },
                TeamHome = new TeamInformation
                {
                    Id = it.ConvertToInt("TeamHome.Id"),
                    Name = it.GetString("TeamHome.Name"),
                    CurrentScore = it.ConvertToInt("TeamHome.CurrentScore"),
                    IsSelected = it.ConvertToBoolean("TeamHome.IsSelected"),
                    CurrentPredictionPoints = it.ConvertToInt("TeamHome.CurrentPredictionPoints"),
                    WinningPredictionPoints = it.ConvertToInt("TeamHome.WinningPredictionPoints")
                },
            }).ToList();

            return qry;
        }
    }
}
