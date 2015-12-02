using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.DAC
{
    public interface IMatchDataAccess
    {
        IEnumerable<MatchInformation> GetAllMatches();
    }
}
