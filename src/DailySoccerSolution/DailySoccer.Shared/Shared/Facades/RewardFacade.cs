using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Facades
{
    public class RewardFacade
    {
        public IEnumerable<RewardGroupInformation> GetRewardGroup()
        {
            var rewardDac = FacadeRepository.Instance.RewardDataAccess;
            return rewardDac.GetRewardGroup();
        }

        public GetCurrentWinnersRespond GetCurrentWinners(DateTime currentTime)
        {
            var rewardDac = FacadeRepository.Instance.RewardDataAccess;
            var selectedRewardGroup = rewardDac.GetRewardGroup()
                .Where(it => it.ExpiredDate.HasValue)
                .OrderByDescending(it => it.ExpiredDate)
                .FirstOrDefault();

            var invalidDataModel = new GetCurrentWinnersRespond { Winners = Enumerable.Empty<WinnerAwardInformation>() };
            if (selectedRewardGroup == null) return invalidDataModel;

            int ordering = 1;
            var result = selectedRewardGroup.RewardInfo.Select(reward =>
            {
                var winnerNames = rewardDac.GetAllWinners()
                        .Where(it => it.RewardId == reward.Id)
                        .Select(it => it.AccountFullName);

                return new WinnerAwardInformation
                {
                    Description = reward.Description,
                    ImagePath = reward.ImagePath,
                    Ordering = ordering++, // HACK: Reward ordering
                    Winners = winnerNames
                };
            }).ToList();

            return new GetCurrentWinnersRespond
            {
                Winners = result
            };
        }
    }
}
