using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Facades
{
    public class MatchFacade
    {
        public GetMatchesRespond GetMatches(GetMatchesRequest request, DateTime currentTime)
        {
            var invalidRespondData = new GetMatchesRespond
            {
                CurrentDate = currentTime,
                AccountInfo = new AccountInformation(),
                Matches = Enumerable.Empty<MatchInformation>()
            };

            var isArgumentsValid = request != null && !string.IsNullOrEmpty(request.UserId);
            if (!isArgumentsValid) return invalidRespondData;

            var accountDac = FacadeRepository.Instance.AccountDataAccess;
            var account = accountDac.GetAccountBySecrectCode(request.UserId);
            if (account == null) return invalidRespondData;

            var guessMatches = accountDac.GetGuessMatchsByAccountSecrectCode(request.UserId)
                .Where(it => it.GuessTeamId.HasValue)
                .ToList();

            var limitedPastDate = currentTime.Date.AddDays(-2);
            var limitedFutureDate = currentTime.Date.AddDays(2);

            var matches = FacadeRepository.Instance.MatchDataAccess.GetAllMatches()
                .Where(it => it.BeginDate.Date >= limitedPastDate)
                .Where(it => it.BeginDate.Date <= limitedFutureDate)
                .ToList();
            foreach (var match in matches.Where(it => guessMatches.Select(guess => guess.MatchId).Contains(it.Id)))
            {
                var guess = guessMatches.First(it => it.MatchId == match.Id);
                if (guess == null) continue;

                var isSelectionGuessValid = guess.GuessTeamId.Value == match.TeamHome.Id || guess.GuessTeamId.Value == match.TeamAway.Id;
                if (!isSelectionGuessValid) continue;

                var isGuessTeamHome = guess.GuessTeamId.Value == match.TeamHome.Id;
                var selectedTeam = isGuessTeamHome ? match.TeamHome : match.TeamAway;
                selectedTeam.IsSelected = true;
                selectedTeam.WinningPredictionPoints = guess.PredictionPoints;
            }

            return new GetMatchesRespond
            {
                CurrentDate = currentTime,
                AccountInfo = account,
                Matches = matches
            };
        }
    }
}
