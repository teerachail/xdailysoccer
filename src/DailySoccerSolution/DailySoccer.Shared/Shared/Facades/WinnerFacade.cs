using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Facades
{
    public class WinnerFacade
    {
        public GetSelectedTicketRespond GetSelectedTicket(int rewardId)
        {
            var ticketDac = FacadeRepository.Instance.TicketDataAccess;
            var rewardDac = FacadeRepository.Instance.RewardDataAccess;
            var accountDac = FacadeRepository.Instance.AccountDataAccess;

            var selectedReward = rewardDac.GetRewardsById(rewardId);
            var selectedTicket = ticketDac.GetTicketByRewardGroupId(selectedReward.RewardGroupId);
            var selectedWinner = ticketDac.GetTicketBySelectedRewardId(rewardId);


            var rewardRemainingAmount = selectedReward.Amount - selectedWinner.Count();

            var ticketInfo = new List<TicketRespond>();
            var allowSelectTicket = new List<TicketRespond>();
            if (selectedTicket != null)
            {
                var allTicketUnSelected = selectedTicket.Where(it => it.SelectedRewardId == null && accountDac.GetGuestAccountsByAccountId(it.AccountId).Any());
                ticketInfo = (from ticket in selectedWinner.OrderBy(it => it.ApproveWinnerDate)
                              let account = accountDac.GetAccountById(ticket.AccountId)
                              select new TicketRespond
                              {
                                  Id = ticket.Id,
                                  DisplayName = account.VerifiedPhoneNumber,
                                  IsManualSelected = ticket.ManualSelectedDate.HasValue,
                                  IsRandomSelected = ticket.RandomSelectedDate.HasValue,
                                  IsApproveWinner = ticket.ApproveWinnerDate.HasValue
                              }).ToList();

                allowSelectTicket = (from ticket in allTicketUnSelected
                                     let account = accountDac.GetAccountById(ticket.AccountId)
                                     select new TicketRespond
                                     {
                                         Id = ticket.Id,
                                         DisplayName = account.VerifiedPhoneNumber,
                                         IsManualSelected = ticket.ManualSelectedDate.HasValue,
                                         IsRandomSelected = ticket.RandomSelectedDate.HasValue
                                     }).ToList();
            }

            var ticketAmount = ticketInfo.Count() + allowSelectTicket.Count();

            return new GetSelectedTicketRespond()
            {
                Name = selectedReward.Name,
                Description = selectedReward.Description,
                RewardRemainingAmount = rewardRemainingAmount,
                TicketAmount = ticketAmount,
                SelectedTicket = ticketInfo,
                AllTicket = allowSelectTicket,
            };
        }

        public void SelectTicket(int rewardId, int ticketId, DateTime selectedDate)
        {
            var winnerdDac = FacadeRepository.Instance.WinnerDataAccess;
            winnerdDac.SelectTicket(rewardId, ticketId, selectedDate);
        }

        public void CancelSelectedTicket(int rewardId, int ticketId)
        {
            var winnerdDac = FacadeRepository.Instance.WinnerDataAccess;
            winnerdDac.CancelSelectedTicket(rewardId, ticketId);
        }

        public void SubmitSelectedWinner(int rewardId, DateTime approveDate)
        {
            var winnerdDac = FacadeRepository.Instance.WinnerDataAccess;
            winnerdDac.SubmitSelectedWinner(rewardId, approveDate);
        }
    }
}
