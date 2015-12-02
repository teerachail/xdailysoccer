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
                return accounts.FirstOrDefault(account => account.SecrectCode == it);
            });
        }
    }
}
