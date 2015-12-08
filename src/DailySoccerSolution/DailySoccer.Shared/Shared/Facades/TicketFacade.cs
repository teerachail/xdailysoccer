using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Facades
{
    public class TicketFacade
    {
        public BuyTicketRespond BuyTicket(BuyTicketRequest request)
        {
            var invalidDataModel = new BuyTicketRespond { IsSuccessed = false };
            var MinimumBuyTicketRequest = 1;
            var areArgumentValid = request != null
                && !string.IsNullOrEmpty(request.UserId)
                && request.Amount >= MinimumBuyTicketRequest;
            if (!areArgumentValid) return invalidDataModel;

            var selectedAccount = FacadeRepository.Instance.AccountDataAccess.GetAccountBySecrectCode(request.UserId);
            if (selectedAccount == null) return invalidDataModel;

            var rewardDac = FacadeRepository.Instance.RewardDataAccess;
            var currentRewardGroup = rewardDac.GetRewardGroup()
                .OrderByDescending(it => it.ExpiredDate)
                .FirstOrDefault();

            var isCurrentRewardAvailableForBuy = currentRewardGroup != null && currentRewardGroup.RewardInfo.Any();
            if (!isCurrentRewardAvailableForBuy) return invalidDataModel;

            var requiredPoints = currentRewardGroup.RequestPoints * request.Amount;
            var isNeedReachMinimumRequirement = selectedAccount.Points >= requiredPoints;
            if (!isNeedReachMinimumRequirement) return invalidDataModel;

            FacadeRepository.Instance.TicketDataAccess.BuyTicket(request.UserId, request.Amount, currentRewardGroup.Id);
            FacadeRepository.Instance.AccountDataAccess.ChargeFromBuyTicket(request.UserId, requiredPoints);

            selectedAccount.Points -= requiredPoints;
            selectedAccount.CurrentOrderedCoupon += request.Amount;
            return new BuyTicketRespond
            {
                AccountInfo = selectedAccount,
                IsSuccessed = true,
                RewardResultDate = currentRewardGroup.ExpiredDate
            };
        }
    }
}
