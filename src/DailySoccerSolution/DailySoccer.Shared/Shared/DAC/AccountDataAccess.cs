using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailySoccer.Shared.Models;
using DailySoccer.DAC.EF;

namespace DailySoccer.Shared.DAC
{
    public class AccountDataAccess : IAccountDataAccess
    {
        public AccountInformation CreateAccount()
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var SecrectCode = Guid.NewGuid().ToString();

                dctx.Accounts.Add(new Account
                {
                    Points = 0,
                    GuestAccounts = new List<GuestAccount>()
                    {
                        new GuestAccount
                        {
                            SecretCode = SecrectCode
                        }
                    }
                });
                dctx.SaveChanges();

                return new AccountInformation()
                {
                    SecretCode = SecrectCode,
                };
            }
        }

        public AccountInformation CreateNewAccountWithFacebook(string OAuthId, string email)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var SecrectCode = Guid.NewGuid().ToString();

                dctx.Accounts.Add(new Account
                {
                    Points = 0,
                    Email = email,
                    OAuthId = OAuthId,
                    GuestAccounts = new List<GuestAccount>()
                    {
                        new GuestAccount
                        {
                            SecretCode = SecrectCode
                        }
                    }
                });
                dctx.SaveChanges();

                return new AccountInformation()
                {
                    SecretCode = SecrectCode,
                    OAuthId = OAuthId,
                };
            }
        }

        public AccountInformation GetAccountBySecrectCode(string secrectCode)
        {
            var isArgumentValid = !string.IsNullOrEmpty(secrectCode);
            if (!isArgumentValid) return null;

            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts
                    .Include("Tickets")
                    .Where(it => it.GuestAccounts.Any(guestAccount => guestAccount.SecretCode.Equals(secrectCode, StringComparison.CurrentCultureIgnoreCase)))
                    .FirstOrDefault();
                if (selectedAccount == null) return null;

                var currentRewardGroup = Facades.FacadeRepository.Instance.RewardDataAccess.GetRewardGroup()
                    .OrderByDescending(it => it.ExpiredDate)
                    .FirstOrDefault();

                var currentOrderedCoupon = selectedAccount.Tickets
                    .Where(it => it.RewardGroupId == currentRewardGroup.Id)
                    .Count();

                return new AccountInformation
                {
                    MaximumGuessAmount = 5, // HACK: Maximum guess amount
                    CurrentOrderedCoupon = currentOrderedCoupon,
                    Points = selectedAccount.Points,
                    SecretCode = secrectCode,
                    OAuthId = selectedAccount.OAuthId,
                    Email = selectedAccount.Email,
                    VerifiedPhoneNumber = selectedAccount.VerifiedPhoneNumber
                };
            }
        }

        public AccountInformation GetAccountByOAuthId(string OAuthId)
        {
            var isArgumentValid = !string.IsNullOrEmpty(OAuthId);
            if (!isArgumentValid) return null;

            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts
                    .FirstOrDefault(it => it.OAuthId.Equals(OAuthId, StringComparison.CurrentCultureIgnoreCase));
                if (selectedAccount == null) return null;

                return new AccountInformation
                {
                    Points = selectedAccount.Points,
                    OAuthId = selectedAccount.OAuthId,
                    Email = selectedAccount.Email,
                    VerifiedPhoneNumber = selectedAccount.VerifiedPhoneNumber
                };
            }
        }

        public void UpdateAccount(AccountInformation accountInfo)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts.FirstOrDefault(it => it.GuestAccounts
                .Any(guestAccount => guestAccount.SecretCode.Equals(accountInfo.SecretCode, StringComparison.CurrentCultureIgnoreCase)));
                if (selectedAccount != null)
                {
                    selectedAccount.OAuthId = accountInfo.OAuthId;
                    selectedAccount.Email = accountInfo.Email;
                    selectedAccount.VerifiedPhoneNumber = accountInfo.VerifiedPhoneNumber;
                    selectedAccount.Points = accountInfo.Points;
                    dctx.SaveChanges();
                }
            }
        }

        public IEnumerable<GuessMatchInformation> GetGuessMatchsByAccountSecrectCode(string secrectCode)
        {
            var isArgumentValid = !string.IsNullOrEmpty(secrectCode);
            if (!isArgumentValid) return Enumerable.Empty<GuessMatchInformation>();

            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts
                    .Include("GuessMatches")
                    .Where(it => it.GuestAccounts.Any(guestAccount => guestAccount.SecretCode.Equals(secrectCode, StringComparison.CurrentCultureIgnoreCase)))
                    .FirstOrDefault();
                if (selectedAccount == null) return Enumerable.Empty<GuessMatchInformation>();

                var result = selectedAccount.GuessMatches
                    .Select(it => new GuessMatchInformation
                    {
                        Id = it.Id,
                        AccountSecrectCode = secrectCode,
                        GuessTeamId = it.GuessTeamId,
                        MatchId = it.MatchId,
                        PredictionPoints = it.PredictionPoints
                    }).ToList();

                return result;
            }
        }

        public IEnumerable<GuessMatchInformation> GetGuessMatchsByMatchId(int matchId)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedMatch = dctx.Matches
                    .Include("GuessMatches.Account")
                    .Where(it => it.Id == matchId)
                    .FirstOrDefault();
                if (selectedMatch == null) return Enumerable.Empty<GuessMatchInformation>();

                var result = selectedMatch.GuessMatches
                    .Select(it => new GuessMatchInformation
                    {
                        Id = it.Id,
                        AccountId = it.AccountId,
                        GuessTeamId = it.GuessTeamId,
                        MatchId = it.MatchId,
                        PredictionPoints = it.PredictionPoints
                    }).ToList();

                return result;
            }
        }

        public IEnumerable<LeagueInformation> GetAllLeagues()
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var result = dctx.FavoriteTeams
                    .Select(it => new LeagueInformation
                    {
                        TeamId = it.Id,
                        LeagueName = it.LeagueName,
                        TeamName = it.TeamName
                    }).ToList();
                return result;
            }
        }

        public void SetFavoriteTeam(SetFavoriteTeamRequest request)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts.FirstOrDefault(it => it.GuestAccounts
                .Any(guestAccount => guestAccount.SecretCode.Equals(request.UserId, StringComparison.CurrentCultureIgnoreCase)));
                if (selectedAccount == null) return;

                var selectedTeam = dctx.FavoriteTeams.FirstOrDefault(it => it.Id == request.SelectedTeamId);
                if (selectedTeam == null) return;

                selectedAccount.FavoriteTeam = selectedTeam;
                dctx.SaveChanges();
            }
        }

        public void ChargeFromBuyTicket(string secrectCode, int requiredPoints)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts.FirstOrDefault(it => it.GuestAccounts
                .Any(guestAccount => guestAccount.SecretCode.Equals(secrectCode, StringComparison.CurrentCultureIgnoreCase)));
                if (selectedAccount == null) return;

                selectedAccount.Points -= requiredPoints;
                dctx.SaveChanges();
            }
        }

        public void RequestConfirmPhoneNumber(RequestConfirmPhoneNumberRequest request, string verificationCode)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var newData = new PhoneVerification
                {
                    PhoneNumber = request.PhoneNo,
                    UserId = request.UserId,
                    VerificationCode = verificationCode
                };
                dctx.PhoneVerifications.Add(newData);
                dctx.SaveChanges();
            }
        }

        public VerificationPhoneInformation GetVerificationPhoneByVerificationCode(string userId, string verificationCode)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var result = dctx.PhoneVerifications
                    .Where(it => it.UserId.Equals(userId, StringComparison.CurrentCultureIgnoreCase))
                    .Where(it => it.VerificationCode.Equals(verificationCode, StringComparison.CurrentCultureIgnoreCase))
                    .Select(it => new VerificationPhoneInformation
                    {
                        Id = it.Id,
                        UserId = it.UserId,
                        PhoneNumber = it.PhoneNumber,
                        CompletedDate = it.CompletedDate,
                        VerificationCode = it.VerificationCode
                    }).FirstOrDefault();

                return result;
            }
        }

        public void VerifyPhoneSuccess(string userId, string phoneNo, string verificationCode)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedVerification = dctx.PhoneVerifications
                    .Where(it => it.UserId.Equals(userId, StringComparison.CurrentCultureIgnoreCase))
                    .Where(it => it.VerificationCode.Equals(verificationCode, StringComparison.CurrentCultureIgnoreCase))
                    .FirstOrDefault();
                if (selectedVerification == null) return;

                var selectedAccount = dctx.Accounts.FirstOrDefault(it => it.GuestAccounts
                .Any(guestAccount => guestAccount.SecretCode.Equals(userId, StringComparison.CurrentCultureIgnoreCase)));
                if (selectedAccount == null) return;

                selectedVerification.CompletedDate = DateTime.Now;
                selectedAccount.VerifiedPhoneNumber = phoneNo;
                dctx.SaveChanges();
            }
        }

        public void UpdateGuessResult(int guessMatchId, bool isGuessCorrect, int gotPoints)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedGuessMatch = dctx.GuessMatches.FirstOrDefault(it => it.Id == guessMatchId);
                if (selectedGuessMatch == null) return;

                selectedGuessMatch.IsWinner = isGuessCorrect;
                selectedGuessMatch.WinnerPoints = gotPoints;
                dctx.SaveChanges();
            }
        }

        public void UpdateAccountPoints(int accountId, int additionPoints)
        {
            using (var dctx = new DailySoccer.DAC.EF.DailySoccerModelContainer())
            {
                var selectedAccount = dctx.Accounts.FirstOrDefault(it => it.Id == accountId);
                if (selectedAccount == null) return;

                selectedAccount.Points += additionPoints;
                dctx.SaveChanges();
            }
        }
    }
}
