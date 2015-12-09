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

        public GuessMatchRespond GuessMatch(GuessMatchRequest request, DateTime currentTime)
        {
            var invalidRespondData = new GuessMatchRespond
            {
                IsSuccessed = false,
                AccountInfo = new AccountInformation(),
                Matches = Enumerable.Empty<MatchInformation>(),
            };

            var isArgumentsValid = request != null && !string.IsNullOrEmpty(request.UserId);
            if (!isArgumentsValid) return invalidRespondData;

            var accountDac = FacadeRepository.Instance.AccountDataAccess;
            var account = accountDac.GetAccountBySecrectCode(request.UserId);
            if (account == null) return invalidRespondData;

            var limitedPastDate = currentTime.Date.AddDays(-2);
            var limitedFutureDate = currentTime.Date.AddDays(2);
            var selectedMatche = FacadeRepository.Instance.MatchDataAccess.GetAllMatches()
                .Where(it => it.BeginDate.Date >= limitedPastDate)
                .Where(it => it.BeginDate.Date <= limitedFutureDate)
                .FirstOrDefault(it => it.Id == request.MatchId);
            if (selectedMatche == null) return invalidRespondData;

            var isMatchEnableToGuess = !selectedMatche.CompletedDate.HasValue;
            if (isMatchEnableToGuess)
            {
                var updateData = new GuessMatchInformation
                {
                    AccountSecrectCode = request.UserId,
                    MatchId = request.MatchId,
                    GuessTeamId = request.IsCancelGuess ? null : request.IsGuessTeamHome ? new Nullable<int>(selectedMatche.TeamHome.Id) : new Nullable<int>(selectedMatche.TeamAway.Id),
                    PredictionPoints = request.IsCancelGuess ? 0 : request.IsGuessTeamHome ? selectedMatche.TeamHome.CurrentPredictionPoints : selectedMatche.TeamAway.CurrentPredictionPoints
                };
                FacadeRepository.Instance.MatchDataAccess.SaveGuess(updateData);
            }

            var respond = GetMatches(new GetMatchesRequest { UserId = request.UserId }, currentTime);
            return new GuessMatchRespond
            {
                IsSuccessed = true,
                AccountInfo = respond.AccountInfo,
                Matches = respond.Matches
            };
        }

        public void CalculateGameResults(DateTime currentTime)
        {
            var uncalculatedMatches = FacadeRepository.Instance.MatchDataAccess.GetAllMatches()
                .Where(it => it.StartedDate.HasValue)
                .Where(it => it.CompletedDate.HasValue)
                .Where(it => !it.CalculatedDate.HasValue);

            var gameResults = uncalculatedMatches.Select(it =>
            {
                var isTie = it.TeamHome.CurrentScore == it.TeamAway.CurrentScore;
                var isTeamHomeWin = it.TeamHome.CurrentScore > it.TeamAway.CurrentScore;
                var winnerTeamId = isTeamHomeWin ? it.TeamHome.Id : it.TeamAway.Id;
                var result = new
                {
                    MatchId = it.Id,
                    IsTie = isTie,
                    WinnerTeamId = winnerTeamId,
                };
                return result;
            });

            if (!gameResults.Any()) return;

        }
    }
}
