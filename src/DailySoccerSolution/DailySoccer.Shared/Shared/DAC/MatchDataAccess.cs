using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.DAC
{
    public class MatchDataAccess : IMatchDataAccess
    {
        public IEnumerable<MatchInformation> GetAllMatches()
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var qry = dctx.Matches.Select(it => new MatchInformation
                {
                    Id = it.Id,
                    LeagueName = it.LeagueName,
                    BeginDate = it.BeginDate,
                    StartedDate = it.StartedDate,
                    CompletedDate = it.CompletedDate,
                    Status = it.Status,
                    TeamAway = new TeamInformation
                    {
                        Id = it.TeamAway.Id,
                        Name = it.TeamAway.Name,
                        CurrentScore = it.TeamAway.CurrentScore,
                        CurrentPredictionPoints = it.TeamAway.CurrentPredictionPoints,
                    }
                }).ToList();
                return qry;
            }
        }
    }
}
