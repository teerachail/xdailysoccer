using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.DAC
{
    public interface IRewardDataAccess
    {
        IEnumerable<RewardGroupInformation> GetRewardGroup();
        RewardGroupInformation GetRewardGroupById(int id);
        IEnumerable<WinnerInformation> GetAllWinners();
    }
}
