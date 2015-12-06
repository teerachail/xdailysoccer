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
            // TODO: GetCurrentWinners
            throw new NotImplementedException();
        }
    }
}
