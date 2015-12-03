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
                    },
                    TeamHome = new TeamInformation
                    {
                        Id = it.TeamHome.Id,
                        Name = it.TeamHome.Name,
                        CurrentScore = it.TeamHome.CurrentScore,
                        CurrentPredictionPoints = it.TeamHome.CurrentPredictionPoints,
                    },
                }).ToList();
                return qry;
            }
        }

        public void SaveGuess(GuessMatchInformation guess)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedLastGuessed = dctx.GuessMatches
                    .Where(it => it.Account.SecrectCode.Equals(guess.AccountSecrectCode, StringComparison.CurrentCultureIgnoreCase))
                    .Where(it => it.MatchId == guess.MatchId)
                    .FirstOrDefault();
                var isNewGuess = selectedLastGuessed == null;
                if (isNewGuess)
                {
                    var selectedAccount = dctx.Accounts.FirstOrDefault(it => it.SecrectCode.Equals(guess.AccountSecrectCode, StringComparison.CurrentCultureIgnoreCase));
                    if (selectedAccount == null) return;
                    dctx.GuessMatches.Add(new DailySoccer.DAC.EF.GuessMatch
                    {
                        AccountId = selectedAccount.Id,
                        GuessTeamId = guess.GuessTeamId,
                        MatchId = guess.MatchId,
                        PredictionPoints = guess.PredictionPoints
                    });
                    dctx.SaveChanges();
                }
                else
                {
                    selectedLastGuessed.GuessTeamId = guess.MatchId;
                    selectedLastGuessed.PredictionPoints = guess.PredictionPoints;
                    dctx.SaveChanges();
                }
            }
        }
    }
}
