using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailySoccer.Shared.Models;

namespace DailySoccer.Shared.DAC
{
    public class TicketDataAccess : ITicketDataAccess
    {
        public void BuyTicket(string secrectCode, int amount, int rewardGroup)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts.FirstOrDefault(it => it.SecretCode.Equals(secrectCode, StringComparison.CurrentCultureIgnoreCase));
                if (selectedAccount == null) return;

                var selectedRewardGroup = dctx.RewardGroups.FirstOrDefault(it => it.Id == rewardGroup);
                if (selectedRewardGroup == null) return;

                var now = DateTime.Now;
                for (int buyCounter = 0; buyCounter < amount; buyCounter++)
                {
                    var data = new DailySoccer.DAC.EF.Ticket
                    {
                        AccountId = selectedAccount.Id,
                        RewardGroupId = selectedRewardGroup.Id,
                        CreatedDate = now
                    };
                    selectedAccount.Tickets.Add(data);
                }
                dctx.SaveChanges();
            }
        }
    }
}
