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
        public IEnumerable<TicketInformation> GetTicketByRewardGroupId(int rewardGroupId)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedTicket = dctx.Tickets.Where(it => it.RewardGroupId == rewardGroupId);
                if (selectedTicket == null) return null;
                return selectedTicket.Select(it => new TicketInformation
                {
                    Id = it.Id,
                    CreatedDate = it.CreatedDate,
                    ManualSelectedDate = it.ManualSelectedDate,
                    RandomSelectedDate = it.RandomSelectedDate,
                    ApproveWinnerDate = it.ApproveWinnerDate,
                    AccountId = it.AccountId,
                    RewardGroupId = it.RewardGroupId,
                    SelectedRewardId = it.SelectedRewardId
                }).ToList();
            }
        }

        public IEnumerable<TicketInformation> GetTicketBySelectedRewardId(int selectedRewardId)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedTicket = dctx.Tickets.Include("Account")
                    .Where(it => it.SelectedRewardId == selectedRewardId).ToList();
                if (selectedTicket == null) return null;
                return selectedTicket.Select(it => new TicketInformation
                {
                    Id = it.Id,
                    CreatedDate = it.CreatedDate,
                    ManualSelectedDate = it.ManualSelectedDate,
                    RandomSelectedDate = it.RandomSelectedDate,
                    ApproveWinnerDate = it.ApproveWinnerDate,
                    AccountId = it.AccountId,
                    RewardGroupId = it.RewardGroupId,
                    SelectedRewardId = it.SelectedRewardId
                }).ToList();
            }
        }

        public void BuyTicket(string secrectCode, int amount, int rewardGroup)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts.FirstOrDefault(it => it.GuestAccounts
                 .Any(guestAccount => guestAccount.SecretCode.Equals(secrectCode, StringComparison.CurrentCultureIgnoreCase)));
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
