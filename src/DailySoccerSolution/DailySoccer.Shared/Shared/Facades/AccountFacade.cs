using DailySoccer.DAC.EF;
using DailySoccer.Shared.DAC;
using DailySoccer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySoccer.Shared.Facades
{
    public class AccountFacade
    {
        public CreateNewGuestRespond CreateNewGuest()
        {
            var facade = FacadeRepository.Instance;
            var accountInfo = facade.AccountDataAccess.CreateAccount();
            return new CreateNewGuestRespond()
            {
                AccountInfo = new AccountInformation
                {
                    SecretCode = accountInfo.SecretCode,
                    Points = accountInfo.Points,
                    CurrentOrderedCoupon = accountInfo.CurrentOrderedCoupon,
                    MaximumGuessAmount = accountInfo.MaximumGuessAmount,
                },
                IsSuccessed = true
            };
        }

        public CreateNewGuestRespond CreateNewGuestWithFaceebook(string OAuthId, string email)
        {
            var facade = FacadeRepository.Instance;
            var accountInfo = facade.AccountDataAccess.CreateNewAccountWithFacebook(OAuthId, email);
            return new CreateNewGuestRespond()
            {
                AccountInfo = new AccountInformation
                {
                    SecretCode = accountInfo.SecretCode,
                    Points = accountInfo.Points,
                    CurrentOrderedCoupon = accountInfo.CurrentOrderedCoupon,
                    MaximumGuessAmount = accountInfo.MaximumGuessAmount,
                    OAuthId = accountInfo.OAuthId,
                },
                IsSuccessed = true
            };
        }


        public void UpdateAccountWithFacebook(string secretCode,string OAuthId, string email)
        {
            var facade = FacadeRepository.Instance;
            var accountInfo = facade.AccountDataAccess.GetAccountBySecrectCode(secretCode);
            accountInfo.OAuthId = OAuthId;
            accountInfo.Email = email;
            facade.AccountDataAccess.UpdateAccount(accountInfo);
        }

        public AccountInformation GetAccountBySecretCode(string secretCode)
        {
            var facade = FacadeRepository.Instance;
            return facade.AccountDataAccess.GetAccountBySecrectCode(secretCode);
        }

        public AccountInformation GetAccountByOAuthId(string OAuthId)
        {
            var facade = FacadeRepository.Instance;
            return facade.AccountDataAccess.GetAccountByOAuthId(OAuthId);
        }

        public GetAllLeagueRespond GetAllLeagues()
        {
            var leagues = FacadeRepository.Instance.AccountDataAccess.GetAllLeagues();
            var result = new GetAllLeagueRespond { Leagues = leagues };
            return result;
        }

        public void SetFavoriteTeam(SetFavoriteTeamRequest request)
        {
            const int IgnoreRange = 0;
            var isArgumentValid = request != null 
                && !string.IsNullOrEmpty(request.UserId) 
                && request.SelectedTeamId > IgnoreRange;
            if (!isArgumentValid) return;

            var accountDac = FacadeRepository.Instance.AccountDataAccess;
            var selectedAccount = accountDac.GetAccountBySecrectCode(request.UserId);
            if (selectedAccount == null) return;

            var isSelectedTeamAvailable = accountDac.GetAllLeagues().Any(it => it.TeamId == request.SelectedTeamId);
            if (!isSelectedTeamAvailable) return;

            accountDac.SetFavoriteTeam(request);
        }

        public GetAllGuessHistoryRespond GetAllGuessHistory(GetAllGuessHistoryRequest request, DateTime currentTime)
        {
            var invalidRespondData = new GetAllGuessHistoryRespond
            {
                CurrentDate = currentTime,
                Histories = Enumerable.Empty<GuessHistoryMonthlyInformation>()
            };
            var areArgumentsValid = request != null && !string.IsNullOrEmpty(request.UserId);
            if (!areArgumentsValid) return invalidRespondData;

            var accountDac = FacadeRepository.Instance.AccountDataAccess;
            var guessedMatches = accountDac.GetGuessMatchsByAccountSecrectCode(request.UserId);
            if (guessedMatches == null) return invalidRespondData;

            var matches = FacadeRepository.Instance.MatchDataAccess.GetAllMatches()
                .Where(it => it.BeginDate.Year == currentTime.Year)
                .Where(it => guessedMatches.Any(s => s.MatchId == it.Id))
                .ToList();

            foreach (var match in matches)
            {
                var guess = guessedMatches.First(it => it.MatchId == match.Id);
                if (guess == null) continue;

                var isSelectionGuessValid = guess.GuessTeamId.Value == match.TeamHome.Id || guess.GuessTeamId.Value == match.TeamAway.Id;
                if (!isSelectionGuessValid) continue;

                var isGuessTeamHome = guess.GuessTeamId.Value == match.TeamHome.Id;
                var selectedTeam = isGuessTeamHome ? match.TeamHome : match.TeamAway;
                selectedTeam.IsSelected = true;
                selectedTeam.WinningPredictionPoints = guess.PredictionPoints;
            }

            var qry = from match in matches
                      group match by match.BeginDate.ToString("MMyy") into grouping
                      select grouping;

            var result = new List<GuessHistoryMonthlyInformation>();
            foreach (var item in qry)
            {
                var DateGroup = item.First().BeginDate;
                var totalPoints = (int)item.Where(it => it.CompletedDate.HasValue).Sum(it =>
                {
                    var selectedTeam = it.TeamAway.IsSelected ? it.TeamAway : it.TeamHome;
                    var opponentTeam = it.TeamAway.IsSelected ? it.TeamHome : it.TeamAway;

                    if (selectedTeam.CurrentScore > opponentTeam.CurrentScore) return selectedTeam.WinningPredictionPoints;
                    else if (selectedTeam.CurrentScore == opponentTeam.CurrentScore) return (int)(selectedTeam.WinningPredictionPoints / 2);
                    else return 0;
                });
                result.Add(new GuessHistoryMonthlyInformation
                {
                    Month = DateGroup.Month,
                    TotalPoints = totalPoints
                });
            }

            return new GetAllGuessHistoryRespond
            {
                CurrentDate = currentTime,
                Histories = result
            };
        }

        public GetGuessHistoryByMonthRespond GetGuessHistoryByMonth(GetGuessHistoryByMonthRequest request)
        {
            var invalidRespondData = new GetGuessHistoryByMonthRespond { Histories = Enumerable.Empty<GuessHistoryDailyInformation>() };
            const int MinimumMonth = 1;
            const int MaximumMonth = 12;
            const int MinimumYear = 2015;
            var areArgumentsValid = request != null
                && !string.IsNullOrEmpty(request.UserId)
                && request.Month >= MinimumMonth
                && request.Month <= MaximumMonth
                && request.Year >= MinimumYear;
            if (!areArgumentsValid) return invalidRespondData;

            var accountDac = FacadeRepository.Instance.AccountDataAccess;
            var guessedMatches = accountDac.GetGuessMatchsByAccountSecrectCode(request.UserId);
            if (guessedMatches == null) return invalidRespondData;

            var matches = FacadeRepository.Instance.MatchDataAccess.GetAllMatches()
                .Where(it => it.BeginDate.Year == request.Year)
                .Where(it => it.BeginDate.Month == request.Month)
                .Where(it => guessedMatches.Any(s => s.MatchId == it.Id))
                .ToList();

            foreach (var match in matches)
            {
                var guess = guessedMatches.First(it => it.MatchId == match.Id);
                if (guess == null) continue;

                var isSelectionGuessValid = guess.GuessTeamId.Value == match.TeamHome.Id || guess.GuessTeamId.Value == match.TeamAway.Id;
                if (!isSelectionGuessValid) continue;

                var isGuessTeamHome = guess.GuessTeamId.Value == match.TeamHome.Id;
                var selectedTeam = isGuessTeamHome ? match.TeamHome : match.TeamAway;
                selectedTeam.IsSelected = true;
                selectedTeam.WinningPredictionPoints = guess.PredictionPoints;
            }

            var qry = from match in matches
                      group match by match.BeginDate.Day into grouping
                      select grouping;

            var result = new List<GuessHistoryDailyInformation>();
            foreach (var item in qry)
            {
                var day = item.First().BeginDate;
                var totalPoints = (int)item.Where(it => it.CompletedDate.HasValue).Sum(it =>
                {
                    var selectedTeam = it.TeamAway.IsSelected ? it.TeamAway : it.TeamHome;
                    var opponentTeam = it.TeamAway.IsSelected ? it.TeamHome : it.TeamAway;

                    if (selectedTeam.CurrentScore > opponentTeam.CurrentScore) return selectedTeam.WinningPredictionPoints;
                    else if (selectedTeam.CurrentScore == opponentTeam.CurrentScore) return (int)(selectedTeam.WinningPredictionPoints / 2);
                    else return 0;
                });

                var selectedMatches = matches.Where(it => it.BeginDate.Date == day.Date).ToList();
                foreach (var match in selectedMatches)
                {
                    var selectedGuessMatch = guessedMatches.FirstOrDefault(it => it.MatchId == match.Id);
                    var isSelectedTeamHome = selectedGuessMatch.GuessTeamId == match.TeamHome.Id;
                    var selectedMatch = isSelectedTeamHome ? match.TeamHome : match.TeamAway;
                    var isTieMatch = match.CompletedDate.HasValue ? match.TeamHome.CurrentScore == match.TeamAway.CurrentScore : false;
                    var displayScore = isTieMatch ? selectedGuessMatch.PredictionPoints / 2 : selectedGuessMatch.PredictionPoints;
                    selectedMatch.WinningPredictionPoints = displayScore;
                }

                result.Add(new GuessHistoryDailyInformation
                {
                    Day = day,
                    TotalPoints = totalPoints,
                    Matches = selectedMatches
                });
            }

            return new GetGuessHistoryByMonthRespond { Histories = result };
        }

        public RequestConfirmPhoneNumberRespond RequestConfirmPhoneNumber(RequestConfirmPhoneNumberRequest request)
        {
            var invalidDataModel = new RequestConfirmPhoneNumberRespond { IsSuccessed = false };
            var isArgumentValid = request != null
                && !string.IsNullOrEmpty(request.UserId)
                && !string.IsNullOrEmpty(request.PhoneNo);
            if (!isArgumentValid) return invalidDataModel;

            var phoneNumber = request.PhoneNo.Replace("-", string.Empty);
            const int MinimumPhoneNumberRequired = 6;
            const int MaximumPhoneNumberRequired = 20;
            var isPhoneNumberValid = phoneNumber.Length >= MinimumPhoneNumberRequired && phoneNumber.Length <= MaximumPhoneNumberRequired;
            if (!isPhoneNumberValid) return invalidDataModel;

            var accountDac = FacadeRepository.Instance.AccountDataAccess;
            var selectedAccount = accountDac.GetAccountBySecrectCode(request.UserId);
            var isAccountValid = selectedAccount != null && string.IsNullOrEmpty(selectedAccount.VerifiedPhoneNumber);
            if (!isAccountValid) return invalidDataModel;

            const int RequiredVerificationDigits = 10;
            var verificationCode = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, RequiredVerificationDigits).ToUpper();
            accountDac.RequestConfirmPhoneNumber(request, verificationCode);
            FacadeRepository.Instance.PhoneVerificationFacade.SendMessage(request.PhoneNo, verificationCode);

            return new RequestConfirmPhoneNumberRespond
            {
                IsSuccessed = true,
                ForPhoneNumber = request.PhoneNo,
                VerificationCode = verificationCode
            };
        }

        public ConfirmPhoneNumberRespond ConfirmPhoneNumber(ConfirmPhoneNumberRequest request)
        {
            var confirmationFailed = new ConfirmPhoneNumberRespond();
            var isArgumentsValid = request != null && !string.IsNullOrEmpty(request.UserId) && !string.IsNullOrEmpty(request.VerificationCode);
            if (!isArgumentsValid) return confirmationFailed;

            var accountDac = FacadeRepository.Instance.AccountDataAccess;
            var selectedVerification = accountDac.GetVerificationPhoneByVerificationCode(request.UserId, request.VerificationCode);

            var isVerificationPass = selectedVerification != null
                && !selectedVerification.CompletedDate.HasValue
                && selectedVerification.UserId.Equals(request.UserId, StringComparison.CurrentCultureIgnoreCase)
                && selectedVerification.VerificationCode.Equals(request.VerificationCode, StringComparison.CurrentCultureIgnoreCase)
                && !string.IsNullOrEmpty(selectedVerification.PhoneNumber);
            if (!isVerificationPass) return confirmationFailed;

            accountDac.VerifyPhoneSuccess(request.UserId, selectedVerification.PhoneNumber, request.VerificationCode);
            return new ConfirmPhoneNumberRespond { IsSuccessed = true };
        }

        public bool TieFacbookWithFacebookData(string secrectCode, string OAuthId)
        {
            var accountDac = FacadeRepository.Instance.AccountDataAccess;
            accountDac.TieFacbookWithFacebookData(secrectCode, OAuthId);
            return true;
        }

        public bool TieFacbookWithLocalData(string secrectCode, string OAuthId)
        {
            var accountDac = FacadeRepository.Instance.AccountDataAccess;
            accountDac.TieFacbookWithLocalData(secrectCode, OAuthId);
            return true;
        }
    }
}
